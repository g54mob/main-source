using System;
using System.Linq;
using UnityEngine;

public class Claw : MonoBehaviour
{
	[SerializeField]
	private Transform resourceTargetTf;

	[SerializeField]
	private ClawAssembly assembly;

	private Animator anim;

	private ResourceBox currentResource;

	private LayerMask resourceLayer;

	private float shockTimer;

	private bool isShockActive;

	public bool isDeflecting;

	public float deflectChance;

	private AudioSource audioSource;

	public event Action OnPickup;

	public event Action<ResourceBoxData> OnResourcePickedUp;

	private void Awake()
	{
		anim = GetComponent<Animator>();
		resourceLayer = LayerMask.NameToLayer("Resource");
		audioSource = GetComponent<AudioSource>();
	}

	private void Update()
	{
		if (!assembly.module.IsFullyBroken && !assembly.module.IsEMPattached)
		{
			CheckShock();
			Shock();
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!assembly.module.HealthComponent.IsDead && resourceTargetTf.childCount <= 0 && !assembly.module.IsFullyBroken && !assembly.module.IsEMPattached)
		{
			ResourceBox component = collision.GetComponent<ResourceBox>();
			if ((bool)component && (!component.transform.parent || component.transform.parent.gameObject.layer != (int)resourceLayer))
			{
				anim.Play("Close");
				currentResource = component;
				component.transform.parent = resourceTargetTf;
				component.transform.localPosition = Vector3.zero;
			}
		}
	}

	private void OnAnimClosed()
	{
		anim.Play("Open");
		if ((bool)currentResource)
		{
			ResourceBoxData obj = currentResource.OnGrab(LootManager.Instance.CacheMult);
			this.OnPickup?.Invoke();
			this.OnResourcePickedUp?.Invoke(obj);
		}
		audioSource.Play();
		if (assembly.module.collectExplosionDamage == 0f)
		{
			return;
		}
		EnemyBase[] array = EnemyManager.Instance.Enemies.ToArray();
		foreach (EnemyBase enemyBase in array)
		{
			if (enemyBase != null && enemyBase.HealthComponent.HealthMax != 0f)
			{
				HealthChangeInfo info = new HealthChangeInfo(assembly.module, enemyBase.HealthComponent, 0f - assembly.module.collectExplosionDamage, isPercent: false, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.AoE);
				enemyBase.HealthComponent.ChangeHealthWithInfo(info);
			}
		}
		assembly.module.resourceImplosionPS.transform.position = resourceTargetTf.position;
		assembly.module.resourceImplosionPS.Play();
	}

	private void CheckShock()
	{
		if (!assembly.module.isShocking)
		{
			return;
		}
		bool flag = false;
		if (!assembly.module.IsFullyBroken && EnemyManager.Instance.Enemies.Count > 0)
		{
			flag = true;
		}
		if (flag != isShockActive)
		{
			isShockActive = flag;
			if (isShockActive)
			{
				assembly.shockPS.Play();
				return;
			}
			assembly.shockPS.Stop();
			assembly.shockPS.Clear();
		}
	}

	private void Shock()
	{
		if (!isShockActive)
		{
			return;
		}
		shockTimer += Time.deltaTime;
		if (shockTimer < assembly.module.TimeBetweenShocks)
		{
			return;
		}
		shockTimer = 0f;
		RaycastHit2D[] array = Physics2D.CircleCastAll(base.transform.position + Vector3.right * 0.05f, assembly.module.ShockRadius, Vector2.zero, assembly.module.ShockRadius, LayerMask.GetMask("Unit", "Enemy"));
		foreach (RaycastHit2D raycastHit2D in array)
		{
			Unit component = raycastHit2D.collider.gameObject.GetComponent<Unit>();
			if (component != null && component.IsEnemy && !component.IsHacked)
			{
				HealthChangeInfo info = new HealthChangeInfo(assembly.module, component.HealthComponent, -1f, isPercent: false, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.AoE);
				component.HealthComponent.ChangeHealthWithInfo(info);
			}
		}
	}
}
