using System;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	public class FieldOfViewConnection : Connection<float>
	{
		public const float DefaultFallback = 60f;

		public bool UseMain;

		public bool UseMarkers;

		[NonSerialized]
		protected float _fieldOfView = 60f;

		public FieldOfViewConnection(bool useMain = true, bool useMarkers = true)
		{
			UseMain = useMain;
			UseMarkers = useMarkers;
			CameraDetector instance = CameraDetector.Instance;
			instance.OnNewCameraFound = (CameraDetector.OnNewCameraFoundDelegate)Delegate.Combine(instance.OnNewCameraFound, new CameraDetector.OnNewCameraFoundDelegate(onNewCamera));
		}

		protected void onNewCamera(Camera cam)
		{
			Apply();
		}

		public void Apply()
		{
			Set(_fieldOfView);
		}

		public override float Get()
		{
			if (UseMain && Camera.main != null)
			{
				return Camera.main.fieldOfView;
			}
			if (UseMarkers)
			{
				CameraMarker<FieldOfViewMarker> firstValidMarker = CameraMarker<FieldOfViewMarker>.GetFirstValidMarker();
				if (firstValidMarker != null)
				{
					return firstValidMarker.Camera.fieldOfView;
				}
			}
			return _fieldOfView;
		}

		public override void Set(float fieldOfView)
		{
			_fieldOfView = fieldOfView;
			if (UseMain && Camera.main != null)
			{
				Camera.main.fieldOfView = fieldOfView;
			}
			else
			{
				if (!UseMarkers)
				{
					return;
				}
				foreach (CameraMarker<FieldOfViewMarker> marker in CameraMarker<FieldOfViewMarker>.Markers)
				{
					if (marker.IsValid())
					{
						marker.Camera.fieldOfView = fieldOfView;
					}
				}
			}
		}
	}
}
