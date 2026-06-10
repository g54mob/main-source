using System;
using NSEipix.Base;
using NSMedieval.Enums;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[Serializable]
	public class PenMarkerComponentBlueprint : NSEipix.Base.Model
	{
		private readonly BuildingType componentType = BuildingType.PenMarker;

		[SerializeField]
		private string id;

		public BuildingType ComponentType => componentType;

		public override string GetID()
		{
			return id;
		}
	}
}
