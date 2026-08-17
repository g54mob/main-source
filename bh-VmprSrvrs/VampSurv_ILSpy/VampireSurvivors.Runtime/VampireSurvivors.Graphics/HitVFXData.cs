using System;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.Graphics;

public class HitVFXData
{
	public bool HasTintFill;

	public string TintColor;

	public Sprite HitSprite;

	public Sprite ImpactSprite;

	public float Duration;

	public Color? CachedTintColor;

	public unsafe HitVFXData(bool hasTintFill, string tintColor, Sprite hitSprite, Sprite impactSprite, float duration)
	{
		//IL_005f: Expected O, but got I4
		HasTintFill = hasTintFill;
		TintColor = tintColor;
		HitSprite = hitSprite;
		Sprite impactSprite2 = default(Sprite);
		ImpactSprite = impactSprite2;
		float duration2 = default(float);
		Duration = duration2;
		IntPtr color;
		bool flag = ColorUtility.DoTryParseHtmlColor(tintColor, out *(Color32*)(&color));
		float num = 0f / 255f;
		if (flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
			CachedTintColor = (Color?)(object)1;
		}
	}

	public unsafe Color GetColor()
	{
		//IL_0009: Expected native int or pointer, but got O
		Color color = default(Color);
		((Color*)(nint)color)->r = 0f;
		bool flag = ColorUtility.TryParseHtmlString(TintColor, out *(Color*)color);
		return color;
	}
}
