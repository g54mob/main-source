namespace NGS.MeshFusionPro
{
	public class CombinedMeshPartInternal : CombinedMeshPart
	{
		public CombinedMeshPartInternal(CombinedMesh root, int index, int vertexStart, int vertexCount, int trianglesStart, int trianglesCount)
			: base(root, index, vertexStart, vertexCount, trianglesStart, trianglesCount)
		{
		}

		public void Offset(int newIndex, int newVertexStart, int newTrianglesStart)
		{
			base.Index = newIndex;
			base.VertexStart = newVertexStart;
			base.TrianglesStart = newTrianglesStart;
		}
	}
}
