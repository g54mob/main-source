using CTS.Core;
using TMPro;
using UnityEngine;

namespace CTS
{
	public class CutsceneFeature_CharacterName : CutsceneFeature, ILocaleRepaint
	{
		[SerializeField]
		private TMP_Text _characterName;

		protected override void OnRepaint()
		{
			if ((bool)_manager.CurrentPage && (bool)_manager.CurrentPage.MainCharacter)
			{
				_characterName.SetText(_manager.CurrentPage.MainCharacter.CharacterName.GetLocalizedStringSafe());
			}
			else
			{
				_characterName.SetText("No Current Page.");
			}
		}

		public void RepaintLocale()
		{
			Repaint();
		}
	}
}
