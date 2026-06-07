using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Deform
{
	[Deformer(Name = "UV Scale", Description = "Scales the mesh's UVs", Type = typeof(UVScaleDeformer), Category = Category.Normal)]
	[HelpURL("https://github.com/keenanwoodall/Deform/wiki/UVScaleDeformer")]
	public class UVScaleDeformer : Deformer, IFactor
	{
		[BurstCompile(CompileSynchronously = true)]
		public struct UVScaleJob : IJobParallelFor
		{
			public float2 scale;

			public NativeArray<float2> uvs;

			public void Execute(int index)
			{
				uvs[index] *= scale;
			}
		}

		[SerializeField]
		[HideInInspector]
		private float factor = 1f;

		[SerializeField]
		[HideInInspector]
		private Vector2 scale = Vector2.one;

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

		public Vector2 Scale
		{
			get
			{
				return scale;
			}
			set
			{
				scale = value;
			}
		}

		public override DataFlags DataFlags => DataFlags.UVs;

		public override JobHandle Process(MeshData data, JobHandle dependency = default(JobHandle))
		{
			return new UVScaleJob
			{
				scale = Scale * Factor,
				uvs = data.DynamicNative.UVBuffer
			}.Schedule(data.Length, 64, dependency);
		}
	}
}
