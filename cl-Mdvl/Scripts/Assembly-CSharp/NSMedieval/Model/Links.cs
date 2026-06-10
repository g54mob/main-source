using System;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class Links : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private string[] linkKeys;

		public string[] LinkKeys => linkKeys;

		public override string GetID()
		{
			return id;
		}
	}
}
