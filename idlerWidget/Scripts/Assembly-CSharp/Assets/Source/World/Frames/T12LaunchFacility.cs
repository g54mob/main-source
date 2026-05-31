using System;
using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;
using LightJson;
using UnityEngine;

namespace Assets.Source.World.Frames
{
	public class T12LaunchFacility : CraftingFrame
	{
		private float _inactivityTimer;

		public static int PartsPerRocket => Mathf.RoundToInt(10000f * Mathf.Pow(1.1f, GamePlayer.Current.RocketsLaunched + GamePlayer.Current.Prestige));

		public override int AutoWorkerCount => 0;

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
			_extraCostMultiplier = 8f;
		}

		public override void OnConstructionCompleted()
		{
			SteamAchievement.Trigger("LaunchFacilityConstructed");
			if (GamePlayer.Current.SessionStats.PlayTime != 0)
			{
				GamePlayer.Current.AddRocketSiloBenchmark();
			}
		}

		public override void ActiveUpdate(float delta)
		{
			if (_inactivityTimer > 0f)
			{
				_inactivityTimer -= delta;
				return;
			}
			base.MusicIsImportant = GamePlayer.Current.RocketParts >= PartsPerRocket;
			int num = CheckAndPayCost(new WorldAnchor(WorldAnchorType.HandCraft, 0), GetReagents(), 999, addToStats: true);
			if (num > 0)
			{
				GamePlayer.Current.AddInventoryItem(GamePlayer.RocketPartItem, num, addToStats: true);
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
				GamePlayer.Current.AddInventoryItem(GamePlayer.RocketPartItem, val["CollectedParts"], addToStats: false);
			}
		}
	}
}
