using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Deform
{
	[Deformer(Name = "UV Offset", Description = "Offsets the mesh's UVs", Type = typeof(UVOffsetDeformer), Category = Category.Normal)]
	[HelpURL("https://github.com/keenanwoodall/Deform/wiki/UVOffsetDeformer")]
	public class UVOffsetDeformer : Deformer
	{
		[BurstCompile(CompileSynchronously = true)]
		public struct UVOffsetJob : IJobParallelFor
		{
			public float2 offset;

			public NativeArray<float2> uvs;

			public void Execute(int index)
			{
				uvs[index] += offset;
			}
		}

		[SerializeField]
		[HideInInspector]
		private Vector2 offset;

		public Vector2 Offset
		{
			get
			{
				return offset;
			}
			set
			{
				offset = value;
			}
		}

		public override DataFlags DataFlags => DataFlags.UVs;

		public override JobHandle Process(MeshData data, JobHandle dependency = default(JobHandle))
		{
			return new UVOffsetJob
			{
				offset = offset,
				uvs = data.DynamicNative.UVBuffer
			}.Schedule(data.Length, 64, dependency);
		}
	}
}
