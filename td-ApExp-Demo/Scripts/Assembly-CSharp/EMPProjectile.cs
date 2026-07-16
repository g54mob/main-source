using UnityEngine;

public class EMPProjectile : Unit
{
	[Header("Stats")]
	[SerializeField]
	private float speed;

	[Header("EMP")]
	[SerializeField]
	private GameObject attachEffect;

	[SerializeField]
	private GameObject empAOEPrefab;

	[SerializeField]
	protected GameObject explosionPrefab;

	[SerializeField]
	protected float explosionScale = 0.25f;

	[SerializeField]
	private SimpleFlash flashEffect;

	[SerializeField]
	public float duration;

	[Header("Sound")]
	[SerializeField]
	private UnitAudioController audioController;

	[SerializeField]
	private Animator anim;

	[HideInInspector]
	public Unit SourceUnit;

	[HideInInspector]
	public bool isAttached;

	private Transform targetTf;

	private Explosion deathExplosion;

	private Rigidbody2D rb;

	[SerializeField]
	private Transform raycastPoint;

	private new void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		base.IsEnemy = true;
		if ((bool)base.HealthComponent)
		{
			base.HealthComponent.OnDeath += OnDeath;
			base.HealthComponent.OnHealthChanged += OnHealthChanged;
		}
		LevelManager.Instance.DestinationReached += DestroySelf;
		GameManager.Instance.ringMinigame.OnStartMinigame += DestroySelf;
	}

	private void FixedUpdate()
	{
		if (base.TargetUnit == null || targetTf == null)
		{
			return;
		}
		if (isAttached)
		{
			base.transform.position = targetTf.position;
			return;
		}
		RaycastCollide();
		Vector2 vector = (targetTf.position - base.transform.position).normalized;
		rb.velocity = vector * speed;
		base.transform.up = base.TargetUnit.transform.position - base.transform.position;
		if (Vector2.Distance(base.transform.position, targetTf.position) < 0.1f)
		{
			AttachToTarget();
		}
	}

	public void SetTarget(Unit target)
	{
		base.TargetUnit = target;
		if (base.TargetUnit is Module module)
		{
			targetTf = module.ModuleSlot.GetAnchorPoint(base.transform.position.y > 0f);
		}
		else
		{
			targetTf = base.TargetUnit.transform;
		}
	}

	private void Activate()
	{
		anim.Play("Stage 0", 0);
		anim.Play("Activate", 1);
	}

	private void AttachToTarget()
	{
		isAttached = true;
		rb.velocity = Vector2.zero;
		base.transform.position = targetTf.position;
		GameObject obj = null;
		if ((bool)attachEffect)
		{
			obj = Object.Instantiate(attachEffect, base.transform.position, Quaternion.identity);
		}
		if (base.TargetUnit is Module module)
		{
			module.EMPBreak(this);
		}
		else if (base.TargetUnit is EnemyBase enemyBase)
		{
			enemyBase.EMP(duration);
		}
		Object.Destroy(obj, 2f);
		Invoke("DestroySelf", duration);
	}

	protected virtual void OnHealthChanged(HealthChangeInfo info)
	{
		if (!(info.HealthChange >= 0f) && (bool)flashEffect)
		{
			if (info.IsImmune)
			{
				flashEffect.Flash(FlashTypes.Invulnerability);
			}
			else if (info.IsCrit)
			{
				flashEffect.Flash(FlashTypes.Crit);
			}
			else if (info.IsDamageReduced)
			{
				flashEffect.Flash(FlashTypes.ReducedDamage);
			}
			else
			{
				flashEffect.Flash();
			}
		}
	}

	protected virtual void OnDeath(HealthChangeInfo info)
	{
		DestroySelf();
	}

	private void DestroySelf()
	{
		LevelManager.Instance.DestinationReached -= DestroySelf;
		GameManager.Instance.ringMinigame.OnStartMinigame -= DestroySelf;
		GameObject gameObject = Object.Instantiate(explosionPrefab, base.transform.position, Quaternion.identity);
		deathExplosion = gameObject.GetComponent<Explosion>();
		deathExplosion.Initialize(this, explosionScale, 0f);
		if (base.TargetUnit is Module module)
		{
			module.EMPFix(this);
		}
		Object.Destroy(base.gameObject);
	}

	private void RaycastCollide()
	{
		RaycastHit2D[] array = Physics2D.RaycastAll(raycastPoint.position, base.transform.up, 0.02f, LayerMask.GetMask("Unit", "Enemy"));
		foreach (RaycastHit2D raycastHit2D in array)
		{
			if (raycastHit2D.collider.TryGetComponent<Unit>(out var component) && component.isShieldPlate)
			{
				DestroySelf();
			}
		}
	}
}
