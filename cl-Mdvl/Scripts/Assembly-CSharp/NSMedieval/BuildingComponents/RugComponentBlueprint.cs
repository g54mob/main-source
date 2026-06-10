using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Enums;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[Serializable]
	public class RugComponentBlueprint : NSEipix.Base.Model
	{
		private readonly BuildingType componentType = BuildingType.Rug;

		[SerializeField]
		private string id;

		[SerializeField]
		private List<string> workerEffectors;

		public BuildingType ComponentType => componentType;

		public List<string> WorkerEffectors => workerEffectors;

		public override string GetID()
		{
			return id;
		}

		public void SetInfo(ProductQuality quality, List<string> workerEffectors)
		{
			id = quality.ToString().ToLower() + "_" + GetID();
			this.workerEffectors = workerEffectors;
		}

		public RugComponentBlueprint GetQualityClone(ProductQuality quality, List<string> workerEffectors)
		{
			RugComponentBlueprint obj = (RugComponentBlueprint)MemberwiseClone();
			obj.SetInfo(quality, workerEffectors);
			return obj;
		}
	}
}
