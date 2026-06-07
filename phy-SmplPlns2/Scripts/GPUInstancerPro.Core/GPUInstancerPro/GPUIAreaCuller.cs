using System;
using System.Collections.Generic;
using UnityEngine;

namespace GPUInstancerPro
{
	[HelpURL("https://wiki.gurbu.com/index.php?title=GPU_Instancer_Pro:GettingStarted#GPUI_Area_Culler")]
	[DefaultExecutionOrder(1200)]
	[ExecuteInEditMode]
	public class GPUIAreaCuller : MonoBehaviour
	{
		[SerializeField]
		public bool useColliders = true;

		[SerializeField]
		public Bounds bounds;

		[SerializeField]
		public List<GPUIManager> gpuiManagerFilter;

		[SerializeField]
		public List<int> prototypeIndexFilter;

		[SerializeField]
		public float offset;

		[NonSerialized]
		private Collider[] _colliders;

		private void OnEnable()
		{
			if (useColliders)
			{
				_colliders = GetComponents<Collider>();
				if (Application.isPlaying && (_colliders == null || _colliders.Length == 0))
				{
					Debug.LogWarning(GPUIConstants.LOG_PREFIX + "GPUI Area Culler can not find any colliders on its GameObject.", base.gameObject);
					base.enabled = false;
					return;
				}
			}
			GPUIRenderingSystem.OnBufferDataModified = (GPUIRenderingSystem.OnBufferDataModifiedCallback)Delegate.Remove(GPUIRenderingSystem.OnBufferDataModified, new GPUIRenderingSystem.OnBufferDataModifiedCallback(CullInstances));
			GPUIRenderingSystem.OnBufferDataModified = (GPUIRenderingSystem.OnBufferDataModifiedCallback)Delegate.Combine(GPUIRenderingSystem.OnBufferDataModified, new GPUIRenderingSystem.OnBufferDataModifiedCallback(CullInstances));
			OnValuesChanged();
		}

		private void OnDisable()
		{
			GPUIRenderingSystem.OnBufferDataModified = (GPUIRenderingSystem.OnBufferDataModifiedCallback)Delegate.Remove(GPUIRenderingSystem.OnBufferDataModified, new GPUIRenderingSystem.OnBufferDataModifiedCallback(CullInstances));
			OnValuesChanged();
		}

		private void Update()
		{
			if (base.transform.hasChanged)
			{
				OnValuesChanged();
			}
		}

		public void OnValuesChanged()
		{
			base.transform.hasChanged = false;
			GPUITransformBufferUtility.ResetAllCulledInstances();
		}

		private void CullInstances(GPUITransformBufferData transformBufferData)
		{
			if (useColliders && (_colliders == null || _colliders.Length == 0))
			{
				return;
			}
			int bufferStartIndex = 0;
			int bufferSize = transformBufferData.RenderSourceGroup.BufferSize;
			bool flag = prototypeIndexFilter != null && prototypeIndexFilter.Count > 0;
			if (gpuiManagerFilter != null && gpuiManagerFilter.Count > 0)
			{
				for (int i = 0; i < gpuiManagerFilter.Count; i++)
				{
					GPUIManager gPUIManager = gpuiManagerFilter[i];
					if (gPUIManager == null)
					{
						continue;
					}
					int prototypeCount = gPUIManager.GetPrototypeCount();
					for (int j = 0; j < prototypeCount; j++)
					{
						if ((flag && !prototypeIndexFilter.Contains(j)) || !GPUIRenderingSystem.TryGetTransformBufferData(gPUIManager.GetRenderKey(j), out var transformBufferData2, out bufferStartIndex, out bufferSize) || transformBufferData2 != transformBufferData)
						{
							continue;
						}
						if (useColliders)
						{
							Collider[] colliders = _colliders;
							foreach (Collider collider in colliders)
							{
								GPUITransformBufferUtility.CullInstancesInsideCollider(transformBufferData, bufferStartIndex, bufferSize, collider, offset);
							}
						}
						else
						{
							Bounds bounds = this.bounds;
							bounds.center += base.transform.position;
							GPUITransformBufferUtility.CullInstancesInsideBounds(transformBufferData, bufferStartIndex, bufferSize, bounds, offset);
						}
					}
				}
			}
			else if (useColliders)
			{
				Collider[] colliders = _colliders;
				foreach (Collider collider2 in colliders)
				{
					GPUITransformBufferUtility.CullInstancesInsideCollider(transformBufferData, bufferStartIndex, bufferSize, collider2, offset);
				}
			}
			else
			{
				Bounds bounds2 = this.bounds;
				bounds2.center += base.transform.position;
				GPUITransformBufferUtility.CullInstancesInsideBounds(transformBufferData, bufferStartIndex, bufferSize, bounds2, offset);
			}
		}
	}
}
