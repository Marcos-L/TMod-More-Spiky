using SpikyBalls.Content.Items.Weapons;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Terraria.Chat;

namespace SpikyBalls.Content.Projectiles
{
	public class CrystalBallProjectile : ModProjectile
	{	
		public override string Texture => "SpikyBalls/Content/Items/Weapons/CrystalBall";

		public override void SetStaticDefaults() {
			ProjectileID.Sets.DontAttachHideToAlpha[Type] = true;
		}

		public override void SetDefaults() {
			Projectile.width = 14; // The width of projectile hitbox
			Projectile.height = 14; // The height of projectile hitbox
			Projectile.aiStyle = 0; // The ai style of the projectile (0 means custom AI). For more please reference the source code of Terraria
			Projectile.friendly = true; // Can the projectile deal damage to enemies?
			Projectile.hostile = false; // Can the projectile deal damage to the player?
			Projectile.DamageType = DamageClass.Ranged; // Makes the projectile deal ranged damage. You can set in to DamageClass.Throwing, but that is not used by any vanilla items
			Projectile.penetrate = 5; // How many monsters the projectile can penetrate.
			Projectile.timeLeft = 3600; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
			Projectile.light = 0.5f; // How much light emit around the projectile
			Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
			Projectile.tileCollide = true; // Can the projectile collide with tiles?
			Projectile.hide = false; // Makes the projectile completely invisible. We need this to draw our projectile behind enemies/tiles in DrawBehind()
			Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 30;
		}

		public override void AI()
        {
			Lighting.AddLight(Projectile.position, 0.84f, 0.21f, 0.92f);
            if (Projectile.ai[0] != 1f)
            {
                Projectile.localAI[1] += 1f;
                if (Projectile.localAI[1] > 10f)
                {
                    Projectile.localAI[1] = 10f;
                    if (Projectile.velocity.Y == 0f && Projectile.velocity.X != 0f)
                    {
                        Projectile.velocity.X *= 0.97f;
                        if (Math.Abs(Projectile.velocity.X) < 0.01f)
                        {
                            Projectile.velocity.X = 0f;
                            Projectile.netUpdate = true;
                        }
                    }
                    Projectile.velocity.Y += 0.2f;
                }
                Projectile.rotation += Projectile.velocity.X * 0.1f;
            }
        }

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			var vector1 = new Vector2(7,7);
			Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.position, vector1.RotateRandom(2*Math.PI), ProjectileID.CrystalShard, 16, 1, Projectile.owner);
			Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.position, vector1.RotateRandom(2*Math.PI), ProjectileID.CrystalShard, 16, 1, Projectile.owner);
			Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.position, vector1.RotateRandom(2*Math.PI), ProjectileID.CrystalShard, 16, 1, Projectile.owner);
			Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.position, vector1.RotateRandom(2*Math.PI), ProjectileID.CrystalShard, 16, 1, Projectile.owner);
		}

		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac){
			// if (ConsoleText){
			// 	ConsoleText = false;
			// 	Main.NewText($"fallThrough: {fallThrough}");
			// }
			fallThrough = false;
			return true;
		}
		public override bool OnTileCollide(Vector2 velocityChange) {
			return false;
		}

		public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            if (targetHitbox.Width > 8 && targetHitbox.Height > 8)
            {
                targetHitbox.Inflate(-targetHitbox.Width / 8, -targetHitbox.Height / 8);
            }
            return null;
        }
	}
}