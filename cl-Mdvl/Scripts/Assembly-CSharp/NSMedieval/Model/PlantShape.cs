using System;
using System.Collections.Generic;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class PlantShape : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private List<Vec3Int> positions;

		public List<Vec3Int> Positions => positions;

		public override string GetID()
		{
			return id;
		}
	}
}
