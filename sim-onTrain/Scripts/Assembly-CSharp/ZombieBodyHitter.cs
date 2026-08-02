using HQFPSTemplate;
using Mirror;
using UnityEngine;

public class ZombieBodyHitter : MonoBehaviour, IDamageable
{
	public BodyHitPart hitPart;

	public float damageMultiplier = 1f;

	private ZombieDamageController damageController;

	private ZombieHitReactor hitReactor;

	[SerializeField]
	private Hitbox.DamageEvent m_OnDamageEvent;

	[SerializeField]
	private Hitbox.DamageEventSimple m_OnSimpleDamageEvent;

	private void Start()
	{
		damageController = GetComponentInParent<ZombieDamageController>();
		hitReactor = GetComponentInParent<ZombieHitReactor>();
	}

	public void TakeDamage(DamageInfo damageData)
	{
		m_OnDamageEvent?.Invoke(damageData);
		m_OnSimpleDamageEvent?.Invoke(damageData.Delta);
		Vector3 hitPoint = damageData.HitPoint;
		Vector3 vector = damageData.HitDirection;
		if (vector == Vector3.zero)
		{
			vector = Vector3.forward;
		}
		ZombieController componentInParent = GetComponentInParent<ZombieController>();
		if (componentInParent != null && componentInParent.isDeath)
		{
			return;
		}
		if (NetworkPoolManager.Instance != null)
		{
			ZombieController componentInParent2 = GetComponentInParent<ZombieController>();
			uint zombieNetId = 0u;
			if (componentInParent2 != null)
			{
				NetworkIdentity component = componentInParent2.GetComponent<NetworkIdentity>();
				if (component != null)
				{
					zombieNetId = component.netId;
				}
			}
			NetworkPoolManager.Instance.RequestBloodEffects(hitPoint, vector, zombieNetId, hitPart);
		}
		if (hitReactor != null)
		{
			hitReactor.ApplyHitImpulse(hitPart, vector, hitPoint);
		}
		if (damageController != null)
		{
			damageController.ProcessHit(damageData, this);
		}
		else
		{
			Debug.LogError("[ZOMBIE_HIT] ZombieDamageController not found on " + base.gameObject.name + "!");
		}
	}
}
