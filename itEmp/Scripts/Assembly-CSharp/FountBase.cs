using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "FountBase", menuName = "Fount Base")]
public class FountBase : ScriptableObject
{
	[Serializable]
	public class FontPair
	{
		public Font ttfFont;

		public TMP_FontAsset tmpFontAsset;
	}

	public List<FontPair> fonts;
}
