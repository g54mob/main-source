using System;
using NSEipix.Base;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class ArmorQualitySettings : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private ArmorType armorType;

		[SerializeField]
		private ArmorQuality[] qualitySettings;

		public ArmorType Type => armorType;

		public ArmorQuality[] QualitySettings => qualitySettings;

		public override string GetID()
		{
			if (string.IsNullOrEmpty(id))
			{
				id = armorType.ToString();
			}
			return id;
		}
	}
}
