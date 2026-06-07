using System;
using System.Collections.Generic;
using UnityEngine;

namespace GPUInstancerPro.PrefabModule
{
	public class GPUIMaterialVariationData : IGPUIDisposable, IDisposable
	{
		private GPUIMaterialVariationDefinition _definition;

		private GPUIDataBuffer<Vector4> _variationBuffer;

		private bool _isInitialized;

		private List<int> _renderKeys;

		public GPUIMaterialVariationData(GPUIMaterialVariationDefinition definition)
		{
			_definition = definition;
		}

		internal void Initialize()
		{
			if (_isInitialized)
			{
				return;
			}
			if (_definition == null)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Can not find Material Variation Definition.");
				return;
			}
			Shader shader = _definition.replacementShader;
			if (shader == null)
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Can not find Replacement Shader for the Material Variation Definition. Please make sure to Generate Shader for the Material Variation Definition.", _definition);
				shader = GPUIShaderBindings.Instance.ErrorShader;
			}
			_isInitialized = true;
			if (_variationBuffer == null)
			{
				_variationBuffer = new GPUIDataBuffer<Vector4>(_definition.bufferName);
			}
			if (_renderKeys == null)
			{
				_renderKeys = new List<int>();
			}
			GPUIRenderingSystem.InitializeRenderingSystem();
			if (!(_definition.material.shader == shader))
			{
				List<string> list = new List<string> { GPUIPrefabConstants.Kw_GPUI_MATERIAL_VARIATION };
				int instanceID = _definition.material.GetInstanceID();
				instanceID = GPUIUtility.GenerateHash(instanceID, string.Concat(list).GetHashCode());
				if (!GPUIRenderingSystem.Instance.MaterialProvider.TryGetData(instanceID, out var result) || !(result != null) || !result.name.EndsWith("_MV" + GPUIShaderBindings.GPUI_REPLACEMENT_MATERIAL_NAME_SUFFIX))
				{
					result = new Material(shader);
					result.CopyPropertiesFromMaterial(_definition.material);
					result.name = _definition.material.name + "_MV" + GPUIShaderBindings.GPUI_REPLACEMENT_MATERIAL_NAME_SUFFIX;
					result.hideFlags = HideFlags.HideAndDontSave;
					result.EnableKeyword(GPUIPrefabConstants.Kw_GPUI_MATERIAL_VARIATION);
					GPUIRenderingSystem.Instance.MaterialProvider.AddOrSet(instanceID, result);
					list.Add("LOD_FADE_CROSSFADE");
					list.Sort();
					instanceID = GPUIUtility.GenerateHash(_definition.material.GetInstanceID(), string.Concat(list).GetHashCode());
					result = new Material(result);
					result.name = _definition.material.name + "_MV" + GPUIShaderBindings.GPUI_REPLACEMENT_MATERIAL_NAME_SUFFIX;
					result.EnableKeyword("LOD_FADE_CROSSFADE");
					GPUIRenderingSystem.Instance.MaterialProvider.AddOrSet(instanceID, result);
				}
			}
		}

		public void ReleaseBuffers()
		{
			if (_isInitialized)
			{
				_isInitialized = false;
				if (_variationBuffer != null)
				{
					_variationBuffer.ReleaseBuffers();
				}
			}
		}

		public void Dispose()
		{
			ReleaseBuffers();
			if (_variationBuffer != null)
			{
				_variationBuffer.Dispose();
			}
			_variationBuffer = null;
			_renderKeys = null;
		}

		public void AddVariation(int renderKey, int bufferIndex, Vector4 value)
		{
			Initialize();
			if (_isInitialized)
			{
				_variationBuffer.AddOrSet(bufferIndex, value);
				if (!_renderKeys.Contains(renderKey))
				{
					_renderKeys.Add(renderKey);
					GPUIRenderingSystem.AddDependentDisposable(renderKey, this);
				}
			}
		}

		public void UpdateVariationBuffer()
		{
			if (!_isInitialized || !_variationBuffer.UpdateBufferData())
			{
				return;
			}
			foreach (int renderKey in _renderKeys)
			{
				GPUIRenderingSystem.AddMaterialPropertyOverride(renderKey, _definition.bufferName, _variationBuffer.Buffer);
			}
		}
	}
}
