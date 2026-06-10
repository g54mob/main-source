using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Enums;
using NSMedieval.Model;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[Serializable]
	public class ChairComponentBlueprint : NSEipix.Base.Model
	{
		private readonly BuildingType componentType = BuildingType.Chair;

		[SerializeField]
		private string id;

		[SerializeField]
		private List<string> workerEffectors;

		[SerializeField]
		private TransformSettings sittingPosition;

		public BuildingType ComponentType => componentType;

		public List<string> WorkerEffectors => workerEffectors;

		public TransformSettings SittingPosition => sittingPosition;

		public override string GetID()
		{
			return id;
		}
	}
}
