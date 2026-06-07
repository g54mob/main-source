using UnityEngine;

public class SpiritSword : Projectile
{
	private GameObject victim;

	private bool slaughterMode;

	private float slaughterCooldown;

	private Vector3 offsetVector;

	public int healthSlaughter;

	public int armorSlaughter;

	public int shieldSlaughter;

	[SerializeField]
	private Transform artTransform;

	protected override void FixedUpdate()
	{
		if (slaughterMode)
		{
			SlaughterUpdate();
			return;
		}
		maximumLifeTime -= Time.fixedDeltaTime;
		if (maximumLifeTime < 0f)
		{
			Object.Destroy(base.gameObject);
		}
		CheckForHits();
		MoveProjectile();
		if (homing)
		{
			AlterCourse();
		}
	}

	private void SlaughterUpdate()
	{
		if (victim == null)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		base.transform.position = victim.transform.position + Vector3.up * 0.5f;
		Vector3 b = base.transform.position + offsetVector * slaughterCooldown;
		artTransform.position = Vector3.Lerp(artTransform.position, b, 0.25f);
		slaughterCooldown += Time.fixedDeltaTime;
		if (slaughterCooldown > 1f)
		{
			slaughterCooldown = 0f;
			DealDamage(victim);
		}
	}

	protected override void AlterCourse()
	{
		if (target == null)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		Quaternion rotation = Quaternion.LookRotation(0.25f * Vector3.up + target.transform.position - base.transform.position, Vector3.up);
		base.transform.rotation = rotation;
	}

	protected override void OnHit(RaycastHit hit)
	{
		if (hit.transform.GetComponent<IDamageable>() != null)
		{
			victim = hit.transform.gameObject;
			DealDamage(victim);
			offsetVector = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
			offsetVector.Normalize();
			offsetVector += 2f * Vector3.up;
			artTransform.rotation = Quaternion.LookRotation(-offsetVector, Vector3.up);
			slaughterMode = true;
		}
		else
		{
			Object.Destroy(base.gameObject);
		}
	}

	protected virtual void DealDamage(GameObject target)
	{
		int num = 0;
		Enemy component = target.GetComponent<Enemy>();
		if (component.bleeding)
		{
			num += healthSlaughter;
		}
		if (component.burning)
		{
			num += armorSlaughter;
		}
		if (component.poisoned)
		{
			num += shieldSlaughter;
		}
		target.GetComponent<IDamageable>().TakeDamage(shotBy, damage + num, healthDamage, armorDamage, shieldDamage, slowPercent, bleedPercent, burnPercent, poisonPercent, critChance, stunChance);
		damage--;
		if (hitSound != Sound.None)
		{
			SFXManager.instance.PlaySound(hitSound, base.transform.position);
		}
		if (damage <= 0)
		{
			Object.Destroy(base.gameObject);
		}
	}
}
