using System;
using NSEipix.Base;
using NSMedieval.Enums;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[Serializable]
	public class WellComponentBlueprint : NSEipix.Base.Model
	{
		private readonly BuildingType componentType = BuildingType.Decoration;

		[SerializeField]
		private string id;

		[SerializeField]
		private float waterBucketProductionTime;

		public BuildingType ComponentType => componentType;

		public float WaterBucketProductionTime => waterBucketProductionTime;

		public override string GetID()
		{
			return id;
		}
	}
}
