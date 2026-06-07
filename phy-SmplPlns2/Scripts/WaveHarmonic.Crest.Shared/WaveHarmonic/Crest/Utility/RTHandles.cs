using UnityEngine;
using UnityEngine.Rendering;

namespace WaveHarmonic.Crest.Utility
{
	internal static class RTHandles
	{
		public static void Initialize()
		{
			if (RenderPipelineHelper.IsLegacy && UnityEngine.Rendering.RTHandles.maxWidth <= 1)
			{
				UnityEngine.Rendering.RTHandles.Initialize(Screen.width, Screen.height);
				UnityEngine.Rendering.RTHandles.SetHardwareDynamicResolutionState(hwDynamicResRequested: false);
			}
		}

		public static void OnBeginCameraRendering(Camera camera)
		{
			UnityEngine.Rendering.RTHandles.SetReferenceSize(camera.pixelWidth, camera.pixelHeight);
		}
	}
}
