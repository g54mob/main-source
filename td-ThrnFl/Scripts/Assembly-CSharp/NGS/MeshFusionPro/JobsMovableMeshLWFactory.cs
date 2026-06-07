namespace NGS.MeshFusionPro
{
	public class JobsMovableMeshLWFactory : IMovableCombinedMeshFactory
	{
		private IMeshToolsFactory _tools;

		public JobsMovableMeshLWFactory(IMeshToolsFactory tools)
		{
			_tools = tools;
		}

		public CombinedMesh CreateMovableMesh(out ICombinedMeshMover mover)
		{
			CombinedMesh<MeshDataNativeArraysLW> combinedMesh = new CombinedMesh<MeshDataNativeArraysLW>(_tools.CreateMeshCombiner(), _tools.CreateMeshCutter());
			mover = new JobsMeshMoverLW(combinedMesh.MeshDataInternal);
			return combinedMesh;
		}
	}
}
