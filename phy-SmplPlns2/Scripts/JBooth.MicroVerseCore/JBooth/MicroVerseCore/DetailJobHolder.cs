using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Rendering;

namespace JBooth.MicroVerseCore
{
	public class DetailJobHolder
	{
		private AsyncGPUReadbackRequest gpuRequest;

		private RenderTexture detailLayer;

		public Terrain terrain;

		private NativeArray<byte> rawData;

		private int width;

		private int height;

		private static int[,] resultValues;

		public int detailIndex { get; private set; }

		public bool canceled { get; set; }

		public bool IsDone()
		{
			return gpuRequest.done;
		}

		public void Dispose()
		{
			RenderTexture.active = null;
			RenderTexture.ReleaseTemporary(detailLayer);
		}

		private void OnAsynComplete(AsyncGPUReadbackRequest obj)
		{
			if (canceled)
			{
				if (rawData.IsCreated)
				{
					rawData.Dispose();
				}
				return;
			}
			if (resultValues == null || width * height != resultValues.Length)
			{
				resultValues = new int[width, height];
			}
			NativeArray<int> nativeArray = new NativeArray<int>(rawData.Length, Allocator.TempJob);
			IJobParallelForExtensions.Schedule(new UnityAPISucksJob
			{
				source = rawData,
				target = nativeArray
			}, nativeArray.Length, 4096).Complete();
			nativeArray.CopyToFast(resultValues);
			nativeArray.Dispose();
			rawData.Dispose();
			RenderTexture.active = null;
			RenderTexture.ReleaseTemporary(detailLayer);
			if (terrain != null && terrain.terrainData != null)
			{
				terrain.terrainData.SetDetailLayer(0, 0, detailIndex, resultValues);
			}
		}

		public void AddJob(RenderTexture detailLayer, int detailIndex)
		{
			width = detailLayer.width;
			height = detailLayer.height;
			this.detailIndex = detailIndex;
			this.detailLayer = detailLayer;
			if (MicroVerse.noAsyncReadback)
			{
				Texture2D texture2D = new Texture2D(detailLayer.width, detailLayer.height, TextureFormat.R8, mipChain: false, linear: true);
				RenderTexture.active = detailLayer;
				texture2D.ReadPixels(new Rect(0f, 0f, texture2D.width, texture2D.height), 0, 0);
				RenderTexture.active = null;
				texture2D.Apply();
				if (resultValues == null || width * height != resultValues.Length)
				{
					resultValues = new int[width, height];
				}
				NativeArray<byte> rawTextureData = texture2D.GetRawTextureData<byte>();
				rawTextureData.CopyToFastByteToInt(resultValues);
				rawTextureData.Dispose();
				RenderTexture.active = null;
				RenderTexture.ReleaseTemporary(detailLayer);
				Object.DestroyImmediate(texture2D);
				terrain.terrainData.SetDetailLayer(0, 0, detailIndex, resultValues);
			}
			else
			{
				rawData = new NativeArray<byte>(width * height, Allocator.Persistent);
				gpuRequest = AsyncGPUReadback.RequestIntoNativeArray(ref rawData, detailLayer, 0, OnAsynComplete);
			}
		}
	}
}
