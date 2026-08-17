using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Graphics;

namespace VampireSurvivors;

public class IconImageLoader : MonoBehaviour
{
	private struct SpriteTextureDataInternal(string texture, string sprite, Sprite spriteRef)
	{
		public string Texture = texture;

		public string Sprite = sprite;

		public Sprite SpriteRef = spriteRef;
	}

	private string _filterTextures;

	private SpriteTextureDataInternal _spriteTextureData;

	private string _texture;

	private string _sprite;

	private Sprite _spritePreview;

	private Image _image;

	private void Awake()
	{
		Image component = GetComponent<Image>();
		_image = component;
	}

	public void OnEnable()
	{
		Image image = _image;
		Sprite sprite = image.m_Sprite;
		if ((object)image.m_Sprite == null || ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0)
		{
			Sprite sprite2 = SpriteManager.GetSprite(_sprite, _texture);
			_image.sprite = sprite2;
		}
	}

	public IconImageLoader()
	{
		//IL_0058: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A495B]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_filterTextures = "";
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rcx_v4 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
