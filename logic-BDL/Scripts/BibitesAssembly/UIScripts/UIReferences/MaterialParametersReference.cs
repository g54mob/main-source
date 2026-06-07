using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UIScripts.UIReferences
{
	public class MaterialParametersReference : MonoBehaviour
	{
		public Image pelletImage;

		public TextMeshProUGUI titleText;

		public Button resetButton;

		public GameObject settingsHolder;

		public GameObject subSettingsPanel;

		public void ToggleSubSettingsPanel()
		{
			subSettingsPanel.SetActive(!subSettingsPanel.activeSelf);
		}
	}
}
