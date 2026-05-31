using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class T3CapacitorWidget : CraftingFrame
	{
		public const int MaxVoltage = 15;

		public override int AutoWorkerCount => 6;

		public override int HandCraftButtonCount => 1;

		public override TechNode RequiredTech => "t3f_capacitor_widget";

		public int InputVoltage { get; private set; }

		public int OutputVoltage { get; private set; }

		public T3CapacitorWidget()
		{
			base.ItemHint = "capacitor_widget";
			base.PlacementTech = "t3u_capacitor_widget_placement";
			base.MusicName = "TheLongestYear";
			base.CheaperFirstWorker = false;
			_reagents["spinning_widget"] = 1;
			_reagents["battery"] = 2;
			_results["capacitor_widget"] = 1;
			_baseCraftingTime = 5f;
			_firstCost = new List<ItemType> { "spinning_widget", "gyroscope" };
			_baseCost = new List<ItemType> { "capacitor_widget", "gyroscope" };
			_extraCostMultiplier = 1.4f;
		}

		public override void ActiveUpdate(float delta)
		{
			base.ActiveUpdate(delta);
			if (!_manualCrafters[0].Active && InputVoltage == 0)
			{
				InputVoltage = SeededRandom.Global.RandomRange(1, 16);
				OutputVoltage = 0;
			}
		}

		public override void ButtonClicked(WorldAnchor anchor)
		{
			base.ButtonClicked(anchor);
			if (anchor.AnchorType == WorldAnchorType.HandCraft)
			{
				InputVoltage = 0;
				OutputVoltage = 0;
			}
			else if (anchor.AnchorType == WorldAnchorType.Custom)
			{
				OutputVoltage ^= 1 << anchor.Slot;
			}
		}

		public override ManualCrafter CreateHandCrafter(WorldAnchor slot)
		{
			return new ManualMultiCrafter(this, slot, 5);
		}

		protected override float CalculatePlacementBonus()
		{
			int num = 0;
			foreach (WorldFrame adjacentFrame in GetAdjacentFrames())
			{
				if (adjacentFrame is T3CapacitorWidget)
				{
					return 1f;
				}
				if (adjacentFrame is T3Battery)
				{
					num++;
				}
			}
			if (num < 2)
			{
				return 1f;
			}
			return base.PlacementTech.UpgradeMultiplier;
		}
	}
}
