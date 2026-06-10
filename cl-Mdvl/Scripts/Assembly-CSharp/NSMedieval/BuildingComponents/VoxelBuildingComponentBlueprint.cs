using System;
using NSEipix.Base;
using NSMedieval.Enums;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[Serializable]
	public class VoxelBuildingComponentBlueprint : NSEipix.Base.Model
	{
		private readonly BuildingType componentType = BuildingType.Wall;

		[SerializeField]
		private string id;

		[SerializeField]
		private string voxelTypeID;

		public string VoxelTypeID => voxelTypeID;

		public BuildingType ComponentType => componentType;

		public override string GetID()
		{
			return id;
		}
	}
}
