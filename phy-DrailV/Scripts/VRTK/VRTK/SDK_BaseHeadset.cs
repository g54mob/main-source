using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

namespace VRTK
{
	public abstract class SDK_BaseHeadset : SDK_Base
	{
		public enum HeadsetType
		{
			Undefined = 0,
			Simulator = 1,
			HTCVive = 2,
			OculusRiftDK1 = 3,
			OculusRiftDK2 = 4,
			OculusRift = 5,
			OculusGearVR = 6,
			GoogleDaydream = 7,
			GoogleCardboard = 8,
			HyperealVR = 9,
			WindowsMixedReality = 10
		}

		protected Transform cachedHeadset;

		protected Transform cachedHeadsetCamera;

		public abstract void ProcessUpdate(Dictionary<string, object> options);

		public abstract void ProcessFixedUpdate(Dictionary<string, object> options);

		public abstract Transform GetHeadset();

		public abstract Transform GetHeadsetCamera();

		public abstract string GetHeadsetType();

		public abstract Vector3 GetHeadsetVelocity();

		public abstract Vector3 GetHeadsetAngularVelocity();

		public abstract void HeadsetFade(Color color, float duration, bool fadeOverlay = false);

		public abstract bool HasHeadsetFade(Transform obj);

		public abstract void AddHeadsetFade(Transform camera);

		protected Transform GetSDKManagerHeadset()
		{
			VRTK_SDKManager instance = VRTK_SDKManager.instance;
			if (instance != null && instance.loadedSetup != null && instance.loadedSetup.actualHeadset != null)
			{
				cachedHeadset = (instance.loadedSetup.actualHeadset ? instance.loadedSetup.actualHeadset.transform : null);
				return cachedHeadset;
			}
			return null;
		}

		protected virtual string ScrapeHeadsetType()
		{
			string text = CleanPropertyString(XRDevice.model);
			string text2 = CleanPropertyString(XRSettings.loadedDeviceName);
			switch (text)
			{
			case "oculusriftcv1":
			case "oculusriftes07":
				return CleanPropertyString("oculusrift");
			case "vivemv":
			case "vivedvt":
				return CleanPropertyString("htcvive");
			case "googleinc-daydreamview":
				return "googledaydream";
			case "googleinc-defaultcardboard":
				return "googlecardboard";
			case "galaxynote5":
			case "galaxys6":
			case "galaxys6edge":
			case "galaxys7":
			case "galaxys7edge":
			case "galaxys8":
			case "galaxys8+":
				if (text2 == "oculus")
				{
					return "oculusgearvr";
				}
				break;
			case "oculusriftdk1":
				return CleanPropertyString("oculusriftdk1");
			case "oculusriftdk2":
				return CleanPropertyString("oculusriftdk2");
			case "acermixedreality":
				return CleanPropertyString("windowsmixedreality");
			}
			return "";
		}

		protected string CleanPropertyString(string inputString)
		{
			return inputString.Replace(" ", "").Replace(".", "").Replace(",", "")
				.ToLowerInvariant();
		}
	}
}
