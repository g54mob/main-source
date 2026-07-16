using UnityEngine;

[CreateAssetMenu(fileName = "MissileGoblin", menuName = "Upgrade/Missile/Goblin")]
public class UpgradeMissileGoblin : EnhancementUpgrade
{
	[SerializeField]
	private float goodProb = 0.5f;

	[SerializeField]
	private float badProb = 0.25f;

	[SerializeField]
	private StatusEffect goodStatus;

	private StatusEffect currentGoodStatus;

	private ModuleMissile moduleMissile;

	private float minBadLifetime = 0.5f;

	private float maxBadLifetime = 1.5f;

	public override void ApplyUpgrade()
	{
		ModuleMissile moduleByType = Train.Instance.GetModuleByType<ModuleMissile>();
		if ((object)moduleByType != null)
		{
			moduleMissile = moduleByType;
			moduleMissile.PreMissileSpawn += PreMissileSpawn;
			moduleMissile.PostMissileSpawn += PostMissileSpawn;
		}
	}

	private void PreMissileSpawn()
	{
		float num = goodProb + goodProb * GlobalFields.Instance.LuckProb;
		if (!(Random.Range(0f, 1f) > num))
		{
			currentGoodStatus = moduleMissile.StatsSO.ApplyStatusEffect(goodStatus);
		}
	}

	private void PostMissileSpawn(GameObject missile)
	{
		moduleMissile.StatsSO.RemoveStatusEffect(currentGoodStatus);
		float num = badProb - badProb * GlobalFields.Instance.LuckProb;
		if (!(Random.Range(0f, 1f) > num))
		{
			Missile component2;
			if (missile.TryGetComponent<APCMissile>(out var component))
			{
				component.lifetime = Random.Range(minBadLifetime, maxBadLifetime);
			}
			else if (missile.TryGetComponent<Missile>(out component2))
			{
				component2.lifetime = Random.Range(minBadLifetime, maxBadLifetime);
			}
		}
	}
}
