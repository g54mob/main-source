using System;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using VampireSurvivors.App.Tools;

namespace VampireSurvivors.App.Scripts.Framework
{
	[CreateAssetMenu(fileName = "FontFactory", menuName = "VampireSurvivors/New FontFactory")]
	public class FontFactory : SerializedScriptableObject
	{
		[Serializable]
		public class UnityFontRefDictionary : UnitySerializedDictionary<string, UnityFontRefData>
		{
		}

		[Serializable]
		public class TMPFontRefDictionary : UnitySerializedDictionary<string, TMPFontRefData>
		{
		}

		[Serializable]
		public class UnityFontRefData
		{
			[SerializeField]
			private AssetReferenceT<Font> _UnityFontRef;

			public AssetReferenceT<Font> UnityFontRef
			{
				get
				{
					return null;
				}
				set
				{
				}
			}
		}

		[Serializable]
		public class TMPFontRefData
		{
			[SerializeField]
			private AssetReferenceT<TMP_FontAsset> _TMPFontRef;

			public AssetReferenceT<TMP_FontAsset> TMPFontRef
			{
				get
				{
					return null;
				}
				set
				{
				}
			}
		}

		[SerializeField]
		private UnityFontRefDictionary _Fonts;

		[SerializeField]
		private TMPFontRefDictionary _TMPFonts;

		public Font GetFont(string fontName)
		{
			return null;
		}

		public TMP_FontAsset GetTMPFont(string fontName)
		{
			return null;
		}
	}
}
