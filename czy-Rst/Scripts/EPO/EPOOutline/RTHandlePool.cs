using System;
using System.Collections.Generic;
using EPOOutline.Utility;
using UnityEngine;
using UnityEngine.Rendering;

namespace EPOOutline
{
	public class RTHandlePool : IDisposable
	{
		private class PoolSegment : IDisposable
		{
			private List<RTHandle> allocated = new List<RTHandle>();

			private Queue<RTHandle> free = new Queue<RTHandle>();

			public RTHandle GetFree()
			{
				if (free.Count != 0)
				{
					return free.Dequeue();
				}
				RTHandle rTHandle = OutlineEffect.HandleSystem.Alloc(default(RenderTargetIdentifier));
				allocated.Add(rTHandle);
				return rTHandle;
			}

			public void ReleaseAll()
			{
				free.Clear();
				foreach (RTHandle item in allocated)
				{
					free.Enqueue(item);
				}
			}

			public void Dispose()
			{
				foreach (RTHandle item in allocated)
				{
					item.Release();
				}
				allocated.Clear();
				free.Clear();
			}
		}

		private readonly PoolSegment textureSegment = new PoolSegment();

		private readonly PoolSegment rtiSegment = new PoolSegment();

		public RTHandle Allocate(Texture target)
		{
			RTHandle free = textureSegment.GetFree();
			free.SetTexture(target);
			return free;
		}

		public RTHandle Allocate(RenderTargetIdentifier target)
		{
			RTHandle free = rtiSegment.GetFree();
			free.SetRenderTargetIdentifier(target);
			return free;
		}

		public void ReleaseAll()
		{
			textureSegment.ReleaseAll();
			rtiSegment.ReleaseAll();
		}

		public void Dispose()
		{
			textureSegment.Dispose();
			rtiSegment.Dispose();
		}
	}
}
