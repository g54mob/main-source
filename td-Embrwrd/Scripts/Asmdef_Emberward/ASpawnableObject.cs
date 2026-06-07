using UnityEngine;

public abstract class ASpawnableObject : MonoBehaviour
{
	public static T Spawn<T>(Vector3 position, Quaternion rotation, Transform parent = null) where T : ASpawnableObject
	{
		return null;
	}

	public abstract void OnSpawnProcess();
}
