using Unity.Entities;

public static class StatsUIUtility
{
	public static bool HasExplosiveWeapon(ObjectDataCD objectData, out IsExplosiveCD isExplosiveCD, World world)
	{
		if (objectData.objectID == ObjectID.None)
		{
			isExplosiveCD = default(IsExplosiveCD);
			return false;
		}
		bool result = PugDatabase.TryGetComponent<IsExplosiveCD>(objectData, out isExplosiveCD);
		if (!PugDatabase.TryGetComponent<RangeWeaponCD>(objectData, out var component))
		{
			return result;
		}
		if (!PugDatabase.HasComponent<IsExplosiveCD>(component.projectileID))
		{
			return result;
		}
		result = true;
		if (PugDatabase.HasComponent<LevelEntitiesBuffer>(component.projectileID) && PugDatabase.HasComponent<LevelEntitiesBuffer>(objectData.objectID))
		{
			int variation = ((objectData.variation > 0) ? objectData.variation : PugDatabase.GetComponent<LevelCD>(objectData).level);
			Entity levelEntity = EntityUtility.GetLevelEntity(new ObjectDataCD
			{
				objectID = component.projectileID,
				variation = variation
			});
			isExplosiveCD = EntityUtility.GetComponentData<IsExplosiveCD>(levelEntity, world);
		}
		else
		{
			isExplosiveCD = PugDatabase.GetComponent<IsExplosiveCD>(component.projectileID);
		}
		return result;
	}
}
