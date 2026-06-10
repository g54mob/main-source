using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Crops;
using NSMedieval.Enums;
using NSMedieval.Model;
using NSMedieval.Stockpiles;
using NSMedieval.StorageUniversal;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.View;
using NSMedieval.View.Animals;
using NSMedieval.Views.Resources;
using NSMedieval.Village;

namespace NSMedieval.Manager
{
	public class SelectableObjectManager : MonoSingleton<SelectableObjectManager>
	{
		public HashSet<SelectableObject> SelectedObjects { get; } = new HashSet<SelectableObject>();

		public SelectableObject MouseHoverObject { get; private set; }

		public HashSet<SelectableObject> SelectableObjects { get; } = new HashSet<SelectableObject>();

		public bool IsMultipleSelected => SelectedObjects.Count > 1;

		private void OnEnable()
		{
			MonoSingleton<ConstructionController>.Instance.ChangeBuildingTypeToPlaceEvent += DeselectAll;
			MonoSingleton<LoadingController>.Instance.MainSceneLeavingEvent += OnLeavingMainScene;
		}

		private void OnDisable()
		{
			if (MonoSingleton<ConstructionController>.IsInstantiated())
			{
				MonoSingleton<ConstructionController>.Instance.ChangeBuildingTypeToPlaceEvent -= DeselectAll;
			}
			if (MonoSingleton<LoadingController>.IsInstantiated())
			{
				MonoSingleton<LoadingController>.Instance.MainSceneLeavingEvent -= OnLeavingMainScene;
			}
		}

		private void OnLeavingMainScene()
		{
			MultiSelectPanelManager.OnDomainReload();
			DeselectAll();
		}

		public bool GetFirstSelected(out SelectableObject selected)
		{
			if (SelectedObjects.Count == 0)
			{
				selected = null;
				return false;
			}
			selected = SelectedObjects.FirstOrDefault();
			return selected != null;
		}

		public T GetFirstSelected<T>() where T : SelectableObject
		{
			return SelectedObjects.FirstOrDefault((SelectableObject obj) => obj is T) as T;
		}

		public PooledList<T> GetSelectedPooled<T>() where T : SelectableObject
		{
			PooledList<T> janitor = ListPool<T>.GetJanitor();
			foreach (SelectableObject selectedObject in SelectedObjects)
			{
				if (selectedObject is T item)
				{
					janitor.Add(item);
				}
			}
			return janitor;
		}

		public bool IsSelected(SelectableObject selectableObject)
		{
			return SelectedObjects.Contains(selectableObject);
		}

		public bool AnySelected(Func<SelectableObject, bool> method)
		{
			return SelectedObjects.Any(method);
		}

		public bool RegisterObject(SelectableObject obj)
		{
			bool num = SelectableObjects.Add(obj);
			if (num)
			{
				MonoSingleton<SelectableObjectController>.Instance.OnRegistered(obj);
			}
			return num;
		}

		public bool RemoveObject(SelectableObject obj)
		{
			bool flag = SelectableObjects.Remove(obj);
			if (!MonoSingleton<SelectableObjectController>.IsInstantiated())
			{
				return flag;
			}
			if (flag && obj.Selected)
			{
				obj.Deselect();
			}
			if (flag)
			{
				MonoSingleton<SelectableObjectController>.Instance.OnRemoved(obj);
			}
			return flag;
		}

		public void SelectObject(SelectableObject selectableObject)
		{
			if (MonoSingleton<KeybindingManager>.IsInstantiated() && !MonoSingleton<KeybindingManager>.Instance.IsKeybindingKeyDown(KeyInputEvent.LeftControl))
			{
				DeselectAll();
			}
			if (!(selectableObject == null))
			{
				selectableObject.Select();
			}
		}

		public void DeselectAll()
		{
			if (SelectedObjects.Count == 0)
			{
				return;
			}
			foreach (SelectableObject item in SelectedObjects.ToList())
			{
				if (item == null)
				{
					SelectedObjects.Remove(item);
					continue;
				}
				item.Deselect(isSilent: true);
				SelectedObjects.Remove(item);
			}
			MonoSingleton<SelectableObjectController>.Instance.OnDeselectAll();
		}

		public void SetHoverObject(SelectableObject selectableObject)
		{
			MouseHoverObject = selectableObject;
			MonoSingleton<SelectableObjectController>.Instance.OnHovered(selectableObject);
		}

		public void OnSelectedEvent(SelectableObject obj)
		{
			if (!SelectedObjects.Contains(obj))
			{
				SelectedObjects.Add(obj);
			}
		}

		public void OnDeSelectedEvent(SelectableObject obj)
		{
			if (SelectedObjects.Contains(obj))
			{
				SelectedObjects.Remove(obj);
			}
		}

		public void SelectResourceType(Resource resource)
		{
			if (SelectedObjects.Count > 0 && SelectedObjects.OfType<ResourcePileView>().Any((ResourcePileView resourcePileView2) => resourcePileView2.ResourcePileInstance?.Blueprint == resource))
			{
				SelectNextOfType();
				return;
			}
			foreach (SelectableObject selectableObject in SelectableObjects)
			{
				ResourcePileView resourcePileView = selectableObject as ResourcePileView;
				if (!(resourcePileView == null) && !(resourcePileView.ResourcePileInstance?.Blueprint != resource))
				{
					DeselectAll();
					selectableObject.Select();
					break;
				}
			}
		}

