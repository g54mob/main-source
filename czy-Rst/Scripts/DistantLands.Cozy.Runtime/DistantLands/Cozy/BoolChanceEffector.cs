using System;
using UnityEngine;

namespace DistantLands.Cozy
{
	[Serializable]
	[CreateAssetMenu(menuName = "Distant Lands/Cozy/WRC/Boolean Chance", order = 361)]
	public class BoolChanceEffector : CustomCozyChanceEffector
	{
		public bool toggle;

		public override float GetChance()
		{
			return toggle ? 1 : 0;
		}
	}
}
