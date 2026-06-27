using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Restory.UI.Presenters.DevicePaintingTool
{
	public class GUI_PaintingMiniPalette : UIBehaviour
	{
		[SerializeField]
		private Image[] colors = new Image[0];

		public void SetColors(IReadOnlyList<Color> colorsToSet)
		{
			for (int i = 0; i < colors.Length; i++)
			{
				if (i < colorsToSet.Count)
				{
					colors[i].color = colorsToSet[i];
				}
				else
				{
					colors[i].color = Color.clear;
				}
			}
		}
	}
}
