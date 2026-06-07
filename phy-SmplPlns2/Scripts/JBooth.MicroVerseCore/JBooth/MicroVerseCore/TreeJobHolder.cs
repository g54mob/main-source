using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

namespace JBooth.MicroVerseCore
{
	public class TreeJobHolder
	{
		public UnpackTreeInstanceJob job;

		public JobHandle handle;

		public NativeArray<half4> placementData;

		public NativeArray<half4> randomData;

		private RenderTexture filteredInstances;

		private RenderTexture randomResults;

		private AsyncGPUReadbackRequest gpuRequestPlacement;

		private AsyncGPUReadbackRequest gpuRequestRandoms;

		private NativeArray<int> treeIndexes;

		public bool canceled { get; set; }

		public bool IsDone()
		{
			if (MicroVerse.noAsyncReadback)
			{
				handle.Complete();
			}
			if (gpuRequestPlacement.done && gpuRequestRandoms.done)
			{
				return handle.IsCompleted;
			}
			return false;
		}

		public void Cleanup()
		{
			handle.Complete();
			if (placementData.IsCreated)
			{
				placementData.Dispose();
			}
			if (randomData.IsCreated)
			{
				randomData.Dispose();
			}
			if (treeIndexes.IsCreated)
			{
				treeIndexes.Dispose();
			}
			if (job.count.IsCreated)
			{
				job.count.Dispose();
			}
			if (job.trees.IsCreated)
			{
				job.trees.Dispose();
			}
		}

		public void Dispose()
		{
			Cleanup();
		}

		private void LaunchJob()
		{
			job = new UnpackTreeInstanceJob
			{
				placementData = placementData,
				randomData = randomData,
				count = new NativeArray<int>(1, Allocator.TempJob),
				trees = new NativeArray<TreeInstance>(placementData.Length, Allocator.TempJob),
				treeIndexes = treeIndexes
			};
			handle = job.Schedule();
		}

		private void OnAsyncCompletePositions(AsyncGPUReadbackRequest obj)
		{
			RenderTexture.active = null;
			if (filteredInstances != null)
			{
				RenderTexture.active = null;
				Object.DestroyImmediate(filteredInstances);
			}
			filteredInstances = null;
			if (!(randomResults == null))
			{
				return;
			}
			if (canceled)
			{
				if (placementData.IsCreated)
				{
					placementData.Dispose();
				}
				if (randomData.IsCreated)
				{
					randomData.Dispose();
				}
				if (treeIndexes.IsCreated)
				{
					treeIndexes.Dispose();
				}
			}
			else
			{
				LaunchJob();
			}
		}

		private void OnAsyncCompleteRandoms(AsyncGPUReadbackRequest obj)
		{
			RenderTexture.active = null;
			if (randomResults != null)
			{
				Object.DestroyImmediate(randomResults);
			}
			randomResults = null;
			if (!(filteredInstances == null))
			{
				return;
			}
			if (canceled)
			{
				if (placementData.IsCreated)
				{
					placementData.Dispose();
				}
				if (randomData.IsCreated)
				{
					randomData.Dispose();
				}
				if (treeIndexes.IsCreated)
				{
					treeIndexes.Dispose();
				}
			}
			else
			{
				LaunchJob();
			}
		}

		public void AddJob(RenderTexture filteredInstances, RenderTexture randomResults, NativeArray<int> treeIndexes)
		{
			this.treeIndexes = treeIndexes;
			this.filteredInstances = filteredInstances;
			this.randomResults = randomResults;
			if (MicroVerse.noAsyncReadback)
			{
				Texture2D texture2D = new Texture2D(filteredInstances.width, filteredInstances.height, TextureFormat.RGBAHalf, mipChain: false, linear: true);
				Texture2D texture2D2 = new Texture2D(filteredInstances.width, filteredInstances.height, TextureFormat.RGBAHalf, mipChain: false, linear: true);
				RenderTexture.active = filteredInstances;
				texture2D.ReadPixels(new Rect(0f, 0f, texture2D.width, texture2D.height), 0, 0);
				texture2D.Apply();
				placementData = texture2D.GetRawTextureData<half4>();
				RenderTexture.active = randomResults;
				texture2D2.ReadPixels(new Rect(0f, 0f, randomResults.width, randomResults.height), 0, 0);
				texture2D2.Apply();
				randomData = texture2D2.GetRawTextureData<half4>();
				LaunchJob();
				Object.DestroyImmediate(texture2D);
				Object.DestroyImmediate(texture2D2);
			}
			else
			{
				placementData = new NativeArray<half4>(filteredInstances.width * filteredInstances.height, Allocator.Persistent);
				randomData = new NativeArray<half4>(filteredInstances.width * filteredInstances.height, Allocator.Persistent);
				gpuRequestPlacement = AsyncGPUReadback.RequestIntoNativeArray(ref placementData, filteredInstances, 0, OnAsyncCompletePositions);
				gpuRequestRandoms = AsyncGPUReadback.RequestIntoNativeArray(ref randomData, randomResults, 0, OnAsyncCompleteRandoms);
			}
		}
	}
}
