using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpikyBalls.Content.Items.Weapons
{
	public class BouncyBall : ModItem
	{
		public override void SetDefaults() {
			// Alter any of these values as you see fit, but you should probably keep useStyle on 1, as well as the noUseGraphic and noMelee bools

			// Common Properties
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(copper: 20);
			Item.maxStack = 9999;

			// Use Properties
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useAnimation = 25;
			Item.useTime = 25;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.consumable = true;

			// Weapon Properties			
			Item.damage = 16;
			Item.knockBack = 10f;
			Item.noUseGraphic = true; // The item should not be visible when used
			Item.noMelee = true; // The projectile will do the damage and not the item
			Item.DamageType = DamageClass.Ranged;

			// Projectile Properties
			Item.shootSpeed = 8f;
			Item.shoot = ModContent.ProjectileType<Projectiles.BouncyBallProjectile>(); // The projectile that will be thrown
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			CreateRecipe(50)
				.AddIngredient(ItemID.SpikyBall, 50)
				.AddIngredient(ItemID.PinkGel)
				.Register();
		}
	}
}