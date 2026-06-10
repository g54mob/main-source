namespace NGS.MeshFusionPro
{
	public interface IMovableCombinedMeshFactory
	{
		CombinedMesh CreateMovableMesh(out ICombinedMeshMover mover);
	}
}
