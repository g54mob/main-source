using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering.Universal.Internal;

namespace CTS
{
	public class TestRenderingLayers : MonoBehaviour
	{
		[SerializeField]
		private UniversalRenderPipelineAsset _rendererAsset;

		[SerializeField]
		private UniversalRendererData _rendererData;

		[SerializeField]
		[Range(0f, 7f)]
		private int _firstLayer;

		[SerializeField]
		[Range(0f, 7f)]
		private int _currentLayer;

		[SerializeField]
		private Light _mainLight;

		private ScriptableRenderer _scriptableRenderer;

		private const BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic;

		private static readonly FieldInfo GBufferPassField;

		private static readonly FieldInfo DepthNormalPrepassField;

		private static readonly FieldInfo DepthOnlyPassField;

		private static readonly FieldInfo TransparentForwardPassField;

		private static readonly FieldInfo GBufferPass_FilteringSettingsField;

		private static readonly FieldInfo DepthNormalOnlyPass_FilteringSettingsField;

		private static readonly FieldInfo DepthOnlyPass_FilteringSettingsField;

		private static readonly FieldInfo DrawObjectsPass_FilteringSettingsField;

		private uint _renderingLayerMask;

		static TestRenderingLayers()
		{
			Type typeFromHandle = typeof(UniversalRenderer);
			GBufferPassField = typeFromHandle.GetField("m_GBufferPass", BindingFlags.Instance | BindingFlags.NonPublic);
			DepthNormalPrepassField = typeFromHandle.GetField("m_DepthNormalPrepass", BindingFlags.Instance | BindingFlags.NonPublic);
			DepthOnlyPassField = typeFromHandle.GetField("m_DepthOnlyPrepass", BindingFlags.Instance | BindingFlags.NonPublic);
			TransparentForwardPassField = typeFromHandle.GetField("m_RenderTransparentForwardPass", BindingFlags.Instance | BindingFlags.NonPublic);
			Type typeFromHandle2 = typeof(DrawObjectsPass);
			GBufferPass_FilteringSettingsField = GetFilteringSettingsField(typeFromHandle2.Assembly.GetType("UnityEngine.Rendering.Universal.Internal.GBufferPass"));
			DepthNormalOnlyPass_FilteringSettingsField = GetFilteringSettingsField(typeof(DepthNormalOnlyPass));
			DepthOnlyPass_FilteringSettingsField = GetFilteringSettingsField(typeof(DepthOnlyPass));
			DrawObjectsPass_FilteringSettingsField = GetFilteringSettingsField(typeFromHandle2);
		}

		private void Update()
		{
			if (_rendererAsset.scriptableRenderer != _scriptableRenderer)
			{
				UpdateFields();
			}
		}

		private void UpdateFields()
		{
			_scriptableRenderer = _rendererAsset.scriptableRenderer;
			_renderingLayerMask = (uint)(1 << _currentLayer);
			if (_rendererData.renderingMode == RenderingMode.Deferred)
			{
				UpdatePass(GBufferPassField, GBufferPass_FilteringSettingsField);
			}
			UpdatePass(DepthNormalPrepassField, DepthNormalOnlyPass_FilteringSettingsField);
			UpdatePass(TransparentForwardPassField, DrawObjectsPass_FilteringSettingsField);
		}

		private void UpdatePass(FieldInfo p_passField, FieldInfo p_filteringSettingsField)
		{
			object value = p_passField.GetValue(_scriptableRenderer);
			if (value != null)
			{
				FilteringSettings filteringSettings = (FilteringSettings)p_filteringSettingsField.GetValue(value);
				filteringSettings.renderingLayerMask = _renderingLayerMask;
				p_filteringSettingsField.SetValue(value, filteringSettings);
			}
		}

		private static FieldInfo GetFilteringSettingsField(IReflect p_type)
		{
			return p_type.GetField("m_FilteringSettings", BindingFlags.Instance | BindingFlags.NonPublic);
		}

		private void OnValidate()
		{
			if (Application.isPlaying)
			{
				UpdateFields();
			}
		}
	}
}
