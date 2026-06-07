using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Kamgam.SettingsGenerator
{
	public static class UniversalRenderPipelineUtils
	{
		private static FieldInfo MainLightCastShadows_FieldInfo;

		private static FieldInfo AdditionalLightCastShadows_FieldInfo;

		private static FieldInfo MainLightShadowmapResolution_FieldInfo;

		private static FieldInfo AdditionalLightShadowmapResolution_FieldInfo;

		private static FieldInfo Cascade2Split_FieldInfo;

		private static FieldInfo Cascade4Split_FieldInfo;

		private static FieldInfo SoftShadowsEnabled_FieldInfo;

		private static FieldInfo RenderDataList_FieldInfo;

		static UniversalRenderPipelineUtils()
		{
			try
			{
				Type typeFromHandle = typeof(UniversalRenderPipelineAsset);
				BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.NonPublic;
				MainLightCastShadows_FieldInfo = typeFromHandle.GetField("m_MainLightShadowsSupported", bindingAttr);
				AdditionalLightCastShadows_FieldInfo = typeFromHandle.GetField("m_AdditionalLightShadowsSupported", bindingAttr);
				MainLightShadowmapResolution_FieldInfo = typeFromHandle.GetField("m_MainLightShadowmapResolution", bindingAttr);
				AdditionalLightShadowmapResolution_FieldInfo = typeFromHandle.GetField("m_AdditionalLightsShadowmapResolution", bindingAttr);
				Cascade2Split_FieldInfo = typeFromHandle.GetField("m_Cascade2Split", bindingAttr);
				Cascade4Split_FieldInfo = typeFromHandle.GetField("m_Cascade4Split", bindingAttr);
				SoftShadowsEnabled_FieldInfo = typeFromHandle.GetField("m_SoftShadowsSupported", bindingAttr);
				RenderDataList_FieldInfo = typeFromHandle.GetField("m_RendererDataList", bindingAttr);
			}
			catch (Exception ex)
			{
				Debug.LogError("UniversalRenderPipelineUtils reflection cache build failed. Maybe the API has changed? \n" + ex.Message);
			}
		}

		public static void SetMainLightCastShadows(bool value, UniversalRenderPipelineAsset asset = null)
		{
			if (asset == null)
			{
				asset = (UniversalRenderPipelineAsset)GraphicsSettings.currentRenderPipeline;
			}
			if (MainLightCastShadows_FieldInfo != null)
			{
				MainLightCastShadows_FieldInfo.SetValue(asset, value);
			}
		}

		public static void SetAdditionalLightCastShadows(bool value, UniversalRenderPipelineAsset asset = null)
		{
			if (asset == null)
			{
				asset = (UniversalRenderPipelineAsset)GraphicsSettings.currentRenderPipeline;
			}
			if (AdditionalLightCastShadows_FieldInfo != null)
			{
				AdditionalLightCastShadows_FieldInfo.SetValue(asset, value);
			}
		}

		public static void SetMainLightShadowResolution(int value, UniversalRenderPipelineAsset asset = null)
		{
			if (asset == null)
			{
				asset = (UniversalRenderPipelineAsset)GraphicsSettings.currentRenderPipeline;
			}
			if (MainLightShadowmapResolution_FieldInfo != null)
			{
				MainLightShadowmapResolution_FieldInfo.SetValue(asset, value);
			}
		}

		public static void SetAdditionalLightShadowResolution(int value, UniversalRenderPipelineAsset asset = null)
		{
			if (asset == null)
			{
				asset = (UniversalRenderPipelineAsset)GraphicsSettings.currentRenderPipeline;
			}
			if (AdditionalLightShadowmapResolution_FieldInfo != null)
			{
				AdditionalLightShadowmapResolution_FieldInfo.SetValue(asset, value);
			}
		}

		public static void SetCascade2Split(float value, UniversalRenderPipelineAsset asset = null)
		{
			if (asset == null)
			{
				asset = (UniversalRenderPipelineAsset)GraphicsSettings.currentRenderPipeline;
			}
			if (Cascade2Split_FieldInfo != null)
			{
				Cascade2Split_FieldInfo.SetValue(asset, value);
			}
		}

		public static void SetCascade4Split(Vector3 value, UniversalRenderPipelineAsset asset = null)
		{
			if (asset == null)
			{
				asset = (UniversalRenderPipelineAsset)GraphicsSettings.currentRenderPipeline;
			}
			if (Cascade4Split_FieldInfo != null)
			{
				Cascade4Split_FieldInfo.SetValue(asset, value);
			}
		}

		public static void SetSoftShadowsEnabled(bool value, UniversalRenderPipelineAsset asset = null)
		{
			if (asset == null)
			{
				asset = (UniversalRenderPipelineAsset)GraphicsSettings.currentRenderPipeline;
			}
			if (SoftShadowsEnabled_FieldInfo != null)
			{
				SoftShadowsEnabled_FieldInfo.SetValue(asset, value);
			}
		}

		public static ScriptableRendererData[] GetRendererDataList(UniversalRenderPipelineAsset asset = null)
		{
			try
			{
				if (asset == null)
				{
					asset = (UniversalRenderPipelineAsset)GraphicsSettings.currentRenderPipeline;
				}
				if (asset == null)
				{
					return null;
				}
				if (RenderDataList_FieldInfo == null)
				{
					return null;
				}
				return (ScriptableRendererData[])RenderDataList_FieldInfo.GetValue(asset);
			}
			catch
			{
				return null;
			}
		}

		public static T GetRendererFeature<T>(UniversalRenderPipelineAsset asset = null) where T : ScriptableRendererFeature
		{
			ScriptableRendererData[] rendererDataList = GetRendererDataList(asset);
			if (rendererDataList == null || rendererDataList.Length == 0)
			{
				return null;
			}
			ScriptableRendererData[] array = rendererDataList;
			for (int i = 0; i < array.Length; i++)
			{
				foreach (ScriptableRendererFeature rendererFeature in array[i].rendererFeatures)
				{
					if (rendererFeature is T)
					{
						return rendererFeature as T;
					}
				}
			}
			return null;
		}

		public static ScriptableRendererFeature GetRendererFeature(string typeName, UniversalRenderPipelineAsset asset = null)
		{
			ScriptableRendererData[] rendererDataList = GetRendererDataList(asset);
			if (rendererDataList == null || rendererDataList.Length == 0)
			{
				return null;
			}
			ScriptableRendererData[] array = rendererDataList;
			for (int i = 0; i < array.Length; i++)
			{
				foreach (ScriptableRendererFeature rendererFeature in array[i].rendererFeatures)
				{
					if (!(rendererFeature == null) && rendererFeature.GetType().Name.Contains(typeName))
					{
						return rendererFeature;
					}
				}
			}
			return null;
		}

		public static T GetRendererFeatureChild<T>(ScriptableRendererFeature feature, string fieldName, string subFieldName = null)
		{
			if (feature == null)
			{
				return default(T);
			}
			FieldInfo field = feature.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
			if (field != null)
			{
				object value = field.GetValue(feature);
				if (value != null)
				{
					if (string.IsNullOrEmpty(subFieldName))
					{
						if (value is T)
						{
							return (T)value;
						}
					}
					else
					{
						FieldInfo field2 = value.GetType().GetField(subFieldName, BindingFlags.Instance | BindingFlags.NonPublic);
						if (field2 != null)
						{
							object value2 = field2.GetValue(value);
							if (value2 != null && value2 is T)
							{
								return (T)value2;
							}
						}
					}
				}
			}
			return default(T);
		}

		public static void SetRendererFeatureChild<T>(T value, ScriptableRendererFeature feature, string fieldName, string subFieldName = null)
		{
			if (feature == null)
			{
				return;
			}
			FieldInfo field = feature.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
			if (!(field != null))
			{
				return;
			}
			if (string.IsNullOrEmpty(subFieldName))
			{
				field.SetValue(feature, value);
				return;
			}
			object value2 = field.GetValue(feature);
			if (value2 != null)
			{
				FieldInfo field2 = value2.GetType().GetField(subFieldName, BindingFlags.Instance | BindingFlags.NonPublic);
				if (field2 != null)
				{
					field2.SetValue(value2, value);
				}
			}
		}

		public static bool IsRendererFeatureActive<T>(UniversalRenderPipelineAsset asset = null, bool defaultValue = false) where T : ScriptableRendererFeature
		{
			T rendererFeature = GetRendererFeature<T>(asset);
			if (rendererFeature == null)
			{
				return defaultValue;
			}
			return rendererFeature.isActive;
		}

		public static bool IsRendererFeatureActive(string typeName, UniversalRenderPipelineAsset asset = null, bool defaultValue = false)
		{
			ScriptableRendererFeature rendererFeature = GetRendererFeature(typeName, asset);
			if (rendererFeature == null)
			{
				return defaultValue;
			}
			return rendererFeature.isActive;
		}

		public static void SetRendererFeatureActive<T>(bool active, UniversalRenderPipelineAsset asset = null) where T : ScriptableRendererFeature
		{
			T rendererFeature = GetRendererFeature<T>(asset);
			if (!(rendererFeature == null))
			{
				rendererFeature.SetActive(active);
			}
		}

		public static void SetRendererFeatureActive(string typeName, bool active, UniversalRenderPipelineAsset asset = null)
		{
			ScriptableRendererFeature rendererFeature = GetRendererFeature(typeName, asset);
			if (!(rendererFeature == null))
			{
				rendererFeature.SetActive(active);
			}
		}
	}
}
