using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using VampireSurvivors.App.Tools;

namespace VampireSurvivors.App.Scripts.Framework;

public class FontFactory : SerializedScriptableObject
{
	[Serializable]
	public class UnityFontRefDictionary : UnitySerializedDictionary<string, UnityFontRefData>
	{
		public UnityFontRefDictionary()
		{
			((UnitySerializedDictionary<object, object>)(object)this)._002Ector();
		}
	}

	[Serializable]
	public class TMPFontRefDictionary : UnitySerializedDictionary<string, TMPFontRefData>
	{
		public TMPFontRefDictionary()
		{
			((UnitySerializedDictionary<object, object>)(object)this)._002Ector();
		}
	}

	[Serializable]
	public class UnityFontRefData
	{
		private AssetReferenceT<Font> _UnityFontRef;

		public AssetReferenceT<Font> UnityFontRef
		{
			get
			{
				return _UnityFontRef;
			}
			set
			{
				_UnityFontRef = value;
			}
		}
	}

	[Serializable]
	public class TMPFontRefData
	{
		private AssetReferenceT<TMP_FontAsset> _TMPFontRef;

		public AssetReferenceT<TMP_FontAsset> TMPFontRef
		{
			get
			{
				return _TMPFontRef;
			}
			set
			{
				_TMPFontRef = value;
			}
		}
	}

	private UnityFontRefDictionary _Fonts;

	private TMPFontRefDictionary _TMPFonts;

	public Font GetFont(string fontName)
	{
		if (_Fonts != null && ((Dictionary<object, object>)(object)_Fonts).TryGetValue((object)fontName, out object value))
		{
			if (value != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F94830");
				Font result = default(Font);
				return result;
			}
			return (Font)(object)new NullReferenceException();
		}
		return null;
	}

	public TMP_FontAsset GetTMPFont(string fontName)
	{
		if (_TMPFonts != null && ((Dictionary<object, object>)(object)_TMPFonts).TryGetValue((object)fontName, out object value))
		{
			if (value != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F94830");
				TMP_FontAsset result = default(TMP_FontAsset);
				return result;
			}
			return (TMP_FontAsset)(object)new NullReferenceException();
		}
		return null;
	}

	public FontFactory()
	{
		UnityFontRefDictionary fonts = (UnityFontRefDictionary)(object)new UnitySerializedDictionary<object, object>();
		_Fonts = fonts;
		_TMPFonts = (TMPFontRefDictionary)(object)new UnitySerializedDictionary<object, object>();
		((ScriptableObject)this)._002Ector();
	}
}
