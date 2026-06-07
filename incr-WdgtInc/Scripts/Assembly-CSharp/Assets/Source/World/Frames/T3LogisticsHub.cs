using System.Collections.Generic;
using System.Numerics;
using Assets.Behaviour.Util;
using Assets.Source.Item;
using Assets.Source.Player;
using UnityEngine;

namespace Assets.Source.World.Frames
{
	public class T3LogisticsHub : CraftingFrame
	{
		private double _powerDraw;

		public override int AutoWorkerMax => 1;

		public override TechNode RequiredTech => "t3f_logistics_hub";

		public override int Tier => 3;

		public double DisplayedPowerDraw => _powerDraw * GetParallelMultiplier(handCraft: false);

		public T3LogisticsHub()
		{
			base.IconName = "Items2_11";
			base.MusicName = "SlightlyAcross";
			_baseCost = new List<ItemType> { "widget", "spinning_widget", "capacitor_widget" };
			_autoCraftingTime = 1f;
			_extraCostMultiplier = 1.7999999523162842;
		}

		public override IEnumerable<KeyValuePair<ItemType, BigInteger>> GetReagents()
		{
			if (_powerDraw != 0.0)
			{
				float chanceOfTrue = (float)(_powerDraw % 1.0);
				yield return KeyValuePair.Create(ItemType.Power, new BigInteger((int)_powerDraw + (SeededRandom.Global.RandomBool(chanceOfTrue) ? 1 : 0)));
			}
		}

		public override void OnConstructionCompleted()
		{
			PurchaseAutoWorker(new WorldAnchor(WorldAnchorType.AutoWorker, 0));
			int num = 0;
			foreach (T3LogisticsHub frame in WorldMap.Current.GetFrames<T3LogisticsHub>())
			{
				if (frame.Construction == null)
				{
					num++;
				}
			}
			SteamStatsManager.Set(SteamStatType.LogisticsHubs, num);
		}

		public override IEnumerable<KeyValuePair<ItemType, BigInteger>> GetAutoWorkerCost(int? nthWorker = null)
		{
			yield break;
		}

		public override void UpdatePlacementBonus(WorldFrame triggeredBy = null)
		{
			base.UpdatePlacementBonus();
			if (!(triggeredBy is T1Warehouse))
			{
				return;
			}
			foreach (WorldFrame adjacentFrame in GetAdjacentFrames())
			{
				if (!(adjacentFrame is T1Warehouse))
				{
					adjacentFrame.UpdatePlacementBonus(this);
				}
			}
		}

		public double GetLogisticsBonus(WorldFrame worldFrame)
		{
			double num = 1.0;
			double num2 = 0.0;
			int num3 = 0;
			foreach (WorldFrame adjacentFrame in GetAdjacentFrames())
			{
				if (!(adjacentFrame is T3LogisticsHub))
				{
					if (adjacentFrame is T1Warehouse && GamePlayer.Current.HasTech(TechNode.LogisticHub1))
					{
						num += 0.1;
						num3++;
					}
					else if (adjacentFrame is T12LaunchFacility)
					{
						num2 += 20.0;
					}
					else if (adjacentFrame.Tier == 12)
					{
						num2 += 10.0;
					}
					else if (adjacentFrame is CraftingFrame)
					{
						num2 += (double)Mathf.Max(1, (adjacentFrame.Tier - 1) / 2);
					}
				}
			}
			_powerDraw = num2 * (1.0 + (double)num3 * 0.2);
			if (GamePlayer.Current.HasTech(TechNode.LogisticHub2))
			{
				_powerDraw *= 2.0;
			}
			return num;
		}
	}
}
