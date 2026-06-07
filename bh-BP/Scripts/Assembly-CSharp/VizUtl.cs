using System.Collections.Generic;
using UnityEngine;

public static class VizUtl
{
	public static Sprite ColorizeSprite(Sprite ogSprite, Color redColor, Color blueColor)
	{
		return null;
	}

	public static Sprite CombineBallSprites(HeroInfo hBase, HeroInfo hEf)
	{
		return null;
	}

	public static Sprite CombineBallSprites(HeroInfo hBase, Sprite sprBase, HeroInfo hEf, Sprite sprEf)
	{
		return null;
	}

	public static Sprite ColorizeBallSprite(HeroInfo hBase, Sprite sprBase, HeroInfo hColorize)
	{
		return null;
	}

	public static Sprite ColorizeSprite(List<Color> baseColorList, Sprite sprBase, List<Color> remappedColors)
	{
		return null;
	}

	public static Texture2D ColorizeBallTex(HeroInfo hBase, Texture2D baseTex, HeroInfo hColorize)
	{
		return null;
	}

	public static Texture2D ColorizeBallTexSprites(HeroInfo hBase, Texture2D baseTex, HeroInfo hColorize)
	{
		return null;
	}

	public static Color GetFirstColor(Sprite spr)
	{
		return default(Color);
	}

	public static float GetPixelPerfectSize(float defaultSize, float tgtPct)
	{
		return 0f;
	}

	public static Vector2 GetPixelPerfectSize(Vector2 defaultSize, float tgtPct)
	{
		return default(Vector2);
	}

	public static List<Color> GetSpriteColorList(Sprite spr)
	{
		return null;
	}

	public static float GetLuminosity(this Color c)
	{
		return 0f;
	}

	public static void CopySpriteToTex(this Texture2D tex, Sprite spr, int startX, int startY)
	{
	}

	public static void DrawBorder(this Texture2D tex, Color c, int x, int y, int w, int h)
	{
	}

	public static int PickTex(int x, int y, int w, int h, ComboAngle angle)
	{
		return 0;
	}

	public static Sprite CombineCharSprites(Sprite spr1, Color c1, Sprite spr2, Color c2, ComboAngle angle = ComboAngle.k90, bool flipX = false)
	{
		return null;
	}
}
