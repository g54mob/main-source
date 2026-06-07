using System;
using UnityEngine;

namespace GPUInstancerPro
{
	public abstract class GPUISystemExtension : MonoBehaviour, IGPUIDisposable, IDisposable
	{
		public abstract void Dispose();

		public virtual void ReleaseBuffers()
		{
		}

		public virtual void OnCreatedRenderSourceGroup(GPUIRenderSourceGroup renderSourceGroup)
		{
		}

		public virtual void OnRemovedRenderSourceGroup(int renderSourceGroupKey)
		{
		}

		public virtual void OnRenderSourceGroupBufferSizeChanged(GPUIRenderSourceGroup renderSourceGroup)
		{
		}

		public virtual void OnCreatedRenderSource(GPUIRenderSource renderSource)
		{
		}

		public virtual void OnRemovedRenderSource(int key)
		{
		}

		public virtual void OnRenderSourceBufferSizeChanged(GPUIRenderSource renderSource, int previousBufferSize)
		{
		}

		public virtual void ExecuteOnPreCull(GPUICameraData cameraData)
		{
		}

		public virtual void ExecuteOnPreRender(GPUICameraData cameraData)
		{
		}

		public virtual void ExecuteOnPostRender(GPUICameraData cameraData)
		{
		}
	}
}
