using System;
using UnityEngine;

namespace VolFx
{
	[Serializable]
	public class CurveValue
	{
		public const int k_Width = 32;

		public AnimationCurve _curve;

		public Color[] _pixels;

		private bool _build;

		internal void SetValue(CurveValue val)
		{
			if (!val._build)
			{
				val.Build();
			}
			_curve = val._curve;
			val._pixels.CopyTo(_pixels, 0);
		}

		public void Blend(CurveValue a, CurveValue b, float t)
		{
			for (int i = 0; i < 32; i++)
			{
				_pixels[i] = Color.LerpUnclamped(a._pixels[i], b._pixels[i], t);
			}
		}

		public CurveValue(AnimationCurve curve)
		{
			_curve = curve;
			_pixels = new Color[32];
			for (int i = 0; i < 32; i++)
			{
				float num = _curve.Evaluate((float)i / 31f);
				_pixels[i] = new Color(num, num, num, num);
			}
		}

		public Texture2D GetTexture(ref Texture2D tex)
		{
			if (tex == null)
			{
				tex = new Texture2D(32, 1, TextureFormat.RGBA32, mipChain: false);
				tex.wrapMode = TextureWrapMode.Clamp;
				tex.filterMode = FilterMode.Bilinear;
			}
			tex.SetPixels(_pixels);
			tex.Apply();
			return tex;
		}

		public void Build()
		{
			if (!_build)
			{
				_build = true;
				_pixels = new Color[32];
				for (int i = 0; i < 32; i++)
				{
					float num = _curve.Evaluate((float)i / 31f);
					_pixels[i] = new Color(num, num, num, num);
				}
			}
		}
	}
}
