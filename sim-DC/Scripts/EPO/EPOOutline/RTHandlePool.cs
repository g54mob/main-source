using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace EPOOutline
{
	public class RTHandlePool : IDisposable
	{
		private class PoolSegment : IDisposable
		{
			private List<RTHandle> allocated;

			private Queue<RTHandle> free;

			public RTHandle GetFree()
			{
				return null;
			}

			public void ReleaseAll()
			{
			}

			public void Dispose()
			{
			}
		}

		private readonly PoolSegment textureSegment;

		private readonly PoolSegment rtiSegment;

		public RTHandle Allocate(Texture target)
		{
			return null;
		}

		public RTHandle Allocate(RenderTargetIdentifier target)
		{
			return null;
		}

		public void ReleaseAll()
		{
		}

		public void Dispose()
		{
		}
	}
}
