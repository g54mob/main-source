using System;
using DV.Utils;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace DV.VFX
{
	public class CeilingDetection : SingletonBehaviour<CeilingDetection>
	{
		public struct WorldPositionedArray
		{
			public float2 startCorner;

			public float2 endCorner;

			public int2 arraySize;

			public int GetIndex(float3 worldPosition)
			{
				if (worldPosition.x < startCorner.x || worldPosition.x > endCorner.x)
				{
					return -1;
				}
				if (worldPosition.z < startCorner.y || worldPosition.z > endCorner.y)
				{
					return -1;
				}
				float num = math.unlerp(startCorner.x, endCorner.x, worldPosition.x);
				float num2 = math.unlerp(startCorner.y, endCorner.y, worldPosition.z);
				int num3 = (int)(0.5f + num * (float)(arraySize.x - 1));
				int num4 = (int)(0.5f + num2 * (float)(arraySize.y - 1));
				return num3 + num4 * arraySize.x;
			}

			public int GetIndex(int x, int y)
			{
				return x + y * arraySize.x;
			}

			public float3 GetPosition(int x, int y)
			{
				return new float3(math.lerp(startCorner.x, endCorner.x, (float)x / ((float)arraySize.x - 1f)), 0f, math.lerp(startCorner.y, endCorner.y, (float)y / ((float)arraySize.y - 1f)));
			}

			public void Update(float3 center, int2 arrSize, float gridSeparation)
			{
				arraySize = arrSize;
				float2 float5 = (arraySize - new float2(1f, 1f)) * gridSeparation;
				float2 float6 = new float2(center.x, center.z);
				startCorner = float6 - float5 * 0.5f;
				endCorner = float6 + float5 * 0.5f;
			}
		}

		[BurstCompile]
		public struct SetRaysJob : IJobParallelFor
		{
			[NativeDisableParallelForRestriction]
			public NativeArray<RaycastCommand> commands;

			public WorldPositionedArray worldPositionedArray;

			public int layerMask;

			public void Execute(int x)
			{
				for (int i = 0; i < worldPositionedArray.arraySize.y; i++)
				{
					float3 position = worldPositionedArray.GetPosition(x, i);
					position.y = 1000f;
					commands[worldPositionedArray.GetIndex(x, i)] = new RaycastCommand(position, Vector3.down, 1050f, layerMask);
				}
			}
		}

		private const float UPDATE_RATE_PER_SECOND = 3f;

		private const float UPDATE_RATE = 1f / 3f;

		private const float FIRE_FROM_HEIGHT = 1000f;

		private const float FIRE_DISTANCE = 1050f;

		public int2 arraySize;

		public LayerMask layerMask;

		public float gridSeparation;

		[NonSerialized]
		public WorldPositionedArray worldPositionedArray;

		[NonSerialized]
		public NativeArray<RaycastHit> results;

		[NonSerialized]
		public NativeArray<RaycastHit> copiedResults;

		private NativeArray<RaycastCommand> commands;

		private SetRaysJob setRaysJob;

		private JobHandle handle;

		private float lastStartTime;

		public new static string AllowAutoCreate()
		{
			return null;
		}

		private void Start()
		{
			results = new NativeArray<RaycastHit>(arraySize.x * arraySize.y, Allocator.Persistent);
			copiedResults = new NativeArray<RaycastHit>(arraySize.x * arraySize.y, Allocator.Persistent);
			commands = new NativeArray<RaycastCommand>(arraySize.x * arraySize.y, Allocator.Persistent);
			setRaysJob = new SetRaysJob
			{
				worldPositionedArray = worldPositionedArray,
				commands = commands,
				layerMask = layerMask
			};
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			handle.Complete();
			if (results.IsCreated)
			{
				results.Dispose();
			}
			if (copiedResults.IsCreated)
			{
				copiedResults.Dispose();
			}
			if (commands.IsCreated)
			{
				commands.Dispose();
			}
		}

		private void Update()
		{
			if (Time.time - lastStartTime > 1f / 3f && handle.IsCompleted)
			{
				handle.Complete();
				results.CopyTo(copiedResults);
				Camera activeCamera = PlayerManager.ActiveCamera;
				worldPositionedArray.Update((activeCamera != null) ? activeCamera.transform.position : base.transform.position, arraySize, gridSeparation);
				setRaysJob.worldPositionedArray = worldPositionedArray;
				handle = setRaysJob.Schedule(worldPositionedArray.arraySize.x, 1);
				handle = RaycastCommand.ScheduleBatch(commands, results, worldPositionedArray.arraySize.x, handle);
				lastStartTime = Time.time;
			}
		}
	}
}
