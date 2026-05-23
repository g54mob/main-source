namespace NGS.MeshFusionPro
{
	public interface IMeshToolsFactory
	{
		IMeshCombiner CreateMeshCombiner();

		IMeshCutter CreateMeshCutter();
	}
}
