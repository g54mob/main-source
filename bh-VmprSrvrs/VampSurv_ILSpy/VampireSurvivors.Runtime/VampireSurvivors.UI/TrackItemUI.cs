using System;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VampireSurvivors.Data;

namespace VampireSurvivors.UI;

public class TrackItemUI : SelectableUI
{
	private Image _Icon;

	private TextMeshProUGUI _Title;

	private Image _Frame;

	private Button _Button;

	private CanvasGroup _CanvasGroup;

	private Canvas _canvas;

	private BgmType _bgmType;

	private MusicData _data;

	private AdvancedMusicSelection _page;

	private Color _deselectColor;

	private float _deselectAlpha;

	private bool _holdSelection;

	private Tween _colorTween;

	private Tween _fadeTween;

	protected override void Awake()
	{
		base.Awake();
	}

	public unsafe void SetData(string name, Sprite icon, BgmType bgmType, MusicData data, AdvancedMusicSelection page)
	{
		//IL_0123: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A36C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		GameObject gameObject = base.gameObject;
		((UnityEngine.Object)gameObject).SetName(name);
		MusicData data2 = default(MusicData);
		_data = data2;
		_bgmType = bgmType;
		AdvancedMusicSelection page2 = default(AdvancedMusicSelection);
		_page = page2;
		MusicData data3 = _data;
		if (!data3._003CisUnlocked_003Ek__BackingField)
		{
			_Icon.enabled = false;
			_Title.text = "---------------------------";
			base.enabled = false;
			_Button.enabled = false;
		}
		else
		{
			_Icon.enabled = true;
			_Icon.sprite = icon;
			_Title.text = name;
		}
		object obj = default(object);
		_Frame.color = (Color)(&obj);
		_CanvasGroup.alpha = _deselectAlpha;
	}

	protected override void OnDisable()
	{
		base.OnDisable();
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

	public void KillTweens()
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

	public void OnMouseClick()
	{
		//IL_0134: Expected O, but got I4
		//IL_014e: Expected O, but got I4
		EventSystem current = EventSystem.current;
		GameObject currentSelected = current.m_CurrentSelected;
		GameObject gameObject = base.gameObject;
		bool flag = (object)gameObject == null;
		bool flag2 = (object)current.m_CurrentSelected == null;
		object obj = flag2 & flag;
		bool flag3 = obj == null;
		object obj2 = !flag3;
		if (obj2 == null)
		{
			bool flag4;
			if ((object)gameObject != null)
			{
				if ((object)current.m_CurrentSelected != null)
				{
					object obj3 = (object)current.m_CurrentSelected - (object)gameObject;
					flag4 = obj3 == null;
				}
				else
				{
					flag4 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
				}
			}
			else
			{
				flag4 = ((UnityEngine.Object)currentSelected).m_CachedPtr == (IntPtr)0;
			}
			if (!flag4)
			{
				Selectable component = GetComponent<Selectable>();
				component.Select();
				return;
			}
		}
		OnSelected();
	}

	public BgmType GetBgmType()
	{
		return _bgmType;
	}

	public MusicData GetMusicData()
	{
		return _data;
	}

	public void SetLoading(bool v)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A36C4]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (!v)
		{
			MusicData data = _data;
			_Title.text = data._003Ctitle_003Ek__BackingField;
		}
		else
		{
			MusicData data2 = _data;
			string text = data2._003Ctitle_003Ek__BackingField + " (Loading...)";
			_Title.text = text;
		}
	}

	public void HoldSelection()
	{
		_holdSelection = true;
	}

	public void ReleaseSelection()
	{
		_holdSelection = false;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 2 Invalid \"Jump target not found in method: 0x186DF2260\"");
	}

	public unsafe void ForceDeselect()
	{
		//IL_0121: Expected O, but got Ref
		if (!_holdSelection)
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
			Image frame = _Frame;
			if ((object)_Frame != null && ((UnityEngine.Object)frame).m_CachedPtr != (IntPtr)0)
			{
				Image component = GetComponent<Image>();
				object obj = default(object);
				TweenerCore<Color, Color, ColorOptions> colorTween2 = DOTweenModuleUI.DOColor(component, (Color)(&obj), 0.2f);
				_colorTween = colorTween2;
			}
			CanvasGroup canvasGroup = _CanvasGroup;
			if ((object)_CanvasGroup != null && ((UnityEngine.Object)canvasGroup).m_CachedPtr != (IntPtr)0)
			{
				TweenerCore<float, float, FloatOptions> fadeTween2 = DOTweenModuleUI.DOFade(_CanvasGroup, _deselectAlpha, 0.2f);
				_fadeTween = fadeTween2;
			}
		}
	}

	protected unsafe override void OnSelected()
	{
		//IL_014f: Expected O, but got Ref
		MusicData data = _data;
		if (data._003CisUnlocked_003Ek__BackingField)
		{
			_page.SetSelectedTrack(this);
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
			Image frame = _Frame;
			if ((object)_Frame != null && ((UnityEngine.Object)frame).m_CachedPtr != (IntPtr)0)
			{
				Image component = GetComponent<Image>();
				object obj = default(object);
				TweenerCore<Color, Color, ColorOptions> colorTween2 = DOTweenModuleUI.DOColor(component, (Color)(&obj), 0.2f);
				_colorTween = colorTween2;
			}
			CanvasGroup canvasGroup = _CanvasGroup;
			if ((object)_CanvasGroup != null && ((UnityEngine.Object)canvasGroup).m_CachedPtr != (IntPtr)0)
			{
				TweenerCore<float, float, FloatOptions> fadeTween2 = DOTweenModuleUI.DOFade(_CanvasGroup, 1f, 0.2f);
				_fadeTween = fadeTween2;
			}
		}
	}

	public TrackItemUI()
	{
		//IL_0012: Expected O, but got I
		//IL_0053: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12310]");
		_deselectColor = (Color)0;
		_deselectAlpha = 0.45f;
		base._ShowSelector = true;
		base._ShouldUpdatePositionWhenForcingDumbFix = true;
		ReselectIfDefaultSelectedOnPage = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
