using System.Collections.Generic;
using System.Numerics;
using Assets.Source.Item;
using Assets.Source.World;
using Assets.Source.World.Frames;
using UnityEngine;

namespace Assets.Source.Ability
{
	public class Mitosis : ActivatedAbility
	{
		public override double Entropy => 1.5;

		public override int BaseCost => 200;

		public override string IconName => "Items2_6";

		public override AbilityTargetType TargetType => AbilityTargetType.Frame;

		public override bool IsValidTarget(object target)
		{
			return target is CraftingFrame;
		}

		protected override bool ActivateAbility(object target)
		{
			if (target is T1GlitchedFrame)
			{
				_failReason = "@AbilityMitosisFail";
				return false;
			}
			if (target is WorldFrame worldFrame)
			{
				List<Vector2Int> list = new List<Vector2Int>();
				for (int i = -1; i <= 1; i++)
				{
					for (int j = -1; j <= 1; j++)
					{
						if (i != 0 || j != 0)
						{
							list.Add(new Vector2Int(worldFrame.Position.x + i, worldFrame.Position.y + j));
						}
					}
				}
				SeededRandom.Global.Shuffle(list);
				while (list.Count > 0)
				{
					Vector2Int vector2Int = list[0];
					list.RemoveAt(0);
					if (!WorldMap.Current.CanBuildAtPosition(vector2Int, worldFrame))
					{
						continue;
					}
					Dictionary<ItemType, BigInteger> dictionary = new Dictionary<ItemType, BigInteger>();
					WorldFrame worldFrame2 = WorldFrame.Create(worldFrame.Identifier);
					worldFrame2.StartConstruction(dictionary);
					worldFrame2.CopyFrom(worldFrame);
					WorldMap.Current.AddFrame(worldFrame2, vector2Int);
					for (int k = 0; k < worldFrame.AutoWorkerCount; k++)
					{
						AutoWorker autoWorker = worldFrame.GetAutoWorker(k);
						if (autoWorker != null && autoWorker.Construction == null)
						{
							worldFrame2.PurchaseAutoWorker(new WorldAnchor(WorldAnchorType.AutoWorker, k), dictionary);
						}
					}
					foreach (FrameUpgrade availableUpgrade in worldFrame.GetAvailableUpgrades())
					{
						if (worldFrame.HasUpgrade(availableUpgrade))
						{
							worldFrame2.AddUpgrade(availableUpgrade);
						}
					}
					WorldOverview.Instance.AddCell(worldFrame2);
					return true;
				}
				_failReason = "@AbilityMitosisFail2";
			}
			return false;
		}
	}
}
