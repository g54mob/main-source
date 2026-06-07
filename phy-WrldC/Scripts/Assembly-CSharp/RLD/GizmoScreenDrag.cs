using UnityEngine;

namespace RLD
{
	public abstract class GizmoScreenDrag : GizmoDragSession
	{
		private bool _isSnapEnabled;

		private float _sensitivity = 1f;

		protected InputDeviceScreenDragSession _screenDragSession;

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
				if (_screenDragSession != null)
				{
					return _screenDragSession.IsActive;
				}
				return false;
			}
		}

		protected override bool DoBeginSession()
		{
			_screenDragSession = new InputDeviceScreenDragSession(MonoSingleton<RTInputDevice>.Get.Device);
			return _screenDragSession.Begin();
		}

		protected override bool DoUpdateSession()
		{
			return _screenDragSession.Update();
		}

		protected override void DoEndSession()
		{
			_screenDragSession.End();
			_screenDragSession = null;
		}

		protected bool CanSnap()
		{
			return _isSnapEnabled;
		}
	}
}
