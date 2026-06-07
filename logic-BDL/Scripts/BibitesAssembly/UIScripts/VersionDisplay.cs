using TMPro;
using UnityEngine;

namespace UIScripts
{
	public class VersionDisplay : MonoBehaviour
	{
		private TextMeshProUGUI text;

		private void Start()
		{
			text = GetComponent<TextMeshProUGUI>();
			text.text = "The Bibites " + Application.version;
		}
	}
}
