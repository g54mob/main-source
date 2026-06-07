using System;
using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class Gizmo
	{
		private bool _isEnabled = true;

		private GizmoHandleCollection _handles;

		private GizmoBehaviourCollection _behaviours = new GizmoBehaviourCollection();

		private GizmoHoverInfo _hoverInfo;

		private GizmoDragInfo _dragInfo;

		private IGizmoHandle _hoveredHandle;

		private Priority _genericHoverPriority = new Priority();

		private Priority _hoverPriority3D = new Priority();

		private Priority _hoverPriority2D = new Priority();

		private IGizmoDragSession _activeDragSession;

		private GizmoTransform _transform = new GizmoTransform();

		[NonSerialized]
		private MoveGizmo _moveGizmo;

		[NonSerialized]
		private RotationGizmo _rotationGizmo;

		[NonSerialized]
		private ScaleGizmo _scaleGizmo;

		[NonSerialized]
		private UniversalGizmo _universalGizmo;

		[NonSerialized]
		private ObjectTransformGizmo _objectTransformGizmo;

		[NonSerialized]
		private BoxGizmo _boxGizmo;

		[NonSerialized]
		private ObjectExtrudeGizmo _objectExtrudeGizmo;

		[NonSerialized]
		private SceneGizmo _sceneGizmo;

		public static int InputDeviceDragButtonIndex => 0;

		public int NumHandles => _handles.Count;

		public Camera FocusCamera
		{
			get
			{
				if (SceneGizmo != null)
				{
					return SceneGizmo.SceneGizmoCamera.Camera;
				}
				return MonoSingleton<RTFocusCamera>.Get.TargetCamera;
			}
		}

		public bool IsEnabled => _isEnabled;

		public Priority GenericHoverPriority => _genericHoverPriority;

		public Priority HoverPriority3D => _hoverPriority3D;

		public Priority HoverPriority2D => _hoverPriority2D;

		public GizmoTransform Transform => _transform;

		public GizmoHoverInfo HoverInfo => _hoverInfo;

		public bool IsHovered => _hoverInfo.IsHovered;

		public int HoverHandleId => _hoverInfo.HandleId;

		public GizmoDimension HoverHandleDimension => _hoverInfo.HandleDimension;

		public Vector3 HoverPoint => _hoverInfo.HoverPoint;

		public GizmoDragInfo DragInfo => _dragInfo;

		public bool IsDragged => _dragInfo.IsDragged;

		public GizmoDragChannel ActiveDragChannel => _dragInfo.DragChannel;

		public int DragHandleId => _dragInfo.HandleId;

		public Vector3 DragBeginPoint => _dragInfo.DragBeginPoint;

		public GizmoDimension DragHandleDimension => _dragInfo.HandleDimension;

		public Vector3 TotalDragOffset => _dragInfo.TotalOffset;

		public Quaternion TotalDragRotation => _dragInfo.TotalRotation;

		public Vector3 TotalDragScale => _dragInfo.TotalScale;

		public Vector3 RelativeDragOffset => _dragInfo.RelativeOffset;

		public Quaternion RelativeDragRotation => _dragInfo.RelativeRotation;

		public Vector3 RelativeDragScale => _dragInfo.RelativeScale;

		public MoveGizmo MoveGizmo => _moveGizmo;

		public RotationGizmo RotationGizmo => _rotationGizmo;

		public ScaleGizmo ScaleGizmo => _scaleGizmo;

		public UniversalGizmo UniversalGizmo => _universalGizmo;

		public ObjectTransformGizmo ObjectTransformGizmo => _objectTransformGizmo;

		public BoxGizmo BoxGizmo => _boxGizmo;

		public ObjectExtrudeGizmo ObjectExtrudeGizmo => _objectExtrudeGizmo;

		public SceneGizmo SceneGizmo => _sceneGizmo;

		public event GizmoPostEnabledHandler PostEnabled;

		public event GizmoPostDisabledHandler PostDisabled;

		public event GizmoPreUpdateBeginHandler PreUpdateBegin;

		public event GizmoPostUpdateEndHandler PostUpdateEnd;

		public event GizmoPreHoverEnterHandler PreHoverEnter;

		public event GizmoPostHoverEnterHandler PostHoverEnter;

		public event GizmoPreHoverExitHandler PreHoverExit;

		public event GizmoPostHoverExitHandler PostHoverExit;

		public event GizmoPreDragBeginHandler PreDragBegin;

		public event GizmoPostDragBeginHandler PostDragBegin;

		public event GizmoPreDragEndHandler PreDragEnd;

		public event GizmoPostDragEndHandler PostDragEnd;

		public event GizmoPreDragUpdateHandler PreDragUpdate;

		public event GizmoPostDragUpdateHandler PostDragUpdate;

		public event GizmoPreHandlePickedHandler PreHandlePicked;

		public event GizmoPostHandlePickedHandler PostHandlePicked;

		public event GizmoPreDragBeginAttemptHandler PreDragBeginAttempt;

		public event GizmoPostDragBeginAttemptHandler PostDragBeginAttempt;

		public Gizmo()
		{
			_handles = new GizmoHandleCollection(this);
			_hoverInfo.Reset();
			_dragInfo.Reset();
		}

		public Camera GetWorkCamera()
		{
			if (MonoSingleton<RTGizmosEngine>.Get.PipelineStage != GizmosEnginePipelineStage.Render)
			{
				return FocusCamera;
			}
			return MonoSingleton<RTGizmosEngine>.Get.RenderStageCamera;
		}

		public GizmoHandle CreateHandle(int id)
		{
			if (_handles.Contains(id))
			{
				return null;
			}
			GizmoHandle gizmoHandle = new GizmoHandle(this, id);
			_handles.Add(gizmoHandle);
			return gizmoHandle;
		}

		public void SetEnabled(bool enabled)
		{
			if (enabled == _isEnabled)
			{
				return;
			}
			if (!enabled)
			{
				EndDragSession();
				_hoverInfo.Reset();
				_hoveredHandle = null;
				_isEnabled = false;
				foreach (IGizmoBehaviour behaviour in _behaviours)
				{
					if (behaviour.IsEnabled)
					{
						behaviour.OnGizmoDisabled();
					}
				}
				if (this.PostDisabled != null)
				{
					this.PostDisabled(this);
				}
				return;
			}
			_isEnabled = true;
			foreach (IGizmoBehaviour behaviour2 in _behaviours)
			{
				if (behaviour2.IsEnabled)
				{
					behaviour2.OnGizmoEnabled();
				}
			}
			if (this.PostEnabled != null)
			{
				this.PostEnabled(this);
			}
		}

		public BehaviourType AddBehaviour<BehaviourType>() where BehaviourType : class, IGizmoBehaviour, new()
		{
			BehaviourType val = new BehaviourType();
			AddBehaviour(val);
			return val;
		}

		public bool AddBehaviour(IGizmoBehaviour behaviour)
		{
			if (behaviour == null || behaviour.Gizmo != null)
			{
				return false;
			}
			behaviour.Init_SystemCall(new GizmoBehaviorInitParams
			{
				Gizmo = this
			});
			if (!_behaviours.Add(behaviour))
			{
				return false;
			}
			Type type = behaviour.GetType();
			if (type == typeof(MoveGizmo))
			{
				_moveGizmo = behaviour as MoveGizmo;
			}
			else if (type == typeof(RotationGizmo))
			{
				_rotationGizmo = behaviour as RotationGizmo;
			}
			else if (type == typeof(ScaleGizmo))
			{
				_scaleGizmo = behaviour as ScaleGizmo;
			}
			else if (type == typeof(UniversalGizmo))
			{
				_universalGizmo = behaviour as UniversalGizmo;
			}
			else if (type == typeof(SceneGizmo))
			{
				_sceneGizmo = behaviour as SceneGizmo;
			}
			else if (type == typeof(BoxGizmo))
			{
				_boxGizmo = behaviour as BoxGizmo;
			}
			else if (type == typeof(ObjectTransformGizmo))
			{
				_objectTransformGizmo = behaviour as ObjectTransformGizmo;
			}
			else if (type == typeof(ObjectExtrudeGizmo))
			{
				_objectExtrudeGizmo = behaviour as ObjectExtrudeGizmo;
			}
			behaviour.OnAttached();
			behaviour.OnEnabled();
			return true;
		}

		public bool RemoveBehaviour(IGizmoBehaviour behaviour)
		{
			if (behaviour == null)
			{
				return false;
			}
			if (behaviour == _moveGizmo)
			{
				_moveGizmo = null;
			}
			else if (behaviour == _rotationGizmo)
			{
				_rotationGizmo = null;
			}
			else if (behaviour == _scaleGizmo)
			{
				_scaleGizmo = null;
			}
			else if (behaviour == _universalGizmo)
			{
				_universalGizmo = null;
			}
			else if (behaviour == _sceneGizmo)
			{
				_sceneGizmo = null;
			}
			else if (behaviour == _boxGizmo)
			{
				_boxGizmo = null;
			}
			else if (behaviour == _objectTransformGizmo)
			{
				_objectTransformGizmo = null;
			}
			else if (behaviour == _objectExtrudeGizmo)
			{
				_objectExtrudeGizmo = null;
			}
			return _behaviours.Remove(behaviour);
		}

		public List<BehaviourType> GetBehavioursOfType<BehaviourType>() where BehaviourType : class, IGizmoBehaviour
		{
			return _behaviours.GetBehavioursOfType<BehaviourType>();
		}

		public BehaviourType GetFirstBehaviourOfType<BehaviourType>() where BehaviourType : class, IGizmoBehaviour
		{
			return _behaviours.GetFirstBehaviourOfType<BehaviourType>();
		}

		public IGizmoBehaviour GetFirstBehaviourOfType(Type behaviourType)
		{
			return _behaviours.GetFirstBehaviourOfType(behaviourType);
		}

		public List<GizmoHandleHoverData> GetAllHandlesHoverData(Ray hoverRay)
		{
			return _handles.GetAllHandlesHoverData(hoverRay);
		}

		public IGizmoHandle GetHandleById_SystemCall(int handleId)
		{
			return _handles.GetHandleById(handleId);
		}

		public void OnGUI_SystemCall()
		{
			if (!IsEnabled)
			{
				return;
			}
			foreach (IGizmoBehaviour behaviour in _behaviours)
			{
				if (behaviour.IsEnabled)
				{
					behaviour.OnGUI();
				}
			}
		}

		public void OnUpdateBegin_SystemCall()
		{
			if (!IsEnabled)
			{
				return;
			}
			if (this.PreUpdateBegin != null)
			{
				this.PreUpdateBegin(this);
			}
			foreach (IGizmoBehaviour behaviour in _behaviours)
			{
				if (behaviour.IsEnabled)
				{
					behaviour.OnGizmoUpdateBegin();
				}
			}
		}

		public void OnUpdateEnd_SystemCall()
		{
			if (!IsEnabled)
			{
				return;
			}
			foreach (IGizmoBehaviour behaviour in _behaviours)
			{
				if (behaviour.IsEnabled)
				{
					behaviour.OnGizmoUpdateEnd();
				}
			}
			if (this.PostUpdateEnd != null)
			{
				this.PostUpdateEnd(this);
			}
		}

		public void UpdateHandleHoverInfo_SystemCall(GizmoHoverInfo hoverInfo)
		{
			if (!IsEnabled || IsDragged)
			{
				return;
			}
			bool isHovered = _hoverInfo.IsHovered;
			int handleId = _hoverInfo.HandleId;
			_hoverInfo.Reset();
			_hoveredHandle = null;
			if (hoverInfo.IsHovered && hoverInfo.HandleId != GizmoHandleId.None)
			{
				_hoverInfo.IsHovered = true;
				_hoverInfo.HandleId = hoverInfo.HandleId;
				_hoverInfo.HoverPoint = hoverInfo.HoverPoint;
				_hoveredHandle = _handles.GetHandleById(hoverInfo.HandleId);
				_hoverInfo.HandleDimension = hoverInfo.HandleDimension;
			}
			if (isHovered && !_hoverInfo.IsHovered)
			{
				if (this.PreHoverExit != null)
				{
					this.PreHoverExit(this, handleId);
				}
				foreach (IGizmoBehaviour behaviour in _behaviours)
				{
					if (behaviour.IsEnabled)
					{
						behaviour.OnGizmoHoverExit(handleId);
					}
				}
				if (this.PostHoverExit != null)
				{
					this.PostHoverExit(this, handleId);
				}
			}
			else if (!isHovered && _hoverInfo.IsHovered)
			{
				if (this.PreHoverEnter != null)
				{
					this.PreHoverEnter(this, _hoverInfo.HandleId);
				}
				foreach (IGizmoBehaviour behaviour2 in _behaviours)
				{
					if (behaviour2.IsEnabled)
					{
						behaviour2.OnGizmoHoverEnter(_hoverInfo.HandleId);
					}
				}
				if (this.PostHoverEnter != null)
				{
					this.PostHoverEnter(this, _hoverInfo.HandleId);
				}
			}
			else
			{
				if (!isHovered || !_hoverInfo.IsHovered)
				{
					return;
				}
				if (handleId != _hoverInfo.HandleId)
				{
					if (this.PreHoverExit != null)
					{
						this.PreHoverExit(this, handleId);
					}
					foreach (IGizmoBehaviour behaviour3 in _behaviours)
					{
						if (behaviour3.IsEnabled)
						{
							behaviour3.OnGizmoHoverExit(handleId);
						}
					}
					if (this.PostHoverExit != null)
					{
						this.PostHoverExit(this, handleId);
					}
				}
				if (this.PreHoverEnter != null)
				{
					this.PreHoverEnter(this, _hoverInfo.HandleId);
				}
				foreach (IGizmoBehaviour behaviour4 in _behaviours)
				{
					if (behaviour4.IsEnabled)
					{
						behaviour4.OnGizmoHoverEnter(_hoverInfo.HandleId);
					}
				}
				if (this.PostHoverEnter != null)
				{
					this.PostHoverEnter(this, _hoverInfo.HandleId);
				}
			}
		}

		public AABB GetVisible3DHandlesAABB()
		{
			AABB result = AABB.GetInvalid();
			int count = _handles.Count;
			for (int i = 0; i < count; i++)
			{
				AABB visible3DShapesAABB = _handles[i].GetVisible3DShapesAABB();
				if (visible3DShapesAABB.IsValid)
				{
					if (result.IsValid)
					{
						result.Encapsulate(visible3DShapesAABB);
					}
					else
					{
						result = visible3DShapesAABB;
					}
				}
			}
			return result;
		}

		public Rect GetVisible2DHandlesRect(Camera camera)
		{
			List<Vector2> list = new List<Vector2>();
			int count = _handles.Count;
			for (int i = 0; i < count; i++)
			{
				Rect visible2DShapesRect = _handles[i].GetVisible2DShapesRect(camera);
				if (visible2DShapesRect.width != 0f || visible2DShapesRect.height != 0f)
				{
					list.AddRange(visible2DShapesRect.GetCornerPoints());
				}
			}
			if (list.Count != 0)
			{
				return RectEx.FromPoints(list);
			}
			return default(Rect);
		}

		public void Render_SystemCall(Camera camera, Plane[] worldFrustumPlanes)
		{
			if (!IsEnabled || NumHandles == 0)
			{
				return;
			}
			bool flag = MonoSingleton<RTGizmosEngine>.Get.IsSceneGizmoCamera(camera);
			if ((SceneGizmo == null && flag) || (SceneGizmo != null && !flag))
			{
				return;
			}
			foreach (IGizmoBehaviour behaviour in _behaviours)
			{
				if (behaviour.IsEnabled)
				{
					behaviour.OnGizmoRender(camera);
				}
			}
		}

		public void HandleInputDeviceEvents_SystemCall()
		{
			if (IsEnabled)
			{
				IInputDevice device = MonoSingleton<RTInputDevice>.Get.Device;
				if (device.WasButtonPressedInCurrentFrame(InputDeviceDragButtonIndex))
				{
					OnInputDevicePickButtonDown();
				}
				else if (device.WasButtonReleasedInCurrentFrame(InputDeviceDragButtonIndex))
				{
					OnInputDevicePickButtonUp();
				}
				if (device.WasMoved())
				{
					OnInputDeviceMoved();
				}
			}
		}

		private void OnInputDevicePickButtonDown()
		{
			if (_hoveredHandle == null)
			{
				return;
			}
			if (this.PreHandlePicked != null)
			{
				this.PreHandlePicked(this, _hoveredHandle.Id);
			}
			foreach (IGizmoBehaviour behaviour in _behaviours)
			{
				if (behaviour.IsEnabled)
				{
					behaviour.OnGizmoHandlePicked(_hoveredHandle.Id);
				}
			}
			if (this.PostHandlePicked != null)
			{
				this.PostHandlePicked(this, _hoveredHandle.Id);
			}
			TryActivateDragSession();
		}

		private void OnInputDevicePickButtonUp()
		{
			EndDragSession();
		}

		private void EndDragSession()
		{
			if (_activeDragSession != null)
			{
				_activeDragSession.End();
				_dragInfo.IsDragged = false;
				if (this.PreDragEnd != null)
				{
					this.PreDragEnd(this, _dragInfo.HandleId);
				}
				foreach (IGizmoBehaviour behaviour in _behaviours)
				{
					if (behaviour.IsEnabled)
					{
						behaviour.OnGizmoDragEnd(_dragInfo.HandleId);
					}
				}
				int handleId = _dragInfo.HandleId;
				_dragInfo.Reset();
				if (this.PostDragEnd != null)
				{
					this.PostDragEnd(this, handleId);
				}
			}
			_activeDragSession = null;
		}

		private void OnInputDeviceMoved()
		{
			if (!MonoSingleton<RTInputDevice>.Get.Device.IsButtonPressed(InputDeviceDragButtonIndex) || _activeDragSession == null || !_activeDragSession.IsActive || !_activeDragSession.Update())
			{
				return;
			}
			_dragInfo.TotalOffset = _activeDragSession.TotalDragOffset;
			_dragInfo.TotalRotation = _activeDragSession.TotalDragRotation;
			_dragInfo.TotalScale = _activeDragSession.TotalDragScale;
			_dragInfo.RelativeOffset = _activeDragSession.RelativeDragOffset;
			_dragInfo.RelativeRotation = _activeDragSession.RelativeDragRotation;
			_dragInfo.RelativeScale = _activeDragSession.RelativeDragScale;
			if (this.PreDragUpdate != null)
			{
				this.PreDragUpdate(this, _dragInfo.HandleId);
			}
			foreach (IGizmoBehaviour behaviour in _behaviours)
			{
				if (behaviour.IsEnabled)
				{
					behaviour.OnGizmoDragUpdate(_dragInfo.HandleId);
				}
			}
			if (this.PostDragUpdate != null)
			{
				this.PostDragUpdate(this, _dragInfo.HandleId);
			}
		}

		private void TryActivateDragSession()
		{
			if (_hoveredHandle == null || _hoveredHandle.DragSession == null)
			{
				return;
			}
			foreach (IGizmoBehaviour behaviour in _behaviours)
			{
				if (behaviour.IsEnabled && !behaviour.OnGizmoCanBeginDrag(_hoveredHandle.Id))
				{
					return;
				}
			}
			if (this.PreDragBeginAttempt != null)
			{
				this.PreDragBeginAttempt(this, _hoveredHandle.Id);
			}
			foreach (IGizmoBehaviour behaviour2 in _behaviours)
			{
				if (behaviour2.IsEnabled)
				{
					behaviour2.OnGizmoAttemptHandleDragBegin(_hoveredHandle.Id);
				}
			}
			if (this.PostDragBeginAttempt != null)
			{
				this.PostDragBeginAttempt(this, _hoveredHandle.Id);
			}
			if (!_hoveredHandle.DragSession.Begin())
			{
				return;
			}
			_activeDragSession = _hoveredHandle.DragSession;
			_dragInfo.IsDragged = true;
			_dragInfo.DragChannel = _activeDragSession.DragChannel;
			_dragInfo.HandleDimension = _hoverInfo.HandleDimension;
			_dragInfo.HandleId = _hoverInfo.HandleId;
			_dragInfo.DragBeginPoint = _hoverInfo.HoverPoint;
			if (this.PreDragBegin != null)
			{
				this.PreDragBegin(this, _dragInfo.HandleId);
			}
			foreach (IGizmoBehaviour behaviour3 in _behaviours)
			{
				if (behaviour3.IsEnabled)
				{
					behaviour3.OnGizmoDragBegin(_dragInfo.HandleId);
				}
			}
			if (this.PostDragBegin != null)
			{
				this.PostDragBegin(this, _dragInfo.HandleId);
			}
		}
	}
}
