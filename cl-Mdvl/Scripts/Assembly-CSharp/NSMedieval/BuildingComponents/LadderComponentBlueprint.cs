using System;
using NSEipix.Base;
using NSMedieval.Enums;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[Serializable]
	public class LadderComponentBlueprint : NSEipix.Base.Model
	{
		private readonly BuildingType componentType = BuildingType.Ladder;

		[SerializeField]
		private string id;

		public BuildingType ComponentType => componentType;

		public override string GetID()
		{
			return id;
		}
	}
}
