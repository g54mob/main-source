using Unity.Entities;

public struct ConnectionAdminLevelCD : IComponentData, IQueryTypeParameter
{
	public int adminPrivileges;

	public ulong onlineId;
}
