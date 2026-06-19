using UnityEngine;

[DisallowMultipleComponent]
public class AlertEmoteStateAuthoring : MonoBehaviour
{
	public int animations = 1;

	public float preAlertMinDuration;

	public float preAlertMaxDuration;

	public float duration = 1f;

	public float minCooldown = 4f;

	public float maxCooldown = 6f;
}
