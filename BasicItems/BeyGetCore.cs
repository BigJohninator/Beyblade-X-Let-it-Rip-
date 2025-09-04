using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace LetItRip.Content.Items.BasicItems
{ 
	// This is a basic item template.
	// Please see tModLoader's ExampleMod for every other example:
	// https://github.com/tModLoader/tModLoader/tree/stable/ExampleMod
	public class BeyGetCore : ModItem
	{




        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        }
		// The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.LetItRip.hjson' file.
        public override void SetDefaults()
        {
            
            Item.width = 40;
            Item.height = 40;
            Item.value = Item.buyPrice(gold: 40);
            Item.rare = ItemRarityID.Blue;
            Item.maxStack = 9999;
        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.HellstoneBar, 10);
            recipe.AddIngredient<EnhancedBeyCore>(1);
            recipe.AddIngredient(ItemID.Terragrim, 1);
			recipe.AddTile(TileID.Hellforge);
			recipe.Register();

			
		}
	}
}