using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T9Helium : CraftingFrame
	{
		public override int AutoWorkerCount => 6;

		public override int HandCraftButtonCount => 1;

		public override TechNode RequiredTech => "t9f_helium";

		public T9Helium()
		{
			base.ItemHint = "helium";
			base.PlacementTech = "t9u_helium_placement";
			base.MusicName = "EvolvingCities";
			_reagents["power"] = 8;
			_results["helium"] = 1;
			_baseCraftingTime = 0.5f;
			_firstCost = new List<ItemType> { "quantum_widget" };
			_baseCost = new List<ItemType> { "unshackled_widget" };
		}

		protected override float CalculatePlacementBonus()
		{
			if (base.Terrain != 6)
			{
				return 1f;
			}
			return base.PlacementTech.UpgradeMultiplier;
		}
	}
}
