using CTS.Core;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class CutsceneFeature_ScrollingText : CutsceneFeature, ILocaleRepaint
	{
		[SerializeField]
		private UI_ScrollingText _scrollingText;

		protected override void OnRepaint()
		{
			if ((bool)_manager.CurrentPage)
			{
				string text = "";
				for (int i = 0; i < _manager.CurrentPage.News.Length - 1; i++)
				{
					LocalizedString localizedString = _manager.CurrentPage.News[i];
					text = text + localizedString.GetLocalizedStringSafe() + "  /  ";
				}
				if (_manager.CurrentPage.News.Length > 1)
				{
					text += _manager.CurrentPage.News[^1].GetLocalizedStringSafe();
				}
				_scrollingText.Text = text;
			}
		}

		public void RepaintLocale()
		{
			Repaint();
		}
	}
}
