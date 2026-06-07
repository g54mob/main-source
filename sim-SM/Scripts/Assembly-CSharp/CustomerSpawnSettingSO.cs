using UnityEngine;

[CreateAssetMenu(fileName = "Customer Spawn Setting", menuName = "Customer/Spawn Setting")]
public class CustomerSpawnSettingSO : ScriptableObject
{
	public Vector2 SpawnTimeRange;

	public Vector2Int PlayerLevelRange;
}
