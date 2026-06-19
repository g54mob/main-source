using TMPro;
using UnityEngine;

public class AudioMixingApplyButton : MonoBehaviour
{
	public TMP_InputField inputRef;

	public TextMeshProUGUI categoryNameField;

	private string audioCategoryID;

	public void SetInfo(string categoryID)
	{
		categoryNameField.text = categoryID;
		audioCategoryID = categoryID;
		RefreshInputFieldValue();
	}

	public void OnClick()
	{
		float result = 0f;
		float.TryParse(inputRef.text, out result);
		AudioController.SetCategoryVolume(audioCategoryID, result);
		RefreshInputFieldValue();
	}

	private void RefreshInputFieldValue()
	{
		inputRef.text = AudioController.GetCategoryVolume(audioCategoryID).ToString();
	}
}
