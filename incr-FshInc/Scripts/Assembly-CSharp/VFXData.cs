using UnityEngine;

[CreateAssetMenu(fileName = "NewVFX", menuName = "VFX/VFX Data")]
public class VFXData : ScriptableObject
{
	[Tooltip("The unique identifier for this VFX. Must match the ID on the prefab.")]
	public string id;

	[Tooltip("The prefab of the particle system or VFX graph to spawn.")]
	public GameObject prefab;

	[Tooltip("How many instances of this effect to create when the game starts.")]
	public int initialPoolSize = 10;

	[Tooltip("How long in seconds until the VFX is automatically returned to the pool. Set to 0 for manual disposal.")]
	public float disposeAfterSeconds = 2f;
}
