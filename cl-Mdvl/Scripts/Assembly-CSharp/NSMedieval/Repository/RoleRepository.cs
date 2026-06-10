using NSEipix.Repository;
using NSMedieval.Roles;

namespace NSMedieval.Repository
{
	public class RoleRepository : DynamicJsonRepository<RoleRepository, Role>
	{
		protected override string JsonFile()
		{
			return "Roles/Role.json";
		}
	}
}
