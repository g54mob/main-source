using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.Stockpiles;
using UnityEngine;

namespace NSMedieval.StorageUniversal
{
	[Serializable]
	public class UniversalStorageBlueprint : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private int maxPileCount;

		[SerializeField]
		private int maxAmount;

		[SerializeField]
		private List<string> storableResourceGroups;

		[SerializeField]
		private List<ResourceGroups> resourceGroups;

		[SerializeField]
		private List<string> parentGroups = new List<string>();

		[SerializeField]
		private ZonePriority zonePriority;

		[SerializeField]
		private float refillPercentageThreshold;

		[SerializeField]
		private int refillWhileRainingAmount;

		public int MaxPileCount => maxPileCount;

		public int MaxAmount => maxAmount;

		public bool OverrideStackingLimit => maxAmount > 0;

		public List<string> StorableResourceGroups => storableResourceGroups;

		public List<ResourceGroups> ResourceGroups
		{
			get
			{
				if (resourceGroups == null)
				{
					resourceGroups = new List<ResourceGroups>();
				}
				if (resourceGroups.Count == 0)
				{
					InitializeStorableGroups(storableResourceGroups);
				}
				return resourceGroups;
			}
		}

		public ZonePriority ZonePriority => zonePriority;

		public float RefillPercentageThreshold => refillPercentageThreshold;

		public List<string> GetParentGroups()
		{
			if (parentGroups.Count > 0)
			{
				return parentGroups;
			}
			parentGroups.Clear();
			List<ResourceGroups> list = new List<ResourceGroups>(ResourceGroups);
			foreach (ResourceGroups resourceGroup in ResourceGroups)
			{
				int num = 0;
				List<ResourceGroups> list2 = new List<ResourceGroups>();
				foreach (string subgroupID in resourceGroup.SubGroupIDs)
				{
					ResourceGroups item = Repository<StockpileRepository, Stockpile>.Instance.GetByID("default_stockpile").ResourceGroups.FirstOrDefault((ResourceGroups x) => x.GetID() == subgroupID);
					if (list.Contains(item))
					{
						list2.Add(item);
						num++;
					}
				}
				if (num > 0)
				{
					if (num == resourceGroup.SubGroupIDs.Count)
					{
						list.RemoveMultiple(list2);
					}
					else
					{
						list.Remove(resourceGroup);
					}
				}
			}
			foreach (ResourceGroups item3 in list.IterateInReverseDynamic())
			{
				int num2 = 0;
				foreach (string subgroupID2 in item3.SubGroupIDs)
				{
					ResourceGroups item2 = Repository<StockpileRepository, Stockpile>.Instance.GetByID("default_stockpile").ResourceGroups.FirstOrDefault((ResourceGroups x) => x.GetID() == subgroupID2);
					if (ResourceGroups.Contains(item2))
					{
						num2++;
					}
				}
				if (num2 < item3.SubGroupIDs.Count)
				{
					list.Remove(item3);
				}
			}
			foreach (ResourceGroups item4 in list)
			{
				parentGroups.Add(item4.GetID());
			}
			return parentGroups;
		}

		public override string GetID()
		{
			return id;
		}

		private ResourceGroups GetActualResourceGroup(string id)
		{
			ResourceGroups resourceGroups = Repository<StockpileRepository, Stockpile>.Instance.GetByID("default_stockpile").ResourceGroups.FirstOrDefault((ResourceGroups x) => x.GetID() == id);
			if (resourceGroups != null)
			{
				if (resourceGroups.SubGroupIDs.Count <= 0)
				{
					return resourceGroups;
				}
				InitializeStorableGroups(resourceGroups.SubGroupIDs);
			}
			return null;
		}

		private void InitializeStorableGroups(List<string> storableGroups)
		{
			foreach (string storableGroup in storableGroups)
			{
				ResourceGroups actualResourceGroup = GetActualResourceGroup(storableGroup);
				if (!(actualResourceGroup == null) && !resourceGroups.Contains(actualResourceGroup))
				{
					resourceGroups.Add(GetActualResourceGroup(storableGroup));
					AddParentsToList(storableGroup);
				}
			}
		}

		private void AddParentsToList(string childNode)
		{
			foreach (ResourceGroups resourceGroup in Repository<StockpileRepository, Stockpile>.Instance.GetByID("default_stockpile").ResourceGroups)
			{
				foreach (string subGroupID in resourceGroup.SubGroupIDs)
				{
					if (subGroupID == childNode && !resourceGroups.Contains(resourceGroup))
					{
						resourceGroups.Add(resourceGroup);
						AddParentsToList(resourceGroup.GetID());
					}
				}
			}
		}
	}
}
