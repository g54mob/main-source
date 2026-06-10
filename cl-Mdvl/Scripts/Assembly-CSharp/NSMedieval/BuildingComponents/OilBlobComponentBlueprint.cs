using System;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[Serializable]
	public class OilBlobComponentBlueprint : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private OilBlobType oilBlobType;

		public OilBlobType OilBlobType => oilBlobType;

		public override string GetID()
		{
			return id;
		}
	}
}
