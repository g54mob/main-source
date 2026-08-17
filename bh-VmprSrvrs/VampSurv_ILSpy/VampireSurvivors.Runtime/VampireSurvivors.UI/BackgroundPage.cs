using System;
using System.Collections;
using System.Collections.Generic;
using Coherence.Cloud;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.App.Data.Adventures;
using VampireSurvivors.App.Scripts.Data;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI;

public class BackgroundPage : BaseUIPage
{
	private sealed class _003CWaitAndHideFader_003Ed__30(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public BackgroundPage _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_003b: Expected I4, but got I8
			//IL_0089: Expected I4, but got I8
			//IL_0120: Expected I4, but got O
			BackgroundPage backgroundPage = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null && (object)backgroundPage._Fader != null)
				{
					GameObject gameObject = backgroundPage._Fader.gameObject;
					if ((object)gameObject != null)
					{
						gameObject.SetActive(value: false);
						goto IL_010c;
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			goto IL_010c;
			IL_010c:
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

	private PixelateEffect _pixelateEffect;

	private TextMeshProUGUI _VersionText;

	private Image _Villain;

	private Image _Antonio;

	private Image _Imelda;

	private Image _Fader;

	private Image _AdventureSubtitleImage;

	public Animator _Animator;

	private Material _pixelizer;

	private Slider _slider;

	private SignalBus _signalBus;

	private PlayerOptions _playerOptions;

	private AdventureManager _adventureManager;

	private LobbiesManager _lobbiesManager;

	private static bool _hasPlayedSong;

	private bool _doTrumpetGag;

	private bool _doMirrorGag;

	private static readonly int CellSizeX;

	private static readonly int CellSizeY;

	private static readonly int PixelSize;

	private static readonly int TexSize;

	private void Construct(SignalBus signal, PlayerOptions playerOptions, AdventureManager adventureManager, LobbiesManager lobbiesManager)
	{
		_signalBus = signal;
		_playerOptions = playerOptions;
		_adventureManager = adventureManager;
		LobbiesManager lobbiesManager2 = default(LobbiesManager);
		_lobbiesManager = lobbiesManager2;
	}

	private void Start()
	{
		AdventureManager adventureManager = _adventureManager;
		if (_adventureManager != null)
		{
			Action<AdventureType> b = OnAdventureStarted;
			Delegate obj = Delegate.Combine(adventureManager._003COnAdventureStartedEvent_003Ek__BackingField, b);
			Delegate obj2 = default(Delegate);
			if ((object)obj == null)
			{
				obj2 = null;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				if ((object)obj2 == null)
				{
					throw new InvalidCastException();
				}
			}
			adventureManager._003COnAdventureStartedEvent_003Ek__BackingField = (Action<AdventureType>)obj2;
			AdventureManager adventureManager2 = _adventureManager;
			if (_adventureManager != null)
			{
				Action b2 = OnAdventureExit;
				Delegate obj3 = Delegate.Combine(adventureManager2._003COnAdventureExitEvent_003Ek__BackingField, b2);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(Action);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						goto IL_01b6;
					}
				}
				adventureManager2._003COnAdventureExitEvent_003Ek__BackingField = (Action)obj4;
				return;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		goto IL_01b6;
		IL_01b6:
		throw new InvalidCastException();
	}

	private void OnDestroy()
	{
		AdventureManager adventureManager = _adventureManager;
		if (_adventureManager != null)
		{
			Action<AdventureType> value = OnAdventureStarted;
			Delegate obj = Delegate.Remove(adventureManager._003COnAdventureStartedEvent_003Ek__BackingField, value);
			Delegate obj2 = default(Delegate);
			if ((object)obj == null)
			{
				obj2 = null;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				if ((object)obj2 == null)
				{
					throw new InvalidCastException();
				}
			}
			adventureManager._003COnAdventureStartedEvent_003Ek__BackingField = (Action<AdventureType>)obj2;
			AdventureManager adventureManager2 = _adventureManager;
			if (_adventureManager != null)
			{
				Action value2 = OnAdventureExit;
				Delegate obj3 = Delegate.Remove(adventureManager2._003COnAdventureExitEvent_003Ek__BackingField, value2);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(Action);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						goto IL_01b6;
					}
				}
				adventureManager2._003COnAdventureExitEvent_003Ek__BackingField = (Action)obj4;
				return;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		goto IL_01b6;
		IL_01b6:
		throw new InvalidCastException();
	}

	public void CompleteIntroAnimation()
	{
		_Animator.enabled = false;
		if (_doTrumpetGag)
		{
			_doTrumpetGag = false;
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleUI.DOFade(_Villain, 0f, 1.1f);
			TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleUI.DOFade(_Antonio, 0f, 1.1f);
			TweenerCore<Color, Color, ColorOptions> tweenerCore3 = DOTweenModuleUI.DOFade(_Imelda, 0f, 1.1f);
		}
	}

	public void ProceedToNextPage()
	{
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		LobbiesManager lobbiesManager = _lobbiesManager;
		if (lobbiesManager._activeLobby != null)
		{
			LobbySession activeLobby = lobbiesManager._activeLobby;
			if (!activeLobby._003CIsDisposed_003Ek__BackingField)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A978D0");
				return;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
	}

	public void PlayIntroSound()
	{
		//IL_0096: Expected O, but got I4
		if (!_hasPlayedSong)
		{
			PlayerOptionsData config = _playerOptions.Config;
			bool flag = config._003CClassicMusic_003Ek__BackingField;
			SfxType sfxType = SfxType.BGM_Intro;
			if (!flag)
			{
				sfxType = SfxType.BGM_IntroB;
			}
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(sfxType, soundConfig, 0f, 10, time);
			_hasPlayedSong = true;
		}
	}

	public static void AllowJinglePlayback()
	{
		_hasPlayedSong = false;
	}

	protected unsafe override void OnShowStart(GameObject g)
	{
		//IL_00d5: Expected O, but got Ref
		base.OnShowStart(g);
		_Animator.enabled = true;
		PlayerOptions playerOptions = _playerOptions;
		if (playerOptions._003CJustGotMirror_003Ek__BackingField)
		{
			_doMirrorGag = true;
			playerOptions._003CJustGotMirror_003Ek__BackingField = false;
		}
		PlayerOptions playerOptions2 = _playerOptions;
		if (playerOptions2._003CJustGotTrumpet_003Ek__BackingField)
		{
			_doTrumpetGag = true;
			playerOptions2._003CJustGotTrumpet_003Ek__BackingField = false;
		}
		if (_doMirrorGag)
		{
			_doMirrorGag = false;
			Transform transform = base.transform;
			object obj = default(object);
			transform.localEulerAngles = (Vector3)(&obj);
			RectMask2D component = GetComponent<RectMask2D>();
			component.enabled = false;
		}
		PlayerOptionsData config = _playerOptions.Config;
		bool flag = !config._003CShowTPCredits_003Ek__BackingField;
		float duration = 1f;
		if (!flag)
		{
			duration = 0.5f;
		}
		bool disableWhenFinished = default(bool);
		Tween tween = _pixelateEffect.Pixelate(50f, 1f, duration, disableWhenFinished);
		if (AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
		{
			SetupAdventureSubtitleImage();
		}
		_003CWaitAndHideFader_003Ed__30 obj2 = null;
		obj2._003C_003E1__state = 0;
		obj2._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj2);
	}

	private void OnEnable()
	{
		GameObject gameObject = _Fader.gameObject;
		gameObject.SetActive(value: true);
	}

	private IEnumerator WaitAndHideFader()
	{
		_003CWaitAndHideFader_003Ed__30 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void OnAdventureStarted(AdventureType adventureType)
	{
		SetupAdventureSubtitleImage();
	}

	private void OnAdventureExit()
	{
		GameObject gameObject = _AdventureSubtitleImage.gameObject;
		gameObject.SetActive(value: false);
	}

	private void SetupAdventureSubtitleImage()
	{
		GameObject gameObject = _AdventureSubtitleImage.gameObject;
		gameObject.SetActive(value: false);
		if (_adventureManager == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C0C0");
		object obj = default(object);
		if (obj == null)
		{
			return;
		}
		AdventureManager adventureManager = _adventureManager;
		AdventureData adventureData = adventureManager._003CAdventureData_003Ek__BackingField;
		if (adventureManager._003CAdventureData_003Ek__BackingField == null)
		{
			return;
		}
		CoreAdventureData coreAdventureData = adventureData._003CCoreAdventureData_003Ek__BackingField;
		string text = coreAdventureData._003CSubtitleImage_003Ek__BackingField;
		if (coreAdventureData._003CSubtitleImage_003Ek__BackingField == null || text._stringLength <= 0)
		{
			return;
		}
		Sprite sprite = SpriteManager.GetSprite(coreAdventureData._003CSubtitleImage_003Ek__BackingField);
		if ((object)sprite != null && ((UnityEngine.Object)sprite).m_CachedPtr != (IntPtr)0)
		{
			_AdventureSubtitleImage.sprite = sprite;
			GameObject gameObject2 = _AdventureSubtitleImage.gameObject;
			gameObject2.SetActive(value: true);
			AspectRatioFitter component = _AdventureSubtitleImage.GetComponent<AspectRatioFitter>();
			if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
			{
				component.aspectMode = AspectRatioFitter.AspectMode.None;
				_AdventureSubtitleImage.SetNativeSize();
				RectTransform component2 = _AdventureSubtitleImage.GetComponent<RectTransform>();
				Vector2 vector = default(Vector2);
				component2.sizeDelta = vector;
				Image adventureSubtitleImage = _AdventureSubtitleImage;
				Rect rect = adventureSubtitleImage.m_Sprite.rect;
				Image adventureSubtitleImage2 = _AdventureSubtitleImage;
				float aspectRatio = (float)vector / adventureSubtitleImage2.m_Sprite.rect.m_Height;
				component.aspectRatio = aspectRatio;
				component.aspectMode = AspectRatioFitter.AspectMode.WidthControlsHeight;
			}
		}
	}

	static BackgroundPage()
	{
		int cellSizeX = Shader.PropertyToID("_CellSizeX");
		CellSizeX = cellSizeX;
		int cellSizeY = Shader.PropertyToID("_CellSizeY");
		CellSizeY = cellSizeY;
		int pixelSize = Shader.PropertyToID("_PixelSize");
		PixelSize = pixelSize;
		int texSize = Shader.PropertyToID("_TexSize");
		TexSize = texSize;
	}
}
