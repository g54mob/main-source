using UnityEngine;

public abstract class SpawnPositionProviderBase : ScriptableObject, ISpawnPositionProvider
{
	public abstract void Initialize(GameplaySettings settings, Vector3 current);

	public abstract Vector3 ReturnInitialSpawnPosition(bool outsideBuildradius);

	public abstract Vector3 ReturnSpawnPosition();
}
