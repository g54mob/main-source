using SettingScripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UIScripts.SettingHandles.References
{
	public class SettingToggleReference : MonoBehaviour
	{
		[SerializeField]
		public Toggle toggle;

		public TooltipTrigger tooltip;

		[SerializeField]
		public TextMeshProUGUI settingName;

		[SerializeField]
		public TextMeshProUGUI helperText;

		[SerializeField]
		public SettingHelper helperButton;
	}
}
