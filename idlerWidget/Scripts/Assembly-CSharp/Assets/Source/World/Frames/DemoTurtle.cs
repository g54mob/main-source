using System;
using System.Collections.Generic;
using Assets.Behaviour.UI;
using Assets.Source.Item;
using Assets.Source.Player;
using Assets.Source.Util;
using LightJson;

namespace Assets.Source.World.Frames
{
	public class DemoTurtle : CraftingFrame
	{
		private float _inactivityTimer;

		public static int PartsPerTurtle => 10000;

		public override int AutoWorkerCount => 0;

		public override TechNode RequiredTech => "t4f_demo_turtle";

		public override int Tier => 4;

		public DemoTurtle()
		{
			base.IconName = "Items_7";
			base.MusicName = "SlightlyAcross";
			_reagents["widget"] = 1;
			_reagents["spinning_widget"] = 1;
			_reagents["capacitor_widget"] = 1;
			_reagents["iron_ingot"] = 2;
			_baseCost = new List<ItemType> { "capacitor_widget" };
			_extraCostMultiplier = 8f;
		}

		public override void OnConstructionCompleted()
		{
			UIStatusMessage.Show("Leaping Turtle Statue site built in " + GameMath.FormatTime(GamePlayer.Current.SessionStats.PlayTime), "Items_7", persistent: true);
		}

		public override void ActiveUpdate(float delta)
		{
			if (_inactivityTimer > 0f)
			{
				_inactivityTimer -= delta;
				return;
			}
			int num = PartsPerTurtle - GamePlayer.Current.DemoTurtleParts;
			base.MusicIsImportant = num <= 0;
			if (num <= 0)
			{
				_inactivityTimer = 2f;
				return;
			}
			int num2 = CheckAndPayCost(new WorldAnchor(WorldAnchorType.HandCraft, 0), GetReagents(), num, addToStats: true);
			if (num2 > 0)
			{
				GamePlayer.Current.AddInventoryItem(GamePlayer.DemoTurtleItem, num2, addToStats: true);
				_inactivityTimer = 0.5f;
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
