using System;
using System.Collections.Generic;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class TooltipPieChart : Tooltip
	{
		[Serializable]
		public class LegendItem
		{
			public GameObject MainObject;

			public Image ColourIcon;

			public TMP_Text Label;
		}

		[SerializeField]
		private List<LegendItem> _legendItems;

		public void Setup(List<PieChart.SegmentInternal> segmentData)
		{
			for (int i = 0; i < segmentData.Count; i++)
			{
				if (i >= _legendItems.Count)
				{
					return;
				}
				if (!segmentData[i].IsShowing)
				{
					GameObjectUtils.SetActive(_legendItems[i].MainObject, isActive: false);
					continue;
				}
				_legendItems[i].ColourIcon.color = segmentData[i].SegmentImage.color;
				_legendItems[i].Label.text = segmentData[i].Description;
				GameObjectUtils.SetActive(_legendItems[i].MainObject, isActive: true);
			}
			for (int j = segmentData.Count; j < _legendItems.Count; j++)
			{
				GameObjectUtils.SetActive(_legendItems[j].MainObject, isActive: false);
			}
		}
	}
}
