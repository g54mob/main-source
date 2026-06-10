using System;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace NGS.MeshFusionPro
{
	public class JobsMeshMoverLW : IAsyncCombinedMeshMover, ICombinedMeshMover, IDisposable
	{
		[BurstCompile]
		private struct MovePartsJob : IJobParallelFor
		{
			[NativeDisableParallelForRestriction]
			public NativeArray<LightweightVertex> vertices;

			[ReadOnly]
			public NativeArray<LightweightVertex> localVertices;

			[WriteOnly]
			[NativeDisableParallelForRestriction]
			public NativeArray<Bounds> bounds;

			[ReadOnly]
			[NativeDisableParallelForRestriction]
			public NativeArray<Bounds> localBounds;

			[ReadOnly]
			public NativeList<PartMoveInfo> moveInfos;

			public void Execute(int idx)
			{
				PartMoveInfo partMoveInfo = moveInfos[idx];
				int partIndex = partMoveInfo.partIndex;
				int vertexStart = partMoveInfo.vertexStart;
				int num = vertexStart + partMoveInfo.vertexCount;
				Matrix4x4 targetTransform = partMoveInfo.targetTransform;
				for (int i = vertexStart; i < num; i++)
				{
					LightweightVertex lightweightVertex = localVertices[i];
					float w = lightweightVertex.tanW;
					Vector3 normalized = targetTransform.MultiplyVector(lightweightVertex.Normal).normalized;
					Vector4 tangent = targetTransform.MultiplyVector(lightweightVertex.Tangent).normalized;
					tangent.w = w;
					LightweightVertex value = new LightweightVertex
					{
						Position = targetTransform.MultiplyPoint3x4(lightweightVertex.Position),
						Normal = normalized,
						Tangent = tangent,
						uv = lightweightVertex.uv,
						uv2 = lightweightVertex.uv2
					};
					vertices[i] = value;
				}
				bounds[partIndex] = localBounds[partIndex].Transform(targetTransform);
			}
		}

		[BurstCompile]
		private struct RecalculateBoundsJob : IJob
		{
			public NativeArray<Bounds> bounds;

			public NativeArray<Bounds> boundingBox;

			public void Execute()
			{
				Bounds value = boundingBox[0];
				value.size = Vector3.zero;
				for (int i = 0; i < bounds.Length; i++)
				{
					value.Encapsulate(bounds[i]);
				}
				boundingBox[0] = value;
			}
		}

		private MeshDataNativeArraysLW _meshData;

		private NativeList<PartMoveInfo> _moveInfos;

		private JobHandle _handle;

		public JobsMeshMoverLW(MeshDataNativeArraysLW meshData)
		{
			_meshData = meshData;
			_moveInfos = new NativeList<PartMoveInfo>(Allocator.Persistent);
		}

		public void MoveParts(IList<PartMoveInfo> moveInfos)
		{
			MovePartsAsync(moveInfos);
			FinishAsyncMoving();
		}

		public void MovePartsAsync(IList<PartMoveInfo> moveInfos)
		{
			NativeArray<Bounds> bounds = _meshData.Bounds;
			bounds[0] = new Bounds(_meshData.GetBounds().center, Vector3.zero);
			_moveInfos.Clear();
			for (int i = 0; i < moveInfos.Count; i++)
			{
				_moveInfos.Add(moveInfos[i]);
			}
			MovePartsJob jobData = new MovePartsJob
			{
				vertices = _meshData.Vertices,
				bounds = _meshData.PartsBounds,
				localVertices = _meshData.VerticesLocal,
				localBounds = _meshData.PartsBoundsLocal,
				moveInfos = _moveInfos
			};
			RecalculateBoundsJob jobData2 = new RecalculateBoundsJob
			{
				bounds = _meshData.PartsBounds,
				boundingBox = bounds
			};
			_handle = IJobExtensions.Schedule(jobData2, IJobParallelForExtensions.Schedule(jobData, _moveInfos.Length, 4));
		}

		public void FinishAsyncMoving()
		{
			_handle.Complete();
		}

		public void ApplyData()
		{
			if (!_handle.IsCompleted)
			{
				FinishAsyncMoving();
			}
			_meshData.ApplyDataToMesh();
		}

		public void Dispose()
		{
			_moveInfos.Dispose();
		}
	}
}
