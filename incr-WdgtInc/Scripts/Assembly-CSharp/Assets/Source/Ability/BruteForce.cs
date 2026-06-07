using System.Collections.Generic;
using System.Numerics;
using Assets.Source.Item;
using Assets.Source.Player;
using Assets.Source.World;

namespace Assets.Source.Ability
{
	public class BruteForce : ActivatedAbility
	{
		public override double Entropy => 1.1;

		public override int BaseCost => 4;

		public override string IconName => "Items2_4";

		public override AbilityTargetType TargetType => AbilityTargetType.Frame;

		public override bool IsValidTarget(object target)
		{
			return target is CraftingFrame;
		}

		protected override bool ActivateAbility(object target)
		{
			if (target is CraftingFrame craftingFrame)
			{
				foreach (KeyValuePair<ItemType, BigInteger> result in craftingFrame.GetResults())
				{
					GamePlayer.Current.AddInventoryItem(result.Key, result.Value, addToStats: true, handCraft: true);
					ShowItemCrafted(_abilitySource, result.Key, result.Value);
				}
				return true;
			}
			return false;
		}
	}
}
