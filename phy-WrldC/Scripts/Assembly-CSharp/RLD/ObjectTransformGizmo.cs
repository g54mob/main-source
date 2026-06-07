using System;
using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class ObjectTransformGizmo : GizmoBehaviour
	{
		public class ObjectRestrictions
		{
			private bool[] _moveAxesMask = new bool[3] { true, true, true };

			private bool[] _scaleAxesMask = new bool[3] { true, true, true };

			private HashSet<int> _handleMask = new HashSet<int>();

			public bool CanMoveAlongAllAxes()
			{
				if (_moveAxesMask[0] && _moveAxesMask[1])
				{
					return _moveAxesMask[2];
				}
				return false;
			}

			public bool CanScaleAlongAllAxes()
			{
				if (_scaleAxesMask[0] && _scaleAxesMask[1])
				{
					return _scaleAxesMask[2];
				}
				return false;
			}

			public bool CanMoveAlongAxis(int axisIndex)
			{
				return _moveAxesMask[axisIndex];
			}

			public bool CanScaleAlongAxis(int axisIndex)
			{
				return _scaleAxesMask[axisIndex];
			}

			public void SetCanMoveAlongAxis(int axisIndex, bool canMove)
			{
				_moveAxesMask[axisIndex] = canMove;
			}

			public void SetCanScaleAlongAxis(int axisIndex, bool canScale)
			{
				_scaleAxesMask[axisIndex] = canScale;
			}

			public bool IsAffectedByHandle(int handleId)
			{
				return !_handleMask.Contains(handleId);
			}

			public void SetIsAffectedByHandle(int handleId, bool isAffected)
			{
				if (isAffected)
				{
					_handleMask.Remove(handleId);
				}
				else
				{
					_handleMask.Add(handleId);
				}
			}

			public Vector3 AdjustMoveVector(Vector3 moveVector)
			{
				Vector3 result = moveVector;
				if (!CanMoveAlongAxis(0))
				{
					result[0] = 0f;
				}
				if (!CanMoveAlongAxis(1))
				{
					result[1] = 0f;
				}
				if (!CanMoveAlongAxis(2))
				{
					result[2] = 0f;
				}
				return result;
			}

			public Vector3 AdjustScaleVector(Vector3 scaleVector)
			{
				Vector3 result = scaleVector;
				if (!CanScaleAlongAxis(0))
				{
					result[0] = 1f;
				}
				if (!CanScaleAlongAxis(1))
				{
					result[1] = 1f;
				}
				if (!CanScaleAlongAxis(2))
				{
					result[2] = 1f;
				}
				return result;
			}
		}

		[Flags]
		public enum Channels
		{
			None = 0,
			Position = 1,
			Rotation = 2,
			Scale = 4,
			All = 7
		}

		private enum TargetObjectMode
		{
			Multiple = 0,
			Single = 1
		}

		private TargetObjectMode _targetObjectMode;

		private Channels _transformChannelFlags;

		private IEnumerable<GameObject> _targetObjects;

		private GameObject _targetPivotObject;

		private List<LocalTransformSnapshot> _preTransformSnapshots;

		private List<GameObject> _transformableParents;

		private AABB _targetGroupAABBOnDragBegin;

		private GizmoSpace _transformSpace;

		private bool _isTransformSpacePermanent;

		private GizmoObjectTransformPivot _transformPivot;

		private bool _isTransformPivotPermanent;

		private Vector3 _customWorldPivot;

		private Dictionary<GameObject, Vector3> _objectToCustomLocalPivot = new Dictionary<GameObject, Vector3>();

		private Dictionary<GameObject, ObjectRestrictions> _objectToRestrictions = new Dictionary<GameObject, ObjectRestrictions>();

		[SerializeField]
		private ObjectTransformGizmoSettings _settings = new ObjectTransformGizmoSettings();

		private ObjectTransformGizmoSettings _sharedSettings;

		public GizmoObjectTransformPivot TransformPivot => _transformPivot;

		public bool IsTransformPivotPermanent => _isTransformPivotPermanent;

		public GizmoSpace TransformSpace => _transformSpace;

		public bool IsTransformSpacePermanent => _isTransformSpacePermanent;

		public Channels TransformChannelFlags => _transformChannelFlags;

		public bool CanAffectPosition => (_transformChannelFlags & Channels.Position) != 0;

		public bool CanAffectRotation => (_transformChannelFlags & Channels.Rotation) != 0;

		public bool CanAffectScale => (_transformChannelFlags & Channels.Scale) != 0;

		public Vector3 CustomWorldPivot => _customWorldPivot;

		public ObjectTransformGizmoSettings Settings
		{
			get
			{
				if (_sharedSettings == null)
				{
					return _settings;
				}
				return _sharedSettings;
			}
		}

		public ObjectTransformGizmoSettings SharedSettings
		{
			get
			{
				return _sharedSettings;
			}
			set
			{
				_sharedSettings = value;
			}
		}

		public override void OnAttached()
		{
			MonoSingleton<RTUndoRedo>.Get.UndoEnd += OnUndoRedoEnd;
			MonoSingleton<RTUndoRedo>.Get.RedoEnd += OnUndoRedoEnd;
		}

		public override void OnDetached()
		{
			MonoSingleton<RTUndoRedo>.Get.UndoEnd -= OnUndoRedoEnd;
			MonoSingleton<RTUndoRedo>.Get.RedoEnd -= OnUndoRedoEnd;
		}

		public void MakeTransformSpacePermanent()
		{
			_isTransformSpacePermanent = true;
		}

		public void MakeTransformPivotPermanent()
		{
			_isTransformPivotPermanent = true;
		}

		public bool ContainsRestrictionsForObject(GameObject targetObject)
		{
			if (targetObject != null)
			{
				return _objectToRestrictions.ContainsKey(targetObject);
			}
			return false;
		}

		public void RegisterObjectRestrictions(GameObject targetObject, ObjectRestrictions restrictions)
		{
			if (!ContainsRestrictionsForObject(targetObject))
			{
				_objectToRestrictions.Add(targetObject, restrictions);
			}
		}

		public void RegisterObjectRestrictions(List<GameObject> targetObjects, ObjectRestrictions restrictions)
		{
			foreach (GameObject targetObject in targetObjects)
			{
				RegisterObjectRestrictions(targetObject, restrictions);
			}
		}

		public void UnregisterObjectRestrictions(GameObject targetObject)
		{
			if (ContainsRestrictionsForObject(targetObject))
			{
				_objectToRestrictions.Remove(targetObject);
			}
		}

		public ObjectRestrictions GetObjectRestrictions(GameObject targetObject)
		{
			if (ContainsRestrictionsForObject(targetObject))
			{
				return _objectToRestrictions[targetObject];
			}
			return null;
		}

		public void SetTransformChannelFlags(Channels flags)
		{
			if (!_gizmo.IsDragged)
			{
				_transformChannelFlags = flags;
			}
		}

		public void SetCanAffectPosition(bool affectPosition)
		{
			if (!_gizmo.IsDragged)
			{
				if (affectPosition)
				{
					_transformChannelFlags |= Channels.Position;
				}
				else
				{
					_transformChannelFlags &= ~Channels.Position;
				}
			}
		}

		public void SetCanAffectRotation(bool affectRotation)
		{
			if (!_gizmo.IsDragged)
			{
				if (affectRotation)
				{
					_transformChannelFlags |= Channels.Rotation;
				}
				else
				{
					_transformChannelFlags &= ~Channels.Rotation;
				}
			}
		}

		public void SetCanAffectScale(bool affectScale)
		{
			if (!_gizmo.IsDragged)
			{
				if (affectScale)
				{
					_transformChannelFlags |= Channels.Scale;
				}
				else
				{
					_transformChannelFlags &= ~Channels.Scale;
				}
			}
		}

		public void SetTargetPivotObject(GameObject targetPivotObject)
		{
			if (!_gizmo.IsDragged && _targetObjectMode != TargetObjectMode.Single)
			{
				_targetPivotObject = targetPivotObject;
				RefreshPositionAndRotation();
			}
		}

		public void SetTargetObjects(IEnumerable<GameObject> targetObjects)
		{
			if (!_gizmo.IsDragged)
			{
				_targetObjectMode = TargetObjectMode.Multiple;
				_targetObjects = targetObjects;
				RefreshPositionAndRotation();
			}
		}

		public void SetTargetObject(GameObject targetObject)
		{
			if (!_gizmo.IsDragged)
			{
				_targetObjectMode = TargetObjectMode.Single;
				_targetObjects = new List<GameObject> { targetObject };
				_targetPivotObject = targetObject;
				RefreshPositionAndRotation();
			}
		}

		public void SetTransformPivot(GizmoObjectTransformPivot transformPivot)
		{
			if (!_gizmo.IsDragged && !_isTransformPivotPermanent)
			{
				_transformPivot = transformPivot;
				RefreshPosition();
			}
		}

		public void SetCustomWorldPivot(Vector3 pivot)
		{
			if (!_gizmo.IsDragged)
			{
				_customWorldPivot = pivot;
				RefreshPosition();
			}
		}

		public void SetObjectCustomLocalPivot(GameObject gameObj, Vector3 pivot)
		{
			if (!(gameObj == null) && !_gizmo.IsDragged)
			{
				if (_objectToCustomLocalPivot.ContainsKey(gameObj))
				{
					_objectToCustomLocalPivot[gameObj] = pivot;
				}
				else
				{
					_objectToCustomLocalPivot.Add(gameObj, pivot);
				}
				RefreshPosition();
			}
		}

		public Vector3 GetObjectCustomLocalPivot(GameObject gameObj)
		{
			if (gameObj == null)
			{
				return Vector3.zero;
			}
			if (_objectToCustomLocalPivot.ContainsKey(gameObj))
			{
				return _objectToCustomLocalPivot[gameObj];
			}
			Transform transform = gameObj.transform;
			return transform.InverseTransformPoint(transform.position);
		}

		public void SetTransformSpace(GizmoSpace transformSpace)
		{
			if (!_gizmo.IsDragged && !_isTransformSpacePermanent)
			{
				_transformSpace = transformSpace;
				RefreshRotation();
			}
		}

		public AABB GetTargetObjectGroupWorldAABB()
		{
			if (_targetObjects == null)
			{
				return AABB.GetInvalid();
			}
			ObjectBounds.QueryConfig objectBoundsQConfig = GetObjectBoundsQConfig();
			AABB result = AABB.GetInvalid();
			foreach (GameObject targetObject in _targetObjects)
			{
				AABB aABB = ObjectBounds.CalcWorldAABB(targetObject, objectBoundsQConfig);
				if (result.IsValid)
				{
					result.Encapsulate(aABB);
				}
				else
				{
					result = aABB;
				}
			}
			return result;
		}

		public int GetNumTransformableParentObjects()
		{
			return GetTransformableParentObjects().Count;
		}

		public void RefreshPosition()
		{
			if (_targetObjects == null || _gizmo.IsDragged)
			{
				return;
			}
			GizmoTransform transform = base.Gizmo.Transform;
			if (_transformPivot == GizmoObjectTransformPivot.ObjectGroupCenter || _targetPivotObject == null)
			{
				transform.Position3D = GetTargetObjectGroupWorldAABB().Center;
			}
			else if (_transformPivot == GizmoObjectTransformPivot.ObjectMeshPivot)
			{
				if (_targetPivotObject == null)
				{
					transform.Position3D = GetTargetObjectGroupWorldAABB().Center;
				}
				else
				{
					transform.Position3D = _targetPivotObject.transform.position;
				}
			}
			else if (_transformPivot == GizmoObjectTransformPivot.ObjectCenterPivot)
			{
				if (_targetPivotObject == null)
				{
					transform.Position3D = GetTargetObjectGroupWorldAABB().Center;
				}
				else
				{
					ObjectBounds.QueryConfig objectBoundsQConfig = GetObjectBoundsQConfig();
					AABB aABB = ObjectBounds.CalcWorldAABB(_targetPivotObject, objectBoundsQConfig);
					if (aABB.IsValid)
					{
						transform.Position3D = aABB.Center;
					}
				}
			}
			if (_transformPivot == GizmoObjectTransformPivot.CustomWorldPivot)
			{
				transform.Position3D = _customWorldPivot;
			}
			else if (_transformPivot == GizmoObjectTransformPivot.CustomObjectLocalPivot)
			{
				if (_targetPivotObject == null)
				{
					transform.Position3D = GetTargetObjectGroupWorldAABB().Center;
				}
				else
				{
					transform.Position3D = _targetPivotObject.transform.TransformPoint(GetObjectCustomLocalPivot(_targetPivotObject));
				}
			}
		}

		public void RefreshRotation()
		{
			if (_targetObjects != null && !_gizmo.IsDragged)
			{
				GizmoTransform transform = base.Gizmo.Transform;
				if (_transformSpace == GizmoSpace.Global)
				{
					transform.Rotation3D = Quaternion.identity;
				}
				else if (_targetPivotObject == null)
				{
					transform.Rotation3D = Quaternion.identity;
				}
				else
				{
					transform.Rotation3D = _targetPivotObject.transform.rotation;
				}
			}
		}

		public void RefreshPositionAndRotation()
		{
			RefreshPosition();
			RefreshRotation();
		}

		public override void OnGizmoDragBegin(int handleId)
		{
			_preTransformSnapshots = LocalTransformSnapshot.GetSnapshotCollection(_targetObjects);
			_transformableParents = GetTransformableParentObjects();
			_targetGroupAABBOnDragBegin = GetTargetObjectGroupWorldAABB();
		}

		public override void OnGizmoDragUpdate(int handleId)
		{
			if (CanAffectPosition && base.Gizmo.ActiveDragChannel == GizmoDragChannel.Offset)
			{
				MoveObjects(base.Gizmo.RelativeDragOffset);
			}
			if (CanAffectRotation && base.Gizmo.ActiveDragChannel == GizmoDragChannel.Rotation)
			{
				RotateObjects(base.Gizmo.RelativeDragRotation);
			}
			if (CanAffectScale && base.Gizmo.ActiveDragChannel == GizmoDragChannel.Scale)
			{
				ScaleObjects();
			}
		}

		public override void OnGizmoDragEnd(int handleId)
		{
			if (_transformableParents.Count != 0)
			{
				new PostObjectTransformsChangedAction(_preTransformSnapshots, LocalTransformSnapshot.GetSnapshotCollection(_targetObjects)).Execute();
			}
			RefreshPositionAndRotation();
		}

		private List<GameObject> GetTransformableParentObjects()
		{
			List<GameObject> list = GameObjectEx.FilterParentsOnly(_targetObjects);
			List<GameObject> list2 = new List<GameObject>();
			foreach (GameObject item in list)
			{
				IRTTransformGizmoListener component = item.GetComponent<IRTTransformGizmoListener>();
				if ((component == null || component.OnCanBeTransformed(base.Gizmo)) && Settings.IsLayerTransformable(item.layer) && Settings.IsObjectTransformable(item))
				{
					list2.Add(item);
				}
			}
			return list2;
		}

		private void OnUndoRedoEnd(IUndoRedoAction action)
		{
			if (action is PostObjectTransformsChangedAction)
			{
				RefreshPositionAndRotation();
			}
		}

		private void MoveObjects(Vector3 moveVector)
		{
			foreach (GameObject transformableParent in _transformableParents)
			{
				MoveObject(transformableParent, moveVector);
			}
		}

		private void MoveObject(GameObject gameObject, Vector3 moveVector)
		{
			ObjectRestrictions objectRestrictions = GetObjectRestrictions(gameObject);
			if (objectRestrictions != null)
			{
				if (!objectRestrictions.IsAffectedByHandle(base.Gizmo.DragHandleId))
				{
					return;
				}
				moveVector = objectRestrictions.AdjustMoveVector(moveVector);
			}
			gameObject.transform.position += moveVector;
			gameObject.GetComponent<IRTTransformGizmoListener>()?.OnTransformed(base.Gizmo);
		}

		private void RotateObjects(Quaternion rotation)
		{
			if (TransformPivot == GizmoObjectTransformPivot.ObjectGroupCenter)
			{
				foreach (GameObject transformableParent in _transformableParents)
				{
					RotateObject(transformableParent, rotation, _targetGroupAABBOnDragBegin.Center);
				}
				return;
			}
			if (TransformPivot == GizmoObjectTransformPivot.ObjectMeshPivot)
			{
				foreach (GameObject transformableParent2 in _transformableParents)
				{
					RotateObject(transformableParent2, rotation, transformableParent2.transform.position);
				}
				return;
			}
			if (TransformPivot == GizmoObjectTransformPivot.CustomWorldPivot)
			{
				foreach (GameObject transformableParent3 in _transformableParents)
				{
					RotateObject(transformableParent3, rotation, CustomWorldPivot);
				}
				return;
			}
			if (TransformPivot == GizmoObjectTransformPivot.ObjectCenterPivot)
			{
				ObjectBounds.QueryConfig objectBoundsQConfig = GetObjectBoundsQConfig();
				{
					foreach (GameObject transformableParent4 in _transformableParents)
					{
						AABB aABB = ObjectBounds.CalcWorldAABB(transformableParent4, objectBoundsQConfig);
						if (aABB.IsValid)
						{
							RotateObject(transformableParent4, rotation, aABB.Center);
						}
					}
					return;
				}
			}
			if (TransformPivot != GizmoObjectTransformPivot.CustomObjectLocalPivot)
			{
				return;
			}
			foreach (GameObject transformableParent5 in _transformableParents)
			{
				Vector3 rotationPivot = transformableParent5.transform.TransformPoint(GetObjectCustomLocalPivot(transformableParent5));
				RotateObject(transformableParent5, rotation, rotationPivot);
			}
		}

		private void RotateObject(GameObject gameObject, Quaternion rotation, Vector3 rotationPivot)
		{
			ObjectRestrictions objectRestrictions = GetObjectRestrictions(gameObject);
			if (objectRestrictions == null || objectRestrictions.IsAffectedByHandle(base.Gizmo.DragHandleId))
			{
				gameObject.transform.RotateAroundPivot(rotation, rotationPivot);
				gameObject.GetComponent<IRTTransformGizmoListener>()?.OnTransformed(base.Gizmo);
			}
		}

		private void ScaleObjects()
		{
			if (TransformPivot == GizmoObjectTransformPivot.ObjectGroupCenter)
			{
				foreach (GameObject transformableParent in _transformableParents)
				{
					ScaleObject(transformableParent, _targetGroupAABBOnDragBegin.Center);
				}
				return;
			}
			if (TransformPivot == GizmoObjectTransformPivot.ObjectMeshPivot)
			{
				foreach (GameObject transformableParent2 in _transformableParents)
				{
					ScaleObject(transformableParent2, transformableParent2.transform.position);
				}
				return;
			}
			if (TransformPivot == GizmoObjectTransformPivot.CustomWorldPivot)
			{
				foreach (GameObject transformableParent3 in _transformableParents)
				{
					ScaleObject(transformableParent3, CustomWorldPivot);
				}
				return;
			}
			if (TransformPivot == GizmoObjectTransformPivot.ObjectCenterPivot)
			{
				ObjectBounds.QueryConfig objectBoundsQConfig = GetObjectBoundsQConfig();
				{
					foreach (GameObject transformableParent4 in _transformableParents)
					{
						AABB aABB = ObjectBounds.CalcWorldAABB(transformableParent4, objectBoundsQConfig);
						if (aABB.IsValid)
						{
							ScaleObject(transformableParent4, aABB.Center);
						}
					}
					return;
				}
			}
			if (TransformPivot != GizmoObjectTransformPivot.CustomObjectLocalPivot)
			{
				return;
			}
			foreach (GameObject transformableParent5 in _transformableParents)
			{
				Vector3 scalePivot = transformableParent5.transform.TransformPoint(GetObjectCustomLocalPivot(transformableParent5));
				ScaleObject(transformableParent5, scalePivot);
			}
		}

		private void ScaleObject(GameObject gameObject, Vector3 scalePivot)
		{
			Transform transform = gameObject.transform;
			Vector3 vector = base.Gizmo.RelativeDragScale.ReplaceInfinites(1f);
			ObjectRestrictions objectRestrictions = GetObjectRestrictions(gameObject);
			if (objectRestrictions != null)
			{
				if (!objectRestrictions.IsAffectedByHandle(base.Gizmo.DragHandleId))
				{
					return;
				}
				vector = objectRestrictions.AdjustScaleVector(vector);
			}
			transform.ScaleFromPivot(vector, scalePivot);
			gameObject.GetComponent<IRTTransformGizmoListener>()?.OnTransformed(base.Gizmo);
		}

		private ObjectBounds.QueryConfig GetObjectBoundsQConfig()
		{
			return new ObjectBounds.QueryConfig
			{
				NoVolumeSize = Vector3Ex.FromValue(1E-06f),
				ObjectTypes = GameObjectTypeHelper.AllCombined
			};
		}
	}
}
