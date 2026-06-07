using System;
using DV.PointSet;
using MeshXtensions;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

namespace DV
{
	[BurstCompile]
	public struct MeshSweeperJob : IJob
	{
		private readonly struct MeshSweeperVertexData
		{
			public static readonly VertexAttributeDescriptor[] Layout = new VertexAttributeDescriptor[4]
			{
				new VertexAttributeDescriptor(VertexAttribute.Position, VertexAttributeFormat.Float32, 3, 0),
				new VertexAttributeDescriptor(VertexAttribute.Normal),
				new VertexAttributeDescriptor(VertexAttribute.Tangent, VertexAttributeFormat.Float32, 4),
				new VertexAttributeDescriptor(VertexAttribute.TexCoord0, VertexAttributeFormat.Float32, 2)
			};

			public readonly float3 position;

			public readonly float3 normal;

			public readonly float4 tangent;

			public readonly float2 uv;

			public MeshSweeperVertexData(float3 position, float3 normal, float4 tangent, float2 uv)
			{
				this.position = position;
				this.normal = normal;
				this.tangent = tangent;
				this.uv = uv;
			}
		}

		private NativeArray<MeshSweeperVertexData> vertices;

		private NativeArray<int> triangles;

		[WriteOnly]
		private NativeArray<Bounds> bounds;

		[ReadOnly]
		[DeallocateOnJobCompletion]
		private NativeArray<Vector3> positions;

		[DeallocateOnJobCompletion]
		[ReadOnly]
		private NativeArray<Vector3> forwards;

		[ReadOnly]
		[DeallocateOnJobCompletion]
		private NativeArray<Vector3> ups;

		[ReadOnly]
		[DeallocateOnJobCompletion]
		private NativeArray<double> spans;

		[ReadOnly]
		[DeallocateOnJobCompletion]
		private NativeArray<Vector2> shapePoints;

		[DeallocateOnJobCompletion]
		[ReadOnly]
		private NativeArray<float> shapeDistances;

		private double pointSetSpan;

		private float totalShapeDistance;

		private UVType uvPath;

		private float uvPathScale;

		private UVType uvShape;

		private float uvShapeScale;

		private bool capEnd;

		private const string PROF_ctor = "MeshSweeperJob constructor";

		private const string PROF_AfterComplete_mesh = "AfterComplete mesh calls";

		private const string PROF_AfterComplete_dispose = "AfterComplete dispose";

