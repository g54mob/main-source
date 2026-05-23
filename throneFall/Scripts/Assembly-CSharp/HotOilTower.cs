using System.Collections.Generic;
using UnityEngine;

public class HotOilTower : MonoBehaviour
{
	public ParticleSystem hotOilGround;

	public float hotOilGroundBurnTickDuration = 0.2f;

	public int hotOilGroundBurnTicks = 5;

	public float attackCooldown = 5f;

	public float checkRate = 1f;

	public float range = 3.5f;

	public List<DamageModifyer> damageModifyers = new List<DamageModifyer>();

	public List<TagManager.ETag> mustHaveTags;

	public List<TagManager.ETag> mayNotHaveTags;

	public float DamageMultiplyer = 1f;

	private float cooldown;

	private TagManager tagManager;

	private List<TaggedObject> foundTaggedObjects = new List<TaggedObject>();

	private float timeTillTickEnds;

	private int ticksRemaining;

	private BlacksmithUpgrades blacksmithUpgrages;

	private void Start()
	{
		cooldown = Random.value;
		tagManager = TagManager.instance;
	}

	public void ReduceCooldownBy(float _reduceBy)
	{
		cooldown -= _reduceBy;
	}

	private void Update()
	{
		cooldown -= Time.deltaTime;
		if (timeTillTickEnds > 0f)
		{
			timeTillTickEnds -= Time.deltaTime;
			if (timeTillTickEnds <= 0f)
			{
				ticksRemaining--;
				if (ticksRemaining < 0)
				{
					ParticleSystem.EmissionModule emission = hotOilGround.emission;
					emission.enabled = false;
				}
				else
				{
					DamageTick();
					timeTillTickEnds = hotOilGroundBurnTickDuration;
				}
			}
		}
		if (cooldown <= 0f)
		{
			if (DamageTick())
			{
				cooldown = attackCooldown;
				timeTillTickEnds = hotOilGroundBurnTickDuration;
				ticksRemaining = hotOilGroundBurnTicks - 1;
				ParticleSystem.EmissionModule emission2 = hotOilGround.emission;
				emission2.enabled = true;
			}
			else
			{
				cooldown = checkRate;
			}
		}
	}

	private bool DamageTick()
	{
		bool result = false;
		tagManager.FindAllTaggedObjectsWithTags(foundTaggedObjects, mustHaveTags, mayNotHaveTags);
		for (int i = 0; i < foundTaggedObjects.Count; i++)
		{
			if (!(tagManager.MeasureDistanceToTaggedObject(foundTaggedObjects[i], base.transform.position) > range))
			{
				result = true;
				if (!blacksmithUpgrages)
				{
					blacksmithUpgrages = BlacksmithUpgrades.instance;
				}
				float meleeDamage = blacksmithUpgrages.meleeDamage;
				foundTaggedObjects[i].Hp.TakeDamage(DamageModifyer.CalculateDamageOnTarget(foundTaggedObjects[i], damageModifyers, DamageMultiplyer * meleeDamage) / (float)hotOilGroundBurnTicks);
			}
		}
		return result;
	}
}
