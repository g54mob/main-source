using UnityEngine;

public class SpawnAttackOnCollision : MonoBehaviour, DayNightCycle.IDaytimeSensitive
{
	public static float lastTriggerProducitonProgress;

	[SerializeField]
	private Weapon spwanAttackOnCollision;

	public ThronefallAudioManager.AudioOneShot placementSound;

	public ThronefallAudioManager.AudioOneShot fireSound;

	[SerializeField]
	private bool isPlayerAttack;

	[SerializeField]
	private float preSelectRadius = 20f;

	private Collider[] overlapColliders = new Collider[50];

	[SerializeField]
	private LayerMask lmTakeDamage;

	[SerializeField]
	private BoxCollider myCollider;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Percentage)]
	private float baseDamagePercentage = 0.2f;

	private float productionProgress;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private float productionTime = 10f;

	[SerializeField]
	private ProductionBar productionBar;

	[SerializeField]
	private GameObject fullyChargedIndicator;

	public float damageMultiplyer = 1f;

	public Weapon SpwanAttackOnDeath
	{
		get
		{
			return spwanAttackOnCollision;
		}
		set
		{
			spwanAttackOnCollision = value;
		}
	}

	private TaggedObject taggedObject { get; set; }

	private void Start()
	{
		DayNightCycle.Instance.RegisterDaytimeSensitiveObject(this);
		ThronefallAudioManager.WorldSpaceOneShot(placementSound, base.transform.position);
		if (isPlayerAttack)
		{
			damageMultiplyer *= PlayerUpgradeManager.instance.PlayerDamageMultiplyer;
		}
	}

	private void Update()
	{
		productionProgress = Mathf.Min(1f, productionProgress + Time.deltaTime / productionTime);
		if (productionProgress < 1f)
		{
			productionBar.UpdateVisual(productionProgress);
		}
		else if (productionBar.gameObject.activeSelf)
		{
			productionBar.gameObject.SetActive(value: false);
			fullyChargedIndicator.SetActive(value: true);
		}
		foreach (TaggedObject enemyUnit in TagManager.instance.EnemyUnits)
		{
			if (!(Vector3.Distance(base.transform.position, enemyUnit.transform.position) <= preSelectRadius))
			{
				continue;
			}
			overlapColliders = Physics.OverlapBox(base.transform.position, myCollider.size, base.transform.rotation, lmTakeDamage);
			Collider[] array = overlapColliders;
			for (int i = 0; i < array.Length; i++)
			{
				TaggedObject componentInParent = array[i].GetComponentInParent<TaggedObject>();
				if ((bool)componentInParent && componentInParent.Tags.Contains(TagManager.ETag.EnemyOwned))
				{
					Fire();
				}
			}
			break;
		}
	}

	private void Fire()
	{
		lastTriggerProducitonProgress = productionProgress;
		DayNightCycle.Instance.UnregisterDaytimeSensitiveObject(this);
		ThronefallAudioManager.WorldSpaceOneShot(fireSound, base.transform.position);
		if ((bool)spwanAttackOnCollision)
		{
			spwanAttackOnCollision.Attack(base.transform.position, null, Vector3.zero, taggedObject, damageMultiplyer * Mathf.Lerp(productionProgress, 1f, baseDamagePercentage));
		}
		Object.Destroy(base.gameObject);
	}

	public void OnDuskEarly()
	{
	}

	public void OnDusk()
	{
	}

	public void OnDawn_AfterSunrise()
	{
		DayNightCycle.Instance.UnregisterDaytimeSensitiveObject(this);
		Object.Destroy(base.gameObject);
	}

	public void OnDawn_BeforeSunrise()
	{
		DayNightCycle.Instance.UnregisterDaytimeSensitiveObject(this);
		Object.Destroy(base.gameObject);
	}
}
