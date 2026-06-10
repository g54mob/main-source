using System;
using NSEipix.Base;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class WeaponQualitySettings : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private WeaponType weaponType;

		[SerializeField]
		private WeaponQuality[] qualitySettings;

		public WeaponType Type => weaponType;

		public WeaponQuality[] QualitySettings => qualitySettings;

		public override string GetID()
		{
			if (string.IsNullOrEmpty(id))
			{
				id = weaponType.ToString();
			}
			return id;
		}
	}
}
