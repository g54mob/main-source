using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class FishPreferenceUI : MonoBehaviour
{
	public Image iconImage;

	public TMP_Text strengthText;

	public TMP_Text descriptionText;

	public void Setup(Sprite icon, string strength, LocalizedString formatString, LocalizedString categoryString)
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
		if (strengthText != null)
		{
			strengthText.text = strength;
		}
		if (descriptionText != null)
		{
			if (formatString != null && !formatString.IsEmpty && categoryString != null && !categoryString.IsEmpty)
			{
				string localizedString = categoryString.GetLocalizedString();
				formatString.Arguments = new object[1] { localizedString };
				descriptionText.text = formatString.GetLocalizedString();
			}
			else if (categoryString != null && !categoryString.IsEmpty)
			{
				descriptionText.text = categoryString.GetLocalizedString();
			}
			else
			{
				descriptionText.text = "";
			}
		}
	}
}
