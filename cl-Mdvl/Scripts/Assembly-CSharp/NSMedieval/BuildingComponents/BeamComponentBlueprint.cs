using System;
using NSEipix.Base;
using NSMedieval.Enums;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[Serializable]
	public class BeamComponentBlueprint : NSEipix.Base.Model
	{
		private readonly BuildingType componentType = BuildingType.Beam;

		[SerializeField]
		private string id;

		[SerializeField]
		private int maxLength;

		public BuildingType ComponentType => componentType;

		public int MaxLength => maxLength;

		public override string GetID()
		{
			return id;
		}
	}
}
