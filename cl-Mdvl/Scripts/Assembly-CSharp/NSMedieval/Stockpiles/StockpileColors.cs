using System;
using System.Collections.Generic;
using UnityEngine;

namespace NSMedieval.Stockpiles
{
	[Serializable]
	public class StockpileColors
	{
		[SerializeField]
		private List<string> colors = new List<string>();

		private int counter = -1;

		public Color GetNextColor()
		{
			if (counter >= colors.Count)
			{
				counter = -1;
			}
			counter++;
			return GetColor(counter);
		}

		public Color GetRandomColor()
		{
			return GetColor(GetRandomHexColor());
		}

		public Color GetColor(string colorID)
		{
			ColorUtility.TryParseHtmlString(colorID, out var color);
			return color;
		}

		public Color GetColor(int index)
		{
			if (index < 0 || index >= colors.Count)
			{
				return new Color(0f, 0f, 0f);
			}
			ColorUtility.TryParseHtmlString(colors[index], out var color);
			return color;
		}

		private string GetRandomHexColor()
		{
			int index = new System.Random().Next(colors.Count);
			return colors[index];
		}
	}
}
