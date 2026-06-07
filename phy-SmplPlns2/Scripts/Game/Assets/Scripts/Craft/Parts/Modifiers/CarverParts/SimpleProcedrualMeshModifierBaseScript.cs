using System;
using Assets.Scripts.Bindings.Manifold;
using Assets.Scripts.Craft.MeshGen;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.CarverParts
{
	public abstract class SimpleProcedrualMeshModifierBaseScript : ScalableMeshModifierBaseScript
	{
		[BurstCompile]
		private struct GenerateRoundedManifoldJob : IJob
		{
			public float cornerRadius;

			public int numPoints;

			public NativeMesh result;

			public float3 scale;

			public void Execute()
			{
				float3 float5 = math.max(scale, 0.01f);
				float num = math.cmin(float5.xy) * 0.5f * math.saturate(cornerRadius);
				NativeList<float2> points = new NativeList<float2>(numPoints * 4, Allocator.Temp);
				NativeList<float2> normals = new NativeList<float2>(numPoints * 4, Allocator.Temp);
				float num2 = MathF.PI * 2f / (float)((numPoints - 1) * 4);
				float2 float6 = float5.xy * 0.5f - num;
				float2x2 a = float2x2.identity;
				Span<int> span = stackalloc int[4];
				span[1] = (span[3] = ((math.abs(float6.x) <= 0.001f) ? (numPoints - 1) : numPoints));
				span[0] = (span[2] = ((math.abs(float6.y) <= 0.001f) ? (numPoints - 1) : numPoints));
				float2 float7 = default(float2);
				for (int i = 0; i < 4; i++)
				{
					for (int j = 0; j < span[i]; j++)
					{
						math.sincos(num2 * (float)j, out float7.x, out float7.y);
						normals.Add(math.mul(a, float7));
						float7 = float7 * num + float6;
						points.Add(math.mul(a, float7));
					}
					float6 = float6.yx;
					a = new float2x2(a.c0.y, a.c1.y, 0f - a.c0.x, 0f - a.c1.x);
				}
				NativeArray<int> lastIndices = new NativeArray<int>(points.Length, Allocator.Temp);
				NativeArray<int> indices = new NativeArray<int>(points.Length, Allocator.Temp);
				NativeMesh mesh = result;
				float num3 = float5.z * 0.5f;
				EmitWithNormal(0f - num3, math.back());
				FanFill();
				Emit(0f - num3);
				Emit(num3);
				Join();
				EmitWithNormal(num3, math.forward());
				FanFillReverse();
				void Emit(float z)
				{
					for (int k = 0; k < points.Length; k++)
					{
						lastIndices[k] = indices[k];
						indices[k] = mesh.Vert(math.float3(points[k], z), math.float3(normals[k], 0f));
					}
				}
				void EmitWithNormal(float z, float3 normal)
				{
					for (int k = 0; k < points.Length; k++)
					{
						lastIndices[k] = indices[k];
						indices[k] = mesh.Vert(math.float3(points[k], z), normal);
					}
				}
				void FanFill()
				{
					for (int k = 2; k < indices.Length; k++)
					{
						mesh.Tri(indices[k - 1], indices[k], indices[0]);
					}
				}
				void FanFillReverse()
				{
					for (int k = 2; k < indices.Length; k++)
					{
						mesh.Tri(indices[0], indices[k], indices[k - 1]);
					}
				}
				void Join()
				{
					for (int k = 0; k < indices.Length; k++)
					{
						int index = (k + 1) % indices.Length;
						mesh.Quad(lastIndices[index], lastIndices[k], indices[k], indices[index]);
					}
				}
			}
		}

		public new SimpleProceduralMeshModifierBaseData Data => (SimpleProceduralMeshModifierBaseData)base.Data;

		protected override Manifold<Vertex> MakeManifold(Allocator allocator)
		{
			using NativeMesh result = new NativeMesh(64, 64, Allocator.TempJob, 5);
			new GenerateRoundedManifoldJob
			{
				result = result,
				scale = Data.Scale,
				numPoints = 5,
				cornerRadius = Data.CornerRadius
			}.Run();
			Error status;
			Manifold<Vertex> manifold = result.ToManifold(allocator, out status);
			if (manifold == null)
			{
				Debug.LogError($"Manifold build error: {status}", this);
			}
			return manifold;
		}
	}
}
