using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Components.Base;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Types;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using UnityEngine;

namespace NSMedieval.Resources
{
	[Serializable]
	public class ManageGroup : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private string groupName;

		[SerializeField]
		private StorageBase storage;

		[SerializeField]
		private EquipmentSlotType equipmentSlotType;

		[SerializeField]
		private List<ResourceGroups> resourceGroups;

		public string GroupName => groupName;

		public StorageBase StorageBase => storage;

		public List<ResourceGroups> ResourceGroups => resourceGroups;

		public EquipmentSlotType SlotType => equipmentSlotType;

		public override string GetID()
		{
			return id;
		}

		[MustDisposeResource]
		public PooledHashSet<Resource> GetResources()
		{
			PooledHashSet<Resource> janitor = HashSetPool<Resource>.GetJanitor();
			foreach (ResourceGroups resourceGroup in resourceGroups)
			{
				IEnumerable<Resource> allResourcesBySortingGroup = Repository<ResourceRepository, Resource>.Instance.GetAllResourcesBySortingGroup(resourceGroup.GetID());
				janitor.UnionWith(allResourcesBySortingGroup);
			}
			return janitor;
		}

		public void GetResources(HashSet<Resource> set)
		{
			set.Clear();
			foreach (ResourceGroups resourceGroup in resourceGroups)
			{
				IEnumerable<Resource> allResourcesBySortingGroup = Repository<ResourceRepository, Resource>.Instance.GetAllResourcesBySortingGroup(resourceGroup.GetID());
				set.UnionWith(allResourcesBySortingGroup);
			}
		}

		[MustDisposeResource]
		public PooledHashSet<string> GetResourceIds()
		{
			PooledHashSet<string> janitor = HashSetPool<string>.GetJanitor();
			foreach (ResourceGroups resourceGroup in resourceGroups)
			{
				foreach (Resource item in Repository<ResourceRepository, Resource>.Instance.GetAllResourcesBySortingGroup(resourceGroup.GetID()))
				{
					janitor.Add(item.GetID());
				}
			}
			return janitor;
		}
	}
}
