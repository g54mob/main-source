using NSEipix.Repository;

namespace NSMedieval.Resources
{
	public class ManageGroupRepository : DynamicJsonRepository<ManageGroupRepository, ManageGroup>
	{
		protected override string JsonFile()
		{
			return "Resources/ManageGroup.json";
		}
	}
}
