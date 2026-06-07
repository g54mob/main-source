using UnityEngine;

public class ImageResizer
{
	public Texture2D ResizeTexture32_KeepRatio(Texture2D texOrigin, int width, int height)
	{
		int num = width;
		int num2 = height;
		float num3 = (float)texOrigin.width / (float)texOrigin.height;
		float num4 = (float)width / (float)height;
		if (num3 > num4)
		{
			num = width;
			num2 = (int)((float)num / num3);
		}
		else if (num3 < num4)
		{
			num2 = height;
			num = (int)((float)num2 * num3);
		}
		Texture2D texture2D = ResizeTexture32(texOrigin, num, num2);
		Texture2D texture2D2 = new Texture2D(width, height);
		texture2D2.SetPixels32(new Color32[width * height]);
		texture2D2.SetPixels32((int)((float)(width - num) / 2f), (int)((float)(height - num2) / 2f), num, num2, texture2D.GetPixels32());
		texture2D2.Apply();
		Object.Destroy(texture2D);
		return texture2D2;
	}

	public Texture2D ResizeTexture32(Texture2D texOrigin, int width, int height)
	{
		Color32[] array = new Color32[width * height];
		Color32[] pixels = texOrigin.GetPixels32();
		int width2 = texOrigin.width;
		int height2 = texOrigin.height;
		float num = 1f / ((float)width / (float)(width2 - 1));
		float num2 = 1f / ((float)height / (float)(height2 - 1));
		for (int i = 0; i < height; i++)
		{
			int num3 = (int)Mathf.Floor((float)i * num2);
			float t = (float)i * num2 - (float)num3;
			int num4 = num3 * width2;
			int num5 = (num3 + 1) * width2;
			int num6 = i * width;
			for (int j = 0; j < width; j++)
			{
				int num7 = (int)Mathf.Floor((float)j * num);
				float t2 = (float)j * num - (float)num7;
				array[num6 + j] = Color32.Lerp(Color32.Lerp(pixels[num4 + num7], pixels[num4 + num7 + 1], t2), Color32.Lerp(pixels[num5 + num7], pixels[num5 + num7 + 1], t2), t);
			}
		}
		Texture2D texture2D = new Texture2D(width, height);
		texture2D.SetPixels32(array);
		texture2D.Apply();
		Object.Destroy(texOrigin);
		return texture2D;
	}

	public Texture2D ResizeTexture_KeepRatio(Texture2D texOrigin, int width, int height)
	{
		int num = width;
		int num2 = height;
		float num3 = (float)texOrigin.width / (float)texOrigin.height;
		float num4 = (float)width / (float)height;
		if (num3 > num4)
		{
			num = width;
			num2 = (int)((float)num / num3);
		}
		else if (num3 < num4)
		{
			num2 = height;
			num = (int)((float)num2 * num3);
		}
		Texture2D texture2D = ResizeTexture(texOrigin, num, num2);
		Texture2D texture2D2 = new Texture2D(width, height);
		texture2D2.SetPixels((int)((float)(width - num) / 2f), (int)((float)(height - num2) / 2f), num, num2, texture2D.GetPixels());
		texture2D2.Apply();
		Object.Destroy(texture2D);
		return texture2D2;
	}

	public Texture2D ResizeTexture(Texture2D texOrigin, int width, int height)
	{
		Color[] array = new Color[width * height];
		Color[] pixels = texOrigin.GetPixels();
		int width2 = texOrigin.width;
		int height2 = texOrigin.height;
		float num = 1f / ((float)width / (float)(width2 - 1));
		float num2 = 1f / ((float)height / (float)(height2 - 1));
		for (int i = 0; i < height; i++)
		{
			int num3 = (int)Mathf.Floor((float)i * num2);
			float t = (float)i * num2 - (float)num3;
			int num4 = num3 * width2;
			int num5 = (num3 + 1) * width2;
			int num6 = i * width;
			for (int j = 0; j < width; j++)
			{
				int num7 = (int)Mathf.Floor((float)j * num);
				float t2 = (float)j * num - (float)num7;
				array[num6 + j] = Color.Lerp(Color.Lerp(pixels[num4 + num7], pixels[num4 + num7 + 1], t2), Color.Lerp(pixels[num5 + num7], pixels[num5 + num7 + 1], t2), t);
			}
		}
		Texture2D texture2D = new Texture2D(width, height);
		texture2D.SetPixels(array);
		texture2D.Apply();
		Object.Destroy(texOrigin);
		return texture2D;
	}
}
