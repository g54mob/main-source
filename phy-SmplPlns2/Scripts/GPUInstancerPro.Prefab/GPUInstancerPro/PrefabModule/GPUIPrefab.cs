using UnityEngine;

namespace GPUInstancerPro.PrefabModule
{
	[DefaultExecutionOrder(200)]
	[HelpURL("https://wiki.gurbu.com/index.php?title=GPU_Instancer_Pro:GettingStarted#GPUI_Prefab")]
	public class GPUIPrefab : GPUIPrefabBase
	{
		[SerializeField]
		private bool _isRenderersDisabled;

		internal bool _isBeingAddedToThePrefabManager;

		public bool IsRenderersDisabled => _isRenderersDisabled;

		public GPUIPrefabManager registeredManager { get; internal set; }

		internal void SetInstancingData(GPUIPrefabManager registeredManager, int prefabID, int renderKey, int bufferIndex)
		{
			this.registeredManager = registeredManager;
			base.renderKey = renderKey;
			base.bufferIndex = bufferIndex;
			if (_prefabID == 0)
			{
				_prefabID = prefabID;
			}
			registeredManager.SetPrefabInstanceRenderersEnabled(this, enabled: false);
			_isBeingAddedToThePrefabManager = false;
			OnInstancingStatusModified?.Invoke();
		}

		internal void ClearInstancingData(bool enableRenderers)
		{
			if (enableRenderers && registeredManager != null)
			{
				registeredManager.SetPrefabInstanceRenderersEnabled(this, enabled: true);
			}
			registeredManager = null;
			base.renderKey = 0;
			base.bufferIndex = -1;
			_isBeingAddedToThePrefabManager = false;
			OnInstancingStatusModified?.Invoke();
		}

		public void RemovePrefabInstance()
		{
			if (base.IsInstanced && !registeredManager.RemovePrefabInstance(this))
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "Can not remove prefab instance with prefab ID: " + GetPrefabID(), this);
			}
		}

		internal void UpdateTransformData()
		{
			if (base.IsInstanced && base.CachedTransform.hasChanged)
			{
				registeredManager.UpdateTransformData(this);
			}
		}

		public void SetRenderersEnabled(bool enabled)
		{
			if (_isRenderersDisabled != enabled)
			{
				return;
			}
			GPUIRenderingSystem.prefabRendererList.Clear();
			base.transform.GetPrefabRenderers(GPUIRenderingSystem.prefabRendererList);
			foreach (Renderer prefabRenderer in GPUIRenderingSystem.prefabRendererList)
			{
				prefabRenderer.enabled = enabled;
			}
			if (TryGetComponent<LODGroup>(out var component))
			{
				component.enabled = enabled;
			}
			_isRenderersDisabled = !enabled;
		}

		internal void SetBufferIndex(int bufferIndex)
		{
			int num = base.bufferIndex;
			if (num != bufferIndex)
			{
				base.bufferIndex = bufferIndex;
				OnBufferIndexModified?.Invoke(num);
			}
		}

		protected override void OnOptionalRendererStatusChanged()
		{
			if (base.IsInstanced)
			{
				GPUIPrefabPrototypeData prototypeDataWithRenderKey = registeredManager.GetPrototypeDataWithRenderKey(base.renderKey);
				if (prototypeDataWithRenderKey != null)
				{
					prototypeDataWithRenderKey.optionalRendererStatusData[base.bufferIndex] = base.optionalRendererStatus;
					prototypeDataWithRenderKey.isOptionalRendererStatusModified = true;
				}
			}
		}

		public override void SetMaterialVariation(int index, Vector4 variationValue)
		{
			if (!TryGetComponent<GPUIMaterialVariationInstance>(out var component))
			{
				Debug.LogError(GPUIConstants.LOG_PREFIX + "The prefab instance does not contain a GPUIMaterialVariationInstance component, so the variation cannot be set.");
			}
			else
			{
				component.SetVariation(index, variationValue);
			}
		}
	}
}
