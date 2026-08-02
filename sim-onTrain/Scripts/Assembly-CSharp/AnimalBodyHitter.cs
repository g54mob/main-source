using System.Collections;
using HQFPSTemplate;
using UnityEngine;

public class AnimalBodyHitter : MonoBehaviour, IDamageable
{
	public BodyHitPart hitPart;

	public float damageMultiplier = 1f;

	public bool isHit;

	private AnimalBase animalBase;

	private Coroutine resetHitCoroutine;

	[SerializeField]
	private Hitbox.DamageEvent m_OnDamageEvent;

	[SerializeField]
	private Hitbox.DamageEventSimple m_OnSimpleDamageEvent;

	private void Start()
	{
		animalBase = GetComponentInParent<AnimalBase>();
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
		if (animalBase != null && (animalBase.isDead || animalBase.CurrentHealth <= 0))
		{
			return;
		}
		if (NetworkPoolManager.Instance != null)
		{
			NetworkPoolManager.Instance.RequestBloodEffects(hitPoint, vector);
		}
		if (!isHit)
		{
			isHit = true;
			if (resetHitCoroutine != null)
			{
				StopCoroutine(resetHitCoroutine);
			}
			resetHitCoroutine = StartCoroutine(ResetHitAfterDelay());
		}
		if (animalBase != null)
		{
			int damage = Mathf.Abs(Mathf.RoundToInt(damageData.Delta * damageMultiplier));
			animalBase.TakeDamage(damage, damageData.HitPoint);
		}
		else
		{
			Debug.LogError(base.name + ": AnimalBase bulunamadı!");
		}
	}

	private IEnumerator ResetHitAfterDelay()
	{
		yield return new WaitForSeconds(1f);
		isHit = false;
	}
}
