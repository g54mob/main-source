using Unity.Entities;

public static class PugEcsExtensions
{
	public static int GetAdminLevelOnServer(this ref ComponentLookup<ConnectionAdminLevelCD> fromEntity, Entity connectionEntity)
	{
		fromEntity.TryGetComponent(connectionEntity, out var componentData);
		return componentData.adminPrivileges;
	}
}
