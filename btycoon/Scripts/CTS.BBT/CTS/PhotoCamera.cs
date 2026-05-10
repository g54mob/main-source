using System;
using UnityEngine;

namespace CTS
{
	public class PhotoCamera : MonoBehaviour
	{
		private Camera _camera;

		public static PhotoCamera instance { get; private set; }

		private bool IsCameraActived
		{
			get
			{
				if ((bool)_camera)
				{
					return _camera.enabled;
				}
				return false;
			}
		}

		public event Action onCameraActived;

		public event Action onCameraDesactived;

		private void Awake()
		{
			instance = this;
			_camera = GetComponent<Camera>();
		}

		public void SetCameraActived(bool p_acitveCamera)
		{
			if (p_acitveCamera)
			{
				ActiveCamera();
			}
			else
			{
				DesactiveCamera();
			}
		}

		public void ActiveCamera()
		{
			if (!IsCameraActived)
			{
				if (_camera == null)
				{
					_camera = GetComponent<Camera>();
				}
				_camera.enabled = true;
				this.onCameraActived?.Invoke();
			}
		}

		public void DesactiveCamera()
		{
			if (IsCameraActived)
			{
				_camera.enabled = false;
				this.onCameraDesactived?.Invoke();
			}
		}

		public void SetParent(Transform p_parent)
		{
			base.transform.parent = p_parent;
			if (!(p_parent == null))
			{
				base.transform.localPosition = Vector3.zero;
				base.transform.localRotation = Quaternion.identity;
			}
		}
	}
}
