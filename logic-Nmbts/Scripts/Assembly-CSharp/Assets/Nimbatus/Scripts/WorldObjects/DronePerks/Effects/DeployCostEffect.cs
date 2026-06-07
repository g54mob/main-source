using System;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.DronePerks.Effects
{
	[Serializable]
	public class DeployCostEffect : DroneEffect
	{
		public int DeployCostIncrease;

		public override EEffectType EffectType
		{
			get
			{
				return EEffectType.DeployCost;
			}
		}

		public override string GetDescription()
		{
			string text = ((DeployCostIncrease > 0) ? "+" : "-");
			return text + Mathf.Abs(DeployCostIncrease) + "% " + base.GetDescription();
		}
	}
}
