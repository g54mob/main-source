using NSEipix.Repository;

namespace NSMedieval.BuildingComponents
{
	public class VoxelBuildingComponentRepository : DynamicJsonRepository<VoxelBuildingComponentRepository, VoxelBuildingComponentBlueprint>
	{
		protected override string JsonFile()
		{
			return "Constructables/VoxelBuildingComponentRepository.json";
		}
	}
}
