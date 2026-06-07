using UnityEngine;

namespace RLD
{
	public class InputDevicePlaneDragSession3D
	{
		private Plane _plane;

		private Camera _raycastCamera;

		private Vector3 _dragPoint;

		private Vector3 _dragDelta;

		private Vector3 _accumDrag;

		private IInputDevice _inputDevice;

		private bool _isActive;

		public Plane Plane
		{
			get
			{
				return _plane;
			}
			set
			{
				if (!_isActive)
				{
					_plane = value;
				}
			}
		}

		public Camera RaycastCamera
		{
			get
			{
				return _raycastCamera;
			}
			set
			{
				if (!_isActive)
				{
					_raycastCamera = value;
				}
			}
		}

		public Vector3 DragPoint => _dragPoint;

		public Vector3 DragDelta => _dragDelta;

		public Vector3 AccumDrag => _accumDrag;

		public bool IsActive => _isActive;

		public InputDevicePlaneDragSession3D(IInputDevice inputDevice, Camera raycastCamera)
		{
			_inputDevice = inputDevice;
			_raycastCamera = raycastCamera;
		}

		public bool Begin()
		{
			if (_isActive || _raycastCamera == null)
			{
				return false;
			}
			_isActive = UpdateDragPoint();
			return _isActive;
		}

		public void End()
		{
			if (_isActive)
			{
				_isActive = false;
				_dragPoint = Vector3.zero;
				_dragDelta = Vector3.zero;
				_accumDrag = Vector3.zero;
				_plane = default(Plane);
			}
		}

		public bool Update()
		{
			if (!_isActive)
			{
				return false;
			}
			Vector3 dragPoint = _dragPoint;
			if (!UpdateDragPoint())
			{
				_dragDelta = Vector3.zero;
				return false;
			}
			_dragDelta = _dragPoint - dragPoint;
			_accumDrag += _dragDelta;
			return true;
		}

		private bool UpdateDragPoint()
		{
			Ray ray = _inputDevice.GetRay(_raycastCamera);
			if (!_plane.Raycast(ray, out var enter))
			{
				return false;
			}
			_dragPoint = ray.GetPoint(enter);
			return true;
		}
	}
}
