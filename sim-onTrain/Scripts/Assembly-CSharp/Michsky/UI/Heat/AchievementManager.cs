using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.UI.Heat
{
	[DisallowMultipleComponent]
	public class AchievementManager : MonoBehaviour
	{
		public UIManager UIManagerAsset;

		[SerializeField]
		private Transform allParent;

		[SerializeField]
		private Transform commonParent;

		[SerializeField]
		private Transform rareParent;

		[SerializeField]
		private Transform legendaryParent;

		[SerializeField]
		private GameObject achievementPreset;

		[SerializeField]
		private TextMeshProUGUI totalUnlockedObj;

		[SerializeField]
		private TextMeshProUGUI totalValueObj;

		[SerializeField]
		private TextMeshProUGUI commonUnlockedObj;

		[SerializeField]
		private TextMeshProUGUI commonlTotalObj;

		[SerializeField]
		private TextMeshProUGUI rareUnlockedObj;

		[SerializeField]
		private TextMeshProUGUI rareTotalObj;

		[SerializeField]
		private TextMeshProUGUI legendaryUnlockedObj;

		[SerializeField]
		private TextMeshProUGUI legendaryTotalObj;

		public bool useLocalization = true;

		[SerializeField]
		private bool useAlphabeticalOrder = true;

		private int totalCount;

		private int commonCount;

		private int rareCount;

		private int legendaryCount;

		private int totalUnlockedCount;

		private int commonUnlockedCount;

		private int rareUnlockedCount;

		private int legendaryUnlockedCount;

		private LocalizedObject localizedObject;

		private void Awake()
		{
			InitializeItems();
		}

		private static int SortByName(AchievementLibrary.AchievementItem o1, AchievementLibrary.AchievementItem o2)
		{
			return o1.title.CompareTo(o2.title);
		}

		public void InitializeItems()
		{
			if (UIManagerAsset == null || UIManagerAsset.achievementLibrary == null || achievementPreset == null)
			{
				return;
			}
			if (useAlphabeticalOrder)
			{
				UIManagerAsset.achievementLibrary.achievements.Sort(SortByName);
			}
			if (useLocalization)
			{
				localizedObject = base.gameObject.GetComponent<LocalizedObject>();
				if (localizedObject == null || !localizedObject.CheckLocalizationStatus())
				{
					useLocalization = false;
				}
			}
			foreach (Transform item in allParent)
			{
				Object.Destroy(item.gameObject);
			}
			foreach (Transform item2 in commonParent)
			{
				Object.Destroy(item2.gameObject);
			}
			foreach (Transform item3 in rareParent)
			{
				Object.Destroy(item3.gameObject);
			}
			foreach (Transform item4 in legendaryParent)
			{
				Object.Destroy(item4.gameObject);
			}
			for (int i = 0; i < UIManagerAsset.achievementLibrary.achievements.Count; i++)
			{
				Transform parent = null;
				AchievementLibrary.AchievementType achievementType = AchievementLibrary.AchievementType.Common;
				totalCount++;
				if (UIManagerAsset.achievementLibrary.achievements[i].type == AchievementLibrary.AchievementType.Common)
				{
					parent = commonParent;
					achievementType = AchievementLibrary.AchievementType.Common;
					commonCount++;
				}
				else if (UIManagerAsset.achievementLibrary.achievements[i].type == AchievementLibrary.AchievementType.Rare)
				{
					parent = rareParent;
					achievementType = AchievementLibrary.AchievementType.Rare;
					rareCount++;
				}
				else if (UIManagerAsset.achievementLibrary.achievements[i].type == AchievementLibrary.AchievementType.Legendary)
				{
					parent = legendaryParent;
					achievementType = AchievementLibrary.AchievementType.Legendary;
					legendaryCount++;
				}
				GameObject gameObject = Object.Instantiate(achievementPreset, new Vector3(0f, 0f, 0f), Quaternion.identity);
				gameObject.transform.SetParent(parent, worldPositionStays: false);
				AchievementItem component = gameObject.GetComponent<AchievementItem>();
				component.lockedIndicator.SetActive(value: true);
				component.unlockedIndicator.SetActive(value: false);
				if ((UIManagerAsset.achievementLibrary.achievements[i].isHidden && PlayerPrefs.GetString("ACH_" + UIManagerAsset.achievementLibrary.achievements[i].title) == "true") || !UIManagerAsset.achievementLibrary.achievements[i].isHidden || UIManagerAsset.achievementLibrary.achievements[i].dataBehaviour == AchievementLibrary.DataBehaviour.Unlocked)
				{
					component.iconObj.sprite = UIManagerAsset.achievementLibrary.achievements[i].icon;
					if (!useLocalization)
					{
						component.titleObj.text = UIManagerAsset.achievementLibrary.achievements[i].title;
						component.descriptionObj.text = UIManagerAsset.achievementLibrary.achievements[i].description;
					}
					else
					{
						LocalizedObject component2 = component.titleObj.GetComponent<LocalizedObject>();
						if (component2 != null)
						{
							component2.tableIndex = localizedObject.tableIndex;
							component2.localizationKey = UIManagerAsset.achievementLibrary.achievements[i].titleKey;
						}
						LocalizedObject component3 = component.descriptionObj.GetComponent<LocalizedObject>();
						if (component3 != null)
						{
							component3.tableIndex = localizedObject.tableIndex;
							component3.localizationKey = UIManagerAsset.achievementLibrary.achievements[i].decriptionKey;
						}
					}
				}
				else
				{
					component.iconObj.sprite = UIManagerAsset.achievementLibrary.achievements[i].hiddenIcon;
					if (!useLocalization)
					{
						component.titleObj.text = UIManagerAsset.achievementLibrary.achievements[i].hiddenTitle;
						component.descriptionObj.text = UIManagerAsset.achievementLibrary.achievements[i].hiddenDescription;
					}
					else
					{
						LocalizedObject component4 = component.titleObj.GetComponent<LocalizedObject>();
						if (component4 != null)
						{
							component4.tableIndex = localizedObject.tableIndex;
							component4.localizationKey = UIManagerAsset.achievementLibrary.achievements[i].hiddenTitleKey;
						}
						LocalizedObject component5 = component.descriptionObj.GetComponent<LocalizedObject>();
						if (component5 != null)
						{
							component5.tableIndex = localizedObject.tableIndex;
							component5.localizationKey = UIManagerAsset.achievementLibrary.achievements[i].hiddenDescKey;
						}
					}
				}
				for (int j = 0; j < component.images.Count; j++)
				{
					switch (achievementType)
					{
					case AchievementLibrary.AchievementType.Common:
						component.images[j].color = new Color(UIManagerAsset.commonColor.r, UIManagerAsset.commonColor.g, UIManagerAsset.commonColor.b, component.images[j].color.a);
						break;
					case AchievementLibrary.AchievementType.Rare:
						component.images[j].color = new Color(UIManagerAsset.rareColor.r, UIManagerAsset.rareColor.g, UIManagerAsset.rareColor.b, component.images[j].color.a);
						break;
					case AchievementLibrary.AchievementType.Legendary:
						component.images[j].color = new Color(UIManagerAsset.legendaryColor.r, UIManagerAsset.legendaryColor.g, UIManagerAsset.legendaryColor.b, component.images[j].color.a);
						break;
					}
				}
				if ((!PlayerPrefs.HasKey("ACH_" + UIManagerAsset.achievementLibrary.achievements[i].title) && UIManagerAsset.achievementLibrary.achievements[i].dataBehaviour == AchievementLibrary.DataBehaviour.Unlocked) || PlayerPrefs.GetString("ACH_" + UIManagerAsset.achievementLibrary.achievements[i].title) == "true")
				{
					if (component.lockedIndicator != null)
					{
						component.lockedIndicator.SetActive(value: false);
					}
					if (component.unlockedIndicator != null)
					{
						component.unlockedIndicator.SetActive(value: true);
					}
					switch (achievementType)
					{
					case AchievementLibrary.AchievementType.Common:
						commonUnlockedCount++;
						break;
					case AchievementLibrary.AchievementType.Rare:
						rareUnlockedCount++;
						break;
					case AchievementLibrary.AchievementType.Legendary:
						legendaryUnlockedCount++;
						break;
					}
					totalUnlockedCount++;
				}
				Object.Instantiate(gameObject, new Vector3(0f, 0f, 0f), Quaternion.identity).transform.SetParent(allParent, worldPositionStays: false);
			}
			ParseTotalText();
		}

		private void ParseTotalText()
		{
			if (totalValueObj != null)
			{
				totalValueObj.text = totalCount.ToString();
			}
			if (totalUnlockedObj != null)
			{
				totalUnlockedObj.text = totalUnlockedCount.ToString();
			}
			if (commonUnlockedObj != null)
			{
				commonUnlockedObj.text = commonUnlockedCount.ToString();
			}
			if (rareUnlockedObj != null)
			{
				rareUnlockedObj.text = rareUnlockedCount.ToString();
			}
			if (legendaryUnlockedObj != null)
			{
				legendaryUnlockedObj.text = legendaryUnlockedCount.ToString();
			}
			if (commonlTotalObj != null)
			{
				commonlTotalObj.text = commonCount.ToString();
				foreach (Transform item in commonlTotalObj.transform.parent)
				{
					TextMeshProUGUI component = item.GetComponent<TextMeshProUGUI>();
					if (component != null)
					{
						component.color = new Color(UIManagerAsset.commonColor.r, UIManagerAsset.commonColor.g, UIManagerAsset.commonColor.b, component.color.a);
						Image componentInChildren = component.GetComponentInChildren<Image>();
						if (componentInChildren != null)
						{
							componentInChildren.color = new Color(UIManagerAsset.commonColor.r, UIManagerAsset.commonColor.g, UIManagerAsset.commonColor.b, componentInChildren.color.a);
						}
					}
					else
					{
						Image component2 = item.GetComponent<Image>();
						if (component2 != null)
						{
							component2.color = new Color(UIManagerAsset.commonColor.r, UIManagerAsset.commonColor.g, UIManagerAsset.commonColor.b, component2.color.a);
						}
					}
				}
			}
			if (rareTotalObj != null)
			{
				rareTotalObj.text = rareCount.ToString();
				foreach (Transform item2 in rareTotalObj.transform.parent)
				{
					TextMeshProUGUI component3 = item2.GetComponent<TextMeshProUGUI>();
					if (component3 != null)
					{
						component3.color = new Color(UIManagerAsset.rareColor.r, UIManagerAsset.rareColor.g, UIManagerAsset.rareColor.b, component3.color.a);
						Image componentInChildren2 = component3.GetComponentInChildren<Image>();
						if (componentInChildren2 != null)
						{
							componentInChildren2.color = new Color(UIManagerAsset.rareColor.r, UIManagerAsset.rareColor.g, UIManagerAsset.rareColor.b, componentInChildren2.color.a);
						}
					}
					else
					{
						Image component4 = item2.GetComponent<Image>();
						if (component4 != null)
						{
							component4.color = new Color(UIManagerAsset.rareColor.r, UIManagerAsset.rareColor.g, UIManagerAsset.rareColor.b, component4.color.a);
						}
					}
				}
			}
			if (!(legendaryTotalObj != null))
			{
				return;
			}
			legendaryTotalObj.text = legendaryCount.ToString();
			foreach (Transform item3 in legendaryTotalObj.transform.parent)
			{
				TextMeshProUGUI component5 = item3.GetComponent<TextMeshProUGUI>();
				if (component5 != null)
				{
					component5.color = new Color(UIManagerAsset.legendaryColor.r, UIManagerAsset.legendaryColor.g, UIManagerAsset.legendaryColor.b, component5.color.a);
					Image componentInChildren3 = component5.GetComponentInChildren<Image>();
					if (componentInChildren3 != null)
					{
						componentInChildren3.color = new Color(UIManagerAsset.legendaryColor.r, UIManagerAsset.legendaryColor.g, UIManagerAsset.legendaryColor.b, componentInChildren3.color.a);
					}
				}
				else
				{
					Image component6 = item3.GetComponent<Image>();
					if (component6 != null)
					{
						component6.color = new Color(UIManagerAsset.legendaryColor.r, UIManagerAsset.legendaryColor.g, UIManagerAsset.legendaryColor.b, component6.color.a);
					}
				}
			}
		}

		public static void SetAchievement(string title, bool value)
		{
			if (value)
			{
				PlayerPrefs.SetString("ACH_" + title, "true");
			}
			else
			{
				PlayerPrefs.SetString("ACH_" + title, "false");
			}
		}
	}
}
