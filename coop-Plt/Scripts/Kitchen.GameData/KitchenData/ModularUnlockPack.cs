using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace KitchenData
{
	[CreateAssetMenu(fileName = "ModularUnlockPack", menuName = "Kitchen/Unlock/Unlock Pack/Modular", order = 3)]
	public class ModularUnlockPack : UnlockPack
	{
		public List<IUnlockSet> Sets = new List<IUnlockSet>();

		public List<IUnlockFilter> Filter = new List<IUnlockFilter>();

		public List<IUnlockSorter> Sorters = new List<IUnlockSorter>();

		public List<ConditionalOptions> ConditionalOptions = new List<ConditionalOptions>();

		public override UnlockOptions GetOptions(HashSet<int> current_cards, UnlockRequest request)
		{
			List<Unlock> cardSet = GetCardSet(request);
			cardSet = cardSet.Where((Unlock c) => !ShouldBlockCard(c, current_cards, request)).ToList();
			SortCards(ref cardSet, current_cards, request);
			return GetOptions(cardSet, current_cards, request);
		}

		protected virtual List<Unlock> GetCardSet(UnlockRequest request)
		{
			List<Unlock> list = new List<Unlock>();
			foreach (IUnlockSet set in Sets)
			{
				list.AddRange(set.GetCardSet(request));
			}
			return list.OrderBy((Unlock u) => u.ID).ToList();
		}

		protected virtual bool ShouldBlockCard(Unlock candidate, HashSet<int> current_cards, UnlockRequest request)
		{
			foreach (IUnlockFilter item in Filter)
			{
				if (item.ShouldBlockCard(candidate, current_cards, request))
				{
					return true;
				}
			}
			return false;
		}

		protected virtual void SortCards(ref List<Unlock> candidates, HashSet<int> current_cards, UnlockRequest request)
		{
			foreach (IUnlockSorter sorter in Sorters)
			{
				sorter.SortCards(ref candidates, current_cards, request);
			}
		}

		protected virtual UnlockOptions GetOptions(List<Unlock> candidates, HashSet<int> current_cards, UnlockRequest request)
		{
			foreach (ConditionalOptions conditionalOption in ConditionalOptions)
			{
				if (conditionalOption.Condition != null && conditionalOption.Condition.ShouldProvide(candidates, current_cards, request))
				{
					UnlockOptions options = conditionalOption.Selector.GetOptions(candidates, current_cards, request);
					if (options.Unlock1 != null)
					{
						return options;
					}
				}
			}
			return default(UnlockOptions);
		}
	}
}
