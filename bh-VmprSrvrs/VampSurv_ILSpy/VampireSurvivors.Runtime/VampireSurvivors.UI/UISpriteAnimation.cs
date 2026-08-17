using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.UI;

public class UISpriteAnimation : MonoBehaviour
{
	private int FPS = 8;

	private bool PlayManually;

	private bool _UseCustomScaleTween;

	private bool _UseCustomPositionTween;

	private bool _ScaleBasedOnSpriteSize;

	private bool _hideWhenDone = true;

	public bool _FreezeOnLastFrame;

	public Action OnComplete;

	private Vector3 _StartScale;

	private Vector3 _EndScale;

	private Vector2 _StartPos;

	private Vector2 _EndPos;

	public List<Sprite> sprites;

	private RectTransform _rTrans;

	private Image _image;

	private float _currentTimer;

	private float _triggerTimer;

	private int _index;

	private bool _isPlayingManually;

	private Action _onComplete;

	private bool _003CIsPaused_003Ek__BackingField;

	public bool ScaleBasedOnSpriteSizeWithoutMagic;

	public bool IsPaused
	{
		get
		{
			return _003CIsPaused_003Ek__BackingField;
		}
		set
		{
			_003CIsPaused_003Ek__BackingField = value;
		}
	}

	private void Awake()
	{
		Image component = GetComponent<Image>();
		_image = component;
		float triggerTimer = 1f / (float)FPS;
		_triggerTimer = triggerTimer;
		RectTransform component2 = GetComponent<RectTransform>();
		_rTrans = component2;
	}