		public MeshSweeperJob(EquiPointSet pSet, int fromIndex, int toIndex, Vector3 globalOffset, Vector2[] shapePoints, UVType uvPath = UVType.DistanceTiled, float uvPathScale = 1f, UVType uvShape = UVType.Equidistant, float uvShapeScale = 1f, bool capEnd = false)
		{
			this.uvPath = uvPath;
			this.uvPathScale = uvPathScale;
			this.uvShape = uvShape;
			this.uvShapeScale = uvShapeScale;
			this.capEnd = capEnd;
			toIndex = Mathf.Clamp(toIndex + 1, 0, pSet.points.Length - 1);
			int num = toIndex - fromIndex + 1;
			positions = new NativeArray<Vector3>(num, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
			forwards = new NativeArray<Vector3>(num, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
			ups = new NativeArray<Vector3>(num, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
			spans = new NativeArray<double>(num, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
			for (int i = 0; i < num; i++)
			{
				EquiPointSet.Point point = pSet.points[i + fromIndex];
				positions[i] = (Vector3)point.position + globalOffset;
				forwards[i] = point.forward;
				ups[i] = point.up;
				spans[i] = point.span;
			}
			pointSetSpan = pSet.span;
			this.shapePoints = new NativeArray<Vector2>(shapePoints, Allocator.TempJob);
			shapeDistances = new NativeArray<float>(shapePoints.Length, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
			totalShapeDistance = 0f;
			for (int j = 0; j < shapePoints.Length - 1; j++)
			{
				totalShapeDistance += Vector2.Distance(shapePoints[j], shapePoints[j + 1]);
				shapeDistances[j] = totalShapeDistance;
			}
			int length = num * shapePoints.Length;
			int length2 = (num - 1) * (shapePoints.Length - 1) * 6 + (capEnd ? ((shapePoints.Length / 2 - 1) * 6 * 2 + 6) : 0);
			vertices = new NativeArray<MeshSweeperVertexData>(length, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
			triangles = new NativeArray<int>(length2, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
			bounds = new NativeArray<Bounds>(1, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
		}

		public JobHandle ScheduleSelf()
		{
			return this.Schedule();
		}

		public void AfterComplete(Mesh mesh)
		{
			mesh.SetVertexBufferParams(vertices.Length, MeshSweeperVertexData.Layout);
			mesh.SetVertexBufferData(vertices, 0, 0, vertices.Length, 0, MeshUpdateFlags.DontValidateIndices | MeshUpdateFlags.DontResetBoneBounds | MeshUpdateFlags.DontNotifyMeshUsers | MeshUpdateFlags.DontRecalculateBounds);
			mesh.SetIndexBufferParams(triangles.Length, IndexFormat.UInt32);
			mesh.SetIndexBufferData(triangles, 0, 0, triangles.Length, MeshUpdateFlags.DontValidateIndices | MeshUpdateFlags.DontResetBoneBounds | MeshUpdateFlags.DontNotifyMeshUsers | MeshUpdateFlags.DontRecalculateBounds);
			mesh.SetSubMesh(0, new SubMeshDescriptor(0, triangles.Length), MeshUpdateFlags.DontValidateIndices | MeshUpdateFlags.DontResetBoneBounds | MeshUpdateFlags.DontNotifyMeshUsers | MeshUpdateFlags.DontRecalculateBounds);
			mesh.bounds = bounds[0];
			vertices.Dispose();
			triangles.Dispose();
			bounds.Dispose();
		}

		public void Execute()
		{
			float3 float5 = float3.zero;
			float3 float6 = float3.zero;
			int num = (capEnd ? ((shapePoints.Length / 2 - 1) * 6 * 2 + 6) : 0);
			int trianglesAddedForEndCaps = 0;
			int endCapStartIndex = triangles.Length - num;
			for (int i = 0; i < positions.Length; i++)
			{
				Vector3 vector = positions[i];
				Vector3 forward = forwards[i];
				Vector3 upwards = ups[i];
				Vector2 zero = Vector2.zero;
				Quaternion quaternion2 = Quaternion.LookRotation(forward, upwards);
				switch (uvPath)
				{
				case UVType.DistanceTiled:
					zero.y = (float)(spans[i] * (double)uvPathScale);
					break;
				case UVType.SegmentBased:
					zero.y = (float)i * uvPathScale;
					break;
				case UVType.Equidistant:
					if (pointSetSpan != 0.0)
					{
						zero.y = (float)(spans[i] / pointSetSpan) * uvPathScale;
					}
					break;
				default:
					throw new NotImplementedException();
				}
				for (int j = 0; j < shapePoints.Length; j++)
				{
					int num2 = i * shapePoints.Length + j;
					Vector3 vector2 = quaternion2 * shapePoints[j];
					Vector3 vector3 = vector + vector2;
					Vector4 vector4 = ((j == 0) ? (quaternion2 * shapePoints[j + 1] - vector2) : (vector2 - quaternion2 * shapePoints[j - 1])).normalized;
					vector4.w = -1f;
					if (i > 0 && j > 0)
					{
						int num3 = num2 - shapePoints.Length;
						int num4 = ((i - 1) * (shapePoints.Length - 1) + (j - 1)) * 6;
						triangles[num4++] = num3 - 1;
						triangles[num4++] = num2 - 1;
						triangles[num4++] = num3;
						triangles[num4++] = num3;
						triangles[num4++] = num2 - 1;
						triangles[num4++] = num2;
					}
					switch (uvShape)
					{
					case UVType.DistanceTiled:
						zero.x = ((j == 0) ? 0f : (shapeDistances[j - 1] * uvShapeScale));
						break;
					case UVType.SegmentBased:
						zero.x = (float)j / ((float)shapePoints.Length - 1f);
						break;
					case UVType.Equidistant:
						if (totalShapeDistance != 0f && j != 0)
						{
							zero.x = shapeDistances[j - 1] / totalShapeDistance * uvShapeScale;
						}
						break;
					}
					float5 = math.min(float5, vector3);
					float6 = math.max(float6, vector3);
					vertices[num2] = new MeshSweeperVertexData(vector3, float3.zero, vector4, zero);
				}
				if (capEnd)
				{
					if (i == 0)
					{
						trianglesAddedForEndCaps = DoCap(reversed: true, trianglesAddedForEndCaps, i, endCapStartIndex);
					}
					if (i == positions.Length - 1)
					{
						trianglesAddedForEndCaps = DoCap(reversed: false, trianglesAddedForEndCaps, i, endCapStartIndex);
					}
				}
			}
			Bounds value = default(Bounds);
			value.SetMinMax(float5, float6);
			bounds[0] = value;
			NativeArray<float3> nativeArray = new NativeArray<float3>(vertices.Length, Allocator.Temp);
			for (int k = 0; k < triangles.Length; k += 3)
			{
				int index = triangles[k];
				int index2 = triangles[k + 1];
				int index3 = triangles[k + 2];
				float3 float7 = math.cross(vertices[index2].position - vertices[index].position, vertices[index3].position - vertices[index].position);
				nativeArray[index] += float7;
				nativeArray[index2] += float7;
				nativeArray[index3] += float7;
			}
			for (int l = 0; l < vertices.Length; l++)
			{
				MeshSweeperVertexData meshSweeperVertexData = vertices[l];
				float3 normal = math.normalize(nativeArray[l]);
				vertices[l] = new MeshSweeperVertexData(meshSweeperVertexData.position, normal, meshSweeperVertexData.tangent, meshSweeperVertexData.uv);
			}
			nativeArray.Dispose();
		}

		private int DoCap(bool reversed, int trianglesAddedForEndCaps, int pointIndex, int endCapStartIndex)
		{
			for (int i = 0; i < shapePoints.Length / 2; i++)
			{
				int num = pointIndex * shapePoints.Length + i;
				int value = num + 1;
				int num2 = shapePoints.Length - i - 1;
				int num3 = pointIndex * shapePoints.Length + num2;
				int value2 = num3 - 1;
				bool flag = i == shapePoints.Length / 2 - 1;
				if (reversed)
				{
					triangles[endCapStartIndex + trianglesAddedForEndCaps] = num;
					trianglesAddedForEndCaps++;
					triangles[endCapStartIndex + trianglesAddedForEndCaps] = value;
					trianglesAddedForEndCaps++;
					triangles[endCapStartIndex + trianglesAddedForEndCaps] = num3;
					trianglesAddedForEndCaps++;
					if (!flag)
					{
						triangles[endCapStartIndex + trianglesAddedForEndCaps] = num3;
						trianglesAddedForEndCaps++;
						triangles[endCapStartIndex + trianglesAddedForEndCaps] = value;
						trianglesAddedForEndCaps++;
						triangles[endCapStartIndex + trianglesAddedForEndCaps] = value2;
						trianglesAddedForEndCaps++;
					}
				}
				else
				{
					triangles[endCapStartIndex + trianglesAddedForEndCaps] = num;
					trianglesAddedForEndCaps++;
					triangles[endCapStartIndex + trianglesAddedForEndCaps] = num3;
					trianglesAddedForEndCaps++;
					triangles[endCapStartIndex + trianglesAddedForEndCaps] = value;
					trianglesAddedForEndCaps++;
					if (!flag)
					{
						triangles[endCapStartIndex + trianglesAddedForEndCaps] = value;
						trianglesAddedForEndCaps++;
						triangles[endCapStartIndex + trianglesAddedForEndCaps] = num3;
						trianglesAddedForEndCaps++;
						triangles[endCapStartIndex + trianglesAddedForEndCaps] = value2;
						trianglesAddedForEndCaps++;
					}
				}
			}
			return trianglesAddedForEndCaps;
		}
	}
}
