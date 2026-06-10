using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Enums;
using NSMedieval.Model;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[Serializable]
	public class BedComponentBlueprint : NSEipix.Base.Model
	{
		private readonly BuildingType componentType = BuildingType.Bed;

		[SerializeField]
		private string id;

		[SerializeField]
		private List<string> workerEffectors;

		[SerializeField]
		private BedType bedType;

		[SerializeField]
		private TransformSettings sleepPosition;

		public BedType BedType => bedType;

		public BuildingType ComponentType => componentType;

		public List<string> WorkerEffectors => workerEffectors;

		public TransformSettings SleepPosition => sleepPosition;

		public override string GetID()
		{
			return id;
		}
	}
}
