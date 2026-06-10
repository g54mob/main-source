using System;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.Model.MapNew
{
	[Serializable]
	public class Slope : NSEipix.Base.Model
	{
		[SerializeField]
		private string id = string.Empty;

		[SerializeField]
		private int length;

		public int Length => length;

		public override string GetID()
		{
			return id;
		}
	}
}
