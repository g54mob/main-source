using Unity.Collections;

public struct InstancedSpawnGroup
{
	public FixedList64Bytes<ObjectID> spawnObjects;

	public FixedList64Bytes<int> spawnObjectAmounts;
}
