using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Video;
using VampireSurvivors.Achievements;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.DLC;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI;

public class TPCreditsScene : MonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass42_0
	{
		public string cacheGroupName;

		public TPCreditsScene _003C_003E4__this;

		internal void _003CPreload_003Eb__0(Action cb)
		{
			//IL_0054: Expected O, but got I4
			_003C_003Ec__DisplayClass42_1 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass42_1();
			CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1 = this;
			CS_0024_003C_003E8__locals4.cb = cb;
			Action<VideoClip> onComplete = delegate(VideoClip vc)
			{
				_003C_003Ec__DisplayClass42_0 obj = CS_0024_003C_003E8__locals4.CS_0024_003C_003E8__locals1;
				TPCreditsScene tPCreditsScene = obj._003C_003E4__this;
				Action cb2 = CS_0024_003C_003E8__locals4.cb;
				tPCreditsScene._Video.clip = vc;
				IntPtr method = ((Delegate)cb2).method;
				IntPtr method_code = ((Delegate)cb2).method_code;
				IntPtr invoke_impl = ((Delegate)cb2).invoke_impl;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v89 @ rax_v6 (System.IntPtr) (should have been resolved before IL gen)");
				/*Error: End of method reached without returning.*/;
			};
			bool forceSync = default(bool);
			VideoLoader.LoadVideoInternal(CreditsVideo_1080_60, cacheGroupName, (DlcType?)(object)1, onComplete, forceSync);
		}

		internal void _003CPreload_003Eb__1(Action cb)
		{
			//IL_0029: Expected I4, but got O
			//IL_0047: Expected O, but got I4
			_003C_003Ec__DisplayClass42_2 obj = new _003C_003Ec__DisplayClass42_2();
			obj.cb = cb;
			Action<bool> action = null;
			((_003C_003Ec__DisplayClass42_2)(object)action)._003CPreload_003Eb__6((byte)(int)obj != 0);
			SpriteLoader.LoadTextureAsync("castle02_COMP04_Background", cacheGroupName, (DlcType?)(object)1, action);
		}

		internal void _003CPreload_003Eb__2(Action cb)
		{
			//IL_0029: Expected I4, but got O
			//IL_0047: Expected O, but got I4
			_003C_003Ec__DisplayClass42_3 obj = new _003C_003Ec__DisplayClass42_3();
			obj.cb = cb;
			Action<bool> action = null;
			((_003C_003Ec__DisplayClass42_3)(object)action)._003CPreload_003Eb__7((byte)(int)obj != 0);
			SpriteLoader.LoadTextureAsync("castle02_COMP04_Foreground", cacheGroupName, (DlcType?)(object)1, action);
		}

		internal void _003CPreload_003Eb__3(Action cb)
		{
			//IL_0029: Expected I4, but got O
			//IL_0047: Expected O, but got I4
			_003C_003Ec__DisplayClass42_4 obj = new _003C_003Ec__DisplayClass42_4();
			obj.cb = cb;
			Action<bool> action = null;
			((_003C_003Ec__DisplayClass42_4)(object)action)._003CPreload_003Eb__8((byte)(int)obj != 0);
			SpriteLoader.LoadTextureAsync("TP_enemies", cacheGroupName, (DlcType?)(object)1, action);
		}

		internal void _003CPreload_003Eb__4(Action cb)
		{
			//IL_0029: Expected I4, but got O
			//IL_0047: Expected O, but got I4
			_003C_003Ec__DisplayClass42_5 obj = new _003C_003Ec__DisplayClass42_5();
			obj.cb = cb;
			Action<bool> action = null;
			((_003C_003Ec__DisplayClass42_5)(object)action)._003CPreload_003Eb__9((byte)(int)obj != 0);
			SpriteLoader.LoadTextureAsync("TP_enemiesReuse", cacheGroupName, (DlcType?)(object)1, action);
		}
	}

	private sealed class _003C_003Ec__DisplayClass42_1
	{
		public Action cb;

		public _003C_003Ec__DisplayClass42_0 CS_0024_003C_003E8__locals1;

		internal void _003CPreload_003Eb__5(VideoClip vc)
		{
			_003C_003Ec__DisplayClass42_0 obj = CS_0024_003C_003E8__locals1;
			TPCreditsScene tPCreditsScene = obj._003C_003E4__this;
			Action action = cb;
			tPCreditsScene._Video.clip = vc;
			IntPtr method = ((Delegate)action).method;
			IntPtr method_code = ((Delegate)action).method_code;
			IntPtr invoke_impl = ((Delegate)action).invoke_impl;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v89 @ rax_v6 (System.IntPtr) (should have been resolved before IL gen)");
			/*Error: End of method reached without returning.*/;
		}
	}

	private sealed class _003C_003Ec__DisplayClass42_2
	{
		public Action cb;

		internal void _003CPreload_003Eb__6(bool x)
		{
			Action action = cb;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private sealed class _003C_003Ec__DisplayClass42_3
	{
		public Action cb;

		internal void _003CPreload_003Eb__7(bool x)
		{
			Action action = cb;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private sealed class _003C_003Ec__DisplayClass42_4
	{
		public Action cb;

		internal void _003CPreload_003Eb__8(bool x)
		{
			Action action = cb;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private sealed class _003C_003Ec__DisplayClass42_5
	{
		public Action cb;

		internal void _003CPreload_003Eb__9(bool x)
		{
			Action action = cb;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private sealed class _003C_003Ec__DisplayClass67_0
	{
		public SpriteRenderer image;

		public float outDuration;

		public GameObject g;

		public TweenCallback _003C_003E9__2;

		internal void _003CSpawnDoilie_003Eb__0()
		{
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(image, 0f, outDuration);
		}

		internal void _003CSpawnDoilie_003Eb__1()
		{
			Transform transform = g.transform;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(transform, 4f, outDuration);
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v4 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 5;
					_ = 0;
				}
			}
			TweenCallback tweenCallback = _003C_003E9__2;
			if (_003C_003E9__2 == null)
			{
				tweenCallback = (_003C_003E9__2 = delegate
				{
					g.SetActive(value: false);
				});
			}
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v4 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
		}

		internal void _003CSpawnDoilie_003Eb__2()
		{
			g.SetActive(value: false);
		}
	}

	private SpriteRenderer _Background;

	private SpriteRenderer _Castle;

	private Transform _RingContainer;

	private GameObject _DoilieSpritePrefab;

	private Transform _DoilieOrigin;

	private List<string> _DoilieSprites;

	private AnimationClip _AnimationLandscape;

	private AnimationClip _AnimationPortrait;

	private Animator _Animator;

	private GameObject _AnimCamera;

	private List<GameObject> _RingPrefabs;

	private AnimationCurve _CameraRotationCurve;

	private Transform _Space;

	private VideoPlayer _Video;

	private TextMeshProUGUI _DebugText;

	private Transform _Rotator;

	private TextAsset _TimeCodes;

	private AnimationClip _currentAnimationClip;

	private float _normalizedTime;

	private float _animLength;

	private Vector3 _cameraStartPos;

	private Vector3 _cameraEndPos;

	private float _ringDistanceInterval;

	private Vector3 _cameraDirection;

	private float _cameraVelocity;

	private SignalBus _signalBus;

	private MultiplayerManager _multiplayer;

	private PlayerOptions _playerOptions;

	private AchievementManager _achievementManager;

	private DataManager _data;

	private LobbiesManager _lobbiesManager;

	private TPCreditsPage _page;

	private bool isPlaying;

	private float _currentTime;

	private List<KeyValuePair<float, string>> _timeCodesFromAudio;

	private List<CharacterType> _charsToUnlock;

	private int _charIndex;

	public static string CreditsVideo_1080_60 = "VS_TP_CreditsMontage_1080_60";

	public static string CreditsVideo_1080_30 = "VS_TP_CreditsMontage_1080_30";

	public static string GetCreditsVideoForCurrentPlatform()
	{
		return CreditsVideo_1080_60;
	}

	public static string GetExcludedCreditsVideo()
	{
		return CreditsVideo_1080_30;
	}

	private void Construct(SignalBus signal, MultiplayerManager _multi, PlayerOptions playerOptions, AchievementManager achievementManager, DataManager data, LobbiesManager lobbiesManager)
	{
		_signalBus = signal;
		_multiplayer = _multi;
		_playerOptions = playerOptions;
		AchievementManager achievementManager2 = default(AchievementManager);
		_achievementManager = achievementManager2;
		DataManager data2 = default(DataManager);
		_data = data2;
		LobbiesManager lobbiesManager2 = default(LobbiesManager);
		_lobbiesManager = lobbiesManager2;
	}

	public void Preload(AsyncLoader loader, string cacheGroupName)
	{
		_003C_003Ec__DisplayClass42_0 CS_0024_003C_003E8__locals11 = new _003C_003Ec__DisplayClass42_0();
		CS_0024_003C_003E8__locals11.cacheGroupName = cacheGroupName;
		CS_0024_003C_003E8__locals11._003C_003E4__this = this;
		Action<Action> loadCall = delegate(Action cb)
		{
			//IL_0054: Expected O, but got I4
			_003C_003Ec__DisplayClass42_1 CS_0024_003C_003E8__locals13 = new _003C_003Ec__DisplayClass42_1();
			CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals11;
			CS_0024_003C_003E8__locals13.cb = cb;
			Action<VideoClip> onComplete = delegate(VideoClip vc)
			{
				_003C_003Ec__DisplayClass42_0 obj = CS_0024_003C_003E8__locals13.CS_0024_003C_003E8__locals1;
				TPCreditsScene tPCreditsScene = obj._003C_003E4__this;
				Action cb2 = CS_0024_003C_003E8__locals13.cb;
				tPCreditsScene._Video.clip = vc;
				IntPtr method = ((Delegate)cb2).method;
				IntPtr method_code = ((Delegate)cb2).method_code;
				IntPtr invoke_impl = ((Delegate)cb2).invoke_impl;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v89 @ rax_v6 (System.IntPtr) (should have been resolved before IL gen)");
				/*Error: End of method reached without returning.*/;
			};
			bool forceSync = default(bool);
			VideoLoader.LoadVideoInternal(CreditsVideo_1080_60, CS_0024_003C_003E8__locals11.cacheGroupName, (DlcType?)(object)1, onComplete, forceSync);
		};
		loader.Add(loadCall);
		Action<Action> loadCall2 = delegate(Action cb)
		{
			//IL_0029: Expected I4, but got O
			//IL_0047: Expected O, but got I4
			_003C_003Ec__DisplayClass42_2 obj = new _003C_003Ec__DisplayClass42_2();
			obj.cb = cb;
			Action<bool> action = null;
			((_003C_003Ec__DisplayClass42_2)(object)action)._003CPreload_003Eb__6((byte)(int)obj != 0);
			SpriteLoader.LoadTextureAsync("castle02_COMP04_Background", CS_0024_003C_003E8__locals11.cacheGroupName, (DlcType?)(object)1, action);
		};
		loader.Add(loadCall2);
		Action<Action> loadCall3 = delegate(Action cb)
		{
			//IL_0029: Expected I4, but got O
			//IL_0047: Expected O, but got I4
			_003C_003Ec__DisplayClass42_3 obj = new _003C_003Ec__DisplayClass42_3();
			obj.cb = cb;
			Action<bool> action = null;
			((_003C_003Ec__DisplayClass42_3)(object)action)._003CPreload_003Eb__7((byte)(int)obj != 0);
			SpriteLoader.LoadTextureAsync("castle02_COMP04_Foreground", CS_0024_003C_003E8__locals11.cacheGroupName, (DlcType?)(object)1, action);
		};
		loader.Add(loadCall3);
		Action<Action> loadCall4 = delegate(Action cb)
		{
			//IL_0029: Expected I4, but got O
			//IL_0047: Expected O, but got I4
			_003C_003Ec__DisplayClass42_4 obj = new _003C_003Ec__DisplayClass42_4();
			obj.cb = cb;
			Action<bool> action = null;
			((_003C_003Ec__DisplayClass42_4)(object)action)._003CPreload_003Eb__8((byte)(int)obj != 0);
			SpriteLoader.LoadTextureAsync("TP_enemies", CS_0024_003C_003E8__locals11.cacheGroupName, (DlcType?)(object)1, action);
		};
		loader.Add(loadCall4);
		Action<Action> loadCall5 = delegate(Action cb)
		{
			//IL_0029: Expected I4, but got O
			//IL_0047: Expected O, but got I4
			_003C_003Ec__DisplayClass42_5 obj = new _003C_003Ec__DisplayClass42_5();
			obj.cb = cb;
			Action<bool> action = null;
			((_003C_003Ec__DisplayClass42_5)(object)action)._003CPreload_003Eb__9((byte)(int)obj != 0);
			SpriteLoader.LoadTextureAsync("TP_enemiesReuse", CS_0024_003C_003E8__locals11.cacheGroupName, (DlcType?)(object)1, action);
		};
		loader.Add(loadCall5);
	}

	private unsafe void ParseText()
	{
		//IL_03cb: Expected O, but got Ref
		//IL_03d8: Expected O, but got I4
		//IL_03e1: Expected O, but got I4
		//IL_0109: Expected O, but got Ref
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		List<string> list = new List<string>();
		string text = _TimeCodes.text;
		object obj = default(object);
		string[] array = text.SplitInternal((ReadOnlySpan<char>)(&obj), 2147483647, StringSplitOptions.None);
		object obj2 = 0;
		object obj3 = 0;
		List<object> list2 = (List<object>)(object)text;
		while ((nint)obj3 < array.Length)
		{
			int version = list._version + 1;
			list._version = version;
			list2 = (List<object>)(object)list._items;
			if (list._size >= list2._size)
			{
				((List<object>)(object)list).AddWithResize((object)array[obj2]);
				obj2++;
				obj3 = obj2;
				list2 = (List<object>)(object)list;
			}
			else
			{
				int size = list._size + 1;
				list._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				obj2++;
				obj3 = obj2;
			}
		}
		List<string> list3 = list;
		List<string>.Enumerator enumerator = default(List<string>.Enumerator);
		if (enumerator.MoveNext())
		{
			List<string>.Enumerator enumerator2 = (List<string>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}

	private unsafe List<string> TextAssetToList(TextAsset ta)
	{
		//IL_0154: Expected O, but got Ref
		//IL_0161: Expected O, but got I4
		//IL_016a: Expected O, but got I4
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Expected O, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		List<string> list = new List<string>();
		string text = ta.text;
		object obj = default(object);
		string[] array = text.SplitInternal((ReadOnlySpan<char>)(&obj), 2147483647, StringSplitOptions.None);
		object obj2 = 0;
		object obj3 = 0;
		while (true)
		{
			if ((nint)obj2 < array.Length)
			{
				if ((nint)obj3 >= array.Length)
				{
					break;
				}
				int version = list._version + 1;
				list._version = version;
				string[] items = list._items;
				if (list._size >= items.Length)
				{
					((List<object>)(object)list).AddWithResize((object)array[obj3]);
					obj3++;
					obj2 = obj3;
				}
				else
				{
					int size = list._size + 1;
					list._size = size;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					obj3++;
					obj2 = obj3;
				}
				continue;
			}
			return list;
		}
		return (List<string>)(object)new IndexOutOfRangeException();
	}

	private void PrepareVideo(VideoClip clip, Action onComplete)
	{
		_Video.clip = clip;
		IntPtr method = ((Delegate)onComplete).method;
		IntPtr method_code = ((Delegate)onComplete).method_code;
		IntPtr invoke_impl = ((Delegate)onComplete).invoke_impl;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v50 @ rax_v4 (System.IntPtr) (should have been resolved before IL gen)");
		/*Error: End of method reached without returning.*/;
	}

	public void Initialize(TPCreditsPage page)
	{
		//IL_0188: Expected O, but got I
		//IL_02bc: Expected O, but got F4
		//IL_023a->IL01b7: Incompatible stack heights: 1 vs 0
		//IL_0287->IL01b7: Incompatible stack heights: 2 vs 0
		//IL_01a8->IL01b7: Incompatible stack heights: 2 vs 0
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._multiplayer != null)
		{
			if (core._multiplayer.IsOnlineMultiplayer)
			{
				Debug.Log("_lobbiesManager.LeaveLobby()");
				if (_lobbiesManager == null)
				{
					goto IL_01b7;
				}
				Task<bool> task = _lobbiesManager.LeaveLobby();
			}
			_page = page;
			if ((object)_Animator != null)
			{
				RuntimeAnimatorController runtimeAnimatorController = _Animator.runtimeAnimatorController;
				if ((object)runtimeAnimatorController != null)
				{
					AnimationClip[] animationClips = runtimeAnimatorController.animationClips;
					if (animationClips != null)
					{
						animationClips[0] = _AnimationLandscape;
						TPCreditsPage animator = (TPCreditsPage)(object)_Animator;
						if ((object)_Animator != null)
						{
							bool flag = ((UnityEngine.Object)animator).m_CachedPtr == (IntPtr)0;
							IntPtr gcHandlePtr = Animator.get_runtimeAnimatorController_Injected(((UnityEngine.Object)animator).m_CachedPtr);
							RuntimeAnimatorController runtimeAnimatorController2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<RuntimeAnimatorController>(gcHandlePtr);
							if ((object)runtimeAnimatorController2 != null)
							{
								bool flag2 = ((UnityEngine.Object)runtimeAnimatorController2).m_CachedPtr == (IntPtr)0;
								object obj = RuntimeAnimatorController.get_animationClips_Injected(((UnityEngine.Object)runtimeAnimatorController2).m_CachedPtr);
								if (obj != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rax_v39+20]");
									TPCreditsPage tPCreditsPage = (TPCreditsPage)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rax_v39+20]");
									if ((nint)0 != 0)
									{
										bool flag3 = ((UnityEngine.Object)tPCreditsPage).m_CachedPtr == (IntPtr)0;
										object obj2 = AnimationClip.get_length_Injected(((UnityEngine.Object)tPCreditsPage).m_CachedPtr);
										float animLength = default(float);
										_animLength = animLength;
										return;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_01b7;
		IL_01b7:
		throw new NullReferenceException();
	}

	public void GenerateFramesAndEvents()
	{
	}

	public void ActivateCamera()
	{
		if ((object)_AnimCamera != null)
		{
			_AnimCamera.SetActive(value: true);
			Canvas canvas = UIHelper.Canvas;
			if ((object)canvas != null)
			{
				bool flag = ((UnityEngine.Object)canvas).m_CachedPtr == (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 91 ConditionalJump @-1, v153 @ ZF_v9 (System.Boolean) --- -1 Nop");
				/*Error: End of method reached without returning.*/;
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void Update()
	{
		//IL_01ba: Expected O, but got F4
		//IL_020e: Invalid comparison between I4 and F4
		//IL_0074: Expected F4, but got I4
		//IL_015a: Expected Ref, but got F4
		if (!isPlaying)
		{
			return;
		}
		object obj = Time.deltaTime;
		TPCreditsPage page = _page;
		object obj2 = default(object);
		float num = (_currentTime = (float)obj2 + _currentTime);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3673]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		page._currentTime = num;
		float num2 = num / page._animLength;
		if (!(0f > num2))
		{
			if (num2 > 1f)
			{
				num2 = 1f;
			}
		}
		else
		{
			num2 = 0f;
		}
		page._normalizedTime = num2;
		page._Animator.SetFloatString("Time", num2);
		SetAnimTime(_currentTime);
		if (_DebugText.IsActive())
		{
			PlaylistController onlyPlaylistController = MasterAudio.OnlyPlaylistController;
			AudioSource activeAudioSource = onlyPlaylistController.ActiveAudioSource;
			float time = activeAudioSource.time;
			NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
			string text = System.Number.FormatSingle(time, "0.00", currentInfo);
			string text2 = "AudioTime: " + text;
			string text3 = text2 + "<br>";
			float num3 = (float)this + 292f;
			string text4 = ((float*)num3)->ToString("0.00");
			string text5 = text3 + "AnimTime:" + text4;
			_DebugText.text = text5;
		}
	}

	public void SkipToTime(float skipTime)
	{
		_currentTime = skipTime;
		SetAnimTime(skipTime);
		PlaylistController onlyPlaylistController = MasterAudio.OnlyPlaylistController;
		AudioSource activeAudioSource = onlyPlaylistController.ActiveAudioSource;
		activeAudioSource.time = skipTime;
	}

	private void AddAnimationEvents(List<AnimationEvent> existingEvents)
	{
		AnimationEvent animationEvent = new AnimationEvent();
		animationEvent.m_FunctionName = "SpawnRings";
		animationEvent.m_Time = 85.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1CA0");
		AnimationEvent animationEvent2 = new AnimationEvent();
		animationEvent2.m_Time = 97f;
		animationEvent2.m_FunctionName = "PlayVideo";
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1CA0");
	}

	private void StopMusic()
	{
		//IL_0080: Expected O, but got I
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_0102: Expected O, but got I
		SoundManager.StopMusic(BgmType.BGM_TP_SOH_Credits);
		BgmType bgmType = BgmType.BGM_TP_SOH_Credits;
		object obj = default(object);
		object obj2 = default(object);
		object obj4 = default(object);
		while (true)
		{
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ stack_-28_v3+1C]");
				if (obj2 == null)
				{
					object obj3 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ stack_-28_v3+18]");
					if ((nint)obj3 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ stack_-28_v3+10]");
						object obj5 = 0;
						obj4++;
						Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _data.GetConvertedCharacterData();
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ rdx_v11+20+v493 @ rcx_v23*4]");
						object obj6 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)0);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v595 @ rax_v43 (System.Object)+18]");
						if ((nint)0 > (nint)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v595 @ rax_v43 (System.Object)+10]");
							object obj7 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v539 @ rax_v44+20]");
							bgmType = BgmType.BGM_Forest;
							_ = 1;
							continue;
						}
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
						throw new NullReferenceException();
					}
					break;
				}
				break;
			}
			throw new NullReferenceException();
		}
		bool flag = obj == null;
		bgmType = BgmType.BGM_Forest;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ stack_-28_v3+1C]");
			if (obj2 == null)
			{
				return;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			bgmType = BgmType.BGM_Forest;
		}
		throw new NullReferenceException();
	}

	public AnimationEvent AddEvent(float time, string functionName)
	{
		AnimationEvent animationEvent = new AnimationEvent();
		if (animationEvent != null)
		{
			animationEvent.m_Time = time;
			animationEvent.m_FunctionName = functionName;
			return animationEvent;
		}
		return (AnimationEvent)(object)new NullReferenceException();
	}

	private void SpawnMinorDoilie()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
	}

	private void UnlockNext()
	{
		//IL_0047: Expected O, but got I
		//IL_00ae: Expected O, but got I
		//IL_00ea: Expected O, but got I
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected O, but got Unknown
		//IL_014a: Expected I, but got O
		//IL_0166: Expected O, but got I
		List<CharacterType> list = new List<CharacterType>();
		CharacterType[] charactersToUnlocks = TPCreditsPage.CharactersToUnlocks;
		int charIndex = _charIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ r8_v5 (Il2CppMethodInfo)+18]");
		if (num2 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rcx_v6 (VampireSurvivors.Data.CharacterType[])+20+v154 @ rax_v12 (System.Int32)*4]");
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)0);
			num = 0;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rcx_v6 (VampireSurvivors.Data.CharacterType[])+20+v154 @ rax_v12 (System.Int32)*4]");
			_ = 0;
		}
		nint num3 = 0;
		((List<CharacterType>)0).Add(CharacterType.ANTONIO);
		object obj4 = default(object);
		object obj3 = obj4 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		IntPtr intPtr = default(IntPtr);
		num3 = intPtr;
		object obj5 = default(object);
		object signal = (IntPtr)obj5;
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire((Type)num3, signal, (object)null, requireDeclaration);
		int charIndex2 = _charIndex + 1;
		_charIndex = charIndex2;
	}

	private unsafe void SpawnRings()
	{
		//IL_000d: Expected O, but got Ref
		//IL_007e: Expected O, but got I4
		//IL_02d9: Expected O, but got I4
		//IL_0500: Expected O, but got Ref
		//IL_0523: Expected O, but got Ref
		//IL_0531: Expected O, but got Ref
		//IL_055b: Expected O, but got I
		//IL_059d: Expected O, but got I
		//IL_0867: Expected O, but got I
		//IL_05ec: Expected O, but got Ref
		//IL_0170: Expected O, but got I8
		//IL_01aa: Expected O, but got I8
		//IL_01e4: Expected O, but got I8
		//IL_0641: Expected I, but got O
		//IL_0699: Expected O, but got Ref
		//IL_06e2: Expected O, but got I
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Expected O, but got Unknown
		//IL_0245: Expected I, but got I8
		//IL_00b2->IL02b6: Incompatible stack heights: 1 vs 0
		//IL_00f0->IL02b6: Incompatible stack heights: 1 vs 0
		//IL_034e->IL02b6: Incompatible stack heights: 2 vs 0
		//IL_03cb->IL02b6: Incompatible stack heights: 4 vs 0
		//IL_0425->IL02b6: Incompatible stack heights: 5 vs 0
		//IL_0175->IL0583: Incompatible stack heights: 12 vs 11
		//IL_01af->IL084d: Incompatible stack heights: 12 vs 11
		//IL_01e9->IL05c5: Incompatible stack heights: 12 vs 11
		//IL_02b0->IL0772: Incompatible stack heights: 15 vs 0
		//IL_024a->IL0712: Incompatible stack heights: 16 vs 15
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Debug.Log("SPAWNING RINGS");
		MathsStuff();
		float ringDistanceInterval = _ringDistanceInterval * 0.5f;
		_ringDistanceInterval = ringDistanceInterval;
		object obj3 = 0;
		Vector3 value = default(Vector3);
		Vector3 worldPosition = default(Vector3);
		Vector3 worldUp = default(Vector3);
		object obj10 = default(object);
		object obj11 = default(object);
		object obj14 = default(object);
		while (true)
		{
			float num = (float)_cameraDirection * _ringDistanceInterval;
			_ = _cameraDirection;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.UI.TPCreditsScene)+DC]");
			float num2 = 0f * _ringDistanceInterval;
			float num3 = num * (float)obj3;
			float num4 = num2 * (float)obj3;
			_ = _cameraStartPos;
			List<GameObject> ringPrefabs = _RingPrefabs;
			if (_RingPrefabs == null)
			{
				break;
			}
			object obj4 = UnityEngine.Random.RandomRangeInt(0, ringPrefabs._size);
			bool flag = (nint)obj4 >= ringPrefabs._size;
			GameObject[] items = ringPrefabs._items;
			if (ringPrefabs._items == null)
			{
				break;
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(items[obj4], _RingContainer);
			if ((object)gameObject == null)
			{
				break;
			}
			bool flag2 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr = GameObject.get_transform_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
			Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			if ((object)transform == null)
			{
				break;
			}
			bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			bool flag4 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr2 = GameObject.get_transform_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
			Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
			Transform animCamera = (Transform)(object)_AnimCamera;
			if ((object)_AnimCamera == null)
			{
				break;
			}
			bool flag5 = ((UnityEngine.Object)animCamera).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr3 = GameObject.get_transform_Injected(((UnityEngine.Object)animCamera).m_CachedPtr);
			Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr3);
			if ((object)transform3 == null)
			{
				break;
			}
			bool flag6 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out Vector3 _);
			bool flag7 = (object)transform2 == null;
			bool flag8 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
			Transform.Internal_LookAt_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref worldPosition, ref worldUp);
			bool flag9 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr4 = GameObject.get_transform_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
			Transform transform4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr4);
			bool flag10 = (object)transform4 == null;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1627 @ rax_v124 (UnityEngine.Transform)+10]");
			bool flag11 = (nint)0 == 0;
			object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 96));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1627 @ rax_v124 (UnityEngine.Transform)+10]");
			Transform.get_localRotation_Injected((IntPtr)0, out *(Quaternion*)obj5);
			Quaternion quaternion = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
			object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 80));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1-60]");
			_ = 0;
			Vector3 eulerAngles = ((Quaternion*)quaternion)->eulerAngles;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				bool flag12 = obj7 == null;
				obj6 = 6573110936L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2186 @ rax_v131 (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				bool flag13 = obj8 == null;
				obj6 = 6573110936L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2210 @ rax_v134 (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				bool flag14 = obj9 == null;
				obj6 = 6573110936L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2292 @ rax_v137 (should have been resolved before IL gen)");
			float num5 = (float)obj10 + -32f;
			transform4.localEulerAngles = (Vector3)(&obj11);
			bool flag15 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr5 = GameObject.get_transform_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
			Transform transform5 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr5);
			nint num6 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2485 @ rcx_v120 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num7 = 0;
			bool flag16 = (object)transform5 == null;
			_ = Vector3.zeroVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2486 @ rax_v146 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2411 @ rax_v144 (UnityEngine.Transform)+10]");
			bool flag17 = (nint)0 == 0;
			object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2411 @ rax_v144 (UnityEngine.Transform)+10]");
			Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)obj12);
			bool flag18 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
			IntPtr intPtr = GameObject.get_transform_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
			Transform target = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(intPtr);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			bool flag19 = (nint)0 != 0;
			nint num8 = intPtr;
			if (!flag19)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				bool flag20 = obj13 == null;
				num8 = unchecked((nint)6573110936L);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2660 @ rax_v158 (should have been resolved before IL gen)");
			TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOScale(target, 200f, 1f);
			float delay = (float)obj3 * 0.03f;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = TweenSettingsExtensions.SetDelay(t, delay);
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2670 @ rax_v161 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 27;
					_ = 0;
				}
			}
			obj3++;
			bool flag21 = (nint)obj3 < 46;
			obj11 = obj14;
			if (!flag21)
			{
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void AddCameraPositionKeyFrames()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_0322: Unknown result type (might be due to invalid IL or missing references)
		//IL_0327: Expected O, but got Unknown
		//IL_04d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04de: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = obj2 - 95;
		_ = _cameraEndPos;
		object obj3 = default(object);
		float num = (float)obj3 * _cameraVelocity;
		float num2 = (float)_cameraDirection * _cameraVelocity;
		_ = _cameraDirection;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.UI.TPCreditsScene)+DC]");
		float num3 = 0f * _cameraVelocity;
		float num4 = num2 + num2;
		float num5 = num + num;
		float num6 = num3 + num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.UI.TPCreditsScene)+CC]");
		float num7 = 0f + num6;
		_ = _cameraEndPos;
		float num8 = (float)obj3 + num5;
		float num9 = (float)_cameraEndPos + num4;
		Keyframe[] keys = new Keyframe[4];
		_ = _cameraStartPos;
		_ = 0;
		_ = _cameraStartPos;
		_ = 0;
		_ = 0;
		_ = 1118502912;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1-39]");
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1-29]");
		_ = 0;
		_ = 0;
		_ = _cameraStartPos;
		_ = 0;
		_ = 1119748096;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1-39]");
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1-29]");
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1-59]");
		_ = 0;
		_ = 0;
		_ = 1120010240;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1-39]");
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1-29]");
		_ = 0;
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1-39]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1-29]");
		_ = 0;
		_ = 0;
		AnimationCurve animationCurve = new AnimationCurve();
		IntPtr ptr = AnimationCurve.Internal_Create(keys);
		animationCurve.m_Ptr = ptr;
		animationCurve.m_RequiresNativeCleanup = true;
		VampireSurvivors.App.Tools.Extensions.SetCurveLinear(animationCurve);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj5 = default(object);
		object obj4 = obj5 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type type = default(Type);
		AnimationCurve curve = default(AnimationCurve);
		_currentAnimationClip.SetCurve("AnimCamera", type, "m_LocalPosition.x", curve);
		Keyframe[] keys2 = new Keyframe[4];
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1-45]");
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 1118502912;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1-39]");
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1-29]");
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1-45]");
		_ = 0;
		_ = 0;
		_ = 1119748096;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1-39]");
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1-29]");
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1-55]");
		_ = 0;
		_ = 0;
		_ = 1120010240;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1-39]");
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1-29]");
		_ = 0;
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1-39]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1-29]");
		_ = 0;
		_ = 0;
		AnimationCurve animationCurve2 = new AnimationCurve();
		IntPtr ptr2 = AnimationCurve.Internal_Create(keys2);
		animationCurve2.m_Ptr = ptr2;
		animationCurve2.m_RequiresNativeCleanup = true;
		VampireSurvivors.App.Tools.Extensions.SetCurveLinear(animationCurve2);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj7 = default(object);
		object obj6 = obj7 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type type2 = default(Type);
		_currentAnimationClip.SetCurve("AnimCamera", type2, "m_LocalPosition.y", curve);
		Keyframe[] keys3 = new Keyframe[4];
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.UI.TPCreditsScene)+C0]");
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 1118502912;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1-39]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.UI.TPCreditsScene)+C0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1-29]");
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 1119748096;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1-39]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.UI.TPCreditsScene)+CC]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1-29]");
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 1120010240;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1-39]");
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1-29]");
		_ = 0;
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1-39]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1-29]");
		_ = 0;
		_ = 0;
		AnimationCurve animationCurve3 = new AnimationCurve();
		IntPtr ptr3 = AnimationCurve.Internal_Create(keys3);
		animationCurve3.m_Ptr = ptr3;
		animationCurve3.m_RequiresNativeCleanup = true;
		VampireSurvivors.App.Tools.Extensions.SetCurveLinear(animationCurve3);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj9 = default(object);
		object obj8 = obj9 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type type3 = default(Type);
		_currentAnimationClip.SetCurve("AnimCamera", type3, "m_LocalPosition.z", curve);
	}

	private unsafe void MathsStuff()
	{
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Expected O, but got Unknown
		//IL_0307: Unknown result type (might be due to invalid IL or missing references)
		//IL_030c: Expected O, but got Unknown
		//IL_0571: Expected I, but got O
		//IL_058e: Expected O, but got I
		//IL_05ab: Expected O, but got I
		//IL_05c8: Expected O, but got I
		//IL_0356: Unknown result type (might be due to invalid IL or missing references)
		//IL_035b: Expected O, but got Unknown
		//IL_03bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c4: Expected O, but got Unknown
		//IL_03f4: Expected O, but got I
		//IL_03fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ff: Expected O, but got Unknown
		//IL_042a: Expected O, but got F4
		//IL_0486: Unknown result type (might be due to invalid IL or missing references)
		//IL_048b: Expected O, but got Unknown
		//IL_04af: Expected O, but got I
		//IL_050e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0513: Expected O, but got Unknown
		//IL_02cf->IL0264: Incompatible stack heights: 1 vs 0
		//IL_007c->IL0264: Incompatible stack heights: 1 vs 0
		//IL_0187->IL0264: Incompatible stack heights: 2 vs 0
		//IL_01b3->IL0264: Incompatible stack heights: 2 vs 0
		//IL_0387->IL0264: Incompatible stack heights: 3 vs 0
		//IL_01e9->IL0264: Incompatible stack heights: 3 vs 0
		//IL_044e->IL0264: Incompatible stack heights: 4 vs 0
		//IL_021f->IL0264: Incompatible stack heights: 4 vs 0
		//IL_04d6->IL0264: Incompatible stack heights: 5 vs 0
		//IL_0255->IL0264: Incompatible stack heights: 5 vs 0
		if ((object)_AnimCamera != null)
		{
			Transform transform = _AnimCamera.transform;
			if ((object)transform != null)
			{
				_ = 0;
				_ = 0;
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				object obj2 = default(object);
				object obj = obj2 - 80;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj);
				if ((object)_DoilieOrigin != null)
				{
					Transform transform2 = _DoilieOrigin.transform;
					if ((object)transform2 != null)
					{
						_ = 0;
						_ = 0;
						bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						object obj3 = obj2 - 64;
						Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out *(Vector3*)obj3);
						nint num = (nint)typeof(Math);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-50]");
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-40]");
						object obj4 = num2 - 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-4C]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-3C]");
						object obj5 = num3 - 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-48]");
						nint num4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-38]");
						object obj6 = num4 - 0;
						object obj7 = obj5 * obj5;
						object obj8 = obj4 * obj4;
						object obj9 = obj6 * obj6;
						object obj10 = obj7 + obj8;
						double d = (double)obj10 + (double)obj9;
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v706 @ rcx_v41 (Il2CppClass<System.Math>)+E4]");
						if ((nint)0 <= (nint)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
						}
						else
						{
							double num5 = Math.Sqrt(d);
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm6,xmm0\"");
						float num6 = (_cameraVelocity = 0f / 0.35f) * 10f;
						float ringDistanceInterval = num6 / 21f;
						_ringDistanceInterval = ringDistanceInterval;
						if ((object)_DoilieOrigin != null)
						{
							Transform transform3 = _DoilieOrigin.transform;
							if ((object)transform3 != null)
							{
								_ = 0;
								_ = 0;
								bool flag3 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
								object obj11 = obj2 - 64;
								Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out *(Vector3*)obj11);
								if ((object)_AnimCamera != null)
								{
									Transform transform4 = _AnimCamera.transform;
									if ((object)transform4 != null)
									{
										_ = 0;
										_ = 0;
										bool flag4 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
										object obj12 = obj2 - 80;
										Transform.get_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out *(Vector3*)obj12);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-38]");
										nint num7 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-48]");
										object obj13 = num7 - 0;
										Vector3 vector = (Vector3)(this + 212);
										Vector3 vector2 = default(Vector3);
										_cameraDirection = vector2;
										Vector3 normalized = ((Vector3*)vector)->normalized;
										_cameraDirection = (Vector3)normalized.x;
										_ = normalized.z;
										if ((object)_AnimCamera != null)
										{
											Transform transform5 = _AnimCamera.transform;
											if ((object)transform5 != null)
											{
												_ = 0;
												_ = 0;
												bool flag5 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
												object obj14 = obj2 - 64;
												Transform.get_position_Injected(((UnityEngine.Object)transform5).m_CachedPtr, out *(Vector3*)obj14);
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-40]");
												_cameraStartPos = (Vector3)0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-38]");
												_ = 0;
												if ((object)_AnimCamera != null)
												{
													Transform transform6 = _AnimCamera.transform;
													if ((object)transform6 != null)
													{
														_ = 0;
														_ = 0;
														bool flag6 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
														object obj15 = obj2 - 64;
														Transform.get_position_Injected(((UnityEngine.Object)transform6).m_CachedPtr, out *(Vector3*)obj15);
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.UI.TPCreditsScene)+DC]");
														float num8 = 0f * num6;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-38]");
														float num9 = 0f + num8;
														_cameraEndPos = vector2;
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
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void AddCameraRotationKeyFrames()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00b4: Expected O, but got Ref
		//IL_091b: Expected O, but got Ref
		//IL_027c: Expected O, but got I
		//IL_0297: Expected F4, but got I4
		//IL_02a0: Expected O, but got I4
		//IL_02a9: Expected F4, but got I4
		//IL_0af7: Invalid comparison between I4 and F4
		//IL_02ef: Expected F4, but got I4
		//IL_096c: Expected O, but got I
		//IL_09ca: Expected O, but got F4
		//IL_09d3: Invalid comparison between I4 and F4
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		//IL_034f: Expected O, but got Unknown
		//IL_0369: Invalid comparison between I4 and F4
		//IL_03ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b2: Expected O, but got Unknown
		//IL_03cc: Invalid comparison between I4 and F4
		//IL_0421: Expected F4, but got I4
		//IL_0a2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a2f: Expected O, but got Unknown
		//IL_042f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0434: Expected O, but got Unknown
		//IL_045d: Invalid comparison between I4 and F4
		//IL_04b0: Expected F4, but got I4
		//IL_04c5: Expected F4, but got I
		//IL_04ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d3: Expected O, but got Unknown
		//IL_04dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e1: Expected O, but got Unknown
		//IL_0521: Expected F4, but got I4
		//IL_0645: Expected O, but got I
		//IL_0662: Unknown result type (might be due to invalid IL or missing references)
		//IL_0667: Expected O, but got Unknown
		//IL_06a8: Expected O, but got I
		//IL_06c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ca: Expected O, but got Unknown
		//IL_0715: Expected O, but got I
		//IL_0732: Unknown result type (might be due to invalid IL or missing references)
		//IL_0737: Expected O, but got Unknown
		//IL_077b: Expected O, but got I
		//IL_0798: Unknown result type (might be due to invalid IL or missing references)
		//IL_079d: Expected O, but got Unknown
		//IL_07e1: Expected O, but got I
		//IL_0852->IL07e2: Incompatible stack heights: 1 vs 0
		//IL_006c->IL07e2: Incompatible stack heights: 1 vs 0
		//IL_0098->IL07e2: Incompatible stack heights: 1 vs 0
		//IL_089f->IL07e2: Incompatible stack heights: 2 vs 0
		//IL_00ce->IL07e2: Incompatible stack heights: 2 vs 0
		//IL_00fa->IL07e2: Incompatible stack heights: 2 vs 0
		//IL_01af->IL07e2: Incompatible stack heights: 8 vs 0
		//IL_01fc->IL07e2: Incompatible stack heights: 9 vs 0
		//IL_0249->IL07e2: Incompatible stack heights: 10 vs 0
		//IL_09ac->IL07e2: Incompatible stack heights: 11 vs 0
		//IL_052a->IL0ade: Incompatible stack heights: 16 vs 11
		//IL_0b30->IL07e2: Incompatible stack heights: 16 vs 0
		//IL_0b55->IL07e2: Incompatible stack heights: 16 vs 0
		//IL_0b7a->IL07e2: Incompatible stack heights: 16 vs 0
		//IL_0b9f->IL07e2: Incompatible stack heights: 16 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if ((object)_AnimCamera != null)
		{
			Transform transform = _AnimCamera.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Quaternion _);
				if ((object)_AnimCamera != null)
				{
					Transform transform2 = _AnimCamera.transform;
					if ((object)_DoilieOrigin != null)
					{
						Transform transform3 = _DoilieOrigin.transform;
						if ((object)transform3 != null)
						{
							bool flag2 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out Vector3 _);
							if ((object)transform2 != null)
							{
								Quaternion ret3 = default(Quaternion);
								transform2.LookAt((Vector3)(&ret3));
								if ((object)_AnimCamera != null)
								{
									Transform transform4 = _AnimCamera.transform;
									if ((object)transform4 != null)
									{
										bool flag3 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
										Transform.get_rotation_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out ret3);
										bool flag4 = (object)_AnimCamera == null;
										Transform transform5 = _AnimCamera.transform;
										bool flag5 = (object)transform5 == null;
										bool flag6 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
										object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 64));
										Transform.set_rotation_Injected(((UnityEngine.Object)transform5).m_CachedPtr, ref *(Quaternion*)obj3);
										Keyframe[] array = new Keyframe[22];
										Keyframe[] array2 = new Keyframe[22];
										Keyframe[] array3 = new Keyframe[22];
										Keyframe[] array4 = new Keyframe[22];
										bool flag7 = array == null;
										bool flag8 = array.Length <= 0;
										_ = 0;
										_ = 0;
										_ = 0;
										if (array2 != null)
										{
											bool flag9 = array2.Length <= 0;
											_ = 0;
											_ = 0;
											_ = 0;
											if (array3 != null)
											{
												bool flag10 = array3.Length <= 0;
												_ = 0;
												_ = 0;
												_ = 0;
												if (array4 != null)
												{
													bool flag11 = array4.Length <= 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+A0]");
													object obj4 = 0;
													_ = 0;
													_ = 0;
													_ = 0;
													float num = 0f;
													Transform transform6 = (Transform)1;
													float time = 0f;
													object obj10 = default(object);
													object obj13 = default(object);
													object obj14 = default(object);
													object obj18 = default(object);
													Type type = default(Type);
													AnimationCurve curve = default(AnimationCurve);
													object obj20 = default(object);
													Type type3 = default(Type);
													object obj22 = default(object);
													Type type4 = default(Type);
													object obj24 = default(object);
													Type type5 = default(Type);
													while (true)
													{
														float num2 = (float)transform6 / 21f;
														float num3 = ((0f > num2) ? 0f : ((num2 > 1f) ? 1f : num2));
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rsi_v15+78]");
														object obj5 = 0;
														float num4 = num3 * 9.5f;
														float num5 = num4 + 85.5f;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rsi_v15+78]");
														if ((nint)0 == 0)
														{
															break;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ rcx_v52 (System.Object)+10]");
														bool flag12 = (nint)0 == 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ rcx_v52 (System.Object)+10]");
														object obj6 = AnimationCurve.Evaluate_Injected((IntPtr)0, time);
														if (0f > num || !(num > 1f))
														{
														}
														bool flag13 = (nint)transform6 >= array.Length;
														object obj7 = transform6 * 28;
														_ = 0;
														_ = 0;
														if (0f > num || !(num > 1f))
														{
														}
														bool flag14 = (nint)transform6 >= array2.Length;
														object obj8 = transform6 * 28;
														_ = 0;
														_ = 0;
														float num6 = ((0f > num) ? 0f : ((num > 1f) ? 1f : num));
														object obj9 = 0 - obj10;
														_ = 0;
														_ = 0;
														float num7 = (float)obj9 * num6;
														float num8 = num7 + (float)obj10;
														bool flag15 = (nint)transform6 >= array3.Length;
														object obj11 = transform6 * 28;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
														_ = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-70]");
														_ = 0;
														_ = 0;
														float num9;
														if (!(0f > num))
														{
															bool flag16 = !(num > 1f);
															num9 = num;
															if (!flag16)
															{
																num9 = 1f;
															}
														}
														else
														{
															num9 = 0f;
														}
														object obj12 = obj13 - obj14;
														_ = 0;
														_ = 0;
														float num10 = (float)obj12 * num9;
														float num11 = num10 + (float)obj14;
														bool flag17 = (nint)transform6 >= array4.Length;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-60]");
														num = 0f;
														Transform transform7 = (Transform)(transform6 + 1);
														object obj15 = transform6 * 28;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-60]");
														_ = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-50]");
														_ = 0;
														_ = 0;
														bool flag18 = (nint)transform7 < 21;
														transform6 = transform7;
														time = 0f;
														if (!flag18)
														{
															AnimationCurve animationCurve = new AnimationCurve();
															IntPtr ptr = AnimationCurve.Internal_Create(array);
															animationCurve.m_Ptr = ptr;
															animationCurve.m_RequiresNativeCleanup = true;
															AnimationCurve animationCurve2 = new AnimationCurve();
															IntPtr ptr2 = AnimationCurve.Internal_Create(array2);
															animationCurve2.m_Ptr = ptr2;
															animationCurve2.m_RequiresNativeCleanup = true;
															AnimationCurve animationCurve3 = new AnimationCurve();
															IntPtr ptr3 = AnimationCurve.Internal_Create(array3);
															animationCurve3.m_Ptr = ptr3;
															animationCurve3.m_RequiresNativeCleanup = true;
															AnimationCurve animationCurve4 = new AnimationCurve();
															IntPtr ptr4 = AnimationCurve.Internal_Create(array4);
															animationCurve4.m_Ptr = ptr4;
															animationCurve4.m_RequiresNativeCleanup = true;
															VampireSurvivors.App.Tools.Extensions.SetCurveLinear(animationCurve);
															VampireSurvivors.App.Tools.Extensions.SetCurveLinear(animationCurve2);
															VampireSurvivors.App.Tools.Extensions.SetCurveLinear(animationCurve3);
															VampireSurvivors.App.Tools.Extensions.SetCurveLinear(animationCurve4);
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+A0]");
															object obj16 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
															object obj17 = obj18 + 32;
															Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ r12_v15+A8]");
															if ((nint)0 == 0)
															{
																break;
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ r12_v15+A8]");
															((AnimationClip)0).SetCurve("AnimCamera", type, "m_LocalRotation.x", curve);
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
															object obj19 = obj20 + 32;
															Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
															Type type2 = null;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ r12_v15+A8]");
															if ((nint)0 == 0)
															{
																break;
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ r12_v15+A8]");
															((AnimationClip)0).SetCurve("AnimCamera", type3, "m_LocalRotation.y", curve);
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
															object obj21 = obj22 + 32;
															Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ r12_v15+A8]");
															if ((nint)0 == 0)
															{
																break;
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ r12_v15+A8]");
															((AnimationClip)0).SetCurve("AnimCamera", type4, "m_LocalRotation.z", curve);
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
															object obj23 = obj24 + 32;
															Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ r12_v15+A8]");
															if ((nint)0 == 0)
															{
																break;
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ r12_v15+A8]");
															((AnimationClip)0).SetCurve("AnimCamera", type5, "m_LocalRotation.w", curve);
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
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void PlayVideo()
	{
		if ((object)_Video != null)
		{
			GameObject gameObject = _Video.gameObject;
			if ((object)gameObject != null)
			{
				gameObject.SetActive(value: true);
				if ((object)_Video != null)
				{
					_Video.enabled = true;
					TPCreditsScene video = (TPCreditsScene)(object)_Video;
					if ((object)_Video != null)
					{
						bool flag = ((UnityEngine.Object)video).m_CachedPtr == (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
						Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 88 ConditionalJump @-1, v138 @ ZF_v9 (System.Boolean) --- -1 Nop");
						/*Error: End of method reached without returning.*/;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void SetPlaying(bool v, float startTime)
	{
		isPlaying = v;
		_currentTime = startTime;
		Sprite sprite = SpriteManager.GetSprite("castle02_COMP04_Background");
		_Background.sprite = sprite;
		Sprite sprite2 = SpriteManager.GetSprite("castle02_COMP04_Foreground");
		_Castle.sprite = sprite2;
	}

	public void ReturnToMenu()
	{
		//IL_0019: Expected I, but got O
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_01d5->IL017d: Incompatible stack heights: 1 vs 0
		//IL_020e->IL017d: Incompatible stack heights: 1 vs 0
		//IL_00b6->IL017d: Incompatible stack heights: 1 vs 0
		//IL_00e2->IL017d: Incompatible stack heights: 1 vs 0
		//IL_010f->IL017d: Incompatible stack heights: 1 vs 0
		//IL_0139->IL017d: Incompatible stack heights: 1 vs 0
		//IL_016e->IL017d: Incompatible stack heights: 1 vs 0
		Debug.Log("RETURNING TO MENU");
		nint num = (nint)_Video;
		if ((object)_Video != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rbx_v1 (Il2CppClass<VampireSurvivors.Signals.UISignals+CloseTPCreditsSignal>)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rbx_v1 (Il2CppClass<VampireSurvivors.Signals.UISignals+CloseTPCreditsSignal>)+10]");
			VideoPlayer.Stop_Injected((IntPtr)0);
			if (_signalBus != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
				object obj2 = default(object);
				object obj = obj2 + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
				Type signalType = default(Type);
				bool requireDeclaration = default(bool);
				_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
				if ((object)_AnimCamera != null)
				{
					_AnimCamera.SetActive(value: false);
					if ((object)_RingContainer != null)
					{
						GameObject gameObject = _RingContainer.gameObject;
						if ((object)gameObject != null)
						{
							gameObject.SetActive(value: false);
							if ((object)_page != null)
							{
								_page.DisableAllInput();
								if (_signalBus != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1BC0");
									Canvas canvas = UIHelper.Canvas;
									if ((object)canvas != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rax_v32 (UnityEngine.Canvas)+10]");
										bool flag2 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
										Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 90 ConditionalJump @-1, v224 @ ZF_v10 (System.Boolean) --- -1 Nop");
										Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 345 ConditionalJump @-1, v495 @ ZF_v27 (System.Boolean) --- -1 Nop");
										/*Error: End of method reached without returning.*/;
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

	public void GoToCharacterSelectScreen()
	{
		PlayerOptionsData config = _playerOptions.Config;
		config.SelectedCharacter = CharacterType.TP_DRACULA;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9FC30");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1AE0");
	}

	public void SelectDraculaAndRelease()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_021e: Expected I, but got O
		//IL_023a: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		IntPtr intPtr = default(IntPtr);
		num = intPtr;
		object obj3 = default(object);
		object signal = (IntPtr)obj3;
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
		_multiplayer.EnableAllUIInteraction();
		PlayerOptionsData config = _playerOptions.Config;
		config._003CShowTPCredits_003Ek__BackingField = false;
		if (_achievementManager != null)
		{
			Dictionary<DlcType, BundleManifestData> loadedDlc = DlcSystem.LoadedDlc;
			int num2 = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc).FindEntry((System.Int32Enum)5);
			if (num2 >= 0)
			{
				if (_achievementManager.CheckHaveOpenedCoffinForXCharacter(CharacterType.TP_DRACULA))
				{
					bool flag = _achievementManager.Unlock(AchievementType.TP_Dracula_FindCoffin3);
				}
				PlayerOptionsData config2 = _playerOptions.Config;
				List<ItemType> list = config2._003CCollectedItems_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rcx_v33 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
					object obj4 = default(object);
					if ((nint)obj4 != -1)
					{
						bool flag2 = _achievementManager.Unlock(AchievementType.TP_Relic_BlackDisk);
					}
				}
			}
		}
		BackButtonController instance = BackButtonController.Instance;
		instance.ListenForControllerInput = true;
		BackButtonController.BackButtonClosesPage = true;
		AddressableCache.RemoveTexturesFromCacheAndSpriteManager(TPCreditsPage.CACHE_GROUP_NAME);
		AddressableCache.ReleaseCustomOperationHandleGroup(TPCreditsPage.CACHE_GROUP_NAME);
	}

	private void RunManualAchievementChecks()
	{
		if (_achievementManager == null)
		{
			return;
		}
		Dictionary<DlcType, BundleManifestData> loadedDlc = DlcSystem.LoadedDlc;
		int num = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc).FindEntry((System.Int32Enum)5);
		if (num < 0)
		{
			return;
		}
		if (_achievementManager.CheckHaveOpenedCoffinForXCharacter(CharacterType.TP_DRACULA))
		{
			bool flag = _achievementManager.Unlock(AchievementType.TP_Dracula_FindCoffin3);
		}
		PlayerOptionsData config = _playerOptions.Config;
		List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rcx_v14 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				bool flag2 = _achievementManager.Unlock(AchievementType.TP_Relic_BlackDisk);
			}
		}
	}

	public void SetAnimTime(float time)
	{
		//IL_009e: Invalid comparison between I4 and F4
		//IL_006a: Expected F4, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A36A1]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
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

	public unsafe void SpawnDoilie()
	{
		//IL_003a: Expected O, but got I8
		//IL_04c3: Expected O, but got I4
		//IL_016b: Expected O, but got I
		//IL_0420: Expected O, but got Ref
		//IL_02fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ff: Expected O, but got Unknown
		//IL_0316: Unknown result type (might be due to invalid IL or missing references)
		//IL_031b: Expected O, but got Unknown
		//IL_0332: Unknown result type (might be due to invalid IL or missing references)
		//IL_0337: Expected O, but got Unknown
		//IL_05a7: Expected O, but got I4
		//IL_05b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bc: Expected O, but got Unknown
		//IL_04a4->IL042a: Incompatible stack heights: 1 vs 0
		//IL_00ef->IL042a: Incompatible stack heights: 1 vs 0
		//IL_0123->IL042a: Incompatible stack heights: 2 vs 0
		//IL_018c->IL042a: Incompatible stack heights: 3 vs 0
		//IL_01c0->IL042a: Incompatible stack heights: 3 vs 0
		_003C_003Ec__DisplayClass67_0 CS_0024_003C_003E8__locals31 = new _003C_003Ec__DisplayClass67_0();
		Vector3 value = default(Vector3);
		if (CS_0024_003C_003E8__locals31 != null)
		{
			CS_0024_003C_003E8__locals31.outDuration = 0.2f;
			GameObject g = UnityEngine.Object.Instantiate(_DoilieSpritePrefab, _DoilieOrigin);
			object obj = 6603577472L;
			CS_0024_003C_003E8__locals31.g = g;
			if ((object)CS_0024_003C_003E8__locals31.g != null)
			{
				Transform transform = CS_0024_003C_003E8__locals31.g.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					if ((object)CS_0024_003C_003E8__locals31.g != null)
					{
						SpriteRenderer component = CS_0024_003C_003E8__locals31.g.GetComponent<SpriteRenderer>();
						CS_0024_003C_003E8__locals31.image = component;
						Transform doilieSprites = (Transform)(object)_DoilieSprites;
						if (_DoilieSprites != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rdi_v12 (UnityEngine.Transform)+18]");
							object obj2 = UnityEngine.Random.RandomRangeInt(0, 0);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rdi_v12 (UnityEngine.Transform)+18]");
							bool flag2 = (nint)obj2 >= 0;
							IntPtr cachedPtr = ((UnityEngine.Object)doilieSprites).m_CachedPtr;
							if (((UnityEngine.Object)doilieSprites).m_CachedPtr != (IntPtr)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rcx_v32 (System.IntPtr)+18]");
								bool flag3 = (nint)obj2 >= 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rcx_v32 (System.IntPtr)+20+v127 @ rax_v36*8]");
								Sprite sprite = SpriteManager.GetSprite((string)0, "vfx");
								if ((object)CS_0024_003C_003E8__locals31.image != null)
								{
									CS_0024_003C_003E8__locals31.image.sprite = sprite;
									if ((object)CS_0024_003C_003E8__locals31.g != null)
									{
										Transform transform2 = CS_0024_003C_003E8__locals31.g.transform;
										bool flag4 = (object)transform2 == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v947 @ rax_v41 (UnityEngine.Transform)+10]");
										bool flag5 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v947 @ rax_v41 (UnityEngine.Transform)+10]");
										Vector3 value2 = default(Vector3);
										Transform.set_localScale_Injected((IntPtr)0, ref value2);
										TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(CS_0024_003C_003E8__locals31.image, 1f, 0.8f);
										TweenCallback tweenCallback = delegate
										{
											TweenerCore<Color, Color, ColorOptions> tweenerCore4 = DOTweenModuleSprite.DOFade(CS_0024_003C_003E8__locals31.image, 0f, CS_0024_003C_003E8__locals31.outDuration);
										};
										if (tweenerCore != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1004 @ rax_v49 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
											if ((nint)0 == 0)
											{
											}
										}
										bool flag6 = (object)CS_0024_003C_003E8__locals31.g == null;
										Transform target = CS_0024_003C_003E8__locals31.g.transform;
										TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(target, 5f, 0.8f);
										TweenCallback tweenCallback3;
										if (tweenerCore2 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1075 @ rax_v54 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
											if ((nint)0 != 0)
											{
												_ = 6;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
												bool flag7 = (nint)0 == 0;
												_ = 0;
												if (!flag7)
												{
													object obj3 = tweenerCore2 + 184;
													object obj4 = obj3 >> 12;
													object obj5 = obj4 & 0x1FFFFF;
													object obj6 = obj5 >> 6;
													object obj7 = obj5 & 0x3F;
													nint num2;
													do
													{
														object obj8 = 1 << (int)obj7;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ r14_v10+462E0+v1147 @ rdx_v39*8]");
														object obj9 = 0 | obj8;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ r14_v10+462E0+v1147 @ rdx_v39*8]");
														nint num = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ r14_v10+462E0+v1147 @ rdx_v39*8]");
														if (num == 0)
														{
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ r14_v10+462E0+v1147 @ rdx_v39*8]");
														num2 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ r14_v10+462E0+v1147 @ rdx_v39*8]");
													}
													while (num2 != 0);
													TweenCallback tweenCallback2 = delegate
													{
														Transform target3 = CS_0024_003C_003E8__locals31.g.transform;
														TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore4 = ShortcutExtensions.DOScale(target3, 4f, CS_0024_003C_003E8__locals31.outDuration);
														if (tweenerCore4 != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v4 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
															if ((nint)0 != 0)
															{
																_ = 5;
																_ = 0;
															}
														}
														TweenCallback tweenCallback5 = CS_0024_003C_003E8__locals31._003C_003E9__2;
														if (CS_0024_003C_003E8__locals31._003C_003E9__2 == null)
														{
															tweenCallback5 = (CS_0024_003C_003E8__locals31._003C_003E9__2 = delegate
															{
																CS_0024_003C_003E8__locals31.g.SetActive(value: false);
															});
														}
														if (tweenerCore4 != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v4 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
															if ((nint)0 == 0)
															{
															}
														}
													};
													tweenCallback3 = tweenCallback2;
													goto IL_03aa;
												}
											}
										}
										TweenCallback tweenCallback4 = delegate
										{
											Transform target3 = CS_0024_003C_003E8__locals31.g.transform;
											TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore4 = ShortcutExtensions.DOScale(target3, 4f, CS_0024_003C_003E8__locals31.outDuration);
											if (tweenerCore4 != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v4 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
												if ((nint)0 != 0)
												{
													_ = 5;
													_ = 0;
												}
											}
											TweenCallback tweenCallback5 = CS_0024_003C_003E8__locals31._003C_003E9__2;
											if (CS_0024_003C_003E8__locals31._003C_003E9__2 == null)
											{
												tweenCallback5 = (CS_0024_003C_003E8__locals31._003C_003E9__2 = delegate
												{
													CS_0024_003C_003E8__locals31.g.SetActive(value: false);
												});
											}
											if (tweenerCore4 != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v4 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
												if ((nint)0 == 0)
												{
												}
											}
										};
										bool flag8 = tweenerCore2 == null;
										tweenCallback3 = tweenCallback4;
										if (!flag8)
										{
											goto IL_03aa;
										}
										goto IL_03d9;
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_03aa:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1075 @ rax_v54 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_03d9;
		IL_03d9:
		bool flag9 = (object)CS_0024_003C_003E8__locals31.g == null;
		Transform target2 = CS_0024_003C_003E8__locals31.g.transform;
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore3 = ShortcutExtensions.DOLocalRotate(target2, (Vector3)(&value), 10f, RotateMode.LocalAxisAdd);
	}

	private unsafe void OnDrawGizmos()
	{
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected O, but got Unknown
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Expected O, but got Unknown
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Expected O, but got Unknown
		//IL_0202: Expected O, but got I
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Expected O, but got Unknown
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Expected O, but got Unknown
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Expected O, but got Unknown
		//IL_012c->IL00c1: Incompatible stack heights: 1 vs 0
		//IL_007c->IL00c1: Incompatible stack heights: 1 vs 0
		//IL_0195->IL00c1: Incompatible stack heights: 2 vs 0
		//IL_00b2->IL00c1: Incompatible stack heights: 2 vs 0
		if ((object)_AnimCamera != null)
		{
			Transform transform = _AnimCamera.transform;
			if ((object)transform != null)
			{
				_ = 0;
				_ = 0;
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				object obj2 = default(object);
				object obj = obj2 - 64;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj);
				if ((object)_DoilieOrigin != null)
				{
					Transform transform2 = _DoilieOrigin.transform;
					if ((object)transform2 != null)
					{
						_ = 0;
						_ = 0;
						bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						object obj3 = obj2 - 48;
						Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out *(Vector3*)obj3);
						if ((object)_AnimCamera != null)
						{
							Transform transform3 = _AnimCamera.transform;
							if ((object)transform3 != null)
							{
								_ = 0;
								_ = 0;
								bool flag3 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
								object obj4 = obj2 - 32;
								Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out *(Vector3*)obj4);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-28]");
								nint num = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-18]");
								object obj5 = num - 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-38]");
								object obj6 = 0 + obj5;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-38]");
								_ = 0;
								object obj7 = obj2 - 48;
								object obj8 = obj2 - 64;
								Gizmos.DrawLine_Injected(ref *(Vector3*)obj8, ref *(Vector3*)obj7);
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public TPCreditsScene()
	{
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"doi01");
		}
		else
		{
			int size = list._size + 1;
			list._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list._version + 1;
		list._version = version2;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"doi02");
		}
		else
		{
			int size2 = list._size + 1;
			list._size = size2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version3 = list._version + 1;
		list._version = version3;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"doi03");
		}
		else
		{
			int size3 = list._size + 1;
			list._size = size3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version4 = list._version + 1;
		list._version = version4;
		string[] items4 = list._items;
		if (list._size >= items4.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"doi04");
		}
		else
		{
			int size4 = list._size + 1;
			list._size = size4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version5 = list._version + 1;
		list._version = version5;
		string[] items5 = list._items;
		if (list._size >= items5.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"doi05");
		}
		else
		{
			int size5 = list._size + 1;
			list._size = size5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version6 = list._version + 1;
		list._version = version6;
		string[] items6 = list._items;
		if (list._size >= items6.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"doi06");
		}
		else
		{
			int size6 = list._size + 1;
			list._size = size6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version7 = list._version + 1;
		list._version = version7;
		string[] items7 = list._items;
		if (list._size >= items7.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"doi07");
		}
		else
		{
			int size7 = list._size + 1;
			list._size = size7;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version8 = list._version + 1;
		list._version = version8;
		string[] items8 = list._items;
		if (list._size >= items8.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"doi08");
		}
		else
		{
			int size8 = list._size + 1;
			list._size = size8;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version9 = list._version + 1;
		list._version = version9;
		string[] items9 = list._items;
		if (list._size >= items9.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"doi09");
		}
		else
		{
			int size9 = list._size + 1;
			list._size = size9;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version10 = list._version + 1;
		list._version = version10;
		string[] items10 = list._items;
		if (list._size >= items10.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"doi05");
		}
		else
		{
			int size10 = list._size + 1;
			list._size = size10;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		_DoilieSprites = list;
		List<GameObject> ringPrefabs = new List<GameObject>();
		_RingPrefabs = ringPrefabs;
		List<KeyValuePair<float, string>> timeCodesFromAudio = new List<KeyValuePair<float, string>>();
		_timeCodesFromAudio = timeCodesFromAudio;
		List<CharacterType> charsToUnlock = new List<CharacterType>();
		_charsToUnlock = charsToUnlock;
	}
}
