using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using TMPro;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UI;
using VampireSurvivors.App.Scripts.UI;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.DLC;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;

namespace VampireSurvivors.UI;

public class TPCreditsPage : BaseUIPage
{
	private sealed class _003C_003Ec__DisplayClass48_0
	{
		public TPCreditsPage _003C_003E4__this;

		public BgmType bgmToLoad;

		internal void _003COnShowStart_003Eb__0()
		{
			TPCreditsPage tPCreditsPage = _003C_003E4__this;
			tPCreditsPage._loadingComplete = true;
			TPCreditsPage tPCreditsPage2 = _003C_003E4__this;
			tPCreditsPage2._sceneInstance.Initialize(_003C_003E4__this);
			_003CWaitAndPlay_003Ed__54 obj = null;
			obj._003C_003E1__state = 0;
			obj._003C_003E4__this = _003C_003E4__this;
			Coroutine coroutine = _003C_003E4__this.StartCoroutine(obj);
		}

		internal void _003COnShowStart_003Eb__1(Action cb)
		{
			TPCreditsPage tPCreditsPage = _003C_003E4__this;
			DlcType? bgmDlcType = DlcSystem._utils.GetBgmDlcType(bgmToLoad, tPCreditsPage._data);
			AudioLoader.LoadBgmAsync(bgmToLoad, CACHE_GROUP_NAME, bgmDlcType, cb);
		}
	}

