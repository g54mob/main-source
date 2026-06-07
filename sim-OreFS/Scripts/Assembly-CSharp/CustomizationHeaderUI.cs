using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CustomizationHeaderUI : MonoBehaviour
{
	[Header("References")]
	public Image iconImage;

	public TextMeshProUGUI titleText;

	[Tooltip("Option satırlarının spawn edileceği child transform")]
	public Transform optionContent;

	public void Setup(string i2Key, Sprite icon)
	{
		if (titleText != null)
		{
			string translation = LocalizationManager.GetTranslation(i2Key);
			titleText.text = ((!string.IsNullOrEmpty(translation)) ? translation : i2Key);
		}
		if (iconImage != null)
		{
			if (icon != null)
			{
				iconImage.sprite = icon;
				iconImage.enabled = true;
			}
			else
			{
				iconImage.enabled = false;
			}
		}
	}
}
