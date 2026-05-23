using Data.Credits;
using TMPro;
using UnityEngine;

namespace Presentation.UI.Credits
{
	public class CreditsMultiColumnSegment : CreditsBaseSegment
	{
		[SerializeField]
		private TextMeshProUGUI[] _columnTexts;

		private string _columnsLoca;

		protected override void UpdateTexts()
		{
		}

		private void SetColumns()
		{
			int num = _columnTexts.Length;
			string[] array = LocalizationUtility.GetLocalizedText(_columnsLoca).Split('\n');
			int num2 = array.Length;
			for (int i = 0; i < num; i++)
			{
				int num3 = num2 * i / num;
				int num4 = num2 * (i + 1) / num;
				_columnTexts[i].text = string.Join("\n", array, num3, num4 - num3);
			}
		}

		public override void SetContent(CreditsSegmentData segmentData)
		{
			_columnsLoca = segmentData.TextLocaKey;
			SetColumns();
		}
	}
}
