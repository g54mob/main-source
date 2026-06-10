using System;
using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Resources;
using NSMedieval.Stockpiles;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class ResourcePanelManager : PanelBase
	{
		[SerializeField]
		private RectTransform contentRect;

		[SerializeField]
		private Transform listParent;

		[SerializeField]
		private Transform groupRootParent;

		[SerializeField]
		private GameObject resourceGroupPrefab;

		[SerializeField]
		private ScrollRect listScrollView;

		[SerializeField]
		private ScrollRect groupScrollView;

		private List<Resource> resources;

		private Dictionary<Resource, ResourceGroupItemView> resourceListElements;

		private Dictionary<Resource, ResourceGroupItemView> resourceGroupElements;

		private Dictionary<ResourceGroups, ResourceGroupItemView> resourceGroups;

		private Dictionary<ResourceGroups, List<ResourceGroups>> parents;

		private Dictionary<ResourceGroups, List<Resource>> children;

		private List<ResourceGroups> allowedGroups;

		protected override bool SubscribeToEscapeKey => false;

		protected override PanelGroupType GetGroupType()
		{
			return PanelGroupType.Resources;
		}

		protected override void UpdatePanel()
		{
		}

		protected override void Start()
		{
			if (GlobalSaveController.CurrentVillageData.IsSecondMap)
			{
				base.Start();
				return;
			}
			resources = new List<Resource>();
			resourceListElements = new Dictionary<Resource, ResourceGroupItemView>();
			resourceGroupElements = new Dictionary<Resource, ResourceGroupItemView>();
			resourceGroups = new Dictionary<ResourceGroups, ResourceGroupItemView>();
			parents = new Dictionary<ResourceGroups, List<ResourceGroups>>();
			children = new Dictionary<ResourceGroups, List<Resource>>();
			allowedGroups = new List<ResourceGroups>();
			MonoSingleton<UIController>.Instance.ResurcesShowGroupView += SwitchResourcesView;
			MonoSingleton<ResourceCommonController>.Instance.OnResourceGroupItemUpdate += OnGroupExpansion;
			MonoSingleton<ResourcePileController>.Instance.ResourceCountChangeEvent += OnUpdateSingleResource;
			MonoSingleton<World>.Instance.MapLoadedEvent += OnMapLoaded;
			base.Start();
			SetupResources();
		}

		protected override void OnDestroy()
		{
			if (MonoSingleton<UIController>.IsInstantiated())
			{
				MonoSingleton<UIController>.Instance.ResurcesShowGroupView -= SwitchResourcesView;
			}
			if (MonoSingleton<ResourceCommonController>.IsInstantiated())
			{
				MonoSingleton<ResourceCommonController>.Instance.OnResourceGroupItemUpdate -= OnGroupExpansion;
			}
			if (MonoSingleton<ResourcePileController>.IsInstantiated())
			{
				MonoSingleton<ResourcePileController>.Instance.ResourceCountChangeEvent -= OnUpdateSingleResource;
			}
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.MapLoadedEvent -= OnMapLoaded;
			}
			base.OnDestroy();
		}

		protected override void OnEnable()
		{
			MonoSingleton<UIController>.Instance.Attach(this);
		}

		protected override void OnDisable()
		{
			if (MonoSingleton<UIController>.IsInstantiated())
			{
				MonoSingleton<UIController>.Instance.Detach(this);
			}
		}

		private void OnMapLoaded(bool wasLoadedFromSave)
		{
			ResourcePileTracker instance = MonoSingleton<ResourcePileTracker>.Instance;
			foreach (Resource allItem in Repository<ResourceRepository, Resource>.Instance.GetAllItems())
			{
				ResourcePileCount count = instance.GetCount(allItem);
				OnUpdateSingleResource(allItem, count);
			}
		}

		private void SwitchResourcesView(bool groupViewOn)
		{
			listScrollView.gameObject.SetActive(!groupViewOn);
			groupScrollView.gameObject.SetActive(groupViewOn);
		}

		private void OnUpdateSingleResource(Resource resource, ResourcePileCount count)
		{
			if (resourceGroupElements.ContainsKey(resource))
			{
				resourceGroupElements[resource].UpdateValue(count.StockpilePlacedCount);
			}
			if (resourceListElements.ContainsKey(resource))
			{
				resourceListElements[resource].UpdateValue(count.StockpilePlacedCount);
			}
		}

		private void SetupResources()
		{
			using PooledHashSet<string> pooledHashSet = HashSetPool<string>.GetJanitor();
			foreach (ResourceGroups resourceGroup in Repository<StockpileRepository, Stockpile>.Instance.GetByID("hud_display_stockpile").ResourceGroups)
			{
				allowedGroups.Add(resourceGroup);
				pooledHashSet.Add(resourceGroup.GetID());
			}
			foreach (Resource allItem in Repository<ResourceRepository, Resource>.Instance.GetAllItems())
			{
				if (pooledHashSet.Contains(allItem.SortingGroup))
				{
					resources.Add(allItem);
					GameObject gameObject = UnityEngine.Object.Instantiate(resourceGroupPrefab, listParent);
					gameObject.name = allItem.GetID();
					gameObject.SetActive(value: false);
					resourceListElements.Add(allItem, gameObject.GetComponent<ResourceGroupItemView>());
					resourceListElements[allItem].SetupGroup(allItem.GetID(), "name", -1, 0, ResourceClickCallback(allItem));
				}
			}
			SetupGroups();
		}

		private void SetupGroups()
		{
			foreach (ResourceGroups allowedGroup in allowedGroups)
			{
				resourceGroups.Add(allowedGroup, UnityEngine.Object.Instantiate(resourceGroupPrefab, groupRootParent).GetComponent<ResourceGroupItemView>());
			}
			foreach (ResourceGroups allowedGroup2 in allowedGroups)
			{
				string nameKey = allowedGroup2.GetID();
				Transform parent = groupRootParent;
				foreach (ResourceGroups allowedGroup3 in allowedGroups)
				{
					foreach (string subGroupID in allowedGroup3.SubGroupIDs)
					{
						if (allowedGroup2.GetID() == subGroupID)
						{
							parent = resourceGroups[allowedGroup3].transform;
							resourceGroups[allowedGroup3].AddChild(resourceGroups[allowedGroup2]);
							if (!parents.ContainsKey(allowedGroup3))
							{
								parents.Add(allowedGroup3, new List<ResourceGroups>());
							}
							parents[allowedGroup3].Add(allowedGroup2);
							nameKey = subGroupID;
							goto end_IL_0146;
						}
					}
					continue;
					end_IL_0146:
					break;
				}
				resourceGroups[allowedGroup2].transform.SetParent(parent);
				resourceGroups[allowedGroup2].gameObject.name = nameKey;
				resourceGroups[allowedGroup2].SetupGroup(nameKey, "group", allowedGroup2.Depth);
				AddGroupResource(allowedGroup2);
			}
		}

		private void AddGroupResource(ResourceGroups node)
		{
			ResourceGroupItemView resourceGroupItemView = resourceGroups[node];
			foreach (Resource resource in resources)
			{
				if (resource.SortingGroup == node.GetID())
				{
					ResourceGroupItemView component = UnityEngine.Object.Instantiate(resourceGroupPrefab, resourceGroupItemView.transform).GetComponent<ResourceGroupItemView>();
					string iD = resource.GetID();
					component.gameObject.name = iD;
					component.SetupGroup(iD, "name", node.Depth + 1, 0, ResourceClickCallback(resource));
					resourceGroupItemView.AddChild(component);
					if (!children.ContainsKey(node))
					{
						children.Add(node, new List<Resource>());
					}
					children[node].Add(resource);
					resourceGroupElements.Add(resource, component);
				}
			}
		}

		private static Action ResourceClickCallback(Resource resource)
		{
			return delegate
			{
				MonoSingleton<SelectableObjectManager>.Instance.SelectResourceType(resource);
			};
		}

		private void OnGroupExpansion()
		{
			MonoSingleton<TaskController>.Instance.OptimizedCall(this, "rebuild", delegate
			{
				if (!(this == null) && groupRootParent is RectTransform layoutRoot)
				{
					LayoutRebuilder.ForceRebuildLayoutImmediate(layoutRoot);
				}
			});
		}
	}
}
