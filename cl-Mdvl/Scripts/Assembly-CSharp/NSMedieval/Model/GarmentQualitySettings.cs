using System;
using NSEipix.Base;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class GarmentQualitySettings : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private GarmentType garmentType;

		[SerializeField]
		private GarmentQuality[] qualitySettings;

		public GarmentType Type => garmentType;

		public GarmentQuality[] QualitySettings => qualitySettings;

		public override string GetID()
		{
			if (string.IsNullOrEmpty(id))
			{
				id = garmentType.ToString();
			}
			return id;
		}
	}
}
