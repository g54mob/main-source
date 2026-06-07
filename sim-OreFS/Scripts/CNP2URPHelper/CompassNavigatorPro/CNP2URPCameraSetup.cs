using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace CompassNavigatorPro
{
	public static class CNP2URPCameraSetup
	{
		public static bool usesURP = true;

		public static void SetupURPCamera(Camera cam, bool renderShadows)
		{
			UniversalAdditionalCameraData universalAdditionalCameraData = cam.GetComponent<UniversalAdditionalCameraData>();
			if (universalAdditionalCameraData == null)
			{
				universalAdditionalCameraData = cam.gameObject.AddComponent<UniversalAdditionalCameraData>();
			}
			if (universalAdditionalCameraData != null)
			{
				universalAdditionalCameraData.renderShadows = renderShadows;
			}
		}
	}
}
