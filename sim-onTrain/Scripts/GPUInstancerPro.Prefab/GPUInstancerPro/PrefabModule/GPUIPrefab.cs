using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GPUInstancerPro.PrefabModule
{
	[DefaultExecutionOrder(200)]
	[HelpURL("https://wiki.gurbu.com/index.php?title=GPU_Instancer_Pro:GettingStarted#GPUI_Prefab")]
	public class GPUIPrefab : GPUIPrefabBase
	{
		[SerializeField]
		private int _prefabID;

		[SerializeField]
		private bool _isRenderersDisabled;

		[NonSerialized]
		public UnityEvent OnInstancingStatusModified;

		private Transform _cachedTransform;

		private static List<Renderer> _rendererList;

		public bool IsRenderersDisabled => _isRenderersDisabled;

		public GPUIPrefabManager registeredManager { get; internal set; }

		public int renderKey { get; internal set; }

		public int bufferIndex { get; private set; }

		public bool IsInstanced => renderKey != 0;

		public Transform CachedTransform => _cachedTransform;

		private void Awake()
		{
			Initialize();
		}

		internal void Initialize()
		{
			if (_cachedTransform == null)
			{
				_cachedTransform = base.transform;
			}
		}

		internal void SetInstancingData(GPUIPrefabManager registeredManager, int prefabID, int renderKey, int bufferIndex, Type[] rendererTypes)
		{
			this.registeredManager = registeredManager;
			this.renderKey = renderKey;
			this.bufferIndex = bufferIndex;
			if (_prefabID == 0)
			{
				_prefabID = prefabID;
			}
			SetRenderersEnabled(enabled: false, rendererTypes);
			OnInstancingStatusModified?.Invoke();
		}

		internal void ClearInstancingData(bool enableRenderers, Type[] rendererTypes)
		{
			registeredManager = null;
			renderKey = 0;
			bufferIndex = -1;
			if (enableRenderers)
			{
				SetRenderersEnabled(enabled: true, rendererTypes);
			}
			OnInstancingStatusModified?.Invoke();
		}

		public void RemovePrefabInstance()
		{
			if (IsInstanced && !registeredManager.RemovePrefabInstance(this))
			{
				Debug.LogError("Can not remove prefab instance with prefab ID: " + GetPrefabID(), this);
			}
		}

		internal void UpdateTransformData()
		{
			if (IsInstanced && _cachedTransform.hasChanged)
			{
				registeredManager.UpdateTransformData(this);
			}
		}

		public void SetRenderersEnabled(bool enabled, params Type[] rendererTypes)
		{
			if (_isRenderersDisabled != enabled)
			{
				return;
			}
			if (_rendererList == null)
			{
				_rendererList = new List<Renderer>();
			}
			GetComponentsInChildren(includeInactive: true, _rendererList);
			foreach (Renderer renderer in _rendererList)
			{
				foreach (Type type in rendererTypes)
				{
					if (renderer.GetType() == type)
					{
						renderer.enabled = enabled;
					}
				}
			}
			if (TryGetComponent<LODGroup>(out var component))
			{
				component.enabled = enabled;
			}
			_isRenderersDisabled = !enabled;
		}

		internal void SetBufferIndex(int bufferIndex)
		{
			this.bufferIndex = bufferIndex;
			OnInstancingStatusModified?.Invoke();
		}

		public int GetPrefabID()
		{
			return _prefabID;
		}
	}
}
