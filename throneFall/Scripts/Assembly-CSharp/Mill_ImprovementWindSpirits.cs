using System.Collections.Generic;
using UnityEngine;

public class Mill_ImprovementWindSpirits : MonoBehaviour, DayNightCycle.IDaytimeSensitive
{
	[SerializeField]
	private BuildSlot buildSlot;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private float blockIntervalLvl1 = 1f;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private float blockIntervalLvl2 = 0.5f;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private float blockIntervalLvl3 = 0.25f;

	public Mesh lvl2Mesh;

	public Mesh lvl3Mesh;

	private float blockInterval = 1f;

	[SerializeField]
	[BalancingParameter(BalancingParameter.EType.Default)]
	private float range = 30f;

	[SerializeField]
	private GameObject fxBlockArrow;

	private float cooldown;

	private TagManager tagManager;

	public List<TagManager.ETag> mustHaveTags = new List<TagManager.ETag>();

	private List<TagManager.ETag> mayNotHaveTags = new List<TagManager.ETag>();

	[SerializeField]
	private TagManager.ETag giveSelfAndFieldsmillThisTag;

	private void Start()
	{
		tagManager = TagManager.instance;
		cooldown = Random.value * blockInterval;
		DayNightCycle.Instance.RegisterDaytimeSensitiveObject(this);
	}

	private void Update()
	{
		cooldown -= Time.deltaTime;
		while (cooldown <= 0f)
		{
			BlockAnArrow();
			cooldown += blockInterval;
		}
	}

	private void BlockAnArrow()
	{
		TaggedObject taggedObject = tagManager.FindClosestTaggedObjectWithTags(base.transform.position, mustHaveTags, mayNotHaveTags);
		if (!(taggedObject == null) && (taggedObject.transform.position - base.transform.position).magnitude < range)
		{
			if ((bool)fxBlockArrow)
			{
				Object.Instantiate(fxBlockArrow, taggedObject.transform.position, Quaternion.identity);
			}
			Object.Destroy(taggedObject.gameObject);
		}
	}

	private void OnEnable()
	{
		buildSlot.upgrades[1].upgradeBranches[0].replacementMesh = lvl2Mesh;
		buildSlot.upgrades[2].upgradeBranches[0].replacementMesh = lvl3Mesh;
		GetComponentInParent<TaggedObject>().AddTag(giveSelfAndFieldsmillThisTag);
		foreach (BuildSlot item in GetComponentInParent<BuildSlot>().BuiltSlotsThatRelyOnThisBuilding)
		{
			item.GetComponentInChildren<TaggedObject>(includeInactive: true).AddTag(giveSelfAndFieldsmillThisTag);
		}
		SetCorrectWeapon();
	}

	public void OnDusk()
	{
		SetCorrectWeapon();
	}

	public void OnDawn_AfterSunrise()
	{
	}

	public void OnDawn_BeforeSunrise()
	{
	}

	private void SetCorrectWeapon()
	{
		if (buildSlot.Level == 1)
		{
			blockInterval = blockIntervalLvl1;
		}
		else if (buildSlot.Level == 2)
		{
			blockInterval = blockIntervalLvl2;
		}
		else if (buildSlot.Level == 3)
		{
			blockInterval = blockIntervalLvl3;
		}
	}

	public void OnDuskEarly()
	{
	}
}
