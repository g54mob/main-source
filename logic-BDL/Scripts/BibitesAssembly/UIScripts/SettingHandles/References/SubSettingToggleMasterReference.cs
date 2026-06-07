using SettingScripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UIScripts.SettingHandles.References
{
	public class SubSettingToggleMasterReference : MonoBehaviour
	{
		[SerializeField]
		public Toggle toggle;

		[SerializeField]
		public TextMeshProUGUI settingName;

		[SerializeField]
		public TextMeshProUGUI helperText;

		[SerializeField]
		public SettingHelper helperButton;

		public Button editSubSettingsButton;
	}
}
