using NSMedieval.BuildingComponents;

namespace NSMedieval.Testing.Autoplay
{
	public struct BuildingItem
	{
		public BaseBuildingBlueprint Blueprint;

		public Vec3Int Position;

		public int Angle;

		public BuildingItem(BaseBuildingBlueprint blueprint, Vec3Int position, int angle = 0)
		{
			Blueprint = blueprint;
			Position = position;
			Angle = angle;
		}
	}
}
