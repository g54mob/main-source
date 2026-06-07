using TMPro;
using UnityEngine;

namespace CTS
{
	public class UI_ProfileSaveTime : UI_ProfileFeature
	{
		[SerializeField]
		private TMP_Text _textContainer;

		public override void Repaint()
		{
			if (_careerMetaData.HasProfile())
			{
				_textContainer.text = _careerMetaData.GetProfile().SaveTime.ToShortDateString();
			}
		}
	}
}
