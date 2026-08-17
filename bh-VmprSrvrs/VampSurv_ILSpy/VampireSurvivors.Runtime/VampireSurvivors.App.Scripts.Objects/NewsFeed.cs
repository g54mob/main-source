using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using TMPro;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.App.Scripts.Objects;

public class NewsFeed : MonoBehaviour
{
	private const string BannerSpriteName = "NewsfeedWarning";

	private const string BannerTextureName = "UI";

	private const float ScreenPercentY = 0.9f;

	private const float ScrollDurationMS = 10000f;

	private const float BannerAlphaDefault = 0.25f;

	private const float BannerAlphaPulse = 0.35f;

	private const float BannerAlphaPulseDurationMS = 1000f;

	private const float BannerFadeInDurationMS = 150f;

	private const float BannerFadeOutDurationMS = 150f;

	private const float TextFadeInDurationMS = 150f;

	private const float TextFadeOutDurationMS = 150f;

	private MultiTargetTween _bannerShowTween;

	private MultiTargetTween _bannerScrollTween;

	private MultiTargetTween _bannerAlphaTween;

	private MultiTargetTween _bannerHideTween;

	private MultiTargetTween _textShowTween;

	private MultiTargetTween _textScrollTween;

	private MultiTargetTween _textHideTween;

	private GameObject _banner;

	private TileSpriteBuilder _bannerTileSpriteBuilder;

	private TileSprite _bannerTileSprite;

	private PhaserText _text;

	private float _textStartPosX;

	private float _bannerScrollStartOffsetX;

	public float _BannerScrollOffsetX;

	public PhaserText TextObject => _text;

	private void Awake()
	{
		MakeBanner();
		MakeText();
	}

