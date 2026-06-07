using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UIScripts.SettingHandles.References
{
	public class TextLineReference : MonoBehaviour
	{
		public TextMeshProUGUI settingName;

		public TooltipTrigger tooltip;

		public TextMeshProUGUI line;

		public GameObject normalSection;

		public GameObject editSection;

		public TMP_InputField lineField;

		public Button openEdit;
	}
}
