using UnityEngine;
using UnityEngine.Rendering;

namespace Shapes
{
	internal class ShapeDrawCallSingle : ShapeDrawCall
	{
		public Matrix4x4 matrix;

		public ShapeDrawCallSingle(Matrix4x4 matrix)
		{
			this.matrix = matrix;
		}

		public override void AddToCommandBuffer(CommandBuffer cmd)
		{
			cmd.DrawMesh(drawState.mesh, matrix, drawState.mat, drawState.submesh, 0, mpb);
		}
	}
}
