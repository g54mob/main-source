using CodeStage.AdvancedFPSCounter.CountersData;
using UnityEngine;
using UnityEngine.Rendering;

namespace CodeStage.AdvancedFPSCounter.Utils
{
	[DisallowMultipleComponent]
	public class AFPSRenderRecorder : MonoBehaviour
	{
		private static FPSCounterData currentListener;

		private static bool recording;

		private static float renderTime;

		public static void Add(FPSCounterData counter)
		{
		}

		public static void Remove()
		{
		}

		private static void OnBeginCameraRendering(ScriptableRenderContext context, Camera camera)
		{
		}

		private static void OnEndCameraRendering(ScriptableRenderContext context, Camera camera)
		{
		}

		private static void BeginRecording()
		{
		}

		private static void EndRecording()
		{
		}

		private void OnPreCull()
		{
		}

		private void OnPostRender()
		{
		}
	}
}
