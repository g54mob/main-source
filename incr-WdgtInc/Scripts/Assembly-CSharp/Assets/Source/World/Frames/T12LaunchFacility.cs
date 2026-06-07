using System;
using System.Collections.Generic;
using System.Numerics;
using Assets.Source.Item;
using Assets.Source.Player;
using Assets.Source.Util;
using LightJson;
using UnityEngine;

namespace Assets.Source.World.Frames
{
	public class T12LaunchFacility : CraftingFrame
	{
		private float _inactivityTimer;

		public static BigInteger PartsPerRocket => GameMath.Multiply(10000, Mathf.Pow(1.1f, GamePlayer.Current.RocketsLaunched + GamePlayer.Current.Prestige));

		public override int AutoWorkerMax => 0;

		public override TechNode RequiredTech => "t12f_launch_facility";

		public T12LaunchFacility()
		{
			base.IconName = "Items_60";
			base.MusicName = "SlightlyAcross";
			_reagents["omega_widget"] = 1;
			_reagents["rocket_part"] = 1;
			_reagents["rocket_electronics"] = 1;
			_reagents["rocket_fuel"] = 10;
			_baseCost = new List<ItemType> { "omega_widget" };
			_extraCostMultiplier = 8.0;
		}

		public override void OnConstructionCompleted()
		{
			SteamAchievement.Trigger("LaunchFacility");
			GamePlayer.Current.AddRocketSiloBenchmark();
		}

		public override void ActiveUpdate(float delta)
		{
			base.ActiveUpdate(delta);
			if (_inactivityTimer > 0f)
			{
				_inactivityTimer -= delta;
				return;
			}
			base.MusicIsImportant = GamePlayer.Current.RocketParts >= PartsPerRocket;
			int num = CheckAndPayCost(new WorldAnchor(WorldAnchorType.HandCraft, 0), GetReagents(), 1000 * (1 + GamePlayer.Current.Prestige), addToStats: true);
			if (num > 0)
			{
				double num2 = (double)num * GetProductivityMultiplier(handCraft: false);
				double num3 = num2 % 1.0;
				num2 -= num3;
				if (SeededRandom.Global.RandomBool(num3))
				{
					num2 += 1.0;
				}
				int num4 = (int)num2;
				GamePlayer.Current.AddInventoryItem(GamePlayer.RocketPartItem, num4, addToStats: true);
				_inactivityTimer = 1f;
			}
			else
			{
				_inactivityTimer = 2f;
			}
		}

		public override AutoWorker CreateAutoWorker(WorldAnchor slot)
		{
			throw new NotImplementedException();
		}

		protected override void LoadFromJson(JsonValue val)
		{
			base.LoadFromJson(val);
			if (val["CollectedParts"].IsInteger)
			{
				GamePlayer.Current.AddInventoryItem(GamePlayer.RocketPartItem, val["CollectedParts"].AsInteger, addToStats: false);
			}
		}
	}
}
