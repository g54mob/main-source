using UnityEngine;
using UnityEngine.XR;
using VRTK;

namespace DV.VRTK_Extensions
{
	public static class HeadsetUtils
	{
		private const string HEADSET_HTCVIVE = "vive";

		private const string HEADSET_VIVE_INDEX = "index";

		private const string HEADSET_OCULUS_RIFT = "rift";

		private const string HEADSET_OCULUS_QUEST = "quest";

		private const string HEADSET_OCULUS_QUEST2_A = "quest2";

		private const string HEADSET_OCULUS_QUEST2_B = "miramar";

		private const string HEADSET_WMR = "mixed";

		private const string HEADSET_G2 = "g20";

		private const string PICO = "pico";

		private const string STEAMVR_NULL = "null model number";

		private static bool shouldLogHeadsetData = true;

		public static HeadsetType_DV GetHeadsetTypeDV()
		{
			string text = XRDevice.model.ToLowerInvariant();
			HeadsetType_DV headsetType_DV = HeadsetType_DV.Undefined;
			if (shouldLogHeadsetData)
			{
				Debug.Log("---Model name from XRDevice: '" + text + "'. Headset name from VRTK: `" + VRTK_SDK_Bridge.GetHeadsetType() + "`---");
				shouldLogHeadsetData = false;
			}
			if (text.Contains("vive"))
			{
				headsetType_DV = HeadsetType_DV.HTCVive;
			}
			else if (text.Contains("index"))
			{
				headsetType_DV = HeadsetType_DV.ValveIndex;
			}
			else if (text.Contains("rift"))
			{
				headsetType_DV = HeadsetType_DV.OculusRift;
			}
			else if (text.Contains("quest2"))
			{
				headsetType_DV = HeadsetType_DV.OculusQuest2;
			}
			else if (text.Contains("miramar"))
			{
				headsetType_DV = HeadsetType_DV.OculusQuest2;
			}
			else if (text.Contains("quest"))
			{
				headsetType_DV = HeadsetType_DV.OculusQuest;
			}
			else if (text.Contains("mixed"))
			{
				headsetType_DV = HeadsetType_DV.WMR;
			}
			else if (text.Contains("g20"))
			{
				headsetType_DV = HeadsetType_DV.HPReverbG2;
			}
			else if (text.Contains("pico"))
			{
				headsetType_DV = HeadsetType_DV.Pico;
			}
			else if (text.Contains("null model number"))
			{
				headsetType_DV = HeadsetType_DV.SteamVRNullDriver;
			}
			if (headsetType_DV != HeadsetType_DV.Undefined)
			{
				Debug.Log($"Detected Headset: '{headsetType_DV}' from model name '{XRDevice.model}'.");
			}
			else
			{
				Debug.LogError("Could not properly identify headset with model name '" + XRDevice.model + "'.");
			}
			return headsetType_DV;
		}
	}
}
