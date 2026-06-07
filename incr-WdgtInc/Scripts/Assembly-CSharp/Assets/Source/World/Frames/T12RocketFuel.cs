using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;
using UnityEngine;

namespace Assets.Source.World.Frames
{
	public class T12RocketFuel : CraftingFrame
	{
		private int _addedInventorySpace;

		public override int AutoWorkerMax => 6;

		public override int HandCraftButtonCount => 1;

		public override TechNode RequiredTech => "t12f_rocket_fuel";

		public T12RocketFuel()
		{
			base.ItemHint = "rocket_fuel";
			base.MusicName = "EvolvingCities";
			base.CheaperFirstWorker = false;
			_reagents["oil"] = 2;
			_reagents["fuel_rod"] = 1;
			_reagents["power"] = 20;
			_results["rocket_fuel"] = 1;
			_baseCraftingTime = 3f;
			_autoCraftingTime = 8f;
			_firstCost = new List<ItemType> { "portable_reactor", "omega_widget" };
			_baseCost = new List<ItemType> { "portable_reactor", "omega_widget" };
			_extraCostMultiplier = 0.800000011920929;
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
				_addedInventorySpace = Mathf.RoundToInt(100f * Mathf.Sqrt(GamePlayer.Current.PrestigeMultiplier));
				GamePlayer.Current.AddItemStorage(ItemType.RocketFuel, _addedInventorySpace);
			}
		}

		private void _removeAddedStorage()
		{
			GamePlayer.Current.AddItemStorage(ItemType.RocketFuel, -_addedInventorySpace);
			_addedInventorySpace = 0;
		}

		public override ManualCrafter CreateHandCrafter(WorldAnchor slot)
		{
			return new ManualMultiCrafter(this, slot, 10);
		}
	}
}
