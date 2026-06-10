using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.View;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.Manager
{
	public class PenViewManager : MonoSingleton<PenViewManager>
	{
		[SerializeField]
		private string roomViewPrefabName = "PenViewPrefab";

		private GameObject penViewPrefab;

		private readonly Dictionary<AnimalPenInstance, AnimalPenView> instanceViewDictionary = new Dictionary<AnimalPenInstance, AnimalPenView>();

		private readonly List<AnimalPenView> unusedViews = new List<AnimalPenView>();

		public List<AnimalPenInstance> PenInstances => instanceViewDictionary.Keys.ToList();

		private GameObject PenViewPrefab
		{
			get
			{
				penViewPrefab = ((penViewPrefab == null) ? MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByAddress(roomViewPrefabName) : penViewPrefab);
				return penViewPrefab;
			}
		}

		private void Start()
		{
			MonoSingleton<PenController>.Instance.OnPenAddedEvent += OnPenAdded;
			MonoSingleton<PenController>.Instance.OnPenRemovedEvent += OnPenRemoved;
			MonoSingleton<PenController>.Instance.OnPenRegionRefreshedEvent += OnPenRegionRefreshed;
			VillageManager.ActiveVillage.Map.OnNodeAddedToRegionEvent += OnNodeAddedToRegion;
			VillageManager.ActiveVillage.Map.OnNodeRemovedFromRegionEvent += OnNodeRemovedFromRegion;
		}

		protected override void OnDestroy()
		{
			if (MonoSingleton<PenController>.IsInstantiated())
			{
				MonoSingleton<PenController>.Instance.OnPenAddedEvent -= OnPenAdded;
				MonoSingleton<PenController>.Instance.OnPenRemovedEvent -= OnPenRemoved;
				MonoSingleton<PenController>.Instance.OnPenRegionRefreshedEvent -= OnPenRegionRefreshed;
			}
			if (VillageManager.ActiveVillage?.Map != null)
			{
				VillageManager.ActiveVillage.Map.OnNodeAddedToRegionEvent -= OnNodeAddedToRegion;
				VillageManager.ActiveVillage.Map.OnNodeRemovedFromRegionEvent -= OnNodeRemovedFromRegion;
			}
			base.OnDestroy();
		}

		private void OnPenAdded(AnimalPenInstance pen)
		{
			if (instanceViewDictionary.ContainsKey(pen))
			{
				instanceViewDictionary[pen].Init(pen);
				return;
			}
			AnimalPenView newPenView = GetNewPenView();
			newPenView.Init(pen);
			instanceViewDictionary.Add(pen, newPenView);
		}

		private void OnPenRemoved(AnimalPenInstance pen)
		{
			if (instanceViewDictionary.ContainsKey(pen))
			{
				ReturnView(instanceViewDictionary[pen]);
				instanceViewDictionary.Remove(pen);
			}
		}

		private void OnPenRegionRefreshed(AnimalPenInstance pen)
		{
			if (instanceViewDictionary.ContainsKey(pen) && !(instanceViewDictionary[pen] == null))
			{
				instanceViewDictionary[pen].RefreshMesh();
			}
		}

		public void OnSelected(SelectableObject obj)
		{
			if (!(obj is BaseBuildingViewComponent { BaseBuildingInstance: { HasDisposed: false } baseBuildingInstance }) || baseBuildingInstance.Blueprint == null || baseBuildingInstance.Blueprint.BuildingType != BuildingType.PenMarker)
			{
				return;
			}
			PenMarkerComponentInstance componentInstance = baseBuildingInstance.Map.PenMarkerComponentManager.GetComponentInstance(baseBuildingInstance);
			if (componentInstance == null)
			{
				return;
			}
			foreach (AnimalPenInstance key in instanceViewDictionary.Keys)
			{
				if (key.PenMarkers != null && key.PenMarkers.Contains(componentInstance))
				{
					instanceViewDictionary[key]?.OnSelected();
				}
			}
		}

		public void OnDeSelected(SelectableObject obj)
		{
			if (!(obj is BaseBuildingViewComponent { BaseBuildingInstance: not null, BaseBuildingInstance: var baseBuildingInstance }) || baseBuildingInstance.HasDisposed || baseBuildingInstance.Blueprint == null || baseBuildingInstance.Blueprint.BuildingType != BuildingType.PenMarker)
			{
				return;
			}
			PenMarkerComponentInstance componentInstance = baseBuildingInstance.Map.PenMarkerComponentManager.GetComponentInstance(baseBuildingInstance);
			if (componentInstance == null)
			{
				return;
			}
			foreach (AnimalPenInstance key in instanceViewDictionary.Keys)
			{
				if (key.PenMarkers.Contains(componentInstance))
				{
					instanceViewDictionary[key].OnDeselected();
				}
			}
		}

		private void OnNodeRemovedFromRegion(Region region, MapNode nodeRemoved)
		{
			RefreshPenForRegion(region);
		}

		private void OnNodeAddedToRegion(Region region, MapNode nodeAdded)
		{
			RefreshPenForRegion(region);
		}

		private void RefreshPenForRegion(Region region)
		{
			AnimalPenInstance pen = MonoSingleton<PenDetection>.Instance.GetPen(region);
			if (pen != null && instanceViewDictionary.ContainsKey(pen))
			{
				AnimalPenView animalPenView = instanceViewDictionary[pen];
				if (animalPenView != null)
				{
					animalPenView.RefreshMesh();
				}
			}
		}

		private AnimalPenView GetNewPenView()
		{
			AnimalPenView firstFreeView = GetFirstFreeView();
			if (firstFreeView != null)
			{
				return firstFreeView;
			}
			return Object.Instantiate(PenViewPrefab).GetComponent<AnimalPenView>();
		}

		private void ReturnView(AnimalPenView animalPenView)
		{
			if (!unusedViews.Contains(animalPenView))
			{
				animalPenView.gameObject.SetActive(value: false);
				unusedViews.Add(animalPenView);
			}
		}

		private AnimalPenView GetFirstFreeView()
		{
			if (unusedViews.Count == 0)
			{
				return null;
			}
			AnimalPenView animalPenView = unusedViews.First();
			animalPenView.gameObject.SetActive(value: true);
			unusedViews.Remove(animalPenView);
			return animalPenView;
		}
	}
}
