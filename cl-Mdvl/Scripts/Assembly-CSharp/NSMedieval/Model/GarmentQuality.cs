using System;
using NSEipix.Model;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class GarmentQuality : ItemQuality
	{
		[SerializeField]
		private FloatRange warmthModifierMultiplier;

		public FloatRange WarmthModifierMultiplier => warmthModifierMultiplier;
	}
}
