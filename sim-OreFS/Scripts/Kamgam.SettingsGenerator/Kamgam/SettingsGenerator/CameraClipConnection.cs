using System;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	public class CameraClipConnection : Connection<float>
	{
		public enum ClippingMode
		{
			Near = 0,
			Far = 1
		}

		public const float DefaultFallbackNear = 0.3f;

		public const float DefaultFallbackFar = 1000f;

		public bool UseMain;

		public bool UseMarkers;

		public ClippingMode Mode;

		public float ClipMin;

		public float ClipMax;

		[NonSerialized]
		protected float _clipValue;

		public CameraClipConnection(ClippingMode mode = ClippingMode.Far, float clipMin = 1f, float clipMax = 1000f, bool useMain = true, bool useMarkers = true)
		{
			Mode = mode;
			ClipMin = clipMin;
			ClipMax = clipMax;
			if (mode == ClippingMode.Near)
			{
				_clipValue = 0.3f;
			}
			else
			{
				_clipValue = 1000f;
			}
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
			Set(_clipValue);
		}

		public override float Get()
		{
			if (UseMain && Camera.main != null)
			{
				return getClipValue(Camera.main);
			}
			if (UseMarkers)
			{
				CameraMarker<FieldOfViewMarker> firstValidMarker = CameraMarker<FieldOfViewMarker>.GetFirstValidMarker();
				if (firstValidMarker != null)
				{
					return getClipValue(firstValidMarker.Camera);
				}
			}
			return _clipValue;
		}

		public override void Set(float value)
		{
			_clipValue = value;
			if (UseMain && Camera.main != null)
			{
				setClipValue(Camera.main, value);
			}
			else
			{
				if (!UseMarkers)
				{
					return;
				}
				foreach (CameraMarker<CameraClipMarker> marker in CameraMarker<CameraClipMarker>.Markers)
				{
					if (marker.IsValid())
					{
						setClipValue(marker.Camera, value);
					}
				}
			}
		}

		public float getClipValue(Camera cam)
		{
			if (Mode == ClippingMode.Far)
			{
				return cam.farClipPlane;
			}
			return cam.nearClipPlane;
		}

		public void setClipValue(Camera cam, float value)
		{
			if (Mode == ClippingMode.Far)
			{
				if (cam.farClipPlane > cam.nearClipPlane)
				{
					cam.farClipPlane = value;
				}
				else
				{
					Logger.LogWarning("CameraCipConnection: You can not set the far clipping distance lower than the near clipping distance!");
				}
			}
			else if (cam.nearClipPlane < cam.farClipPlane)
			{
				cam.nearClipPlane = value;
			}
			else
			{
				Logger.LogWarning("CameraCipConnection: You can not set the near clipping distance higher than the far clipping distance!");
			}
		}
	}
}
