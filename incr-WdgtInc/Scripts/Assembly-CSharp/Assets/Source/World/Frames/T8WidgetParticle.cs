using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T8WidgetParticle : CraftingFrame
	{
		private int _addedInventorySpace;

		public override int AutoWorkerMax => 6;

		public override int HandCraftButtonCount => 1;

		public override float TimePerClick => 0.2f;

		public override TechNode RequiredTech => "t8f_widget_particle";

		public T8WidgetParticle()
		{
			base.ItemHint = "widget_particle";
			base.PlacementTech = "t8u_widget_particle_placement";
			base.MusicName = "DancingOperators";
			_reagents["widget"] = 1;
			_reagents["power"] = 1;
			_results["widget_particle"] = 5;
			_baseCraftingTime = 0.2f;
			_autoCraftingTime = 1f;
			_firstCost = new List<ItemType> { "fuel_rod", "cloud_widget" };
			_baseCost = new List<ItemType> { "fuel_rod", "quantum_widget" };
			_extraCostMultiplier = 1.2999999523162842;
		}

		public override void OnAddFrame()
		{
			_refreshStorage();
		}

		public override void OnConstructionCompleted()
		{
			_refreshStorage();
		}

		private void _refreshStorage()
		{
			if (_addedInventorySpace > 0)
			{
				_removeAddedStorage();
			}
			if (base.Construction == null)
			{
				_addedInventorySpace = 500;
				GamePlayer.Current.AddItemStorage(ItemType.WidgetParticle, _addedInventorySpace);
			}
		}

		private void _removeAddedStorage()
		{
			GamePlayer.Current.AddItemStorage(ItemType.WidgetParticle, -_addedInventorySpace);
			_addedInventorySpace = 0;
		}

		protected override double CalculatePlacementBonus(WorldFrame triggeredBy)
		{
			double num = 1.0;
			foreach (WorldFrame adjacentFrame in GetAdjacentFrames())
			{
				if (adjacentFrame is T1BasicWidget)
				{
					num += base.PlacementTech.UpgradeMultiplier;
				}
			}
			return num;
		}
	}
}
