using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace ScriptHelpers
{
	public static class TextureHelper
	{
		public static bool LoadImageIntoTexture(this Texture2D tex, string path)
		{
			if (!File.Exists(path))
			{
				return false;
			}
			byte[] data = File.ReadAllBytes(path);
			tex.LoadImage(data);
			return true;
		}

		public static void FitTexture(this RawImage img, Texture2D tex, FitType fit = FitType.None)
		{
			img.texture = tex;
			Rect rect = img.GetComponent<RectTransform>().rect;
			float num = rect.width / rect.height;
			if (fit == FitType.None)
			{
				return;
			}
			Vector2 vector = new Vector2(tex.width, tex.height);
			float num2 = vector.x / vector.y;
			if (fit == FitType.Fill)
			{
				if (num < num2)
				{
					float num3 = num / num2;
					img.uvRect = new Rect((1f - num3) / 2f, 0f, num3, 1f);
				}
				else
				{
					float num4 = num2 / num;
					img.uvRect = new Rect(0f, (1f - num4) / 2f, 1f, num4);
				}
			}
		}
	}
}
