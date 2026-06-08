using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Dorfromantik
{
	public class PlayerPrefsOrganizer : MonoBehaviour
	{
		[SerializeField]
		private TMP_InputField keyNameInput;

		[SerializeField]
		private Image doesExistCheckmark;

		[SerializeField]
		private Image doesntExistCross;

		[SerializeField]
		private TextMeshProUGUI valueLabel;

		[SerializeField]
		private Button clearButton;

		private void Start()
		{
			UpdateUi();
		}

		public void UpdateUi()
		{
			string text = keyNameInput.text;
			bool flag = !string.IsNullOrWhiteSpace(text) && PlayerPrefs.HasKey(text);
			doesExistCheckmark.gameObject.SetActive(flag);
			doesntExistCross.gameObject.SetActive(!flag);
			string text2 = "-";
			if (flag)
			{
				text2 = PlayerPrefs.GetString(text, "");
				if (string.IsNullOrWhiteSpace(text2))
				{
					text2 = PlayerPrefs.GetInt(text, -99).ToString();
				}
				if (text2 == "99")
				{
					text2 = PlayerPrefs.GetFloat(text, 99f).ToString(CultureInfo.InvariantCulture);
				}
			}
			valueLabel.text = text2;
			clearButton.interactable = flag;
		}

		public void DeleteKey()
		{
			string text = keyNameInput.text;
			if (!string.IsNullOrWhiteSpace(text) && PlayerPrefs.HasKey(text))
			{
				PlayerPrefs.DeleteKey(text);
			}
			UpdateUi();
		}
	}
}
