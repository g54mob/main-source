using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.PlanetStudio.Brush.Interfaces;
using ModApi.Common.Extensions;
using ModApi.Common.SimpleTypes;
using Unity.Collections;
using UnityEngine;

namespace Assets.Scripts.PlanetStudio.Brush.Brushes
{
	public class SmoothingBrush : PlanetBrush, IBrushBlurStrength, IBrushHardness
	{
		private float[] _blurKernel;

		private float[][] _blurKernels;

		private float[] _blurTemp;

		private Dictionary<int, BrushStrokePixel>[] _brushStrokePixels;

		private float[][] _smoothedFaces = new float[6][];

		private float[][] _smoothedFacesData = new float[6][];

		public int BlurStrength { get; set; }

		public float Hardness { get; set; }

		public override string Name => "Smooth";

		protected int TextureSize => PlanetStudioScript.Instance.CelestialBodyDesignerScript.CelestialBodyViewer.BrushSphere.TextureSize;

		public SmoothingBrush()
		{
			_brushStrokePixels = (from x in Enumerable.Repeat(0, 6)
				select new Dictionary<int, BrushStrokePixel>()).ToArray();
			_smoothedFacesData = new float[6][];
			_smoothedFaces = new float[6][];
			InitializeBlurKernels();
		}

		public override void BeginBrush()
		{
			_brushStrokePixels.Foreach(delegate(Dictionary<int, BrushStrokePixel> x)
			{
				x.Clear();
			});
			int textureSize = TextureSize;
			int num = textureSize * textureSize;
			if (_blurTemp == null || _blurTemp.Length != num)
			{
				_blurTemp = new float[num];
			}
			for (int num2 = 0; num2 < 6; num2++)
			{
				_smoothedFaces[num2] = null;
				if (_smoothedFacesData.Length != num)
				{
					_smoothedFacesData[num2] = null;
				}
			}
			_blurKernel = _blurKernels[BlurStrength];
		}

		public override void UpdateBrush(BrushPixelData pixelData)
		{
			float num = 1f - Hardness;
			foreach (BrushPixelFaceData face in pixelData.Faces)
			{
				NativeArray<ColorRGB24> pixels = face.Pixels;
				float[] blurredFace = GetBlurredFace(face.FaceIndex, pixels);
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
					byte b = (byte)Mathf.Clamp((int)blurredFace[pixelDatum.Index], 0, 255);
					pixels[pixelDatum.Index] = ColorRGB24.Lerp(value.Color, new ColorRGB24(b, b, b), t);
				}
				face.Texture.Apply(updateMipmaps: true);
			}
		}

		private float[] BlurFace(int faceIndex, NativeArray<ColorRGB24> source)
		{
			int textureSize = TextureSize;
			int num = textureSize * textureSize;
			int num2 = textureSize - 1;
			float[] array = _smoothedFacesData[faceIndex];
			if (array == null)
			{
				array = new float[num];
				_smoothedFacesData[faceIndex] = array;
			}
			int num3 = (_blurKernel.Length - 1) / 2;
			for (int i = 0; i < num; i++)
			{
				float num4 = 0f;
				int num5 = i % textureSize;
				for (int j = -num3; j <= num3; j++)
				{
					int num6 = num5 + j;
					num6 = ((num6 >= 0) ? ((num6 < textureSize) ? (i + j) : (i - num5 + num2 - num6 % num2)) : (i - num5 - num6));
					num4 += (float)(int)source[num6].r * _blurKernel[j + num3];
				}
				_blurTemp[i] = num4;
			}
			for (int k = 0; k < num; k++)
			{
				float num7 = 0f;
				int num8 = k / textureSize;
				for (int l = -num3; l <= num3; l++)
				{
					int num9 = num8 + l;
					num9 = ((num9 >= 0) ? ((num9 < textureSize) ? (k + l * textureSize) : (k % textureSize + textureSize * (num2 + (num2 - num9)))) : (k % textureSize - textureSize * num9));
					num7 += _blurTemp[num9] * _blurKernel[l + num3];
				}
				array[k] = num7;
			}
			return array;
		}

		private float[] GetBlurredFace(int faceIndex, NativeArray<ColorRGB24> source)
		{
			float[] array = _smoothedFaces[faceIndex];
			if (array == null)
			{
				array = (_smoothedFaces[faceIndex] = BlurFace(faceIndex, source));
			}
			return array;
		}

		private void InitializeBlurKernels()
		{
			_blurKernels = new float[6][]
			{
				new float[3] { 1f, 2f, 1f }.Select((float x) => x / 4f).ToArray(),
				new float[5] { 1f, 4f, 6f, 4f, 1f }.Select((float x) => x / 16f).ToArray(),
				new float[7] { 1f, 6f, 15f, 20f, 15f, 6f, 1f }.Select((float x) => x / 64f).ToArray(),
				new float[9] { 1f, 8f, 28f, 56f, 70f, 56f, 28f, 8f, 1f }.Select((float x) => x / 256f).ToArray(),
				new float[11]
				{
					1f, 10f, 45f, 120f, 210f, 252f, 210f, 120f, 45f, 10f,
					1f
				}.Select((float x) => x / 1024f).ToArray(),
				new float[13]
				{
					1f, 12f, 66f, 220f, 495f, 792f, 924f, 792f, 495f, 220f,
					66f, 12f, 1f
				}.Select((float x) => x / 4096f).ToArray()
			};
		}
	}
}
