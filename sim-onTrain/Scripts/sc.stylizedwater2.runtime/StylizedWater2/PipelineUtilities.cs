using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace StylizedWater2
{
	public static class PipelineUtilities
	{
		private const string renderDataListFieldName = "m_RendererDataList";

		private static GUIContent[] _rendererDisplayList;

		private static int[] _rendererIndexList;

		public static GUIContent[] rendererDisplayList
		{
			get
			{
				if (_rendererDisplayList == null)
				{
					RefreshRendererList();
				}
				return _rendererDisplayList;
			}
			set
			{
				_rendererDisplayList = value;
			}
		}

		public static int[] rendererIndexList
		{
			get
			{
				if (_rendererIndexList == null)
				{
					RefreshRendererList();
				}
				return _rendererIndexList;
			}
			set
			{
				_rendererIndexList = value;
			}
		}

		public static UniversalRendererData GetRenderer(string GUID)
		{
			Debug.LogError("PipelineUtilities.GetRenderer() cannot be called in a build, it requires AssetDatabase. References to renderers should be saved beforehand!");
			return null;
		}

		public static void RefreshRendererList()
		{
			if (UniversalRenderPipeline.asset == null)
			{
				Debug.LogError("No pipeline is active, do not display UI that uses this function if it isn't!");
			}
			ScriptableRendererData[] array = (ScriptableRendererData[])typeof(UniversalRenderPipelineAsset).GetField("m_RendererDataList", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(UniversalRenderPipeline.asset);
			_rendererDisplayList = new GUIContent[array.Length + 1];
			int defaultRendererIndex = GetDefaultRendererIndex(UniversalRenderPipeline.asset);
			_rendererDisplayList[0] = new GUIContent("Default (" + array[defaultRendererIndex].name + ")");
			for (int i = 1; i < _rendererDisplayList.Length; i++)
			{
				_rendererDisplayList[i] = new GUIContent(i - 1 + ": " + array[i - 1].name);
			}
			_rendererIndexList = new int[array.Length + 1];
			for (int j = 0; j < _rendererIndexList.Length; j++)
			{
				_rendererIndexList[j] = j - 1;
			}
		}

		public static int ValidateRenderer(int index)
		{
			if ((bool)UniversalRenderPipeline.asset)
			{
				int defaultRendererIndex = GetDefaultRendererIndex(UniversalRenderPipeline.asset);
				ScriptableRendererData[] array = (ScriptableRendererData[])typeof(UniversalRenderPipelineAsset).GetField("m_RendererDataList", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(UniversalRenderPipeline.asset);
				if (index == -1)
				{
					index = defaultRendererIndex;
				}
				if (index >= array.Length || !(array[index] != null))
				{
					Debug.LogWarning("Renderer at <b>index " + index + "</b> is missing, falling back to Default Renderer. <b>" + array[defaultRendererIndex].name + "</b>", UniversalRenderPipeline.asset);
					return defaultRendererIndex;
				}
				return index;
			}
			Debug.LogError("No Universal Render Pipeline is currently active.");
			return 0;
		}

		public static bool IsRendererAdded(ScriptableRendererData renderer)
		{
			if (renderer == null)
			{
				Debug.LogError("Pass is null");
				return false;
			}
			if ((bool)UniversalRenderPipeline.asset)
			{
				BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.NonPublic;
				ScriptableRendererData[] array = (ScriptableRendererData[])typeof(UniversalRenderPipelineAsset).GetField("m_RendererDataList", bindingAttr).GetValue(UniversalRenderPipeline.asset);
				bool result = false;
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] == renderer)
					{
						result = true;
					}
				}
				return result;
			}
			Debug.LogError("No Universal Render Pipeline is currently active.");
			return false;
		}

		private static void AddRendererToPipeline(ScriptableRendererData renderer)
		{
			if (renderer == null)
			{
				return;
			}
			if ((bool)UniversalRenderPipeline.asset)
			{
				BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.NonPublic;
				ScriptableRendererData[] array = (ScriptableRendererData[])typeof(UniversalRenderPipelineAsset).GetField("m_RendererDataList", bindingAttr).GetValue(UniversalRenderPipeline.asset);
				List<ScriptableRendererData> list = new List<ScriptableRendererData>();
				for (int i = 0; i < array.Length; i++)
				{
					list.Add(array[i]);
				}
				list.Add(renderer);
				typeof(UniversalRenderPipelineAsset).GetField("m_RendererDataList", bindingAttr).SetValue(UniversalRenderPipeline.asset, list.ToArray());
			}
			else
			{
				Debug.LogError("No Universal Render Pipeline is currently active.");
			}
		}

		private static int GetDefaultRendererIndex(UniversalRenderPipelineAsset asset)
		{
			return (int)typeof(UniversalRenderPipelineAsset).GetField("m_DefaultRendererIndex", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(asset);
		}

		public static ScriptableRendererData GetDefaultRenderer()
		{
			if ((bool)UniversalRenderPipeline.asset)
			{
				ScriptableRendererData[] obj = (ScriptableRendererData[])typeof(UniversalRenderPipelineAsset).GetField("m_RendererDataList", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(UniversalRenderPipeline.asset);
				int defaultRendererIndex = GetDefaultRendererIndex(UniversalRenderPipeline.asset);
				return obj[defaultRendererIndex];
			}
			Debug.LogError("No Universal Render Pipeline is currently active.");
			return null;
		}

		public static ScriptableRendererFeature GetRenderFeature<T>()
		{
			foreach (ScriptableRendererFeature rendererFeature in GetDefaultRenderer().rendererFeatures)
			{
				if (rendererFeature.GetType() == typeof(T))
				{
					return rendererFeature;
				}
			}
			return null;
		}

		public static bool RenderFeatureAdded<T>(bool addIfMissing = false)
		{
			ScriptableRendererData defaultRenderer = GetDefaultRenderer();
			bool flag = false;
			foreach (ScriptableRendererFeature rendererFeature in defaultRenderer.rendererFeatures)
			{
				if (!(rendererFeature == null) && rendererFeature.GetType() == typeof(T))
				{
					flag = true;
				}
			}
			if (!flag && addIfMissing)
			{
				AddRenderFeature<T>(defaultRenderer);
			}
			return flag;
		}

		public static void AddRenderFeature<T>(ScriptableRendererData forwardRenderer = null)
		{
			if (forwardRenderer == null)
			{
				forwardRenderer = GetDefaultRenderer();
			}
			ScriptableRendererFeature scriptableRendererFeature = (ScriptableRendererFeature)ScriptableObject.CreateInstance(typeof(T).ToString());
			scriptableRendererFeature.name = typeof(T).ToString();
			FieldInfo field = typeof(ScriptableRendererData).GetField("m_RendererFeatures", BindingFlags.Instance | BindingFlags.NonPublic);
			List<ScriptableRendererFeature> list = (List<ScriptableRendererFeature>)field.GetValue(forwardRenderer);
			list.Add(scriptableRendererFeature);
			field.SetValue(forwardRenderer, list);
			typeof(ScriptableRendererData).GetMethod("OnValidate", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(forwardRenderer, null);
			Debug.Log("<b>" + scriptableRendererFeature.name + "</b> was added to the " + forwardRenderer.name + " renderer");
		}

		public static bool IsRenderFeatureEnabled<T>(ScriptableRendererData forwardRenderer = null, bool autoEnable = false)
		{
			if (forwardRenderer == null)
			{
				forwardRenderer = GetDefaultRenderer();
			}
			foreach (ScriptableRendererFeature item in (List<ScriptableRendererFeature>)typeof(ScriptableRendererData).GetField("m_RendererFeatures", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(forwardRenderer))
			{
				if (item.GetType() == typeof(T))
				{
					if (!item.isActive && autoEnable)
					{
						item.SetActive(active: true);
					}
					return item.isActive;
				}
			}
			return true;
		}

		public static void ToggleRenderFeature<T>(bool state)
		{
			foreach (ScriptableRendererFeature rendererFeature in GetDefaultRenderer().rendererFeatures)
			{
				if (rendererFeature.GetType() == typeof(T))
				{
					rendererFeature.SetActive(state);
				}
			}
		}

		public static void RemoveRendererFromPipeline(ScriptableRendererData renderer)
		{
			if (renderer == null)
			{
				return;
			}
			if ((bool)UniversalRenderPipeline.asset)
			{
				BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.NonPublic;
				List<ScriptableRendererData> list = new List<ScriptableRendererData>((ScriptableRendererData[])typeof(UniversalRenderPipelineAsset).GetField("m_RendererDataList", bindingAttr).GetValue(UniversalRenderPipeline.asset));
				if (list.Contains(renderer))
				{
					list.Remove(renderer);
					typeof(UniversalRenderPipelineAsset).GetField("m_RendererDataList", bindingAttr).SetValue(UniversalRenderPipeline.asset, list.ToArray());
				}
			}
			else
			{
				Debug.LogError("No Universal Render Pipeline is currently active.");
			}
		}

		public static void AssignRendererToCamera(UniversalAdditionalCameraData camData, ScriptableRendererData renderer)
		{
			if ((bool)UniversalRenderPipeline.asset)
			{
				if (!renderer)
				{
					return;
				}
				ScriptableRendererData[] array = (ScriptableRendererData[])typeof(UniversalRenderPipelineAsset).GetField("m_RendererDataList", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(UniversalRenderPipeline.asset);
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] == renderer)
					{
						camData.SetRenderer(i);
					}
				}
			}
			else
			{
				Debug.LogError("No Universal Render Pipeline is currently active.");
			}
		}

		public static bool TransparentShadowsEnabled()
		{
			if (!UniversalRenderPipeline.asset)
			{
				return false;
			}
			UniversalRendererData universalRendererData = (UniversalRendererData)GetDefaultRenderer();
			if (!universalRendererData)
			{
				return false;
			}
			return universalRendererData.shadowTransparentReceive;
		}

		public static bool IsDepthAfterTransparents()
		{
			if (!UniversalRenderPipeline.asset)
			{
				return false;
			}
			return ((UniversalRendererData)GetDefaultRenderer()).copyDepthMode == CopyDepthMode.AfterTransparents;
		}
	}
}
