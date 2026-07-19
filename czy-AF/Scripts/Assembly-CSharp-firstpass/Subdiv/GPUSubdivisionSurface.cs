using UnityEngine;

namespace Subdiv
{
	public class GPUSubdivisionSurface
	{
		protected const string kKernelKey = "Subdivide";

		protected const string kVertexBufferKey = "_VertexBuffer";

		protected const string kEdgeBufferKey = "_EdgeBuffer";

		protected const string kTriangleBufferKey = "_TriangleBuffer";

		protected const string kVertexCountKey = "_VertexCount";

		protected const string kEdgeCountKey = "_EdgeCount";

		protected const string kTriangleCountKey = "_TriangleCount";

		protected const string kSubdivBufferKey = "_SubdivBuffer";

		protected const string kSubdivCountKey = "_SubdivCount";

		public static Mesh Subdivide(ComputeShader subdivCompute, Mesh mesh, int details = 1, bool weld = false)
		{
			Kernel kernel = new Kernel(subdivCompute, "Subdivide");
			GPUSubdivData gPUSubdivData = new GPUSubdivData(mesh);
			for (int i = 0; i < details; i++)
			{
				subdivCompute.SetBuffer(kernel.Index, "_VertexBuffer", gPUSubdivData.VertexBuffer);
				subdivCompute.SetBuffer(kernel.Index, "_EdgeBuffer", gPUSubdivData.EdgeBuffer);
				subdivCompute.SetBuffer(kernel.Index, "_TriangleBuffer", gPUSubdivData.TriangleBuffer);
				subdivCompute.SetBuffer(kernel.Index, "_SubdivBuffer", gPUSubdivData.SubdivBuffer);
				subdivCompute.SetInt("_VertexCount", gPUSubdivData.VertexBuffer.count);
				subdivCompute.SetInt("_EdgeCount", gPUSubdivData.EdgeBuffer.count);
				subdivCompute.SetInt("_TriangleCount", gPUSubdivData.TriangleBuffer.count);
				subdivCompute.SetInt("_SubdivCount", gPUSubdivData.SubdivBuffer.count);
				subdivCompute.Dispatch(kernel.Index, gPUSubdivData.SubdivBuffer.count / (int)kernel.ThreadX + 1, (int)kernel.ThreadY, (int)kernel.ThreadZ);
				if (i != details - 1)
				{
					gPUSubdivData = gPUSubdivData.Next();
				}
			}
			mesh = gPUSubdivData.Build(weld);
			gPUSubdivData.Dispose();
			return mesh;
		}
	}
}
