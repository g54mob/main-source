using System;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Kitchen.Layouts.Modules
{
	[CreateNodeMenu("Source/New From Texture")]
	public class NewFromTexture : LayoutModule
	{
		[Serializable]
		public struct ColorRoom
		{
			public Color Color;

			public Room Room;
		}

		public Texture2D SourceTexture;

		public List<ColorRoom> Map;

		protected override LayoutBlueprint Generate()
		{
			LayoutBlueprint layoutBlueprint = LayoutBlueprint.New;
			ActOn(layoutBlueprint);
			return layoutBlueprint;
		}

		public override void ActOn(LayoutBlueprint blueprint)
		{
			blueprint.Features.Clear();
			blueprint.Tiles.Clear();
			Color[] pixels = SourceTexture.GetPixels();
			for (int i = 0; i < SourceTexture.width; i++)
			{
				for (int j = 0; j < SourceTexture.height; j++)
				{
					Color color = pixels[i + j * SourceTexture.width];
					bool flag = false;
					foreach (ColorRoom item in Map)
					{
						if (item.Color == color)
						{
							blueprint[i, j] = item.Room;
							flag = true;
						}
					}
					if (!flag)
					{
						Map.Add(new ColorRoom
						{
							Color = color,
							Room = Room.New
						});
					}
				}
			}
		}
	}
}
