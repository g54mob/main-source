using Unity.Entities;
using UnityEngine;

public class PacketSpawnerAuthoring : MonoBehaviour
{
	private class Baker : Baker<PacketSpawnerAuthoring>
	{
		public override void Bake(PacketSpawnerAuthoring authoring)
		{
		}
	}

	public GameObject packetPrefab;

	public float spawnRate;
}
