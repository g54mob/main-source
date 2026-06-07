using System;
using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class RTObjectSelection : MonoSingleton<RTObjectSelection>
	{
		[Flags]
		private enum SelectRestrictFlags
		{
			None = 0,
			ObjectLayer = 1,
			ObjectType = 2,
			Object = 4,
			SelectionListener = 8,
			All = 0xF
		}

		private struct CyclicalClickSelectInfo
		{
			public int LastSelectedIndex;

			public GameObject LastPickedObject;
		}

		private static readonly int _objectPickDeviceBtnIndex;

		[SerializeField]
		private bool _isEnabled = true;

		private List<Camera> _renderIgnoreCameras = new List<Camera>();

		private List<GameObject> _selectedObjects = new List<GameObject>();

		private MultiSelectShape _multiSelectShape = new MultiSelectShape();

		private ObjectSelectionSnapshot _multiSelectPreChangeSnapshot = new ObjectSelectionSnapshot();

		private bool _wasSelectionChangedViaMultiSelectShape;

		private bool _willBeDeleted;

		private bool _doingPreSelectCustomize;

		private bool _doingPreDeselectCustomize;

		private bool _firingSelectionChanged;

		private ObjectSelectionManipSession _activeManipSession;

		private CyclicalClickSelectInfo _cyclicalClickSelectInfo = new CyclicalClickSelectInfo
		{
			LastSelectedIndex = -1
		};

		[SerializeField]
		private ObjectSelectionHotkeys _hotkeys = new ObjectSelectionHotkeys();

		[SerializeField]
		private ObjectSelectionSettings _settings = new ObjectSelectionSettings();

		[SerializeField]
		private ObjectSelectionLookAndFeel _lookAndFeel = new ObjectSelectionLookAndFeel();

		[SerializeField]
		private ObjectSelectionRotationSettings _rotationSettings = new ObjectSelectionRotationSettings();

		[SerializeField]
		private ObjectSelectionRotationHotkeys _rotationHotkeys = new ObjectSelectionRotationHotkeys();

		private DeviceObjectGrabSession _grabSession = new DeviceObjectGrabSession();

		[SerializeField]
		private ObjectGrabSettings _grabSettings = new ObjectGrabSettings();

		[SerializeField]
		private ObjectGrabLookAndFeel _grabLookAndFeel = new ObjectGrabLookAndFeel();

		[SerializeField]
		private ObjectGrabHotkeys _grabHotkeys = new ObjectGrabHotkeys();

		private ObjectGridSnapSession _gridSnapSession = new ObjectGridSnapSession();

		[SerializeField]
		private ObjectGridSnapLookAndFeel _gridSnapLookAndFeel = new ObjectGridSnapLookAndFeel();

		[SerializeField]
		private ObjectGridSnapHotkeys _gridSnapHotkeys = new ObjectGridSnapHotkeys();

		private Object2ObjectSnapSession _object2ObjectSnapSession = new Object2ObjectSnapSession();

		[SerializeField]
		private Object2ObjectSnapSettings _object2ObjectSnapSettings = new Object2ObjectSnapSettings();

		[SerializeField]
		private Object2ObjectSnapHotkeys _object2ObjectSnapHotkeys = new Object2ObjectSnapHotkeys();

		[SerializeField]
		private EditorToolbar _settingsToolbar = new EditorToolbar(new EditorToolbarTab[5]
		{
			new EditorToolbarTab("General", "General selection settings."),
			new EditorToolbarTab("Selection grab", "Selection grab settings."),
			new EditorToolbarTab("Object2Object snap", "Selection object-to-object snap settings."),
			new EditorToolbarTab("Grid snap", "Selection grid snap settings."),
			new EditorToolbarTab("Rotation", "Selection rotation settings.")
		}, 5, Color.green);

		public bool IsEnabled => _isEnabled;

		public bool IsMultiSelectShapeVisible => _multiSelectShape.IsVisible;

		public int NumSelectedObjects => _selectedObjects.Count;

		public ObjectSelectionHotkeys Hotkeys => _hotkeys;

		public ObjectSelectionSettings Settings => _settings;

		public ObjectSelectionLookAndFeel LookAndFeel => _lookAndFeel;

		public ObjectSelectionRotationSettings RotationSettings => _rotationSettings;

		public ObjectSelectionRotationHotkeys RotationHotkeys => _rotationHotkeys;

		public ObjectGrabSettings GrabSettings => _grabSettings;

		public ObjectGrabHotkeys GrabHotkeys => _grabHotkeys;

		public ObjectGrabLookAndFeel GrabLookAndFeel => _grabLookAndFeel;

		public ObjectGridSnapLookAndFeel GridSnapLookAndFeel => _gridSnapLookAndFeel;

		public ObjectGridSnapHotkeys GridSnapHotkeys => _gridSnapHotkeys;

		public Object2ObjectSnapSettings Object2ObjectSnapSettings => _object2ObjectSnapSettings;

		public Object2ObjectSnapHotkeys Object2ObjectSnapHotkeys => _object2ObjectSnapHotkeys;

		public bool IsManipSessionActive => _activeManipSession != ObjectSelectionManipSession.None;

		public ObjectSelectionManipSession ActiveManipSession => _activeManipSession;

		public bool IsGrabSessionActive => ActiveManipSession == ObjectSelectionManipSession.Grab;

		public bool IsGridSnapSessionActive => ActiveManipSession == ObjectSelectionManipSession.GridSnap;

		public bool IsObject2ObjectSnapSessionActive => ActiveManipSession == ObjectSelectionManipSession.Object2ObjectSnap;

		public List<GameObject> SelectedObjects => new List<GameObject>(_selectedObjects);

		public event ObjectSelectionManipSessionBeginHandler ManipSessionBegin;

		public event ObjectSelectionManipSessionEndHandler ManipSessionEnd;

		public event ObjectSelectionCanClickSelectDeselectHandler CanClickSelectDeselect;

		public event ObjectSelectionCanMultiSelectDeselectHandler CanMultiSelectDeselect;

		public event ObjectSelectionChangedHandler Changed;

		public event ObjectSelectionWillBeDeletedHandler WillBeDeleted;

		public event ObjectSelectionDeletedHandler Deleted;

		public event ObjectSelectionWillBeDuplicatedHandler WillBeDuplicated;

		public event ObjectSelectionDuplicatedHandler Duplicated;

		public event ObjectSelectionRotatedHandler Rotated;

		public event ObjectSelectionPreSelectCustomizeHandler PreSelectCustomize;

		public event ObjectSelectionPreDeselectCustomizeHandler PreDeselectCustomize;

		public event ObjectSelectionEnabled Enabled;

		public event ObjectSelectionDisabled Disabled;

		public void Initialize_SystemCall()
		{
			_grabSession.SharedSettings = GrabSettings;
			_grabSession.SharedHotkeys = GrabHotkeys;
			_grabSession.SharedLookAndFeel = GrabLookAndFeel;
			_grabSession.SessionBegin += OnGrabSessionBegin;
			_grabSession.SessionEnd += OnGrabSessionEnd;
			_gridSnapSession.SharedHotkeys = GridSnapHotkeys;
			_gridSnapSession.SharedLookAndFeel = GridSnapLookAndFeel;
			_gridSnapSession.SessionBegin += OnGridSnapSessionBegin;
			_gridSnapSession.SessionEnd += OnGridSnapSessionEnd;
			_object2ObjectSnapSession.SharedSettings = Object2ObjectSnapSettings;
			_object2ObjectSnapSession.SharedHotkeys = Object2ObjectSnapHotkeys;
			_object2ObjectSnapSession.SessionBegin += OnObject2ObjectSnapSessionBegin;
			_object2ObjectSnapSession.SessionEnd += OnObject2ObjectSnapSessionEnd;
			MonoSingleton<RTUndoRedo>.Get.UndoEnd += OnUndoEnd;
			MonoSingleton<RTUndoRedo>.Get.RedoEnd += OnRedoEnd;
		}

		public void AttachGizmoController(IObjectCollectionGizmoController gizmoController)
		{
			gizmoController.SetTargetObjectCollection(_selectedObjects);
		}

		public bool IsRenderIgnoreCamera(Camera camera)
		{
			return _renderIgnoreCameras.Contains(camera);
		}

		public void AddRenderIgnoreCamera(Camera camera)
		{
			if (!IsRenderIgnoreCamera(camera))
			{
				_renderIgnoreCameras.Add(camera);
			}
		}

		public void RemoveRenderIgnoreCamera(Camera camera)
		{
			_renderIgnoreCameras.Remove(camera);
		}

		public void SetEnabled(bool isEnabled)
		{
			if (isEnabled == _isEnabled)
			{
				return;
			}
			_isEnabled = isEnabled;
			if (!_isEnabled)
			{
				_gridSnapSession.End();
				_grabSession.End();
				_object2ObjectSnapSession.End();
				if (this.Disabled != null)
				{
					this.Disabled();
				}
			}
			else if (this.Enabled != null)
			{
				this.Enabled();
			}
		}

		public void SetRotation(Quaternion rotation)
		{
			List<LocalTransformSnapshot> snapshotCollection = LocalTransformSnapshot.GetSnapshotCollection(_selectedObjects);
			foreach (GameObject item in GameObjectEx.FilterParentsOnly(_selectedObjects))
			{
				item.transform.rotation = rotation;
			}
			List<LocalTransformSnapshot> snapshotCollection2 = LocalTransformSnapshot.GetSnapshotCollection(_selectedObjects);
			new PostObjectTransformsChangedAction(snapshotCollection, snapshotCollection2).Execute();
			if (this.Rotated != null)
			{
				this.Rotated();
			}
		}

		public void Rotate(Axis axis, float rotationAngle, ObjectRotationPivot rotationPivot)
		{
			List<LocalTransformSnapshot> snapshotCollection = LocalTransformSnapshot.GetSnapshotCollection(_selectedObjects);
			Vector3 axis2 = Vector3.right;
			switch (axis)
			{
			case Axis.Y:
				axis2 = Vector3.up;
				break;
			case Axis.Z:
				axis2 = Vector3.forward;
				break;
			}
			Quaternion quaternion = Quaternion.AngleAxis(rotationAngle, axis2);
			switch (rotationPivot)
			{
			case ObjectRotationPivot.GroupCenter:
			{
				AABB worldAABB = GetWorldAABB();
				foreach (GameObject item in GameObjectEx.FilterParentsOnly(_selectedObjects))
				{
					item.transform.RotateAroundPivot(quaternion, worldAABB.Center);
				}
				break;
			}
			case ObjectRotationPivot.IndividualCenter:
			{
				ObjectBounds.QueryConfig queryConfig = new ObjectBounds.QueryConfig
				{
					NoVolumeSize = Vector3Ex.FromValue(0.01f),
					ObjectTypes = GameObjectTypeHelper.AllCombined
				};
				foreach (GameObject item2 in GameObjectEx.FilterParentsOnly(_selectedObjects))
				{
					OBB oBB = ObjectBounds.CalcHierarchyWorldOBB(item2, queryConfig);
					item2.transform.RotateAroundPivot(quaternion, oBB.Center);
				}
				break;
			}
			case ObjectRotationPivot.IndividualPivot:
				foreach (GameObject item3 in GameObjectEx.FilterParentsOnly(_selectedObjects))
				{
					item3.transform.rotation = quaternion * item3.transform.rotation;
				}
				break;
			}
			List<LocalTransformSnapshot> snapshotCollection2 = LocalTransformSnapshot.GetSnapshotCollection(_selectedObjects);
			new PostObjectTransformsChangedAction(snapshotCollection, snapshotCollection2).Execute();
			if (this.Rotated != null)
			{
				this.Rotated();
			}
		}

		public void AppendObjects(List<GameObject> gameObjects, bool allowUndoRedo)
		{
			if (!CanBeModifiedByAPI() || gameObjects == null || gameObjects.Count == 0)
			{
				return;
			}
			ObjectSelectionSnapshot objectSelectionSnapshot = new ObjectSelectionSnapshot();
			if (allowUndoRedo)
			{
				objectSelectionSnapshot.Snapshot();
			}
			bool flag = false;
			ObjectSelectReason selectReason = ObjectSelectReason.AppendToSelectionCall;
			List<GameObject> list = new List<GameObject>();
			foreach (GameObject gameObject in gameObjects)
			{
				if (!IsObjectSelected(gameObject) && CanSelectObject(gameObject, SelectRestrictFlags.None, selectReason))
				{
					SelectObject(gameObject, selectReason);
					list.Add(gameObject);
					flag = true;
				}
			}
			if (flag)
			{
				OnSelectionChanged(new ObjectSelectionChangedEventArgs(selectReason, list, ObjectDeselectReason.None, null));
				if (allowUndoRedo)
				{
					ObjectSelectionSnapshot objectSelectionSnapshot2 = new ObjectSelectionSnapshot();
					objectSelectionSnapshot2.Snapshot();
					new PostObjectSelectionChangedAction(objectSelectionSnapshot, objectSelectionSnapshot2).Execute();
				}
			}
		}

		public void RemoveObjects(List<GameObject> gameObjects, bool allowUndoRedo)
		{
			if (!CanBeModifiedByAPI() || gameObjects == null || gameObjects.Count == 0)
			{
				return;
			}
			ObjectSelectionSnapshot objectSelectionSnapshot = new ObjectSelectionSnapshot();
			if (allowUndoRedo)
			{
				objectSelectionSnapshot.Snapshot();
			}
			bool flag = false;
			ObjectDeselectReason deselectReason = ObjectDeselectReason.RemoveFromSelectionCall;
			List<GameObject> list = new List<GameObject>();
			foreach (GameObject gameObject in gameObjects)
			{
				if (IsObjectSelected(gameObject))
				{
					DeselectObject(gameObject, deselectReason);
					list.Add(gameObject);
					flag = true;
				}
			}
			if (flag)
			{
				OnSelectionChanged(new ObjectSelectionChangedEventArgs(ObjectSelectReason.None, null, deselectReason, list));
				if (allowUndoRedo)
				{
					ObjectSelectionSnapshot objectSelectionSnapshot2 = new ObjectSelectionSnapshot();
					objectSelectionSnapshot2.Snapshot();
					new PostObjectSelectionChangedAction(objectSelectionSnapshot, objectSelectionSnapshot2).Execute();
				}
			}
		}

		public void SetSelectedObjects(List<GameObject> gameObjects, bool allowUndoRedo)
		{
			if (!CanBeModifiedByAPI())
			{
				return;
			}
			if (gameObjects == null)
			{
				gameObjects = new List<GameObject>();
			}
			if (IsSelectionExactMatch(gameObjects))
			{
				return;
			}
			ObjectSelectionSnapshot objectSelectionSnapshot = new ObjectSelectionSnapshot();
			if (allowUndoRedo)
			{
				objectSelectionSnapshot.Snapshot();
			}
			bool flag = false;
			ObjectSelectReason selectReason = ObjectSelectReason.None;
			ObjectDeselectReason deselectReason = ObjectDeselectReason.None;
			List<GameObject> list = new List<GameObject>();
			List<GameObject> list2 = new List<GameObject>();
			foreach (GameObject selectedObject in SelectedObjects)
			{
				if (!gameObjects.Contains(selectedObject))
				{
					DeselectObject(selectedObject, deselectReason);
					list2.Add(selectedObject);
					flag = true;
					deselectReason = ObjectDeselectReason.SetSelectedCall;
				}
			}
			foreach (GameObject gameObject in gameObjects)
			{
				if (!IsObjectSelected(gameObject) && CanSelectObject(gameObject, SelectRestrictFlags.None, selectReason))
				{
					SelectObject(gameObject, selectReason);
					list.Add(gameObject);
					flag = true;
					selectReason = ObjectSelectReason.SetSelectedCall;
				}
			}
			if (flag)
			{
				OnSelectionChanged(new ObjectSelectionChangedEventArgs(selectReason, list, deselectReason, list2));
				if (allowUndoRedo)
				{
					ObjectSelectionSnapshot objectSelectionSnapshot2 = new ObjectSelectionSnapshot();
					objectSelectionSnapshot2.Snapshot();
					new PostObjectSelectionChangedAction(objectSelectionSnapshot, objectSelectionSnapshot2).Execute();
				}
			}
		}

		public void ClearSelection(bool allowUndoRedo)
		{
			if (!CanBeModifiedByAPI() || NumSelectedObjects == 0)
			{
				return;
			}
			ObjectSelectionSnapshot objectSelectionSnapshot = new ObjectSelectionSnapshot();
			if (allowUndoRedo)
			{
				objectSelectionSnapshot.Snapshot();
			}
			ObjectDeselectReason deselectReason = ObjectDeselectReason.ClearSelectionCall;
			List<GameObject> selectedObjects = SelectedObjects;
			foreach (GameObject item in selectedObjects)
			{
				DeselectObject(item, deselectReason);
			}
			OnSelectionChanged(new ObjectSelectionChangedEventArgs(ObjectSelectReason.None, null, deselectReason, selectedObjects));
			if (allowUndoRedo)
			{
				ObjectSelectionSnapshot objectSelectionSnapshot2 = new ObjectSelectionSnapshot();
				objectSelectionSnapshot2.Snapshot();
				new PostObjectSelectionChangedAction(objectSelectionSnapshot, objectSelectionSnapshot2).Execute();
			}
		}

		public void Delete()
		{
			if (!CanBeDeleted())
			{
				return;
			}
			List<GameObject> list = new List<GameObject>(NumSelectedObjects);
			foreach (GameObject item in GameObjectEx.FilterParentsOnly(_selectedObjects))
			{
				if (Settings.IsObjectLayerDeletable(item.layer))
				{
					list.AddRange(item.GetAllChildrenAndSelf());
				}
			}
			if (list.Count == 0)
			{
				return;
			}
			ObjectSelectionSnapshot objectSelectionSnapshot = new ObjectSelectionSnapshot();
			objectSelectionSnapshot.Snapshot();
			ObjectDeselectReason deselectReason = ObjectDeselectReason.WillBeDeleted;
			foreach (GameObject item2 in list)
			{
				DeselectObject(item2, deselectReason);
			}
			OnSelectionChanged(new ObjectSelectionChangedEventArgs(ObjectSelectReason.None, null, deselectReason, list));
			_willBeDeleted = true;
			if (this.WillBeDeleted != null)
			{
				this.WillBeDeleted();
			}
			new DeleteSelectedObjectsAction(list, objectSelectionSnapshot).Execute();
			_willBeDeleted = false;
			if (this.Deleted != null)
			{
				this.Deleted();
			}
		}

		public void ForceDelete()
		{
			_grabSession.End();
			_gridSnapSession.End();
			_object2ObjectSnapSession.End();
			List<GameObject> list = new List<GameObject>();
			List<GameObject> list2 = GameObjectEx.FilterParentsOnly(_selectedObjects);
			foreach (GameObject item in list2)
			{
				list.AddRange(item.GetAllChildrenAndSelf());
			}
			ObjectDeselectReason deselectReason = ObjectDeselectReason.WillBeDeleted;
			foreach (GameObject item2 in list)
			{
				DeselectObject(item2, deselectReason);
			}
			OnSelectionChanged(new ObjectSelectionChangedEventArgs(ObjectSelectReason.None, null, deselectReason, list));
			_willBeDeleted = true;
			if (this.WillBeDeleted != null)
			{
				this.WillBeDeleted();
			}
			foreach (GameObject item3 in list2)
			{
				UnityEngine.Object.Destroy(item3);
			}
			_willBeDeleted = false;
			if (this.Deleted != null)
			{
				this.Deleted();
			}
		}

		public bool CanBeDeleted()
		{
			if (_isEnabled && !_willBeDeleted && !IsManipSessionActive && !_doingPreSelectCustomize && !_doingPreDeselectCustomize)
			{
				return NumSelectedObjects != 0;
			}
			return false;
		}

		public bool CanBeDuplicated()
		{
			if (_isEnabled && !_willBeDeleted && !IsManipSessionActive && (!_doingPreSelectCustomize & !_doingPreDeselectCustomize))
			{
				return NumSelectedObjects != 0;
			}
			return false;
		}

		public bool CanBeModifiedByAPI()
		{
			if (!_isEnabled || _willBeDeleted || _doingPreSelectCustomize || _doingPreDeselectCustomize || IsManipSessionActive || _firingSelectionChanged)
			{
				return false;
			}
			return true;
		}

		public ObjectSelectionDuplicationResult Duplicate()
		{
			ObjectSelectionDuplicationResult result = new ObjectSelectionDuplicationResult(new List<GameObject>());
			if (!CanBeDuplicated())
			{
				return result;
			}
			List<GameObject> list = new List<GameObject>();
			foreach (GameObject selectedObject in _selectedObjects)
			{
				if (_settings.IsObjectLayerDuplicatable(selectedObject.layer))
				{
					list.Add(selectedObject);
				}
			}
			if (list.Count == 0)
			{
				return result;
			}
			if (this.WillBeDuplicated != null)
			{
				this.WillBeDuplicated();
			}
			DuplicateObjectsAction duplicateObjectsAction = new DuplicateObjectsAction(list);
			duplicateObjectsAction.Execute();
			ObjectSelectionDuplicationResult result2 = new ObjectSelectionDuplicationResult(duplicateObjectsAction.DuplicateResult);
			if (this.Duplicated != null)
			{
				this.Duplicated(result2);
			}
			return result2;
		}

		public bool IsSelectionExactMatch(List<GameObject> gameObjectsToMatch)
		{
			if (gameObjectsToMatch == null)
			{
				if (NumSelectedObjects == 0)
				{
					return true;
				}
				return false;
			}
			if (NumSelectedObjects != gameObjectsToMatch.Count)
			{
				return false;
			}
			foreach (GameObject item in gameObjectsToMatch)
			{
				if (!IsObjectSelected(item))
				{
					return false;
				}
			}
			return true;
		}

		public bool IsObjectSelected(GameObject gameObject)
		{
			if (gameObject == null)
			{
				return false;
			}
			return _selectedObjects.Contains(gameObject);
		}

		public AABB GetWorldAABB()
		{
			if (NumSelectedObjects == 0)
			{
				return AABB.GetInvalid();
			}
			return ObjectBounds.CalcObjectCollectionWorldAABB(queryConfig: new ObjectBounds.QueryConfig
			{
				NoVolumeSize = Vector3Ex.FromValue(1E-05f),
				ObjectTypes = GameObjectTypeHelper.AllCombined
			}, gameObjectCollection: _selectedObjects);
		}

		public void Update_SystemCall()
		{
			if (!Settings.EnableCyclicalClickSelect)
			{
				_cyclicalClickSelectInfo.LastPickedObject = null;
				_cyclicalClickSelectInfo.LastSelectedIndex = -1;
			}
			RemoveNullAndInactiveObjectRefs();
			if (!_isEnabled)
			{
				return;
			}
			_multiSelectShape.MinSize = Settings.MinMultiSelectSize;
			if (!_multiSelectShape.IsVisible)
			{
				if (!IsManipSessionActive || IsGrabSessionActive)
				{
					_grabSession.Update(_selectedObjects);
				}
				if (!IsManipSessionActive || IsGridSnapSessionActive)
				{
					_gridSnapSession.Update(_selectedObjects);
				}
				if (!IsManipSessionActive || IsObject2ObjectSnapSessionActive)
				{
					_object2ObjectSnapSession.Update(_selectedObjects);
				}
			}
			if (!IsManipSessionActive)
			{
				IInputDevice device = MonoSingleton<RTInputDevice>.Get.Device;
				if (device.WasButtonPressedInCurrentFrame(_objectPickDeviceBtnIndex))
				{
					OnInputDevicePickButtonDown();
				}
				else if (device.WasButtonReleasedInCurrentFrame(_objectPickDeviceBtnIndex))
				{
					OnInputDevicePickButtonUp();
				}
				if (device.WasMoved())
				{
					OnInputDeviceWasMoved();
				}
				if (!_multiSelectShape.IsVisible)
				{
					if (Hotkeys.DeleteSelected.IsActiveInFrame())
					{
						Delete();
					}
					else if (Hotkeys.DuplicateSelection.IsActiveInFrame())
					{
						Duplicate();
					}
					else if (Hotkeys.FocusCameraOnSelection.IsActiveInFrame())
					{
						MonoSingleton<RTFocusCamera>.Get.Focus(GetWorldAABB());
					}
					else if (RotationHotkeys.RotateAroundX.IsActiveInFrame())
					{
						Rotate(Axis.X, RotationSettings.KeyRotationSettings.XRotationStep, RotationSettings.RotationPivot);
					}
					else if (RotationHotkeys.RotateAroundY.IsActiveInFrame())
					{
						Rotate(Axis.Y, RotationSettings.KeyRotationSettings.YRotationStep, RotationSettings.RotationPivot);
					}
					else if (RotationHotkeys.RotateAroundZ.IsActiveInFrame())
					{
						Rotate(Axis.Z, RotationSettings.KeyRotationSettings.ZRotationStep, RotationSettings.RotationPivot);
					}
					else if (RotationHotkeys.SetRotationToIdentity.IsActiveInFrame())
					{
						SetRotation(Quaternion.identity);
					}
				}
			}
			else if (MonoSingleton<RTInputDevice>.Get.Device.WasButtonPressedInCurrentFrame(_objectPickDeviceBtnIndex))
			{
				if (ActiveManipSession == ObjectSelectionManipSession.Grab)
				{
					_grabSession.End();
				}
				else if (ActiveManipSession == ObjectSelectionManipSession.Object2ObjectSnap)
				{
					_object2ObjectSnapSession.End();
				}
			}
			else if (ActiveManipSession != ObjectSelectionManipSession.Grab)
			{
				if (RotationHotkeys.RotateAroundX.IsActiveInFrame())
				{
					Rotate(Axis.X, RotationSettings.KeyRotationSettings.XRotationStep, RotationSettings.RotationPivot);
				}
				else if (RotationHotkeys.RotateAroundY.IsActiveInFrame())
				{
					Rotate(Axis.Y, RotationSettings.KeyRotationSettings.YRotationStep, RotationSettings.RotationPivot);
				}
				else if (RotationHotkeys.RotateAroundZ.IsActiveInFrame())
				{
					Rotate(Axis.Z, RotationSettings.KeyRotationSettings.ZRotationStep, RotationSettings.RotationPivot);
				}
				else if (RotationHotkeys.SetRotationToIdentity.IsActiveInFrame())
				{
					SetRotation(Quaternion.identity);
				}
			}
			else if (RotationHotkeys.SetRotationToIdentity.IsActiveInFrame())
			{
				SetRotation(Quaternion.identity);
			}
		}

		public void Render_SystemCall()
		{
			if (!_isEnabled)
			{
				return;
			}
			Camera current = Camera.current;
			if (IsRenderIgnoreCamera(current))
			{
				return;
			}
			if (current == MonoSingleton<RTFocusCamera>.Get.TargetCamera)
			{
				_multiSelectShape.Render(LookAndFeel.SelectionRectFillColor, LookAndFeel.SelectionRectBorderColor, current);
			}
			if (LookAndFeel.DrawHighlight && !IsManipSessionActive)
			{
				Material simpleColor = Singleton<MaterialPool>.Get.SimpleColor;
				simpleColor.SetColor(LookAndFeel.SelectionBoxBorderColor);
				simpleColor.SetZWriteEnabled(enabled: false);
				simpleColor.SetZTestEnabled(enabled: true);
				simpleColor.SetPass(0);
				ObjectBounds.QueryConfig queryConfig = new ObjectBounds.QueryConfig
				{
					NoVolumeSize = Vector3Ex.FromValue(0f),
					ObjectTypes = (GameObjectType.Mesh | GameObjectType.Terrain | GameObjectType.Sprite)
				};
				if (LookAndFeel.SelBoxRenderMode != SelectionBoxRenderMode.SelectionVolume)
				{
					bool flag = LookAndFeel.SelBoxRenderMode == SelectionBoxRenderMode.FromParentToBottom;
					List<GameObject> list = _selectedObjects;
					if (flag)
					{
						list = GameObjectEx.FilterParentsOnly(list);
					}
					if (list.Count == 0)
					{
						return;
					}
					foreach (GameObject item in list)
					{
						OBB box = (flag ? ObjectBounds.CalcHierarchyWorldOBB(item, queryConfig) : ObjectBounds.CalcWorldOBB(item, queryConfig));
						if (box.IsValid)
						{
							box.Inflate(LookAndFeel.SelectionBoxInflateAmount);
							if (LookAndFeel.SelBoxBorderStyle == SelectionBoxBorderStyle.FullWire)
							{
								GraphicsEx.DrawWireBox(box);
							}
							else
							{
								GraphicsEx.DrawWireCornerBox(box, LookAndFeel.WireCornerLinePercentage);
							}
						}
					}
				}
				else
				{
					AABB aabb = AABB.GetInvalid();
					foreach (GameObject selectedObject in _selectedObjects)
					{
						AABB aABB = ObjectBounds.CalcWorldAABB(selectedObject, queryConfig);
						if (aABB.IsValid)
						{
							if (aabb.IsValid)
							{
								aabb.Encapsulate(aABB);
							}
							else
							{
								aabb = aABB;
							}
						}
					}
					if (aabb.IsValid)
					{
						aabb.Inflate(LookAndFeel.SelectionBoxInflateAmount);
						if (LookAndFeel.SelBoxBorderStyle == SelectionBoxBorderStyle.FullWire)
						{
							GraphicsEx.DrawWireBox(new OBB(aabb));
						}
						else
						{
							GraphicsEx.DrawWireCornerBox(new OBB(aabb), LookAndFeel.WireCornerLinePercentage);
						}
					}
				}
			}
			if (current == MonoSingleton<RTFocusCamera>.Get.TargetCamera)
			{
				_grabSession.Render();
				_gridSnapSession.Render();
			}
		}

		private void OnInputDevicePickButtonDown()
		{
			if (!MonoSingleton<RTScene>.Get.IsAnySceneEntityHovered() && MonoSingleton<RTFocusCamera>.Get.IsViewportHoveredByDevice() && Settings.CanMultiSelect)
			{
				YesNoAnswer yesNoAnswer = new YesNoAnswer();
				if (this.CanMultiSelectDeselect != null)
				{
					this.CanMultiSelectDeselect(yesNoAnswer);
				}
				if (yesNoAnswer.HasOnlyYes)
				{
					Vector2 vector = MonoSingleton<RTInputDevice>.Get.Device.GetPositionYAxisUp();
					_multiSelectShape.IsVisible = true;
					_multiSelectShape.SetEnclosingRectTopLeftPoint(vector);
					_multiSelectShape.SetEnclosingRectBottomRightPoint(vector);
					_multiSelectPreChangeSnapshot.Snapshot();
					_wasSelectionChangedViaMultiSelectShape = false;
				}
			}
		}

		private void OnInputDevicePickButtonUp()
		{
			_multiSelectShape.IsVisible = false;
			if (_wasSelectionChangedViaMultiSelectShape)
			{
				ObjectSelectionSnapshot objectSelectionSnapshot = new ObjectSelectionSnapshot();
				objectSelectionSnapshot.Snapshot();
				new PostObjectSelectionChangedAction(_multiSelectPreChangeSnapshot, objectSelectionSnapshot).Execute();
				_wasSelectionChangedViaMultiSelectShape = false;
			}
			else if (!MonoSingleton<RTScene>.Get.IsAnySceneEntityHovered() && MonoSingleton<RTFocusCamera>.Get.IsViewportHoveredByDevice() && Settings.CanClickSelect && (!Settings.CanMultiSelect || !Hotkeys.MultiDeselect.IsActive()))
			{
				YesNoAnswer yesNoAnswer = new YesNoAnswer();
				if (this.CanClickSelectDeselect != null)
				{
					this.CanClickSelectDeselect(yesNoAnswer);
				}
				if (yesNoAnswer.HasOnlyYes)
				{
					PerformClickSelect();
				}
			}
		}

		private void OnInputDeviceWasMoved()
		{
			if (_multiSelectShape.IsVisible && Settings.CanMultiSelect && !MonoSingleton<RTScene>.Get.IsAnyUIElementHovered())
			{
				_multiSelectShape.SetEnclosingRectBottomRightPoint(MonoSingleton<RTInputDevice>.Get.Device.GetPositionYAxisUp());
				PerformMultiSelect();
			}
		}

		private void PerformMultiSelect()
		{
			ObjectBounds.QueryConfig boundsQConfig = default(ObjectBounds.QueryConfig);
			boundsQConfig.ObjectTypes = GameObjectTypeHelper.AllCombined;
			boundsQConfig.NoVolumeSize = Vector3Ex.FromValue(1E-05f);
			List<GameObject> visibleObjects = MonoSingleton<RTFocusCamera>.Get.GetVisibleObjects();
			visibleObjects = _multiSelectShape.GetOverlappedObjects(visibleObjects, MonoSingleton<RTFocusCamera>.Get.TargetCamera, boundsQConfig, Settings.MultiSelectOverlapMode);
			bool flag = false;
			ObjectSelectReason selectReason = ObjectSelectReason.None;
			ObjectDeselectReason deselectReason = ObjectDeselectReason.None;
			List<GameObject> list = new List<GameObject>();
			List<GameObject> list2 = new List<GameObject>();
			if (Hotkeys.MultiDeselect.IsActive())
			{
				visibleObjects = DoPreDeselectCustomize(visibleObjects, ObjectDeselectReason.MultiDeselect);
				foreach (GameObject item in visibleObjects)
				{
					if (IsObjectSelected(item))
					{
						deselectReason = ObjectDeselectReason.MultiDeselect;
						DeselectObject(item, deselectReason);
						list2.Add(item);
						flag = true;
					}
				}
			}
			else if (Hotkeys.AppendToSelection.IsActive())
			{
				List<GameObject> list3 = FilterByRestrictions(visibleObjects, SelectRestrictFlags.All, ObjectSelectReason.MultiSelectAppend);
				ObjectPreSelectCustomizeInfo objectPreSelectCustomizeInfo = DoPreSelectCustomize(list3, ObjectSelectReason.MultiSelectAppend);
				if (objectPreSelectCustomizeInfo != null)
				{
					list3 = objectPreSelectCustomizeInfo.ToBeSelected;
				}
				foreach (GameObject item2 in list3)
				{
					if (!IsObjectSelected(item2))
					{
						selectReason = ObjectSelectReason.MultiSelectAppend;
						SelectObject(item2, selectReason);
						list.Add(item2);
						flag = true;
					}
				}
			}
			else
			{
				List<GameObject> selectedObjects = SelectedObjects;
				selectedObjects.RemoveAll((GameObject item) => _multiSelectShape.OverlapsObject(item, MonoSingleton<RTFocusCamera>.Get.TargetCamera, boundsQConfig, Settings.MultiSelectOverlapMode));
				selectedObjects = DoPreDeselectCustomize(selectedObjects, ObjectDeselectReason.MultiSelectNotOverlapped);
				foreach (GameObject item3 in selectedObjects)
				{
					if (IsObjectSelected(item3))
					{
						deselectReason = ObjectDeselectReason.MultiSelectNotOverlapped;
						DeselectObject(item3, deselectReason);
						list2.Add(item3);
						flag = true;
					}
				}
				List<GameObject> list4 = FilterByRestrictions(visibleObjects, SelectRestrictFlags.All, ObjectSelectReason.MultiSelect);
				ObjectPreSelectCustomizeInfo objectPreSelectCustomizeInfo2 = DoPreSelectCustomize(list4, ObjectSelectReason.MultiSelect);
				if (objectPreSelectCustomizeInfo2 != null)
				{
					list4 = objectPreSelectCustomizeInfo2.ToBeSelected;
				}
				foreach (GameObject item4 in list4)
				{
					if (!IsObjectSelected(item4))
					{
						selectReason = ObjectSelectReason.MultiSelect;
						SelectObject(item4, selectReason);
						list.Add(item4);
						flag = true;
					}
				}
			}
			if (list.Count == 0)
			{
				selectReason = ObjectSelectReason.None;
			}
			if (list2.Count == 0)
			{
				deselectReason = ObjectDeselectReason.None;
			}
			if (flag)
			{
				_wasSelectionChangedViaMultiSelectShape = true;
				OnSelectionChanged(new ObjectSelectionChangedEventArgs(selectReason, list, deselectReason, list2));
			}
		}

		private void PerformClickSelect()
		{
			bool flag = false;
			ObjectSelectReason selectReason = ObjectSelectReason.None;
			ObjectDeselectReason deselectReason = ObjectDeselectReason.None;
			List<GameObject> list = new List<GameObject>();
			List<GameObject> list2 = new List<GameObject>();
			ObjectSelectionSnapshot objectSelectionSnapshot = new ObjectSelectionSnapshot();
			objectSelectionSnapshot.Snapshot();
			Ray ray = MonoSingleton<RTInputDevice>.Get.Device.GetRay(MonoSingleton<RTFocusCamera>.Get.TargetCamera);
			List<GameObjectRayHit> objectHits = MonoSingleton<RTScene>.Get.RaycastAllObjectsSorted(ray, SceneRaycastPrecision.BestFit);
			List<GameObjectRayHit> list3 = FilterByRestrictions(objectHits, SelectRestrictFlags.All);
			if (list3.Count == 0)
			{
				_cyclicalClickSelectInfo.LastSelectedIndex = -1;
			}
			if (list3.Count != 0)
			{
				GameObject hitObject = list3[0].HitObject;
				if (Settings.EnableCyclicalClickSelect)
				{
					if (_cyclicalClickSelectInfo.LastSelectedIndex < 0 || _cyclicalClickSelectInfo.LastPickedObject != list3[0].HitObject)
					{
						_cyclicalClickSelectInfo.LastSelectedIndex = 0;
					}
					else
					{
						_cyclicalClickSelectInfo.LastSelectedIndex++;
						_cyclicalClickSelectInfo.LastSelectedIndex %= list3.Count;
					}
					_cyclicalClickSelectInfo.LastPickedObject = list3[0].HitObject;
					hitObject = list3[_cyclicalClickSelectInfo.LastSelectedIndex].HitObject;
				}
				if (Hotkeys.AppendToSelection.IsActive())
				{
					hitObject = list3[0].HitObject;
					if (IsObjectSelected(hitObject))
					{
						deselectReason = ObjectDeselectReason.CickAppendAlreadySelected;
						foreach (GameObject item in DoPreDeselectCustomize(new List<GameObject> { hitObject }, deselectReason))
						{
							if (IsObjectSelected(item))
							{
								list2.Add(item);
								DeselectObject(item, deselectReason);
								flag = true;
							}
						}
					}
					else
					{
						List<GameObject> list4 = new List<GameObject> { hitObject };
						ObjectPreSelectCustomizeInfo objectPreSelectCustomizeInfo = DoPreSelectCustomize(list4, ObjectSelectReason.ClickAppend);
						if (objectPreSelectCustomizeInfo != null)
						{
							list4 = objectPreSelectCustomizeInfo.ToBeSelected;
						}
						foreach (GameObject item2 in list4)
						{
							if (!IsObjectSelected(item2))
							{
								selectReason = ObjectSelectReason.ClickAppend;
								SelectObject(item2, selectReason);
								list.Add(item2);
								flag = true;
							}
						}
					}
				}
				else
				{
					List<GameObject> list5 = new List<GameObject> { hitObject };
					ObjectPreSelectCustomizeInfo objectPreSelectCustomizeInfo2 = DoPreSelectCustomize(list5, ObjectSelectReason.Click);
					if (objectPreSelectCustomizeInfo2 != null)
					{
						list5 = objectPreSelectCustomizeInfo2.ToBeSelected;
					}
					if (list5.Count == 0)
					{
						selectReason = ObjectSelectReason.None;
						if (NumSelectedObjects != 0)
						{
							flag = true;
							deselectReason = ObjectDeselectReason.ClickAir;
							ClearSelection(deselectReason);
						}
					}
					else
					{
						selectReason = ObjectSelectReason.None;
						if (NumSelectedObjects != 0)
						{
							flag = true;
							deselectReason = ObjectDeselectReason.ClickSelectOther;
							ClearSelection(deselectReason);
						}
						foreach (GameObject item3 in list5)
						{
							if (!IsObjectSelected(item3))
							{
								selectReason = ObjectSelectReason.Click;
								SelectObject(item3, selectReason);
								list.Add(item3);
								flag = true;
							}
						}
					}
				}
			}
			else if (!Hotkeys.MultiDeselect.IsActive() && !Hotkeys.AppendToSelection.IsActive() && NumSelectedObjects != 0)
			{
				list2 = new List<GameObject>(_selectedObjects);
				deselectReason = ObjectDeselectReason.ClickAir;
				flag = true;
				ClearSelection(deselectReason);
			}
			if (flag)
			{
				OnSelectionChanged(new ObjectSelectionChangedEventArgs(selectReason, list, deselectReason, list2));
				ObjectSelectionSnapshot objectSelectionSnapshot2 = new ObjectSelectionSnapshot();
				objectSelectionSnapshot2.Snapshot();
				new PostObjectSelectionChangedAction(objectSelectionSnapshot, objectSelectionSnapshot2).Execute();
			}
		}

		private ObjectPreSelectCustomizeInfo DoPreSelectCustomize(List<GameObject> toBeSelected, ObjectSelectReason selectReason)
		{
			if (this.PreSelectCustomize == null || toBeSelected == null || toBeSelected.Count == 0)
			{
				return null;
			}
			_doingPreSelectCustomize = true;
			ObjectPreSelectCustomizeInfo objectPreSelectCustomizeInfo = new ObjectPreSelectCustomizeInfo(toBeSelected, selectReason);
			this.PreSelectCustomize(objectPreSelectCustomizeInfo, toBeSelected);
			_doingPreSelectCustomize = false;
			return objectPreSelectCustomizeInfo;
		}

		private List<GameObject> DoPreDeselectCustomize(List<GameObject> toBeDeselected, ObjectDeselectReason deselectReason)
		{
			if (this.PreDeselectCustomize == null || toBeDeselected == null || toBeDeselected.Count == 0)
			{
				return toBeDeselected;
			}
			_doingPreDeselectCustomize = true;
			ObjectPreDeselectCustomizeInfo objectPreDeselectCustomizeInfo = new ObjectPreDeselectCustomizeInfo(toBeDeselected, deselectReason);
			this.PreDeselectCustomize(objectPreDeselectCustomizeInfo, toBeDeselected);
			_doingPreDeselectCustomize = false;
			return objectPreDeselectCustomizeInfo.ToBeDeselected;
		}

		private List<GameObject> FilterByRestrictions(IEnumerable<GameObject> gameObjects, SelectRestrictFlags restrictFlags, ObjectSelectReason selectReason)
		{
			List<GameObject> list = new List<GameObject>(10);
			foreach (GameObject gameObject in gameObjects)
			{
				if (CanSelectObject(gameObject, restrictFlags, selectReason))
				{
					list.Add(gameObject);
				}
			}
			return list;
		}

		private List<GameObjectRayHit> FilterByRestrictions(List<GameObjectRayHit> objectHits, SelectRestrictFlags restrictFlags)
		{
			List<GameObjectRayHit> list = new List<GameObjectRayHit>(10);
			foreach (GameObjectRayHit objectHit in objectHits)
			{
				if (CanSelectObject(objectHit.HitObject, restrictFlags, ObjectSelectReason.None))
				{
					list.Add(objectHit);
				}
			}
			return list;
		}

		private bool CanSelectObject(GameObject gameObject, SelectRestrictFlags restrictFlags, ObjectSelectReason selectReason)
		{
			if (gameObject == null || !gameObject.activeInHierarchy)
			{
				return false;
			}
			Camera component = gameObject.GetComponent<Camera>();
			if (component != null && (!Settings.IsCameraSelectable(component) || MonoSingleton<RTFocusCamera>.Get.TargetCamera == component))
			{
				return false;
			}
			if ((restrictFlags & SelectRestrictFlags.ObjectLayer) != SelectRestrictFlags.None && !Settings.IsObjectLayerSelectable(gameObject.layer))
			{
				return false;
			}
			if ((restrictFlags & SelectRestrictFlags.ObjectType) != SelectRestrictFlags.None && !Settings.IsObjectTypeSelectable(gameObject.GetGameObjectType()))
			{
				return false;
			}
			if ((restrictFlags & SelectRestrictFlags.Object) != SelectRestrictFlags.None && !Settings.IsObjectSelectable(gameObject))
			{
				return false;
			}
			if ((restrictFlags & SelectRestrictFlags.SelectionListener) != SelectRestrictFlags.None)
			{
				IRTObjectSelectionListener component2 = gameObject.GetComponent<IRTObjectSelectionListener>();
				if (component2 != null && !component2.OnCanBeSelected(new ObjectSelectEventArgs(selectReason)))
				{
					return false;
				}
			}
			return true;
		}

		private void SelectObject(GameObject gameObject, ObjectSelectReason selectReason)
		{
			_selectedObjects.Add(gameObject);
			gameObject.GetComponent<IRTObjectSelectionListener>()?.OnSelected(new ObjectSelectEventArgs(selectReason));
		}

		private void DeselectObject(GameObject gameObject, ObjectDeselectReason deselectReason)
		{
			_selectedObjects.Remove(gameObject);
			gameObject.GetComponent<IRTObjectSelectionListener>()?.OnDeselected(new ObjectDeselectEventArgs(deselectReason));
		}

		private void ClearSelection(ObjectDeselectReason deselectReason)
		{
			if (NumSelectedObjects == 0)
			{
				return;
			}
			List<GameObject> selectedObjects = SelectedObjects;
			_selectedObjects.Clear();
			ObjectDeselectEventArgs deselectArgs = new ObjectDeselectEventArgs(deselectReason);
			foreach (GameObject item in selectedObjects)
			{
				item.GetComponent<IRTObjectSelectionListener>()?.OnDeselected(deselectArgs);
			}
		}

		private void OnSelectionChanged(ObjectSelectionChangedEventArgs args)
		{
			if (this.Changed != null)
			{
				_firingSelectionChanged = true;
				this.Changed(args);
				_firingSelectionChanged = false;
			}
		}

		private void RemoveNullAndInactiveObjectRefs()
		{
			List<GameObject> list = _selectedObjects.FindAll((GameObject item) => item != null && !item.activeInHierarchy);
			_selectedObjects.RemoveAll((GameObject item) => item == null || !item.activeInHierarchy);
			Settings.RemoveNullObjectRefs();
			if (list.Count != 0)
			{
				OnSelectionChanged(new ObjectSelectionChangedEventArgs(ObjectSelectReason.None, null, ObjectDeselectReason.Inactive, list));
			}
		}

		private void OnUndoEnd(IUndoRedoAction action)
		{
			if (action is PostObjectSelectionChangedAction)
			{
				PostObjectSelectionChangedAction postObjectSelectionChangedAction = action as PostObjectSelectionChangedAction;
				HandleUndoRedo(postObjectSelectionChangedAction.PreChangeSnapshot, isUndo: true);
			}
			else if (action is DeleteSelectedObjectsAction)
			{
				DeleteSelectedObjectsAction deleteSelectedObjectsAction = action as DeleteSelectedObjectsAction;
				HandleUndoRedo(deleteSelectedObjectsAction.PreDeleteSnapshot, isUndo: true);
			}
		}

		private void OnRedoEnd(IUndoRedoAction action)
		{
			if (action is PostObjectSelectionChangedAction)
			{
				PostObjectSelectionChangedAction postObjectSelectionChangedAction = action as PostObjectSelectionChangedAction;
				HandleUndoRedo(postObjectSelectionChangedAction.PostChangeSnapshot, isUndo: false);
			}
			else if (action is DeleteSelectedObjectsAction)
			{
				DeleteSelectedObjectsAction deleteSelectedObjectsAction = action as DeleteSelectedObjectsAction;
				HandleUndoRedo(deleteSelectedObjectsAction.PostDeleteSnapshot, isUndo: false);
			}
		}

		private void HandleUndoRedo(ObjectSelectionSnapshot undoRedoSnapshot, bool isUndo)
		{
			if (!_isEnabled)
			{
				return;
			}
			bool flag = false;
			ObjectSelectReason selectReason = (isUndo ? ObjectSelectReason.Undo : ObjectSelectReason.Redo);
			ObjectDeselectReason deselectReason = (isUndo ? ObjectDeselectReason.Undo : ObjectDeselectReason.Redo);
			List<GameObject> list = new List<GameObject>();
			List<GameObject> list2 = new List<GameObject>();
			foreach (GameObject selectedObject in SelectedObjects)
			{
				DeselectObject(selectedObject, deselectReason);
				list2.Add(selectedObject);
				flag = true;
			}
			foreach (GameObject snapshotObject in undoRedoSnapshot.SnapshotObjects)
			{
				SelectObject(snapshotObject, selectReason);
				list.Add(snapshotObject);
				flag = true;
			}
			if (flag)
			{
				OnSelectionChanged(new ObjectSelectionChangedEventArgs(selectReason, list, deselectReason, list2, undoRedoSnapshot));
			}
		}

		private void OnGrabSessionBegin()
		{
			_activeManipSession = ObjectSelectionManipSession.Grab;
			if (this.ManipSessionBegin != null)
			{
				this.ManipSessionBegin(_activeManipSession);
			}
		}

		private void OnGrabSessionEnd()
		{
			_activeManipSession = ObjectSelectionManipSession.None;
			if (this.ManipSessionEnd != null)
			{
				this.ManipSessionEnd(ObjectSelectionManipSession.Grab);
			}
		}

		private void OnGridSnapSessionBegin()
		{
			_activeManipSession = ObjectSelectionManipSession.GridSnap;
			if (this.ManipSessionBegin != null)
			{
				this.ManipSessionBegin(_activeManipSession);
			}
		}

		private void OnGridSnapSessionEnd()
		{
			_activeManipSession = ObjectSelectionManipSession.None;
			if (this.ManipSessionEnd != null)
			{
				this.ManipSessionEnd(ObjectSelectionManipSession.GridSnap);
			}
		}

		private void OnObject2ObjectSnapSessionBegin()
		{
			_activeManipSession = ObjectSelectionManipSession.Object2ObjectSnap;
			if (this.ManipSessionBegin != null)
			{
				this.ManipSessionBegin(_activeManipSession);
			}
		}

		private void OnObject2ObjectSnapSessionEnd()
		{
			_activeManipSession = ObjectSelectionManipSession.None;
			if (this.ManipSessionEnd != null)
			{
				this.ManipSessionEnd(ObjectSelectionManipSession.Object2ObjectSnap);
			}
		}
	}
}
