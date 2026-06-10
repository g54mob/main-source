using NSEipix.Repository;
using NSMedieval.Model;

namespace NSMedieval.Repository
{
	public class WalkableModelRepository : DynamicJsonRepository<WalkableModelRepository, WalkableModel>
	{
		public WalkableModel GetTestAgentWalkableDoors()
		{
			return GetByID("test_can_go_through_doors");
		}

		public WalkableModel GetTestAgentWalkableDoorsNoWater()
		{
			return GetByID("test_can_go_through_doors_no_water");
		}

		public WalkableModel GetTestAgentUnwalkableDoors()
		{
			return GetByID("test_cant_go_through_doors");
		}

		protected override string JsonFile()
		{
			return "Creature/WalkableModelRepository.json";
		}
	}
}
