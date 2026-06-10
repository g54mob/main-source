using NSMedieval.Goap;

namespace NSMedieval.BuildingComponents
{
	public interface IDoorOrGate
	{
		Vec3Int GetUsePosition(IPathfindingAgent agent);
	}
}