	private void MakeBanner()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
		GameObject banner = base.gameObject;
		_banner = banner;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float x = renderer.width * 0.5f;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		float y = renderer2.height * 0.9f;
		string spriteName = default(string);
		TileSpriteBuilder bannerTileSpriteBuilder = RenderingExtensions.AddTileSprite(_banner, x, y, "UI", spriteName);
		_bannerTileSpriteBuilder = bannerTileSpriteBuilder;
		TileSpriteBuilder bannerTileSpriteBuilder2 = _bannerTileSpriteBuilder;
		bannerTileSpriteBuilder2._depth = 31757f;
		bannerTileSpriteBuilder2._depthMul = 1f;
		TileSpriteBuilder bannerTileSpriteBuilder3 = _bannerTileSpriteBuilder;
		PhaserScene s_scene3 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer3 = s_scene3._renderer;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rax_v3 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rax_v3 (System.Object)+10]");
		Sprite.get_rect_Injected((IntPtr)0, out Rect _);
		object obj = default(object);
		float tileHeight = (float)obj / 100f;
		bannerTileSpriteBuilder3._tileWidth = renderer3.screenWidth;
		bannerTileSpriteBuilder3._tileHeight = tileHeight;
		TileSpriteBuilder bannerTileSpriteBuilder4 = _bannerTileSpriteBuilder;
		bannerTileSpriteBuilder4._name = "NewsfeedWarning";
		TileSprite bannerTileSprite = _bannerTileSpriteBuilder.Build();
		_bannerTileSprite = bannerTileSprite;
		TileSprite tileSprite = RenderingExtensions.SetScrollFactor(_bannerTileSprite, 0f);
		TileSprite bannerTileSprite2 = _bannerTileSprite;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(bannerTileSprite2._spriteRenderer, 0f);
	}

	private unsafe void MakeText()
	{
		//IL_00b8: Expected O, but got Ref
		//IL_0137: Expected O, but got I4
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null && s_scene._renderer != null && (object)GM.Core != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null && s_scene2._renderer != null && (object)GM.Core != null)
				{
					PhaserScene s_scene3 = ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene != null)
					{
						Vector2 pos = default(Vector2);
						float ret = default(float);
						float fontSize = default(float);
						PhaserText component = RenderingExtensions.text(s_scene3.add, pos, "", (Color)(&ret), fontSize);
						PhaserText phaserText = RenderingExtensions.SetScrollFactor(component, 0f);
						if ((object)phaserText != null)
						{
							PhaserText phaserText2 = phaserText.SetDepth(31758);
							if ((object)phaserText2 != null)
							{
								PhaserText phaserText3 = phaserText2.setOrigin(0.5f, (float?)(object)1);
								if ((object)phaserText3 != null)
								{
									PhaserText text = phaserText3.SetAlpha(0f);
									_text = text;
									if ((object)_text != null)
									{
										Transform transform = _text.transform;
										if ((object)transform != null)
										{
											bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
											Transform.get_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
											_textStartPosX = ret;
											return;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void SetText(string text)
	{
		PhaserText phaserText = _text.SetText(text);
	}

	public void SetSprite(string _BannerSpriteName, string _BannerTextureName)
	{
		_bannerTileSprite.SetFrame(_BannerSpriteName, _BannerTextureName);
	}

	public void SetVisible(bool visible)
	{
		PhaserText text = _text;
		if ((object)_text != null && ((UnityEngine.Object)text).m_CachedPtr != (IntPtr)0)
		{
			PhaserText text2 = _text;
			_text.EnsureTextRenderer();
			TextMeshPro textRenderer = text2._textRenderer;
			if ((object)text2._textRenderer != null && ((UnityEngine.Object)textRenderer).m_CachedPtr != (IntPtr)0)
			{
				text2._textRenderer.enabled = visible;
			}
		}
		TileSprite bannerTileSprite = _bannerTileSprite;
		if ((object)_bannerTileSprite != null && ((UnityEngine.Object)bannerTileSprite).m_CachedPtr != (IntPtr)0)
		{
			_bannerTileSprite.SetVisible(visible);
		}
	}

	public void Show()
	{
		//IL_0081: Expected I, but got O
		//IL_00e5: Expected O, but got I4
		//IL_0158: Expected I, but got O
		//IL_024c: Expected I4, but got I8
		//IL_0315: Expected I, but got O
		//IL_036b: Expected O, but got I4
		//IL_03f0: Expected I, but got O
		//IL_0446: Expected O, but got I4
		//IL_0466: Expected I4, but got I8
		TileSprite bannerTileSprite = _bannerTileSprite;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(bannerTileSprite._spriteRenderer, 0f);
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		TileSprite bannerTileSprite2 = _bannerTileSprite;
		if ((object)bannerTileSprite2._spriteRenderer != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 150f;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			//IL_003e: Expected I, but got O
			//IL_00a6: Expected I4, but got I8
			//IL_00c2: Expected O, but got I4
			TweenConfig tweenConfig5 = new TweenConfig();
			object[] array5 = new object[1];
			TileSprite bannerTileSprite3 = _bannerTileSprite;
			if ((object)bannerTileSprite3._spriteRenderer != null)
			{
				nint num7 = (nint)array5;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj5 = default(object);
				if (obj5 == null)
				{
					ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
					throw ex5;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig5.targets = array5;
			tweenConfig5.duration = 1000f;
			tweenConfig5.repeat = -1;
			tweenConfig5.yoyo = true;
			tweenConfig5.alpha = (float?)(object)1;
			MultiTargetTween bannerAlphaTween = Tweens.Add(tweenConfig5);
			_bannerAlphaTween = bannerAlphaTween;
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween bannerShowTween = Tweens.Add(tweenConfig);
		_bannerShowTween = bannerShowTween;
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		nint num2 = (nint)array2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj2 = default(object);
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			float num3 = renderer.width + renderer.width;
			float num4 = num3 + _bannerScrollStartOffsetX;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value = default(object);
			bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_BannerScrollOffsetX", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig2.custom = dictionary;
			tweenConfig2.duration = 10000f;
			tweenConfig2.repeat = -1;
			TweenCallback onUpdate = delegate
			{
				TileSprite bannerTileSprite3 = _bannerTileSprite;
				bannerTileSprite3._xScrollOffset = _BannerScrollOffsetX;
				bannerTileSprite3._spriteScroller.SetScrollOffsetX(_BannerScrollOffsetX);
			};
			tweenConfig2.onUpdate = onUpdate;
			TweenCallback onRepeat = delegate
			{
				_bannerScrollStartOffsetX = _BannerScrollOffsetX;
				_BannerScrollOffsetX = 0f;
			};
			tweenConfig2.onRepeat = onRepeat;
			MultiTargetTween bannerScrollTween = Tweens.Add(tweenConfig2);
			_bannerScrollTween = bannerScrollTween;
			PhaserText phaserText = _text.SetAlpha(0f);
			TweenConfig tweenConfig3 = new TweenConfig();
			object[] array3 = new object[1];
			if ((object)_text != null)
			{
				nint num5 = (nint)array3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj3 = default(object);
				if (obj3 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig3.targets = array3;
			tweenConfig3.alpha = (float?)(object)1;
			tweenConfig3.duration = 150f;
			MultiTargetTween textShowTween = Tweens.Add(tweenConfig3);
			_textShowTween = textShowTween;
			TweenConfig tweenConfig4 = new TweenConfig();
			object[] array4 = new object[1];
			Transform transform = _text.transform;
			if ((object)transform != null)
			{
				nint num6 = (nint)array4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj4 = default(object);
				if (obj4 == null)
				{
					ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
					throw ex3;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig4.targets = array4;
			tweenConfig4.localX = (float?)(object)1;
			tweenConfig4.duration = 10000f;
			tweenConfig4.repeat = -1;
			MultiTargetTween textScrollTween = Tweens.Add(tweenConfig4);
			_textScrollTween = textScrollTween;
			return;
		}
		ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
		throw ex4;
	}

	public void Hide()
	{
		//IL_005e: Expected I, but got O
		//IL_00c2: Expected O, but got I4
		//IL_01bf: Expected I, but got O
		//IL_0223: Expected O, but got I4
		if (_textShowTween != null)
		{
			_textShowTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_text != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 150f;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			if (_textScrollTween != null)
			{
				_textScrollTween.Kill();
			}
			if (_textHideTween != null)
			{
				_textHideTween.Kill();
			}
			UnityEngine.Object.Destroy(_text, 0f);
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween textHideTween = Tweens.Add(tweenConfig);
		_textHideTween = textHideTween;
		if (_bannerShowTween != null)
		{
			_bannerShowTween.Kill();
		}
		if (_bannerAlphaTween != null)
		{
			_bannerAlphaTween.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		TileSprite bannerTileSprite = _bannerTileSprite;
		if ((object)bannerTileSprite._spriteRenderer != null)
		{
			nint num2 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.duration = 150f;
		tweenConfig2.alpha = (float?)(object)1;
		TweenCallback onComplete2 = delegate
		{
			if (_bannerScrollTween != null)
			{
				_bannerScrollTween.Kill();
			}
			if (_bannerHideTween != null)
			{
				_bannerHideTween.Kill();
			}
			UnityEngine.Object.Destroy(this, 0f);
		};
		tweenConfig2.onComplete = onComplete2;
		MultiTargetTween bannerHideTween = Tweens.Add(tweenConfig2);
		_bannerHideTween = bannerHideTween;
	}

	public NewsFeed()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	private void _003CShow_003Eb__33_0()
	{
		//IL_003e: Expected I, but got O
		//IL_00a6: Expected I4, but got I8
		//IL_00c2: Expected O, but got I4
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		TileSprite bannerTileSprite = _bannerTileSprite;
		if ((object)bannerTileSprite._spriteRenderer != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 1000f;
		tweenConfig.repeat = -1;
		tweenConfig.yoyo = true;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween bannerAlphaTween = Tweens.Add(tweenConfig);
		_bannerAlphaTween = bannerAlphaTween;
	}

	private void _003CShow_003Eb__33_1()
	{
		TileSprite bannerTileSprite = _bannerTileSprite;
		bannerTileSprite._xScrollOffset = _BannerScrollOffsetX;
		bannerTileSprite._spriteScroller.SetScrollOffsetX(_BannerScrollOffsetX);
	}

	private void _003CShow_003Eb__33_2()
	{
		_bannerScrollStartOffsetX = _BannerScrollOffsetX;
		_BannerScrollOffsetX = 0f;
	}

	private void _003CHide_003Eb__34_0()
	{
		if (_textScrollTween != null)
		{
			_textScrollTween.Kill();
		}
		if (_textHideTween != null)
		{
			_textHideTween.Kill();
		}
		UnityEngine.Object.Destroy(_text, 0f);
	}

	private void _003CHide_003Eb__34_1()
	{
		if (_bannerScrollTween != null)
		{
			_bannerScrollTween.Kill();
		}
		if (_bannerHideTween != null)
		{
			_bannerHideTween.Kill();
		}
		UnityEngine.Object.Destroy(this, 0f);
	}
}
