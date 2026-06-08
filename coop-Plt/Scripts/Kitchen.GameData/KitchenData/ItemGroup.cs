using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace KitchenData
{
	[CreateAssetMenu(fileName = "ItemGroup", menuName = "Kitchen/Item Group", order = 4)]
	public class ItemGroup : Item
	{
		[Serializable]
		public struct ItemSet
		{
			public List<Item> Items;

			public int Min;

			public int Max;

			public bool IsMandatory;

			public bool RequiresUnlock;

			public bool OrderingOnly;
		}

		[Serializable]
		public struct ItemReward
		{
			public Item Item;

			public int RewardAmount;
		}

		[SerializeField]
		private List<ItemSet> Sets;

		[NonSerialized]
		public List<ItemSet> DerivedSets;

		public bool CanContainSide;

		public bool ApplyProcessesToComponents;

		public bool AllowLooseComponentSplitting;

		public bool AutoCollapsing;

		public List<ItemReward> Rewards = new List<ItemReward>();

		protected override void InitialiseDefaults()
		{
			base.InitialiseDefaults();
			DerivedSets = new List<ItemSet>();
		}

		public override void SetupForGame()
		{
			base.SetupForGame();
			if (Sets == null)
			{
				Sets = new List<ItemSet>();
			}
			DerivedSets = new List<ItemSet>(Sets);
		}

		private void PopulateRewards()
		{
			foreach (ItemSet derivedSet in DerivedSets)
			{
				foreach (Item item in derivedSet.Items)
				{
					if (!Rewards.Any((ItemReward r) => r.Item == item))
					{
						Rewards.Add(new ItemReward
						{
							Item = item
						});
					}
				}
			}
		}
	}
}
