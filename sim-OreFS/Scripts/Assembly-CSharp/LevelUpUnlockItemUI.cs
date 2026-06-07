using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpUnlockItemUI : MonoBehaviour
{
	[Header("UI References")]
	[SerializeField]
	private Image iconImage;

	[SerializeField]
	private TMP_Text titleText;

	[SerializeField]
	private TMP_Text subtitleText;

	public void Setup(Sprite icon, string title)
	{
		Setup(icon, title, null);
	}

	public void Setup(Sprite icon, string title, string subtitle)
	{
		if (iconImage != null)
		{
			iconImage.sprite = icon;
			iconImage.gameObject.SetActive(icon != null);
		}
		if (titleText != null)
		{
			titleText.text = title;
		}
		if (subtitleText != null)
		{
			bool flag = !string.IsNullOrEmpty(subtitle);
			subtitleText.gameObject.SetActive(flag);
			if (flag)
			{
				subtitleText.text = subtitle;
			}
		}
	}
}
