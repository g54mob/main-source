using System;
using TMPro;
using UnityEngine;

[Serializable]
public struct FontSet
{
	[NamedArray(typeof(FontId))]
	public TMP_FontAsset[] PixelFonts;

	[NamedArray(typeof(FontId))]
	public Material[] PixelOutlinedMats;

	[NamedArray(typeof(FontId))]
	public TMP_FontAsset[] HighResFonts;

	[NamedArray(typeof(FontId))]
	public Material[] HighResOutlinedMats;
}
