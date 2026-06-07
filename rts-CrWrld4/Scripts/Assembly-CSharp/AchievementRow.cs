using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementRow : MonoBehaviour
{
	public Image image;

	public TextMeshProUGUI achievementName;

	public TextMeshProUGUI desc;

	public GameObject progressContainer;

	public TextMeshProUGUI progressText;

	public Image progressBar;

	public void Init(Achievements.AchievementRecord ar)
	{
	}
}
