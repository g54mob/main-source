using UnityEngine.Rendering.Universal;

namespace StylizedGrass
{
	public static class PipelineUtilities
	{
		private const string renderDataListFieldName = "m_RendererDataList";

		public static UniversalRendererData GetRenderer(string guid)
		{
			return null;
		}

		public static void ValidatePipelineRenderers(ScriptableRendererData pass)
		{
		}

		private static void AddRendererToPipeline(ScriptableRendererData pass)
		{
		}

		public static void RemoveRendererFromPipeline(ScriptableRendererData pass)
		{
		}

		private static int GetDefaultRendererIndex(UniversalRenderPipelineAsset asset)
		{
			return 0;
		}

		public static ScriptableRendererData GetDefaultRenderer()
		{
			return null;
		}

		public static bool RenderFeatureAdded<T>(bool addIfMissing = false)
		{
			return false;
		}

		public static void AddRenderFeature<T>(ScriptableRendererData forwardRenderer = null, bool persistent = true)
		{
		}

		public static void AssignRendererToCamera(UniversalAdditionalCameraData camData, ScriptableRendererData pass)
		{
		}
	}
}
