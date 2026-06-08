using System;
using System.Collections.Generic;
using Kitchen.Layouts.Features;
using UnityEngine;
using XNode;

namespace Kitchen.Layouts.Modules
{
	[CreateNodeMenu("Source/Features From Texture")]
	public class FeaturesFromTexture : LayoutModule
	{
		[Serializable]
		public struct ColorFeature
		{
			public Color Color;

			public FeatureType Feature;
		}

		public Texture2D SourceTexture;

		public List<ColorFeature> Map;

		public override void ActOn(LayoutBlueprint blueprint)
		{
			List<(int, int)> list = new List<(int, int)>
			{
				(1, 0),
				(0, 1)
			};
			Color[] pixels = SourceTexture.GetPixels();
			for (int i = 0; i < SourceTexture.width; i++)
			{
				for (int j = 0; j < SourceTexture.height; j++)
				{
					Color color = pixels[i + j * SourceTexture.width];
					if (!(color.a > 0f))
					{
						continue;
					}
					foreach (var item in list)
					{
						if (i + item.Item1 < 0 || i + item.Item1 >= SourceTexture.width || j + item.Item2 < 0 || j + item.Item2 >= SourceTexture.height)
						{
							continue;
						}
						Color color2 = pixels[i + item.Item1 + (j + item.Item2) * SourceTexture.width];
						if (color != color2 || blueprint[i, j].ID == blueprint[i + item.Item1, j + item.Item2].ID)
						{
							continue;
						}
						bool flag = false;
						foreach (ColorFeature item2 in Map)
						{
							if (item2.Color == color)
							{
								blueprint.Features.Add(new Feature(new LayoutPosition(i, j), new LayoutPosition(i + item.Item1, j + item.Item2), item2.Feature));
								flag = true;
							}
						}
						if (!flag)
						{
							Map.Add(new ColorFeature
							{
								Color = color,
								Feature = FeatureType.Generic
							});
						}
					}
				}
			}
		}
	}
}
