using UnityEngine;

public class SleepStateAuthoring : MonoBehaviour
{
	[Header("Sleep params")]
	public float minSleepCooldown = 4f;

	public float maxSleepCooldown = 5f;

	public float minPreFallAsleepDuration = 1f;

	public float maxPreFallAsleepDuration = 2f;

	public float minSleepDuration = 4f;

	public float maxSleepDuration = 5f;

	[Header("Wake up params")]
	public float wakeUpDuration = 1f;

	public float radiusFromVisiblePlayerToAwake = 4f;

	public float minRadiusFromOwnerToWakeUp;

	public bool stayAwakeUntilNoVisiblePlayer;

	public bool triggerAwakeOnClientWhenDamagingEntity;
}
