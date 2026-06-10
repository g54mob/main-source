using System;
using System.Collections.Generic;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class ResourceGroups : NSEipix.Base.Model
	{
		[SerializeField]
		private string groupId;

		[SerializeField]
		private List<string> subGroupIDs;

		[SerializeField]
		private int depth;

		public List<string> SubGroupIDs => subGroupIDs;

		public int Depth => depth;

		public override string GetID()
		{
			return groupId;
		}
	}
}
