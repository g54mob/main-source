using System;
using System.Collections;
using HQFPSTemplate;
using Mirror;
using UnityEngine;
using UnityEngine.Events;

public class ZombieDamageController : MonoBehaviour, IDamageable
{
	[Serializable]
	public class DamageEvent : UnityEvent<DamageInfo>
	{
	}

	[Serializable]
	public class DamageEventSimple : UnityEvent<float>
	{
	}

	[Serializable]
	public class HealthEvent : UnityEvent<float, float>
	{
	}

	[Serializable]
	public class DeathEvent : UnityEvent
	{
	}

	[Tooltip("Açıkken zombiler hiç hasar almaz (efektler oynar ama HP düşmez).")]
	public bool disableDamage;

	public float headshotMultiplier = 2f;

	[Range(0f, 1f)]
	public float hitSlowdownMultiplier = 0.5f;

	public float hitSlowdownDuration = 1.5f;

	[SerializeField]
	private DamageEvent m_OnDamageEvent;

	[SerializeField]
	private DamageEventSimple m_OnSimpleDamageEvent;

	[SerializeField]
	private HealthEvent m_OnHealthChanged;

	[SerializeField]
	private DeathEvent m_OnDeathEvent;

	private ZombieAnimationController animationController;

	private ZombieController zombieController;

	private ZombieHitReactor hitReactor;

	private ZombieBodyHitter[] bodyHitters;

	private Coroutine slowdownCoroutine;

	private void Start()
	{
		animationController = GetComponentInChildren<ZombieAnimationController>();
		zombieController = GetComponent<ZombieController>();
		hitReactor = GetComponentInChildren<ZombieHitReactor>();
		bodyHitters = GetComponentsInChildren<ZombieBodyHitter>(includeInactive: true);
		if (zombieController != null)
		{
			ZombieController obj = zombieController;
			obj.OnHealthChanged = (Action<float, float>)Delegate.Combine(obj.OnHealthChanged, new Action<float, float>(OnZombieHealthChanged));
			ZombieController obj2 = zombieController;
			obj2.OnDeath = (Action)Delegate.Combine(obj2.OnDeath, new Action(OnZombieDeath));
		}
	}

	private void OnDestroy()
	{
		if (zombieController != null)
		{
			ZombieController obj = zombieController;
			obj.OnHealthChanged = (Action<float, float>)Delegate.Remove(obj.OnHealthChanged, new Action<float, float>(OnZombieHealthChanged));
			ZombieController obj2 = zombieController;
			obj2.OnDeath = (Action)Delegate.Remove(obj2.OnDeath, new Action(OnZombieDeath));
		}
	}

	public void TakeDamage(DamageInfo damageData)
	{
		if (zombieController != null && zombieController.isDeath)
		{
			return;
		}
		if (damageData.HitPoint != Vector3.zero)
		{
			ZombieBodyHitter zombieBodyHitter = FindNearestBodyHitter(damageData.HitPoint);
			if (zombieBodyHitter != null)
			{
				zombieBodyHitter.TakeDamage(damageData);
				return;
			}
		}
		float num = Mathf.Abs(damageData.Delta);
		Vector3 vector = damageData.HitDirection;
		if (vector == Vector3.zero && damageData.Source != null)
		{
			vector = (base.transform.position - damageData.Source.transform.position).normalized;
		}
		if (vector == Vector3.zero)
		{
			vector = Vector3.forward;
		}
		if (zombieController != null)
		{
			zombieController.lastHitDirection = vector;
			Quaternion quaternion = Quaternion.LookRotation(vector);
			Vector3 playerPos = damageData.HitPoint - vector;
			zombieController.GetDamage(disableDamage ? 0f : num, playerPos, vector, damageData.HitPoint, quaternion, (int)damageData.DamageType);
		}
		if (zombieController != null && !zombieController.isJumping)
		{
			if (NetworkPoolManager.Instance != null)
			{
				uint zombieNetId = 0u;
				NetworkIdentity component = zombieController.GetComponent<NetworkIdentity>();
				if (component != null)
				{
					zombieNetId = component.netId;
				}
				NetworkPoolManager.Instance.RequestBloodEffects(damageData.HitPoint, vector, zombieNetId);
			}
			if (hitReactor != null)
			{
				hitReactor.ApplyHitImpulse(BodyHitPart.Spine, vector, damageData.HitPoint);
			}
			PlayRunningHitReaction(BodyHitPart.Spine, vector);
		}
		m_OnDamageEvent?.Invoke(damageData);
		m_OnSimpleDamageEvent?.Invoke(damageData.Delta);
	}

