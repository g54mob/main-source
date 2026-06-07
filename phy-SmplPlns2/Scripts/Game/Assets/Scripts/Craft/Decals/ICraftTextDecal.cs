using TMPro;
using UnityEngine;

namespace Assets.Scripts.Craft.Decals
{
	public interface ICraftTextDecal : ICraftDecal
	{
		float FontSize { get; }

		HorizontalAlignmentOptions HorizontalAlignment { get; }

		string Text { get; }

		VerticalAlignmentOptions VerticalAlignment { get; }

		TMP_FontAsset GetFont();

		Material GetFontMaterial();
	}
}
