using System;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class ArmorQuality : ItemQuality
	{
		[SerializeField]
		private float armorRatingMultiplier;

		public float ArmorRatingMultiplier => armorRatingMultiplier;
	}
}
