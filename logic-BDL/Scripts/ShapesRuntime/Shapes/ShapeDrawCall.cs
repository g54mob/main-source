using UnityEngine;
using UnityEngine.Rendering;

namespace Shapes
{
	internal struct ShapeDrawCall
	{
		public ShapeDrawState drawState;

		public MaterialPropertyBlock mpb;

		public int count;

		public Matrix4x4 matrix;

		public Matrix4x4[] matrices;

		private bool instanced;

		public ShapeDrawCall(ShapeDrawState drawState, Matrix4x4 matrix)
		{
			count = 1;
			this.drawState = drawState;
			this.matrix = matrix;
			instanced = false;
			mpb = ObjectPool<MaterialPropertyBlock>.Alloc();
			matrices = null;
		}

		public ShapeDrawCall(ShapeDrawState drawState, int count, Matrix4x4[] matrices)
		{
			this.count = count;
			this.drawState = drawState;
			this.matrices = matrices;
			instanced = true;
			mpb = ObjectPool<MaterialPropertyBlock>.Alloc();
			matrix = default(Matrix4x4);
		}

		public void AddToCommandBuffer(CommandBuffer cmd)
		{
			if (instanced)
			{
				cmd.DrawMeshInstanced(drawState.mesh, drawState.submesh, drawState.mat, 0, matrices, count, mpb);
			}
			else
			{
				cmd.DrawMesh(drawState.mesh, matrix, drawState.mat, drawState.submesh, 0, mpb);
			}
		}

		public void Cleanup()
		{
			mpb.Clear();
			ObjectPool<MaterialPropertyBlock>.Free(mpb);
			if (instanced)
			{
				ArrayPool<Matrix4x4>.Free(matrices);
			}
			drawState.mat = null;
			drawState.mesh = null;
		}
	}
}
