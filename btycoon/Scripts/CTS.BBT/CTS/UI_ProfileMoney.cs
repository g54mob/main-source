using System.Globalization;
using TMPro;
using UnityEngine;

namespace CTS
{
	public class UI_ProfileMoney : UI_ProfileFeature
	{
		[SerializeField]
		private TMP_Text _textContainer;

		public override void Repaint()
		{
			if (_careerMetaData.HasProfile())
			{
				_textContainer.text = Mathf.RoundToInt(_careerMetaData.GetProfile().TotalMoney).ToString("C0", CultureInfo.CreateSpecificCulture("en-US"));
			}
		}
	}
}
