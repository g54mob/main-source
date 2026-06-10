using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Enums;
using UnityEngine;

namespace NSMedieval.Model.MapNew
{
	[Serializable]
	public class MapPropType : NSEipix.Base.Model
	{
		[SerializeField]
		private string id = string.Empty;

		[SerializeField]
		private string model = string.Empty;

		[SerializeField]
		private List<int> phases;

		[SerializeField]
		private bool forbid = true;

		[SerializeField]
		private string resourceType = string.Empty;

		[NonSerialized]
		private MapPropResourceType resourceTypeCache;

		[NonSerialized]
		private bool resourceTypeCacheInitialized;

		public string Model => model;

		public List<int> Phases => phases;

		public bool Forbid => forbid;

		public MapPropResourceType ResourceType
		{
			get
			{
				if (!resourceTypeCacheInitialized)
				{
					if (!Enum.TryParse<MapPropResourceType>(resourceType, out resourceTypeCache))
					{
						resourceTypeCache = MapPropResourceType.None;
					}
					resourceTypeCacheInitialized = true;
				}
				return resourceTypeCache;
			}
		}

		public override string GetID()
		{
			return id;
		}
	}
}
