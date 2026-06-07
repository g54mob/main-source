using TMPro;
using UnityEngine;

namespace Presentation.UI.Menus.SettingsCategories.Controls
{
	public class SettingsControlsSubtitle : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _text;

		public void SetText(string text)
		{
			_text.SetText(text);
		}
	}
}
