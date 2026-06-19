using System.Collections.Generic;
using UnityEngine;

public static class TextureGeneration
{
	private static int baseTextureDimensions = 300;

	private static int baseTextureMod = 1;

	private static float stripeFlipChance = 5f;

	private static float segmentSkipChance = 5f;

	private static float stripeChance = 95f;

	public static Texture2D GenerateTexture(DogLooks lookRef, float defaultColorMax, float textureWidth, float textureHeight, PatternType patternType, int numImages, int maxImages, Color textureColor, List<PatternInfoField> patternInfo)
	{
		textureWidth *= (float)(baseTextureDimensions * baseTextureMod);
		textureHeight *= (float)(baseTextureDimensions * baseTextureMod);
		int num = (int)textureWidth;
		int num2 = (int)textureHeight;
		Texture2D texture2D = new Texture2D(num, num2, TextureFormat.ARGB32, mipChain: false);
		texture2D.filterMode = FilterMode.Point;
		texture2D.wrapMode = TextureWrapMode.Clamp;
		Color32 color = new Color32(0, 0, 0, 0);
		Color32[] finalColors = new Color32[num * num2];
		for (int i = 0; i < num * num2; i++)
		{
			finalColors[i] = color;
		}
		switch (patternType)
		{
		case PatternType.SPLOTCHES:
			AddSplotchesToTexture(lookRef, num, num2, textureColor, ref finalColors, patternInfo, numImages);
			break;
		case PatternType.STRIPES:
			AddSegmentedStripesToTexture(lookRef, num, num2, textureColor, ref finalColors, patternInfo);
			break;
		case PatternType.REPEATING:
			AddRepeatingPatternToTexture(lookRef, num, num2, textureColor, ref finalColors, patternInfo);
			break;
		default:
			Debug.LogError("No valid patternType given.");
			break;
		}
		texture2D.SetPixels32(finalColors);
		texture2D.Apply();
		return texture2D;
	}

	private static void AddSplotchesToTexture(DogLooks lookRef, int textureWidth, int textureHeight, Color textureColor, ref Color32[] finalColors, List<PatternInfoField> splotchInfo, int numImages, float startX = 0f, float endX = 1f, float startY = 0f, float endY = 1f)
	{
		for (int i = 0; i < numImages; i++)
		{
			AddSplotchToTexture(lookRef, textureWidth, textureHeight, textureColor, ref finalColors, splotchInfo[i].splotchInfo, startX, endX, startY, endY);
		}
	}

	private static void AddSplotchToTexture(DogLooks lookRef, int textureWidth, int textureHeight, Color textureColor, ref Color32[] finalColors, SplotchInfoField splotchInfo, float startX, float endX, float startY, float endY)
	{
		int num = (int)((float)textureWidth * (endX - startX));
		int num2 = (int)((float)textureHeight * (endY - startY));
		bool flipX = ((splotchInfo.a != 0) ? true : false);
		bool flipY = ((splotchInfo.b != 0) ? true : false);
		int splotchWidthFromFloat = lookRef.GetSplotchWidthFromFloat(splotchInfo.c);
		List<Texture2D> list = ((splotchWidthFromFloat <= 10) ? lookRef.textureLoaderRef.spots_10x10 : ((splotchWidthFromFloat <= 64) ? lookRef.textureLoaderRef.spots_64x64 : ((splotchWidthFromFloat > 128) ? lookRef.textureLoaderRef.spots_256x256 : lookRef.textureLoaderRef.spots_128x128)));
		float num3 = splotchInfo.d / 100f;
		int num4 = (int)((float)(list.Count - 1) * num3);
		Texture2D texture2D = list[num4];
		if (texture2D.width > num / 2)
		{
			texture2D = lookRef.textureLoaderRef.spots_64x64[Mathf.Min(num4, lookRef.textureLoaderRef.spots_64x64.Count - 1)];
			if (texture2D.width > num / 2)
			{
				texture2D = lookRef.textureLoaderRef.spots_10x10[Mathf.Min(num4, lookRef.textureLoaderRef.spots_10x10.Count - 1)];
			}
		}
		int num5 = texture2D.width / 2;
		Color[] pixels = texture2D.GetPixels();
		int num6 = (int)((float)(num / 2 - texture2D.width) * splotchInfo.e) + texture2D.width;
		int num7 = (int)((float)num2 * splotchInfo.f) + num5 / 2;
		num6 += (int)((float)textureWidth / 2f * startX);
		num7 += (int)((float)textureHeight * startY);
		WriteImageToTexture(textureColor, textureWidth, textureHeight, ref finalColors, num5, num5, num6, num7, pixels, flipX, flipY);
	}