	private unsafe void Update()
	{
		//IL_02ca: Expected O, but got I4
		//IL_0259: Expected O, but got I4
		//IL_0157: Expected O, but got Ref
		//IL_0403: Expected O, but got I4
		//IL_0169->IL0169: Incompatible stack heights: 1 vs 0
		if ((PlayManually && !_isPlayingManually) || _003CIsPaused_003Ek__BackingField || sprites == null)
		{
			return;
		}
		List<Sprite> list = sprites;
		if (list._size <= 0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186228470");
		bool flag = !_UseCustomScaleTween;
		object obj = default(object);
		float currentTimer = (float)obj + _currentTimer;
		_currentTimer = currentTimer;
		if (!flag && _index == 0)
		{
			Transform transform = base.transform;
			bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			Transform target = base.transform;
			List<Sprite> list2 = sprites;
			int size = list2._size;
			float num = 1f / (float)FPS;
			float duration = num * (float)list2._size;
			object obj2 = default(object);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, (Vector3)(&obj2), duration);
			bool flag3 = false;
		}
		if (!_UseCustomPositionTween || _index != 0)
		{
			goto IL_026f;
		}
		if ((object)_rTrans != null)
		{
			Vector2 vector = default(Vector2);
			_rTrans.anchoredPosition = vector;
			List<Sprite> list3 = sprites;
			if (sprites != null)
			{
				int size = list3._size;
				float num2 = 1f / (float)FPS;
				float num3 = num2 * (float)list3._size;
				TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore2 = DOTweenModuleUI.DOAnchorPos(_rTrans, vector, num3);
				object obj3 = 0;
				bool flag3 = false;
				float duration = num3;
				goto IL_026f;
			}
		}
		goto IL_04e6;
		IL_026f:
		if (_FreezeOnLastFrame)
		{
			List<Sprite> list4 = sprites;
			if (sprites == null)
			{
				goto IL_04e6;
			}
			object obj4 = list4._size - 1;
			if (_index == (nint)obj4)
			{
				return;
			}
		}
		if (!(_currentTimer > _triggerTimer))
		{
			return;
		}
		List<Sprite> list5 = sprites;
		int num4 = _index + 1;
		_currentTimer = 0f;
		_index = num4;
		if (sprites != null)
		{
			if (num4 >= list5._size)
			{
				if (_onComplete != null)
				{
					Action onComplete = _onComplete;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v802.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
				if (PlayManually)
				{
					_isPlayingManually = false;
					if (~(_hideWhenDone ? 1u : 0u) == 0)
					{
						if ((object)_image != null)
						{
							_image.enabled = false;
							return;
						}
						goto IL_04e6;
					}
					return;
				}
				if (~(_hideWhenDone ? 1u : 0u) == 0)
				{
					if ((object)_image == null)
					{
						goto IL_04e6;
					}
					_image.enabled = false;
					object obj3 = 0;
				}
				Action onComplete2 = OnComplete;
				_index = 0;
				if (OnComplete != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v762.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			}
			if (sprites != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				if ((object)_image != null)
				{
					Sprite sprite = default(Sprite);
					_image.sprite = sprite;
					RefreshScale();
					return;
				}
			}
		}
		goto IL_04e6;
		IL_04e6:
		throw new NullReferenceException();
	}

	public void Play(bool hideWhenDone = false, float startTimer = 0f)
	{
		Image image = _image;
		if ((object)_image == null || ((UnityEngine.Object)image).m_CachedPtr == (IntPtr)0)
		{
			Image component = GetComponent<Image>();
			_image = component;
		}
		_isPlayingManually = true;
		_image.enabled = true;
		_hideWhenDone = hideWhenDone;
		_currentTimer = 0f;
		Reset();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 200 Invalid \"Jump target not found in method: 0x186DFEA90\"");
		throw new NullReferenceException();
	}

	private void RefreshScale()
	{
		//IL_0145: Expected O, but got I
		//IL_0288->IL0189: Incompatible stack heights: 1 vs 0
		//IL_0300->IL0189: Incompatible stack heights: 1 vs 0
		//IL_0165->IL0189: Incompatible stack heights: 1 vs 0
		//IL_0091->IL0189: Incompatible stack heights: 1 vs 0
		//IL_02d7->IL0189: Incompatible stack heights: 2 vs 0
		//IL_022f->IL0189: Incompatible stack heights: 2 vs 0
		//IL_0188->IL0188: Incompatible stack heights: 2 vs 0
		//IL_00b4->IL00b4: Incompatible stack heights: 2 vs 0
		if (!_ScaleBasedOnSpriteSize)
		{
			goto IL_00b4;
		}
		Image image = _image;
		Rect ret;
		Rect ret2;
		Vector2 sizeDelta = default(Vector2);
		if ((object)_image != null)
		{
			Image sprite = (Image)(object)image.m_Sprite;
			if ((object)image.m_Sprite != null)
			{
				bool flag = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
				Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out ret);
				Image image2 = _image;
				if ((object)_image != null)
				{
					Image sprite2 = (Image)(object)image2.m_Sprite;
					if ((object)image2.m_Sprite != null)
					{
						bool flag2 = ((UnityEngine.Object)sprite2).m_CachedPtr == (IntPtr)0;
						Sprite.get_rect_Injected(((UnityEngine.Object)sprite2).m_CachedPtr, out ret2);
						if ((object)_rTrans != null)
						{
							_rTrans.sizeDelta = sizeDelta;
							goto IL_00b4;
						}
					}
				}
			}
		}
		goto IL_0189;
		IL_00b4:
		if (!ScaleBasedOnSpriteSizeWithoutMagic)
		{
			return;
		}
		Image image3 = _image;
		if ((object)_image != null)
		{
			Image sprite3 = (Image)(object)image3.m_Sprite;
			if ((object)image3.m_Sprite != null)
			{
				bool flag3 = ((UnityEngine.Object)sprite3).m_CachedPtr == (IntPtr)0;
				Sprite.get_rect_Injected(((UnityEngine.Object)sprite3).m_CachedPtr, out ret);
				UISpriteAnimation image4 = (UISpriteAnimation)(object)_image;
				if ((object)_image != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rbx_v13 (VampireSurvivors.UI.UISpriteAnimation)+E0]");
					UISpriteAnimation uISpriteAnimation = (UISpriteAnimation)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rbx_v13 (VampireSurvivors.UI.UISpriteAnimation)+E0]");
					if ((nint)0 != 0)
					{
						bool flag4 = ((UnityEngine.Object)uISpriteAnimation).m_CachedPtr == (IntPtr)0;
						Sprite.get_rect_Injected(((UnityEngine.Object)uISpriteAnimation).m_CachedPtr, out ret2);
						if ((object)_rTrans != null)
						{
							_rTrans.sizeDelta = sizeDelta;
							return;
						}
					}
				}
			}
		}
		goto IL_0189;
		IL_0189:
		throw new NullReferenceException();
	}

	public void SetScaleBasedOnSpriteSize(bool b)
	{
		_ScaleBasedOnSpriteSize = b;
	}

	public void SetCallback(Action cb)
	{
		_onComplete = cb;
	}

	public void SetFPS(int fps)
	{
		FPS = fps;
	}

	public void RecalculateTriggerTime()
	{
		float triggerTimer = 1f / (float)FPS;
		_triggerTimer = triggerTimer;
	}

	public void Reset()
	{
		List<Sprite> list = sprites;
		if (list._size > 0)
		{
			Sprite[] items = list._items;
			_image.sprite = items[0];
			_index = 0;
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public void Clean()
	{
		List<Sprite> list = sprites;
		int version = list._version + 1;
		list._version = version;
		list._size = 0;
		if (list._size > 0)
		{
			Array.Clear(list._items, 0, list._size);
		}
	}

	public void ResetScale()
	{
		//IL_006e->IL0038: Incompatible stack heights: 1 vs 0
		if (_UseCustomScaleTween)
		{
			Transform transform = base.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		}
	}

	public UISpriteAnimation()
	{
		List<Sprite> list = new List<Sprite>();
		sprites = list;
	}
}
