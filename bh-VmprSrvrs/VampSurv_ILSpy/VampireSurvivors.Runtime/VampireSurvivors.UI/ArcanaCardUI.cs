using System;
using System.Collections;
using System.Collections.Generic;
using Coffee.UIEffects;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.UI;

public class ArcanaCardUI : SelectableUI
{
	private sealed class _003C_003Ec__DisplayClass48_0
	{
		public float val;

		public UIDissolve dissolve;

		internal float _003CModeChanged_003Eb__0()
		{
			return val;
		}

		internal void _003CModeChanged_003Eb__1(float x)
		{
			val = x;
		}

		internal void _003CModeChanged_003Eb__2()
		{
			//IL_0024: Invalid comparison between I4 and F4
			//IL_006f: Expected F4, but got I4
			UIDissolve uIDissolve = dissolve;
			float num = val;
			if (!(0f > val))
			{
				if (num > 1f)
				{
					num = 1f;
				}
			}
			else
			{
				num = 0f;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
			object obj = default(object);
			if (obj == null)
			{
				uIDissolve.m_EffectFactor = num;
				uIDissolve.SetEffectParamsDirty();
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass48_1
	{
		public float val;

		public UIDissolve dissolve;

		internal float _003CModeChanged_003Eb__4()
		{
			return val;
		}

		internal void _003CModeChanged_003Eb__5(float x)
		{
			val = x;
		}

		internal void _003CModeChanged_003Eb__6()
		{
			//IL_0024: Invalid comparison between I4 and F4
			//IL_006f: Expected F4, but got I4
			UIDissolve uIDissolve = dissolve;
			float num = val;
			if (!(0f > val))
			{
				if (num > 1f)
				{
					num = 1f;
				}
			}
			else
			{
				num = 0f;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
			object obj = default(object);
			if (obj == null)
			{
				uIDissolve.m_EffectFactor = num;
				uIDissolve.SetEffectParamsDirty();
			}
		}
	}

	private sealed class _003CWait_003Ed__62(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public float d;

		public ArcanaCardUI _003C_003E4__this;

		public int times;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0079: Expected I4, but got I8
			//IL_00d4: Expected I4, but got O
			ArcanaCardUI arcanaCardUI = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				WaitForSeconds waitForSeconds = null;
				waitForSeconds.m_Seconds = d;
				_003C_003E2__current = waitForSeconds;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				arcanaCardUI._spinTimes = times;
				Tween tween = _003C_003E4__this.GenerateFlipTween();
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	public bool _IsOpen;

	public Action<SelectableUI, ArcanaData, ArcanaType, Transform> OnArcanaCardSelected;

	public Action<ArcanaType> OnArcanaCardDeselected;

	private bool DEBUGTHIS;

	private GameObject _Selected;

	private Image _Icon;

	private Image _Transitioner;

	private Image _rarityIcon;

	private Image _editionIcon;

	private Material _foilMat;

	private Material _holoMat;

	private Material _polyMat;

	private Material _inveMat;

	private Material _galaMat;

	private CharacterSkillCard_Base _003CCharacterCard_003Ek__BackingField;

	private ArcanaData _data;

	private ArcanaType _type;

	private ISetArcanaInfo _selectionPage;

	private IArcanaDisplayContainer _displayContainer;

	private float _halfTime;

	private bool _isFlipping;

	private Vector3 _scale;

	private Tween _flipTween;

	private Tween _backTween;

	private int _spinTimes;

	private Selectable _cachedSelectable;

	private Sprite _back;

	private bool _interactable;

	private Tween _tween;

	private string _overrideBackFrameName;

	private bool _ignoreDarkana;

	public Selectable Selectable => _cachedSelectable;

	public CharacterSkillCard_Base CharacterCard
	{
		get
		{
			return _003CCharacterCard_003Ek__BackingField;
		}
		private set
		{
			_003CCharacterCard_003Ek__BackingField = value;
		}
	}

	private bool ShowEditionIcon
	{
		get
		{
			//IL_000a: Expected I4, but got O
			//IL_0021: Expected I4, but got O
			bool flag = (byte)(int)_003CCharacterCard_003Ek__BackingField != 0;
			if (_003CCharacterCard_003Ek__BackingField == null)
			{
				return (byte)(int)_003CCharacterCard_003Ek__BackingField != 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal1 @ rax_v1 (System.Boolean)+4C]");
			bool flag2 = (nint)0 < (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal1 @ rax_v1 (System.Boolean)+4C]");
			bool flag3 = (nint)0 == 0;
			bool flag4 = !flag2;
			bool flag5 = !flag3;
			return flag5 & flag4;
		}
	}

	private bool ShowRarityIcon
	{
		get
		{
			bool flag = (nint)_003CCharacterCard_003Ek__BackingField < 0;
			bool flag2 = _003CCharacterCard_003Ek__BackingField == null;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			return flag4 & flag3;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		Selectable component = GetComponent<Selectable>();
		_cachedSelectable = component;
		ArcanaMainSelectionPage.OnArcanaModeChange value = ModeChanged;
		ArcanaMainSelectionPage.ArcanaModeChanged += value;
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		ArcanaMainSelectionPage.OnArcanaModeChange value = ModeChanged;
		ArcanaMainSelectionPage.ArcanaModeChanged -= value;
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		if (_tween != null)
		{
			Tween tween = _tween;
			if (tween._003Cactive_003Ek__BackingField)
			{
				TweenExtensions.Complete(tween, withCallbacks: false);
			}
			_tween = null;
		}
	}

	protected override void OnSelected()
	{
		Action<SelectableUI, ArcanaData, ArcanaType, Transform> onArcanaCardSelected = OnArcanaCardSelected;
		if (OnArcanaCardSelected != null)
		{
			Transform transform = base.transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v4 @ rbp_v1 (System.Action`4<VampireSurvivors.UI.SelectableUI, VampireSurvivors.Data.ArcanaData, VampireSurvivors.Data.ArcanaType, UnityEngine.Transform>)+18] (should have been resolved before IL gen)");
		}
	}

	protected override void OnDeselected()
	{
		Action<ArcanaType> onArcanaCardDeselected = OnArcanaCardDeselected;
		if (OnArcanaCardDeselected != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v0 @ rax_v1 (System.Action`1<VampireSurvivors.Data.ArcanaType>)+18] (should have been resolved before IL gen)");
		}
	}

	public void SetData(ArcanaData data, ArcanaType type, ArcanaMainSelectionPage page)
	{
		_data = data;
		_type = type;
		_selectionPage = page;
		if (!data._003Cunlocked_003Ek__BackingField)
		{
			bool flag = _overrideBackFrameName == null;
			string spriteName = "back";
			if (!flag)
			{
				spriteName = _overrideBackFrameName;
			}
			Sprite sprite = SpriteManager.GetSprite(spriteName, "randomazzo");
			_Icon.sprite = sprite;
		}
		else
		{
			Sprite sprite2 = SpriteManager.GetSprite(data._003CframeName_003Ek__BackingField, "randomazzo");
			_Icon.sprite = sprite2;
			_IsOpen = true;
		}
	}

	public void SetData(ArcanaData data, ArcanaType type, ISetArcanaInfo page, bool isShowing)
	{
		_data = data;
		_type = type;
		_selectionPage = page;
		bool flag = _overrideBackFrameName == null;
		string spriteName = "back";
		if (!flag)
		{
			spriteName = _overrideBackFrameName;
		}
		Sprite sprite = SpriteManager.GetSprite(spriteName, "randomazzo");
		_back = sprite;
		object obj = default(object);
		if (obj == null)
		{
			SetClosed();
		}
		else
		{
			SetOpen();
		}
	}

	public void SetArcanaDisplayContainer(IArcanaDisplayContainer container)
	{
		_displayContainer = container;
	}

	private void ModeChanged(ArcanaMainSelectionPage.ArcanaMode m)
	{
		if (_ignoreDarkana)
		{
			return;
		}
		Button component = GetComponent<Button>();
		if (((Selectable)component).m_Interactable)
		{
			return;
		}
		TweenerCore<float, float, FloatOptions> tween;
		if (m != ArcanaMainSelectionPage.ArcanaMode.DARK)
		{
			_003C_003Ec__DisplayClass48_1 CS_0024_003C_003E8__locals10 = new _003C_003Ec__DisplayClass48_1();
			if (DEBUGTHIS)
			{
				Debug.Break();
			}
			bool flag = _overrideBackFrameName == null;
			string spriteName = "back";
			if (!flag)
			{
				spriteName = _overrideBackFrameName;
			}
			Sprite sprite = SpriteManager.GetSprite(spriteName, "randomazzo");
			_back = sprite;
			GameObject gameObject = _Transitioner.gameObject;
			gameObject.SetActive(value: true);
			Image icon = _Icon;
			_Transitioner.sprite = icon.m_Sprite;
			if (!_IsOpen)
			{
				SetClosed();
			}
			else
			{
				SetOpen();
			}
			Image icon2 = _Icon;
			_Icon.sprite = icon2.m_Sprite;
			UIDissolve component2 = _Transitioner.GetComponent<UIDissolve>();
			CS_0024_003C_003E8__locals10.dissolve = component2;
			CS_0024_003C_003E8__locals10.dissolve.effectFactor = 0f;
			CS_0024_003C_003E8__locals10.val = 0f;
			float duration = UnityEngine.Random.Range(0.35f, 0.45f);
			DOGetter<float> getter = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
			DOSetter<float> dOSetter = null;
			((_003C_003Ec__DisplayClass48_1)(object)dOSetter)._003CModeChanged_003Eb__5(0.45f);
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, 1f, duration);
			TweenCallback tweenCallback = delegate
			{
				//IL_0024: Invalid comparison between I4 and F4
				//IL_006f: Expected F4, but got I4
				UIDissolve dissolve = CS_0024_003C_003E8__locals10.dissolve;
				float num = CS_0024_003C_003E8__locals10.val;
				if (!(0f > CS_0024_003C_003E8__locals10.val))
				{
					if (num > 1f)
					{
						num = 1f;
					}
				}
				else
				{
					num = 0f;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
				object obj = default(object);
				if (obj == null)
				{
					dissolve.m_EffectFactor = num;
					dissolve.SetEffectParamsDirty();
				}
			};
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v785 @ rax_v59 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
			float delay = UnityEngine.Random.Range(0f, 0.2f);
			TweenerCore<float, float, FloatOptions> tweenerCore2 = TweenSettingsExtensions.SetDelay(tweenerCore, delay);
			TweenCallback tweenCallback2 = delegate
			{
				Image transitioner = _Transitioner;
				if ((object)_Transitioner != null && ((UnityEngine.Object)transitioner).m_CachedPtr != (IntPtr)0)
				{
					GameObject gameObject3 = _Transitioner.gameObject;
					gameObject3.SetActive(value: false);
				}
			};
			bool flag2 = tweenerCore2 == null;
			tween = tweenerCore2;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v987 @ rax_v63 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				bool flag3 = (nint)0 == 0;
				tween = tweenerCore2;
				if (!flag3)
				{
					tween = tweenerCore2;
				}
			}
		}
		else
		{
			_003C_003Ec__DisplayClass48_0 CS_0024_003C_003E8__locals13 = new _003C_003Ec__DisplayClass48_0();
			GameObject gameObject2 = _Transitioner.gameObject;
			gameObject2.SetActive(value: true);
			Sprite sprite2 = SpriteManager.GetSprite("darkana_card", "darkana_card");
			_Transitioner.sprite = sprite2;
			UIDissolve component3 = _Transitioner.GetComponent<UIDissolve>();
			CS_0024_003C_003E8__locals13.dissolve = component3;
			CS_0024_003C_003E8__locals13.dissolve.effectFactor = 1f;
			CS_0024_003C_003E8__locals13.val = 1f;
			float duration2 = UnityEngine.Random.Range(0.35f, 0.45f);
			DOGetter<float> getter2 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
			DOSetter<float> dOSetter2 = null;
			((_003C_003Ec__DisplayClass48_0)(object)dOSetter2)._003CModeChanged_003Eb__1(0.45f);
			TweenerCore<float, float, FloatOptions> tweenerCore3 = DOTween.To(getter2, dOSetter2, 0f, duration2);
			TweenCallback tweenCallback3 = delegate
			{
				//IL_0024: Invalid comparison between I4 and F4
				//IL_006f: Expected F4, but got I4
				UIDissolve dissolve = CS_0024_003C_003E8__locals13.dissolve;
				float num = CS_0024_003C_003E8__locals13.val;
				if (!(0f > CS_0024_003C_003E8__locals13.val))
				{
					if (num > 1f)
					{
						num = 1f;
					}
				}
				else
				{
					num = 0f;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
				object obj = default(object);
				if (obj == null)
				{
					dissolve.m_EffectFactor = num;
					dissolve.SetEffectParamsDirty();
				}
			};
			if (tweenerCore3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v634 @ rax_v23 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
			float delay2 = UnityEngine.Random.Range(0f, 0.2f);
			TweenerCore<float, float, FloatOptions> tweenerCore4 = TweenSettingsExtensions.SetDelay(tweenerCore3, delay2);
			TweenCallback tweenCallback4 = delegate
			{
				Image icon3 = _Icon;
				if ((object)_Icon != null && ((UnityEngine.Object)icon3).m_CachedPtr != (IntPtr)0)
				{
					Sprite sprite3 = SpriteManager.GetSprite("darkana_card", "darkana_card");
					_Icon.sprite = sprite3;
				}
				Image transitioner = _Transitioner;
				if ((object)_Transitioner != null && ((UnityEngine.Object)transitioner).m_CachedPtr != (IntPtr)0)
				{
					GameObject gameObject3 = _Transitioner.gameObject;
					gameObject3.SetActive(value: false);
				}
				Sprite sprite4 = SpriteManager.GetSprite("darkana_card", "darkana_card");
				_back = sprite4;
			};
			bool flag4 = tweenerCore4 == null;
			tween = tweenerCore4;
			if (!flag4)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v729 @ rax_v27 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				bool flag5 = (nint)0 == 0;
				tween = tweenerCore4;
				if (!flag5)
				{
					tween = tweenerCore4;
				}
			}
		}
		_tween = tween;
	}

	public void SetOwned()
	{
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A968E0");
		object obj = default(object);
		if (obj != null)
		{
			UICornersGradient component = _Icon.GetComponent<UICornersGradient>();
			component.enabled = true;
		}
	}

	public void SetData(ArcanaData data, ArcanaType t, bool isOpen = false, bool isInteractable = false)
	{
		_data = data;
		_type = t;
		bool flag = _overrideBackFrameName == null;
		bool interactable = default(bool);
		_interactable = interactable;
		string spriteName = "back";
		if (!flag)
		{
			spriteName = _overrideBackFrameName;
		}
		Sprite sprite = SpriteManager.GetSprite(spriteName, "randomazzo");
		_back = sprite;
		if (!isOpen)
		{
			SetClosed();
		}
		else
		{
			SetOpen();
		}
		Button component = GetComponent<Button>();
		component.interactable = interactable;
	}

	public void SetDarkBack()
	{
		Sprite sprite = SpriteManager.GetSprite("darkana_card", "darkana_card");
		_back = sprite;
		if (!_IsOpen)
		{
			_Icon.sprite = _back;
		}
	}

	public void SetBackOnly()
	{
		SetClosed();
		bool flag = _overrideBackFrameName == null;
		string spriteName = "back";
		if (!flag)
		{
			spriteName = _overrideBackFrameName;
		}
		Sprite sprite = SpriteManager.GetSprite(spriteName, "randomazzo");
		_Icon.sprite = sprite;
		CanvasGroup component = GetComponent<CanvasGroup>();
		CanvasGroup canvasGroup;
		if ((object)component != null)
		{
			bool flag2 = ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0;
			canvasGroup = component;
			if (flag2)
			{
				goto IL_00b8;
			}
		}
		GameObject gameObject = base.gameObject;
		CanvasGroup canvasGroup2 = gameObject.AddComponent<CanvasGroup>();
		canvasGroup = canvasGroup2;
		goto IL_00b8;
		IL_00b8:
		canvasGroup.interactable = false;
		canvasGroup.blocksRaycasts = false;
	}

	public unsafe void SetGreyBackOnly()
	{
		//IL_0040: Expected O, but got Ref
		SetClosed();
		Sprite sprite = SpriteManager.GetSprite("deback");
		_Icon.sprite = sprite;
		object obj = default(object);
		_Icon.color = (Color)(&obj);
	}

	public void OnClick()
	{
		//IL_0149: Expected I, but got O
		//IL_0157: Expected I, but got O
		//IL_0167: Expected O, but got I
		//IL_01a3: Expected O, but got I
		if (_data == null)
		{
			return;
		}
		if (_selectionPage == null)
		{
			if (_displayContainer != null)
			{
				Transform transform = base.transform;
				_displayContainer.ToggleArcanaInfoPanel(this, _data, _type, null, toggleFromClick: false, toggleFromSelectionChange: false);
			}
			return;
		}
		ArcanaData data = _data;
		ISetArcanaInfo selectionPage;
		ArcanaData data2;
		ArcanaType type;
		if (data._003Cunlocked_003Ek__BackingField)
		{
			GameManager core = GM.Core;
			ArcanaManager arcanaManager = core._arcanaManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A968E0");
			object obj = default(object);
			if (obj == null)
			{
				selectionPage = _selectionPage;
				data2 = _data;
				type = _type;
				goto IL_01f3;
			}
		}
		ISetArcanaInfo selectionPage2 = _selectionPage;
		if (_selectionPage != null)
		{
			nint num = (nint)selectionPage2;
			nint num2 = (nint)typeof(SurvarotsSelectionPage);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ rdx_v10 (Il2CppClass<VampireSurvivors.UI.SurvarotsSelectionPage>)+130]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ r8_v9 (Il2CppClass<VampireSurvivors.UI.ISetArcanaInfo>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ rdx_v10 (Il2CppClass<VampireSurvivors.UI.SurvarotsSelectionPage>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ r8_v9 (Il2CppClass<VampireSurvivors.UI.ISetArcanaInfo>)+C8]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rax_v22+FFFFFFF8+v234 @ rax_v21*8]");
				if (0 == (nint)typeof(SurvarotsSelectionPage))
				{
					selectionPage = _selectionPage;
					data2 = _data;
					type = _type;
					goto IL_01f3;
				}
				return;
			}
			return;
		}
		return;
		IL_01f3:
		selectionPage.SetInfo(data2, type, this);
	}

	public void SetActiveSelection(bool b)
	{
		_Selected.SetActive(b);
	}

	public Tween Reveal(float delay = 0f)
	{
		if (!_isFlipping)
		{
			_isFlipping = true;
			Transform transform = base.transform;
			bool flag = (object)transform == null;
			bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			if (_flipTween != null)
			{
				Tween flipTween = _flipTween;
				if (flipTween._003Cactive_003Ek__BackingField)
				{
					TweenExtensions.Kill(flipTween);
				}
			}
			Tween flipTween2 = GenerateFlipTween(delay);
			_flipTween = flipTween2;
			return _flipTween;
		}
		return null;
	}

	private unsafe Tween GenerateFlipTween(float delay = 0f)
	{
		//IL_0089: Expected O, but got Ref
		Transform target = base.transform;
		object obj = default(object);
		TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOScale(target, (Vector3)(&obj), _halfTime);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = TweenSettingsExtensions.SetDelay(t, delay);
		TweenCallback tweenCallback = delegate
		{
			//IL_0096: Expected O, but got Ref
			bool isOpen = !_IsOpen;
			_IsOpen = isOpen;
			if (~(_IsOpen ? 1u : 0u) == 0)
			{
				SetClosed();
			}
			else
			{
				SetOpen();
			}
			if (_backTween != null)
			{
				Tween backTween = _backTween;
				if (backTween._003Cactive_003Ek__BackingField)
				{
					TweenExtensions.Kill(backTween);
				}
			}
			Transform target2 = base.transform;
			object obj2 = default(object);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(target2, (Vector3)(&obj2), _halfTime);
			TweenCallback tweenCallback2 = delegate
			{
				_isFlipping = false;
				if (_spinTimes > 0)
				{
					int spinTimes = _spinTimes - 1;
					_spinTimes = spinTimes;
					Tween tween = Reveal();
				}
			};
			if (tweenerCore2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rax_v6 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
			_backTween = tweenerCore2;
		};
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rax_v4 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		return tweenerCore;
	}

	public void KillReveal()
	{
		if (_backTween != null)
		{
			Tween backTween = _backTween;
			if (backTween._003Cactive_003Ek__BackingField)
			{
				TweenExtensions.Kill(backTween);
			}
		}
		if (_flipTween != null)
		{
			Tween flipTween = _flipTween;
			if (flipTween._003Cactive_003Ek__BackingField)
			{
				TweenExtensions.Kill(flipTween);
			}
		}
	}

	public unsafe void Hide()
	{
		//IL_0061: Expected O, but got Ref
		if (_backTween != null)
		{
			Tween backTween = _backTween;
			if (backTween._003Cactive_003Ek__BackingField)
			{
				TweenExtensions.Kill(backTween);
			}
		}
		Transform target = base.transform;
		object obj = default(object);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, (Vector3)(&obj), _halfTime);
		TweenCallback tweenCallback = delegate
		{
			_isFlipping = false;
		};
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v4 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		_backTween = tweenerCore;
	}

	public Tween Spin(int spinTimes)
	{
		_spinTimes = spinTimes;
		return GenerateFlipTween();
	}

	public void SpinDelay(float delay, int times)
	{
		_003CWait_003Ed__62 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.d = delay;
		obj.times = times;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private IEnumerator Wait(float d, int times)
	{
		_003CWait_003Ed__62 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.d = d;
		obj.times = times;
		return obj;
	}

	public void ChangeSide()
	{
		bool isOpen = !_IsOpen;
		_IsOpen = isOpen;
		if (~(_IsOpen ? 1u : 0u) == 0)
		{
			SetClosed();
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 28 Invalid \"Jump target not found in method: 0x18776DCB0\"");
		}
	}

	public void SetOpen()
	{
		//IL_020e: Expected O, but got I4
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Expected O, but got Unknown
		//IL_0241: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Expected O, but got Unknown
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Expected O, but got Unknown
		ArcanaData data = _data;
		Sprite sprite = SpriteManager.GetSprite(data._003CframeName_003Ek__BackingField, "randomazzo");
		_Icon.sprite = sprite;
		_IsOpen = true;
		if ((object)_rarityIcon != null)
		{
			GameObject gameObject = _rarityIcon.gameObject;
			bool flag = (nint)_003CCharacterCard_003Ek__BackingField < 0;
			bool flag2 = _003CCharacterCard_003Ek__BackingField == null;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			bool active = flag4 & flag3;
			gameObject.SetActive(active);
		}
		if ((object)_editionIcon != null)
		{
			GameObject gameObject2 = _editionIcon.gameObject;
			CharacterSkillCard_Base characterSkillCard_Base = _003CCharacterCard_003Ek__BackingField;
			bool active2;
			if (_003CCharacterCard_003Ek__BackingField == null)
			{
				active2 = false;
			}
			else
			{
				bool flag5 = characterSkillCard_Base.Edition < SkillCardEdition.Base;
				bool flag6 = characterSkillCard_Base.Edition == SkillCardEdition.Base;
				bool flag7 = !flag5;
				bool flag8 = !flag6;
				active2 = flag8 & flag7;
			}
			gameObject2.SetActive(active2);
		}
		CharacterSkillCard_Base characterSkillCard_Base2 = _003CCharacterCard_003Ek__BackingField;
		if (_003CCharacterCard_003Ek__BackingField == null)
		{
			return;
		}
		bool flag9 = characterSkillCard_Base2.Edition == SkillCardEdition.Base;
		if (characterSkillCard_Base2.Edition <= SkillCardEdition.Base)
		{
			return;
		}
		object obj = characterSkillCard_Base2.Edition - 1;
		Material material;
		if (!flag9)
		{
			object obj2 = obj - 1;
			if (!flag9)
			{
				object obj3 = obj2 - 1;
				if (!flag9)
				{
					object obj4 = obj3 - 1;
					material = (flag9 ? _inveMat : (((nint)obj4 == 1) ? _galaMat : null));
				}
				else
				{
					material = _polyMat;
				}
			}
			else
			{
				material = _holoMat;
			}
		}
		else
		{
			material = _foilMat;
		}
		_Icon.material = material;
	}

	public void SetClosed()
	{
		_Icon.sprite = _back;
		_IsOpen = false;
		if ((object)_rarityIcon != null)
		{
			GameObject gameObject = _rarityIcon.gameObject;
			gameObject.SetActive(value: false);
		}
		if ((object)_editionIcon != null)
		{
			GameObject gameObject2 = _editionIcon.gameObject;
			gameObject2.SetActive(value: false);
		}
		CharacterSkillCard_Base characterSkillCard_Base = _003CCharacterCard_003Ek__BackingField;
		if (_003CCharacterCard_003Ek__BackingField != null && characterSkillCard_Base.Edition > SkillCardEdition.Base)
		{
			_Icon.material = null;
		}
	}

	public ArcanaData GetData()
	{
		return _data;
	}

	public ArcanaType GetArcanaType()
	{
		return _type;
	}

	public void OverrideBackFrameName(string frameName)
	{
		_overrideBackFrameName = frameName;
		Sprite back = _back;
		if ((object)_back != null && ((UnityEngine.Object)back).m_CachedPtr != (IntPtr)0)
		{
			bool flag = _overrideBackFrameName == null;
			string spriteName = "back";
			if (!flag)
			{
				spriteName = _overrideBackFrameName;
			}
			Sprite sprite = SpriteManager.GetSprite(spriteName, "randomazzo");
			_back = sprite;
		}
	}

	public void SetIgnoreDarkana()
	{
		_ignoreDarkana = true;
	}

	public unsafe void SetCharacterCard(CharacterSkillCard_Base characterCard)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected I4, but got Unknown
		//IL_00eb: Expected O, but got Ref
		//IL_0155: Expected O, but got I4
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Expected O, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Expected O, but got Unknown
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Expected O, but got Unknown
		_003CCharacterCard_003Ek__BackingField = characterCard;
		GameObject gameObject = _rarityIcon.gameObject;
		gameObject.SetActive(value: true);
		int num = characterCard + 56;
		string text = ((int*)num)->ToString();
		string spriteName = "SVStar" + text;
		Sprite sprite = SpriteManager.GetSprite(spriteName, "randomazzo");
		_rarityIcon.sprite = sprite;
		_rarityIcon.SetNativeSize();
		if (characterCard.Edition != SkillCardEdition.Base)
		{
			GameObject gameObject2 = _editionIcon.gameObject;
			gameObject2.SetActive(value: true);
			object obj = default(object);
			string text2 = ((Enum)(&obj)).ToString();
			string spriteName2 = text2.ToUpper();
			Sprite sprite2 = SpriteManager.GetSprite(spriteName2, "randomazzo");
			bool flag = (object)_editionIcon == null;
			_editionIcon.sprite = sprite2;
			object obj2 = characterCard.Edition - 1;
			Material material;
			if (!flag)
			{
				object obj3 = obj2 - 1;
				if (!flag)
				{
					object obj4 = obj3 - 1;
					if (!flag)
					{
						object obj5 = obj4 - 1;
						material = (flag ? _inveMat : (((nint)obj5 == 1) ? _galaMat : null));
					}
					else
					{
						material = _polyMat;
					}
				}
				else
				{
					material = _holoMat;
				}
			}
			else
			{
				material = _foilMat;
			}
			_Icon.material = material;
			GameObject gameObject3 = _Icon.gameObject;
			UIImageUVRemap uIImageUVRemap = gameObject3.AddComponent<UIImageUVRemap>();
		}
		else
		{
			GameObject gameObject4 = _editionIcon.gameObject;
			gameObject4.SetActive(value: false);
		}
	}

	public ArcanaCardUI()
	{
		//IL_0020: Expected I, but got O
		//IL_007c: Expected I, but got O
		_halfTime = 0.1f;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rax_v2 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		_scale = Vector3.oneVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdx_v1 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		_ = 0;
		base._ShowSelector = true;
		base._ShouldUpdatePositionWhenForcingDumbFix = true;
		ReselectIfDefaultSelectedOnPage = true;
		nint num3 = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rcx_v3 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	private void _003CModeChanged_003Eb__48_3()
	{
		Image icon = _Icon;
		if ((object)_Icon != null && ((UnityEngine.Object)icon).m_CachedPtr != (IntPtr)0)
		{
			Sprite sprite = SpriteManager.GetSprite("darkana_card", "darkana_card");
			_Icon.sprite = sprite;
		}
		Image transitioner = _Transitioner;
		if ((object)_Transitioner != null && ((UnityEngine.Object)transitioner).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject = _Transitioner.gameObject;
			gameObject.SetActive(value: false);
		}
		Sprite sprite2 = SpriteManager.GetSprite("darkana_card", "darkana_card");
		_back = sprite2;
	}

	private void _003CModeChanged_003Eb__48_7()
	{
		Image transitioner = _Transitioner;
		if ((object)_Transitioner != null && ((UnityEngine.Object)transitioner).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject = _Transitioner.gameObject;
			gameObject.SetActive(value: false);
		}
	}

	private unsafe void _003CGenerateFlipTween_003Eb__57_0()
	{
		//IL_0096: Expected O, but got Ref
		bool isOpen = !_IsOpen;
		_IsOpen = isOpen;
		if (~(_IsOpen ? 1u : 0u) == 0)
		{
			SetClosed();
		}
		else
		{
			SetOpen();
		}
		if (_backTween != null)
		{
			Tween backTween = _backTween;
			if (backTween._003Cactive_003Ek__BackingField)
			{
				TweenExtensions.Kill(backTween);
			}
		}
		Transform target = base.transform;
		object obj = default(object);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, (Vector3)(&obj), _halfTime);
		TweenCallback tweenCallback = delegate
		{
			_isFlipping = false;
			if (_spinTimes > 0)
			{
				int spinTimes = _spinTimes - 1;
				_spinTimes = spinTimes;
				Tween tween = Reveal();
			}
		};
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rax_v6 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		_backTween = tweenerCore;
	}

	private void _003CGenerateFlipTween_003Eb__57_1()
	{
		_isFlipping = false;
		if (_spinTimes > 0)
		{
			int spinTimes = _spinTimes - 1;
			_spinTimes = spinTimes;
			Tween tween = Reveal();
		}
	}

	private void _003CHide_003Eb__59_0()
	{
		_isFlipping = false;
	}
}
