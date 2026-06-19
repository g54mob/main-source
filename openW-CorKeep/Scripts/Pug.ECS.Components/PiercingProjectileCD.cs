using Unity.Entities;
using Unity.NetCode;

public struct PiercingProjectileCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public int currentPiercedEnemiesCount;

	[GhostField]
	public int piercesEnemiesAmount;
}
