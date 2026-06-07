using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.PlanetStudio.Brush.Interfaces;
using ModApi.Common.Extensions;
using ModApi.Common.SimpleTypes;
using Unity.Collections;
using UnityEngine;

namespace Assets.Scripts.PlanetStudio.Brush.Brushes
{
	public class AdditiveBrush : PlanetBrush, IBrushStrength, IBrushHardness
	{
		private Dictionary<int, BrushStrokePixel>[] _brushStrokePixels;

		private float _multiplier;

		public float Hardness { get; set; }

		public override string Name { get; }

		public float Strength { get; set; }

		public AdditiveBrush(float multiplier)
		{
			_multiplier = multiplier;
			Name = ((multiplier < 0f) ? "Subtractive" : "Additive");
			_brushStrokePixels = (from x in Enumerable.Repeat(0, 6)
				select new Dictionary<int, BrushStrokePixel>()).ToArray();
		}

		public override void BeginBrush()
		{
			_brushStrokePixels.Foreach(delegate(Dictionary<int, BrushStrokePixel> x)
			{
				x.Clear();
			});
		}

		public override void UpdateBrush(BrushPixelData pixelData)
		{
			float num = Strength * 100f * _multiplier;
			float num2 = 1f - Hardness;
			foreach (BrushPixelFaceData face in pixelData.Faces)
			{
				NativeArray<ColorRGB24> pixels = face.Pixels;
				foreach (BrushPixel pixelDatum in face.PixelData)
				{
					if (_brushStrokePixels[face.FaceIndex].TryGetValue(pixelDatum.Index, out var value))
					{
						if (value.Strength < pixelDatum.Strength)
						{
							value.Strength = pixelDatum.Strength;
						}
					}
					else
					{
						value = new BrushStrokePixel(pixelDatum.Strength, pixels[pixelDatum.Index]);
						_brushStrokePixels[face.FaceIndex].Add(pixelDatum.Index, value);
					}
					int num3 = (int)(((value.Strength >= num2) ? 1f : (value.Strength / num2)) * num);
					ColorRGB24 color = value.Color;
					pixels[pixelDatum.Index] = new ColorRGB24((byte)Mathf.Clamp(color.r + num3, 0, 255), (byte)Mathf.Clamp(color.g + num3, 0, 255), (byte)Mathf.Clamp(color.b + num3, 0, 255));
				}
				face.Texture.Apply(updateMipmaps: true);
			}
		}
	}
}
