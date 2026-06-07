using UnityEngine;

namespace RLD
{
	public abstract class GizmoPlaneDrag3D : GizmoDragSession
	{
		private bool _isSnapEnabled;

		private float _sensitivity = 1f;

		protected InputDevicePlaneDragSession3D _planeDragSession;

		public bool IsSnapEnabled
		{
			get
			{
				return _isSnapEnabled;
			}
			set
			{
				_isSnapEnabled = value;
			}
		}

		public float Sensitivity
		{
			get
			{
				return _sensitivity;
			}
			set
			{
				_sensitivity = Mathf.Max(0.0001f, value);
			}
		}

		public override bool IsActive
		{
			get
			{
				if (_planeDragSession != null)
				{
					return _planeDragSession.IsActive;
				}
				return false;
			}
		}

		protected override bool DoBeginSession()
		{
			_planeDragSession = new InputDevicePlaneDragSession3D(MonoSingleton<RTInputDevice>.Get.Device, MonoSingleton<RTFocusCamera>.Get.TargetCamera);
			_planeDragSession.Plane = CalculateDragPlane();
			return _planeDragSession.Begin();
		}

		protected override bool DoUpdateSession()
		{
			return _planeDragSession.Update();
		}

		protected override void DoEndSession()
		{
			_planeDragSession.End();
			_planeDragSession = null;
		}

		protected bool CanSnap()
		{
			return _isSnapEnabled;
		}

		protected abstract Plane CalculateDragPlane();
	}
}