	private sealed class _003CWaitAndFormatPortrait_003Ed__52(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public TPCreditsPage _003C_003E4__this;

		private float _003Cheight_003E5__2;

		private float _003Cwidth_003E5__3;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_01c4: Expected I4, but got I8
			//IL_004d: Expected O, but got I4
			//IL_014c: Expected I4, but got I8
			//IL_008a: Expected I4, but got I8
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Expected O, but got Unknown
			//IL_02ea->IL0236: Incompatible stack heights: 1 vs 0
			//IL_0236->IL0335: Incompatible stack heights: 2 vs 0
			TPCreditsPage tPCreditsPage = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				Vector2 vector = default(Vector2);
				if (!flag)
				{
					if ((nint)obj != 1)
					{
						goto IL_012f;
					}
					_003C_003E1__state = -1;
					if ((object)_003C_003E4__this != null && (object)tPCreditsPage._Rotator != null)
					{
						_ = -90f;
						object obj2 = default(object);
						Vector3 localEulerAngles = (Vector3)(obj2 - 56);
						tPCreditsPage._Rotator.localEulerAngles = localEulerAngles;
						if ((object)tPCreditsPage._Rotator != null)
						{
							tPCreditsPage._Rotator.sizeDelta = vector;
							goto IL_012f;
						}
					}
				}
				else
				{
					_003C_003E1__state = -1;
					if ((object)_003C_003E4__this != null && (object)tPCreditsPage._Rotator != null)
					{
						tPCreditsPage._Rotator.anchorMin = vector;
						if ((object)tPCreditsPage._Rotator != null)
						{
							tPCreditsPage._Rotator.anchorMax = vector;
							_003C_003E2__current = null;
							_003C_003E1__state = 2;
							goto IL_0335;
						}
					}
				}
			}
			else
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					RectTransform rotator = tPCreditsPage._Rotator;
					if ((object)tPCreditsPage._Rotator != null)
					{
						bool flag2 = ((UnityEngine.Object)rotator).m_CachedPtr == (IntPtr)0;
						RectTransform.get_rect_Injected(((UnityEngine.Object)rotator).m_CachedPtr, out Rect _);
						float num = default(float);
						_003Cheight_003E5__2 = num;
						TPCreditsPage rotator2 = (TPCreditsPage)(object)tPCreditsPage._Rotator;
						if ((object)tPCreditsPage._Rotator != null)
						{
							bool flag3 = ((UnityEngine.Object)rotator2).m_CachedPtr == (IntPtr)0;
							RectTransform.get_rect_Injected(((UnityEngine.Object)rotator2).m_CachedPtr, out Rect _);
							float num2 = default(float);
							_003Cwidth_003E5__3 = num2;
							_003C_003E2__current = null;
							_003C_003E1__state = 1;
							goto IL_0335;
						}
					}
				}
			}
			throw new NullReferenceException();
			IL_012f:
			return false;
			IL_0335:
			return true;
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

	private sealed class _003CWaitAndHide_003Ed__51(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public TPCreditsPage _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0062: Expected I4, but got I8
			//IL_00f2: Expected I4, but got O
			TPCreditsPage tPCreditsPage = _003C_003E4__this;
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
				if ((object)_003C_003E4__this != null && tPCreditsPage.SignalBus != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1AE0");
					if (tPCreditsPage.SignalBus != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1BC0");
						goto IL_00de;
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			goto IL_00de;
			IL_00de:
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

	private sealed class _003CWaitAndPlay_003Ed__54(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public TPCreditsPage _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_05b2: Expected I4, but got I8
			//IL_0039: Expected O, but got I4
			//IL_03aa: Expected I4, but got I8
			//IL_0076: Expected I4, but got I8
			//IL_0570: Expected O, but got I4
			//IL_06f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_06fe: Expected O, but got Unknown
			//IL_0617: Expected O, but got I4
			//IL_0530->IL06c3: Incompatible stack heights: 6 vs 3
			//IL_05a3->IL071f: Incompatible stack heights: 6 vs 0
			//IL_02f3->IL02f3: Incompatible stack heights: 15 vs 11
			//IL_038d->IL038d: Incompatible stack heights: 16 vs 0
			TPCreditsPage tPCreditsPage = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (!flag)
				{
					if ((nint)obj == 1)
					{
						_003C_003E1__state = -1;
						bool flag2 = (object)_003C_003E4__this == null;
						bool flag3 = tPCreditsPage._playerOptions == null;
						PlayerOptionsData config = tPCreditsPage._playerOptions.Config;
						bool flag4 = config == null;
						SoundManager.StopMusic(config._003CSelectedBGM_003Ek__BackingField);
						bool flag5 = tPCreditsPage._playerOptions == null;
						PlayerOptionsData config2 = tPCreditsPage._playerOptions.Config;
						bool flag6 = config2 == null;
						config2._003CSelectedBGM_003Ek__BackingField = BgmType.BGM_TP_SOH_Credits;
						SoundManager._003CCurrentBgm_003Ek__BackingField = BgmType.BGM_TP_SOH_Credits;
						bool flag7 = (object)tPCreditsPage._Animator == null;
						RuntimeAnimatorController runtimeAnimatorController = tPCreditsPage._Animator.runtimeAnimatorController;
						bool flag8 = (object)runtimeAnimatorController == null;
						AnimationClip[] animationClips = runtimeAnimatorController.animationClips;
						bool flag9 = animationClips == null;
						bool flag10 = (object)animationClips[0] == null;
						float length = animationClips[0].length;
						tPCreditsPage._animLength = length;
						tPCreditsPage._isPlaying = true;
						SoundManager.PlayMusic(BgmType.BGM_TP_SOH_Credits, new SoundManager.SoundConfig
						{
							Volume = (float?)(object)1,
							Rate = 1f
						});
						bool flag11 = tPCreditsPage._playerOptions == null;
						PlayerOptionsData config3 = tPCreditsPage._playerOptions.Config;
						bool flag12 = config3 == null;
						if (!(0.05f < config3._003CMusicVolume_003Ek__BackingField))
						{
							PlaylistController onlyPlaylistController = MasterAudio.OnlyPlaylistController;
							bool flag13 = (object)onlyPlaylistController == null;
							AudioSource activeAudioSource = onlyPlaylistController.ActiveAudioSource;
							bool flag14 = tPCreditsPage._playerOptions == null;
							PlayerOptionsData config4 = tPCreditsPage._playerOptions.Config;
							bool flag15 = config4 == null;
							bool flag16 = (object)activeAudioSource == null;
							activeAudioSource.volume = config4._003CSoundsVolume_003Ek__BackingField;
						}
						TPCreditsScene sceneInstance = tPCreditsPage._sceneInstance;
						tPCreditsPage._syncAudioCheck = true;
						bool flag17 = (object)tPCreditsPage._sceneInstance == null;
						bool flag18 = (object)sceneInstance._AnimCamera == null;
						sceneInstance._AnimCamera.SetActive(value: true);
						Canvas canvas = UIHelper.Canvas;
						bool flag19 = (object)canvas == null;
						bool flag20 = ((UnityEngine.Object)canvas).m_CachedPtr == (IntPtr)0;
						Canvas.set_renderMode_Injected(((UnityEngine.Object)canvas).m_CachedPtr, RenderMode.ScreenSpaceOverlay);
						bool flag21 = (object)tPCreditsPage._Overlay == null;
						tPCreditsPage._Overlay.SetActive(value: false);
					}
					return false;
				}
				_003C_003E1__state = -1;
				bool flag22 = (object)_003C_003E4__this == null;
				string thosePeopleCreditsText = Credits.GetThosePeopleCreditsText();
				bool flag23 = (object)tPCreditsPage._TextPrefab == null;
				TextMeshProUGUI component = tPCreditsPage._TextPrefab.GetComponent<TextMeshProUGUI>();
				bool flag24 = (object)component == null;
				component.text = thosePeopleCreditsText;
				tPCreditsPage._widthCounter = 0f;
				int num = 0;
				do
				{
					WiggleTween wiggleTween = new WiggleTween();
					bool flag25 = wiggleTween == null;
					wiggleTween.Start(num);
					List<object> movementTweens = (List<object>)(object)tPCreditsPage._movementTweens;
					bool flag26 = tPCreditsPage._movementTweens == null;
					int version = movementTweens._version + 1;
					movementTweens._version = version;
					object[] items = movementTweens._items;
					bool flag27 = movementTweens._items == null;
					if (movementTweens._size >= items.Length)
					{
						((List<object>)(object)tPCreditsPage._movementTweens).AddWithResize((object)wiggleTween);
					}
					else
					{
						int size = movementTweens._size + 1;
						movementTweens._size = size;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					num++;
				}
				while (num < 10);
				_003C_003E4__this.CreateEnemyList();
				_003C_003E4__this.CreateCharacterList();
				bool flag28 = tPCreditsPage._congaLength <= 0;
				object obj2 = 0;
				if (!flag28)
				{
					do
					{
						_003C_003E4__this.GetNextCharacter();
						obj2++;
					}
					while ((nint)obj2 < tPCreditsPage._congaLength);
				}
				_003C_003E2__current = null;
				_003C_003E1__state = 2;
				return true;
			}
			_003C_003E1__state = -1;
			_003C_003E2__current = null;
			_003C_003E1__state = 1;
			return true;
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

	public static CharacterType[] CharactersToUnlocks = new CharacterType[19]
	{
		CharacterType.TP_LISA,
		CharacterType.TP_MINA,
		CharacterType.TP_CORNELL,
		CharacterType.TP_RINALDO,
		CharacterType.TP_VINCENT,
		CharacterType.TP_NATHAN,
		CharacterType.TP_JULIA,
		CharacterType.TP_SARA,
		CharacterType.TP_QUINCY,
		CharacterType.TP_MAXIM,
		CharacterType.TP_REINHARDT,
		CharacterType.TP_HENRY,
		CharacterType.TP_CARRIE,
		CharacterType.TP_STGERMAIN,
		CharacterType.TP_ALBUS,
		CharacterType.TP_ISAAC,
		CharacterType.TP_ELIZABETH,
		CharacterType.TP_SHAFT,
		CharacterType.TP_BARLOWE
	};

	private RectTransform _Container;

	private GameObject _TextPrefab;

	private TextMeshProUGUI _Title;

	private RectTransform _CongaContainer;

	private GameObject _CongaItem;

	private CanvasGroup _NowLoading;

	private TPCreditsScene _ScenePrefab;

	private AnimationClip _Animation;

	private Animator _Animator;

	private GameObject _Hand;

	private Image _EndFlash;

	private RectTransform _Rotator;

	private GameObject _Overlay;

	private GameObject _VideoDisplay;

	private Material _NowLoadingMaterial;

	private float _NowLoadingInputSpeed;

	private PlayerOptions _playerOptions;

	private DataManager _data;

	private MultiplayerManager _multiplayerManager;

	public static string CACHE_GROUP_NAME = "TP_CREDITS";

	private TPCreditsScene _sceneInstance;

	private List<WiggleTween> _movementTweens;

	private List<EnemyType> _enemyList;

	private List<CharacterType> _characterList;

	private Dictionary<EnemyType, List<EnemyData>> _enemyData;

	private Dictionary<CharacterType, List<CharacterData>> _characterData;

	private List<UISpriteAnimation> _anims;

	private int _moveTweenIndex;

	private float _congaSpeed;

	private int _congaLength;

	private float _widthCounter;

	private int _enemyCount;

	private int _characterCount;

	private bool _syncAudioCheck;

	private float _currentTime;

	private Vector2 _JSDefaultScreenSize;

	private List<RectTransform> _spawnedConga;

	private PlaySoundResult _soundResult;

	private float _normalizedTime;

	private float _animLength;

	private bool _isPlaying;

	private bool _loadingComplete;

	private void Construct(PlayerOptions player, DataManager data, MultiplayerManager multi)
	{
		_playerOptions = player;
		_data = data;
		_multiplayerManager = multi;
	}

	protected unsafe void FixedUpdate()
	{
		//IL_0139: Expected O, but got Ref
		//IL_027c: Invalid comparison between F4 and I4
		//IL_0182: Expected O, but got F4
		//IL_01a9: Invalid comparison between F4 and O
		//IL_01e5->IL01e5: Incompatible stack heights: 1 vs 0
		//IL_028f->IL0294: Incompatible stack heights: 8 vs 1
		//IL_01bc->IL0294: Incompatible stack heights: 8 vs 1
		//IL_01e0->IL0294: Incompatible stack heights: 8 vs 1
		float screenWidth = UIHelper.ScreenWidth;
		if (!_isPlaying)
		{
			return;
		}
		RectTransform congaContainer = _CongaContainer;
		bool flag = ((UnityEngine.Object)congaContainer).m_CachedPtr == (IntPtr)0;
		RectTransform.get_rect_Injected(((UnityEngine.Object)congaContainer).m_CachedPtr, out Rect _);
		List<RectTransform>.Enumerator enumerator = default(List<RectTransform>.Enumerator);
		Vector2 vector = default(Vector2);
		Vector2 value = default(Vector2);
		Vector2 anchoredPosition2 = default(Vector2);
		while (enumerator.MoveNext())
		{
			object obj = null;
			List<WiggleTween> movementTweens = _movementTweens;
			int moveTweenIndex = _moveTweenIndex;
			bool flag2 = _movementTweens == null;
			bool flag3 = _moveTweenIndex >= movementTweens._size;
			WiggleTween[] items = movementTweens._items;
			bool flag4 = movementTweens._items == null;
			bool flag5 = _moveTweenIndex >= items.Length;
			bool flag6 = items[moveTweenIndex] == null;
			((Transform)null).localEulerAngles = (Vector3)(&vector);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v586 @ rbx_v9 (System.Object)+10]");
			bool flag7 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v586 @ rbx_v9 (System.Object)+10]");
			RectTransform.get_anchoredPosition_Injected((IntPtr)0, out Vector2 _);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v586 @ rbx_v9 (System.Object)+10]");
			bool flag8 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v586 @ rbx_v9 (System.Object)+10]");
			RectTransform.set_anchoredPosition_Injected((IntPtr)0, ref value);
			if (_congaSpeed > 0f)
			{
				Vector2 anchoredPosition = ((RectTransform)null).anchoredPosition;
				Vector2 sizeDelta = ((RectTransform)null).sizeDelta;
				float num = (float)sizeDelta * 0.5f;
				object obj2 = _widthCounter ^ -0f;
				float num2 = (float)obj2 + 3840f;
				float num3 = num2 + num;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num3) > System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref anchoredPosition))
				{
					Vector2 sizeDelta2 = ((RectTransform)null).sizeDelta;
					((RectTransform)null).anchoredPosition = anchoredPosition2;
				}
			}
		}
	}

	protected override void Update()
	{
		//IL_0351: Expected O, but got F4
		//IL_005f: Invalid comparison between F4 and I4
		//IL_038e: Expected O, but got F4
		base.Update();
		if (_syncAudioCheck && _loadingComplete)
		{
			PlaylistController onlyPlaylistController = MasterAudio.OnlyPlaylistController;
			AudioSource activeAudioSource = onlyPlaylistController.ActiveAudioSource;
			float time = activeAudioSource.time;
			if (time > 0f)
			{
				PlaylistController onlyPlaylistController2 = MasterAudio.OnlyPlaylistController;
				AudioSource activeAudioSource2 = onlyPlaylistController2.ActiveAudioSource;
				activeAudioSource2.time = 0f;
				TPCreditsScene sceneInstance = _sceneInstance;
				sceneInstance.isPlaying = true;
				sceneInstance._currentTime = 0f;
				Sprite sprite = SpriteManager.GetSprite("castle02_COMP04_Background");
				sceneInstance._Background.sprite = sprite;
				Sprite sprite2 = SpriteManager.GetSprite("castle02_COMP04_Foreground");
				sceneInstance._Castle.sprite = sprite2;
				_syncAudioCheck = false;
			}
		}
		int num = Shader.PropertyToID("_HorizontalWaveInputAmplitude");
		float floatImpl = _NowLoadingMaterial.GetFloatImpl(num);
		int num2 = Shader.PropertyToID("_VerticalWaveInputAmplitude");
		float floatImpl2 = _NowLoadingMaterial.GetFloatImpl(num2);
		UIHelper.ActiveInputType activeInput = UIHelper.ActiveInput;
		float num3;
		float num4;
		if (activeInput != UIHelper.ActiveInputType.CONTROLLER)
		{
			UIHelper.ActiveInputType activeInput2 = UIHelper.ActiveInput;
			bool flag = activeInput2 != UIHelper.ActiveInputType.KEYBOARD;
			num3 = floatImpl2;
			num4 = floatImpl;
			if (flag)
			{
				goto IL_031d;
			}
		}
		float axis = Player.GetAxis("Move Horizontal");
		object obj = Time.deltaTime;
		float num5 = axis * axis;
		float num6 = num5 * _NowLoadingInputSpeed;
		num4 = floatImpl + num6;
		float axis2 = Player.GetAxis("Move Vertical");
		object obj2 = Time.deltaTime;
		float num7 = axis2 * axis2;
		float num8 = num7 * _NowLoadingInputSpeed;
		num3 = floatImpl2 + num8;
		goto IL_031d;
		IL_031d:
		int num9 = Shader.PropertyToID("_VerticalWaveInputAmplitude");
		if (!(-1f > num3))
		{
			if (num3 > 1f)
			{
				num3 = 1f;
			}
		}
		else
		{
			num3 = -1f;
		}
		_NowLoadingMaterial.SetFloatImpl(num9, num3);
		int num10 = Shader.PropertyToID("_HorizontalWaveInputAmplitude");
		if (!(-1f > num4))
		{
			if (num4 > 1f)
			{
				num4 = 1f;
			}
		}
		else
		{
			num4 = -1f;
		}
		_NowLoadingMaterial.SetFloatImpl(num10, num4);
	}

	public void SetTime(float time)
	{
		//IL_00a8: Invalid comparison between I4 and F4
		//IL_006a: Expected F4, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3673]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_currentTime = time;
		float num = time / _animLength;
		if (!(0f > num))
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
		_normalizedTime = num;
		_Animator.SetFloatString("Time", num);
	}

	public void TakeMyHand()
	{
		_Hand.SetActive(value: true);
		UISpriteAnimation component = _Hand.GetComponent<UISpriteAnimation>();
		component.Play();
		UISpriteAnimation component2 = _Hand.GetComponent<UISpriteAnimation>();
		component2._FreezeOnLastFrame = true;
	}

	protected override void OnShowStart(GameObject g)
	{
		_003C_003Ec__DisplayClass48_0 CS_0024_003C_003E8__locals10 = new _003C_003Ec__DisplayClass48_0();
		CS_0024_003C_003E8__locals10._003C_003E4__this = this;
		base.OnShowStart(g);
		int num = Shader.PropertyToID("_VerticalWaveInputAmplitude");
		_NowLoadingMaterial.SetFloatImpl(num, 0f);
		int num2 = Shader.PropertyToID("_HorizontalWaveInputAmplitude");
		_NowLoadingMaterial.SetFloatImpl(num2, 0f);
		DisableAllInput();
		GameObject original = _ScenePrefab.gameObject;
		GameObject gameObject = UnityEngine.Object.Instantiate(original, null);
		TPCreditsScene component = gameObject.GetComponent<TPCreditsScene>();
		_sceneInstance = component;
		_Hand.SetActive(value: false);
		Action onComplete = delegate
		{
			TPCreditsPage tPCreditsPage = CS_0024_003C_003E8__locals10._003C_003E4__this;
			tPCreditsPage._loadingComplete = true;
			TPCreditsPage tPCreditsPage2 = CS_0024_003C_003E8__locals10._003C_003E4__this;
			tPCreditsPage2._sceneInstance.Initialize(CS_0024_003C_003E8__locals10._003C_003E4__this);
			_003CWaitAndPlay_003Ed__54 obj = null;
			obj._003C_003E1__state = 0;
			obj._003C_003E4__this = CS_0024_003C_003E8__locals10._003C_003E4__this;
			Coroutine coroutine = CS_0024_003C_003E8__locals10._003C_003E4__this.StartCoroutine(obj);
		};
		AsyncLoader asyncLoader = new AsyncLoader(onComplete);
		CS_0024_003C_003E8__locals10.bgmToLoad = BgmType.BGM_TP_SOH_Credits;
		Action<Action> loadCall = delegate(Action cb)
		{
			TPCreditsPage tPCreditsPage = CS_0024_003C_003E8__locals10._003C_003E4__this;
			DlcType? bgmDlcType = DlcSystem._utils.GetBgmDlcType(CS_0024_003C_003E8__locals10.bgmToLoad, tPCreditsPage._data);
			AudioLoader.LoadBgmAsync(CS_0024_003C_003E8__locals10.bgmToLoad, CACHE_GROUP_NAME, bgmDlcType, cb);
		};
		asyncLoader.Add(loadCall);
		_sceneInstance.Preload(asyncLoader, CACHE_GROUP_NAME);
		asyncLoader.Load();
	}

	protected override void OnShowFinish(GameObject g)
	{
		base.OnShowFinish(g);
		_003CWaitAndHide_003Ed__51 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
	}

	protected override void OnHideFinish(GameObject g)
	{
		//IL_003b->IL012b: Incompatible stack heights: 1 vs 0
		base.OnHideFinish(g);
		if (_spawnedConga != null)
		{
			List<RectTransform>.Enumerator enumerator = default(List<RectTransform>.Enumerator);
			while (enumerator.MoveNext())
			{
				GameObject gameObject = null;
				bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
				IntPtr gcHandlePtr = Component.get_gameObject_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
				GameObject obj = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
				UnityEngine.Object.Destroy(obj, 0f);
			}
			List<RectTransform> spawnedConga = _spawnedConga;
			if (_spawnedConga != null)
			{
				int version = spawnedConga._version + 1;
				spawnedConga._version = version;
				spawnedConga._size = 0;
				if (spawnedConga._size > 0)
				{
					Array.Clear(spawnedConga._items, 0, spawnedConga._size);
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	private IEnumerator WaitAndHide()
	{
		_003CWaitAndHide_003Ed__51 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private IEnumerator WaitAndFormatPortrait()
	{
		_003CWaitAndFormatPortrait_003Ed__52 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void Play()
	{
		//IL_00cc: Expected O, but got I4
		_isPlaying = true;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		SoundManager.PlayMusic(BgmType.BGM_TP_SOH_Credits, soundConfig);
		PlayerOptionsData config = _playerOptions.Config;
		if (!(0.05f < config._003CMusicVolume_003Ek__BackingField))
		{
			PlaylistController onlyPlaylistController = MasterAudio.OnlyPlaylistController;
			AudioSource activeAudioSource = onlyPlaylistController.ActiveAudioSource;
			PlayerOptionsData config2 = _playerOptions.Config;
			activeAudioSource.volume = config2._003CSoundsVolume_003Ek__BackingField;
		}
		_syncAudioCheck = true;
	}

	private IEnumerator WaitAndPlay()
	{
		_003CWaitAndPlay_003Ed__54 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void GenerateFramesAndEvents()
	{
	}

	private void GenerateTextKeyFrames()
	{
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Expected O, but got Unknown
		Keyframe[] keys = new Keyframe[3];
		_ = 0;
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11880]");
		_ = 0;
		_ = 0;
		_ = 0;
		Transform child = _Container.GetChild(0);
		RectTransform component = child.GetComponent<RectTransform>();
		Vector2 sizeDelta = component.sizeDelta;
		_ = 1118175232;
		_ = 0;
		_ = 0;
		AnimationCurve animationCurve = new AnimationCurve();
		IntPtr ptr = AnimationCurve.Internal_Create(keys);
		animationCurve.m_Ptr = ptr;
		animationCurve.m_RequiresNativeCleanup = true;
		Extensions.SetCurveLinear(animationCurve);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type type = default(Type);
		AnimationCurve curve = default(AnimationCurve);
		_Animation.SetCurve("Rotator/CreditText/CreditTextContainer", type, "m_AnchoredPosition.y", curve);
	}

	private void SetMusic()
	{
		PlayerOptionsData config = _playerOptions.Config;
		SoundManager.StopMusic(config._003CSelectedBGM_003Ek__BackingField);
		PlayerOptionsData config2 = _playerOptions.Config;
		config2._003CSelectedBGM_003Ek__BackingField = BgmType.BGM_TP_SOH_Credits;
		SoundManager._003CCurrentBgm_003Ek__BackingField = BgmType.BGM_TP_SOH_Credits;
	}

	private void CreateConga()
	{
		//IL_0135: Expected F4, but got I4
		//IL_001d: Expected I4, but got F4
		//IL_00db: Invalid comparison between F4 and I4
		//IL_011d: Expected F4, but got I4
		//IL_0168: Invalid comparison between F4 and I4
		_widthCounter = 0f;
		float num = 0f;
		do
		{
			WiggleTween wiggleTween = new WiggleTween();
			wiggleTween.Start((int)num);
			List<object> movementTweens = (List<object>)(object)_movementTweens;
			int version = movementTweens._version + 1;
			movementTweens._version = version;
			object[] items = movementTweens._items;
			if (movementTweens._size >= items.Length)
			{
				movementTweens.AddWithResize((object)wiggleTween);
			}
			else
			{
				int size = movementTweens._size + 1;
				movementTweens._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			num++;
		}
		while (num < 10f);
		CreateEnemyList();
		CreateCharacterList();
		bool flag = _congaLength <= 0;
		float num2 = 0f;
		if (!flag)
		{
			do
			{
				GetNextCharacter();
				num2++;
			}
			while (num2 < (float)_congaLength);
		}
	}

	private void CreateWiggleTweens()
	{
		int num = 0;
		do
		{
			WiggleTween wiggleTween = new WiggleTween();
			wiggleTween.Start(num);
			List<object> movementTweens = (List<object>)(object)_movementTweens;
			int version = movementTweens._version + 1;
			movementTweens._version = version;
			object[] items = movementTweens._items;
			if (movementTweens._size >= items.Length)
			{
				movementTweens.AddWithResize((object)wiggleTween);
			}
			else
			{
				int size = movementTweens._size + 1;
				movementTweens._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			num++;
		}
		while (num < 10);
	}

	private void CreateEnemyList()
	{
		//IL_0055: Expected O, but got I
		//IL_00af: Expected O, but got I
		//IL_00e7: Expected O, but got I
		//IL_0141: Expected O, but got I
		//IL_0179: Expected O, but got I
		//IL_01d3: Expected O, but got I
		//IL_020b: Expected O, but got I
		//IL_0265: Expected O, but got I
		//IL_029d: Expected O, but got I
		//IL_02f7: Expected O, but got I
		//IL_032f: Expected O, but got I
		//IL_0389: Expected O, but got I
		//IL_03c1: Expected O, but got I
		//IL_041b: Expected O, but got I
		//IL_0453: Expected O, but got I
		//IL_04ad: Expected O, but got I
		//IL_04e5: Expected O, but got I
		//IL_053f: Expected O, but got I
		//IL_0577: Expected O, but got I
		//IL_05d1: Expected O, but got I
		//IL_0609: Expected O, but got I
		//IL_0663: Expected O, but got I
		//IL_069b: Expected O, but got I
		//IL_06f5: Expected O, but got I
		//IL_072d: Expected O, but got I
		//IL_0787: Expected O, but got I
		//IL_07bf: Expected O, but got I
		//IL_0819: Expected O, but got I
		//IL_0851: Expected O, but got I
		//IL_08ab: Expected O, but got I
		//IL_08e3: Expected O, but got I
		//IL_093d: Expected O, but got I
		//IL_0975: Expected O, but got I
		//IL_09cf: Expected O, but got I
		//IL_0a07: Expected O, but got I
		//IL_0a61: Expected O, but got I
		//IL_0a99: Expected O, but got I
		//IL_0af3: Expected O, but got I
		//IL_0b2b: Expected O, but got I
		//IL_0b85: Expected O, but got I
		//IL_0bbd: Expected O, but got I
		//IL_0c17: Expected O, but got I
		//IL_0c4f: Expected O, but got I
		//IL_0ca9: Expected O, but got I
		//IL_0ce1: Expected O, but got I
		//IL_0d3b: Expected O, but got I
		//IL_0d73: Expected O, but got I
		//IL_0dcd: Expected O, but got I
		//IL_0e05: Expected O, but got I
		//IL_0e5f: Expected O, but got I
		//IL_0e97: Expected O, but got I
		//IL_0ef1: Expected O, but got I
		//IL_0f29: Expected O, but got I
		//IL_0f83: Expected O, but got I
		//IL_0fbb: Expected O, but got I
		//IL_1015: Expected O, but got I
		//IL_104d: Expected O, but got I
		//IL_10a7: Expected O, but got I
		//IL_10df: Expected O, but got I
		//IL_1139: Expected O, but got I
		//IL_1171: Expected O, but got I
		//IL_11cb: Expected O, but got I
		//IL_1203: Expected O, but got I
		//IL_125d: Expected O, but got I
		//IL_1295: Expected O, but got I
		//IL_12ef: Expected O, but got I
		//IL_1327: Expected O, but got I
		//IL_1381: Expected O, but got I
		//IL_13b9: Expected O, but got I
		//IL_1413: Expected O, but got I
		//IL_144b: Expected O, but got I
		//IL_14a5: Expected O, but got I
		//IL_153d: Expected O, but got I
		//IL_1690: Expected O, but got I
		//IL_16ea: Expected O, but got I
		Dictionary<EnemyType, List<EnemyData>> convertedEnemyData = _data.GetConvertedEnemyData();
		_enemyData = convertedEnemyData;
		List<System.Int32Enum> enemyList = (List<System.Int32Enum>)(object)_enemyList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ rcx_v6 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ rcx_v6 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ rcx_v6 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ r8_v4+18]");
		if (num >= 0)
		{
			enemyList.AddWithResize((System.Int32Enum)1006);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ rcx_v6 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1006;
		}
		List<System.Int32Enum> enemyList2 = (List<System.Int32Enum>)(object)_enemyList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ rcx_v7 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ rcx_v7 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ rcx_v7 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ r8_v6+18]");
		if (num2 >= 0)
		{
			enemyList2.AddWithResize((System.Int32Enum)1007);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ rcx_v7 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 1007;
		}
		List<System.Int32Enum> enemyList3 = (List<System.Int32Enum>)(object)_enemyList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ rcx_v8 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ rcx_v8 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ rcx_v8 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ r8_v8+18]");
		if (num3 >= 0)
		{
			enemyList3.AddWithResize((System.Int32Enum)1008);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ rcx_v8 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 1008;
		}
		List<System.Int32Enum> enemyList4 = (List<System.Int32Enum>)(object)_enemyList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ rcx_v9 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ rcx_v9 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ rcx_v9 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ r8_v10+18]");
		if (num4 >= 0)
		{
			enemyList4.AddWithResize((System.Int32Enum)1009);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ rcx_v9 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 1009;
		}
		List<System.Int32Enum> enemyList5 = (List<System.Int32Enum>)(object)_enemyList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ rcx_v10 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ rcx_v10 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ rcx_v10 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ r8_v12+18]");
		if (num5 >= 0)
		{
			enemyList5.AddWithResize((System.Int32Enum)1010);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ rcx_v10 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 1010;
		}
		List<System.Int32Enum> enemyList6 = (List<System.Int32Enum>)(object)_enemyList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rcx_v11 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rcx_v11 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rcx_v11 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ r8_v14+18]");
		if (num6 >= 0)
		{
			enemyList6.AddWithResize((System.Int32Enum)1011);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rcx_v11 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 1011;
		}
		List<System.Int32Enum> enemyList7 = (List<System.Int32Enum>)(object)_enemyList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rcx_v12 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rcx_v12 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rcx_v12 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ r8_v16+18]");
		if (num7 >= 0)
		{
			enemyList7.AddWithResize((System.Int32Enum)1012);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rcx_v12 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 1012;
		}
		List<System.Int32Enum> enemyList8 = (List<System.Int32Enum>)(object)_enemyList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v324 @ rcx_v13 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v324 @ rcx_v13 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v324 @ rcx_v13 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ r8_v18+18]");
		if (num8 >= 0)
		{
			enemyList8.AddWithResize((System.Int32Enum)1013);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v324 @ rcx_v13 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 1013;
		}
		List<System.Int32Enum> enemyList9 = (List<System.Int32Enum>)(object)_enemyList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v325 @ rcx_v14 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v325 @ rcx_v14 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v325 @ rcx_v14 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ r8_v20+18]");
		if (num9 >= 0)
		{
			enemyList9.AddWithResize((System.Int32Enum)1014);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v325 @ rcx_v14 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj18 = (nint)0 + (nint)1;
			_ = 1014;
		}
		List<System.Int32Enum> enemyList10 = (List<System.Int32Enum>)(object)_enemyList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ rcx_v15 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ rcx_v15 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ rcx_v15 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ r8_v22+18]");
		if (num10 >= 0)
		{
			enemyList10.AddWithResize((System.Int32Enum)1015);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ rcx_v15 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj20 = (nint)0 + (nint)1;
			_ = 1015;
		}
		List<System.Int32Enum> enemyList11 = (List<System.Int32Enum>)(object)_enemyList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rcx_v16 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rcx_v16 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rcx_v16 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ r8_v24+18]");
		if (num11 >= 0)
		{
			enemyList11.AddWithResize((System.Int32Enum)1016);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rcx_v16 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj22 = (nint)0 + (nint)1;
			_ = 1016;
		}
		List<System.Int32Enum> enemyList12 = (List<System.Int32Enum>)(object)_enemyList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rcx_v17 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rcx_v17 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rcx_v17 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ r8_v26+18]");
		if (num12 >= 0)
		{
			enemyList12.AddWithResize((System.Int32Enum)1017);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rcx_v17 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj24 = (nint)0 + (nint)1;
			_ = 1017;
		}
		List<System.Int32Enum> enemyList13 = (List<System.Int32Enum>)(object)_enemyList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ rcx_v18 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ rcx_v18 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ rcx_v18 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ r8_v28+18]");
		if (num13 >= 0)
		{
			enemyList13.AddWithResize((System.Int32Enum)1018);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ rcx_v18 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj26 = (nint)0 + (nint)1;
			_ = 1018;
		}
		List<System.Int32Enum> enemyList14 = (List<System.Int32Enum>)(object)_enemyList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ rcx_v19 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ rcx_v19 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ rcx_v19 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ r8_v30+18]");
		if (num14 >= 0)
		{
			enemyList14.AddWithResize((System.Int32Enum)1019);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ rcx_v19 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj28 = (nint)0 + (nint)1;
			_ = 1019;
		}
		List<System.Int32Enum> enemyList15 = (List<System.Int32Enum>)(object)_enemyList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v331 @ rcx_v20 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v331 @ rcx_v20 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v331 @ rcx_v20 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ r8_v32+18]");
		if (num15 >= 0)
		{
			enemyList15.AddWithResize((System.Int32Enum)1021);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v331 @ rcx_v20 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj30 = (nint)0 + (nint)1;
			_ = 1021;
		}
		List<System.Int32Enum> enemyList16 = (List<System.Int32Enum>)(object)_enemyList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v332 @ rcx_v21 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v332 @ rcx_v21 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v332 @ rcx_v21 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ r8_v34+18]");
		if (num16 >= 0)
		{
			enemyList16.AddWithResize((System.Int32Enum)1022);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v332 @ rcx_v21 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj32 = (nint)0 + (nint)1;
			_ = 1022;
		}
		List<System.Int32Enum> enemyList17 = (List<System.Int32Enum>)(object)_enemyList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rcx_v22 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rcx_v22 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj33 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rcx_v22 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ r8_v36+18]");
		if (num17 >= 0)
		{
			enemyList17.AddWithResize((System.Int32Enum)1023);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rcx_v22 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj34 = (nint)0 + (nint)1;
			_ = 1023;
		}
		List<System.Int32Enum> enemyList18 = (List<System.Int32Enum>)(object)_enemyList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rcx_v23 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rcx_v23 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj35 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rcx_v23 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num18 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ r8_v38+18]");
		if (num18 >= 0)
		{
			enemyList18.AddWithResize((System.Int32Enum)1024);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rcx_v23 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj36 = (nint)0 + (nint)1;
			_ = 1024;
		}
		List<System.Int32Enum> enemyList19 = (List<System.Int32Enum>)(object)_enemyList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ rcx_v24 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ rcx_v24 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj37 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ rcx_v24 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ r8_v40+18]");
		if (num19 >= 0)
		{
			enemyList19.AddWithResize((System.Int32Enum)1025);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ rcx_v24 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj38 = (nint)0 + (nint)1;
			_ = 1025;
		}
		List<System.Int32Enum> enemyList20 = (List<System.Int32Enum>)(object)_enemyList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ rcx_v25 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ rcx_v25 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj39 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ rcx_v25 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num20 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ r8_v42+18]");
		if (num20 >= 0)
		{
			enemyList20.AddWithResize((System.Int32Enum)1026);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ rcx_v25 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj40 = (nint)0 + (nint)1;
			_ = 1026;
		}
		List<System.Int32Enum> enemyList21 = (List<System.Int32Enum>)(object)_enemyList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v337 @ rcx_v26 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v337 @ rcx_v26 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj41 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v337 @ rcx_v26 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ r8_v44+18]");
		if (num21 >= 0)
		{
			enemyList21.AddWithResize((System.Int32Enum)1027);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v337 @ rcx_v26 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj42 = (nint)0 + (nint)1;
			_ = 1027;
		}
		List<System.Int32Enum> enemyList22 = (List<System.Int32Enum>)(object)_enemyList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v338 @ rcx_v27 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v338 @ rcx_v27 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj43 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v338 @ rcx_v27 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num22 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ r8_v46+18]");
		if (num22 >= 0)
		{
			enemyList22.AddWithResize((System.Int32Enum)1028);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v338 @ rcx_v27 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj44 = (nint)0 + (nint)1;
			_ = 1028;
		}
		List<System.Int32Enum> enemyList23 = (List<System.Int32Enum>)(object)_enemyList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rcx_v28 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rcx_v28 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj45 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rcx_v28 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ r8_v48+18]");
		if (num23 >= 0)
		{
			enemyList23.AddWithResize((System.Int32Enum)1030);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rcx_v28 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj46 = (nint)0 + (nint)1;
			_ = 1030;
		}
		List<System.Int32Enum> enemyList24 = (List<System.Int32Enum>)(object)_enemyList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ rcx_v29 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ rcx_v29 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj47 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ rcx_v29 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num24 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ r8_v50+18]");
		if (num24 >= 0)
		{
			enemyList24.AddWithResize((System.Int32Enum)1033);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ rcx_v29 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj48 = (nint)0 + (nint)1;
			_ = 1033;
		}
		List<System.Int32Enum> enemyList25 = (List<System.Int32Enum>)(object)_enemyList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ rcx_v30 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ rcx_v30 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj49 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ rcx_v30 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ r8_v52+18]");
		if (num25 >= 0)
		{
			enemyList25.AddWithResize((System.Int32Enum)1034);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ rcx_v30 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj50 = (nint)0 + (nint)1;
			_ = 1034;
		}
		List<System.Int32Enum> enemyList26 = (List<System.Int32Enum>)(object)_enemyList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rcx_v31 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rcx_v31 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj51 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rcx_v31 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num26 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ r8_v54+18]");
		if (num26 >= 0)
		{
			enemyList26.AddWithResize((System.Int32Enum)1035);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rcx_v31 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj52 = (nint)0 + (nint)1;
			_ = 1035;
		}
		List<System.Int32Enum> enemyList27 = (List<System.Int32Enum>)(object)_enemyList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v343 @ rcx_v32 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v343 @ rcx_v32 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj53 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v343 @ rcx_v32 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ r8_v56+18]");
		if (num27 >= 0)
		{
			enemyList27.AddWithResize((System.Int32Enum)1036);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v343 @ rcx_v32 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj54 = (nint)0 + (nint)1;
			_ = 1036;
		}
		List<System.Int32Enum> enemyList28 = (List<System.Int32Enum>)(object)_enemyList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v344 @ rcx_v33 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v344 @ rcx_v33 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj55 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v344 @ rcx_v33 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num28 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ r8_v58+18]");
		if (num28 >= 0)
		{
			enemyList28.AddWithResize((System.Int32Enum)1037);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v344 @ rcx_v33 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj56 = (nint)0 + (nint)1;
			_ = 1037;
		}
		List<System.Int32Enum> enemyList29 = (List<System.Int32Enum>)(object)_enemyList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v345 @ rcx_v34 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v345 @ rcx_v34 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj57 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v345 @ rcx_v34 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ r8_v60+18]");
		if (num29 >= 0)
		{
			enemyList29.AddWithResize((System.Int32Enum)1038);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v345 @ rcx_v34 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj58 = (nint)0 + (nint)1;
			_ = 1038;
		}
		List<System.Int32Enum> enemyList30 = (List<System.Int32Enum>)(object)_enemyList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ rcx_v35 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ rcx_v35 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj59 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ rcx_v35 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num30 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ r8_v62+18]");
		if (num30 >= 0)
		{
			enemyList30.AddWithResize((System.Int32Enum)1039);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ rcx_v35 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj60 = (nint)0 + (nint)1;
			_ = 1039;
		}
		List<System.Int32Enum> enemyList31 = (List<System.Int32Enum>)(object)_enemyList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ rcx_v36 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ rcx_v36 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj61 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ rcx_v36 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ r8_v64+18]");
		if (num31 >= 0)
		{
			enemyList31.AddWithResize((System.Int32Enum)1041);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ rcx_v36 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj62 = (nint)0 + (nint)1;
			_ = 1041;
		}
		List<System.Int32Enum> enemyList32 = (List<System.Int32Enum>)(object)_enemyList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rcx_v37 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rcx_v37 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj63 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rcx_v37 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num32 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ r8_v66+18]");
		if (num32 >= 0)
		{
			enemyList32.AddWithResize((System.Int32Enum)1042);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rcx_v37 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj64 = (nint)0 + (nint)1;
			_ = 1042;
		}
		List<System.Int32Enum> enemyList33 = (List<System.Int32Enum>)(object)_enemyList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ rcx_v38 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ rcx_v38 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj65 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ rcx_v38 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num33 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ r8_v68+18]");
		if (num33 >= 0)
		{
			enemyList33.AddWithResize((System.Int32Enum)1043);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ rcx_v38 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj66 = (nint)0 + (nint)1;
			_ = 1043;
		}
		List<System.Int32Enum> enemyList34 = (List<System.Int32Enum>)(object)_enemyList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rcx_v39 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rcx_v39 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj67 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rcx_v39 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num34 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ r8_v70+18]");
		if (num34 >= 0)
		{
			enemyList34.AddWithResize((System.Int32Enum)1044);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rcx_v39 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj68 = (nint)0 + (nint)1;
			_ = 1044;
		}
		List<System.Int32Enum> enemyList35 = (List<System.Int32Enum>)(object)_enemyList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ rcx_v40 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ rcx_v40 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj69 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ rcx_v40 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num35 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ r8_v72+18]");
		if (num35 >= 0)
		{
			enemyList35.AddWithResize((System.Int32Enum)1045);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ rcx_v40 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj70 = (nint)0 + (nint)1;
			_ = 1045;
		}
		List<System.Int32Enum> enemyList36 = (List<System.Int32Enum>)(object)_enemyList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ rcx_v41 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ rcx_v41 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj71 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ rcx_v41 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num36 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ r8_v74+18]");
		if (num36 >= 0)
		{
			enemyList36.AddWithResize((System.Int32Enum)1046);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ rcx_v41 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj72 = (nint)0 + (nint)1;
			_ = 1046;
		}
		List<System.Int32Enum> enemyList37 = (List<System.Int32Enum>)(object)_enemyList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v353 @ rcx_v42 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v353 @ rcx_v42 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		nint num37 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v353 @ rcx_v42 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num38 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ r8_v77 (Il2CppMethodInfo)+18]");
		if (num38 >= 0)
		{
			enemyList37.AddWithResize((System.Int32Enum)1047);
			num37 = 0;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v353 @ rcx_v42 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj73 = (nint)0 + (nint)1;
			_ = 1047;
		}
		_enemyList.Add(EnemyType.TP_WEREWOLF);
		_enemyList.Add(EnemyType.TP_AXEARMOR_01);
		_enemyList.Add(EnemyType.TP_BOSS_KEREMET);
		_enemyList.Add(EnemyType.TP_BOSS_ZEPHYR);
		_enemyList.Add(EnemyType.TP_BOSS_ABBADON);
		_enemyList.Add(EnemyType.TP_BOSS_GIANTMEDUSAHEAD);
		_enemyList.Add(EnemyType.TP_BOSS_PARANOIA);
		_enemyList.Add(EnemyType.TP_KILLERDOLL);
		_enemyList.Add(EnemyType.TP_BOSS_BUGBEAR);
		_enemyList.Add(EnemyType.TP_HIPPOGRYPH);
		_enemyList.Add(EnemyType.TP_BONEPILLAR);
		_enemyList.Add(EnemyType.TP_MEDUSAHEAD);
		_enemyList.Add(EnemyType.TP_BOSS_BAT);
		List<System.Int32Enum> enemyList38 = (List<System.Int32Enum>)(object)_enemyList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ rcx_v56 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ rcx_v56 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj74 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ rcx_v56 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num39 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ r8_v78+18]");
		if (num39 >= 0)
		{
			enemyList38.AddWithResize((System.Int32Enum)1081);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ rcx_v56 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj75 = (nint)0 + (nint)1;
			_ = 1081;
		}
		Extensions.Shuffle(_enemyList);
		List<EnemyType> enemyList39 = _enemyList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ rcx_v58 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj76 = default(object);
			if ((nint)obj76 != -1)
			{
				bool flag = ((List<System.Int32Enum>)(object)_enemyList).Remove((System.Int32Enum)246);
			}
		}
	}

	public void PlayVideo()
	{
		//IL_00a6: Invalid comparison between F4 and I4
		_VideoDisplay.SetActive(value: true);
		RectTransform component = _VideoDisplay.GetComponent<RectTransform>();
		RawImage component2 = _VideoDisplay.GetComponent<RawImage>();
		int width = component2.m_Texture.width;
		int height = component2.m_Texture.height;
		int num = width / height;
		float screenWidth = UIHelper.ScreenWidth;
		float screenHeight = UIHelper.ScreenHeight;
		float num2 = screenWidth / screenHeight;
		Vector2 vector = default(Vector2);
		Vector2 sizeDelta = ((num2 > (float)num) ? vector : vector);
		component.sizeDelta = sizeDelta;
	}

	private void GetNextCharacter()
	{
		//IL_03ac: Expected O, but got I
		//IL_0501: Invalid comparison between F4 and I4
		//IL_02b8: Expected O, but got I
		//IL_003e: Expected O, but got I8
		//IL_0091: Expected O, but got I
		//IL_0311: Expected O, but got I
		//IL_0326: Expected O, but got I
		//IL_033b: Expected O, but got I
		//IL_04a7: Expected O, but got I
		//IL_04b5: Expected I4, but got O
		//IL_0355: Expected O, but got I4
		//IL_013f: Expected O, but got I
		//IL_0154: Expected O, but got I
		//IL_0225: Expected O, but got I4
		//IL_01d2: Expected O, but got I
		//IL_01e7: Expected O, but got I
		//IL_01fc: Expected O, but got I
		//IL_044f->IL0515: Incompatible stack heights: 3 vs 2
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag = (nint)0 != 0;
		TPCreditsPage tPCreditsPage = this;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			tPCreditsPage = (TPCreditsPage)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v56 @ rax_v3 (should have been resolved before IL gen)");
		if (!(0.5f > 0f))
		{
			List<CharacterType> characterList = _characterList;
			int characterCount = _characterCount;
			int characterCount2 = _characterCount;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rax_v15 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			bool flag2 = (nint)characterCount2 >= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rax_v15 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rsi_v4+20+v99 @ rcx_v13 (System.Int32)*4]");
			List<string> texturesForCharacterType = CharacterLoader.GetTexturesForCharacterType(CharacterType.VOID, _playerOptions, _data);
			List<string>.Enumerator enumerator = default(List<string>.Enumerator);
			while (enumerator.MoveNext())
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rsi_v4+20+v99 @ rcx_v13 (System.Int32)*4]");
				CharacterLoader.LoadCharacterTexture(null, CharacterType.VOID, _data);
			}
			Dictionary<CharacterType, List<CharacterData>> characterData = _characterData;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rsi_v4+20+v99 @ rcx_v13 (System.Int32)*4]");
			object obj3 = ((Dictionary<System.Int32Enum, object>)(object)characterData).get_Item((System.Int32Enum)0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rax_v23 (System.Object)+18]");
			bool flag3 = (nint)0 <= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rax_v23 (System.Object)+10]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rax_v24+20]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ rcx_v19+78]");
			int maxExclusive2;
			if ((nint)0 != 0)
			{
				Dictionary<CharacterType, List<CharacterData>> characterData2 = _characterData;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rsi_v4+20+v99 @ rcx_v13 (System.Int32)*4]");
				object obj6 = ((Dictionary<System.Int32Enum, object>)(object)characterData2).get_Item((System.Int32Enum)0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rax_v31 (System.Object)+18]");
				bool flag4 = (nint)0 <= (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rax_v31 (System.Object)+10]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rax_v32+20]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rcx_v28+78]");
				object obj9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ r14_v6+18]");
				System.Int32Enum maxExclusive = (System.Int32Enum)(-1);
				int num = UnityEngine.Random.RandomRangeInt(0, (int)maxExclusive);
				maxExclusive2 = num;
			}
			else
			{
				maxExclusive2 = 0;
			}
			int frameIndex = UnityEngine.Random.RandomRangeInt(0, maxExclusive2);
			List<CharacterType> characterList2 = _characterList;
			object obj10 = _characterCount + 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ rdx_v14 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			bool flag5 = (nint)obj10 >= 0;
			int characterCount3 = 0;
			if (!flag5)
			{
				characterCount3 = _characterCount + 1;
			}
			_characterCount = characterCount3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rsi_v4+20+v99 @ rcx_v13 (System.Int32)*4]");
			CreateCharacterAnimation(CharacterType.VOID, frameIndex);
		}
		else
		{
			List<EnemyType> enemyList = _enemyList;
			int enemyCount = _enemyCount;
			int enemyCount2 = _enemyCount;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rax_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
			bool flag6 = (nint)enemyCount2 >= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rax_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+10]");
			object obj11 = 0;
			Dictionary<EnemyType, List<EnemyData>> enemyData = _enemyData;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rdx_v2+20+v111 @ rcx_v4 (System.Int32)*4]");
			object obj12 = ((Dictionary<System.Int32Enum, object>)(object)enemyData).get_Item((System.Int32Enum)0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ rax_v8 (System.Object)+18]");
			bool flag7 = (nint)0 <= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ rax_v8 (System.Object)+10]");
			object obj13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v250 @ rax_v9+20]");
			object obj14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rcx_v6+D8]");
			object obj15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ rdi_v2+18]");
			object obj16 = -1;
			int frameIndex2 = UnityEngine.Random.RandomRangeInt(0, (int)obj16);
			List<EnemyType> enemyList2 = _enemyList;
			object obj17 = _enemyCount + 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rdx_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
			int enemyCount3 = (((nint)obj17 < 0) ? (_enemyCount + 1) : 0);
			_enemyCount = enemyCount3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rdx_v2+20+v111 @ rcx_v4 (System.Int32)*4]");
			GameObject gameObject = CreateEnemyAnimation(EnemyType.BAT1, frameIndex2);
		}
	}

	private unsafe GameObject CreateEnemyAnimation(EnemyType type, int frameIndex = 0)
	{
		//IL_0055: Expected O, but got I
		//IL_006a: Expected O, but got I
		//IL_007f: Expected O, but got I
		//IL_0189: Expected O, but got I
		//IL_010b: Expected O, but got I
		//IL_012f: Expected O, but got I
		//IL_0154: Expected O, but got Ref
		object obj = ((Dictionary<System.Int32Enum, object>)(object)_enemyData).get_Item((System.Int32Enum)type);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Object)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Object)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v9+20]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rax_v10+C8]");
			string text = (string)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rax_v10+C8]");
			if ((nint)0 == 0 || text._stringLength <= 0)
			{
				text = "enemies";
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rax_v10+168]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rax_v11+18]");
			if ((nint)frameIndex < (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rax_v11+10]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rcx_v7+20+frameIndex @ r8 (System.Int32)*8]");
				List<Sprite> animationFramesFast = SpriteManager.GetAnimationFramesFast((List<string>)0, text);
				GameObject gameObject = CreatePawn(animationFramesFast);
				IntPtr intPtr = default(IntPtr);
				string text2 = ((Enum)(&intPtr)).ToString();
				((UnityEngine.Object)gameObject).SetName(text2);
				return gameObject;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		GameObject result = default(GameObject);
		return result;
	}

	private unsafe void CreateCharacterAnimation(CharacterType type, int frameIndex = 0)
	{
		//IL_0055: Expected O, but got I
		//IL_006a: Expected O, but got I
		//IL_007f: Expected O, but got I
		//IL_008f: Expected O, but got I
		//IL_016c: Expected O, but got I
		//IL_02d2: Expected O, but got Ref
		//IL_01a3: Expected O, but got I
		//IL_01b8: Expected O, but got I
		//IL_01cd: Expected O, but got I
		//IL_01dd: Expected O, but got I
		//IL_01ed: Expected O, but got I
		//IL_0202: Expected O, but got I
		//IL_0249: Expected O, but got I
		//IL_025e: Expected O, but got I
		//IL_0273: Expected O, but got I
		object obj = ((Dictionary<System.Int32Enum, object>)(object)_characterData).get_Item((System.Int32Enum)type);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v10 (System.Object)+18]");
		string text;
		string text2;
		int start;
		int end;
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v10 (System.Object)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rdx_v6+20]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v7+40]");
			text = (string)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v7+48]");
			text2 = (string)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v7+40]");
			if ((nint)0 == 0 || text._stringLength <= 0)
			{
				text = "characters";
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v7+108]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v7+108]");
				if ((nint)0 == 0)
				{
					goto IL_0332;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v7+108]");
				start = (int)((nint)0 >> 32);
			}
			else
			{
				start = 1;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v7+110]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v7+68]");
			end = 0;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v7+110]");
				if ((nint)0 == 0)
				{
					goto IL_0332;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v7+78]");
			if ((nint)0 == 0)
			{
				goto IL_0278;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v7+78]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rcx_v18+18]");
			if ((nint)frameIndex < (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rcx_v18+10]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rcx_v19+20+frameIndex @ r8 (System.Int32)*8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rbp_v9+38]");
				text = (string)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v7+78]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rax_v20+10]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v386 @ rcx_v20+20+frameIndex @ r8 (System.Int32)*8]");
				object obj9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rcx_v21+58]");
				end = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rax_v20+18]");
				if ((nint)frameIndex < (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rax_v20+10]");
					object obj10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rcx_v22+20+frameIndex @ r8 (System.Int32)*8]");
					object obj11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rcx_v23+40]");
					text2 = (string)0;
					goto IL_0278;
				}
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_0332:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		throw new IndexOutOfRangeException();
		IL_0278:
		string animName = text2.Replace("01.png", "");
		int zeroPad = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(animName, start, end, text, zeroPad);
		GameObject gameObject = CreatePawn(animationFrames, flip: true);
		IntPtr intPtr = default(IntPtr);
		string text3 = ((Enum)(&intPtr)).ToString();
		string text4 = text3 + "_CHAR";
		((UnityEngine.Object)gameObject).SetName(text4);
	}

	private unsafe GameObject CreatePawn(List<Sprite> sprites, bool flip = false)
	{
		//IL_032a: Expected I, but got O
		//IL_0393: Expected I, but got O
		//IL_027f->IL0293: Incompatible stack heights: 13 vs 0
		//IL_043d->IL03fb: Incompatible stack heights: 14 vs 13
		GameObject gameObject = UnityEngine.Object.Instantiate(_CongaItem, _CongaContainer);
		if ((object)gameObject != null)
		{
			Transform componentInChildren = (Transform)(object)gameObject.GetComponentInChildren<UISpriteAnimation>(includeInactive: false);
			if ((object)componentInChildren != null)
			{
				RectTransform component = gameObject.GetComponent<RectTransform>();
				if (_anims != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9E360");
					Vector2 vector = default(Vector2);
					Extensions.SetPivot(component, vector);
					bool flag = sprites == null;
					bool flag2 = sprites._size <= 0;
					Sprite[] items = sprites._items;
					bool flag3 = sprites._items == null;
					if (items.Length <= 0)
					{
						throw new IndexOutOfRangeException();
					}
					Transform transform = (Transform)(object)items[0];
					bool flag4 = (object)items[0] == null;
					bool flag5 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Sprite.get_rect_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Rect ret);
					bool flag6 = sprites._size <= 0;
					List<Sprite> items2 = (List<Sprite>)(object)sprites._items;
					bool flag7 = sprites._items == null;
					bool flag8 = items2._size <= 0;
					List<Sprite> syncRoot = (List<Sprite>)items2._syncRoot;
					bool flag9 = items2._syncRoot == null;
					bool flag10 = syncRoot._items == null;
					Sprite.get_rect_Injected((IntPtr)syncRoot._items, out Rect _);
					object obj = default(object);
					float num = (float)obj * 1.6f;
					float num2 = num * 2.5f;
					bool flag11 = (object)component == null;
					component.sizeDelta = vector;
					List<Sprite> congaContainer = (List<Sprite>)(object)_CongaContainer;
					bool flag12 = (object)_CongaContainer == null;
					bool flag13 = congaContainer._items == null;
					RectTransform.get_rect_Injected((IntPtr)congaContainer._items, out ret);
					component.anchoredPosition = vector;
					Vector2 sizeDelta = component.sizeDelta;
					float widthCounter = (float)sizeDelta + _widthCounter;
					_widthCounter = widthCounter;
					Extensions.SetPivot(component, vector);
					bool flag14 = !flip;
					Vector2 vector2 = vector;
					if (!flag14)
					{
						bool flag15 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
						Vector2 value = default(Vector2);
						Transform.set_localScale_Injected(((UnityEngine.Object)component).m_CachedPtr, ref *(Vector3*)(&value));
						vector2 = vector;
					}
					if (_spawnedConga != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D750");
						return gameObject;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void CreateCharacterList()
	{
		//IL_0055: Expected O, but got I
		//IL_00af: Expected O, but got I
		//IL_00e7: Expected O, but got I
		//IL_0141: Expected O, but got I
		//IL_0179: Expected O, but got I
		//IL_01d3: Expected O, but got I
		//IL_020b: Expected O, but got I
		//IL_0265: Expected O, but got I
		//IL_029d: Expected O, but got I
		//IL_02f7: Expected O, but got I
		//IL_032f: Expected O, but got I
		//IL_0389: Expected O, but got I
		//IL_03c1: Expected O, but got I
		//IL_041b: Expected O, but got I
		//IL_0453: Expected O, but got I
		//IL_04ad: Expected O, but got I
		//IL_04e5: Expected O, but got I
		//IL_053f: Expected O, but got I
		//IL_0577: Expected O, but got I
		//IL_05d1: Expected O, but got I
		//IL_0609: Expected O, but got I
		//IL_0663: Expected O, but got I
		//IL_069b: Expected O, but got I
		//IL_06f5: Expected O, but got I
		//IL_072d: Expected O, but got I
		//IL_0787: Expected O, but got I
		//IL_07bf: Expected O, but got I
		//IL_0819: Expected O, but got I
		//IL_0851: Expected O, but got I
		//IL_08ab: Expected O, but got I
		//IL_08e3: Expected O, but got I
		//IL_093d: Expected O, but got I
		//IL_0975: Expected O, but got I
		//IL_09cf: Expected O, but got I
		//IL_0a07: Expected O, but got I
		//IL_0a61: Expected O, but got I
		//IL_0a99: Expected O, but got I
		//IL_0af3: Expected O, but got I
		//IL_0b2b: Expected O, but got I
		//IL_0b85: Expected O, but got I
		//IL_0bbd: Expected O, but got I
		//IL_0c17: Expected O, but got I
		//IL_0c4f: Expected O, but got I
		//IL_0ca9: Expected O, but got I
		//IL_0ce1: Expected O, but got I
		//IL_0d3b: Expected O, but got I
		//IL_0d73: Expected O, but got I
		//IL_0dcd: Expected O, but got I
		Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _data.GetConvertedCharacterData();
		_characterData = convertedCharacterData;
		List<System.Int32Enum> characterList = (List<System.Int32Enum>)(object)_characterList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ rcx_v6 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ rcx_v6 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ rcx_v6 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ r8_v4+18]");
		if (num >= 0)
		{
			characterList.AddWithResize((System.Int32Enum)202);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ rcx_v6 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 202;
		}
		List<System.Int32Enum> characterList2 = (List<System.Int32Enum>)(object)_characterList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ rcx_v7 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ rcx_v7 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ rcx_v7 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ r8_v6+18]");
		if (num2 >= 0)
		{
			characterList2.AddWithResize((System.Int32Enum)206);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ rcx_v7 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 206;
		}
		List<System.Int32Enum> characterList3 = (List<System.Int32Enum>)(object)_characterList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rcx_v8 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rcx_v8 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rcx_v8 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ r8_v8+18]");
		if (num3 >= 0)
		{
			characterList3.AddWithResize((System.Int32Enum)213);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rcx_v8 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 213;
		}
		List<System.Int32Enum> characterList4 = (List<System.Int32Enum>)(object)_characterList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rcx_v9 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rcx_v9 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rcx_v9 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r8_v10+18]");
		if (num4 >= 0)
		{
			characterList4.AddWithResize((System.Int32Enum)214);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rcx_v9 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 214;
		}
		List<System.Int32Enum> characterList5 = (List<System.Int32Enum>)(object)_characterList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rcx_v10 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rcx_v10 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rcx_v10 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ r8_v12+18]");
		if (num5 >= 0)
		{
			characterList5.AddWithResize((System.Int32Enum)217);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rcx_v10 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 217;
		}
		List<System.Int32Enum> characterList6 = (List<System.Int32Enum>)(object)_characterList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rcx_v11 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rcx_v11 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rcx_v11 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ r8_v14+18]");
		if (num6 >= 0)
		{
			characterList6.AddWithResize((System.Int32Enum)211);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rcx_v11 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 211;
		}
		List<System.Int32Enum> characterList7 = (List<System.Int32Enum>)(object)_characterList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ rcx_v12 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ rcx_v12 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ rcx_v12 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ r8_v16+18]");
		if (num7 >= 0)
		{
			characterList7.AddWithResize((System.Int32Enum)218);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ rcx_v12 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 218;
		}
		List<System.Int32Enum> characterList8 = (List<System.Int32Enum>)(object)_characterList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ rcx_v13 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ rcx_v13 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ rcx_v13 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ r8_v18+18]");
		if (num8 >= 0)
		{
			characterList8.AddWithResize((System.Int32Enum)219);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ rcx_v13 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 219;
		}
		List<System.Int32Enum> characterList9 = (List<System.Int32Enum>)(object)_characterList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ rcx_v14 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ rcx_v14 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ rcx_v14 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r8_v20+18]");
		if (num9 >= 0)
		{
			characterList9.AddWithResize((System.Int32Enum)221);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ rcx_v14 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj18 = (nint)0 + (nint)1;
			_ = 221;
		}
		List<System.Int32Enum> characterList10 = (List<System.Int32Enum>)(object)_characterList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ rcx_v15 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ rcx_v15 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ rcx_v15 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ r8_v22+18]");
		if (num10 >= 0)
		{
			characterList10.AddWithResize((System.Int32Enum)222);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ rcx_v15 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj20 = (nint)0 + (nint)1;
			_ = 222;
		}
		List<System.Int32Enum> characterList11 = (List<System.Int32Enum>)(object)_characterList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ rcx_v16 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ rcx_v16 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ rcx_v16 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ r8_v24+18]");
		if (num11 >= 0)
		{
			characterList11.AddWithResize((System.Int32Enum)224);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ rcx_v16 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj22 = (nint)0 + (nint)1;
			_ = 224;
		}
		List<System.Int32Enum> characterList12 = (List<System.Int32Enum>)(object)_characterList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rcx_v17 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rcx_v17 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rcx_v17 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ r8_v26+18]");
		if (num12 >= 0)
		{
			characterList12.AddWithResize((System.Int32Enum)225);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rcx_v17 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj24 = (nint)0 + (nint)1;
			_ = 225;
		}
		List<System.Int32Enum> characterList13 = (List<System.Int32Enum>)(object)_characterList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ rcx_v18 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ rcx_v18 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ rcx_v18 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ r8_v28+18]");
		if (num13 >= 0)
		{
			characterList13.AddWithResize((System.Int32Enum)229);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ rcx_v18 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj26 = (nint)0 + (nint)1;
			_ = 229;
		}
		List<System.Int32Enum> characterList14 = (List<System.Int32Enum>)(object)_characterList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rcx_v19 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rcx_v19 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rcx_v19 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ r8_v30+18]");
		if (num14 >= 0)
		{
			characterList14.AddWithResize((System.Int32Enum)231);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rcx_v19 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj28 = (nint)0 + (nint)1;
			_ = 231;
		}
		List<System.Int32Enum> characterList15 = (List<System.Int32Enum>)(object)_characterList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rcx_v20 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rcx_v20 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rcx_v20 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ r8_v32+18]");
		if (num15 >= 0)
		{
			characterList15.AddWithResize((System.Int32Enum)232);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rcx_v20 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj30 = (nint)0 + (nint)1;
			_ = 232;
		}
		List<System.Int32Enum> characterList16 = (List<System.Int32Enum>)(object)_characterList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ rcx_v21 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ rcx_v21 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ rcx_v21 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ r8_v34+18]");
		if (num16 >= 0)
		{
			characterList16.AddWithResize((System.Int32Enum)233);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ rcx_v21 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj32 = (nint)0 + (nint)1;
			_ = 233;
		}
		List<System.Int32Enum> characterList17 = (List<System.Int32Enum>)(object)_characterList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rcx_v22 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rcx_v22 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj33 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rcx_v22 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ r8_v36+18]");
		if (num17 >= 0)
		{
			characterList17.AddWithResize((System.Int32Enum)238);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rcx_v22 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj34 = (nint)0 + (nint)1;
			_ = 238;
		}
		List<System.Int32Enum> characterList18 = (List<System.Int32Enum>)(object)_characterList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rcx_v23 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rcx_v23 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj35 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rcx_v23 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num18 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ r8_v38+18]");
		if (num18 >= 0)
		{
			characterList18.AddWithResize((System.Int32Enum)239);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rcx_v23 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj36 = (nint)0 + (nint)1;
			_ = 239;
		}
		List<System.Int32Enum> characterList19 = (List<System.Int32Enum>)(object)_characterList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rcx_v24 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rcx_v24 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj37 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rcx_v24 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ r8_v40+18]");
		if (num19 >= 0)
		{
			characterList19.AddWithResize((System.Int32Enum)240);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rcx_v24 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj38 = (nint)0 + (nint)1;
			_ = 240;
		}
		List<System.Int32Enum> characterList20 = (List<System.Int32Enum>)(object)_characterList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ rcx_v25 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ rcx_v25 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj39 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ rcx_v25 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num20 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ r8_v42+18]");
		if (num20 >= 0)
		{
			characterList20.AddWithResize((System.Int32Enum)241);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ rcx_v25 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj40 = (nint)0 + (nint)1;
			_ = 241;
		}
		List<System.Int32Enum> characterList21 = (List<System.Int32Enum>)(object)_characterList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rcx_v26 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rcx_v26 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj41 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rcx_v26 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ r8_v44+18]");
		if (num21 >= 0)
		{
			characterList21.AddWithResize((System.Int32Enum)247);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rcx_v26 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj42 = (nint)0 + (nint)1;
			_ = 247;
		}
		List<System.Int32Enum> characterList22 = (List<System.Int32Enum>)(object)_characterList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ rcx_v27 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ rcx_v27 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj43 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ rcx_v27 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num22 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ r8_v46+18]");
		if (num22 >= 0)
		{
			characterList22.AddWithResize((System.Int32Enum)304);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ rcx_v27 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj44 = (nint)0 + (nint)1;
			_ = 304;
		}
		List<System.Int32Enum> characterList23 = (List<System.Int32Enum>)(object)_characterList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rcx_v28 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rcx_v28 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj45 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rcx_v28 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ r8_v48+18]");
		if (num23 >= 0)
		{
			characterList23.AddWithResize((System.Int32Enum)306);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rcx_v28 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj46 = (nint)0 + (nint)1;
			_ = 306;
		}
		List<System.Int32Enum> characterList24 = (List<System.Int32Enum>)(object)_characterList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ rcx_v29 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ rcx_v29 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj47 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ rcx_v29 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num24 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ r8_v50+18]");
		if (num24 >= 0)
		{
			characterList24.AddWithResize((System.Int32Enum)305);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ rcx_v29 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj48 = (nint)0 + (nint)1;
			_ = 305;
		}
		Extensions.Shuffle(_characterList);
		List<CharacterType> characterList25 = _characterList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rdi_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		int num25 = 0;
		List<CharacterType> characterList26 = _characterList;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rdi_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		if ((nint)0 >= (nint)20)
		{
			num25 = 20;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ r8_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		int count = (int)(-num25);
		_characterList.RemoveRange(num25, count);
	}

	private void BuildCredits()
	{
		string thosePeopleCreditsText = Credits.GetThosePeopleCreditsText();
		TextMeshProUGUI component = _TextPrefab.GetComponent<TextMeshProUGUI>();
		component.text = thosePeopleCreditsText;
	}

	private void AddText(string t)
	{
		TextMeshProUGUI component = _TextPrefab.GetComponent<TextMeshProUGUI>();
		component.text = t;
	}

	public void DisableAllInput()
	{
		_multiplayerManager.DisableAllUIInteraction();
		BackButtonController instance = BackButtonController.Instance;
		instance.ListenForControllerInput = false;
		BackButtonController.BackButtonClosesPage = false;
	}

	public TPCreditsPage()
	{
		//IL_00bc: Expected O, but got I4
		_NowLoadingInputSpeed = 2.5f;
		List<WiggleTween> movementTweens = new List<WiggleTween>();
		_movementTweens = movementTweens;
		_enemyList = new List<EnemyType>();
		_characterList = new List<CharacterType>();
		_enemyData = new Dictionary<EnemyType, List<EnemyData>>();
		_characterData = new Dictionary<CharacterType, List<CharacterData>>();
		_anims = new List<UISpriteAnimation>();
		_congaSpeed = 1f;
		_congaLength = 300;
		_JSDefaultScreenSize = (Vector2)1135280128;
		_ = 1139015680;
		_spawnedConga = new List<RectTransform>();
		base._002Ector();
	}
}
