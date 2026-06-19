using System;
using System.IO;
using UnityEngine;

namespace Michsky.DreamOS
{
	public class DreamOSInternalTools : MonoBehaviour
	{
		public static float GetAnimatorClipLength(Animator _animator, string _clipName)
		{
			float result = -1f;
			RuntimeAnimatorController runtimeAnimatorController = _animator.runtimeAnimatorController;
			for (int i = 0; i < runtimeAnimatorController.animationClips.Length; i++)
			{
				if (runtimeAnimatorController.animationClips[i].name == _clipName)
				{
					result = runtimeAnimatorController.animationClips[i].length;
					break;
				}
			}
			return result;
		}

		public static Color GetSpriteAccentColor(Sprite sprite)
		{
			Texture2D readableTexture = GetReadableTexture(sprite.texture);
			Rect textureRect = sprite.textureRect;
			Color[] pixels = readableTexture.GetPixels((int)textureRect.x, (int)textureRect.y, (int)textureRect.width, (int)textureRect.height);
			Color black = Color.black;
			int num = 0;
			for (int i = 0; i < pixels.Length; i++)
			{
				if (pixels[i].a > 0f)
				{
					black += pixels[i];
					num++;
				}
			}
			return black / num;
		}

		public static Color GetAccentMatchColor(Color color)
		{
			if (0.299f * color.r + 0.587f * color.g + 0.114f * color.b > 0.5f)
			{
				return new Color(5f / 51f, 0.1372549f, 0.1764706f);
			}
			return Color.white;
		}

		public static Texture2D GetReadableTexture(Texture2D source)
		{
			RenderTexture temporary = RenderTexture.GetTemporary(source.width, source.height, 0, RenderTextureFormat.Default, RenderTextureReadWrite.sRGB);
			Graphics.Blit(source, temporary);
			RenderTexture.active = temporary;
			Texture2D texture2D = new Texture2D(source.width, source.height);
			texture2D.ReadPixels(new Rect(0f, 0f, temporary.width, temporary.height), 0, 0);
			texture2D.Apply();
			RenderTexture.active = null;
			RenderTexture.ReleaseTemporary(temporary);
			return texture2D;
		}

		public static Texture2D LoadTexture(string filePath)
		{
			if (File.Exists(filePath))
			{
				byte[] data = File.ReadAllBytes(filePath);
				Texture2D texture2D = new Texture2D(2, 2);
				if (texture2D.LoadImage(data))
				{
					return texture2D;
				}
			}
			return null;
		}

		public static int GetRandomUniqueValue(int currentValue, int minValue, int maxValue)
		{
			int num = UnityEngine.Random.Range(minValue, maxValue);
			while (currentValue == num)
			{
				num = UnityEngine.Random.Range(minValue, maxValue);
			}
			return num;
		}

		public static string GenerateUniqueGuid()
		{
			return Guid.NewGuid().ToString();
		}
	}
}
