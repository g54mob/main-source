using UnityEngine;

public class ZombieAnimationEventTrigger : MonoBehaviour
{
	private ZombieDamageDealer damageDealer;

	private void Awake()
	{
		damageDealer = GetComponent<ZombieDamageDealer>();
		if (damageDealer == null)
		{
			Debug.LogWarning("[ZombieAnimationEventTrigger] " + base.gameObject.name + ": ZombieDamageDealer component bulunamadı!");
		}
	}

	public void Attack()
	{
		Debug.Log("[ZombieAnimationEventTrigger] " + base.gameObject.name + ": Attack event triggered! DamageDealer: " + ((damageDealer != null) ? "OK" : "NULL"));
		if (damageDealer == null)
		{
			Debug.LogError("[ZombieAnimationEventTrigger] " + base.gameObject.name + ": DamageDealer NULL!");
			return;
		}
		Debug.Log("[ZombieAnimationEventTrigger] " + base.gameObject.name + ": CheckHit çağrılıyor...");
		damageDealer.CheckHit();
		Debug.Log("[ZombieAnimationEventTrigger] " + base.gameObject.name + ": CheckPropHit çağrılıyor...");
		damageDealer.CheckPropHit();
		Debug.Log("[ZombieAnimationEventTrigger] " + base.gameObject.name + ": Attack event tamamlandı!");
	}
}