		public void SelectNextOfType()
		{
			if (SelectableObjects == null)
			{
				Log.Error("SelectableObjects is null!", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\SelectableObjectManager.cs");
				return;
			}
			SelectableObject selectableObject = SelectedObjects?.FirstOrDefault();
			if (!selectableObject)
			{
				Log.Error("Nothing was selected!", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\SelectableObjectManager.cs");
				return;
			}
			int num = 0;
			int num2 = 0;
			using PooledList<SelectableObject> pooledList = ListPool<SelectableObject>.GetJanitor();
			foreach (SelectableObject selectableObject2 in SelectableObjects)
			{
				if ((bool)selectableObject2 && !selectableObject2.IsDestroyed && SelectableObjectTypeCheck(selectableObject2, selectableObject))
				{
					if (selectableObject2.Equals(selectableObject))
					{
						num = num2;
					}
					pooledList.Add(selectableObject2);
					num2++;
				}
			}
			if (pooledList.Count > 1)
			{
				int index = ((num + 1 < pooledList.Count) ? (num + 1) : 0);
				if (!pooledList[index])
				{
					Log.Error("Next selectable object is null/destroyed", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\SelectableObjectManager.cs");
					return;
				}
				DeselectAll();
				MonoSingleton<RtsCamera>.Instance.ChangeFollowTarget(pooledList[index].transform);
				pooledList[index].Select();
			}
		}

		public bool SelectableObjectTypeCheck(SelectableObject obj1, SelectableObject obj2)
		{
			Type type = obj1.GetType();
			if (type != obj2.GetType())
			{
				return false;
			}
			if (type == typeof(WorkerView) || type == typeof(NPCView) || type == typeof(StockpileView) || type == typeof(CropView))
			{
				return true;
			}
			ResourcePileView resourcePileView = obj1 as ResourcePileView;
			if (resourcePileView != null)
			{
				if (resourcePileView is EquipmentPileView)
				{
					EquipmentPileView equipmentPileView = (EquipmentPileView)obj2;
					return resourcePileView.ResourcePileInstance?.Blueprint.SortingGroup == equipmentPileView.ResourcePileInstance?.Blueprint.SortingGroup;
				}
				ResourcePileView resourcePileView2 = (ResourcePileView)obj2;
				return resourcePileView.ResourcePileInstance?.Blueprint == resourcePileView2.ResourcePileInstance?.Blueprint;
			}
			PlantMapResourceView plantMapResourceView = obj1 as PlantMapResourceView;
			if (plantMapResourceView != null)
			{
				PlantMapResourceView plantMapResourceView2 = (PlantMapResourceView)obj2;
				return plantMapResourceView.ResourceInstance?.Blueprint == plantMapResourceView2.ResourceInstance?.Blueprint;
			}
			if (obj1.GetAsWorldObject() is BaseBuildingInstance baseBuildingInstance)
			{
				BaseBuildingInstance baseBuildingInstance2 = (BaseBuildingInstance)obj2.GetAsWorldObject();
				if (baseBuildingInstance2 == null)
				{
					return false;
				}
				if (baseBuildingInstance.ConstructionPhase != baseBuildingInstance2.ConstructionPhase)
				{
					return false;
				}
				if (baseBuildingInstance.Blueprint.HasQuality && baseBuildingInstance2.Blueprint.HasQuality)
				{
					return baseBuildingInstance.Blueprint.GroupIdentifier.Equals(baseBuildingInstance2.Blueprint.GroupIdentifier);
				}
				return baseBuildingInstance.Blueprint == baseBuildingInstance2.Blueprint;
			}
			AnimalView animalView = obj1 as AnimalView;
			if (animalView != null)
			{
				AnimalView animalView2 = (AnimalView)obj2;
				if (animalView.AnimalInstance.AnimalType == animalView2.AnimalInstance.AnimalType)
				{
					return animalView.AnimalInstance.Blueprint == animalView2.AnimalInstance.Blueprint;
				}
				return false;
			}
			return true;
		}

		public SelectableObject GetById(int uniqueId)
		{
			SelectableObject selectableObject = null;
			foreach (SelectableObject selectableObject2 in MonoSingleton<SelectableObjectManager>.Instance.SelectableObjects)
			{
				if (selectableObject != null)
				{
					break;
				}
				if (selectableObject2 is StockpileView stockpileView && stockpileView.StockpileInstance.UniqueId.Equals(uniqueId))
				{
					selectableObject = selectableObject2;
					continue;
				}
				WorldObject asWorldObject = selectableObject2.GetAsWorldObject();
				if (asWorldObject != null)
				{
					ShelfComponentInstance componentInstance = asWorldObject.Map.ShelfComponentManager.GetComponentInstance(asWorldObject);
					if (componentInstance != null && !componentInstance.HasDisposed && componentInstance.AllStorage.Any((UniversalStorage us) => us.UniqueId.Equals(uniqueId)))
					{
						selectableObject = selectableObject2;
					}
				}
			}
			return selectableObject;
		}

		public void FollowSelected()
		{
			if (SelectedObjects.Count != 0)
			{
				MonoSingleton<RtsCamera>.Instance.JumpToAndFollow(SelectedObjects.First().transform);
			}
		}
	}
}