	private static void AddSegmentedStripesToTexture(DogLooks lookRef, int textureWidth, int textureHeight, Color textureColor, ref Color32[] finalColors, List<PatternInfoField> patternInfo, float startX = 0f, float endX = 1f, float startY = 0f, float endY = 1f)
	{
		int num = (int)((float)textureWidth * (endX - startX));
		int num2 = (int)((float)textureHeight * (endY - startY));
		int width = lookRef.textureLoaderRef.stripeCaps_TopLeft[0].width;
		int height = lookRef.textureLoaderRef.stripeCaps_TopLeft[0].height;
		int num3 = (int)(patternInfo[0].stripeInfo.c / 100f * ((float)num / 2f - (float)width * 1.5f));
		int num4 = num - num3;
		int numSegments = num2 / height;
		int num5 = num4 / 2;
		int num6 = num5 / width - 1;
		num3 += (num4 / 2 - num6 * width) / 2;
		int num7 = 1;
		for (int i = width + num3 / 2; i < num5; i += width - 1)
		{
			if (patternInfo[num7].stripeInfo.c <= stripeChance)
			{
				BuildAndAddSegmentedStripe(lookRef, numSegments, textureWidth, textureHeight, textureColor, i, ref finalColors, patternInfo, num7);
			}
			num7++;
			if (num7 >= patternInfo.Count)
			{
				break;
			}
		}
	}

	private static void BuildAndAddSegmentedStripe(DogLooks lookRef, int numSegments, int textureWidth, int textureHeight, Color textureColor, int xOffset, ref Color32[] finalColors, List<PatternInfoField> patternInfo, int patternIndex)
	{
		List<Direction> list = new List<Direction>();
		List<Texture2D> stripeTextures = new List<Texture2D>();
		StripeInfoField stripeInfo = patternInfo[patternIndex].stripeInfo;
		bool flipStripe = stripeInfo.d <= stripeFlipChance;
		Direction directionForFloat = lookRef.GetDirectionForFloat(stripeInfo.e);
		list.Add(directionForFloat);
		AddStripeCap(lookRef, directionForFloat, ref stripeTextures, (int)stripeInfo.f);
		int num;
		Direction lastDir;
		for (int i = 1; i < numSegments - 1; i++)
		{
			num = patternIndex;
			if (patternInfo.Count - 1 - patternIndex > 0)
			{
				num = (num + patternIndex) % patternInfo.Count;
				if (num != patternInfo.Count - 1)
				{
					num += i % (patternInfo.Count - 1 - num);
				}
			}
			stripeInfo = patternInfo[num].stripeInfo;
			if (!(stripeInfo.d <= segmentSkipChance))
			{
				directionForFloat = lookRef.GetDirectionForFloat(stripeInfo.e);
				lastDir = list[list.Count - 1];
				list.Add(directionForFloat);
				AddStripeMid(lookRef, lastDir, directionForFloat, ref stripeTextures, (int)stripeInfo.f);
			}
		}
		num = patternIndex;
		if (patternInfo.Count - 1 - patternIndex > 0)
		{
			num += num % (patternInfo.Count - 1 - patternIndex);
		}
		stripeInfo = patternInfo[num].stripeInfo;
		lastDir = list[list.Count - 1];
		list.Add(lastDir);
		AddStripeCap(lookRef, lastDir, ref stripeTextures, (int)stripeInfo.f);
		AddSegmentedStripeToTexture(textureColor, textureWidth, textureHeight, ref finalColors, list, stripeTextures, xOffset, flipStripe);
	}

	private static void AddStripeCap(DogLooks lookRef, Direction d, ref List<Texture2D> stripeTextures, int index)
	{
		switch (d)
		{
		case Direction.LEFT:
		case Direction.RIGHT:
			FillStripeLists(ref stripeTextures, lookRef.textureLoaderRef.stripeCaps_TopLeft, index);
			break;
		case Direction.MIDDLE:
			FillStripeLists(ref stripeTextures, lookRef.textureLoaderRef.stripeCaps_TopMid, index);
			break;
		}
	}

