using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpawnCompanionsAuthoring : MonoBehaviour
{
	public bool follow;

	[Tooltip("Spawn offset has no effect if 'follow' is enabled.")]
	public float3 spawnOffset;

	public List<GameObject> companions;
}
