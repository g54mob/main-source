using System;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.DronePerks.Effects
{
	[Serializable]
	public class ResourceCollectionEffect : DroneEffect
	{
		public int ResourceCollectionIncrease;

		public override EEffectType EffectType
		{
			get
			{
				return EEffectType.ResourceCollection;
			}
		}

		public override string GetDescription()
		{
			string text = ((ResourceCollectionIncrease > 0) ? "+" : "-");
			return text + Mathf.Abs(ResourceCollectionIncrease) + "% " + base.GetDescription();
		}
	}
}
