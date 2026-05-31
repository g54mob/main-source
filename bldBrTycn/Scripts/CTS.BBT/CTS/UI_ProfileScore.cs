using TMPro;
using UnityEngine;

namespace CTS
{
	public class UI_ProfileScore : UI_ProfileFeature
	{
		[SerializeField]
		private TMP_Text _scoreText;

		public override void Repaint()
		{
			if (_careerMetaData.HasProfile())
			{
				_scoreText.text = Mathf.RoundToInt((float)_careerMetaData.GetProfile().TotalScore / 2f).ToString();
			}
		}
	}
}
