using UnityEngine;

public class SpawnerDoor : MonoBehaviour
{
	[SerializeField]
	private E2_4Spawner spawner;

	public void Spawn()
	{
		spawner.Spawn();
	}
}
