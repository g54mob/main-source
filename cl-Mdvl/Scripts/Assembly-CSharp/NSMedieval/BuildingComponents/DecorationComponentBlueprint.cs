using System;
using NSEipix.Base;
using NSMedieval.Enums;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[Serializable]
	public class DecorationComponentBlueprint : NSEipix.Base.Model
	{
		private readonly BuildingType componentType = BuildingType.Decoration;

		[SerializeField]
		private string id;

		[SerializeField]
		private bool generateQualityVersions;

		public BuildingType ComponentType => componentType;

		public bool GenerateQualityVersions => generateQualityVersions;

		public override string GetID()
		{
			return id;
		}

		public void SetInfo(ProductQuality quality)
		{
			id = quality.ToString().ToLower() + "_" + GetID();
		}

		public DecorationComponentBlueprint GetQualityClone(ProductQuality quality)
		{
			DecorationComponentBlueprint obj = (DecorationComponentBlueprint)MemberwiseClone();
			obj.SetInfo(quality);
			return obj;
		}
	}
}
