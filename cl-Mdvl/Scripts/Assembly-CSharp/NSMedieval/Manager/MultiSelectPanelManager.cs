using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.Stockpiles;
using NSMedieval.UI;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.View;
using NSMedieval.View.Animals;
using NSMedieval.Views.Resources;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.Manager
{
	public static class MultiSelectPanelManager
	{
		private static InfoPanelData updateData;

		private static readonly List<SelectionExtraView> ExtraViews = new List<SelectionExtraView>();

		private static readonly Dictionary<string, List<SelectableObject>> ObjectsBySelectName = new Dictionary<string, List<SelectableObject>>();

		private static readonly List<string> Descriptions = new List<string>();

		private static readonly Lazy<InfoPanelHeader> LazyHeader = new Lazy<InfoPanelHeader>(() => new InfoPanelHeader("multiselect_panel", MonoSingleton<LocalizationController>.Instance.GetText("multiselect_panel"), string.Empty));

		private static readonly Lazy<InfoPanelBody> LazyBody = new Lazy<InfoPanelBody>(() => new InfoPanelBody("multiselect_panel", "multiselect_panel", string.Empty, null, Descriptions, null, null, null));

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		public static void OnDomainReload()
		{
			updateData = null;
			ExtraViews.Clear();
			foreach (List<SelectableObject> value in ObjectsBySelectName.Values)
			{
				value.Clear();
			}
			ObjectsBySelectName.Clear();
			Descriptions.Clear();
		}

		public static void ClearObjectsBySelectName()
		{
			foreach (List<SelectableObject> value in ObjectsBySelectName.Values)
			{
				value.Clear();
			}
			ObjectsBySelectName.Clear();
		}

		public static void RefreshData()
		{
			if (MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects.Count > 1)
			{
				GetInfoPanelData(null);
			}
		}

		public static bool DifferentObjectTypesSelected()
		{
			bool result = false;
			SelectableObject selectableObject = MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects.FirstOrDefault((SelectableObject x) => x.GetAsWorldObject() is BaseBuildingInstance);
			if (selectableObject != null && selectableObject.GetAsWorldObject() is BaseBuildingInstance baseBuildingInstance)
			{
				foreach (SelectableObject selectedObject in MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects)
				{
					if (!(selectedObject.GetAsWorldObject() is BaseBuildingInstance baseBuildingInstance2))
					{
						result = true;
						break;
					}
					if (baseBuildingInstance != baseBuildingInstance2 && baseBuildingInstance.BuildingType != baseBuildingInstance2.BuildingType)
					{
						result = true;
						break;
					}
				}
			}
			return result;
		}

		public static InfoPanelData GetInfoPanelData(SelectableObject selectableObject)
		{
			ObjectsBySelectName.Clear();
			if (MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects == null || MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects.Count < 2)
			{
				return null;
			}
			if (!selectableObject)
			{
				selectableObject = MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects.FirstOrDefault();
			}
			foreach (SelectableObject selectedObject in MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects)
			{
				if (selectedObject == selectableObject)
				{
					continue;
				}
				WorldObject asWorldObject = selectedObject.GetAsWorldObject();
				if (asWorldObject == null || !asWorldObject.HasDisposed)
				{
					string multiselectName = selectedObject.GetMultiselectName();
					if (ObjectsBySelectName.TryGetValue(multiselectName, out var value))
					{
						value.Add(selectedObject);
						continue;
					}
					ObjectsBySelectName.Add(multiselectName, new List<SelectableObject> { selectedObject });
				}
			}
			if (selectableObject != null)
			{
				if (ObjectsBySelectName.ContainsKey(selectableObject.GetMultiselectName()))
				{
					ObjectsBySelectName[selectableObject.GetMultiselectName()].Add(selectableObject);
				}
				else
				{
					ObjectsBySelectName.Add(selectableObject.GetMultiselectName(), new List<SelectableObject> { selectableObject });
				}
			}
			Descriptions.Clear();
			foreach (KeyValuePair<string, List<SelectableObject>> item in ObjectsBySelectName)
			{
				if (item.Value[0] is ResourcePileView)
				{
					FillResourcePileDescriptions(item.Value, Descriptions);
					continue;
				}
				Dictionary<string, int> dictionary = new Dictionary<string, int>();
				foreach (SelectableObject item2 in item.Value)
				{
					string simpleName = item2.GetSimpleName();
					if (!dictionary.ContainsKey(simpleName))
					{
						dictionary.Add(simpleName, 1);
					}
					else
					{
						dictionary[simpleName]++;
					}
				}
				foreach (KeyValuePair<string, int> item3 in dictionary)
				{
					Descriptions.Add($"{item3.Key} x{item3.Value}");
				}
			}
			InfoPanelFooter footer = new InfoPanelFooter(GeneratePanelActions());
			ExtraViews.Clear();
			if (AllHaveMeshVariations(out var selectionWithMeshVariations))
			{
				ExtraViews.Add(new InfoPanelMeshVariations(selectionWithMeshVariations));
			}
			List<FuelConsumerComponentInstance> selectionWithFuelConsumers;
			List<GraveComponentInstance> selectionWithGraves;
			List<SiegeWeaponComponentInstance> siegeWeaponsSelection;
			if (AllHaveStorage(out var selectionWithStorage))
			{
				ExtraViews.Add(new InfoPanelStockpile(selectionWithStorage));
			}
			else if (AllHaveFuelConsumer(out selectionWithFuelConsumers))
			{
				ExtraViews.Add(new InfoPanelFuelConsumer(selectionWithFuelConsumers));
			}
			else if (AllGraves(out selectionWithGraves))
			{
				ExtraViews.Add(new InfoPanelGraves(selectionWithGraves));
			}
			else if (AllAreSameSiegeWeapon(out siegeWeaponsSelection))
			{
				ExtraViews.Add(new InfoPanelSiegeWeapon(siegeWeaponsSelection));
			}
			return updateData = new InfoPanelData(InfoPanelDataType.None, LazyHeader.Value, LazyBody.Value, footer, ExtraViews);
		}

		private static bool AllGraves(out List<GraveComponentInstance> selectionWithGraves)
		{
			selectionWithGraves = new List<GraveComponentInstance>();
			bool flag = true;
			foreach (List<SelectableObject> value in ObjectsBySelectName.Values)
			{
				foreach (SelectableObject item in value)
				{
					if (item != null && item.GetAsWorldObject() is BaseBuildingInstance { HasDisposed: false } baseBuildingInstance)
					{
						GraveComponentInstance componentInstance = baseBuildingInstance.Map.GraveComponentManager.GetComponentInstance(baseBuildingInstance);
						if (componentInstance != null)
						{
							selectionWithGraves.Add(componentInstance);
							continue;
						}
						flag = false;
						break;
					}
					flag = false;
					break;
				}
			}
			return selectionWithGraves.Any() && flag;
		}

		private static bool AllHaveFuelConsumer(out List<FuelConsumerComponentInstance> selectionWithFuelConsumers)
		{
			selectionWithFuelConsumers = new List<FuelConsumerComponentInstance>();
			bool flag = true;
			foreach (List<SelectableObject> value in ObjectsBySelectName.Values)
			{
				foreach (SelectableObject item in value)
				{
					if (item != null && item.GetAsWorldObject() is BaseBuildingInstance { HasDisposed: false } baseBuildingInstance)
					{
						FuelConsumerComponentInstance componentInstance = baseBuildingInstance.Map.FuelConsumerComponentManager.GetComponentInstance(baseBuildingInstance);
						if (componentInstance != null)
						{
							selectionWithFuelConsumers.Add(componentInstance);
							continue;
						}
						flag = false;
						break;
					}
					flag = false;
					break;
				}
			}
			return selectionWithFuelConsumers.Any() && flag;
		}

		private static bool AllAreSameSiegeWeapon(out List<SiegeWeaponComponentInstance> siegeWeaponsSelection)
		{
			siegeWeaponsSelection = new List<SiegeWeaponComponentInstance>();
			foreach (List<SelectableObject> value in ObjectsBySelectName.Values)
			{
				string text = string.Empty;
				int num = 0;
				foreach (SelectableObject item in value)
				{
					if (item == null)
					{
						return false;
					}
					if (!(item.GetAsWorldObject() is BaseBuildingInstance baseBuildingInstance))
					{
						return false;
					}
					if (num == 0)
					{
						text = baseBuildingInstance.Blueprint.GetID();
					}
					else if (baseBuildingInstance.Blueprint.GetID() != text)
					{
						return false;
					}
					num++;
					SiegeWeaponComponentInstance componentInstance = baseBuildingInstance.GetComponentInstance<SiegeWeaponComponentInstance>();
					if (componentInstance != null)
					{
						siegeWeaponsSelection.Add(componentInstance);
					}
				}
			}
			return siegeWeaponsSelection.Count > 0;
		}

		private static bool AllHaveStorage(out List<IStorage> selectionWithStorage)
		{
			selectionWithStorage = new List<IStorage>();
			bool flag = true;
			foreach (List<SelectableObject> value in ObjectsBySelectName.Values)
			{
				foreach (SelectableObject item2 in value)
				{
					if (item2 == null)
					{
						continue;
					}
					if (item2.GetAsWorldObject() is StockpileInstance item)
					{
						selectionWithStorage.Add(item);
						continue;
					}
					if (item2.GetAsWorldObject() is BaseBuildingInstance baseBuildingInstance)
					{
						ShelfComponentInstance componentInstance = baseBuildingInstance.GetComponentInstance<ShelfComponentInstance>();
						if (componentInstance != null)
						{
							selectionWithStorage.Add(componentInstance);
							continue;
						}
					}
					flag = false;
					break;
				}
			}
			return selectionWithStorage.Count > 0 && flag;
		}

		private static bool AllHaveMeshVariations(out List<BaseBuildingInstance> selectionWithMeshVariations)
		{
			selectionWithMeshVariations = new List<BaseBuildingInstance>();
			bool flag = true;
			foreach (List<SelectableObject> value in ObjectsBySelectName.Values)
			{
				foreach (SelectableObject item in value)
				{
					if (item != null && item.GetAsWorldObject() is BaseBuildingInstance { Blueprint: { VariationLists: not null, ShowVariations: not false } } baseBuildingInstance)
					{
						selectionWithMeshVariations.Add(baseBuildingInstance);
						continue;
					}
					flag = false;
					break;
				}
			}
			return selectionWithMeshVariations.Count > 0 && flag;
		}

		public static void SetUpdateData(InfoPanelData data)
		{
			updateData = data;
		}

		public static InfoPanelData UpdateCallback()
		{
			if (updateData == null)
			{
				return null;
			}
			InfoPanelData result = updateData;
			updateData = null;
			return result;
		}

		private static void FillResourcePileDescriptions(List<SelectableObject> piles, List<string> list)
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			foreach (SelectableObject pile in piles)
			{
				ResourcePileView resourcePileView = pile as ResourcePileView;
				if (resourcePileView == null)
				{
					continue;
				}
				ResourcePileInstance resourcePileInstance = resourcePileView.ResourcePileInstance;
				if (resourcePileInstance != null && !resourcePileInstance.HasDisposed)
				{
					string simpleName = resourcePileView.GetSimpleName();
					if (!dictionary.ContainsKey(simpleName))
					{
						dictionary.Add(simpleName, resourcePileInstance.GetStoredResource()?.Amount ?? 0);
					}
					else
					{
						dictionary[simpleName] += resourcePileInstance.GetStoredResource()?.Amount ?? 0;
					}
				}
			}
			foreach (KeyValuePair<string, int> item in dictionary)
			{
				list.Add($"{item.Key} x{item.Value}");
			}
		}

		private static List<InfoPanelAction> GeneratePanelActions()
		{
			if (ObjectsBySelectName.Keys.Count > 1)
			{
				return null;
			}
			List<InfoPanelAction> list = new List<InfoPanelAction>();
			foreach (KeyValuePair<string, List<SelectableObject>> pair in ObjectsBySelectName)
			{
				List<SelectableObject> value = pair.Value;
				int num = 0;
				InfoPanelData infoPanelData = null;
				foreach (SelectableObject item in value)
				{
					WorkerView workerView = item as WorkerView;
					if (workerView != null && !workerView.HasDisposed)
					{
						infoPanelData = value[num].GetInfoPanelData();
						break;
					}
					AnimalView animalView = item as AnimalView;
					if (animalView != null && !animalView.HasDisposed)
					{
						infoPanelData = value[num].GetInfoPanelData();
					}
					WorldObject asWorldObject = item.GetAsWorldObject();
					if (asWorldObject != null && !asWorldObject.HasDisposed)
					{
						infoPanelData = value[num].GetInfoPanelData();
						break;
					}
					num++;
				}
				if (infoPanelData?.Footer?.InfoPanelActions == null)
				{
					continue;
				}
				foreach (InfoPanelAction infoPanelAction in infoPanelData.Footer.InfoPanelActions)
				{
					KeyValuePair<SelectionInputActionData, Action>[] array = new KeyValuePair<SelectionInputActionData, Action>[infoPanelAction.ObjectActions.Length];
					int num2 = 0;
					KeyValuePair<SelectionInputActionData, Action>[] objectActions = infoPanelAction.ObjectActions;
					for (int i = 0; i < objectActions.Length; i++)
					{
						KeyValuePair<SelectionInputActionData, Action> actionPair = objectActions[i];
						int curCnt = num2;
						if (!list.Any((InfoPanelAction item) => item.ObjectActions.Length < curCnt && item.CurrentIndex == curCnt && item.ObjectActions.Any((KeyValuePair<SelectionInputActionData, Action> a) => a.Key == actionPair.Key)))
						{
							if (actionPair.Key.GetID().Equals("Banish"))
							{
								break;
							}
							array[curCnt] = new KeyValuePair<SelectionInputActionData, Action>(actionPair.Key, delegate
							{
								AddObjectActions(pair, actionPair, curCnt);
							});
							num2++;
						}
					}
					if (array.Length == 0 || array.Any((KeyValuePair<SelectionInputActionData, Action> item) => item.Key == null))
					{
						continue;
					}
					if (array.Length >= 2 && array[0].Key.GetID().Equals("Forbid"))
					{
						using PooledList<BaseBuildingViewComponent> pooledList = ListPool<BaseBuildingViewComponent>.GetJanitor();
						foreach (SelectableObject selectableObject in MonoSingleton<SelectableObjectManager>.Instance.SelectableObjects)
						{
							BaseBuildingViewComponent baseBuildingViewComponent = selectableObject as BaseBuildingViewComponent;
							if ((bool)baseBuildingViewComponent && !baseBuildingViewComponent.HasDisposed && baseBuildingViewComponent.GetAsWorldObject() is BaseBuildingInstance { HasDisposed: false })
							{
								pooledList.Add(baseBuildingViewComponent);
							}
						}
						if (pooledList.Count > 0)
						{
							bool flag = false;
							bool flag2 = false;
							foreach (BaseBuildingViewComponent item2 in pooledList)
							{
								if (item2.BaseBuildingInstance.ConstructionPhase != ConstructionPhase.Finished)
								{
									flag = true;
									if (!item2.BaseBuildingInstance.IsForbidden)
									{
										flag2 = true;
										break;
									}
								}
							}
							if (flag)
							{
								if (flag2)
								{
									list.Add(new InfoPanelAction(array));
								}
								else
								{
									list.Add(new InfoPanelAction(array, 1));
								}
								continue;
							}
							bool flag3 = false;
							int count = pooledList.Count;
							for (int num3 = 0; num3 < count; num3++)
							{
								ShelfComponentInstance componentInstance = pooledList[num3].BaseBuildingInstance.GetComponentInstance<ShelfComponentInstance>();
								if (componentInstance != null && !componentInstance.IsForbidden())
								{
									flag3 = true;
									break;
								}
							}
							if (flag3)
							{
								list.Add(new InfoPanelAction(array));
							}
							else
							{
								list.Add(new InfoPanelAction(array, 1));
							}
							continue;
						}
						bool flag4 = false;
						foreach (SelectableObject selectedObject in MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects)
						{
							ResourcePileView resourcePileView = selectedObject as ResourcePileView;
							if (resourcePileView != null)
							{
								ResourcePileInstance resourcePileInstance = resourcePileView.ResourcePileInstance;
								if (resourcePileInstance != null && !resourcePileInstance.HasDisposed && !resourcePileInstance.IsForbidden)
								{
									flag4 = true;
									break;
								}
							}
						}
						if (flag4)
						{
							list.Add(new InfoPanelAction(array));
						}
						else
						{
							list.Add(new InfoPanelAction(array, 1));
						}
					}
					else
					{
						list.Add(new InfoPanelAction(array, infoPanelAction.CurrentIndex));
					}
				}
			}
			return list;
		}

		private static void AddObjectActions(KeyValuePair<string, List<SelectableObject>> pair, KeyValuePair<SelectionInputActionData, Action> actionPair, int curCnt)
		{
			string key = pair.Key;
			foreach (SelectableObject item in new HashSet<SelectableObject>(MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects))
			{
				if (item == null || string.IsNullOrEmpty(item.GetMultiselectName()) || !item.GetMultiselectName().Equals(key))
				{
					continue;
				}
				List<InfoPanelAction> list = item.GetInfoPanelData()?.Footer?.InfoPanelActions?.FindAll((InfoPanelAction item) => item?.ObjectActions != null && item.ObjectActions.Any((KeyValuePair<SelectionInputActionData, Action> a) => a.Key == actionPair.Key));
				if (list == null)
				{
					continue;
				}
				foreach (InfoPanelAction item2 in list)
				{
					if (item2.ObjectActions != null && item2.ObjectActions.Length > curCnt)
					{
						KeyValuePair<SelectionInputActionData, Action> keyValuePair = item2.ObjectActions[curCnt];
						keyValuePair.Value?.Invoke();
					}
				}
			}
			if (actionPair.Key == null)
			{
				return;
			}
			string iD = actionPair.Key.GetID();
			if (iD != null && (iD.Equals("Harvesting") || iD.Equals("CutAllVegetation") || iD.Equals("Cancel")))
			{
				MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
				{
					GetInfoPanelData(null);
				});
			}
		}
	}
}
