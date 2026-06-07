using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T8PortableReactor : CraftingFrame
	{
		public override int AutoWorkerMax => 6;

		public override int HandCraftButtonCount => 1;

		public override float TimePerClick => 0.25f;

		public override TechNode RequiredTech => "t8f_portable_reactor";

		public T8PortableReactor()
		{
			base.ItemHint = "portable_reactor";
			base.PlacementTech = "t8u_portable_reactor_placement";
			base.MusicName = "FastLanesLightRain";
			_reagents["fuel_rod"] = 1;
			_reagents["battery"] = 1;
			_results["portable_reactor"] = 1;
			_baseCraftingTime = 1f;
			_firstCost = new List<ItemType> { "fuel_rod", "cloud_widget" };
			_baseCost = new List<ItemType> { "fuel_rod", "quantum_widget" };
			_extraCostMultiplier = 1.2999999523162842;
		}

		protected override double CalculatePlacementBonus(WorldFrame triggeredBy)
		{
			foreach (WorldFrame adjacentFrame in GetAdjacentFrames())
			{
				if (adjacentFrame is T7Power)
				{
					return base.PlacementTech.UpgradeMultiplier;
				}
			}
			return 1.0;
		}
	}
}
