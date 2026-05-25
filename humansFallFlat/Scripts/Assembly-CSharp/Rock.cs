using UnityEngine;

public class Rock : MonoBehaviour
{
	public enum RockType
	{
		A = 0,
		B = 1,
		C = 2
	}

	public RockType type;

	private RockSpawnHandler spawner;

	public void SetSpawner(RockSpawnHandler spawner)
	{
		this.spawner = spawner;
	}

	public void Despawn()
	{
		spawner.ReturnToPool(base.gameObject);
	}
}
