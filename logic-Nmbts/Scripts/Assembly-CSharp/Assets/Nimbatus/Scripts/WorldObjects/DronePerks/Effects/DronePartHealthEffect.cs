using System;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.DronePerks.Effects
{
	[Serializable]
	public class DronePartHealthEffect : DroneEffect
	{
		public int HealthIncrease;

		public override EEffectType EffectType
		{
			get
			{
				return EEffectType.DronePartHealth;
			}
		}

		public override string GetDescription()
		{
			string text = ((HealthIncrease > 0) ? "+" : "-");
			return text + Mathf.Abs(HealthIncrease) + "% " + base.GetDescription();
		}
	}
}
