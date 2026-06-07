using UnityEngine;

public class PracticeTargetCoinDrop : MonoBehaviour
{
	private Hp hp;

	private TagManager tagManager;

	[SerializeField]
	private int totalCoinsToDrop = 3;

	private void Start()
	{
		hp = GetComponent<Hp>();
		tagManager = TagManager.instance;
	}

	private void Update()
	{
		if (tagManager.CountAllTaggedObjectsWithTag(TagManager.ETag.PracticeTargets) <= totalCoinsToDrop)
		{
			hp.coinCount = 1;
		}
	}

	private void OnDestroy()
	{
		if ((bool)hp && hp.HpValue <= 0f)
		{
			AchievementManager.UnlockAchievement(AchievementManager.Achievements.START_TUTORIAL);
		}
	}
}
