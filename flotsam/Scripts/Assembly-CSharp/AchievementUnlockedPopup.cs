using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementUnlockedPopup : SceneBehaviour
{
	[SerializeField]
	private Image _icon;

	[SerializeField]
	private TextMeshProUGUI _title;

	[SerializeField]
	private TextMeshProUGUI _description;

	private void OnDisable()
	{
		base.gameObject.SetActive(value: false);
	}

	public void Activate(AchievementBase achievement)
	{
		base.gameObject.SetActive(value: true);
		_icon.overrideSprite = achievement.Icon;
		_title.text = achievement.Name;
		_description.text = achievement.Description;
	}
}
