using CTS.Core;
using TMPro;
using UnityEngine;

namespace CTS
{
	public class CutsceneFeature_Headline : CutsceneFeature, ILocaleRepaint
	{
		[SerializeField]
		private TMP_Text _textContainer;

		protected override void OnRepaint()
		{
			if ((bool)_manager.CurrentPage)
			{
				_textContainer.SetText(_manager.CurrentPage.Headline.GetLocalizedStringSafe());
			}
		}

		public void RepaintLocale()
		{
			Repaint();
		}
	}
}
