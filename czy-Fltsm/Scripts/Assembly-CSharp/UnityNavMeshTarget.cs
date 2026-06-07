public class UnityNavMeshTarget : Target
{
	public override void AttachNavigator(Navigator navigator)
	{
		navigator.AttachToTarget(this);
		navigator.UpdateTerrain(Navigator.TerrainType.UnityNavMesh);
	}
}
