using System;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.UI
{
	[Serializable]
	public class ActionInfoData : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private string[] actionInfos;

		public string[] ActionInfos => actionInfos;

		public override string GetID()
		{
			return id;
		}
	}
}
