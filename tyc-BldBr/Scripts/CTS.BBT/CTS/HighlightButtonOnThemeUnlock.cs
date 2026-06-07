using System.Collections;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class HighlightButtonOnThemeUnlock : CTSBehaviour
	{
		[SerializeField]
		private StringKey _buttonKey;

		[SerializeField]
		private bool _alsoHighlightIfThemePanelOpened;

		private IEnumerator Start()
		{
			yield return Coroutines.WaitForSecondsRealtime(2f);
			ThemeManager.ThemeUnlocked += OnThemeUnlocked;
		}

		private void OnDestroy()
		{
			ThemeManager.ThemeUnlocked -= OnThemeUnlocked;
		}

		private void OnThemeUnlocked()
		{
			if (_alsoHighlightIfThemePanelOpened || !BBTUI.GetCanvas(BBTUI.Instance.PanelID_Themes).IsShown)
			{
				HighlightButton.Highlight(_buttonKey);
			}
		}
	}
}
