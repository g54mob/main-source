using System;
using UnityEngine;

namespace DistantLands.Cozy
{
	[Serializable]
	[CreateAssetMenu(menuName = "Distant Lands/Cozy/WRC/Simple Chance", order = 361)]
	public class SimpleChanceEffector : CustomCozyChanceEffector
	{
		public float chance;

		public override float GetChance()
		{
			return chance;
		}
	}
}
