using System;
using System.Collections.Generic;
using System.Numerics;
using Assets.Source.Item;
using Assets.Source.Player;
using LightJson;

namespace Assets.Source.World.Frames
{
	public class DemoTurtle : CraftingFrame
	{
		private float _inactivityTimer;

		public static int PartsPerTurtle => 10000;

		public override int AutoWorkerMax => 0;

		public override TechNode RequiredTech => "t4f_demo_turtle";

		public override int Tier => 4;

		public override bool IsUnlocked => false;

		public DemoTurtle()
		{
			base.IconName = "Items_7";
			base.MusicName = "SlightlyAcross";
			_reagents["widget"] = 1;
			_reagents["spinning_widget"] = 1;
			_reagents["capacitor_widget"] = 1;
			_reagents["iron_ingot"] = 2;
			_baseCost = new List<ItemType> { "capacitor_widget" };
			_extraCostMultiplier = 8.0;
		}

		public override void OnConstructionCompleted()
		{
		}

		public override void ActiveUpdate(float delta)
		{
			base.ActiveUpdate(delta);
			if (_inactivityTimer > 0f)
			{
				_inactivityTimer -= delta;
				return;
			}
			BigInteger bigInteger = PartsPerTurtle - GamePlayer.Current.DemoTurtleParts;
			base.MusicIsImportant = bigInteger <= 0L;
			if (bigInteger <= 0L)
			{
				_inactivityTimer = 2f;
				return;
			}
			int num = CheckAndPayCost(new WorldAnchor(WorldAnchorType.HandCraft, 0), GetReagents(), (int)bigInteger, addToStats: true);
			if (num > 0)
			{
				GamePlayer.Current.AddInventoryItem(GamePlayer.DemoTurtleItem, num, addToStats: true);
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
				GamePlayer.Current.AddInventoryItem(GamePlayer.DemoTurtleItem, val["CollectedParts"].AsInteger, addToStats: false);
			}
		}
	}
}
