using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GPUInstancerPro
{
	public abstract class GPUIPrefabBase : GPUIPrefabDefinition
	{
		[SerializeField]
		protected int _prefabID;

		[SerializeField]
		public List<GPUIOptionalRenderer> childOptionalRenderers;

		protected Transform _cachedTransform;

		public UnityAction OnInstancingStatusModified;

		public Action<int> OnBufferIndexModified;

		public int renderKey { get; protected set; }

		public int bufferIndex { get; protected set; }

		public bool IsInstanced => renderKey != 0;

		public Transform CachedTransform
		{
			get
			{
				if (_cachedTransform == null)
				{
					_cachedTransform = base.transform;
				}
				return _cachedTransform;
			}
		}

		public uint optionalRendererStatus { get; protected set; }

		internal int AddOptionalRenderer(GPUIOptionalRenderer optionalRenderer)
		{
			if (childOptionalRenderers == null)
			{
				childOptionalRenderers = new List<GPUIOptionalRenderer>();
			}
			int num = childOptionalRenderers.IndexOf(optionalRenderer);
			if (num == -1)
			{
				num = childOptionalRenderers.Count;
				childOptionalRenderers.Add(optionalRenderer);
			}
			return num;
		}

		internal void SetOptionalRendererEnabled(GPUIOptionalRenderer optionalRenderer, bool enabled)
		{
			if (optionalRenderer.optionalRendererNo > 0 && optionalRenderer.optionalRendererNo <= 32)
			{
				int num = optionalRenderer.optionalRendererNo - 1;
				if (enabled)
				{
					optionalRendererStatus |= (uint)(1 << num);
				}
				else
				{
					optionalRendererStatus &= (uint)(~(1 << num));
				}
				OnOptionalRendererStatusChanged();
			}
		}

		protected virtual void OnOptionalRendererStatusChanged()
		{
		}

		public int GetPrefabID()
		{
			return _prefabID;
		}

		public virtual void SetMaterialVariation(int index, Vector4 variationValue)
		{
		}
	}
}
