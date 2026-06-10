using System;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[Serializable]
	public class BellComponentBlueprint : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		public override string GetID()
		{
			return id;
		}
	}
}
