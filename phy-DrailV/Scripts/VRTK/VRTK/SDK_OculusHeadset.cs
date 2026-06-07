using System.Collections.Generic;
using UnityEngine;

namespace VRTK
{
	[SDK_Description(typeof(SDK_OculusSystem), 0)]
	[SDK_Description(typeof(SDK_OculusSystem), 1)]
	public class SDK_OculusHeadset : SDK_BaseHeadset
	{
		protected VRTK_VelocityEstimator cachedHeadsetVelocityEstimator;

		public override void ProcessUpdate(Dictionary<string, object> options)
		{
		}

		public override void ProcessFixedUpdate(Dictionary<string, object> options)
		{
		}

		public override Transform GetHeadset()
		{
			cachedHeadset = GetSDKManagerHeadset();
			if (cachedHeadset == null)
			{
				cachedHeadset = VRTK_SharedMethods.FindEvenInactiveGameObject<OVRCameraRig>("TrackingSpace/CenterEyeAnchor", searchAllScenes: true).transform;
			}
			return cachedHeadset;
		}

		public override Transform GetHeadsetCamera()
		{
			cachedHeadsetCamera = GetSDKManagerHeadset();
			if (cachedHeadsetCamera == null)
			{
				cachedHeadsetCamera = GetHeadset();
			}
			return cachedHeadsetCamera;
		}

		public override string GetHeadsetType()
		{
			switch (OVRPlugin.GetSystemHeadsetType())
			{
			case OVRPlugin.SystemHeadset.Rift_CV1:
				return CleanPropertyString("oculusrift");
			case OVRPlugin.SystemHeadset.Rift_DK1:
				return CleanPropertyString("oculusriftdk1");
			case OVRPlugin.SystemHeadset.Rift_DK2:
				return CleanPropertyString("oculusriftdk2");
			case OVRPlugin.SystemHeadset.Oculus_Quest:
			case OVRPlugin.SystemHeadset.Oculus_Link_Quest:
				return CleanPropertyString("oculusquest");
			case OVRPlugin.SystemHeadset.Oculus_Quest_2:
			case OVRPlugin.SystemHeadset.Oculus_Link_Quest_2:
				return CleanPropertyString("oculusquest2");
			default:
				return CleanPropertyString("");
			}
		}

		public override Vector3 GetHeadsetVelocity()
		{
			if (!OVRManager.isHmdPresent)
			{
				return Vector3.zero;
			}
			return OVRPlugin.GetNodeVelocity(OVRPlugin.Node.EyeCenter, OVRPlugin.Step.Render).FromFlippedZVector3f();
		}

		public override Vector3 GetHeadsetAngularVelocity()
		{
			SetHeadsetCaches();
			return cachedHeadsetVelocityEstimator.GetAngularVelocityEstimate();
		}

		public override void HeadsetFade(Color color, float duration, bool fadeOverlay = false)
		{
			VRTK_ScreenFade.Start(color, duration);
		}

		public override bool HasHeadsetFade(Transform obj)
		{
			if ((bool)obj.GetComponentInChildren<VRTK_ScreenFade>())
			{
				return true;
			}
			return false;
		}

		public override void AddHeadsetFade(Transform camera)
		{
			if ((bool)camera && !camera.GetComponent<VRTK_ScreenFade>())
			{
				camera.gameObject.AddComponent<VRTK_ScreenFade>();
			}
		}

		protected virtual void SetHeadsetCaches()
		{
			Transform headset = GetHeadset();
			if (cachedHeadsetVelocityEstimator == null && headset != null)
			{
				cachedHeadsetVelocityEstimator = ((headset.GetComponent<VRTK_VelocityEstimator>() != null) ? headset.GetComponent<VRTK_VelocityEstimator>() : headset.gameObject.AddComponent<VRTK_VelocityEstimator>());
			}
		}
	}
}
