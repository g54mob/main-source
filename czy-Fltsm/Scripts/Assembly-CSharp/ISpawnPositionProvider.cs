using UnityEngine;

public interface ISpawnPositionProvider
{
	Vector3 ReturnInitialSpawnPosition(bool outsideConstructionRadius = false);

	Vector3 ReturnSpawnPosition();
}
