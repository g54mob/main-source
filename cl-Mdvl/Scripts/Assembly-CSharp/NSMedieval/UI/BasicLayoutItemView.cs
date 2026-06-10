using System.Collections.Generic;
using NSMedieval.Enums;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class BasicLayoutItemView : LayoutGroupItemView
	{
		private const int TextIndex = 0;

		private const int ImageIndex = 1;

		private const int LeftArrowIndex = 3;

		private const int RightArrowIndex = 4;

		private Image icon;

		public Image Icon => icon = ((icon == null) ? base.GroupItems[1].GetComponent<Image>() : icon);

		public void SetDataText(string text)
		{
			SetText(0, text);
		}

		public void SetDataText(string text, string id)
		{
			SetText(0, text, id);
		}

		public void SetDataText(string text, List<string> tooltipLines)
		{
			SetText(0, text, string.Empty);
			SetTooltipLines(tooltipLines);
		}

		public void SetImageData(string path, string imageKey = "")
		{
			if (!(path == string.Empty) || !(imageKey == string.Empty))
			{
				SetImage(1, path);
			}
		}

		public void SetBasicData(string text, string textId, string path, string imageKey)
		{
			SetDataText(text, textId);
			SetImageData(path, imageKey);
		}

		private void SetArrows(StatTrend trend = StatTrend.None)
		{
			switch (trend)
			{
			case StatTrend.None:
				base.GroupItems[3].SetActive(value: false);
				base.GroupItems[4].SetActive(value: false);
				break;
			case StatTrend.Up:
				base.GroupItems[3].SetActive(value: false);
				base.GroupItems[4].SetActive(value: true);
				break;
			case StatTrend.Down:
				base.GroupItems[3].SetActive(value: true);
				base.GroupItems[4].SetActive(value: false);
				break;
			}
		}
	}
}
