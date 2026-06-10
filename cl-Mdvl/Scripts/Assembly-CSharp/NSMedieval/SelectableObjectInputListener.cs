using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Components;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Managers;
using NSMedieval.Map;
using NSMedieval.State;
using NSMedieval.Tools;
using NSMedieval.View;
using NSMedieval.View.Animals;
using NSMedieval.View.Resources;
using NSMedieval.Views.Resources;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval
{
	public sealed class SelectableObjectInputListener : InputListener
	{
		private readonly struct ObjectSelectIgnoreTimeInfo
		{
			private readonly SelectableObject selectableObject;

			public SelectableObject SelectableObject => selectableObject;

			public float SelectedTime { get; }

			public ObjectSelectIgnoreTimeInfo(SelectableObject selectableObject, float selectedTime)
			{
				this.selectableObject = selectableObject;
				SelectedTime = selectedTime;
			}
		}

		private const float RaycastMinDistance = 5.1f;

		private const float RaycastMaxDistance = 1000f;

		private const float ObscuredSelectionTimeout = 1.35f;

		private const float TypeMultiselectTimeout = 0.25f;

		private const float DragSelectionMinArea = 12f;

		private const float ResetClickThroughThreshold = 10f;

		private readonly int raycastMask;

		private readonly List<SelectableObject> selectHitsCache = new List<SelectableObject>();

		private readonly List<ObjectSelectIgnoreTimeInfo> objectSelectionIgnoreTime = new List<ObjectSelectIgnoreTimeInfo>();

		private bool isMultiSelecting;

		private float lastLeftClickTime;

		private bool dragSelectionStarted;

		private Vector3 dragStartPos = Vector3.zero;

		private Vector3 firstScreenClickPos = Vector3.zero;

		private bool clearClickThrough;

		public SelectableObjectInputListener()
			: base(InputListenerType.SelectableObject)
		{
			int num = 1 << LayerMask.NameToLayer("BuildableSurface");
			int num2 = 1 << LayerMask.NameToLayer("Selectable");
			int num3 = 1 << LayerMask.NameToLayer("VoxelMap");
			raycastMask = num | num2 | num3;
			lastLeftClickTime = Time.unscaledTime;
			MonoSingleton<SelectableObjectController>.Instance.OnRemovedEvent += OnSelectableObjectRemoved;
		}

		private void OnSelectableObjectRemoved(SelectableObject obj)
		{
			for (int num = objectSelectionIgnoreTime.Count - 1; num >= 0; num--)
			{
				if (num < objectSelectionIgnoreTime.Count && objectSelectionIgnoreTime[num].SelectableObject == obj)
				{
					objectSelectionIgnoreTime.RemoveAt(num);
					break;
				}
			}
		}

		public override void Dispose()
		{
			base.Dispose();
			selectHitsCache.Clear();
			objectSelectionIgnoreTime.Clear();
			if (MonoSingleton<SelectableObjectController>.IsInstantiated())
			{
				MonoSingleton<SelectableObjectController>.Instance.OnRemovedEvent -= OnSelectableObjectRemoved;
			}
		}

		public void DisableMultiselect()
		{
			isMultiSelecting = false;
		}

		public override void KeyDown(KeyCode key)
		{
			isMultiSelecting = isMultiSelecting || MonoSingleton<KeybindingManager>.Instance.IsKeybindingKeyDown(KeyInputEvent.Multiselect, key);
			base.KeyDown(key);
		}

		public override void KeyUp(KeyCode key)
		{
			isMultiSelecting = isMultiSelecting && !MonoSingleton<KeybindingManager>.Instance.IsKeybindingKeyDown(KeyInputEvent.Multiselect, key);
			base.KeyUp(key);
		}

		public override void MouseButtonDown(int button, Vector3 position)
		{
			if (button == 0)
			{
				dragStartPos = position;
			}
			base.MouseButtonDown(button, position);
		}

		public override void MouseButtonTick(int button, Vector3 position)
		{
			if (button == 0)
			{
				if (!dragSelectionStarted && dragStartPos != Vector3.zero && Vector3.Distance(dragStartPos, position) > 9f)
				{
					dragSelectionStarted = true;
					MonoSingleton<SelectableObjectDragSelectManager>.Instance.DragSelectStart(dragStartPos);
				}
				if (dragSelectionStarted)
				{
					MonoSingleton<SelectableObjectDragSelectManager>.Instance.DragSelectTick(position);
				}
				base.MouseButtonTick(button, position);
			}
		}

		public override void MouseButtonUp(int button, Vector3 position)
		{
			if (button == 0)
			{
				if (dragSelectionStarted)
				{
					HandleDragSelection();
					EndDragSelection();
					return;
				}
				clearClickThrough = Vector3.Distance(position, firstScreenClickPos) > 10f;
				firstScreenClickPos = position;
				EndDragSelection();
				HandleSelection();
				base.MouseButtonUp(button, position);
			}
		}

		public override void MouseFullClick(int button, Vector3 position)
		{
			if (button != 1)
			{
				base.MouseFullClick(button, position);
			}
			else if ((MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects.Count <= 0 || MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects.Any((SelectableObject item) => item is WorkerView)) && !HandleAdditionalMenu())
			{
				MonoSingleton<AdditionalMenuManager>.Instance.HideAll();
				base.MouseFullClick(button, position);
			}
		}

		public override void Disable()
		{
			EndDragSelection();
			base.Disable();
		}

		public bool HandleAdditionalMenu()
		{
			RaycastHit[] raycastHits = GetRaycastHits();
			if (raycastHits == null || raycastHits.Length == 0)
			{
				return false;
			}
			return ProcessAdditionalMenuHit(raycastHits);
		}

		public override void BlockedUpdate()
		{
			base.BlockedUpdate();
			if (dragSelectionStarted && !Input.GetMouseButton(0))
			{
				EndDragSelection();
			}
		}

		private bool ProcessAdditionalMenuHit(RaycastHit[] hits)
		{
			FillCacheWithRaycastHits(hits);
			SelectableObject nextProperHit;
			if (selectHitsCache.Count <= 1)
			{
				nextProperHit = GetNextProperHit(selectHitsCache);
			}
			else
			{
				nextProperHit = GetNextProperHit(selectHitsCache);
				while (nextProperHit != null && !(nextProperHit is IAdditionalMenuOwner))
				{
					nextProperHit = GetNextProperHit(selectHitsCache);
				}
			}
			bool flag = false;
			foreach (WorkerView item in MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects.OfType<WorkerView>())
			{
				WorkerGoapAgent workerGoapAgent = (WorkerGoapAgent)(item.HumanoidInstance?.GetGoapAgent());
				if (workerGoapAgent != null && workerGoapAgent.CurrentHourType == HourType.PsyhoticCrazy)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("selected_worker_is_crazy"));
				return false;
			}
			Vec3Int gridPosition = GridUtils.GetGridPosition((nextProperHit != null) ? nextProperHit.transform.position : hits[0].point);
			int num = GridDataIndexTools.FastTo1DIndex(gridPosition);
			bool flag2 = false;
			if (!gridPosition.Equals(Vec3Int.zero) && num != -1)
			{
				VillageMap map = VillageManager.ActiveVillage.Map;
				if (map.FireSimLogic.GetFireData(num) > 0f)
				{
					VoxelRightClickObject voxelRightClickObject = UnityEngine.Object.FindObjectOfType<VoxelRightClickObject>();
					voxelRightClickObject.transform.position = GridUtils.GetWorldPosition(gridPosition);
					flag2 = MonoSingleton<AdditionalMenuManager>.Instance.ShowMenu(voxelRightClickObject);
				}
				else if (map.FireSimLogic.OilBlobHealth[num] > 0f)
				{
					VoxelRightClickObject voxelRightClickObject2 = UnityEngine.Object.FindObjectOfType<VoxelRightClickObject>();
					voxelRightClickObject2.transform.position = GridUtils.GetWorldPosition(gridPosition);
					flag2 = MonoSingleton<AdditionalMenuManager>.Instance.ShowMenu(voxelRightClickObject2);
				}
			}
			if (flag2)
			{
				return true;
			}
			if (nextProperHit is IAdditionalMenuOwner additionalMenuOwner)
			{
				if (!gridPosition.Equals(Vec3Int.zero) && num != -1 && VillageManager.ActiveVillage.Map.FireSimLogic.OilBlobHealth[num] > 0f)
				{
					VoxelRightClickObject voxelRightClickObject3 = UnityEngine.Object.FindObjectOfType<VoxelRightClickObject>();
					voxelRightClickObject3.transform.position = GridUtils.GetWorldPosition(gridPosition);
					return MonoSingleton<AdditionalMenuManager>.Instance.ShowMenu(additionalMenuOwner, voxelRightClickObject3);
				}
				return MonoSingleton<AdditionalMenuManager>.Instance.ShowMenu(additionalMenuOwner);
			}
			foreach (SelectableObject item2 in selectHitsCache)
			{
				if (item2 == null || !(item2 is IAdditionalMenuOwner additionalMenuOwner2))
				{
					continue;
				}
				if (!gridPosition.Equals(Vec3Int.zero) && num != -1)
				{
					VillageMap map2 = VillageManager.ActiveVillage.Map;
					if (map2.FireSimLogic.GetFireData(num) > 0f || map2.FireSimLogic.OilBlobHealth[num] > 0f)
					{
						VoxelRightClickObject voxelRightClickObject4 = UnityEngine.Object.FindObjectOfType<VoxelRightClickObject>();
						voxelRightClickObject4.transform.position = GridUtils.GetWorldPosition(gridPosition);
						return MonoSingleton<AdditionalMenuManager>.Instance.ShowMenu(additionalMenuOwner2, voxelRightClickObject4);
					}
				}
				return MonoSingleton<AdditionalMenuManager>.Instance.ShowMenu(additionalMenuOwner2);
			}
			return false;
		}

		private void HandleSelection(Func<SelectableObject, bool> condition = null)
		{
			bool flag = Time.unscaledTime - lastLeftClickTime <= 0.25f;
			lastLeftClickTime = Time.unscaledTime;
			if (MonoSingleton<AdditionalMenuManager>.Instance.IsMenuShown())
			{
				MonoSingleton<AdditionalMenuManager>.Instance.HideAll();
				return;
			}
			RaycastHit[] raycastHits = GetRaycastHits();
			if (raycastHits != null && raycastHits.Length != 0)
			{
				if (flag)
				{
					RaycastHit[] array = raycastHits;
					foreach (RaycastHit hit in array)
					{
						SelectableObject selectableObject = HitToSelectableObject(hit);
						if (!(selectableObject == null) && (condition == null || condition(selectableObject)) && MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects.Contains(selectableObject))
						{
							SelectAllOfSameType(selectableObject);
							return;
						}
					}
				}
				ProcessLeftMouseHits(raycastHits);
			}
			else if (!isMultiSelecting)
			{
				if (MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects.Count == 0)
				{
					MonoSingleton<SelectableObjectController>.Instance.OnSelectNothingClick();
				}
				DeselectAllLeftControlCheck();
				objectSelectionIgnoreTime.Clear();
			}
		}

		private void HandleDragSelection()
		{
			if (!HandleDragFilteredSelection(new List<SelectableObject>(MonoSingleton<WorkerManager>.Instance.AllWorkers.Values.Where((WorkerView item) => !item.HasDisposed))) && !HandleDragFilteredSelection(MonoSingleton<ResourcePileManager>.Instance.AllPiles.Where((KeyValuePair<ResourcePileInstance, ResourcePileView> item) => !item.Key.HasDisposed).Select((Func<KeyValuePair<ResourcePileInstance, ResourcePileView>, SelectableObject>)((KeyValuePair<ResourcePileInstance, ResourcePileView> item) => item.Value)).ToList()) && !HandleDragFilteredSelection(new List<SelectableObject>(MonoSingleton<AnimalManager>.Instance.Animals.Values.Where((AnimalView item) => !item.HasDisposed))) && !HandleDragFilteredSelection(new List<SelectableObject>(MonoSingleton<FishResourceManager>.Instance.InstanceView.Values.Where((FishMapResourceView item) => !item.HasDisposed))) && MonoSingleton<SelectableObjectDragSelectManager>.Instance.GetDragBoxArea() / 1000f < 12f)
			{
				HandleSelection();
			}
		}

		private bool HandleDragFilteredSelection(List<SelectableObject> objects)
		{
			bool flag = false;
			if (objects == null)
			{
				return false;
			}
			foreach (SelectableObject @object in objects)
			{
				if (@object == null || @object.transform == null)
				{
					continue;
				}
				Vector3 position = @object.transform.position;
				if (!MonoSingleton<SelectableObjectDragSelectManager>.Instance.IsWithinSelection(position) && @object.MeshLayers != null && @object.MeshLayers.Count > 0)
				{
					bool flag2 = false;
					Dictionary<Renderer, int> meshLayers = @object.MeshLayers;
					if (meshLayers != null && meshLayers.Count > 0)
					{
						foreach (Renderer key in @object.MeshLayers.Keys)
						{
							if (key != null)
							{
								GameObject gameObject = key.gameObject;
								if (gameObject != null && gameObject.activeInHierarchy && !(key is ParticleSystemRenderer) && !(key == null) && MonoSingleton<SelectableObjectDragSelectManager>.Instance.IsWithinSelection(key.bounds.center))
								{
									flag2 = true;
									break;
								}
							}
						}
					}
					if (!flag2)
					{
						continue;
					}
				}
				if (!isMultiSelecting && !flag)
				{
					flag = true;
					MonoSingleton<SelectableObjectManager>.Instance.DeselectAll();
				}
				@object.Select();
			}
			return flag;
		}

		private void EndDragSelection()
		{
			dragSelectionStarted = false;
			dragStartPos = Vector3.zero;
			if (MonoSingleton<SelectableObjectDragSelectManager>.IsInstantiated())
			{
				MonoSingleton<SelectableObjectDragSelectManager>.Instance.DragSelectEnd();
			}
		}

		private MapChunk GetMapChunk(RaycastHit hit)
		{
			return hit.transform.gameObject.GetComponent<MapChunk>();
		}

		private bool ShouldIgnoreGround()
		{
			foreach (SelectableObject item in selectHitsCache)
			{
				if (item is AnimatedAgentView)
				{
					return true;
				}
			}
			return false;
		}

		private void ProcessLeftMouseHits(RaycastHit[] hits)
		{
			FillCacheWithRaycastHits(hits);
			MapChunk mapChunk = GetMapChunk(hits[0]);
			if (mapChunk != null && mapChunk.SelectedTime == 0f)
			{
				mapChunk.SetClickData(Time.unscaledTime, hits[0].point);
			}
			SelectableObject nextProperHit = GetNextProperHit(selectHitsCache);
			if (isMultiSelecting)
			{
				if (!(nextProperHit == null))
				{
					if (nextProperHit.Selected)
					{
						nextProperHit.Deselect();
					}
					else
					{
						nextProperHit.Select();
					}
				}
				return;
			}
			if (!ShouldIgnoreGround() && mapChunk != null)
			{
				if (Time.unscaledTime - mapChunk.SelectedTime < 1.35f)
				{
					DeselectAllLeftControlCheck();
					MonoSingleton<BuildingPlacementManager>.Instance.EmptyClick();
					return;
				}
				if (Vector3.Distance(hits[0].point, mapChunk.ClickPosition) > 1f)
				{
					mapChunk.SetClickData(Time.unscaledTime, hits[0].point);
					DeselectAllLeftControlCheck();
					MonoSingleton<BuildingPlacementManager>.Instance.EmptyClick();
					return;
				}
				mapChunk.SetClickData(0f, Vector3.down);
			}
			if (nextProperHit == null)
			{
				DeselectAllLeftControlCheck();
				MonoSingleton<BuildingPlacementManager>.Instance.EmptyClick();
			}
			else
			{
				MonoSingleton<SelectableObjectManager>.Instance.SelectObject(nextProperHit);
			}
		}

		private void SelectAllOfSameType(SelectableObject obj)
		{
			MonoSingleton<SelectableObjectManager>.Instance.DeselectAll();
			foreach (SelectableObject item in MonoSingleton<SelectableObjectManager>.Instance.SelectableObjects.Where((SelectableObject item) => !item.IsDestroyed && MonoSingleton<SelectableObjectManager>.Instance.SelectableObjectTypeCheck(item, obj) && item.IsOnScreen()))
			{
				item.OnSelectAllOfSameType();
			}
			obj.Select();
		}

		private SelectableObject GetNextProperHit(List<SelectableObject> objects)
		{
			if (objects.Count == 0)
			{
				return null;
			}
			objects.RemoveAll((SelectableObject selectableObject2) => !selectableObject2.Visible);
			if (objects.Count == 1)
			{
				SelectableObject result = objects[0];
				objects.Clear();
				return result;
			}
			SelectableObject[] array = objects.ToArray();
			foreach (SelectableObject item in array)
			{
				ObjectSelectIgnoreTimeInfo item2 = objectSelectionIgnoreTime.FirstOrDefault((ObjectSelectIgnoreTimeInfo objectSelectIgnoreTimeInfo) => objectSelectIgnoreTimeInfo.SelectableObject == item);
				if (item2.Equals(default(ObjectSelectIgnoreTimeInfo)))
				{
					continue;
				}
				if (isMultiSelecting)
				{
					if (MonoSingleton<SelectableObjectManager>.Instance.SelectableObjects.Any((SelectableObject x) => x.GetType() == item.GetType()))
					{
						continue;
					}
					objects.Remove(item);
				}
				if (Time.unscaledTime - item2.SelectedTime > 1.35f)
				{
					objectSelectionIgnoreTime.Remove(item2);
					continue;
				}
				if (MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects.Count == 1 && clearClickThrough)
				{
					objects.RemoveRange(1, objects.Count - 1);
					break;
				}
				objects.Remove(item);
			}
			SelectableObject selectableObject = ((objects.Count == 0) ? null : objects[0]);
			if (selectableObject != null)
			{
				objectSelectionIgnoreTime.Add(new ObjectSelectIgnoreTimeInfo(selectableObject, Time.unscaledTime));
			}
			return selectableObject;
		}

		private RaycastHit[] GetRaycastHits()
		{
			Camera gameplayCamera = MonoSingleton<CameraManager>.Instance.GameplayCamera;
			RaycastHit[] array = Physics.RaycastAll(MonoSingleton<CameraManager>.Instance.GameplayCamera.ScreenPointToRay(Input.mousePosition), 1000f, raycastMask);
			if (array == null || array.Length <= 1)
			{
				return array;
			}
			Vector3 cameraPosition = gameplayCamera.transform.position;
			Array.Sort(array, (RaycastHit hit1, RaycastHit hit2) => Vector3.Distance(hit1.point, cameraPosition).CompareTo(Vector3.Distance(hit2.point, cameraPosition)));
			return array;
		}

		private void FillCacheWithRaycastHits(RaycastHit[] hits)
		{
			selectHitsCache.Clear();
			int num = 0;
			Vector3 position = MonoSingleton<CameraManager>.Instance.GameplayCamera.transform.position;
			for (int i = 0; i < hits.Length; i++)
			{
				RaycastHit hit = hits[i];
				SelectableObject selectableObject = HitToSelectableObject(hit);
				if (selectableObject == null || Vector3.Distance(position, hit.point) < 5.1f)
				{
					continue;
				}
				if (selectableObject is AnimatedAgentView)
				{
					if (i != 0)
					{
						selectHitsCache.Insert(num, selectableObject);
					}
					else
					{
						selectHitsCache.Add(selectableObject);
					}
					num++;
				}
				else
				{
					selectHitsCache.Add(selectableObject);
				}
			}
		}

		private SelectableObject HitToSelectableObject(RaycastHit hit)
		{
			SelectableObject selectableObject = hit.transform.gameObject.GetComponent<SelectableObject>();
			if (selectableObject == null && hit.transform.parent != null)
			{
				selectableObject = hit.transform.parent.gameObject.GetComponentInParent<SelectableObject>();
			}
			if (selectableObject == null)
			{
				selectableObject = hit.transform.gameObject.GetComponentInChildren<SelectableObject>();
			}
			return selectableObject;
		}

		public void DeselectAllLeftControlCheck()
		{
			if (MonoSingleton<KeybindingManager>.IsInstantiated() && !MonoSingleton<KeybindingManager>.Instance.IsKeybindingKeyDown(KeyInputEvent.LeftControl))
			{
				MonoSingleton<SelectableObjectManager>.Instance.DeselectAll();
			}
		}
	}
}
