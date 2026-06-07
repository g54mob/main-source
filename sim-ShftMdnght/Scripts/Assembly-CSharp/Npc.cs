using UnityEngine;

[CreateAssetMenu(menuName = "SATM/NPC")]
public class Npc : ScriptableObject
{
	[Header("Identity")]
	public string id;

	public GameObject prefab;

	public bool isDoppelganger;

	[Header("Balancing")]
	[Range(0f, 5f)]
	public int entertainment;

	[Range(0f, 5f)]
	public int difficulty;

	public string[] mustBeAliveToSpawn;

	public string[] mustHaveSpawnedBefore;

	[Header("Spawning")]
	public int onlySpawnAfterThisDay = -1;

	public int onlySpawnBeforeThisDay = 100;

	public int alwaysOnlySpawnOnThisDay = -1;

	public int alwaysOnlySpawnOnThisIndex = -1;

	public float extraTimeBeforeSpawn;
}
