namespace NGS.MeshFusionPro
{
	public interface ICombinedMeshFactory
	{
		CombinedMesh CreateCombinedMesh();

		CombinedMesh CreateMovableCombinedMesh(out ICombinedMeshMover mover);
	}
}
