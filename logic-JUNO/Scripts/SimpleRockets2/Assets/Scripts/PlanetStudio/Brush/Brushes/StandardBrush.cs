using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.PlanetStudio.Brush.Interfaces;
using ModApi.Common.Extensions;
using ModApi.Common.SimpleTypes;
using Unity.Collections;

namespace Assets.Scripts.PlanetStudio.Brush.Brushes
{
	public class StandardBrush : PlanetBrush, IBrushValue, IBrushHardness
	{
		private Dictionary<int, BrushStrokePixel>[] _brushStrokePixels;

		public float Hardness { get; set; }

		public override string Name { get; }

		public byte Value { get; set; }

		public StandardBrush()
		{
			Name = "Standard";
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
			float num = 1f - Hardness;
			ColorRGB24 b = new ColorRGB24(Value, Value, Value);
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
					float t = ((value.Strength >= num) ? 1f : (value.Strength / num));
					pixels[pixelDatum.Index] = ColorRGB24.Lerp(value.Color, b, t);
				}
				face.Texture.Apply(updateMipmaps: true);
			}
		}
	}
}
