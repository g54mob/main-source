using System;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace NGS.MeshFusionPro
{
	public class JobsMeshMoverSTD : IAsyncCombinedMeshMover, ICombinedMeshMover, IDisposable
	{
		[BurstCompile]
		private struct MovePartsJob : IJobParallelFor
		{
			[NativeDisableParallelForRestriction]
			public NativeArray<Vector3> vertices;

			[NativeDisableParallelForRestriction]
			public NativeArray<Vector3> normals;

			[NativeDisableParallelForRestriction]
			public NativeArray<Vector4> tangents;

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
				Matrix4x4 inverse = partMoveInfo.currentTransform.inverse;
				for (int i = vertexStart; i < num; i++)
				{
					Vector3 point = vertices[i];
					Vector3 vector = normals[i];
					Vector4 vector2 = tangents[i];
					float w = vector2.w;
					point = inverse.MultiplyPoint3x4(point);
					point = targetTransform.MultiplyPoint3x4(point);
					vector = inverse.MultiplyVector(vector);
					vector = targetTransform.MultiplyVector(vector);
					vector2 = inverse.MultiplyVector(vector2);
					vector2 = targetTransform.MultiplyVector(vector2);
					vector2.w = w;
					vertices[i] = point;
					normals[i] = vector;
					tangents[i] = vector2;
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
				for (int i = 0; i < bounds.Length; i++)
				{
					value.Encapsulate(bounds[i]);
				}
				boundingBox[0] = value;
			}
		}

		private MeshDataNativeArraysSTD _meshData;

		private NativeList<PartMoveInfo> _moveInfos;

		private JobHandle _handle;

		public JobsMeshMoverSTD(MeshDataNativeArraysSTD meshData)
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
				normals = _meshData.Normals,
				tangents = _meshData.Tangents,
				bounds = _meshData.PartsBounds,
				localBounds = _meshData.PartsBoundsLocal,
				moveInfos = _moveInfos
			};
			RecalculateBoundsJob jobData2 = new RecalculateBoundsJob
			{
				bounds = _meshData.PartsBounds,
				boundingBox = bounds
			};
			_handle = jobData2.Schedule(IJobParallelForExtensions.Schedule(jobData, _moveInfos.Length, 4));
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
