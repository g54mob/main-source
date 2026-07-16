using MLCN_Localization;
using TMPro;
using UnityEngine;

public class TutorialChecklistOptionSlot : MonoBehaviour
{
	[SerializeField]
	private TMP_Text label;

	[SerializeField]
	private GameObject checkmark;

	private string key;

	public string GetKey()
	{
		return key;
	}

	public void Init(string optionKey, string labelKey, bool check)
	{
		key = optionKey;
		label.text = LocalizationManager.GetLocalizedString(labelKey, LocalizationDataTable.Tables.UI);
		checkmark.SetActive(check);
	}

	public void Check()
	{
		checkmark.SetActive(value: true);
	}
}
