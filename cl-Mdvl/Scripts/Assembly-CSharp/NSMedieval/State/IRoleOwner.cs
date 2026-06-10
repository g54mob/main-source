using NSMedieval.Roles;

namespace NSMedieval.State
{
	public interface IRoleOwner
	{
		RoleInstance RoleInstance { get; }

		bool AssignedRole { get; }
	}
}
