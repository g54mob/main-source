using UnityEngine;

namespace Kitchen
{
	public class ColourBlindMode : MonoBehaviour
	{
		public bool ShowInColourblindMode = true;

		public bool ShowInNonColourblindMode;

		public GameObject Element;

		private void Update()
		{
			bool flag = (Preferences.Get<bool>(Pref.AccessibilityColourBlindMode) ? ShowInColourblindMode : ShowInNonColourblindMode);
			if (Element.activeSelf != flag)
			{
				Element.SetActive(flag);
			}
		}
	}
}
