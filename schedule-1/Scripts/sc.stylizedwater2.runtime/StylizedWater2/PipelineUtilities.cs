using System.Diagnostics;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace StylizedWater2
{
	public static class PipelineUtilities
	{
		private const string renderDataListFieldName = "m_RendererDataList";

		private const string renderFeaturesListFieldName = "m_RendererFeatures";

		private const string defaultRendererIndexFieldName = "m_DefaultRendererIndex";

		private static GUIContent[] _rendererDisplayList;

		private static int[] _rendererIndexList;

		public static GUIContent[] rendererDisplayList => null;

		public static int[] rendererIndexList => null;

		public static ScriptableRendererData[] GetRenderDataList(UniversalRenderPipelineAsset asset)
		{
			return null;
		}

		public static void RefreshRendererList()
		{
		}

		public static int ValidateRenderer(int index)
		{
			return 0;
		}

		public static bool IsRendererAdded(ScriptableRendererData renderer)
		{
			return false;
		}

		private static int AddRendererToPipeline(ScriptableRendererData renderer)
		{
			return 0;
		}

		private static int GetDefaultRendererIndex(UniversalRenderPipelineAsset asset)
		{
			return 0;
		}

		public static ScriptableRendererData GetDefaultRenderer(UniversalRenderPipelineAsset asset = null)
		{
			return null;
		}

		[Conditional("UNITY_EDITOR")]
		public static void ValidateRenderFeatureSetup<T>(string name)
		{
		}

		public static ScriptableRendererFeature[] GetDefaultRenderFeatures()
		{
			return null;
		}

		public static ScriptableRendererFeature GetRenderFeature<T>(ScriptableRendererData renderer)
		{
			return null;
		}

		public static ScriptableRendererFeature GetRenderFeature<T>()
		{
			return null;
		}

		public static bool RenderFeatureAdded<T>(ScriptableRendererData renderer = null)
		{
			return false;
		}

		public static bool RenderFeatureMissing<T>(out ScriptableRendererData[] renderers)
		{
			renderers = null;
			return false;
		}

		public static void SetupRenderFeature<T>(string name = "")
		{
		}

		public static ScriptableRendererFeature AddRenderFeature<T>(ScriptableRendererData renderer = null, string name = "")
		{
			return null;
		}

		public static bool IsRenderFeatureEnabled<T>(ScriptableRendererData forwardRenderer = null, bool autoEnable = false)
		{
			return false;
		}

		public static void ToggleRenderFeature<T>(bool state)
		{
		}

		public static void CreateAndAssignNewRenderer(out int index, out string path)
		{
			index = default(int);
			path = null;
		}

		public static UniversalRendererData CreateEmptyRenderer(string name = "", string folder = "")
		{
			return null;
		}

		public static void RemoveRendererFromPipeline(ScriptableRendererData renderer)
		{
		}

		public static void AssignRendererToCamera(UniversalAdditionalCameraData camData, ScriptableRendererData renderer)
		{
		}

		public static bool IsDepthTextureOptionDisabledAnywhere()
		{
			return false;
		}

		public static void SetDepthTextureOnAllAssets(bool state)
		{
		}

		public static bool IsOpaqueTextureOptionDisabledAnywhere()
		{
			return false;
		}

		public static void SetOpaqueTextureOnAllAssets(bool state)
		{
		}

		public static bool TransparentShadowsEnabled()
		{
			return false;
		}

		public static bool IsDepthAfterTransparents()
		{
			return false;
		}

		public static bool VREnabled()
		{
			return false;
		}

		public static bool RenderGraphEnabled()
		{
			return false;
		}
	}
}
