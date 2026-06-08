using UnityEngine;
using UnityEngine.Rendering;

namespace Shapes
{
	internal class ShapeDrawCallInstanced : ShapeDrawCall
	{
		public Matrix4x4[] matrices;

		public ShapeDrawCallInstanced(Matrix4x4[] matrices)
		{
			this.matrices = matrices;
		}

		public override void AddToCommandBuffer(CommandBuffer cmd)
		{
			cmd.DrawMeshInstanced(drawState.mesh, drawState.submesh, drawState.mat, 0, matrices, count, mpb);
		}
	}
}
