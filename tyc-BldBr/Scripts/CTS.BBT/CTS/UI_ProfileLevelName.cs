using CTS.Core;
using TMPro;
using UnityEngine;

namespace CTS
{
	public class UI_ProfileLevelName : UI_ProfileFeature
	{
		[SerializeField]
		private TMP_Text _textContainer;

		[SerializeField]
		private CanvasGroup _canvasGroup;

		public override void Repaint()
		{
			if (_careerMetaData.HasProfile())
			{
				MapInfoSO lastLevelPlayed = _careerMetaData.GetLastLevelPlayed();
				if ((object)lastLevelPlayed == null)
				{
					_canvasGroup.alpha = 0f;
					return;
				}
				_canvasGroup.alpha = 1f;
				_textContainer.text = lastLevelPlayed.LevelNameLocalizationString.GetLocalizedStringSafe();
			}
		}
	}
}
