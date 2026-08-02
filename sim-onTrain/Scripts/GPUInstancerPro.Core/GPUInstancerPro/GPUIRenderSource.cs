using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace GPUInstancerPro
{
	public class GPUIRenderSource : IGPUIDisposable, IDisposable
	{
		public GPUIRenderSourceGroup renderSourceGroup;

		public UnityEngine.Object source;

		public int bufferStartIndex;

		public int bufferSize;

		public int instanceCount;

		public bool isDisposed;

		public int Key { get; private set; }

		public GPUIRenderSource(UnityEngine.Object source, GPUIRenderSourceGroup renderSourceGroup)
		{
			this.source = source;
			this.renderSourceGroup = renderSourceGroup;
			Key = GetKey(source, renderSourceGroup);
			bufferStartIndex = -1;
			bufferSize = 0;
			instanceCount = 0;
		}

		public void SetBufferSize(int bufferSize, bool isCopyPreviousData)
		{
			if (instanceCount < 0)
			{
				instanceCount = bufferSize;
			}
			renderSourceGroup.SetBufferSize(this, bufferSize, isCopyPreviousData);
		}

		public void SetInstanceCount(int instanceCount)
		{
			renderSourceGroup.SetInstanceCount(this, instanceCount);
		}

		public void SetTransformBufferData<T>(NativeArray<T> matrices, int managedBufferStartIndex, int graphicsBufferStartIndex, int count, bool isOverwritePreviousFrameBuffer) where T : struct
		{
			renderSourceGroup.SetTransformBufferData(this, matrices, managedBufferStartIndex, graphicsBufferStartIndex, count, isOverwritePreviousFrameBuffer);
		}

		public void SetTransformBufferData<T>(T[] matrices, int managedBufferStartIndex, int graphicsBufferStartIndex, int count, bool isOverwritePreviousFrameBuffer) where T : struct
		{
			renderSourceGroup.SetTransformBufferData(this, matrices, managedBufferStartIndex, graphicsBufferStartIndex, count, isOverwritePreviousFrameBuffer);
		}

		public void SetTransformBufferData<T>(List<T> matrices, int managedBufferStartIndex, int graphicsBufferStartIndex, int count, bool isOverwritePreviousFrameBuffer) where T : struct
		{
			renderSourceGroup.SetTransformBufferData(this, matrices, managedBufferStartIndex, graphicsBufferStartIndex, count, isOverwritePreviousFrameBuffer);
		}

		public void Dispose()
		{
			if (!isDisposed)
			{
				renderSourceGroup.Dispose(this);
				DisposeRenderSource();
			}
		}

		internal void DisposeRenderSource()
		{
			if (!isDisposed)
			{
				isDisposed = true;
				if (GPUIRenderingSystem.IsActive)
				{
					GPUIRenderingSystem.Instance.RenderSourceProvider.Remove(Key);
				}
				bufferStartIndex = -1;
				bufferSize = 0;
				instanceCount = 0;
				if (source is GPUIManager { IsInitialized: not false } gPUIManager)
				{
					gPUIManager.OnRenderSourceDisposed(Key);
				}
			}
		}

		public void ReleaseBuffers()
		{
			if (source is IGPUIDisposable iGPUIDisposable)
			{
				iGPUIDisposable.ReleaseBuffers();
			}
		}

		public static int GetKey(UnityEngine.Object source, GPUIRenderSourceGroup renderSourceGroup)
		{
			return GPUIUtility.GenerateHash(source.GetInstanceID(), renderSourceGroup.Key);
		}
	}
}
