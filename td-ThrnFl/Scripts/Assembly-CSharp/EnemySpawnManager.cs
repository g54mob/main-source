using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
	public static EnemySpawnManager instance;

	public GameObject screenMarkerPrefabEnemySpawns;

	public GameObject screenMarkerPrefabOffscreenWarning;

	public Weapon weaponOnSpawn;

	public float weaponAttackHeight = 1f;

	private void Awake()
	{
		instance = this;
	}
}
