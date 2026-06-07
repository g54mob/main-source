using System;
using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class RTObjectSelectionGizmos : MonoSingleton<RTObjectSelectionGizmos>, IObjectCollectionGizmoController
	{
		private class ObjectSelectionGizmo
		{
			private int _id;

			private Gizmo _gizmo;

			private BoxGizmo _boxScaleGizmo;

			private ObjectTransformGizmo _transformGizmo;

			private ObjectExtrudeGizmo _extrudeGizmo;

			private bool _isUsable = true;

			public int Id => _id;

			public Gizmo Gizmo => _gizmo;

			public BoxGizmo BoxScaleGizmo => _boxScaleGizmo;

			public bool IsBoxScaleGizmo => _boxScaleGizmo != null;

			public ObjectTransformGizmo TransformGizmo => _transformGizmo;

			public bool IsTransformGizmo => _transformGizmo != null;

			public ObjectExtrudeGizmo ExtrudeGizmo => _extrudeGizmo;

			public bool IsExtrudeGizmo => _extrudeGizmo != null;

			public bool IsUsable
			{
				get
				{
					return _isUsable;
				}
				set
				{
					_isUsable = value;
				}
			}

			public ObjectSelectionGizmo(int id, Gizmo gizmo)
			{
				_id = id;
				_gizmo = gizmo;
				_boxScaleGizmo = gizmo.GetFirstBehaviourOfType<BoxGizmo>();
				_transformGizmo = gizmo.GetFirstBehaviourOfType<ObjectTransformGizmo>();
				_extrudeGizmo = gizmo.GetFirstBehaviourOfType<ObjectExtrudeGizmo>();
				_isUsable = true;
			}
		}

		[SerializeField]
		private EditorToolbar _mainToolbar = new EditorToolbar(new EditorToolbarTab[7]
		{
			new EditorToolbarTab("General", "Allows you to change general gizmo settings."),
			new EditorToolbarTab("Move gizmo", "Allows you to change move gizmo settings."),
			new EditorToolbarTab("Rotation gizmo", "Allows you to change rotation settings."),
			new EditorToolbarTab("Scale gizmo", "Allows you to change scale gizmo settings."),
			new EditorToolbarTab("Box scale gizmo", "Allows you to change box scale gizmo settings."),
			new EditorToolbarTab("Universal gizmo", "Allows you to change universal gizmo settings."),
			new EditorToolbarTab("Extrude gizmo", "Allows you to change extrude gizmo settings.")
		}, 4, Color.green);

		[SerializeField]
		private UniversalGizmoConfig _universalGizmoConfig = new UniversalGizmoConfig();

		private GizmoCollectionEnabledStateSnapshot _gizmosEnabledStateSnapshot = new GizmoCollectionEnabledStateSnapshot();

		private List<ObjectSelectionGizmo> _allGizmos = new List<ObjectSelectionGizmo>();

		private List<ObjectTransformGizmo> _objectTransformGizmos = new List<ObjectTransformGizmo>();

		private int _workGizmoId;

		private ObjectSelectionGizmo _workGizmo;

		private bool _areGizmosVisible = true;

		private GizmoSpace _transformSpace;

		private GameObject _pivotObject;

		private IEnumerable<GameObject> _targetObjectCollection;

		[SerializeField]
		private ObjectSelectionGizmosHotkeys _hotkeys = new ObjectSelectionGizmosHotkeys();

		[SerializeField]
		private MoveGizmoSettings2D _moveGizmoSettings2D = new MoveGizmoSettings2D
		{
			IsExpanded = false
		};

		[SerializeField]
		private MoveGizmoSettings3D _moveGizmoSettings3D = new MoveGizmoSettings3D
		{
			IsExpanded = false
		};

		[SerializeField]
		private MoveGizmoLookAndFeel2D _moveGizmoLookAndFeel2D = new MoveGizmoLookAndFeel2D
		{
			IsExpanded = false
		};

		[SerializeField]
		private MoveGizmoLookAndFeel3D _moveGizmoLookAndFeel3D = new MoveGizmoLookAndFeel3D
		{
			IsExpanded = false
		};

		[SerializeField]
		private MoveGizmoHotkeys _moveGizmoHotkeys = new MoveGizmoHotkeys
		{
			IsExpanded = false
		};

		[SerializeField]
		private ObjectTransformGizmoSettings _objectMoveGizmoSettings = new ObjectTransformGizmoSettings
		{
			IsExpanded = false
		};

		[SerializeField]
		private RotationGizmoSettings3D _rotationGizmoSettings3D = new RotationGizmoSettings3D
		{
			IsExpanded = false
		};

		[SerializeField]
		private RotationGizmoLookAndFeel3D _rotationGizmoLookAndFeel3D = new RotationGizmoLookAndFeel3D
		{
			IsExpanded = false
		};

		[SerializeField]
		private RotationGizmoHotkeys _rotationGizmoHotkeys = new RotationGizmoHotkeys
		{
			IsExpanded = false
		};

		[SerializeField]
		private ObjectTransformGizmoSettings _objectRotationGizmoSettings = new ObjectTransformGizmoSettings
		{
			IsExpanded = false
		};

		[SerializeField]
		private ScaleGizmoSettings3D _scaleGizmoSettings3D = new ScaleGizmoSettings3D
		{
			IsExpanded = false
		};

		[SerializeField]
		private ScaleGizmoLookAndFeel3D _scaleGizmoLookAndFeel3D = new ScaleGizmoLookAndFeel3D
		{
			IsExpanded = false
		};

		[SerializeField]
		private ScaleGizmoHotkeys _scaleGizmoHotkeys = new ScaleGizmoHotkeys
		{
			IsExpanded = false
		};

		[SerializeField]
		private ObjectTransformGizmoSettings _objectScaleGizmoSettings = new ObjectTransformGizmoSettings
		{
			IsExpanded = false
		};

		[SerializeField]
		private UniversalGizmoSettings2D _universalGizmoSettings2D = new UniversalGizmoSettings2D
		{
			IsExpanded = false
		};

		[SerializeField]
		private UniversalGizmoSettings3D _universalGizmoSettings3D = new UniversalGizmoSettings3D
		{
			IsExpanded = false
		};

		[SerializeField]
		private UniversalGizmoLookAndFeel2D _universalGizmoLookAndFeel2D = new UniversalGizmoLookAndFeel2D
		{
			IsExpanded = false
		};

		[SerializeField]
		private UniversalGizmoLookAndFeel3D _universalGizmoLookAndFeel3D = new UniversalGizmoLookAndFeel3D
		{
			IsExpanded = false
		};

		[SerializeField]
		private UniversalGizmoHotkeys _universalGizmoHotkeys = new UniversalGizmoHotkeys
		{
			IsExpanded = false
		};

		[SerializeField]
		private ObjectTransformGizmoSettings _objectUniversalGizmoSettings = new ObjectTransformGizmoSettings
		{
			IsExpanded = false
		};

		[SerializeField]
		private BoxGizmoSettings3D _boxScaleGizmoSettings3D = new BoxGizmoSettings3D
		{
			IsExpanded = false
		};

		[SerializeField]
		private BoxGizmoLookAndFeel3D _boxScaleGizmoLookAndFeel3D = new BoxGizmoLookAndFeel3D
		{
			IsExpanded = false
		};

		[SerializeField]
		private BoxGizmoHotkeys _boxScaleGizmoHotkeys = new BoxGizmoHotkeys
		{
			IsExpanded = false
		};

		[SerializeField]
		private ObjectExtrudeGizmoLookAndFeel3D _extrudeGizmoLookAndFeel3D = new ObjectExtrudeGizmoLookAndFeel3D
		{
			IsExpanded = false
		};

		[SerializeField]
		private ObjectExtrudeGizmoHotkeys _extrudeGizmoHotkeys = new ObjectExtrudeGizmoHotkeys
		{
			IsExpanded = false
		};

		public bool AreGizmosVisible => _areGizmosVisible;

		public GameObject PivotObject => _pivotObject;

		public Gizmo WorkGizmo => _workGizmo.Gizmo;

		public ObjectSelectionGizmosHotkeys Hotkeys => _hotkeys;

		public MoveGizmoSettings2D MoveGizmoSettings2D => _moveGizmoSettings2D;

		public MoveGizmoSettings3D MoveGizmoSettings3D => _moveGizmoSettings3D;

		public MoveGizmoLookAndFeel2D MoveGizmoLookAndFeel2D => _moveGizmoLookAndFeel2D;

		public MoveGizmoLookAndFeel3D MoveGizmoLookAndFeel3D => _moveGizmoLookAndFeel3D;

		public MoveGizmoHotkeys MoveGizmoHotkeys => _moveGizmoHotkeys;

		public ObjectTransformGizmoSettings ObjectMoveGizmoSettings => _objectMoveGizmoSettings;

		public RotationGizmoSettings3D RotationGizmoSettings3D => _rotationGizmoSettings3D;

		public RotationGizmoLookAndFeel3D RotationGizmoLookAndFeel3D => _rotationGizmoLookAndFeel3D;

		public RotationGizmoHotkeys RotationGizmoHotkeys => _rotationGizmoHotkeys;

		public ObjectTransformGizmoSettings ObjectRotationGizmoSettings => _objectRotationGizmoSettings;

		public ScaleGizmoSettings3D ScaleGizmoSettings3D => _scaleGizmoSettings3D;

		public ScaleGizmoLookAndFeel3D ScaleGizmoLookAndFeel3D => _scaleGizmoLookAndFeel3D;

		public ScaleGizmoHotkeys ScaleGizmoHotkeys => _scaleGizmoHotkeys;

		public ObjectTransformGizmoSettings ObjectScaleGizmoSettings => _objectScaleGizmoSettings;

		public UniversalGizmoSettings2D UniversalGizmoSettings2D => _universalGizmoSettings2D;

		public UniversalGizmoSettings3D UniversalGizmoSettings3D => _universalGizmoSettings3D;

		public UniversalGizmoLookAndFeel2D UniversalGizmoLookAndFeel2D => _universalGizmoLookAndFeel2D;

		public UniversalGizmoLookAndFeel3D UniversalGizmoLookAndFeel3D => _universalGizmoLookAndFeel3D;

		public UniversalGizmoHotkeys UniversalGizmoHotkeys => _universalGizmoHotkeys;

		public ObjectTransformGizmoSettings ObjectUniversalGizmoSettings => _objectUniversalGizmoSettings;

		public BoxGizmoSettings3D BoxScaleGizmoSettings3D => _boxScaleGizmoSettings3D;

		public BoxGizmoLookAndFeel3D BoxScaleGizmoLookAndFeel3D => _boxScaleGizmoLookAndFeel3D;

		public BoxGizmoHotkeys BoxScaleGizmoHotkeys => _boxScaleGizmoHotkeys;

		public ObjectExtrudeGizmoLookAndFeel3D ExtrudeGizmoLookAndFeel3D => _extrudeGizmoLookAndFeel3D;

		public ObjectExtrudeGizmoHotkeys ExtrudeGozmoHotkeys => _extrudeGizmoHotkeys;

		public void SetTargetObjectCollection(IEnumerable<GameObject> targetObjectCollection)
		{
			_targetObjectCollection = targetObjectCollection;
		}

		public void Initialize_SystemCall()
		{
			ObjectTransformGizmo objectTransformGizmo = MonoSingleton<RTGizmosEngine>.Get.CreateObjectMoveGizmo();
			RegisterGizmo(ObjectSelectionGizmoId.MoveGizmo, objectTransformGizmo.Gizmo);
			_workGizmo = GetObjectSelectionGizmo(objectTransformGizmo.Gizmo);
			_workGizmo.Gizmo.SetEnabled(enabled: false);
			_workGizmoId = ObjectSelectionGizmoId.MoveGizmo;
			ObjectTransformGizmo objectTransformGizmo2 = MonoSingleton<RTGizmosEngine>.Get.CreateObjectRotationGizmo();
			RegisterGizmo(ObjectSelectionGizmoId.RotationGizmo, objectTransformGizmo2.Gizmo);
			objectTransformGizmo2.Gizmo.SetEnabled(enabled: false);
			ObjectTransformGizmo objectTransformGizmo3 = MonoSingleton<RTGizmosEngine>.Get.CreateObjectScaleGizmo();
			RegisterGizmo(ObjectSelectionGizmoId.ScaleGizmo, objectTransformGizmo3.Gizmo);
			objectTransformGizmo3.Gizmo.SetEnabled(enabled: false);
			BoxGizmo boxGizmo = MonoSingleton<RTGizmosEngine>.Get.CreateObjectBoxScaleGizmo();
			RegisterGizmo(ObjectSelectionGizmoId.BoxScaleGizmo, boxGizmo.Gizmo);
			boxGizmo.Gizmo.SetEnabled(enabled: false);
			ObjectTransformGizmo objectTransformGizmo4 = MonoSingleton<RTGizmosEngine>.Get.CreateObjectUniversalGizmo();
			RegisterGizmo(ObjectSelectionGizmoId.UniversalGizmo, objectTransformGizmo4.Gizmo);
			objectTransformGizmo4.Gizmo.SetEnabled(enabled: false);
			ObjectExtrudeGizmo objectExtrudeGizmo = MonoSingleton<RTGizmosEngine>.Get.CreateObjectExtrudeGizmo();
			RegisterGizmo(ObjectSelectionGizmoId.ExtrudeGizmo, objectExtrudeGizmo.Gizmo);
			objectExtrudeGizmo.Gizmo.SetEnabled(enabled: false);
			MonoSingleton<RTUndoRedo>.Get.UndoEnd += OnUndoRedo;
			MonoSingleton<RTUndoRedo>.Get.RedoEnd += OnUndoRedo;
			MonoSingleton<RTObjectSelection>.Get.Changed += OnObjectSelectionChanged;
			MonoSingleton<RTObjectSelection>.Get.Rotated += OnObjectSelectionRotated;
			MonoSingleton<RTObjectSelection>.Get.Enabled += OnObjectSelectionEnabled;
			MonoSingleton<RTObjectSelection>.Get.Disabled += OnObjectSelectionDisabled;
			MonoSingleton<RTObjectSelection>.Get.ManipSessionBegin += OnObjectSelectionManipSessionBegin;
			MonoSingleton<RTObjectSelection>.Get.ManipSessionEnd += OnObjectSelectionManipSessionEnd;
			SetTransformSpace(GizmoSpace.Local);
			SetTransformPivot(GizmoObjectTransformPivot.ObjectGroupCenter);
		}

		public void SetGizmoUsable(int gizmoId, bool isUsable)
		{
			ObjectSelectionGizmo objectSelectionGizmo = GetObjectSelectionGizmo(gizmoId);
			if (objectSelectionGizmo != null && objectSelectionGizmo.IsUsable != isUsable)
			{
				objectSelectionGizmo.IsUsable = isUsable;
				if (!objectSelectionGizmo.IsUsable && _workGizmo.Id == objectSelectionGizmo.Id)
				{
					objectSelectionGizmo.Gizmo.SetEnabled(enabled: false);
				}
			}
		}

		public Gizmo GetGizmoById(int gizmoId)
		{
			if (IsGizmoRegistered(gizmoId))
			{
				return GetObjectSelectionGizmo(gizmoId).Gizmo;
			}
			return null;
		}

		public List<Gizmo> GetAllGizmos()
		{
			if (_allGizmos.Count == 0)
			{
				return new List<Gizmo>();
			}
			List<Gizmo> list = new List<Gizmo>(_allGizmos.Count);
			foreach (ObjectSelectionGizmo allGizmo in _allGizmos)
			{
				list.Add(allGizmo.Gizmo);
			}
			return list;
		}

		public int GetGizmoId(Gizmo gizmo)
		{
			List<ObjectSelectionGizmo> list = _allGizmos.FindAll((ObjectSelectionGizmo item) => item.Gizmo == gizmo);
			if (list.Count == 0)
			{
				return ObjectSelectionGizmoId.None;
			}
			return list[0].Id;
		}

		public ObjectTransformGizmo GetTransformGizmoById(int id)
		{
			List<ObjectSelectionGizmo> list = _allGizmos.FindAll((ObjectSelectionGizmo item) => item.Id == id);
			if (list.Count == 0)
			{
				return null;
			}
			return list[0].Gizmo.GetFirstBehaviourOfType<ObjectTransformGizmo>();
		}

		public void SetTransformPivot(GizmoObjectTransformPivot transformPivot)
		{
			foreach (ObjectTransformGizmo objectTransformGizmo in _objectTransformGizmos)
			{
				objectTransformGizmo.SetTransformPivot(transformPivot);
			}
		}

		public void SetTransformSpace(GizmoSpace transformSpace)
		{
			if (_transformSpace == transformSpace)
			{
				return;
			}
			_transformSpace = transformSpace;
			foreach (ObjectSelectionGizmo allGizmo in _allGizmos)
			{
				if (allGizmo.IsTransformGizmo)
				{
					allGizmo.TransformGizmo.SetTransformSpace(transformSpace);
				}
				else if (allGizmo.IsExtrudeGizmo)
				{
					allGizmo.ExtrudeGizmo.SetExtrudeSpace(transformSpace);
				}
			}
		}

		public void SetWorkGizmo(int gizmoId)
		{
			if (gizmoId != ObjectSelectionGizmoId.None)
			{
				bool isEnabled = _workGizmo.Gizmo.IsEnabled;
				_workGizmo.Gizmo.SetEnabled(enabled: false);
				_workGizmo = GetObjectSelectionGizmo(gizmoId);
				if (_areGizmosVisible && _workGizmo.IsUsable && isEnabled)
				{
					_workGizmo.Gizmo.SetEnabled(enabled: true);
				}
				else
				{
					_workGizmo.Gizmo.SetEnabled(enabled: false);
				}
			}
			else if (_workGizmo != null)
			{
				_workGizmo.Gizmo.SetEnabled(enabled: false);
			}
			_workGizmoId = gizmoId;
		}

		public void SetGizmosVisisble(bool visible)
		{
			if (_areGizmosVisible == visible)
			{
				return;
			}
			_areGizmosVisible = visible;
			if (!_areGizmosVisible)
			{
				foreach (Gizmo allGizmo in GetAllGizmos())
				{
					allGizmo.SetEnabled(enabled: false);
				}
			}
			OnTargetObjectGroupUpdated();
		}

		public void Update_SystemCall()
		{
			bool isManipSessionActive = MonoSingleton<RTObjectSelection>.Get.IsManipSessionActive;
			if (!isManipSessionActive && MonoSingleton<RTObjectSelection>.Get.NumSelectedObjects != 0)
			{
				int num = ObjectSelectionGizmoId.None;
				if (Hotkeys.ActivateMoveGizmo.IsActiveInFrame())
				{
					num = ObjectSelectionGizmoId.MoveGizmo;
				}
				else if (Hotkeys.ActivateRotationGizmo.IsActiveInFrame())
				{
					num = ObjectSelectionGizmoId.RotationGizmo;
				}
				else if (Hotkeys.ActivateScaleGizmo.IsActiveInFrame())
				{
					num = ObjectSelectionGizmoId.ScaleGizmo;
				}
				else if (Hotkeys.ActivateBoxScaleGizmo.IsActiveInFrame())
				{
					num = ObjectSelectionGizmoId.BoxScaleGizmo;
				}
				else if (Hotkeys.ActivateUniversalGizmo.IsActiveInFrame())
				{
					num = ObjectSelectionGizmoId.UniversalGizmo;
				}
				else if (Hotkeys.ActivateExtrudeGizmo.IsActiveInFrame())
				{
					num = ObjectSelectionGizmoId.ExtrudeGizmo;
				}
				if (num != ObjectSelectionGizmoId.None)
				{
					SetWorkGizmo(num);
				}
			}
			if (!isManipSessionActive && Hotkeys.ToggleTransformSpace.IsActiveInFrame())
			{
				GizmoSpace transformSpace = ((_transformSpace == GizmoSpace.Global) ? GizmoSpace.Local : GizmoSpace.Global);
				SetTransformSpace(transformSpace);
			}
		}

		private void OnObjectSelectionChanged(ObjectSelectionChangedEventArgs args)
		{
			if (args.SelectReason != ObjectSelectReason.None)
			{
				if (args.SelectReason == ObjectSelectReason.Undo || args.SelectReason == ObjectSelectReason.Redo)
				{
					_pivotObject = args.UndoRedoSnapshot.GizmosSnapshot.PivotObject;
				}
				else if (args.SelectReason == ObjectSelectReason.MultiSelect || args.SelectReason == ObjectSelectReason.MultiSelectAppend)
				{
					if (_pivotObject == null)
					{
						_pivotObject = GameObjectEx.FilterParentsOnly(args.ObjectsWhichWereSelected)[0];
					}
				}
				else if (args.NumObjectsSelected != 0)
				{
					_pivotObject = GameObjectEx.FilterParentsOnly(args.ObjectsWhichWereSelected)[0];
				}
				else
				{
					_pivotObject = null;
				}
			}
			else if (args.DeselectReason != ObjectDeselectReason.None)
			{
				if (args.DeselectReason == ObjectDeselectReason.Undo || args.DeselectReason == ObjectDeselectReason.Redo)
				{
					_pivotObject = args.UndoRedoSnapshot.GizmosSnapshot.PivotObject;
				}
				else if (MonoSingleton<RTObjectSelection>.Get.NumSelectedObjects != 0)
				{
					if (!MonoSingleton<RTObjectSelection>.Get.IsObjectSelected(_pivotObject))
					{
						_pivotObject = GameObjectEx.FilterParentsOnly(_targetObjectCollection)[0];
					}
				}
				else
				{
					_pivotObject = null;
				}
			}
			OnTargetObjectGroupUpdated();
		}

		private void OnUndoRedo(IUndoRedoAction action)
		{
			OnTargetObjectGroupUpdated();
		}

		private void OnGizmoPostEnabled(Gizmo gizmo)
		{
			ObjectSelectionGizmo objectSelectionGizmo = GetObjectSelectionGizmo(gizmo);
			if (objectSelectionGizmo.IsTransformGizmo)
			{
				objectSelectionGizmo.TransformGizmo.RefreshPositionAndRotation();
			}
			else if (objectSelectionGizmo.IsBoxScaleGizmo)
			{
				_workGizmo.BoxScaleGizmo.SetTargetHierarchy(_pivotObject);
			}
			else if (objectSelectionGizmo.IsExtrudeGizmo)
			{
				_workGizmo.ExtrudeGizmo.SetExtrudeTargets(_targetObjectCollection);
			}
		}

		private void OnTargetObjectGroupUpdated()
		{
			foreach (ObjectTransformGizmo objectTransformGizmo in _objectTransformGizmos)
			{
				objectTransformGizmo.SetTargetPivotObject(_pivotObject);
			}
			if (_areGizmosVisible && _workGizmo.IsUsable && _workGizmoId != ObjectSelectionGizmoId.None)
			{
				if (_pivotObject != null)
				{
					_workGizmo.Gizmo.SetEnabled(enabled: true);
				}
				else
				{
					_workGizmo.Gizmo.SetEnabled(enabled: false);
				}
			}
			if (_workGizmo.IsBoxScaleGizmo)
			{
				_workGizmo.BoxScaleGizmo.SetTargetHierarchy(_pivotObject);
			}
			else if (_workGizmo.IsExtrudeGizmo)
			{
				_workGizmo.ExtrudeGizmo.SetExtrudeTargets(_targetObjectCollection);
			}
		}

		private void OnObjectSelectionManipSessionBegin(ObjectSelectionManipSession manipSession)
		{
			List<Gizmo> allGizmos = GetAllGizmos();
			_gizmosEnabledStateSnapshot.Snapshot(allGizmos);
			foreach (Gizmo item in allGizmos)
			{
				item.SetEnabled(enabled: false);
			}
		}

		private void OnObjectSelectionManipSessionEnd(ObjectSelectionManipSession manipSession)
		{
			_gizmosEnabledStateSnapshot.Apply();
		}

		private void OnObjectSelectionRotated()
		{
			foreach (ObjectSelectionGizmo allGizmo in _allGizmos)
			{
				if (allGizmo.IsTransformGizmo)
				{
					allGizmo.TransformGizmo.RefreshPositionAndRotation();
				}
				else if (allGizmo.IsBoxScaleGizmo)
				{
					allGizmo.BoxScaleGizmo.FitBoxToTargetHierarchy();
				}
				else if (allGizmo.IsExtrudeGizmo)
				{
					allGizmo.ExtrudeGizmo.FitBoxToTargets();
				}
			}
		}

		private void OnObjectSelectionEnabled()
		{
			_gizmosEnabledStateSnapshot.Apply();
		}

		private void OnObjectSelectionDisabled()
		{
			List<Gizmo> allGizmos = GetAllGizmos();
			_gizmosEnabledStateSnapshot.Snapshot(allGizmos);
			foreach (Gizmo item in allGizmos)
			{
				item.SetEnabled(enabled: false);
			}
		}

		private ObjectSelectionGizmo GetObjectSelectionGizmo(Gizmo gizmo)
		{
			foreach (ObjectSelectionGizmo allGizmo in _allGizmos)
			{
				if (allGizmo.Gizmo == gizmo)
				{
					return allGizmo;
				}
			}
			return null;
		}

		private ObjectSelectionGizmo GetObjectSelectionGizmo(int id)
		{
			foreach (ObjectSelectionGizmo allGizmo in _allGizmos)
			{
				if (allGizmo.Id == id)
				{
					return allGizmo;
				}
			}
			return null;
		}

		private bool IsGizmoRegistered(int gizmoId)
		{
			return _allGizmos.FindAll((ObjectSelectionGizmo item) => item.Id == gizmoId).Count != 0;
		}

		private bool IsGizmoRegistered(Gizmo gizmo)
		{
			return _allGizmos.FindAll((ObjectSelectionGizmo item) => item.Gizmo == gizmo).Count != 0;
		}

		private bool RegisterGizmo(int gizmoId, Gizmo gizmo)
		{
			if (IsGizmoRegistered(gizmoId) || IsGizmoRegistered(gizmo))
			{
				return false;
			}
			_allGizmos.Add(new ObjectSelectionGizmo(gizmoId, gizmo));
			ObjectTransformGizmo firstBehaviourOfType = gizmo.GetFirstBehaviourOfType<ObjectTransformGizmo>();
			if (firstBehaviourOfType != null)
			{
				_objectTransformGizmos.Add(firstBehaviourOfType);
				firstBehaviourOfType.SetTargetObjects(_targetObjectCollection);
			}
			MoveGizmo firstBehaviourOfType2 = gizmo.GetFirstBehaviourOfType<MoveGizmo>();
			if (firstBehaviourOfType2 != null)
			{
				firstBehaviourOfType2.SharedSettings2D = MoveGizmoSettings2D;
				firstBehaviourOfType2.SharedSettings3D = MoveGizmoSettings3D;
				firstBehaviourOfType2.SharedLookAndFeel2D = MoveGizmoLookAndFeel2D;
				firstBehaviourOfType2.SharedLookAndFeel3D = MoveGizmoLookAndFeel3D;
				firstBehaviourOfType2.SharedHotkeys = MoveGizmoHotkeys;
				firstBehaviourOfType2.SetVertexSnapTargetObjects(_targetObjectCollection);
				if (firstBehaviourOfType != null)
				{
					firstBehaviourOfType.SharedSettings = ObjectMoveGizmoSettings;
				}
			}
			RotationGizmo firstBehaviourOfType3 = gizmo.GetFirstBehaviourOfType<RotationGizmo>();
			if (firstBehaviourOfType3 != null)
			{
				firstBehaviourOfType3.SharedSettings3D = RotationGizmoSettings3D;
				firstBehaviourOfType3.SharedLookAndFeel3D = RotationGizmoLookAndFeel3D;
				firstBehaviourOfType3.SharedHotkeys = RotationGizmoHotkeys;
				if (firstBehaviourOfType != null)
				{
					firstBehaviourOfType.SharedSettings = ObjectRotationGizmoSettings;
				}
			}
			ScaleGizmo firstBehaviourOfType4 = gizmo.GetFirstBehaviourOfType<ScaleGizmo>();
			if (firstBehaviourOfType4 != null)
			{
				firstBehaviourOfType4.SharedSettings3D = ScaleGizmoSettings3D;
				firstBehaviourOfType4.SharedLookAndFeel3D = ScaleGizmoLookAndFeel3D;
				firstBehaviourOfType4.SharedHotkeys = ScaleGizmoHotkeys;
				firstBehaviourOfType4.SetScaleGuideTargetObjects(_targetObjectCollection);
				if (firstBehaviourOfType != null)
				{
					firstBehaviourOfType.SharedSettings = ObjectScaleGizmoSettings;
				}
			}
			BoxGizmo firstBehaviourOfType5 = gizmo.GetFirstBehaviourOfType<BoxGizmo>();
			if (firstBehaviourOfType5 != null)
			{
				firstBehaviourOfType5.SharedSettings3D = BoxScaleGizmoSettings3D;
				firstBehaviourOfType5.SharedLookAndFeel3D = BoxScaleGizmoLookAndFeel3D;
				firstBehaviourOfType5.SharedHotkeys = BoxScaleGizmoHotkeys;
			}
			UniversalGizmo firstBehaviourOfType6 = gizmo.GetFirstBehaviourOfType<UniversalGizmo>();
			if (firstBehaviourOfType6 != null)
			{
				firstBehaviourOfType6.SharedSettings2D = UniversalGizmoSettings2D;
				firstBehaviourOfType6.SharedSettings3D = UniversalGizmoSettings3D;
				firstBehaviourOfType6.SharedLookAndFeel2D = UniversalGizmoLookAndFeel2D;
				firstBehaviourOfType6.SharedLookAndFeel3D = UniversalGizmoLookAndFeel3D;
				firstBehaviourOfType6.SharedHotkeys = UniversalGizmoHotkeys;
				firstBehaviourOfType6.SetMvVertexSnapTargetObjects(_targetObjectCollection);
				firstBehaviourOfType6.SetScaleGuideTargetObjects(_targetObjectCollection);
				if (firstBehaviourOfType != null)
				{
					firstBehaviourOfType.SharedSettings = ObjectUniversalGizmoSettings;
				}
			}
			ObjectExtrudeGizmo firstBehaviourOfType7 = gizmo.GetFirstBehaviourOfType<ObjectExtrudeGizmo>();
			if (firstBehaviourOfType7 != null)
			{
				firstBehaviourOfType7.SharedLookAndFeel3D = ExtrudeGizmoLookAndFeel3D;
				firstBehaviourOfType7.SharedHotkeys = ExtrudeGozmoHotkeys;
				firstBehaviourOfType7.SetExtrudeTargets(_targetObjectCollection);
			}
			gizmo.PostEnabled += OnGizmoPostEnabled;
			return true;
		}
	}
}
