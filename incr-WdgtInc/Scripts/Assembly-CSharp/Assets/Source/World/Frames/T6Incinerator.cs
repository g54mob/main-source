using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;
using UnityEngine;

namespace Assets.Source.World.Frames
{
	public class T6Incinerator : CraftingFrame
	{
		public class T6IncineratorAutoCrafter : AutoCrafter
		{
			public T6IncineratorAutoCrafter(T6Incinerator parent, WorldAnchor slot)
				: base(parent, slot)
			{
			}

			public override bool InitStartCrafting()
			{
				if (!base.Parent.CanStartCrafting(Slot))
				{
					return false;
				}
				base.CraftCount = base.Parent.ConsumeReagentsForCraft(Slot);
				if (base.CraftCount == 0)
				{
					return false;
				}
				return true;
			}

			protected override bool DoCraftingResult()
			{
				ExecuteCraftingResult(base.Parent.GetResults());
				return true;
			}
		}

		public override int AutoWorkerMax => 6;

		public override int HandCraftButtonCount => 0;

		public override TechNode RequiredTech => "t6f_incinerator";

		public T6Incinerator()
		{
			base.IconName = "Items2_10";
			base.MusicName = "FastLanesLightRain";
			_reagents["human_remains"] = 1;
			_results["power"] = 1;
			_baseCost = new List<ItemType> { "ai_core", "unshackled_widget" };
			_extraCostMultiplier = 1.2999999523162842;
			_autoCraftingTime = 4f;
		}

		public override void OnConstructionCompleted()
		{
			GamePlayer.Current.AddTech("t6f_incinerator_flag");
		}

		public override bool IsValidPlacement(WorldMap map, Vector2Int pos)
		{
			bool flag = GamePlayer.Current.HasTech(TechNode.IndenturedServitude3);
			byte terrain = map.GetTerrain(pos);
			if (terrain == 8 || (flag && terrain == 9))
			{
				return false;
			}
			for (int i = -1; i <= 1; i++)
			{
				for (int j = -1; j <= 1; j++)
				{
					if (i != 0 || j != 0)
					{
						Vector2Int pos2 = new Vector2Int(pos.x + i, pos.y + j);
						terrain = map.GetTerrain(pos2);
						if (terrain == 8 || (flag && terrain == 9))
						{
							return true;
						}
						if (map.GetFrame(pos2) is T6Incinerator)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		public override AutoWorker CreateAutoWorker(WorldAnchor slot)
		{
			return new T6IncineratorAutoCrafter(this, slot);
		}
	}
}
