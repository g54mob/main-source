using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class CutsceneFeature_CharacterColor : CutsceneFeature
	{
		[SerializeField]
		private Image _characterColor;

		protected override void OnRepaint()
		{
			if ((bool)_manager.CurrentPage && (bool)_manager.CurrentPage.MainCharacter)
			{
				_characterColor.color = _manager.CurrentPage.MainCharacter.Color;
			}
			else
			{
				_characterColor.color = Color.white;
			}
		}
	}
}
