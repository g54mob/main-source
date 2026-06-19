using UnityEngine;

namespace MyBox
{
	[ExecuteAlways]
	public class Billboard : MonoBehaviour
	{
		public Transform FacedObject;

		private static Camera _camera;

		private Transform ActiveFacedObject
		{
			get
			{
				if (FacedObject != null)
				{
					return FacedObject;
				}
				if (_camera != null)
				{
					return _camera.transform;
				}
				_camera = Camera.main;
				if (!(_camera == null))
				{
					return _camera.transform;
				}
				return null;
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void Initialize()
		{
			_camera = null;
		}

		private void Update()
		{
			if (!(ActiveFacedObject == null))
			{
				base.transform.LookAt(ActiveFacedObject);
			}
		}
	}
}
