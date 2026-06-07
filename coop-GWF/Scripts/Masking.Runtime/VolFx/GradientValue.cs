using System;
using UnityEngine;

namespace VolFx
{
	[Serializable]
	public class GradientValue
	{
		public const int k_Width = 32;

		public Gradient _grad;

		public Color[] _pixels;

		internal bool _build;

		public static GradientValue White
		{
			get
			{
				Gradient gradient = new Gradient();
				gradient.SetKeys(new GradientColorKey[2]
				{
					new GradientColorKey(Color.white, 0f),
					new GradientColorKey(Color.white, 1f)
				}, new GradientAlphaKey[2]
				{
					new GradientAlphaKey(1f, 0f),
					new GradientAlphaKey(1f, 0f)
				});
				return new GradientValue(gradient);
			}
		}

		public void Build(GradientMode _mode)
		{
			_build = true;
			_grad.mode = _mode;
			_pixels = new Color[32];
			for (int i = 0; i < 32; i++)
			{
				_pixels[i] = _grad.Evaluate((float)i / 31f);
			}
		}

		internal void SetValue(GradientValue val)
		{
			if (!val._build)
			{
				val.Build(val._grad.mode);
			}
			_grad = val._grad;
			val._pixels.CopyTo(_pixels, 0);
		}

		public void Blend(GradientValue a, GradientValue b, float t)
		{
			_build = true;
			for (int i = 0; i < 32; i++)
			{
				_pixels[i] = Color.LerpUnclamped(a._pixels[i], b._pixels[i], t);
			}
			_grad.mode = ((t < 0.5f) ? a._grad.mode : b._grad.mode);
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

		public GradientValue(Gradient grad)
		{
			_grad = grad;
			_pixels = new Color[32];
			for (int i = 0; i < 32; i++)
			{
				_pixels[i] = grad.Evaluate((float)i / 31f);
			}
		}
	}
}
