using System;
using NSEipix.Base;
using NSMedieval.Model;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.PlayerTriggeredEventSystem
{
	[Serializable]
	public class ResourceSetting : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private LocKeys[] locKeys;

		[SerializeField]
		private ResourceCategory resourceCategory;

		[SerializeField]
		private string[] allowedSortingGroups;

		[SerializeField]
		private string[] allowedResources;

		public ResourceCategory ResourceCategory => resourceCategory;

		public string[] AllowedSortingGroups => allowedSortingGroups;

		public string[] AllowedResources => allowedResources;

		public LocKeys[] LocKeys => locKeys;

		public override string GetID()
		{
			return id;
		}
	}
}
