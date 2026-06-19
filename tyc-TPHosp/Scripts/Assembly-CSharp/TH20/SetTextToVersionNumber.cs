using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class SetTextToVersionNumber : MonoBehaviour
	{
		[SerializeField]
		private string _prefix = "";

		private void Awake()
		{
			string text = _prefix + GameVersionNumber.Version.FullVersionString;
			if (OnlineManager.IsInitialized())
			{
				text = text + " (Build: " + OSManager.BuildVersion() + ")";
			}
			Text component = GetComponent<Text>();
			if (component != null)
			{
				component.text = text;
			}
			TextMeshProUGUI component2 = GetComponent<TextMeshProUGUI>();
			if (component2 != null)
			{
				component2.text = text;
			}
		}
	}
}
