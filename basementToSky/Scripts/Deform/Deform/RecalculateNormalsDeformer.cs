using Unity.Jobs;
using UnityEngine;

namespace Deform
{
	[Deformer(Name = "Recalculate Normals", Description = "Recalculates the normals", Type = typeof(RecalculateNormalsDeformer), Category = Category.Utility)]
	[HelpURL("https://github.com/keenanwoodall/Deform/wiki/RecalculateNormalsDeformer")]
	public class RecalculateNormalsDeformer : Deformer
	{
		public override DataFlags DataFlags => DataFlags.Normals;

		public override JobHandle Process(MeshData data, JobHandle dependency = default(JobHandle))
		{
			return MeshUtils.RecalculateNormals(data.DynamicNative, dependency);
		}
	}
}
