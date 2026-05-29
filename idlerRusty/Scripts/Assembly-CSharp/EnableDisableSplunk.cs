using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnableDisableSplunk : MonoBehaviour
{
	private Toggle toggle;

	[SerializeField]
	private TMP_Text enabledDisabledText;

	private string enabledString = "_ENABLE_SPLUNK";

	private string disabledString = "_DISABLE_SPLUNK";

	private void OnEnable()
	{
		toggle = GetComponent<Toggle>();
		toggle.SetIsOnWithoutNotify(GameManager.ins.autoPlantSeeds);
		UpdateText(GameManager.ins.autoPlantSeeds);
	}

	public void ToggleSplunk(bool value)
	{
		GameManager.ins.autoPlantSeeds = value;
		UpdateText(value);
	}

	private void UpdateText(bool value)
	{
		if (value)
		{
			enabledDisabledText.text = LocalizationSystem.GetLocalizedValue(enabledString);
		}
		else
		{
			enabledDisabledText.text = LocalizationSystem.GetLocalizedValue(disabledString);
		}
	}
}
