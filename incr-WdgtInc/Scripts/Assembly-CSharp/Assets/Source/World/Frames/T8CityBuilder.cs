using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;
using UnityEngine;

namespace Assets.Source.World.Frames
{
	public class T8CityBuilder : CraftingFrame
	{
		private float _delayTimer;

		public override int AutoWorkerMax => 1;

		public override int HandCraftButtonCount => 1;

		public override double AutoworkerCostMultiplier => 3.0;

		public override TechNode RequiredTech => "t8f_city_builder";

		public T8CityBuilder()
		{
			base.IconName = "Items2_1";
			base.MusicName = "YouWereAlwaysInTheRightPlace";
			List<ItemType> obj = new List<ItemType> { "quantum_widget" };
			List<ItemType> firstCost = obj;
			_baseCost = obj;
			_firstCost = firstCost;
			_reagents["power"] = 10;
			_reagents["iron_ingot"] = 5;
			_reagents["microprocessor"] = 2;
			_results["city_block"] = 1;
			_baseCraftingTime = 6f;
			_autoCraftingTime = 6f;
			_extraCostMultiplier = 0.6000000238418579;
		}

		public override void OnConstructionCompleted()
		{
			WorldAnchor worldAnchor = new WorldAnchor(WorldAnchorType.AutoWorker, 0);
			AutoWorker autoWorker = CreateAutoWorker(worldAnchor);
			_workers[worldAnchor.Slot] = autoWorker;
			ActiveCell?.UpdateWarningIcon();
		}

		public override void ActiveUpdate(float delta)
		{
			base.ActiveUpdate(delta);
			if (_delayTimer > 0f)
			{
				_delayTimer -= Time.deltaTime;
				return;
			}
			GamePlayer.Current.UpdateCityParts();
			_delayTimer = 1f;
		}

		public override double GetParallelMultiplier(bool handCraft)
		{
			return base.GetParallelMultiplier(handCraft: false);
		}
	}
}
