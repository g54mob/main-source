using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace VRTK
{
	[SDK_Description(typeof(SDK_SteamVRSystem), 0)]
	public class SDK_SteamVRHeadset : SDK_BaseHeadset
	{
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
				SteamVR_Camera steamVR_Camera = VRTK_SharedMethods.FindEvenInactiveComponent<SteamVR_Camera>(searchAllScenes: true);
				if (steamVR_Camera != null)
				{
					cachedHeadset = steamVR_Camera.transform;
				}
			}
			return cachedHeadset;
		}

		public override Transform GetHeadsetCamera()
		{
			cachedHeadsetCamera = GetSDKManagerHeadset();
			if (cachedHeadsetCamera == null)
			{
				SteamVR_Camera steamVR_Camera = VRTK_SharedMethods.FindEvenInactiveComponent<SteamVR_Camera>(searchAllScenes: true);
				if (steamVR_Camera != null)
				{
					cachedHeadsetCamera = steamVR_Camera.transform;
				}
			}
			return cachedHeadsetCamera;
		}

		public override string GetHeadsetType()
		{
			if (SteamVR.instance != null)
			{
				string text = CleanPropertyString(SteamVR.instance.GetStringProperty(ETrackedDeviceProperty.Prop_ManufacturerName_String));
				string text2 = CleanPropertyString(SteamVR.instance.GetStringProperty(ETrackedDeviceProperty.Prop_ModelNumber_String));
				switch (text)
				{
				case "htc":
					if (text2.Contains("vive"))
					{
						return "htcvive";
					}
					break;
				case "oculus":
					return "oculusrift";
				case "windowsmr":
					return "windowsmixedreality";
				}
				return CleanPropertyString(text);
			}
			return CleanPropertyString("");
		}

		public override Vector3 GetHeadsetVelocity()
		{
			return SteamVR_Controller.Input(0).velocity;
		}

		public override Vector3 GetHeadsetAngularVelocity()
		{
			return SteamVR_Controller.Input(0).angularVelocity;
		}

		public override void HeadsetFade(Color color, float duration, bool fadeOverlay = false)
		{
			SteamVR_Fade.Start(color, duration, fadeOverlay);
		}

		public override bool HasHeadsetFade(Transform obj)
		{
			if (obj.GetComponentInChildren<SteamVR_Fade>() != null)
			{
				return true;
			}
			return false;
		}

		public override void AddHeadsetFade(Transform camera)
		{
			if (camera != null && camera.GetComponent<SteamVR_Fade>() == null)
			{
				camera.gameObject.AddComponent<SteamVR_Fade>();
			}
		}
	}
}
