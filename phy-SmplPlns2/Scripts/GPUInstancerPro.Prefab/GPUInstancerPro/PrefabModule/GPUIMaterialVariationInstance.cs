using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GPUInstancerPro.PrefabModule
{
	[ExecuteInEditMode]
	[DefaultExecutionOrder(2000)]
	[RequireComponent(typeof(GPUIPrefab))]
	[HelpURL("https://wiki.gurbu.com/index.php?title=GPU_Instancer_Pro:BestPractices#Prefab_Manager_Material_Variations")]
	public class GPUIMaterialVariationInstance : MonoBehaviour
	{
		[SerializeField]
		public GPUIMaterialVariationDefinition variationDefinition;

		[SerializeField]
		public Vector4[] values;

		[NonSerialized]
		private GPUIPrefab _gpuiPrefab;

		[NonSerialized]
		private List<Renderer> _variationRenderers;

		[NonSerialized]
		private MaterialPropertyBlock _variationMPB;

		private void OnEnable()
		{
			if (!(variationDefinition == null))
			{
				if (_gpuiPrefab == null)
				{
					_gpuiPrefab = GetComponent<GPUIPrefab>();
				}
				ApplyVariation();
				GPUIPrefab gpuiPrefab = _gpuiPrefab;
				gpuiPrefab.OnInstancingStatusModified = (UnityAction)Delegate.Remove(gpuiPrefab.OnInstancingStatusModified, new UnityAction(ApplyVariation));
				GPUIPrefab gpuiPrefab2 = _gpuiPrefab;
				gpuiPrefab2.OnInstancingStatusModified = (UnityAction)Delegate.Combine(gpuiPrefab2.OnInstancingStatusModified, new UnityAction(ApplyVariation));
			}
		}

		private void OnDisable()
		{
			if (_gpuiPrefab != null)
			{
				GPUIPrefab gpuiPrefab = _gpuiPrefab;
				gpuiPrefab.OnInstancingStatusModified = (UnityAction)Delegate.Remove(gpuiPrefab.OnInstancingStatusModified, new UnityAction(ApplyVariation));
			}
			RevertVariation();
		}

		private void LoadVariationRenderers()
		{
			if (_variationRenderers == null)
			{
				_variationRenderers = new List<Renderer>();
			}
			else
			{
				_variationRenderers.Clear();
			}
			Renderer[] componentsInChildren = GetComponentsInChildren<Renderer>();
			foreach (Renderer renderer in componentsInChildren)
			{
				Material[] sharedMaterials = renderer.sharedMaterials;
				for (int j = 0; j < sharedMaterials.Length; j++)
				{
					if (sharedMaterials[j] == variationDefinition.material)
					{
						_variationRenderers.Add(renderer);
					}
				}
			}
		}

		private void CreateVariationMPB()
		{
			_variationMPB = new MaterialPropertyBlock();
			SetMPBValues();
		}

		private void SetMPBValues()
		{
			for (int i = 0; i < variationDefinition.items.Length; i++)
			{
				switch (variationDefinition.items[i].variationType)
				{
				case GPUIMaterialVariationType.Vector4:
					_variationMPB.SetVector(variationDefinition.items[i].propertyName, GetVariation(i));
					break;
				case GPUIMaterialVariationType.Color:
					_variationMPB.SetColor(variationDefinition.items[i].propertyName, GetVariation(i));
					break;
				case GPUIMaterialVariationType.Integer:
					_variationMPB.SetInt(variationDefinition.items[i].propertyName, (int)GetVariation(i).x);
					break;
				case GPUIMaterialVariationType.Float:
					_variationMPB.SetFloat(variationDefinition.items[i].propertyName, GetVariation(i).x);
					break;
				}
			}
		}

		public Vector4 GetVariation(int index)
		{
			if (values != null && values.Length > index)
			{
				return values[index];
			}
			return variationDefinition.items[index].defaultValue;
		}

		public void ApplyVariation()
		{
			if (base.enabled && !(variationDefinition == null) && variationDefinition.items != null)
			{
				if (_gpuiPrefab == null)
				{
					_gpuiPrefab = GetComponent<GPUIPrefab>();
				}
				if (_gpuiPrefab.IsInstanced)
				{
					SetVariationBufferData();
				}
				else if (!_gpuiPrefab.IsRenderersDisabled)
				{
					ApplyVariationMPB();
				}
			}
		}

		public void SetVariation(int index, Vector4 variationValue)
		{
			if (values == null)
			{
				values = new Vector4[index + 1];
			}
			if (values.Length <= index)
			{
				Array.Resize(ref values, index + 1);
			}
			values[index] = variationValue;
			ApplyVariation();
		}

		private void RevertVariation()
		{
			if (_gpuiPrefab == null || _gpuiPrefab.IsInstanced)
			{
				return;
			}
			if (_variationRenderers == null)
			{
				LoadVariationRenderers();
			}
			foreach (Renderer variationRenderer in _variationRenderers)
			{
				variationRenderer.SetPropertyBlock(GPUIRenderingSystem.EmptyMPB);
			}
		}

		private void SetVariationBufferData()
		{
			int num = variationDefinition.items.Length;
			for (int i = 0; i < num; i++)
			{
				if (variationDefinition.items[i].variationType == GPUIMaterialVariationType.Color && QualitySettings.activeColorSpace == ColorSpace.Linear)
				{
					variationDefinition.AddVariation(_gpuiPrefab.renderKey, _gpuiPrefab.bufferIndex * num + i, ((Color)GetVariation(i)).linear);
				}
				else
				{
					variationDefinition.AddVariation(_gpuiPrefab.renderKey, _gpuiPrefab.bufferIndex * num + i, GetVariation(i));
				}
			}
		}

		private void ApplyVariationMPB()
		{
			if (_variationMPB == null)
			{
				CreateVariationMPB();
			}
			else
			{
				SetMPBValues();
			}
			if (_variationRenderers == null)
			{
				LoadVariationRenderers();
			}
			foreach (Renderer variationRenderer in _variationRenderers)
			{
				variationRenderer.SetPropertyBlock(_variationMPB);
			}
		}
	}
}
