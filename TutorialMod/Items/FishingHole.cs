using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TutorialMod.Items
{
	public class FishingHole : ModItem
	{
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.TutorialMod.hjson file.

		public override void SetDefaults()
		{

			Item.width = 40;
			Item.height = 40;
			Item.useAnimation = 20;
			Item.useTime = 20;
			Item.consumable = true;
			Item.maxStack = 99;
			Item.UseSound = SoundID.Item1;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.value = Item.buyPrice(0, 0, 30, 0);
			Item.rare = ItemRarityID.Blue;
			Item.noUseGraphic = true;
			Item.UseSound = SoundID.Item1;
			Item.createTile = ModContent.TileType<AutoHouseTile>();
		}

		public override void HoldItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.ownedProjectileCounts[ModContent.ProjectileType<InstaHouseVisual>()] < 1)
            {
                Vector2 mouse = Main.MouseWorld;
                Projectile.NewProjectile(player.GetSource_ItemUse(Item), mouse, Vector2.Zero, ModContent.ProjectileType<InstaHouseVisual>(), 0, 0, player.whoAmI);
            }
        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.StoneBlock, 20);
			recipe.AddIngredient(ItemID.Bass, 5);
			recipe.AddIngredient(ItemID.WaterBucket, 5);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}