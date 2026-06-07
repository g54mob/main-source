using System;
using System.Collections.Generic;
using System.Numerics;
using Assets.Source.Item;
using Assets.Source.Player;
using UnityEngine;

namespace Assets.Source.World.Frames
{
	public class T1GlitchedFrame : CraftingFrame
	{
		public const float ReagentsChangeTime = 20f;

		private static Dictionary<ItemType, BigInteger> _randomizedReagents = new Dictionary<ItemType, BigInteger>();

		private static float _reagentsTimer;

		private int _addedInventorySpace;

		public override int AutoWorkerMax => 6;

		public override string Description => "@t1f_glitched_frame_desc2";

		public override TechNode RequiredTech => "t1f_glitched_frame";

		public T1GlitchedFrame()
		{
			base.IconName = "Items_7";
			_results["glitched_widget"] = 1;
			base.MusicName = "SlightlyAcross";
			_baseCost = new List<ItemType> { "capacitor_widget" };
			_extraCostMultiplier = 8.0;
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
				_addedInventorySpace = 100;
				GamePlayer.Current.AddItemStorage(ItemType.GlitchedWidget, _addedInventorySpace);
			}
		}

		private void _removeAddedStorage()
		{
			GamePlayer.Current.AddItemStorage(ItemType.GlitchedWidget, -_addedInventorySpace);
			_addedInventorySpace = 0;
		}

		public override IEnumerable<KeyValuePair<ItemType, BigInteger>> GetReagents()
		{
			if (_randomizedReagents.Count == 0)
			{
				UpdateReagents(force: true);
			}
			return _randomizedReagents;
		}

		public override IList<ItemType> GetFirstCost()
		{
			return GetDynamicCostFrame().GetFirstCost();
		}

		public override IList<ItemType> GetBaseCost()
		{
			return GetDynamicCostFrame().GetBaseCost();
		}

		public override IEnumerable<KeyValuePair<ItemType, BigInteger>> GetPurchaseCost(int? nthFrame = null, bool includeUnderConstruction = true)
		{
			_calcFirstCost = null;
			_calcBaseCost = null;
			return base.GetPurchaseCost(nthFrame, includeUnderConstruction);
		}

		public override double GetCostMultiplier(int frameCount)
		{
			if (frameCount == 0)
			{
				return base.GetCostMultiplier(frameCount);
			}
			return base.GetCostMultiplier(1) * Math.Pow(1.75, frameCount);
		}

		public static CraftingFrame GetDynamicCostFrame(int tier = -1)
		{
			if (tier < 1)
			{
				tier = GamePlayer.Current.TechTier;
			}
			return tier switch
			{
				3 => new T2SpinningWidget(), 
				4 => new T3CapacitorWidget(), 
				5 => new T4ComputationalWidget(), 
				6 => new T5IntegratedWidget(), 
				7 => new T6MainframeWidget(), 
				8 => new T7CloudWidget(), 
				9 => new T8QuantumWidget(), 
				10 => new T9UnshackledWidget(), 
				11 => new T10AscendedWidget(), 
				12 => new T11SentientWidget(), 
				13 => new T11SentientWidget(), 
				_ => new T1BasicWidget(), 
			};
		}

		public static void UpdateReagents(bool force = false)
		{
			_reagentsTimer -= Time.deltaTime;
			if (!force && !(_reagentsTimer <= 0f))
			{
				return;
			}
			_randomizedReagents.Clear();
			foreach (KeyValuePair<ItemType, BigInteger> result in GetDynamicCostFrame().GetResults())
			{
				_randomizedReagents[result.Key] = 1;
			}
			List<ItemType> list = new List<ItemType>(GamePlayer.Current.GetInventoryItems());
			ItemType itemType = "iron_ingot";
			if (list.Count > 0)
			{
				int num = 0;
				do
				{
					num++;
					itemType = SeededRandom.Global.Choose(list);
				}
				while (num < 10 && (itemType.Tier >= GamePlayer.Current.TechTier || itemType.Identifier.EndsWith("widget")));
			}
			_randomizedReagents[itemType] = 2;
			_reagentsTimer = 20f;
		}

		public static void ClearReagents()
		{
			_randomizedReagents.Clear();
			_reagentsTimer = 0f;
		}
	}
}
