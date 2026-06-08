using System.Collections.Generic;
using UnityEngine;

namespace KitchenData
{
	[CreateAssetMenu(fileName = "Unlock Card", menuName = "Kitchen/Unlock/Card", order = 0)]
	public class UnlockCard : Unlock
	{
		public List<UnlockEffect> Effects = new List<UnlockEffect>();
	}
}
