using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.UI;

public class AlbumItemUI : CarouselItemUI
{
	private TextMeshProUGUI _Title;

	private Image _Icon;

	private bool _isSelected;

	private bool _previouslyIsSelected;

	private Tween _colorTween;

	private Tween _fadeTween;

	private AlbumType _albumType;

	private AlbumData _albumData;

	public void SetData(string name, AlbumType t, AlbumData d)
	{
		_Title.text = name;
		_albumData = d;
		_albumType = t;
		_Title.enabled = false;
		AlbumData albumData = _albumData;
		string spriteName = albumData._003Cicon_003Ek__BackingField.Replace(".png", "");
		Sprite sprite = SpriteManager.GetSprite(spriteName);
		_Icon.sprite = sprite;
	}

	public override void Initialize(float maxDistance)
	{
		base.Initialize(maxDistance);
		Deselect();
	}

	public AlbumType GetAlbumType()
	{
		return _albumType;
	}

	public AlbumData GetAlbumData()
	{
		return _albumData;
	}

	private void KillTweens()
	{
		Tween colorTween = _colorTween;
		if (_colorTween != null && colorTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_colorTween);
		}
		Tween fadeTween = _fadeTween;
		if (_fadeTween != null && fadeTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_fadeTween);
		}
	}

	private void OnDisable()
	{
		Tween colorTween = _colorTween;
		if (_colorTween != null && colorTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_colorTween);
		}
		Tween fadeTween = _fadeTween;
		if (_fadeTween != null && fadeTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_fadeTween);
		}
	}

	protected override void ApplyProgress()
	{
		//IL_0099: Expected I, but got O
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00fc: Invalid comparison between F4 and O
		//IL_011b: Invalid comparison between F4 and I4
		Vector2 anchoredPosition = _target.anchoredPosition;
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v5 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		object obj = anchoredPosition - Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rcx_v4 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		object obj3 = default(object);
		object obj2 = obj3 - 0;
		object obj4 = obj * obj;
		object obj5 = obj2 * obj2;
		object obj6 = obj5 + obj4;
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6);
		float num3 = 9.9999994E-11f - (float)obj6;
		bool flag2 = num3 == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		object message;
		if (!(_isSelected = flag4 & flag3))
		{
			if (~(_previouslyIsSelected ? 1u : 0u) != 0)
			{
				goto IL_007e;
			}
			Deselect();
			message = "Deselecting";
		}
		else
		{
			if (_previouslyIsSelected)
			{
				goto IL_007e;
			}
			Select();
			message = "Selecting";
		}
		Debug.Log(message);
		goto IL_007e;
		IL_007e:
		_previouslyIsSelected = _isSelected;
	}

	public unsafe override void Deselect(bool completeImmediately = false)
	{
		//IL_00b8: Expected O, but got Ref
		Tween colorTween = _colorTween;
		if (_colorTween != null && colorTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_colorTween);
		}
		Tween fadeTween = _fadeTween;
		if (_fadeTween != null && fadeTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_fadeTween);
		}
		Image component = GetComponent<Image>();
		object obj = default(object);
		TweenerCore<Color, Color, ColorOptions> colorTween2 = DOTweenModuleUI.DOColor(component, (Color)(&obj), 0.2f);
		_colorTween = colorTween2;
		TweenerCore<float, float, FloatOptions> fadeTween2 = DOTweenModuleUI.DOFade(_cg, 0.45f, 0.2f);
		_fadeTween = fadeTween2;
		if (completeImmediately)
		{
			TweenExtensions.Complete(_colorTween, withCallbacks: false);
			TweenExtensions.Complete(_fadeTween, withCallbacks: false);
		}
	}

	public unsafe override void Select(bool completeImmediately = false)
	{
		//IL_00b8: Expected O, but got Ref
		Tween colorTween = _colorTween;
		if (_colorTween != null && colorTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_colorTween);
		}
		Tween fadeTween = _fadeTween;
		if (_fadeTween != null && fadeTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_fadeTween);
		}
		Image component = GetComponent<Image>();
		object obj = default(object);
		TweenerCore<Color, Color, ColorOptions> colorTween2 = DOTweenModuleUI.DOColor(component, (Color)(&obj), 0.2f);
		_colorTween = colorTween2;
		TweenerCore<float, float, FloatOptions> fadeTween2 = DOTweenModuleUI.DOFade(_cg, 1f, 0.2f);
		_fadeTween = fadeTween2;
		if (completeImmediately)
		{
			TweenExtensions.Complete(_colorTween, withCallbacks: false);
			TweenExtensions.Complete(_fadeTween, withCallbacks: false);
		}
	}

	public AlbumItemUI()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
