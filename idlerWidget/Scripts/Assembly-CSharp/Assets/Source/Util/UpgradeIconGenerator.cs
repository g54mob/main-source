using UnityEngine;

namespace Assets.Source.Util
{
	public class UpgradeIconGenerator
	{
		private static Color[] _spriteProductivity;

		private static Color[] _spriteSpeed;

		private static Color[] _spriteParallel;

		private static Color[] _spriteOther;

		private static Color[] _borderColor;

		static UpgradeIconGenerator()
		{
			_borderColor = new Color[13]
			{
				Color.gray,
				Color.white,
				Color.yellow,
				Color.green,
				Color.blue,
				_color("#9C00E5"),
				_color("#E28F00"),
				Color.magenta,
				_color("#E060DC"),
				_color("#DDB075"),
				_color("#2E2F49"),
				_color("#C96668"),
				Color.cyan
			};
			_spriteProductivity = _getSprite("UpgradeProductivity");
			_spriteSpeed = _getSprite("UpgradeSpeed");
			_spriteParallel = _getSprite("UpgradeParallel");
			_spriteOther = _getSprite("UpgradeOther");
		}

		private static Color _color(string hex)
		{
			ColorUtility.TryParseHtmlString(hex, out var color);
			return color;
		}

		private static Color[] _getSprite(string name)
		{
			return Resources.Load<Texture2D>(name).GetPixels();
		}

		public static Sprite CreateUpgradeIcon(int tier, string type, Sprite baseIcon)
		{
			int num = 16;
			int height = 16;
			Texture2D texture2D = new Texture2D(num, height, TextureFormat.ARGB32, mipChain: false);
			texture2D.filterMode = FilterMode.Point;
			Color[] pixels = texture2D.GetPixels();
			Rect rect = baseIcon.rect;
			Color[] pixels2 = baseIcon.texture.GetPixels(Mathf.RoundToInt(rect.x), Mathf.RoundToInt(rect.y), Mathf.RoundToInt(rect.width), Mathf.RoundToInt(rect.height));
			for (int i = 0; i < pixels2.Length; i++)
			{
				pixels[i] = pixels2[i];
			}
			Color color = _borderColor[tier - 1];
			for (int j = 0; j < pixels.Length; j++)
			{
				if (pixels[j] != color && pixels[j].a > 0.5f)
				{
					_colorPixel(pixels, j - 1, color);
					_colorPixel(pixels, j + 1, color);
					_colorPixel(pixels, j - num, color);
					_colorPixel(pixels, j + num, color);
				}
			}
			pixels2 = _getPixels(type);
			for (int k = 0; k < pixels2.Length; k++)
			{
				if (pixels2[k].a > 0.5f)
				{
					pixels[k] = pixels2[k];
				}
			}
			texture2D.SetPixels(pixels);
			texture2D.Apply();
			return Sprite.Create(texture2D, new Rect(0f, 0f, 16f, 16f), new Vector2(0.5f, 0.5f), 16f);
		}

		private static void _colorPixel(Color[] pixels, int idx, Color c)
		{
			if (pixels[idx].a < 0.5f)
			{
				pixels[idx] = c;
			}
		}

		private static Color[] _getPixels(string type)
		{
			return type switch
			{
				"Speed" => _spriteSpeed, 
				"Productivity" => _spriteProductivity, 
				"Parallel" => _spriteParallel, 
				_ => _spriteOther, 
			};
		}
	}
}
