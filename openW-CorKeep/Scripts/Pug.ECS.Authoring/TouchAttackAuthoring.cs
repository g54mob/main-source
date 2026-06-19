using UnityEngine;

public class TouchAttackAuthoring : MonoBehaviour
{
	public bool ignoreDamageReduction;

	public float pushback;

	public float hitRadius = 0.5f;

	public float cooldownAfterHit = 1f;

	public string triggerAnimationOnHit = "attack";
}
