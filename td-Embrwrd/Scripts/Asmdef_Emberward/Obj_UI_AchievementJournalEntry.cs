using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Obj_UI_AchievementJournalEntry : MonoBehaviour
{
	[SerializeField]
	[Header("Visual")]
	private Image image_Icon;

	[SerializeField]
	[Header("Texts")]
	private TMP_Text text_Name;

	[SerializeField]
	private TMP_Text text_Description;

	private eAchievementType achievementType;

	public void Setup(eAchievementType type, bool isCompleted, Sprite icon, string displayName, string description, int progress = -1, int maxProgress = -1)
	{
	}

	public eAchievementType GetAchievementType()
	{
		return default(eAchievementType);
	}
}
