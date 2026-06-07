using System;
using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class BoxGizmo : GizmoBehaviour
	{
		public enum Usage
		{
			Generic = 0,
			ObjectScale = 1
		}

		private Usage _usage;

		private bool _isUsagePermanent;

		private Vector3 _boxSize;

		private GameObject _targetHierarchy;

		private Transform _targetHierarchyTransform;

		private LocalTransformSnapshot _dragBeginTargetTransformSnapshot = new LocalTransformSnapshot();

		private GizmoCap2D _rightTick;

		private GizmoCap2D _topTick;

		private GizmoCap2D _backTick;

		private GizmoCap2D _leftTick;

		private GizmoCap2D _bottomTick;

		private GizmoCap2D _frontTick;

		private GizmoCap2DCollection _ticks = new GizmoCap2DCollection();

		private bool _scaleFromCenter;

		private Vector3 _scalePivot;

		private GizmoSglAxisScaleDrag3D.WorkData _scaleDragWorkData;

		private GizmoSglAxisScaleDrag3D _scaleDrag = new GizmoSglAxisScaleDrag3D();

		[SerializeField]
		private BoxGizmoSettings3D _settings3D = new BoxGizmoSettings3D();

		private BoxGizmoSettings3D _sharedSettings3D;

		[SerializeField]
		private BoxGizmoLookAndFeel3D _lookAndFeel3D = new BoxGizmoLookAndFeel3D();

		private BoxGizmoLookAndFeel3D _sharedLookAndFeel3D;

		private BoxGizmoHotkeys _hotkeys = new BoxGizmoHotkeys();

		private BoxGizmoHotkeys _sharedHotkeys;

		public BoxGizmoSettings3D Settings3D
		{
			get
			{
				if (_sharedSettings3D != null)
				{
					return _sharedSettings3D;
				}
				return _settings3D;
			}
		}

		public BoxGizmoSettings3D SharedSettings3D
		{
			get
			{
				return _sharedSettings3D;
			}
			set
			{
				_sharedSettings3D = value;
				SetupSharedSettings();
			}
		}

		public BoxGizmoLookAndFeel3D LookAndFeel3D
		{
			get
			{
				if (_sharedLookAndFeel3D != null)
				{
					return _sharedLookAndFeel3D;
				}
				return _lookAndFeel3D;
			}
		}

		public BoxGizmoLookAndFeel3D SharedLookAndFeel3D
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

		public BoxGizmoHotkeys Hotkeys
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

		public BoxGizmoHotkeys SharedHotkeys
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

		public Usage BoxUsage => _usage;

		public bool IsUsagePermanent => _isUsagePermanent;

		public Vector3 BoxCenter => base.Gizmo.Transform.Position3D;

		public Quaternion BoxRotation => base.Gizmo.Transform.Rotation3D;

		public Vector3 BoxRight => BoxRotation * Vector3.right;

		public Vector3 BoxUp => BoxRotation * Vector3.up;

		public Vector3 BoxLook => BoxRotation * Vector3.forward;

		public override void OnDetached()
		{
			base.Gizmo.Transform.Changed -= OnGizmoTransformChanged;
			MonoSingleton<RTUndoRedo>.Get.UndoEnd -= OnUndoRedoEnd;
			MonoSingleton<RTUndoRedo>.Get.RedoEnd -= OnUndoRedoEnd;
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

		public void MakeUsagePermanent()
		{
			_isUsagePermanent = true;
		}

		public bool OwnsHandle(int handleId)
		{
			return _ticks.Contains(handleId);
		}

		public bool IsXTick(int handleId)
		{
			if (handleId != _leftTick.HandleId)
			{
				return handleId == _rightTick.HandleId;
			}
			return true;
		}

		public bool IsYTick(int handleId)
		{
			if (handleId != _topTick.HandleId)
			{
				return handleId == _bottomTick.HandleId;
			}
			return true;
		}

		public bool IsZTick(int handleId)
		{
			if (handleId != _frontTick.HandleId)
			{
				return handleId == _backTick.HandleId;
			}
			return true;
		}

		public void SetSnapEnabled(bool isEnabled)
		{
			_scaleDrag.IsSnapEnabled = isEnabled;
		}

		public void SetSize(Vector3 size)
		{
			if (!base.Gizmo.IsDragged && BoxUsage == Usage.Generic)
			{
				_boxSize = size;
				UpdateTickPositions();
			}
		}

		public void SetUsage(Usage usage)
		{
			if (!base.Gizmo.IsDragged && !IsUsagePermanent && usage != _usage)
			{
				_usage = usage;
				if (_usage == Usage.Generic)
				{
					_ticks.SetVisible(visible: true);
					_ticks.SetHoverable(hoverable: true);
				}
			}
		}

		public bool SetTargetHierarchy(GameObject targetHierarchy)
		{
			if (BoxUsage == Usage.ObjectScale && !base.Gizmo.IsDragged && targetHierarchy != null)
			{
				_targetHierarchy = targetHierarchy;
				_targetHierarchyTransform = _targetHierarchy.transform;
				if (!FitBoxToTargetHierarchy())
				{
					_targetHierarchy = null;
					_targetHierarchyTransform = null;
					return false;
				}
				return true;
			}
			if (BoxUsage == Usage.ObjectScale)
			{
				if (_targetHierarchy != null)
				{
					_ticks.SetVisible(visible: true);
					_ticks.SetHoverable(hoverable: true);
				}
				else
				{
					_ticks.SetVisible(visible: false);
					_ticks.SetHoverable(hoverable: false);
				}
			}
			return false;
		}

		public bool FitBoxToTargetHierarchy()
		{
			if (BoxUsage == Usage.ObjectScale)
			{
				if (_targetHierarchy == null)
				{
					_boxSize = Vector3.zero;
					return false;
				}
				OBB oBB = CalcTargetRootOBB(_targetHierarchy);
				if (!oBB.IsValid)
				{
					_boxSize = Vector3.zero;
					return false;
				}
				_boxSize = oBB.Size;
				base.Gizmo.Transform.Position3D = oBB.Center;
				base.Gizmo.Transform.Rotation3D = _targetHierarchy.transform.rotation;
				return true;
			}
			_boxSize = Vector3.zero;
			return false;
		}

		public override void OnAttached()
		{
			MonoSingleton<RTUndoRedo>.Get.UndoEnd += OnUndoRedoEnd;
			MonoSingleton<RTUndoRedo>.Get.RedoEnd += OnUndoRedoEnd;
			_leftTick = new GizmoCap2D(base.Gizmo, GizmoHandleId.BoxTickLeftCenter);
			_rightTick = new GizmoCap2D(base.Gizmo, GizmoHandleId.BoxTickRightCenter);
			_topTick = new GizmoCap2D(base.Gizmo, GizmoHandleId.BoxTickTopCenter);
			_bottomTick = new GizmoCap2D(base.Gizmo, GizmoHandleId.BoxTickBottomCenter);
			_backTick = new GizmoCap2D(base.Gizmo, GizmoHandleId.BoxTickBackCenter);
			_frontTick = new GizmoCap2D(base.Gizmo, GizmoHandleId.BoxTickFrontCenter);
			_ticks.Add(_leftTick);
			_ticks.Add(_rightTick);
			_ticks.Add(_topTick);
			_ticks.Add(_bottomTick);
			_ticks.Add(_backTick);
			_ticks.Add(_frontTick);
			_ticks.SetDragSession(_scaleDrag);
			SetupSharedLookAndFeel();
			SetupSharedSettings();
		}

		public override bool OnGizmoCanBeginDrag(int handleId)
		{
			if (BoxUsage == Usage.ObjectScale && _targetHierarchy != null)
			{
				IRTTransformGizmoListener component = _targetHierarchy.GetComponent<IRTTransformGizmoListener>();
				if (component != null)
				{
					return component.OnCanBeTransformed(base.Gizmo);
				}
			}
			return true;
		}

		public override void OnGizmoUpdateBegin()
		{
			SetSnapEnabled(!Hotkeys.EnableSnapping.IsActive());
			_scaleDrag.Sensitivity = Settings3D.DragSensitivity;
			UpdateTickPositions();
			ValidateBoxSize();
		}

		public override void OnGizmoRender(Camera camera)
		{
			GizmoLineMaterial get = Singleton<GizmoLineMaterial>.Get;
			get.ResetValuesToSensibleDefaults();
			get.SetColor(LookAndFeel3D.BoxWireColor);
			get.SetPass(0);
			GraphicsEx.DrawWireBox(new OBB(BoxCenter, _boxSize, BoxRotation));
			if (MonoSingleton<RTGizmosEngine>.Get.NumRenderCameras > 1)
			{
				UpdateTickPositions();
			}
			_leftTick.Render(camera);
			_rightTick.Render(camera);
			_topTick.Render(camera);
			_bottomTick.Render(camera);
			_frontTick.Render(camera);
			_backTick.Render(camera);
		}

		public override void OnGizmoAttemptHandleDragBegin(int handleId)
		{
			if (OwnsHandle(handleId))
			{
				_scaleFromCenter = Hotkeys.EnableCenterPivot.IsActive();
				_scaleDragWorkData.DragOrigin = BoxCenter;
				if (handleId == _leftTick.HandleId)
				{
					_scaleDragWorkData.Axis = -BoxRight;
					_scaleDragWorkData.AxisIndex = 0;
					_scaleDragWorkData.SnapStep = Settings3D.XSnapStep;
					_scaleDragWorkData.EntityScale = _targetHierarchyTransform.lossyScale.x;
					_scalePivot = BoxMath.CalcBoxFaceCenter(BoxCenter, _boxSize, BoxRotation, BoxFace.Right);
				}
				else if (handleId == _rightTick.HandleId)
				{
					_scaleDragWorkData.Axis = BoxRight;
					_scaleDragWorkData.AxisIndex = 0;
					_scaleDragWorkData.SnapStep = Settings3D.XSnapStep;
					_scaleDragWorkData.EntityScale = _targetHierarchyTransform.lossyScale.x;
					_scalePivot = BoxMath.CalcBoxFaceCenter(BoxCenter, _boxSize, BoxRotation, BoxFace.Left);
				}
				else if (handleId == _topTick.HandleId)
				{
					_scaleDragWorkData.Axis = BoxUp;
					_scaleDragWorkData.AxisIndex = 1;
					_scaleDragWorkData.SnapStep = Settings3D.YSnapStep;
					_scaleDragWorkData.EntityScale = _targetHierarchyTransform.lossyScale.y;
					_scalePivot = BoxMath.CalcBoxFaceCenter(BoxCenter, _boxSize, BoxRotation, BoxFace.Bottom);
				}
				else if (handleId == _bottomTick.HandleId)
				{
					_scaleDragWorkData.Axis = -BoxUp;
					_scaleDragWorkData.AxisIndex = 1;
					_scaleDragWorkData.SnapStep = Settings3D.YSnapStep;
					_scaleDragWorkData.EntityScale = _targetHierarchyTransform.lossyScale.y;
					_scalePivot = BoxMath.CalcBoxFaceCenter(BoxCenter, _boxSize, BoxRotation, BoxFace.Top);
				}
				else if (handleId == _frontTick.HandleId)
				{
					_scaleDragWorkData.Axis = -BoxLook;
					_scaleDragWorkData.AxisIndex = 2;
					_scaleDragWorkData.SnapStep = Settings3D.ZSnapStep;
					_scaleDragWorkData.EntityScale = _targetHierarchyTransform.lossyScale.z;
					_scalePivot = BoxMath.CalcBoxFaceCenter(BoxCenter, _boxSize, BoxRotation, BoxFace.Back);
				}
				else if (handleId == _backTick.HandleId)
				{
					_scaleDragWorkData.Axis = BoxLook;
					_scaleDragWorkData.AxisIndex = 2;
					_scaleDragWorkData.SnapStep = Settings3D.ZSnapStep;
					_scaleDragWorkData.EntityScale = _targetHierarchyTransform.lossyScale.z;
					_scalePivot = BoxMath.CalcBoxFaceCenter(BoxCenter, _boxSize, BoxRotation, BoxFace.Front);
				}
				if (_scaleFromCenter)
				{
					_scalePivot = BoxCenter;
				}
				_scaleDrag.SetWorkData(_scaleDragWorkData);
				if (BoxUsage == Usage.ObjectScale && _targetHierarchyTransform != null)
				{
					_dragBeginTargetTransformSnapshot.Snapshot(_targetHierarchyTransform);
				}
			}
		}

		public override void OnGizmoDragUpdate(int handleId)
		{
			if (!OwnsHandle(handleId))
			{
				return;
			}
			if (BoxUsage == Usage.Generic)
			{
				_boxSize = Vector3.Scale(_boxSize, base.Gizmo.RelativeDragScale.ReplaceInfinites(1f));
				if (!_scaleFromCenter)
				{
					base.Gizmo.Transform.Position3D = _scalePivot + _scaleDragWorkData.Axis * _boxSize[_scaleDragWorkData.AxisIndex] * 0.5f;
				}
			}
			else if (BoxUsage == Usage.ObjectScale && _targetHierarchy != null)
			{
				_targetHierarchyTransform.ScaleFromPivot(base.Gizmo.RelativeDragScale.ReplaceInfinites(1f), _scalePivot);
				FitBoxToTargetHierarchy();
				_targetHierarchy.GetComponent<IRTTransformGizmoListener>()?.OnTransformed(base.Gizmo);
			}
			UpdateTickPositions();
			ValidateBoxSize();
		}

		public override void OnGizmoDragEnd(int handleId)
		{
			if (OwnsHandle(handleId) && BoxUsage == Usage.ObjectScale && _targetHierarchyTransform != null)
			{
				LocalTransformSnapshot localTransformSnapshot = new LocalTransformSnapshot();
				localTransformSnapshot.Snapshot(_targetHierarchyTransform);
				List<LocalTransformSnapshot> list = new List<LocalTransformSnapshot>();
				list.Add(_dragBeginTargetTransformSnapshot);
				new PostObjectTransformsChangedAction(list, new List<LocalTransformSnapshot> { localTransformSnapshot }).Execute();
			}
		}

		private void OnUndoRedoEnd(IUndoRedoAction action)
		{
			if (action is PostObjectTransformsChangedAction)
			{
				FitBoxToTargetHierarchy();
			}
		}

		private void UpdateTickPositions()
		{
			Camera workCamera = base.Gizmo.GetWorkCamera();
			Vector3 boxCenter = BoxCenter;
			Quaternion boxRotation = BoxRotation;
			Vector3 position = BoxMath.CalcBoxFaceCenter(boxCenter, _boxSize, boxRotation, BoxFace.Left);
			_leftTick.Position = workCamera.WorldToScreenPoint(position);
			position = BoxMath.CalcBoxFaceCenter(boxCenter, _boxSize, boxRotation, BoxFace.Right);
			_rightTick.Position = workCamera.WorldToScreenPoint(position);
			position = BoxMath.CalcBoxFaceCenter(boxCenter, _boxSize, boxRotation, BoxFace.Top);
			_topTick.Position = workCamera.WorldToScreenPoint(position);
			position = BoxMath.CalcBoxFaceCenter(boxCenter, _boxSize, boxRotation, BoxFace.Bottom);
			_bottomTick.Position = workCamera.WorldToScreenPoint(position);
			position = BoxMath.CalcBoxFaceCenter(boxCenter, _boxSize, boxRotation, BoxFace.Front);
			_frontTick.Position = workCamera.WorldToScreenPoint(position);
			position = BoxMath.CalcBoxFaceCenter(boxCenter, _boxSize, boxRotation, BoxFace.Back);
			_backTick.Position = workCamera.WorldToScreenPoint(position);
		}

		private void ValidateBoxSize()
		{
			Vector3 boxSize = _boxSize;
			if (Mathf.Abs(boxSize.x) < 1E-05f)
			{
				_leftTick.SetVisible(isVisible: false);
				_rightTick.SetVisible(isVisible: false);
			}
			else
			{
				_leftTick.SetVisible(isVisible: true);
				_rightTick.SetVisible(isVisible: true);
			}
			if (Mathf.Abs(boxSize.y) < 1E-05f)
			{
				_topTick.SetVisible(isVisible: false);
				_bottomTick.SetVisible(isVisible: false);
			}
			else
			{
				_topTick.SetVisible(isVisible: true);
				_bottomTick.SetVisible(isVisible: true);
			}
			if (Mathf.Abs(boxSize.z) < 1E-05f)
			{
				_backTick.SetVisible(isVisible: false);
				_frontTick.SetVisible(isVisible: false);
			}
			else
			{
				_backTick.SetVisible(isVisible: true);
				_frontTick.SetVisible(isVisible: true);
			}
		}

		private void SetupSharedLookAndFeel()
		{
			LookAndFeel3D.ConnectTickLookAndFeel(_rightTick, 0, AxisSign.Positive);
			LookAndFeel3D.ConnectTickLookAndFeel(_topTick, 1, AxisSign.Positive);
			LookAndFeel3D.ConnectTickLookAndFeel(_backTick, 2, AxisSign.Positive);
			LookAndFeel3D.ConnectTickLookAndFeel(_leftTick, 0, AxisSign.Negative);
			LookAndFeel3D.ConnectTickLookAndFeel(_bottomTick, 1, AxisSign.Negative);
			LookAndFeel3D.ConnectTickLookAndFeel(_frontTick, 2, AxisSign.Negative);
		}

		private void SetupSharedSettings()
		{
		}

		private void OnGizmoTransformChanged(GizmoTransform gizmoTransform, GizmoTransform.ChangeData changeData)
		{
			UpdateTickPositions();
		}

		private OBB CalcTargetRootOBB(GameObject targetRoot)
		{
			return ObjectBounds.CalcHierarchyWorldOBB(targetRoot, new ObjectBounds.QueryConfig
			{
				ObjectTypes = (GameObjectType.Mesh | GameObjectType.Sprite)
			});
		}
	}
}
