using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;

public class SettingsTextLocalizeForI2 : MonoBehaviour
{
	public TextMeshProUGUI textTf;

	public List<string> localizeStrings;

	public void OnTextChanged()
	{
		CheckI2Localize();
	}

	private void CheckI2Localize()
	{
		for (int i = 0; i < localizeStrings.Count; i++)
		{
			if (textTf.text == localizeStrings[i])
			{
				textTf.text = LocalizationManager.GetTranslation(textTf.text);
				break;
			}
		}
	}
}
