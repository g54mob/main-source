using NSMedieval.Village.Map;

namespace NSMedieval.State
{
	public interface IGridPositionProvider
	{
		VillageMap Map { get; }

		Vec3Int GetGridPosition();
	}
}
