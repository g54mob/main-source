using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

public class AchievementDisplayManager : MonoBehaviour
{
	[SerializeField]
	private Transform displayParent;

	[SerializeField]
	private GameObject displayObjectPrefab;

	[SerializeField]
	private Vector2 displayOffset;

	[SerializeField]
	private TMP_Text achievementCounterText;

	[SerializeField]
	private LocalizedString achievementString;

	[SerializeField]
	private GlobalColor blackColor;

	public List<AchievementDisplayData> achievementDisplays = new List<AchievementDisplayData>();

	private int unlockCounter;

	public void Start()
	{
		CreateAchievementDisplayObjects();
		SoundManager.LoadSoundEffect(base.transform, SoundManager.instance.titel_impact);
	}

	private void CreateAchievementDisplayObjects()
	{
		unlockCounter = 0;
		List<AchievementDisplayObject> list = new List<AchievementDisplayObject>();
		List<AchievementDisplayObject> list2 = new List<AchievementDisplayObject>();
		for (int i = 0; i < achievementDisplays.Count; i++)
		{
			AchievementDisplayObject achievementDisplayObject = InstantiateDisplayObject(achievementDisplays[i]);
			if (achievementDisplayObject.isUnlocked)
			{
				list.Add(achievementDisplayObject);
			}
			else
			{
				list2.Add(achievementDisplayObject);
			}
		}
		achievementCounterText.text = achievementString.GetLocalizedString() + " : " + unlockCounter + " / " + (SteamAchievements.Achievements.Count + 1);
		Vector2 item = new Vector2((float)achievementDisplays.Count * displayOffset.x * -1f / 2f, (float)achievementDisplays.Count * displayOffset.y * -1f / 2f);
		item += new Vector2(displayOffset.x / 2f, displayOffset.y / 2f);
		List<Vector2> list3 = new List<Vector2>();
		for (int j = 0; j < achievementDisplays.Count; j++)
		{
			list3.Add(item);
			item += displayOffset;
		}
		list = list.OrderByDescending((AchievementDisplayObject achievement) => achievement.globalUnlock).ToList();
		list2 = list2.OrderByDescending((AchievementDisplayObject achievement) => achievement.globalUnlock).ToList();
		List<AchievementDisplayObject> list4 = new List<AchievementDisplayObject>();
		list4.AddRange(list);
		list4.AddRange(list2);
		for (int num = 0; num < list4.Count; num++)
		{
			list4[num].transform.localPosition = list3[num];
		}
	}

	private AchievementDisplayObject InstantiateDisplayObject(AchievementDisplayData achievementDisplayData)
	{
		AchievementDisplayObject component = Object.Instantiate(displayObjectPrefab, Vector3.zero, Quaternion.identity, displayParent).GetComponent<AchievementDisplayObject>();
		string id = ((achievementDisplayData.index >= 0) ? SteamAchievements.Achievements[achievementDisplayData.index] : "UNLOCK_ALL_ACHIEVEMENTS");
		if (component.isUnlocked = SteamAchievements.IsThisAchievementUnlocked(id))
		{
			unlockCounter++;
			component.icon.sprite = achievementDisplayData.icon;
			component.unlockIcon.enabled = true;
		}
		else
		{
			component.unlockIcon.enabled = false;
			component.displayName.color = blackColor.globalColor;
			component.description.color = blackColor.globalColor;
			if (!achievementDisplayData.showIfNotUnlocked)
			{
				component.description.enabled = false;
			}
		}
		component.displayName.text = SteamAchievements.TryGetNameOfAchievement(id);
		component.description.text = SteamAchievements.TryGetDescriptionOfAchievement(id);
		component.globalUnlock = SteamAchievements.TryGetGlobalUnlockedOfAchievement(id);
		return component;
	}
}
