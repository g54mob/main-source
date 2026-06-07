using System;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.DronePerks.Effects
{
	[Serializable]
	public class ThrusterEffect : DroneEffect
	{
		public int ThrustIncrease;

		public override EEffectType EffectType
		{
			get
			{
				return EEffectType.Thruster;
			}
		}

		public override string GetDescription()
		{
			string text = ((ThrustIncrease > 0) ? "+" : "-");
			return text + Mathf.Abs(ThrustIncrease) + "% " + base.GetDescription();
		}
	}
}
