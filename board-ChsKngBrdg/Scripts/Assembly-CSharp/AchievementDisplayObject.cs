using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementDisplayObject : MonoBehaviour
{
	public Image icon;

	public TMP_Text displayName;

	public TMP_Text description;

	public Image unlockIcon;

	public bool isUnlocked;

	public float globalUnlock = -1f;
}
