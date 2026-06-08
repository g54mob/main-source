using System.Collections.Generic;
using UnityEngine;

namespace KitchenData
{
	[CreateAssetMenu(fileName = "CompositeUnlockPack", menuName = "Kitchen/Unlock/Unlock Pack/Composite", order = 3)]
	public class CompositeUnlockPack : UnlockPack
	{
		public List<UnlockPack> Packs = new List<UnlockPack>();

		public override UnlockOptions GetOptions(HashSet<int> current_cards, UnlockRequest request)
		{
			foreach (UnlockPack pack in Packs)
			{
				UnlockOptions options = pack.GetOptions(current_cards, request);
				if (options.Unlock1 != null)
				{
					return options;
				}
			}
			return default(UnlockOptions);
		}
	}
}