	private ZombieBodyHitter FindNearestBodyHitter(Vector3 worldPoint)
	{
		if (bodyHitters == null || bodyHitters.Length == 0)
		{
			return null;
		}
		ZombieBodyHitter result = null;
		float num = float.MaxValue;
		ZombieBodyHitter[] array = bodyHitters;
		foreach (ZombieBodyHitter zombieBodyHitter in array)
		{
			if (!(zombieBodyHitter == null))
			{
				float sqrMagnitude = (zombieBodyHitter.transform.position - worldPoint).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					num = sqrMagnitude;
					result = zombieBodyHitter;
				}
			}
		}
		return result;
	}

	public void ProcessHit(DamageInfo damageData, ZombieBodyHitter sourceHitter)
	{
		if (zombieController != null && zombieController.isDeath)
		{
			return;
		}
		ApplyDamage(damageData, sourceHitter);
		if (!(zombieController == null) && !zombieController.isDeath && !zombieController.isJumping)
		{
			if (damageData.HitDirection != Vector3.zero)
			{
				zombieController.lastHitDirection = damageData.HitDirection;
			}
			ApplyHitSlowdown();
			PlayRunningHitReaction(sourceHitter.hitPart, zombieController.lastHitDirection);
			m_OnDamageEvent?.Invoke(damageData);
			m_OnSimpleDamageEvent?.Invoke(damageData.Delta);
		}
	}

	private void ApplyDamage(DamageInfo damageData, ZombieBodyHitter sourceHitter)
	{
		float num = Mathf.Abs(damageData.Delta);
		num *= sourceHitter.damageMultiplier;
		if (sourceHitter.hitPart == BodyHitPart.Head)
		{
			num *= headshotMultiplier;
		}
		num = Mathf.Max(0f, num);
		if (disableDamage)
		{
			num = 0f;
		}
		if (zombieController != null)
		{
			Vector3 hitPoint = damageData.HitPoint;
			Vector3 vector = damageData.HitDirection;
			if (vector == Vector3.zero)
			{
				vector = ((!(damageData.Source != null)) ? Vector3.forward : (base.transform.position - damageData.Source.transform.position).normalized);
			}
			Quaternion quaternion = Quaternion.LookRotation(vector);
			Vector3 playerPos = damageData.HitPoint - vector;
			zombieController.GetDamage(num, playerPos, vector, hitPoint, quaternion, (int)damageData.DamageType, (int)sourceHitter.hitPart);
		}
	}

	private void ApplyHitSlowdown()
	{
		if (!(zombieController == null))
		{
			zombieController.ApplySpeedMultiplier(hitSlowdownMultiplier);
			if (slowdownCoroutine != null)
			{
				StopCoroutine(slowdownCoroutine);
			}
			slowdownCoroutine = StartCoroutine(ResetSlowdownAfterDelay());
		}
	}

	private IEnumerator ResetSlowdownAfterDelay()
	{
		yield return new WaitForSeconds(hitSlowdownDuration);
		if (zombieController != null)
		{
			zombieController.ApplySpeedMultiplier(1f, instantRestore: true);
		}
		slowdownCoroutine = null;
	}

	private void OnZombieHealthChanged(float currentHealth, float maxHealth)
	{
		m_OnHealthChanged?.Invoke(currentHealth, maxHealth);
	}

	private void OnZombieDeath()
	{
		m_OnDeathEvent?.Invoke();
		StopAllCoroutines();
	}

	private void PlayRunningHitReaction(BodyHitPart hitPart, Vector3 hitDirection)
	{
		if ((!(zombieController != null) || (!zombieController.isDeath && !zombieController.isJumping)) && NetworkSoundPlayer.Instance != null)
		{
			NetworkSoundPlayer.Instance.PlaySound(GameAudios.ZombieGettingDamage, zombieController.transform.position);
		}
	}

	public float GetCurrentHealth()
	{
		if (!(zombieController != null))
		{
			return 0f;
		}
		return zombieController.currentHp;
	}

	public float GetMaxHealth()
	{
		if (!(zombieController != null))
		{
			return 0f;
		}
		return zombieController.maxHp;
	}

	public float GetHealthPercentage()
	{
		if (!(zombieController != null))
		{
			return 0f;
		}
		return zombieController.HealthPercentage;
	}

	public bool IsAlive()
	{
		if (!(zombieController != null))
		{
			return false;
		}
		return zombieController.IsAlive;
	}

	public void ForceKill()
	{
		if (zombieController != null)
		{
			zombieController.Kill();
		}
	}
}
