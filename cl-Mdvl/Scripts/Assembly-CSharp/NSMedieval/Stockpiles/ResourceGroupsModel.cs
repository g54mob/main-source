using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Model;
using UnityEngine;

namespace NSMedieval.Stockpiles
{
	[Serializable]
	public class ResourceGroupsModel : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private List<ResourceGroups> resourceGroups;

		public List<ResourceGroups> ResourceGroups => resourceGroups;

		public override string GetID()
		{
			return id;
		}
	}
}
