using UnityEngine;

public class DestroyWhenNoNearbyPlayerAuthoring : MonoBehaviour
{
	[Tooltip("Defaults to a sane number if <= 0")]
	public float distance;

	public float destroyDelay = 5f;
}
