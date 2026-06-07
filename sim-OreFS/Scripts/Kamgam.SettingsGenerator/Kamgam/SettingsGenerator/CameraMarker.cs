using System.Collections.Generic;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	public class CameraMarker<T> : MonoBehaviour where T : CameraMarker<T>
	{
		public static List<CameraMarker<T>> Markers = new List<CameraMarker<T>>();

		protected Camera _camera;

		public Camera Camera
		{
			get
			{
				if (_camera == null)
				{
					_camera = GetComponent<Camera>();
				}
				return _camera;
			}
		}

		public static bool HasValidMarkers()
		{
			foreach (CameraMarker<T> marker in Markers)
			{
				if (marker.IsValid())
				{
					return true;
				}
			}
			return false;
		}

		public static CameraMarker<T> GetFirstValidMarker()
		{
			foreach (CameraMarker<T> marker in Markers)
			{
				if (marker.IsValid())
				{
					return marker;
				}
			}
			return null;
		}

		public void OnEnable()
		{
		}

		public void Awake()
		{
			Markers.Add(this);
		}

		public void OnDestroy()
		{
			Markers.Remove(this);
		}

		public bool IsValid()
		{
			if (base.isActiveAndEnabled && base.gameObject != null && base.gameObject.activeInHierarchy)
			{
				return Camera != null;
			}
			return false;
		}
	}
}
