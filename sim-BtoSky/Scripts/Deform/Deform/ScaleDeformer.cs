using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Deform
{
	[Deformer(Name = "Scale", Description = "Scales the mesh along an arbitrary axis", Type = typeof(ScaleDeformer), Category = Category.Normal)]
	[HelpURL("https://github.com/keenanwoodall/Deform/wiki/ScaleDeformer")]
	public class ScaleDeformer : Deformer
	{
		[BurstCompile(CompileSynchronously = true)]
		public struct ScaleJob : IJobParallelFor
		{
			public float3 scale;

			public float4x4 meshToAxis;

			public float4x4 axisToMesh;

			public NativeArray<float3> vertices;

			public void Execute(int index)
			{
				float4 b = math.mul(meshToAxis, math.float4(vertices[index], 1f));
				b *= math.float4(scale, 1f);
				vertices[index] = math.mul(axisToMesh, b).xyz;
			}
		}

		[SerializeField]
		[HideInInspector]
		private Transform axis;

		public Transform Axis
		{
			get
			{
				if (axis == null)
				{
					axis = base.transform;
				}
				return axis;
			}
			set
			{
				axis = value;
			}
		}

		public override DataFlags DataFlags => DataFlags.Vertices;

		[BurstCompile(CompileSynchronously = true)]
		public override JobHandle Process(MeshData data, JobHandle dependency = default(JobHandle))
		{
			Matrix4x4 meshToAxisSpace = DeformerUtils.GetMeshToAxisSpace(Axis, data.Target.GetTransform());
			return new ScaleJob
			{
				scale = Axis.localScale,
				meshToAxis = meshToAxisSpace,
				axisToMesh = meshToAxisSpace.inverse,
				vertices = data.DynamicNative.VertexBuffer
			}.Schedule(data.Length, 64, dependency);
		}
	}
}
