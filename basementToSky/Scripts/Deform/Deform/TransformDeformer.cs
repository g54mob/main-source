using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Deform
{
	[Deformer(Name = "Transform", Description = "Gives the mesh a new position, rotation and scale", Type = typeof(TransformDeformer))]
	[HelpURL("https://github.com/keenanwoodall/Deform/wiki/TransformDeformer")]
	public class TransformDeformer : Deformer, IFactor
	{
		[BurstCompile(CompileSynchronously = true)]
		public struct TransformJob : IJobParallelFor
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

		[SerializeField]
		[HideInInspector]
		private float factor = 1f;

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

		public float Factor
		{
			get
			{
				return factor;
			}
			set
			{
				factor = value;
			}
		}

		public override DataFlags DataFlags => DataFlags.Vertices;

		public override JobHandle Process(MeshData data, JobHandle dependency = default(JobHandle))
		{
			Factor = Mathf.Clamp(Factor, 0f, 1f);
			if (Factor == 0f)
			{
				return dependency;
			}
			Transform transform = data.Target.GetTransform();
			Matrix4x4 matrix4x = default(Matrix4x4);
			matrix4x.SetTRS(Vector3.Lerp(transform.position, Target.position, Factor), Quaternion.Lerp(transform.rotation, Target.rotation, Factor), Vector3.Lerp(transform.localScale, Target.localScale, Factor));
			matrix4x = transform.worldToLocalMatrix * matrix4x;
			return new TransformJob
			{
				matrix = matrix4x,
				vertices = data.DynamicNative.VertexBuffer
			}.Schedule(data.Length, 256, dependency);
		}
	}
}
