using System.Collections.Generic;
using UnityEngine;

public class RidingDamager : MonoBehaviour
{
	public Hp playerHp;

	[BalancingParameter(BalancingParameter.EType.Default)]
	public float selfInflictedDamagePerHit = 1f;

	public Equippable requiredUpgradeForRidingDamage;

	public Equippable requiredUpgradeForRidingSlow;

	public LayerMask lmRecieveDamage;

	public List<DamageModifyer> damage;

	private BoxCollider myCollider;

	private Collider[] tempColliders = new Collider[50];

	public float cooldownPerObject = 4f;

	private PlayerMovement playerMovement;

	private PlayerUpgradeManager upgradeManager;

	private BlacksmithUpgrades blacksmithUpgrades;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private float slowDuration = 1f;

	private List<TaggedObject> recentlyHit = new List<TaggedObject>();

	private List<float> recentlyHitWhen = new List<float>();

	private float time;

	private bool ridingDamage;

	private bool ridingSlow;

	public float DamageMultiplyer => upgradeManager.PlayerDamageMultiplyer * blacksmithUpgrades.meleeDamage;

	private void Start()
	{
		ridingDamage = PerkManager.IsEquipped(requiredUpgradeForRidingDamage);
		ridingSlow = PerkManager.IsEquipped(requiredUpgradeForRidingSlow);
		if (!ridingDamage && !ridingSlow)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		myCollider = GetComponent<BoxCollider>();
		playerMovement = GetComponentInParent<PlayerMovement>();
		upgradeManager = PlayerUpgradeManager.instance;
		blacksmithUpgrades = BlacksmithUpgrades.instance;
	}

	private void Update()
	{
		Vector3 center = base.transform.localToWorldMatrix.MultiplyPoint(myCollider.center);
		Vector3 halfExtents = base.transform.localToWorldMatrix.MultiplyVector(myCollider.size);
		if (playerMovement.Moving && playerMovement.enabled && playerHp.HpValue > 0f)
		{
			int num = Physics.OverlapBoxNonAlloc(center, halfExtents, tempColliders, base.transform.rotation, lmRecieveDamage);
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

	private void DealWithColliderHit(Collider other)
	{
		TaggedObject componentInParent = other.GetComponentInParent<TaggedObject>();
		if ((bool)componentInParent && !recentlyHit.Contains(componentInParent) && componentInParent.Tags.Contains(TagManager.ETag.EnemyOwned))
		{
			if (ridingDamage)
			{
				componentInParent.Hp.TakeDamage(Weapon.CalculateDamageGeneral(componentInParent, damage, DamageMultiplyer));
				playerHp.TakeDamage(selfInflictedDamagePerHit * DamageMultiplyer);
			}
			if (ridingSlow && (bool)componentInParent.Hp.PathfindMovement)
			{
				componentInParent.Hp.PathfindMovement.Slow(slowDuration);
			}
			recentlyHit.Add(componentInParent);
			recentlyHitWhen.Add(time);
		}
	}
}