	private static void AddStripeMid(DogLooks lookRef, Direction lastDir, Direction newDir, ref List<Texture2D> stripeTextures, int index)
	{
		switch (lastDir)
		{
		case Direction.MIDDLE:
			if (newDir == Direction.LEFT || newDir == Direction.RIGHT)
			{
				FillStripeLists(ref stripeTextures, lookRef.textureLoaderRef.stripeSegs_LeftMid, index);
			}
			else
			{
				FillStripeLists(ref stripeTextures, lookRef.textureLoaderRef.stripeSegs_MidMid, index);
			}
			break;
		case Direction.LEFT:
			switch (newDir)
			{
			case Direction.LEFT:
				FillStripeLists(ref stripeTextures, lookRef.textureLoaderRef.stripeSegs_LeftLeft, index);
				break;
			case Direction.MIDDLE:
				FillStripeLists(ref stripeTextures, lookRef.textureLoaderRef.stripeSegs_LeftMid, index);
				break;
			default:
				FillStripeLists(ref stripeTextures, lookRef.textureLoaderRef.stripeSegs_LeftRight, index);
				break;
			}
			break;
		case Direction.RIGHT:
			switch (newDir)
			{
			case Direction.LEFT:
				FillStripeLists(ref stripeTextures, lookRef.textureLoaderRef.stripeSegs_LeftRight, index);
				break;
			case Direction.MIDDLE:
				FillStripeLists(ref stripeTextures, lookRef.textureLoaderRef.stripeSegs_LeftMid, index);
				break;
			default:
				FillStripeLists(ref stripeTextures, lookRef.textureLoaderRef.stripeSegs_LeftLeft, index);
				break;
			}
			break;
		}
	}

	private static void FillStripeLists(ref List<Texture2D> stripeTextures, List<Texture2D> refList, int index)
	{
		stripeTextures.Add(refList[index]);
	}

	public static void AddSegmentedStripeToTexture(Color textureColor, int textureWidth, int textureHeight, ref Color32[] finalColors, List<Direction> dirList, List<Texture2D> stripeTextures, int xOffset, bool flipStripe)
	{
		Texture2D texture2D = stripeTextures[0];
		int num = stripeTextures[0].height * stripeTextures.Count;
		int num2 = textureHeight / 8 - (textureHeight - num) / 2;
		if (flipStripe)
		{
			num2 += textureHeight / 2;
		}
		bool flipX = false;
		bool flipY = false;
		if (dirList[0] == Direction.RIGHT)
		{
			flipX = true;
		}
		WriteImageToTexture(textureColor, textureWidth, textureHeight, ref finalColors, texture2D.width / 2, texture2D.height / 2, xOffset, num2, texture2D.GetPixels(), flipX, flipY);
		for (int i = 1; i < stripeTextures.Count - 1; i++)
		{
			texture2D = stripeTextures[i];
			num2 -= texture2D.height;
			flipX = false;
			flipY = true;
			if ((dirList[i - 1] == Direction.MIDDLE && dirList[i] == Direction.RIGHT) || (dirList[i - 1] == Direction.RIGHT && dirList[i] == Direction.RIGHT) || (dirList[i - 1] == Direction.RIGHT && dirList[i] == Direction.MIDDLE) || (dirList[i - 1] == Direction.RIGHT && dirList[i] == Direction.LEFT))
			{
				flipX = true;
			}
			if ((dirList[i - 1] == Direction.MIDDLE && dirList[i] == Direction.LEFT) || (dirList[i - 1] == Direction.MIDDLE && dirList[i] == Direction.RIGHT))
			{
				flipY = false;
			}
			WriteImageToTexture(textureColor, textureWidth, textureHeight, ref finalColors, texture2D.width / 2, texture2D.height / 2, xOffset, num2, texture2D.GetPixels(), flipX, flipY);
		}
		texture2D = stripeTextures[stripeTextures.Count - 1];
		num2 -= texture2D.height;
		flipY = true;
		flipX = false;
		if (dirList[dirList.Count - 1] == Direction.RIGHT)
		{
			flipX = true;
		}
		WriteImageToTexture(textureColor, textureWidth, textureHeight, ref finalColors, texture2D.width / 2, texture2D.height / 2, xOffset, num2, texture2D.GetPixels(), flipX, flipY);
	}

