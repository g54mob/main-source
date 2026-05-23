using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Deform
{
	[Deformer(Name = "Transform Offset", Description = "Offsets the position, rotation and scale of a mesh", Type = typeof(TransformOffsetDeformer))]
	[HelpURL("https://github.com/keenanwoodall/Deform/wiki/TransformOffsetDeformer")]
	public class TransformOffsetDeformer : Deformer
	{
		[BurstCompile(CompileSynchronously = true)]
		public struct TransformOffsetJob : IJobParallelFor
		{
			public float4x4 matrix;

			public NativeArray<float3> vertices;

			public void Execute(int index)
			{
				vertices[index] = math.mul(matrix, math.float4(vertices[index], 1f)).xyz;
			}
		}

		[SerializeField]
		[HideInInspector]
		private Transform target;

		public Transform Target
		{
			get
			{
				if (target == null)
				{
					target = base.transform;
				}
				return target;
			}
			set
			{
				target = value;
			}
		}

		public override DataFlags DataFlags => DataFlags.Vertices;

		public override JobHandle Process(MeshData data, JobHandle dependency = default(JobHandle))
		{
			data.Target.GetTransform();
			Matrix4x4 matrix4x = Matrix4x4.TRS(Target.position, Target.rotation, Target.lossyScale);
			return new TransformOffsetJob
			{
				matrix = matrix4x,
				vertices = data.DynamicNative.VertexBuffer
			}.Schedule(data.Length, 256, dependency);
		}
	}
}
