using System.Collections.Generic;
using UnityEngine;

namespace Kitchen.Modules
{
	[CreateAssetMenu(fileName = "GridMenuColourConfig", menuName = "Kitchen/GridMenu/Colour")]
	public class GridMenuColourConfig : GridMenuConfig
	{
		public List<Color> Colours;

		public override GridMenu Instantiate(Transform container, int player, bool has_back)
		{
			return new ColourGridMenu(Colours, container, player, has_back);
		}

		private void PopulateWithWheel(Color base_colour, int count = 32)
		{
			Colours.Clear();
			Color.RGBToHSV(base_colour, out var _, out var S, out var V);
			for (int i = 0; i < count; i++)
			{
				Colours.Add(Color.HSVToRGB((float)i / (float)count, S, V));
			}
		}

		private void PopulateWithManyWheels(List<Color> base_colours, int count = 7)
		{
			Colours.Clear();
			foreach (Color base_colour in base_colours)
			{
				Color.RGBToHSV(base_colour, out var _, out var S, out var V);
				for (int i = 0; i < count; i++)
				{
					Colours.Add(Color.HSVToRGB((float)i / (float)count, S, V));
				}
				Colours.Add(Color.black);
			}
		}
	}
}