	private static void AddRepeatingPatternToTexture(DogLooks lookRef, int textureWidth, int textureHeight, Color textureColor, ref Color32[] finalColors, List<PatternInfoField> patternInfo, float startX = 0f, float endX = 1f, float startY = 0f, float endY = 1f)
	{
		int num = (int)((float)textureWidth * (endX - startX));
		int num2 = (int)((float)textureHeight * (endY - startY));
		int type = (int)patternInfo[0].repeatingPatternInfo.c;
		int num3 = (int)patternInfo[0].repeatingPatternInfo.d;
		int num4 = num / 2 / num3;
		int num5 = num2 / (num3 / 2);
		int num6 = num / 2 - num4 * num3;
		int num7 = Mathf.RoundToInt((float)num6 / ((float)num4 - 1f));
		if (num6 > 0 && num7 < 1)
		{
			num7 = 1;
		}
		num4++;
		int num8 = num2 - num5 * (num3 / 2);
		int num9 = num8 / num5;
		if (num8 > 0 && num9 < 1)
		{
			num9 = 1;
		}
		float num10 = (float)num3 / 2f;
		int num11 = num2 / 8 + num3 + num8 / 2;
		int num12 = 1;
		int num13 = 0;
		List<Texture2D> refListForRepeatingTypeAndSize = lookRef.GetRefListForRepeatingTypeAndSize(type, num3);
		for (int i = 0; i < num4; i++)
		{
			for (int j = 0; j < num5; j++)
			{
				num13++;
				if (num13 >= patternInfo.Count)
				{
					num12++;
					num13 = 1;
				}
				if (num12 > 4)
				{
					num12 = 1;
				}
				RepeatingPatternInfoField repeatingPatternInfo = patternInfo[num13].repeatingPatternInfo;
				bool flipX = ((repeatingPatternInfo.a != 0) ? true : false);
				bool flipY = ((repeatingPatternInfo.b != 0) ? true : false);
				int num14 = i * num3;
				if (j % 2 == 0)
				{
					num14 += num3 / 2;
				}
				num14 = ((num6 - (i - 1) * num7 < 0) ? (num14 + num6) : (num14 + num7 * (i - 1)));
				if (num14 > num / 2 || num14 < num3)
				{
					num13--;
					continue;
				}
				int num15 = num11 + j * (num3 / 2);
				num15 = ((num8 - j * num9 < 0) ? (num15 + num8) : (num15 + num9 * j));
				Texture2D texture2D;
				switch (num12)
				{
				case 1:
					texture2D = refListForRepeatingTypeAndSize[Mathf.RoundToInt(repeatingPatternInfo.c / 100f * (float)(refListForRepeatingTypeAndSize.Count - 1))];
					break;
				case 2:
					texture2D = refListForRepeatingTypeAndSize[Mathf.RoundToInt(repeatingPatternInfo.d / 100f * (float)(refListForRepeatingTypeAndSize.Count - 1))];
					break;
				case 3:
					texture2D = refListForRepeatingTypeAndSize[Mathf.RoundToInt(repeatingPatternInfo.e / 100f * (float)(refListForRepeatingTypeAndSize.Count - 1))];
					break;
				default:
					texture2D = refListForRepeatingTypeAndSize[Mathf.RoundToInt(repeatingPatternInfo.f / 100f * (float)(refListForRepeatingTypeAndSize.Count - 1))];
					break;
				}
				num14 += (int)((float)textureWidth / 2f * startX);
				num15 += (int)((float)textureHeight * startY);
				WriteImageToTexture(textureColor, textureWidth, textureHeight, ref finalColors, (int)num10, (int)num10, num14, num15, texture2D.GetPixels(), flipX, flipY);
			}
		}
	}

	private static void WriteImageToTexture(Color textureColor, int textureWidth, int textureHeight, ref Color32[] finalColors, int radiusX, int radiusY, int startX, int startY, Color[] pixels, bool flipX, bool flipY, bool fade = false)
	{
		int num = textureWidth / 2;
		int num2 = num / 2;
		int num3 = num - num2;
		int num4 = radiusX * 2;
		int num5 = radiusY * 2;
		Color color = textureColor;
		int num6 = 0;
		int num7 = 0;
		for (int i = 0; i < num5; i++)
		{
			for (int j = 0; j < num4; j++)
			{
				int num8 = startX - j;
				int num9 = MathUtil.Mod(startY - i, textureHeight);
				int num10 = ((!flipX) ? num6 : (radiusX * 2 - num6 - 1));
				int num11 = ((!flipY) ? num7 : (pixels.Length - radiusX * 2 - num7));
				if (num8 < 0)
				{
					continue;
				}
				int num12 = num9 * textureWidth + num8;
				if (((Color)finalColors[num12]).a < pixels[num10 + num11].a)
				{
					color.a = pixels[num10 + num11].a;
					if (fade && num8 >= num3)
					{
						color.a *= (float)(num - num8) / (float)num2;
					}
					finalColors[num12] = color;
				}
				num6++;
			}
			num6 = 0;
			num7 += radiusX * 2;
		}
	}
}
