using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using LetItRip.Content.Projectiles.BeyProjectiles;
using LetItRip.Content.Items.BasicItems;

namespace LetItRip.Content.Items.Beys
{ 
	// This is a basic item template.
	// Please see tModLoader's ExampleMod for every other example:
	// https://github.com/tModLoader/tModLoader/tree/stable/ExampleMod
	public class CobaltDrake : ModItem
	{
		// The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.LetItRip.hjson' file.
		public override void SetDefaults()
		{
			Item.damage = 31;
			Item.DamageType = DamageClass.Melee;
            Item.crit = 15;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 14;
			Item.useAnimation = 14;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 8;
			Item.value = Item.buyPrice(gold: 50);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<CobaltDrakeProjectile>();
			Item.shootSpeed = 15f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient<DranSword>(1);
			recipe.AddIngredient<HellScythe>(1);
			recipe.AddIngredient<WizardArrow>(1);
			recipe.AddIngredient<KnightShield>(1);
			recipe.AddIngredient<BeyGetCore>(1);
			recipe.AddTile(TileID.Hellforge);
			recipe.Register();

			
		}
	}
}