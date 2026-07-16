using System.Collections;
using UnityEngine;

public class EMPAOE : MonoBehaviour
{
	public Unit sourceUnit;

	public float empDuration;

	public float damage;

	public float sunder;

	public float burn;

	public bool isDrone;

	public bool destroyBombers;

	[SerializeField]
	private LayerMask layerMask;

	[SerializeField]
	private ParticleSystem ps;

	private void Start()
	{
		ps.Play();
		Collider2D[] array = Physics2D.OverlapCircleAll(base.transform.position, 10f, layerMask);
		foreach (Collider2D collider2D in array)
		{
			if (collider2D.gameObject.layer == LayerMask.NameToLayer("Enemy Projectile"))
			{
				Object.Destroy(collider2D.gameObject);
			}
			collider2D.GetComponent<IEMPable>()?.EMP(empDuration);
			Unit component = collider2D.GetComponent<Unit>();
			if (component == null || component.IsEnemy == isDrone)
			{
				continue;
			}
			if (sourceUnit is ModuleEMP moduleEMP)
			{
				moduleEMP.UpdateMainStat(1f);
			}
			if (destroyBombers && component is E1_3Bomber)
			{
				HealthChangeInfo info = new HealthChangeInfo(sourceUnit, component.HealthComponent, -100f, isPercent: false, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.AoE);
				component.HealthComponent.ChangeHealthWithInfo(info);
				continue;
			}
			if (damage > 0f)
			{
				HealthChangeInfo info2 = new HealthChangeInfo(sourceUnit, component.HealthComponent, 0f - damage, isPercent: false, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.AoE);
				component.HealthComponent.ChangeHealthWithInfo(info2);
			}
			if (sunder > 0f)
			{
				component.HealthComponent.ApplySunder();
			}
			if (burn > 0f)
			{
				component.HealthComponent.ApplyBurn(burn, sourceUnit);
			}
		}
		StartCoroutine(Destroy());
	}

	private IEnumerator Destroy()
	{
		yield return new WaitForSeconds(2f);
		Object.Destroy(base.gameObject);
	}
}
