using UnityEngine;

public class ProjectileMolotov : Projectile
{
	public Unit TargetUnit;

	[HideInInspector]
	public E2_6MolotovBiker biker;

	[SerializeField]
	private GameObject explosionPrefab;

	[SerializeField]
	private float explosionScale;

	[SerializeField]
	private UnitAudioController AudioController;

	public int burnTicks;

	private Animator anim;

	private bool targetSet;

	private new void Awake()
	{
		base.Awake();
	}

	private void Start()
	{
		anim = GetComponent<Animator>();
	}

	private new void Update()
	{
		if (Time.timeScale != 0f)
		{
			if (LevelManager.Instance.sm.CurrentState.Key == "Slowing")
			{
				DestroyProjectile();
			}
			if (TargetUnit == null)
			{
				DestroyProjectile();
			}
			else if (ProximityCheck())
			{
				Hit();
			}
		}
	}

	public new void SetTarget(Unit target)
	{
		if (!targetSet)
		{
			targetSet = true;
			TargetUnit = target;
		}
	}

	private bool ProximityCheck()
	{
		return (TargetUnit.transform.position - base.transform.position).sqrMagnitude <= 0.01f;
	}

	protected override void Move()
	{
		if ((bool)TargetUnit)
		{
			Vector3 normalized = (TargetUnit.transform.position - base.transform.position).normalized;
			base.transform.position += normalized * speed;
		}
	}

	private void Hit()
	{
		TargetUnit.HealthComponent.ApplyBurn(burnTicks, sourceUnit);
		DestroyProjectile();
	}

	public override void DestroyProjectile()
	{
		Object.Instantiate(explosionPrefab, base.transform.position, Quaternion.identity, null).GetComponent<Explosion>().Initialize(sourceUnit, explosionScale, 0f, trainDamage, mute: true);
		soundBuilder.Play(trainHitSound1);
		Object.Destroy(base.gameObject);
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
	}

	protected override void RaycastCollide(float speed)
	{
		RaycastHit2D raycastHit2D = ((!isEnemyProjectile) ? Physics2D.Raycast(base.transform.position, base.transform.up, speed * Time.deltaTime, LayerMask.GetMask("Enemy")) : Physics2D.Raycast(base.transform.position, base.transform.up, speed * Time.deltaTime, LayerMask.GetMask("Unit", "Resource")));
		if (!(raycastHit2D.collider == null) && isEnemyProjectile && raycastHit2D.collider.TryGetComponent<Unit>(out var component) && component.isShieldPlate)
		{
			HealthChangeInfo info = new HealthChangeInfo(this, component.HealthComponent, trainDamage);
			component.HealthComponent.ChangeHealthWithInfo(info);
			trainDamage = 0f;
			DestroyProjectile();
		}
	}
}
