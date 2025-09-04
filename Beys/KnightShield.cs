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
	public class KnightShield : ModItem
	{
		// The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.LetItRip.hjson' file.
		public override void SetDefaults()
		{
			Item.damage = 8;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 15;
			Item.value = Item.buyPrice(silver: 50);
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<KnightShieldProjectile>();
			Item.shootSpeed = 3f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.IronBar, 10);
			recipe.AddIngredient(ItemID.IronChainmail, 1);
			recipe.AddIngredient<BeyCore>(1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
			
			Recipe recipe2 = CreateRecipe();
			recipe2.AddIngredient(ItemID.LeadBar, 10);
            recipe2.AddIngredient(ItemID.LeadChainmail, 1);
			recipe2.AddIngredient<BeyCore>(1);
			recipe2.AddTile(TileID.WorkBenches);
			recipe2.Register();
		}
	}
}