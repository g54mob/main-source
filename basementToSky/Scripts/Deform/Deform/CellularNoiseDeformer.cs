using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Deform
{
	[Deformer(Name = "Cellular Noise", Description = "Adds cellular noise to mesh", Type = typeof(CellularNoiseDeformer), Category = Category.Noise)]
	[HelpURL("https://github.com/keenanwoodall/Deform/wiki/CellularNoiseDeformer")]
	public class CellularNoiseDeformer : NoiseDeformer, IFactor
	{
		[BurstCompile(CompileSynchronously = true)]
		public struct _3DNoiseJob : IJobParallelFor
		{
			public float3 magnitude;

			public float3 frequency;

			public float4 offset;

			public float4x4 meshToAxis;

			public float4x4 axisToMesh;

			public NativeArray<float3> vertices;

			public void Execute(int index)
			{
				float3 xyz = math.mul(meshToAxis, math.float4(vertices[index], 1f)).xyz;
				float3 float5 = xyz * frequency;
				float3 float6 = frequency * 0.5f;
				xyz += math.float3(math.remap(0f, 1f, -1f, 1f, noise.cellular(math.float3(float5.x - float6.x + offset.x, float5.y - float6.y + offset.y, float5.z - float6.z + offset.z)).x), math.remap(0f, 1f, -1f, 1f, noise.cellular(math.float3(float5.x + offset.x, float5.y + offset.y, float5.z + offset.z)).x), math.remap(0f, 1f, -1f, 1f, noise.cellular(math.float3(float5.x + float6.x + offset.x, float5.y + float6.y + offset.y, float5.z + float6.z + offset.z)).x)) * magnitude;
				vertices[index] = math.mul(axisToMesh, math.float4(xyz, 1f)).xyz;
			}
		}

		[BurstCompile(CompileSynchronously = true)]
		public struct DirectionalNoiseJob : IJobParallelFor
		{
			public float magnitude;

			public float3 frequency;

			public float4 offset;

			public float4x4 meshToAxis;

			public float4x4 axisToMesh;

			public NativeArray<float3> vertices;

			public void Execute(int index)
			{
				float3 xyz = math.mul(meshToAxis, math.float4(vertices[index], 1f)).xyz;
				xyz += math.float3(0f, 0f, 1f) * math.remap(0f, 1f, -1f, 1f, noise.cellular(math.float3(xyz.x * frequency.x + offset.x, xyz.y * frequency.y + offset.y, xyz.z * frequency.z + offset.z)).x) * magnitude;
				vertices[index] = math.mul(axisToMesh, math.float4(xyz, 1f)).xyz;
			}
		}

		[BurstCompile(CompileSynchronously = true)]
		public struct NormalNoiseJob : IJobParallelFor
		{
			public float magnitude;

			public float3 frequency;

			public float4 offset;

			public float4x4 meshToAxis;

			public float4x4 axisToMesh;

			public NativeArray<float3> vertices;

			public NativeArray<float3> normals;

			public void Execute(int index)
			{
				float3 xyz = math.mul(meshToAxis, math.float4(vertices[index], 1f)).xyz;
				xyz += normals[index] * math.remap(0f, 1f, -1f, 1f, noise.cellular(math.float3(xyz.x * frequency.x + offset.x, xyz.y * frequency.y + offset.y, xyz.z * frequency.z + offset.z)).x) * magnitude;
				vertices[index] = math.mul(axisToMesh, math.float4(xyz, 1f)).xyz;
			}
		}

		[BurstCompile(CompileSynchronously = true)]
		public struct SphericalNoiseJob : IJobParallelFor
		{
			public float magnitude;

			public float3 frequency;

			public float4 offset;

			public float4x4 meshToAxis;

			public float4x4 axisToMesh;

			public NativeArray<float3> vertices;

			public void Execute(int index)
			{
				float3 xyz = math.mul(meshToAxis, math.float4(vertices[index], 1f)).xyz;
				xyz += math.normalize(xyz) * math.remap(0f, 1f, -1f, 1f, noise.cellular(math.float3(xyz.x * frequency.x + offset.x, xyz.y * frequency.y + offset.y, xyz.z * frequency.z + offset.z)).x) * magnitude;
				vertices[index] = math.mul(axisToMesh, math.float4(xyz, 1f)).xyz;
			}
		}

		[BurstCompile(CompileSynchronously = true)]
		public struct ColorNoiseJob : IJobParallelFor
		{
			public float magnitude;

			public float3 frequency;

			public float4 offset;

			public float4x4 meshToAxis;

			public float4x4 axisToMesh;

			public NativeArray<float3> vertices;

			public NativeArray<float4> colors;

			public void Execute(int index)
			{
				float3 xyz = math.mul(meshToAxis, math.float4(vertices[index], 1f)).xyz;
				xyz += colors[index].xyz * math.remap(0f, 1f, -1f, 1f, noise.cellular(math.float3(xyz.x * frequency.x + offset.x, xyz.y * frequency.y + offset.y, xyz.z * frequency.z + offset.z)).x) * magnitude;
				vertices[index] = math.mul(axisToMesh, math.float4(xyz, 1f)).xyz;
			}
		}

		protected override JobHandle Create3DNoiseJob(MeshData data, JobHandle dependency = default(JobHandle))
		{
			Matrix4x4 meshToAxisSpace = DeformerUtils.GetMeshToAxisSpace(base.Axis, data.Target.GetTransform());
			return new _3DNoiseJob
			{
				magnitude = GetActualMagnitude(),
				frequency = GetActualFrequency(),
				offset = GetActualOffset(),
				meshToAxis = meshToAxisSpace,
				axisToMesh = meshToAxisSpace.inverse,
				vertices = data.DynamicNative.VertexBuffer
			}.Schedule(data.Length, 64, dependency);
		}

		protected override JobHandle CreateDirectionalNoiseJob(MeshData data, JobHandle dependency = default(JobHandle))
		{
			Matrix4x4 meshToAxisSpace = DeformerUtils.GetMeshToAxisSpace(base.Axis, data.Target.GetTransform());
			return new DirectionalNoiseJob
			{
				magnitude = base.MagnitudeScalar,
				frequency = GetActualFrequency(),
				offset = GetActualOffset(),
				meshToAxis = meshToAxisSpace,
				axisToMesh = meshToAxisSpace.inverse,
				vertices = data.DynamicNative.VertexBuffer
			}.Schedule(data.Length, 64, dependency);
		}

		protected override JobHandle CreateNormalNoiseJob(MeshData data, JobHandle dependency = default(JobHandle))
		{
			Matrix4x4 meshToAxisSpace = DeformerUtils.GetMeshToAxisSpace(base.Axis, data.Target.GetTransform());
			return new NormalNoiseJob
			{
				magnitude = base.MagnitudeScalar,
				frequency = GetActualFrequency(),
				offset = GetActualOffset(),
				meshToAxis = meshToAxisSpace,
				axisToMesh = meshToAxisSpace.inverse,
				vertices = data.DynamicNative.VertexBuffer,
				normals = data.DynamicNative.NormalBuffer
			}.Schedule(data.Length, 64, dependency);
		}

		protected override JobHandle CreateSphericalNoiseJob(MeshData data, JobHandle dependency = default(JobHandle))
		{
			Matrix4x4 meshToAxisSpace = DeformerUtils.GetMeshToAxisSpace(base.Axis, data.Target.GetTransform());
			return new SphericalNoiseJob
			{
				magnitude = base.MagnitudeScalar,
				frequency = GetActualFrequency(),
				offset = GetActualOffset(),
				meshToAxis = meshToAxisSpace,
				axisToMesh = meshToAxisSpace.inverse,
				vertices = data.DynamicNative.VertexBuffer
			}.Schedule(data.Length, 64, dependency);
		}

		protected override JobHandle CreateColorNoiseJob(MeshData data, JobHandle dependency = default(JobHandle))
		{
			Matrix4x4 meshToAxisSpace = DeformerUtils.GetMeshToAxisSpace(base.Axis, data.Target.GetTransform());
			return new ColorNoiseJob
			{
				magnitude = base.MagnitudeScalar,
				frequency = GetActualFrequency(),
				offset = GetActualOffset(),
				meshToAxis = meshToAxisSpace,
				axisToMesh = meshToAxisSpace.inverse,
				vertices = data.DynamicNative.VertexBuffer,
				colors = data.DynamicNative.ColorBuffer
			}.Schedule(data.Length, 64, dependency);
		}
	}
}
