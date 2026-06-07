using System;
using Assets.Scripts.Bindings.Manifold;
using Assets.Scripts.Craft.MeshGen;
using Shapes;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.CarverParts
{
	[BurstCompile]
	public abstract class TrapezoidMeshModifierScript : MeshModifierBaseScript
	{
		[BurstCompile]
		private struct MakeTrapezoidManifoldJob : IJob
		{
			public float2 upperSpan;

			public float2 lowerSpan;

			public float height;

			public float depth;

			public float cornerRadius;

			public NativeMesh targetMesh;

			public NativeReference<bool> success;

			[NativeDisableUnsafePtrRestriction]
			public unsafe void* manifoldStorage;

			public unsafe void Execute()
			{
				NativeMesh mesh = targetMesh;
				mesh.SetRunMaterial(5);
				NativeList<float2> other = new NativeList<float2>(4, Allocator.Temp);
				float2 float5 = math.float2(0f, height) * 0.5f;
				if (lowerSpan.y != lowerSpan.x)
				{
					other.AddNoResize(math.float2(lowerSpan.y, 0f) - float5);
				}
				other.AddNoResize(math.float2(lowerSpan.x, 0f) - float5);
				other.AddNoResize(math.float2(upperSpan.x, 0f) + float5);
				if (upperSpan.y != upperSpan.x)
				{
					other.AddNoResize(math.float2(upperSpan.y, 0f) + float5);
				}
				bool num = cornerRadius > 0f;
				NativeList<float2> points = new NativeList<float2>(32, Allocator.Temp);
				NativeList<float2> normals = new NativeList<float2>(32, Allocator.Temp);
				if (num)
				{
					SimpleInset.Inflate(radius: SimpleInset.Inset(insetBy: cornerRadius * SimpleInset.EstimateMaxInset(other), inPoints: other, minSize: 0f), inPoints: other, outPoints: points, outNormals: normals);
				}
				else
				{
					points.CopyFrom(in other);
				}
				int length = points.Length;
				float num2 = depth * 0.5f;
				mesh.Start();
				EmitPoints(0f - num2, math.back());
				Geometry.fanfill(mesh, reverse: true);
				mesh.Start();
				if (num)
				{
					EmitPoints(0f - num2, null);
					EmitPoints(num2, null);
					Geometry.extrude(mesh, 0, length, length);
				}
				else
				{
					NativeArray<float3> pointsA = new NativeArray<float3>(other.Length, Allocator.Temp);
					NativeArray<float3> pointsB = new NativeArray<float3>(other.Length, Allocator.Temp);
					for (int i = 0; i < other.Length; i++)
					{
						float2 xy = other[i];
						pointsA[i] = new float3(xy, 0f - num2);
						pointsB[i] = new float3(xy, num2);
					}
					Geometry.extrudeSharp(mesh, pointsA, pointsB);
				}
				mesh.Start();
				EmitPoints(num2, math.forward());
				Geometry.fanfill(mesh);
				mesh.ToManifoldNative(manifoldStorage);
				success.Value = true;
				void EmitPoints(float zOffset, float3? normalOverride)
				{
					for (int j = 0; j < points.Length; j++)
					{
						mesh.Vert(new float3(points[j], zOffset), normalOverride ?? new float3(normals[j], 0f));
					}
				}
			}
		}

		private ProceduralPartMeshRenderer _debugRenderer;

		public new TrapezoidMeshModifierData Data
		{
			get
			{
				return (TrapezoidMeshModifierData)base.Data;
			}
			set
			{
				base.Data = value;
			}
		}

		public override void OnMirrored(PartData sourcePart)
		{
			base.OnMirrored(sourcePart);
			Data.MirrorData();
		}

		protected unsafe override Manifold<Vertex> MakeManifold(Allocator allocator)
		{
			void* ptr = MeshGL<Vertex>.AllocNative(allocator);
			using NativeReference<bool> success = new NativeReference<bool>(Allocator.TempJob);
			using NativeMesh nativeMesh = new NativeMesh(256, 256, Allocator.TempJob);
			new MakeTrapezoidManifoldJob
			{
				upperSpan = Data.UpperSpan,
				lowerSpan = Data.LowerSpan,
				height = Data.Height,
				depth = Data.Depth,
				cornerRadius = Data.CornerRadius,
				targetMesh = nativeMesh,
				manifoldStorage = ptr,
				success = success
			}.Run();
			if (!success.Value)
			{
				UnsafeUtility.Free(ptr, allocator);
				if (_debugRenderer == null)
				{
					_debugRenderer = new ProceduralPartMeshRenderer(base.PartScript, "debug", base.LoadContext);
				}
				_debugRenderer.UpdateMesh(nativeMesh);
				Debug.LogError("Failed to generate trapezoid manifold");
				return null;
			}
			Manifold<Vertex> manifold;
			if ((manifold = new Manifold<Vertex>((NativeMethods.Manifold*)ptr, allocator)).Status != Error.NO_ERROR)
			{
				if (_debugRenderer == null)
				{
					_debugRenderer = new ProceduralPartMeshRenderer(base.PartScript, "debug", base.LoadContext)
					{
						EnableTransparency = false
					};
				}
				_debugRenderer.UpdateMesh(nativeMesh);
				Debug.LogError($"Failed to generate trapezoid manifold: {manifold.Status}");
			}
			else
			{
				_debugRenderer?.Destroy();
				_debugRenderer = null;
			}
			return manifold;
		}

		protected override void DrawBox()
		{
			_ = base.transform;
			Draw.Matrix = base.transform.localToWorldMatrix;
			float2 upperSpan = Data.UpperSpan;
			float2 lowerSpan = Data.LowerSpan;
			float num = Data.Height * 0.5f;
			float y = 0f - num;
			float num2 = Data.Depth * 0.5f;
			float z = 0f - num2;
			Span<float3> points = stackalloc float3[8];
			points[0] = new float3(upperSpan.x, num, z);
			points[1] = new float3(upperSpan.y, num, z);
			points[2] = new float3(lowerSpan.y, y, z);
			points[3] = new float3(lowerSpan.x, y, z);
			points[4] = new float3(upperSpan.x, num, num2);
			points[5] = new float3(upperSpan.y, num, num2);
			points[6] = new float3(lowerSpan.y, y, num2);
			points[7] = new float3(lowerSpan.x, y, num2);
			Utility.DrawBoxFromPoints(points);
		}
	}
}
