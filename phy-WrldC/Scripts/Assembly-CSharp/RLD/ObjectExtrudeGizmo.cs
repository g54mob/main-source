using System;
using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class ObjectExtrudeGizmo : GizmoBehaviour
	{
		private struct HandleDragExtrudeData
		{
			public Vector3 ExtrudeDir;

			public Vector3 ExtrudeCenter;

			public int AxisIndex;
		}

		private Vector3 _boxSize = Vector3Ex.FromValue(5f);

		private GizmoSpace _extrudeSpace = GizmoSpace.Local;

		private List<GameObject> _targetParents = new List<GameObject>();

		private HashSet<GameObject> _ignoredParentObjects = new HashSet<GameObject>();

		private ObjectBounds.QueryConfig _boundsQConfig;

		private SceneOverlapFilter _sceneOverlapFilter = new SceneOverlapFilter();

		private ObjectExtrudeGizmoDragEnd _dragEndAction;

		private HandleDragExtrudeData _handleDragExtrData;

		private GizmoLineSlider3D _rightExtrude;

		private GizmoLineSlider3D _upExtrude;

		private GizmoLineSlider3D _frontExtrude;

		private GizmoLineSlider3D _leftExtrude;

		private GizmoLineSlider3D _bottomExtrude;

		private GizmoLineSlider3D _backExtrude;

		private GizmoLineSlider3DCollection _extrudeSliders = new GizmoLineSlider3DCollection();

		[SerializeField]
		private ObjectExtrudeGizmoLookAndFeel3D _lookAndFeel3D = new ObjectExtrudeGizmoLookAndFeel3D();

		private ObjectExtrudeGizmoLookAndFeel3D _sharedLookAndFeel3D;

		[SerializeField]
		private ObjectExtrudeGizmoHotkeys _hotkeys = new ObjectExtrudeGizmoHotkeys();

		private ObjectExtrudeGizmoHotkeys _sharedHotkeys;

		public ObjectExtrudeGizmoLookAndFeel3D LookAndFeel3D
		{
			get
			{
				if (_sharedLookAndFeel3D == null)
				{
					return _lookAndFeel3D;
				}
				return _sharedLookAndFeel3D;
			}
		}

		public ObjectExtrudeGizmoLookAndFeel3D SharedLookAndFeel3D
		{
			get
			{
				return _sharedLookAndFeel3D;
			}
			set
			{
				_sharedLookAndFeel3D = value;
				SetupSharedLookAndFeel();
			}
		}

		public ObjectExtrudeGizmoHotkeys Hotkeys
		{
			get
			{
				if (_sharedHotkeys != null)
				{
					return _sharedHotkeys;
				}
				return _hotkeys;
			}
		}

		public ObjectExtrudeGizmoHotkeys SharedHotkeys
		{
			get
			{
				return _sharedHotkeys;
			}
			set
			{
				_sharedHotkeys = value;
			}
		}

		public Vector3 BoxCenter => base.Gizmo.Transform.Position3D;

		public Quaternion BoxRotation => base.Gizmo.Transform.Rotation3D;

		public Vector3 BoxSize => _boxSize;

		public Vector3 BoxRight => BoxRotation * Vector3.right;

		public Vector3 BoxUp => BoxRotation * Vector3.up;

		public Vector3 BoxLook => BoxRotation * Vector3.forward;

		public OBB OBB => new OBB(BoxCenter, BoxSize, BoxRotation);

		public GizmoSpace ExtrudeSpace => _extrudeSpace;

		public int NumTargetParents => _targetParents.Count;

		public event ObjectExtrudeGizmoExtrudeUpdateHandler ExtrudeUpdate;

		public bool OwnsHandle(int handleId)
		{
			if (!_extrudeSliders.Contains(handleId))
			{
				return _extrudeSliders.ContainsCapId(handleId);
			}
			return true;
		}

		public bool IsRightExtrudeHandle(int handleId)
		{
			if (_rightExtrude.HandleId != handleId)
			{
				return _rightExtrude.Cap3DHandleId == handleId;
			}
			return true;
		}

		public bool IsLeftExtrudeHandle(int handleId)
		{
			if (_leftExtrude.HandleId != handleId)
			{
				return _leftExtrude.Cap3DHandleId == handleId;
			}
			return true;
		}

		public bool IsTopExtrudeHandle(int handleId)
		{
			if (_upExtrude.HandleId != handleId)
			{
				return _upExtrude.Cap3DHandleId == handleId;
			}
			return true;
		}

		public bool IsBottomExtrudeHandle(int handleId)
		{
			if (_bottomExtrude.HandleId != handleId)
			{
				return _bottomExtrude.Cap3DHandleId == handleId;
			}
			return true;
		}

		public bool IsFrontExtrudeHandle(int handleId)
		{
			if (_backExtrude.HandleId != handleId)
			{
				return _backExtrude.Cap3DHandleId == handleId;
			}
			return true;
		}

		public bool IsBackExtrudeHandle(int handleId)
		{
			if (_frontExtrude.HandleId != handleId)
			{
				return _frontExtrude.Cap3DHandleId == handleId;
			}
			return true;
		}

		public void SetIgnoredParentObjects(IEnumerable<GameObject> ignoredParentObjects)
		{
			_ignoredParentObjects.Clear();
			foreach (GameObject ignoredParentObject in ignoredParentObjects)
			{
				_ignoredParentObjects.Add(ignoredParentObject);
			}
		}

		public void SetExtrudeSpace(GizmoSpace extrudeSpace)
		{
			if (extrudeSpace != _extrudeSpace && !base.Gizmo.IsDragged)
			{
				_extrudeSpace = extrudeSpace;
				FitBoxToTargets();
			}
		}

		public void SetExtrudeTargets(IEnumerable<GameObject> extrudeTargets)
		{
			if (extrudeTargets == null)
			{
				_targetParents.Clear();
				_boxSize = Vector3.zero;
			}
			else
			{
				_targetParents = GameObjectEx.FilterParentsOnly(extrudeTargets);
				FitBoxToTargets();
			}
		}

		public void FitBoxToTargets()
		{
			if (NumTargetParents == 0)
			{
				_boxSize = Vector3.zero;
			}
			else if (ExtrudeSpace == GizmoSpace.Global)
			{
				AABB aABB = AABB.GetInvalid();
				foreach (GameObject targetParent in _targetParents)
				{
					if (_ignoredParentObjects.Contains(targetParent))
					{
						continue;
					}
					AABB aABB2 = ObjectBounds.CalcHierarchyWorldAABB(targetParent, _boundsQConfig);
					if (aABB2.IsValid)
					{
						if (aABB.IsValid)
						{
							aABB.Encapsulate(aABB2);
						}
						else
						{
							aABB = aABB2;
						}
					}
				}
				SetAABB(aABB);
				UpdateSnapSteps();
			}
			else
			{
				if (ExtrudeSpace != GizmoSpace.Local)
				{
					return;
				}
				int i;
				for (i = 0; i < NumTargetParents && _ignoredParentObjects.Contains(_targetParents[i]); i++)
				{
				}
				if (i == NumTargetParents)
				{
					SetOBB(OBB.GetInvalid());
					UpdateSnapSteps();
					return;
				}
				OBB oBB = ObjectBounds.CalcHierarchyWorldOBB(_targetParents[i], _boundsQConfig);
				for (int j = i; j < NumTargetParents; j++)
				{
					GameObject gameObject = _targetParents[j];
					if (_ignoredParentObjects.Contains(gameObject))
					{
						continue;
					}
					OBB oBB2 = ObjectBounds.CalcHierarchyWorldOBB(gameObject, _boundsQConfig);
					if (oBB2.IsValid)
					{
						if (oBB.IsValid)
						{
							oBB.Encapsulate(oBB2);
						}
						else
						{
							oBB = oBB2;
						}
					}
				}
				SetOBB(oBB);
				UpdateSnapSteps();
			}
		}

		public override void OnDetached()
		{
			MonoSingleton<RTUndoRedo>.Get.UndoEnd -= OnUndoRedoEnd;
			MonoSingleton<RTUndoRedo>.Get.RedoEnd -= OnUndoRedoEnd;
			base.Gizmo.Transform.Changed -= OnGizmoTransformChanged;
		}

		public override void OnEnabled()
		{
			base.Gizmo.Transform.Changed += OnGizmoTransformChanged;
		}

		public override void OnDisabled()
		{
			base.Gizmo.Transform.Changed -= OnGizmoTransformChanged;
		}

		public override void OnGizmoEnabled()
		{
			OnGizmoUpdateBegin();
		}

		public override void OnAttached()
		{
			MonoSingleton<RTUndoRedo>.Get.UndoEnd += OnUndoRedoEnd;
			MonoSingleton<RTUndoRedo>.Get.RedoEnd += OnUndoRedoEnd;
			_rightExtrude = new GizmoLineSlider3D(base.Gizmo, GizmoHandleId.ExtrudeSliderRight, GizmoHandleId.ExtrudeCapRight);
			_rightExtrude.SetDragChannel(GizmoDragChannel.Offset);
			_leftExtrude = new GizmoLineSlider3D(base.Gizmo, GizmoHandleId.ExtrudeSliderLeft, GizmoHandleId.ExtrudeCapLeft);
			_leftExtrude.SetDragChannel(GizmoDragChannel.Offset);
			_upExtrude = new GizmoLineSlider3D(base.Gizmo, GizmoHandleId.ExtrudeSliderTop, GizmoHandleId.ExtrudeCapTop);
			_upExtrude.SetDragChannel(GizmoDragChannel.Offset);
			_bottomExtrude = new GizmoLineSlider3D(base.Gizmo, GizmoHandleId.ExtrudeSliderBottom, GizmoHandleId.ExtrudeCapBottom);
			_bottomExtrude.SetDragChannel(GizmoDragChannel.Offset);
			_frontExtrude = new GizmoLineSlider3D(base.Gizmo, GizmoHandleId.ExtrudeSliderBack, GizmoHandleId.ExtrudeCapBack);
			_frontExtrude.SetDragChannel(GizmoDragChannel.Offset);
			_backExtrude = new GizmoLineSlider3D(base.Gizmo, GizmoHandleId.ExtrudeSliderFront, GizmoHandleId.ExtrudeCapFront);
			_backExtrude.SetDragChannel(GizmoDragChannel.Offset);
			_extrudeSliders.Add(_rightExtrude);
			_extrudeSliders.Add(_upExtrude);
			_extrudeSliders.Add(_frontExtrude);
			_extrudeSliders.Add(_leftExtrude);
			_extrudeSliders.Add(_bottomExtrude);
			_extrudeSliders.Add(_backExtrude);
			_extrudeSliders.SetSnapEnabled(isEnabled: true);
			_boundsQConfig.ObjectTypes = GameObjectType.Mesh | GameObjectType.Sprite;
			_boundsQConfig.NoVolumeSize = Vector3.zero;
			_sceneOverlapFilter.AllowedObjectTypes.Add(GameObjectType.Mesh);
			_sceneOverlapFilter.AllowedObjectTypes.Add(GameObjectType.Sprite);
			ValidateBoxSize();
			SetupSharedLookAndFeel();
		}

		public override void OnGizmoUpdateBegin()
		{
			ValidateBoxSize();
			UpdateExtrudeSliderTransforms();
			if (!LookAndFeel3D.IsExtrudeSliderVisible(0, AxisSign.Positive))
			{
				_rightExtrude.Set3DCapVisible(isVisible: false);
			}
			if (!LookAndFeel3D.IsExtrudeSliderVisible(1, AxisSign.Positive))
			{
				_upExtrude.Set3DCapVisible(isVisible: false);
			}
			if (!LookAndFeel3D.IsExtrudeSliderVisible(2, AxisSign.Positive))
			{
				_frontExtrude.Set3DCapVisible(isVisible: false);
			}
			if (!LookAndFeel3D.IsExtrudeSliderVisible(0, AxisSign.Negative))
			{
				_leftExtrude.Set3DCapVisible(isVisible: false);
			}
			if (!LookAndFeel3D.IsExtrudeSliderVisible(1, AxisSign.Negative))
			{
				_bottomExtrude.Set3DCapVisible(isVisible: false);
			}
			if (!LookAndFeel3D.IsExtrudeSliderVisible(2, AxisSign.Negative))
			{
				_backExtrude.Set3DCapVisible(isVisible: false);
			}
		}

		public override void OnGizmoRender(Camera camera)
		{
			GizmoLineMaterial get = Singleton<GizmoLineMaterial>.Get;
			get.ResetValuesToSensibleDefaults();
			get.SetColor(LookAndFeel3D.BoxWireColor);
			get.SetPass(0);
			GraphicsEx.DrawWireBox(OBB);
			if (MonoSingleton<RTGizmosEngine>.Get.NumRenderCameras > 1)
			{
				_extrudeSliders.ApplyZoomFactor(camera);
				UpdateExtrudeSliderTransforms();
			}
			foreach (GizmoLineSlider3D renderSortedSlider in _extrudeSliders.GetRenderSortedSliders(camera))
			{
				renderSortedSlider.Render(camera);
			}
		}

		public override void OnGizmoDragBegin(int handleId)
		{
			if (!OwnsHandle(handleId))
			{
				return;
			}
			_sceneOverlapFilter.IgnoreObjects.Clear();
			foreach (GameObject targetParent in _targetParents)
			{
				_sceneOverlapFilter.IgnoreObjects.AddRange(targetParent.GetAllChildrenAndSelf());
			}
			_dragEndAction = new ObjectExtrudeGizmoDragEnd();
			_dragEndAction.SetTargetParents(_targetParents);
			_dragEndAction.TakeUndoTargetSnapshots();
			_handleDragExtrData.ExtrudeCenter = BoxCenter;
			if (IsLeftExtrudeHandle(handleId))
			{
				_handleDragExtrData.AxisIndex = 0;
				_handleDragExtrData.ExtrudeDir = -BoxRight;
			}
			else if (IsRightExtrudeHandle(handleId))
			{
				_handleDragExtrData.AxisIndex = 0;
				_handleDragExtrData.ExtrudeDir = BoxRight;
			}
			else if (IsTopExtrudeHandle(handleId))
			{
				_handleDragExtrData.AxisIndex = 1;
				_handleDragExtrData.ExtrudeDir = BoxUp;
			}
			else if (IsBottomExtrudeHandle(handleId))
			{
				_handleDragExtrData.AxisIndex = 1;
				_handleDragExtrData.ExtrudeDir = -BoxUp;
			}
			else if (IsFrontExtrudeHandle(handleId))
			{
				_handleDragExtrData.AxisIndex = 2;
				_handleDragExtrData.ExtrudeDir = -BoxLook;
			}
			else if (IsBackExtrudeHandle(handleId))
			{
				_handleDragExtrData.AxisIndex = 2;
				_handleDragExtrData.ExtrudeDir = BoxLook;
			}
		}

		public override void OnGizmoDragUpdate(int handleId)
		{
			if (!OwnsHandle(handleId) || base.Gizmo.RelativeDragOffset.magnitude == 0f)
			{
				return;
			}
			float magnitude = base.Gizmo.RelativeDragOffset.magnitude;
			float num = _boxSize[_handleDragExtrData.AxisIndex];
			float num2 = ((num != 0f) ? (magnitude / num) : 0f);
			int num3 = (int)num2;
			float num4 = Mathf.Abs(num2 - (float)(int)num2);
			if (num3 == 0 && Mathf.Abs(num4 - 1f) < 1E-05f)
			{
				num3++;
			}
			List<GameObject> list = new List<GameObject>(10);
			ObjectCloning.Config defaultConfig = ObjectCloning.DefaultConfig;
			Vector3 vector = _handleDragExtrData.ExtrudeDir * num;
			for (int i = 0; i < num3; i++)
			{
				foreach (GameObject targetParent in _targetParents)
				{
					if (_ignoredParentObjects.Contains(targetParent))
					{
						continue;
					}
					if (!Hotkeys.EnableOverlapTest.IsActive())
					{
						defaultConfig.Parent = targetParent.transform.parent;
						GameObject gameObject = ObjectCloning.CloneHierarchy(targetParent, defaultConfig);
						if (gameObject != null)
						{
							_sceneOverlapFilter.IgnoreObjects.AddRange(gameObject.GetAllChildrenAndSelf());
							_dragEndAction.AddExtrudeClone(gameObject);
							list.Add(gameObject);
						}
						gameObject.transform.position += i * vector;
						continue;
					}
					OBB obb = ObjectBounds.CalcHierarchyWorldOBB(targetParent, _boundsQConfig);
					if (!obb.IsValid)
					{
						continue;
					}
					obb.Center += i * vector;
					obb.Inflate(-0.01f);
					if (MonoSingleton<RTScene>.Get.OverlapBox(obb, _sceneOverlapFilter).Count == 0)
					{
						defaultConfig.Parent = targetParent.transform.parent;
						GameObject gameObject2 = ObjectCloning.CloneHierarchy(targetParent, defaultConfig);
						if (gameObject2 != null)
						{
							_sceneOverlapFilter.IgnoreObjects.AddRange(gameObject2.GetAllChildrenAndSelf());
							_dragEndAction.AddExtrudeClone(gameObject2);
							list.Add(gameObject2);
						}
						gameObject2.transform.position += i * vector;
					}
				}
			}
			_handleDragExtrData.ExtrudeCenter += base.Gizmo.RelativeDragOffset;
			foreach (GameObject targetParent2 in _targetParents)
			{
				if (!_ignoredParentObjects.Contains(targetParent2))
				{
					targetParent2.transform.position += base.Gizmo.RelativeDragOffset;
				}
			}
			if (this.ExtrudeUpdate != null)
			{
				this.ExtrudeUpdate(list);
			}
		}

		public override void OnGizmoDragEnd(int handleId)
		{
			if (OwnsHandle(handleId))
			{
				_dragEndAction.TakeRedoTargetSnapshots();
				_dragEndAction.Execute();
			}
		}

		private void UpdateExtrudeSliderTransforms()
		{
			Vector3 boxCenter = BoxCenter;
			Quaternion boxRotation = BoxRotation;
			_leftExtrude.StartPosition = BoxMath.CalcBoxFaceCenter(boxCenter, _boxSize, boxRotation, BoxFace.Left);
			_leftExtrude.SetDirection(-BoxRight);
			_rightExtrude.StartPosition = BoxMath.CalcBoxFaceCenter(boxCenter, _boxSize, boxRotation, BoxFace.Right);
			_rightExtrude.SetDirection(BoxRight);
			_upExtrude.StartPosition = BoxMath.CalcBoxFaceCenter(boxCenter, _boxSize, boxRotation, BoxFace.Top);
			_upExtrude.SetDirection(BoxUp);
			_bottomExtrude.StartPosition = BoxMath.CalcBoxFaceCenter(boxCenter, _boxSize, boxRotation, BoxFace.Bottom);
			_bottomExtrude.SetDirection(-BoxUp);
			_backExtrude.StartPosition = BoxMath.CalcBoxFaceCenter(boxCenter, _boxSize, boxRotation, BoxFace.Front);
			_backExtrude.SetDirection(-BoxLook);
			_frontExtrude.StartPosition = BoxMath.CalcBoxFaceCenter(boxCenter, _boxSize, boxRotation, BoxFace.Back);
			_frontExtrude.SetDirection(BoxLook);
		}

		private void OnGizmoTransformChanged(GizmoTransform gizmoTransform, GizmoTransform.ChangeData changeData)
		{
			UpdateExtrudeSliderTransforms();
		}

		private void SetAABB(AABB aabb)
		{
			if (!aabb.IsValid)
			{
				_boxSize = Vector3.zero;
				return;
			}
			_boxSize = aabb.Size.Abs();
			base.Gizmo.Transform.Rotation3D = Quaternion.identity;
			base.Gizmo.Transform.Position3D = aabb.Center;
		}

		private void SetOBB(OBB obb)
		{
			if (!obb.IsValid)
			{
				_boxSize = Vector3.zero;
				return;
			}
			_boxSize = obb.Size.Abs();
			base.Gizmo.Transform.Rotation3D = obb.Rotation;
			base.Gizmo.Transform.Position3D = obb.Center;
		}

		private void UpdateSnapSteps()
		{
			_rightExtrude.Settings.OffsetSnapStep = _boxSize.x;
			_leftExtrude.Settings.OffsetSnapStep = _boxSize.x;
			_upExtrude.Settings.OffsetSnapStep = _boxSize.y;
			_bottomExtrude.Settings.OffsetSnapStep = _boxSize.y;
			_frontExtrude.Settings.OffsetSnapStep = _boxSize.z;
			_backExtrude.Settings.OffsetSnapStep = _boxSize.z;
		}

		private void ValidateBoxSize()
		{
			Vector3 boxSize = _boxSize;
			if (Mathf.Abs(boxSize.x) < 1E-05f)
			{
				_rightExtrude.Set3DCapVisible(isVisible: false);
				_leftExtrude.Set3DCapVisible(isVisible: false);
			}
			else
			{
				_rightExtrude.Set3DCapVisible(isVisible: true);
				_leftExtrude.Set3DCapVisible(isVisible: true);
			}
			if (Mathf.Abs(boxSize.y) < 1E-05f)
			{
				_upExtrude.Set3DCapVisible(isVisible: false);
				_bottomExtrude.Set3DCapVisible(isVisible: false);
			}
			else
			{
				_upExtrude.Set3DCapVisible(isVisible: true);
				_bottomExtrude.Set3DCapVisible(isVisible: true);
			}
			if (Mathf.Abs(boxSize.z) < 1E-05f)
			{
				_frontExtrude.Set3DCapVisible(isVisible: false);
				_backExtrude.Set3DCapVisible(isVisible: false);
			}
			else
			{
				_frontExtrude.Set3DCapVisible(isVisible: true);
				_backExtrude.Set3DCapVisible(isVisible: true);
			}
		}

		private void SetupSharedLookAndFeel()
		{
			LookAndFeel3D.ConnectSliderLookAndFeel(_rightExtrude, 0, AxisSign.Positive);
			LookAndFeel3D.ConnectSliderLookAndFeel(_upExtrude, 1, AxisSign.Positive);
			LookAndFeel3D.ConnectSliderLookAndFeel(_frontExtrude, 2, AxisSign.Positive);
			LookAndFeel3D.ConnectSliderLookAndFeel(_leftExtrude, 0, AxisSign.Negative);
			LookAndFeel3D.ConnectSliderLookAndFeel(_bottomExtrude, 1, AxisSign.Negative);
			LookAndFeel3D.ConnectSliderLookAndFeel(_backExtrude, 2, AxisSign.Negative);
		}

		private void OnUndoRedoEnd(IUndoRedoAction action)
		{
			if (action is ObjectExtrudeGizmoDragEnd)
			{
				FitBoxToTargets();
			}
		}
	}
}
