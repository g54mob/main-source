using System.Collections.Generic;
using UnityEngine;

public class FireArcherBurn : WeaponDamageDealer
{
	public ParticleSystem hotOilGround;

	public float hotOilGroundBurnTickDuration = 0.2f;

	public int hotOilGroundBurnTicks = 5;

	public float range = 3.5f;

	public List<DamageModifyer> damageModifyers = new List<DamageModifyer>();

	public List<TagManager.ETag> mustHaveTags;

	public List<TagManager.ETag> mayNotHaveTags;

	public float timeTillSelfDestroy = 5f;

	private TagManager tagManager;

	private List<TaggedObject> foundTaggedObjects = new List<TaggedObject>();

	private float timeTillTickEnds;

	private int ticksRemaining;

	private void Start()
	{
		tagManager = TagManager.instance;
		if (DamageTick())
		{
			timeTillTickEnds = hotOilGroundBurnTickDuration;
			ticksRemaining = hotOilGroundBurnTicks - 1;
			if (hotOilGround != null)
			{
				ParticleSystem.EmissionModule emission = hotOilGround.emission;
				emission.enabled = true;
			}
		}
	}

	private void Update()
	{
		if (timeTillTickEnds > 0f)
		{
			timeTillTickEnds -= Time.deltaTime;
			if (timeTillTickEnds <= 0f)
			{
				ticksRemaining--;
				if (ticksRemaining < 0)
				{
					if (hotOilGround != null)
					{
						ParticleSystem.EmissionModule emission = hotOilGround.emission;
						emission.enabled = false;
					}
				}
				else
				{
					DamageTick();
					timeTillTickEnds = hotOilGroundBurnTickDuration;
				}
			}
		}
		timeTillSelfDestroy -= Time.deltaTime;
		if (timeTillSelfDestroy <= 0f)
		{
			Object.Destroy(base.gameObject);
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
				foundTaggedObjects[i].Hp.TakeDamage(DamageModifyer.CalculateDamageOnTarget(foundTaggedObjects[i], damageModifyers, damageMultiplyer) / (float)hotOilGroundBurnTicks);
			}
		}
		return result;
	}
}
