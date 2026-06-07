using System.Collections.Generic;
using UnityEngine;

public class TieBreaker : MonoBehaviour, DayNightCycle.IDaytimeSensitive
{
	[SerializeField]
	private float requiredTimeWithNoDeathsOrDestroyedBuildings = 30f;

	[SerializeField]
	private float damagePerSecond = 10f;

	private List<TagManager.ETag> mustHaveBuildings = new List<TagManager.ETag>();

	private List<TagManager.ETag> mayNotHaveBuildings = new List<TagManager.ETag>();

	public static TieBreaker instance;

	private EnemySpawner spawner;

	private TagManager tagManager;

	private bool active;

	private int enemiesLeftRemember = -1;

	private int buildingsLeftRemember = -1;

	private float timeupForTieBreaker;

	private bool tieBreakingActive;

	private List<TaggedObject> findTemp = new List<TaggedObject>();

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		spawner = EnemySpawner.instance;
		tagManager = TagManager.instance;
		DayNightCycle.Instance.RegisterDaytimeSensitiveObject(this);
		mustHaveBuildings.Add(TagManager.ETag.Building);
		mustHaveBuildings.Add(TagManager.ETag.AUTO_Alive);
	}

	public void OnDuskEarly()
	{
	}

	public void OnDusk()
	{
		active = true;
		enemiesLeftRemember = -1;
		buildingsLeftRemember = -1;
		timeupForTieBreaker = 0f;
		tieBreakingActive = false;
	}

	public void OnDawn_AfterSunrise()
	{
	}

	public void OnDawn_BeforeSunrise()
	{
		active = false;
		tieBreakingActive = false;
	}

	private void Update()
	{
		if (tieBreakingActive)
		{
			TieBreak();
		}
		else if (active && !spawner.SpawningInProgress)
		{
			timeupForTieBreaker += Time.deltaTime;
			if (tagManager.CountAllTaggedObjectsWithTag(TagManager.ETag.Boss) > 0)
			{
				timeupForTieBreaker = 0f;
			}
			if (spawner.NumberOfEnemiesOnTheMap != enemiesLeftRemember)
			{
				timeupForTieBreaker = 0f;
				enemiesLeftRemember = spawner.NumberOfEnemiesOnTheMap;
			}
			tagManager.FindAllTaggedObjectsWithTags(findTemp, mustHaveBuildings, mayNotHaveBuildings);
			int count = findTemp.Count;
			if (buildingsLeftRemember != count)
			{
				timeupForTieBreaker = 0f;
				buildingsLeftRemember = count;
			}
			if (timeupForTieBreaker > requiredTimeWithNoDeathsOrDestroyedBuildings)
			{
				tieBreakingActive = true;
			}
		}
	}

	private void TieBreak()
	{
		tagManager.FindAllTaggedObjectsWithTag(findTemp, TagManager.ETag.EnemyOwned);
		if (findTemp.Count > 0)
		{
			findTemp[0].Hp.TakeDamage(damagePerSecond * Time.deltaTime, null, causedByPlayer: false, invokeFeedbackEvents: false);
		}
	}
}
