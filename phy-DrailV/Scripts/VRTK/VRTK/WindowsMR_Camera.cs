using UnityEngine;
using UnityEngine.XR;

namespace VRTK
{
	[RequireComponent(typeof(Camera))]
	public class WindowsMR_Camera : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("Force the Tracking Space Type to be RoomScale (normal VR experiences). If false, Stationary will be forced (e.g. video experiences.")]
		private bool forceRoomScaleTracking = true;

		private const string DEVICE_NAME = "WindowsMR";

		public bool ForceRoomScaleTracking
		{
			get
			{
				return forceRoomScaleTracking;
			}
			set
			{
				forceRoomScaleTracking = value;
			}
		}

		protected virtual void Awake()
		{
			if (CheckForMixedRealitySupport())
			{
				SetupMRCamera();
			}
		}

		protected virtual void Update()
		{
			if (XRDevice.GetTrackingSpaceType() != TrackingSpaceType.RoomScale && forceRoomScaleTracking)
			{
				XRDevice.SetTrackingSpaceType(TrackingSpaceType.RoomScale);
			}
			if (XRDevice.GetTrackingSpaceType() != TrackingSpaceType.Stationary && !forceRoomScaleTracking)
			{
				XRDevice.SetTrackingSpaceType(TrackingSpaceType.Stationary);
			}
		}

		protected virtual bool CheckForMixedRealitySupport()
		{
			if (!XRSettings.enabled)
			{
				Debug.LogError("XRSettings are not enabled. Enable in PlayerSettings. Do not forget to add Windows Mixed Reality to Virtual Reality SDKs.");
				return false;
			}
			string[] supportedDevices = XRSettings.supportedDevices;
			for (int i = 0; i < supportedDevices.Length; i++)
			{
				if (supportedDevices[i].Equals("WindowsMR"))
				{
					return true;
				}
			}
			Debug.LogError("Windows Mixed Reality is not supported in XRSettings, add in PlayerSettings.");
			return false;
		}

		protected virtual void SetupMRCamera()
		{
			Camera component = GetComponent<Camera>();
			if (component.tag != "MainCamera")
			{
				component.tag = "MainCamera";
			}
			component.nearClipPlane = 0.01f;
			if (component.stereoTargetEye != StereoTargetEyeMask.Both)
			{
				Debug.LogError("Target eye of main camera is not set to both. Are you sure you want to render only one eye?");
			}
		}
	}
}
