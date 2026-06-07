using System.Collections.Generic;
using UnityEngine;

public class PlayerBallMovement : PlayerMovement
{
	[SerializeField]
	private Rigidbody rigidbody;

	[SerializeField]
	private Transform targetPosition;

	public Hp playerHp;

	[BalancingParameter(BalancingParameter.EType.Default)]
	public float selfInflictedDamagePerHit = 1f;

	public LayerMask lmRecieveDamage;

	public List<DamageModifyer> damage;

	private Collider[] tempColliders = new Collider[50];

	public float cooldownPerObject = 4f;

	private PlayerMovement playerMovement;

	private PlayerUpgradeManager upgradeManager;

	private BlacksmithUpgrades blacksmithUpgrades;

	private List<TaggedObject> recentlyHit = new List<TaggedObject>();

	private List<float> recentlyHitWhen = new List<float>();

	private float time;

	[SerializeField]
	private SphereCollider myCollider;

	public float DamageMultiplyer => upgradeManager.PlayerDamageMultiplyer * blacksmithUpgrades.meleeDamage;

	public override void MoveScript(Vector2 inputVector)
	{
		inputVector = Vector2.ClampMagnitude(inputVector, 1f);
		Vector3 normalized = Vector3.ProjectOnPlane(viewTransform.forward, Vector3.up).normalized;
		Vector3 normalized2 = Vector3.ProjectOnPlane(viewTransform.right, Vector3.up).normalized;
		Vector3 vector = default(Vector3);
		vector += normalized * inputVector.x * Time.deltaTime;
		vector += normalized2 * inputVector.y * Time.deltaTime;
		if (base.Dead)
		{
			slowedFor = -1f;
			vector *= moveSpeedWhenDead;
		}
		else
		{
			bool flag = dayNightCycle.CurrentTimestate == DayNightCycle.Timestate.Day;
			vector *= ((!sprinting) ? (flag ? speedDuringDay : speed) : (flag ? sprintSpeedDuringDay : sprintSpeed));
			slowedFor -= Time.deltaTime;
			vector *= ((slowedFor > 0f) ? 0.33f : 1f);
			if (heavyArmorEquipped && DayNightCycle.Instance.CurrentTimestate == DayNightCycle.Timestate.Night)
			{
				vector *= PerkManager.instance.heavyArmor_SpeedMultiplyer;
			}
			if (racingHorseEquipped)
			{
				vector *= PerkManager.instance.racingHorse_SpeedMultiplyer;
			}
		}
		rigidbody.velocity += vector;
		rigidbody.velocity += gravity * Time.deltaTime * Vector3.down;
		Vector3 position = rigidbody.position;
		float radius = myCollider.radius * myCollider.transform.localScale.x;
		if (!base.Dead)
		{
			int num = Physics.OverlapSphereNonAlloc(position, radius, tempColliders, lmRecieveDamage);
			for (int i = 0; i < num && !(tempColliders[i] == null); i++)
			{
				DealWithColliderHit(tempColliders[i]);
			}
		}
		time += Time.deltaTime;
		while (recentlyHitWhen.Count > 0 && time - recentlyHitWhen[0] > cooldownPerObject)
		{
			recentlyHitWhen.RemoveAt(0);
			recentlyHit.RemoveAt(0);
		}
	}

	private void FixedUpdate()
	{
		base.transform.position = targetPosition.position;
		meshParent.rotation = rigidbody.rotation;
	}

	public override void Start()
	{
		base.Start();
		playerMovement = GetComponentInParent<PlayerMovement>();
		upgradeManager = PlayerUpgradeManager.instance;
		blacksmithUpgrades = BlacksmithUpgrades.instance;
	}

	private void DealWithColliderHit(Collider other)
	{
		TaggedObject componentInParent = other.GetComponentInParent<TaggedObject>();
		if ((bool)componentInParent && !recentlyHit.Contains(componentInParent) && componentInParent.Tags.Contains(TagManager.ETag.EnemyOwned))
		{
			componentInParent.Hp.TakeDamage(Weapon.CalculateDamageGeneral(componentInParent, damage, DamageMultiplyer * rigidbody.velocity.magnitude));
			playerHp.TakeDamage(selfInflictedDamagePerHit * DamageMultiplyer);
			recentlyHit.Add(componentInParent);
			recentlyHitWhen.Add(time);
		}
	}
}
