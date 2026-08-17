using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Rendering.Universal;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Stages;

public class BackgroundDevilRoom_Helper
{
	private sealed class _003C_003Ec__DisplayClass39_0
	{
		public Vector2 position;

		internal int _003CWallEyes_003Eb__0(Vector2 v1, Vector2 v2)
		{
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Expected O, but got Unknown
			//IL_01b3: Expected I4, but got I8
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_010f: Expected O, but got Unknown
			//IL_013c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0141: Expected O, but got Unknown
			//IL_0159: Unknown result type (might be due to invalid IL or missing references)
			//IL_015e: Expected O, but got Unknown
			//IL_0190: Expected O, but got I4
			//IL_0199: Unknown result type (might be due to invalid IL or missing references)
			//IL_019e: Expected I4, but got Unknown
			object obj = v1 - position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.BackgroundDevilRoom_Helper+<>c__DisplayClass39_0)+14]");
			object obj3 = default(object);
			object obj2 = obj3 - 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.BackgroundDevilRoom_Helper+<>c__DisplayClass39_0)+14]");
			object obj5 = default(object);
			object obj4 = obj5 - 0;
			object obj6 = obj * obj;
			object obj7 = obj2 * obj2;
			object obj8 = obj7 + obj6;
			object obj9 = v2 - position;
			object obj10 = obj4 * obj4;
			object obj11 = obj9 * obj9;
			object obj12 = obj10 + obj11;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj12) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8))
			{
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj12))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186E6BDF8h\"");
					if (obj8 == obj12)
					{
						return 0;
					}
					object obj13 = obj8 & -2147483649L;
					if ((nint)obj13 > 2139095040)
					{
						object obj14 = obj12 & -2147483649L;
						bool flag = (nint)obj14 < 2139095040;
						object obj15 = obj14 - 2139095040;
						bool flag2 = obj15 == null;
						bool flag3 = !flag;
						bool flag4 = !flag2;
						object obj16 = flag4 & flag3;
						return obj16 - 1;
					}
				}
				return 1;
			}
			return -1;
		}
	}

	private sealed class _003C_003Ec__DisplayClass45_0
	{
		public PhaserSprite _eyeSprite;

		internal void _003CBackgroundEyes_003Eb__0()
		{
			PhaserSprite phaserSprite = _eyeSprite.setAlpha(0f);
		}
	}

	private sealed class _003C_003Ec__DisplayClass54_0
	{
		public PhaserSprite sprite;

		public float __scale;

		internal void _003CTweenEye_003Eb__0()
		{
			PhaserSprite phaserSprite = RenderingExtensions.SetScale(sprite, __scale, 0f);
		}
	}

	private sealed class _003C_003Ec__DisplayClass56_0
	{
		public BackgroundDevilRoom_Helper _003C_003E4__this;

		public SpriteRenderer s;

		public int i;

		internal void _003CReTween_003Eb__0()
		{
			_003C_003E4__this.ReTween(s, i);
		}
	}

	public BackgroundDevilRoom backgroundManager;

	public PhaserScene scene;

	public ParticleSystem TopEmitter;

	public ParticleSystem BottomEmitter;

	public ParticleSystem SkullsEmitter;

	public PhaserSprite _darkBackground;

	public PhaserSprite _lightBackground;

	public MultiTargetTween _tween1;

	public MultiTargetTween _tween2;

	public Light2D _globalLight;

	private float _currentCameraAngleZ = 0.5f;

	private Sequence _pulseLightSeq;

	private TweenerCore<float, float, FloatOptions> _darkToLightTween;

	private List<SpriteRenderer> _backgroundClouds;

	private List<MultiTargetTween> _movingBgTweens;

	private Transform _spritesRootTransform;

	private PlaySoundResult _geiger1AL;

	private PlaySoundResult _geiger2AR;

	private PlaySoundResult _geiger3BL;

	private PlaySoundResult _geiger4BR;

	public PhaserSprite _centralSprite;

	private MultiTargetTween _eyeTween;

	private float IntroDurationMS;

	private float LoopDurationMS;

	private List<string> _eyeFrames;

	private List<string> _eyeFrames2;

	private Timer bloodEmitterTimer;

	private Timer _musicIntroTimedEvent;

	private Timer _musicLoopEvent;

	private TweenerCore<Vector3, Vector3, VectorOptions> _eyeScaleTween;

	private Light2D _redLight;

	private int _wallEyesCounter;

	private List<PhaserSprite> _eyeWallSprites;

	private int _backgroundEyesCounter;

	private List<PhaserSprite> _eyeSprites;

	private float _geigerTime;

	private bool _isPlayingGeigerNoise;

	private bool _bgEnabled;

	public BackgroundDevilRoom_Helper(PhaserScene _scene, BackgroundDevilRoom _backgroundManager)
	{
		List<SpriteRenderer> backgroundClouds = new List<SpriteRenderer>();
		_backgroundClouds = backgroundClouds;
		List<MultiTargetTween> movingBgTweens = new List<MultiTargetTween>();
		_movingBgTweens = movingBgTweens;
		IntroDurationMS = 8571f;
		LoopDurationMS = 86530f;
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"dk_eye1");
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
			((List<object>)(object)list).AddWithResize((object)"dk_eye2");
		}
		else
		{
			int size2 = list._size + 1;
			list._size = size2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		_eyeFrames = list;
		List<string> list2 = new List<string>();
		int version3 = list2._version + 1;
		list2._version = version3;
		string[] items3 = list2._items;
		if (list2._size >= items3.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"dk_eyes1");
		}
		else
		{
			int size3 = list2._size + 1;
			list2._size = size3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version4 = list2._version + 1;
		list2._version = version4;
		string[] items4 = list2._items;
		if (list2._size >= items4.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"dk_eyes2");
		}
		else
		{
			int size4 = list2._size + 1;
			list2._size = size4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version5 = list2._version + 1;
		list2._version = version5;
		string[] items5 = list2._items;
		if (list2._size >= items5.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"dk_mouth1");
		}
		else
		{
			int size5 = list2._size + 1;
			list2._size = size5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		_eyeFrames2 = list2;
		_bgEnabled = true;
		backgroundManager = _backgroundManager;
		scene = _scene;
		MakeEmitters();
		MakeBackgrounds();
		GameManager core = GM.Core;
		_globalLight = core._GlobalLight;
		Light2D globalLight = _globalLight;
		globalLight.m_BlendStyleIndex = 0;
		Light2D globalLight2 = _globalLight;
		globalLight2.m_LightOrder = 17;
		Light2D globalLight3 = _globalLight;
		globalLight3.m_OverlapOperation = Light2D.OverlapOperation.AlphaBlend;
		Light2D globalLight4 = _globalLight;
		globalLight4.m_Intensity = 0f;
		Action onComplete = delegate
		{
			if (_darkToLightTween != null)
			{
				DG.Tweening.TweenExtensions.Kill(_darkToLightTween);
			}
			DOGetter<float> getter = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
			DOSetter<float> dOSetter = null;
			float x = default(float);
			((BackgroundDevilRoom_Helper)(object)dOSetter)._003CDarkToLight_003Eb__33_1(x);
			TweenerCore<float, float, FloatOptions> darkToLightTween = DOTween.To(getter, dOSetter, 1f, 0.25f);
			_darkToLightTween = darkToLightTween;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete2 = delegate
		{
			StartMusic();
		};
		Timer timer2 = Timers.Register(0.5f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 767 Invalid \"Jump target not found in method: 0x186F23BC0\"");
		throw new NullReferenceException();
	}

	public void MakeRedLight()
	{
		//IL_0117: Expected O, but got I
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, "RedLight");
		if ((object)gameObject != null)
		{
			Transform transform = gameObject.transform;
			Camera main = Camera.main;
			if ((object)main != null)
			{
				Transform transform2 = main.transform;
				if ((object)transform != null)
				{
					transform.SetParent(transform2, worldPositionStays: true);
					Transform transform3 = gameObject.transform;
					if ((object)transform3 != null)
					{
						bool flag = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
						Vector3 value = default(Vector3);
						Transform.set_localPosition_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value);
						Light2D redLight = gameObject.AddComponent<Light2D>();
						_redLight = redLight;
						Light2D redLight2 = _redLight;
						bool flag2 = (object)_redLight == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F50]");
						redLight2.m_Color = (Color)0;
						bool flag3 = (object)_redLight == null;
						_redLight.lightType = Light2D.LightType.Point;
						Light2D redLight3 = _redLight;
						bool flag4 = (object)_redLight == null;
						redLight3.m_PointLightOuterRadius = 8f;
						Light2D redLight4 = _redLight;
						bool flag5 = (object)_redLight == null;
						redLight4.m_Intensity = 0f;
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void DarkToLight(float value = 1f)
	{
		if (_darkToLightTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_darkToLightTween);
		}
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		((BackgroundDevilRoom_Helper)(object)dOSetter)._003CDarkToLight_003Eb__33_1(value);
		TweenerCore<float, float, FloatOptions> darkToLightTween = DOTween.To(getter, dOSetter, value, 0.25f);
		_darkToLightTween = darkToLightTween;
	}

	public void StartMusic()
	{
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rcx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				goto IL_00ef;
			}
		}
		GameManager core2 = GM.Core;
		PlayerOptionsData config2 = core2._playerOptions.Config;
		config2._003CSelectedBGM_003Ek__BackingField = BgmType.BGM_Devil;
		GameManager core3 = GM.Core;
		PlayerOptionsData config3 = core3._playerOptions.Config;
		config3._003CSelectedBGMMod_003Ek__BackingField = BgmModType.Normal;
		GM.Core.SetupMusicBanger();
		goto IL_00ef;
		IL_00ef:
		Action onComplete = delegate
		{
			RegisterMusicLoopEvents();
			Action onComplete2 = RegisterMusicLoopEvents;
			bool useRealTime2 = default(bool);
			MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
			int repeat2 = default(int);
			Timer musicLoopEvent = TimerHelper.RegisterMillisUI(LoopDurationMS, onComplete2, null, isLooped: true, useRealTime2, autoDestroyOwner2, repeat2);
			_musicLoopEvent = musicLoopEvent;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		Timer musicIntroTimedEvent = TimerHelper.RegisterMillisUI(IntroDurationMS, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		_musicIntroTimedEvent = musicIntroTimedEvent;
	}

	private void RegisterMusicLoopEvents()
	{
		Action onComplete = delegate
		{
			RedLightSwoop(10);
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		Timer timer = TimerHelper.RegisterMillisUI(28700f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete2 = delegate
		{
			WallEyes(1);
		};
		Timer timer2 = TimerHelper.RegisterMillisUI(31000f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete3 = delegate
		{
			RedLightSwoop(9);
		};
		Timer timer3 = TimerHelper.RegisterMillisUI(34600f, onComplete3, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete4 = delegate
		{
			WallEyes(2);
		};
		Timer timer4 = TimerHelper.RegisterMillisUI(35400f, onComplete4, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete5 = delegate
		{
			WallEyes(5);
		};
		Timer timer5 = TimerHelper.RegisterMillisUI(38600f, onComplete5, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete6 = delegate
		{
			WallEyes(5);
		};
		Timer timer6 = TimerHelper.RegisterMillisUI(41900f, onComplete6, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete7 = delegate
		{
			RedLightSwoop(8);
		};
		Timer timer7 = TimerHelper.RegisterMillisUI(41800f, onComplete7, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete8 = delegate
		{
			WallEyes(6);
		};
		Timer timer8 = TimerHelper.RegisterMillisUI(45300f, onComplete8, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete9 = delegate
		{
			RedLightSwoop(7);
		};
		Timer timer9 = TimerHelper.RegisterMillisUI(47800f, onComplete9, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete10 = delegate
		{
			WallEyes(7);
		};
		Timer timer10 = TimerHelper.RegisterMillisUI(51700f, onComplete10, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete11 = delegate
		{
			WallEyes(7);
		};
		Timer timer11 = TimerHelper.RegisterMillisUI(54900f, onComplete11, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete12 = delegate
		{
			WallEyes(7);
		};
		Timer timer12 = TimerHelper.RegisterMillisUI(58300f, onComplete12, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete13 = delegate
		{
			WallEyes(7);
		};
		Timer timer13 = TimerHelper.RegisterMillisUI(61300f, onComplete13, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete14 = delegate
		{
			RedLightSwoop(6);
		};
		Timer timer14 = TimerHelper.RegisterMillisUI(60800f, onComplete14, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete15 = delegate
		{
			WallEyes(8);
		};
		Timer timer15 = TimerHelper.RegisterMillisUI(63000f, onComplete15, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete16 = delegate
		{
			WallEyes(8);
		};
		Timer timer16 = TimerHelper.RegisterMillisUI(64800f, onComplete16, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete17 = delegate
		{
			WallEyes(8);
		};
		Timer timer17 = TimerHelper.RegisterMillisUI(66200f, onComplete17, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete18 = delegate
		{
			RedLightSwoop(5);
		};
		Timer timer18 = TimerHelper.RegisterMillisUI(69400f, onComplete18, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete19 = delegate
		{
			WallEyes(9);
		};
		Timer timer19 = TimerHelper.RegisterMillisUI(71200f, onComplete19, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete20 = delegate
		{
			WallEyes(10);
		};
		Timer timer20 = TimerHelper.RegisterMillisUI(72900f, onComplete20, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete21 = delegate
		{
			RedLightSwoop(4);
		};
		Timer timer21 = TimerHelper.RegisterMillisUI(79000f, onComplete21, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete22 = delegate
		{
			WallEyes(11);
		};
		Timer timer22 = TimerHelper.RegisterMillisUI(76700f, onComplete22, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete23 = delegate
		{
			WallEyes(11);
		};
		Timer timer23 = TimerHelper.RegisterMillisUI(76904f, onComplete23, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete24 = delegate
		{
			WallEyes(11);
		};
		Timer timer24 = TimerHelper.RegisterMillisUI(77312f, onComplete24, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete25 = delegate
		{
			WallEyes(11);
		};
		Timer timer25 = TimerHelper.RegisterMillisUI(77720f, onComplete25, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete26 = delegate
		{
			WallEyes(11);
		};
		Timer timer26 = TimerHelper.RegisterMillisUI(78128f, onComplete26, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete27 = delegate
		{
			WallEyes(11);
		};
		Timer timer27 = TimerHelper.RegisterMillisUI(78536f, onComplete27, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete28 = delegate
		{
			WallEyes(11);
		};
		Timer timer28 = TimerHelper.RegisterMillisUI(78944f, onComplete28, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete29 = delegate
		{
			WallEyes(11);
		};
		Timer timer29 = TimerHelper.RegisterMillisUI(79148f, onComplete29, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete30 = delegate
		{
			BackgroundEyes(3);
		};
		Timer timer30 = TimerHelper.RegisterMillisUI(30592f, onComplete30, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete31 = delegate
		{
			BackgroundEyes(4);
		};
		Timer timer31 = TimerHelper.RegisterMillisUI(34992f, onComplete31, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete32 = delegate
		{
			BackgroundEyes(7);
		};
		Timer timer32 = TimerHelper.RegisterMillisUI(38192f, onComplete32, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete33 = delegate
		{
			BackgroundEyes(7);
		};
		Timer timer33 = TimerHelper.RegisterMillisUI(41492f, onComplete33, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete34 = delegate
		{
			BackgroundEyes(8);
		};
		Timer timer34 = TimerHelper.RegisterMillisUI(44892f, onComplete34, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete35 = delegate
		{
			BackgroundEyes(9);
		};
		Timer timer35 = TimerHelper.RegisterMillisUI(51292f, onComplete35, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete36 = delegate
		{
			BackgroundEyes(9);
		};
		Timer timer36 = TimerHelper.RegisterMillisUI(54492f, onComplete36, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete37 = delegate
		{
			BackgroundEyes(9);
		};
		Timer timer37 = TimerHelper.RegisterMillisUI(57892f, onComplete37, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete38 = delegate
		{
			BackgroundEyes(9);
		};
		Timer timer38 = TimerHelper.RegisterMillisUI(60892f, onComplete38, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete39 = delegate
		{
			BackgroundEyes(10);
		};
		Timer timer39 = TimerHelper.RegisterMillisUI(62592f, onComplete39, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete40 = delegate
		{
			BackgroundEyes(10);
		};
		Timer timer40 = TimerHelper.RegisterMillisUI(64392f, onComplete40, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete41 = delegate
		{
			BackgroundEyes(10);
		};
		Timer timer41 = TimerHelper.RegisterMillisUI(65792f, onComplete41, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete42 = delegate
		{
			BackgroundEyes(11);
		};
		Timer timer42 = TimerHelper.RegisterMillisUI(70792f, onComplete42, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete43 = delegate
		{
			BackgroundEyes(12);
		};
		Timer timer43 = TimerHelper.RegisterMillisUI(72492f, onComplete43, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete44 = delegate
		{
			BackgroundEyes(13);
		};
		Timer timer44 = TimerHelper.RegisterMillisUI(76700f, onComplete44, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete45 = delegate
		{
			BackgroundEyes(13);
		};
		Timer timer45 = TimerHelper.RegisterMillisUI(76904f, onComplete45, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete46 = delegate
		{
			BackgroundEyes(13);
		};
		Timer timer46 = TimerHelper.RegisterMillisUI(77312f, onComplete46, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete47 = delegate
		{
			BackgroundEyes(13);
		};
		Timer timer47 = TimerHelper.RegisterMillisUI(77720f, onComplete47, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete48 = delegate
		{
			BackgroundEyes(13);
		};
		Timer timer48 = TimerHelper.RegisterMillisUI(78128f, onComplete48, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete49 = delegate
		{
			BackgroundEyes(13);
		};
		Timer timer49 = TimerHelper.RegisterMillisUI(78536f, onComplete49, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete50 = delegate
		{
			BackgroundEyes(13);
		};
		Timer timer50 = TimerHelper.RegisterMillisUI(78944f, onComplete50, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
		Action onComplete51 = delegate
		{
			BackgroundEyes(13);
		};
		Timer timer51 = TimerHelper.RegisterMillisUI(79148f, onComplete51, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
	}

	public void RedLightSwoop(int index = 0)
	{
		//IL_00ca->IL00e9: Incompatible stack heights: 1 vs 0
		if (!_bgEnabled)
		{
			return;
		}
		BackgroundDevilRoom backgroundDevilRoom = backgroundManager;
		if (index <= backgroundDevilRoom.currentLevel && !PauseSystem._paused)
		{
			Light2D redLight = _redLight;
			redLight.m_Intensity = 2f;
			Transform transform = _redLight.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			Transform transform2 = _redLight.transform;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOLocalMoveY(transform2, 16f, 1.65f);
			TweenCallback tweenCallback = delegate
			{
				Light2D redLight2 = _redLight;
				redLight2.m_Intensity = 0f;
			};
		}
	}

	public unsafe void WallEyes(int index = 0, int amount = 1)
	{
		//IL_013a: Invalid comparison between F4 and I4
		//IL_014d: Expected O, but got I4
		//IL_01e2: Expected I4, but got I8
		//IL_0292: Expected O, but got Ref
		//IL_0351: Expected O, but got I
		_003C_003Ec__DisplayClass39_0 obj = new _003C_003Ec__DisplayClass39_0();
		if (!_bgEnabled)
		{
			return;
		}
		BackgroundDevilRoom backgroundDevilRoom = backgroundManager;
		if (index > backgroundDevilRoom.currentLevel || PauseSystem._paused)
		{
			return;
		}
		GameManager core = GM.Core;
		GameSessionData gameSessionData = core._gameSessionData;
		float2 position = gameSessionData._activeCharacter.position;
		obj.position = position;
		BackgroundDevilRoom backgroundDevilRoom2 = backgroundManager;
		Comparison<Vector2> comparison = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1806D04D0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4100");
		List<PhaserSprite> eyeWallSprites = _eyeWallSprites;
		int num = _wallEyesCounter % eyeWallSprites._size;
		if (num < eyeWallSprites._size)
		{
			PhaserSprite[] items = eyeWallSprites._items;
			float value = UnityEngine.Random.value;
			bool flag = value < 0.4f;
			float num2 = value - 0.4f;
			bool flag2 = num2 == 0f;
			object obj2 = flag | flag2;
			string text = VampireSurvivors.App.Tools.Extensions.PickRnd(_eyeFrames);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
			Sprite frame = default(Sprite);
			PhaserSprite phaserSprite = items[num].setFrame(frame);
			BackgroundDevilRoom backgroundDevilRoom3 = backgroundManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
			float2 position2 = default(float2);
			PhaserSprite phaserSprite2 = items[num].setPosition(position2);
			PhaserSprite phaserSprite3 = items[num].setDepth(-1994);
			PhaserSprite phaserSprite4 = items[num].setAlpha(0.85f);
			float value2 = UnityEngine.Random.value;
			float num3 = value2 * 0.25f;
			float xScale = num3 + 0.5f;
			Transform transform = items[num].transform;
			Transform transform2 = RenderingExtensions.SetScale(transform, xScale, 0f);
			Transform transform3 = items[num].transform;
			object obj3 = default(object);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(transform3, (Vector3)(&obj3), 0.08f);
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v445 @ rax_v37 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v445 @ rax_v37 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
					if ((nint)0 == 0)
					{
						_ = 2;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v445 @ rax_v37 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v445 @ rax_v37 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
							nint num4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v445 @ rax_v37 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
							object obj4 = num4 + 0;
						}
					}
				}
			}
			int wallEyesCounter = _wallEyesCounter + 1;
			_wallEyesCounter = wallEyesCounter;
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
	}

	public void BackgroundEyes(int index = 0, int amount = 1)
	{
		//IL_01eb: Expected I4, but got I8
		_003C_003Ec__DisplayClass45_0 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass45_0();
		if (!_bgEnabled)
		{
			return;
		}
		BackgroundDevilRoom backgroundDevilRoom = backgroundManager;
		if (index > backgroundDevilRoom.currentLevel || PauseSystem._paused)
		{
			return;
		}
		GameManager core = GM.Core;
		GameSessionData gameSessionData = core._gameSessionData;
		float2 position = gameSessionData._activeCharacter.position;
		GameManager core2 = GM.Core;
		GameSessionData gameSessionData2 = core2._gameSessionData;
		float2 position2 = gameSessionData2._activeCharacter.position;
		int num = _backgroundEyesCounter & 1;
		bool flag = num == 0;
		BackgroundDevilRoom backgroundDevilRoom2 = backgroundManager;
		if (!flag)
		{
			List<Vector2> list = backgroundDevilRoom2._003CRightEyesLocations_003Ek__BackingField;
		}
		else
		{
			List<Vector2> list = backgroundDevilRoom2._003CLeftEyesLocations_003Ek__BackingField;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
		List<PhaserSprite> eyeSprites = _eyeSprites;
		int num2 = _backgroundEyesCounter % eyeSprites._size;
		if (num2 < eyeSprites._size)
		{
			PhaserSprite[] items = eyeSprites._items;
			CS_0024_003C_003E8__locals7._eyeSprite = items[num2];
			string text = VampireSurvivors.App.Tools.Extensions.PickRnd(_eyeFrames2);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
			Sprite frame = default(Sprite);
			PhaserSprite phaserSprite = CS_0024_003C_003E8__locals7._eyeSprite.setFrame(frame);
			float x = default(float);
			float y = default(float);
			PhaserSprite phaserSprite2 = CS_0024_003C_003E8__locals7._eyeSprite.setPosition(x, y);
			PhaserSprite phaserSprite3 = CS_0024_003C_003E8__locals7._eyeSprite.setDepth(-19000);
			PhaserSprite phaserSprite4 = CS_0024_003C_003E8__locals7._eyeSprite.setAlpha(0.65f);
			float value = UnityEngine.Random.value;
			float num3 = value * 0.25f;
			Transform transform = CS_0024_003C_003E8__locals7._eyeSprite.transform;
			float scale = num3 + 0.75f;
			Transform transform2 = RenderingExtensions.SetScale(transform, scale);
			Action onComplete = delegate
			{
				PhaserSprite phaserSprite5 = CS_0024_003C_003E8__locals7._eyeSprite.setAlpha(0f);
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(0.032f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			int backgroundEyesCounter = _backgroundEyesCounter + 1;
			_backgroundEyesCounter = backgroundEyesCounter;
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public void PulseLight(float value = 1f)
	{
		//IL_00d7: Expected F4, but got I4
		//IL_00e0: Expected O, but got I4
		//IL_0120: Expected O, but got I4
		if (_bgEnabled)
		{
			if (_pulseLightSeq != null)
			{
				DG.Tweening.TweenExtensions.Kill(_pulseLightSeq);
			}
			Sequence pulseLightSeq = DOTween.Sequence();
			_pulseLightSeq = pulseLightSeq;
			Sequence pulseLightSeq2 = _pulseLightSeq;
			DOGetter<float> getter = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
			DOSetter<float> dOSetter = null;
			((BackgroundDevilRoom_Helper)(object)dOSetter)._003CPulseLight_003Eb__46_1(value);
			TweenerCore<float, float, FloatOptions> t = DOTween.To(getter, dOSetter, 0f, 0.25f);
			bool flag = TweenSettingsExtensions.ValidateAddToSequence(_pulseLightSeq, (Tween)t, false);
			bool flag2 = !flag;
			float num = 0f;
			object obj = 0;
			if (!flag2)
			{
				num = ((Tween)pulseLightSeq2).duration;
				Sequence sequence = Sequence.DoInsert(_pulseLightSeq, (Tween)t, ((Tween)pulseLightSeq2).duration);
				obj = 0;
			}
			Sequence pulseLightSeq3 = _pulseLightSeq;
			DOGetter<float> getter2 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
			DOSetter<float> dOSetter2 = null;
			((BackgroundDevilRoom_Helper)(object)dOSetter2)._003CPulseLight_003Eb__46_3(value);
			TweenerCore<float, float, FloatOptions> t2 = DOTween.To(getter2, dOSetter2, value, 0.25f);
			if (TweenSettingsExtensions.ValidateAddToSequence(_pulseLightSeq, (Tween)t2, false))
			{
				Sequence sequence2 = Sequence.DoInsert(_pulseLightSeq, (Tween)t2, ((Tween)pulseLightSeq3).duration);
			}
		}
	}

	public void PulseBlood(float value = 1f)
	{
		if (bloodEmitterTimer != null)
		{
			bloodEmitterTimer.Cancel();
		}
		RenderingExtensions.Start(TopEmitter);
		Action onComplete = delegate
		{
			TopEmitter.Stop();
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		bloodEmitterTimer = timer;
	}

	public void StartBlood(float value = 1f)
	{
		if (bloodEmitterTimer != null)
		{
			bloodEmitterTimer.Cancel();
		}
		RenderingExtensions.Start(TopEmitter);
	}

	public unsafe void TiltCamera()
	{
		//IL_0084: Expected O, but got Ref
		if (_bgEnabled)
		{
			Camera main = Camera.main;
			if ((object)main != null && ((UnityEngine.Object)main).m_CachedPtr != (IntPtr)0)
			{
				float currentCameraAngleZ = _currentCameraAngleZ * -1f;
				_currentCameraAngleZ = currentCameraAngleZ;
				Transform transform = main.transform;
				object obj = default(object);
				TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(transform, (Vector3)(&obj), 10f);
			}
		}
	}

	public unsafe void ResetCameraRotation()
	{
		//IL_00fb: Expected O, but got Ref
		Camera main = Camera.main;
		if ((object)main != null && ((UnityEngine.Object)main).m_CachedPtr != (IntPtr)0)
		{
			Transform transform = main.transform;
			if ((object)transform != null)
			{
				float optionalFloat = default(float);
				object optionalObj = default(object);
				object[] optionalArray = default(object[]);
				int num = DG.Tweening.Core.TweenManager.FilteredOperation(DG.Tweening.Core.Enums.OperationType.Despawn, DG.Tweening.Core.Enums.FilterType.TargetOrId, (object)transform, false, optionalFloat, optionalObj, optionalArray);
			}
			Transform transform2 = main.transform;
			object obj = default(object);
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(transform2, (Vector3)(&obj), 0f);
		}
	}

	public void PulseBackground()
	{
		//IL_00aa: Expected I, but got O
		//IL_011c: Expected O, but got I4
		//IL_01b5: Expected I, but got O
		//IL_0227: Expected O, but got I4
		if (!_bgEnabled)
		{
			return;
		}
		PhaserSprite phaserSprite = _darkBackground.setAlpha(0f);
		PhaserSprite phaserSprite2 = _lightBackground.setAlpha(0f);
		if (_tween1 != null)
		{
			_tween1.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_lightBackground != null)
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
		tweenConfig.yoyo = true;
		tweenConfig.duration = 200f;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween tween = Tweens.Add(tweenConfig);
		_tween1 = tween;
		if (_tween2 != null)
		{
			_tween2.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		if ((object)_darkBackground != null)
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
		tweenConfig2.yoyo = true;
		tweenConfig2.duration = 220f;
		tweenConfig2.alpha = (float?)(object)1;
		MultiTargetTween tween2 = Tweens.Add(tweenConfig2);
		_tween2 = tween2;
	}

	public unsafe void MakeEmitters()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0262: Expected O, but got Ref
		//IL_027c: Expected native int or pointer, but got O
		//IL_0296: Expected O, but got I
		//IL_02b6: Expected O, but got Ref
		//IL_02dd: Expected O, but got I
		//IL_02f7: Expected native int or pointer, but got O
		//IL_1281: Expected O, but got I
		//IL_032f: Expected O, but got Ref
		//IL_0349: Expected native int or pointer, but got O
		//IL_12bb: Expected O, but got I
		//IL_0381: Expected O, but got Ref
		//IL_039b: Expected native int or pointer, but got O
		//IL_12f5: Expected O, but got I
		//IL_1333: Expected O, but got I
		//IL_041b: Expected O, but got I
		//IL_044a: Expected O, but got I
		//IL_063d: Expected O, but got I4
		//IL_0664: Expected O, but got I4
		//IL_067d: Expected O, but got Ref
		//IL_0697: Expected native int or pointer, but got O
		//IL_06b1: Expected O, but got I
		//IL_06d1: Expected O, but got Ref
		//IL_06eb: Expected native int or pointer, but got O
		//IL_136e: Expected O, but got I
		//IL_0729: Expected O, but got Ref
		//IL_074a: Expected O, but got I
		//IL_0764: Expected native int or pointer, but got O
		//IL_13a8: Expected O, but got I
		//IL_079c: Expected O, but got Ref
		//IL_07b6: Expected native int or pointer, but got O
		//IL_13e2: Expected O, but got I
		//IL_07ee: Expected O, but got Ref
		//IL_0808: Expected native int or pointer, but got O
		//IL_141c: Expected O, but got I
		//IL_0890: Expected O, but got I
		//IL_0cad: Expected O, but got I4
		//IL_0cd4: Expected O, but got I4
		//IL_0ce8: Expected O, but got Ref
		//IL_0d02: Expected native int or pointer, but got O
		//IL_0d21: Expected O, but got I
		//IL_0d3c: Expected O, but got Ref
		//IL_0d56: Expected native int or pointer, but got O
		//IL_0d9b: Expected O, but got I
		//IL_0dc8: Expected O, but got Ref
		//IL_0def: Expected O, but got I
		//IL_0e09: Expected native int or pointer, but got O
		//IL_0e4e: Expected O, but got I
		//IL_0e76: Expected O, but got Ref
		//IL_0e90: Expected native int or pointer, but got O
		//IL_0eaf: Expected O, but got I
		//IL_0eca: Expected O, but got Ref
		//IL_0ee4: Expected native int or pointer, but got O
		//IL_0f29: Expected O, but got I
		//IL_0fab: Expected O, but got I
		//IL_0fcc: Expected O, but got I
		//IL_107b: Expected O, but got Ref
		//IL_1094: Expected I4, but got I8
		//IL_1122: Expected O, but got F4
		//IL_1497: Expected I4, but got I8
		//IL_14d1: Expected O, but got Ref
		//IL_14f7: Expected I4, but got I8
		//IL_1513: Expected O, but got I
		//IL_15c7: Expected O, but got Ref
		//IL_1552: Expected O, but got I
		//IL_15fe: Expected O, but got Ref
		//IL_1591: Expected O, but got I
		//IL_1635: Expected O, but got Ref
		//IL_15eb->IL1241: Incompatible stack heights: 2 vs 0
		//IL_11cf->IL15b9: Incompatible stack heights: 3 vs 2
		//IL_1622->IL1241: Incompatible stack heights: 2 vs 0
		//IL_1208->IL15f0: Incompatible stack heights: 3 vs 2
		//IL_1241->IL1627: Incompatible stack heights: 3 vs 2
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if ((object)GM.Core != null)
		{
			bool flag = GM.Core.IsStageVisuallyInverted();
			PhaserScene phaserScene = scene;
			if (scene != null)
			{
				PhaserScene.Renderer renderer = phaserScene._renderer;
				if (phaserScene._renderer != null)
				{
					float num = renderer.screenWidth * 0.5f;
					Rectangle rectangle = new Rectangle();
					float x = num ^ -0f;
					rectangle._x = x;
					rectangle._width = renderer.screenWidth;
					rectangle._y = 0f;
					rectangle._height = 0.64f;
					Rectangle rectangle2 = new Rectangle();
					float x2 = num ^ -0f;
					rectangle2._x = x2;
					rectangle2._width = renderer.screenWidth;
					rectangle2._y = 0.32f;
					rectangle2._height = 0.64f;
					ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
					List<string> list = new List<string>();
					if (list != null)
					{
						int version = list._version + 1;
						list._version = version;
						string[] items = list._items;
						if (list._items != null)
						{
							if (list._size >= items.Length)
							{
								((List<object>)(object)list).AddWithResize((object)"WhiteDot");
							}
							else
							{
								int size = list._size + 1;
								list._size = size;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							if (particleSystemConfig != null)
							{
								particleSystemConfig._frame = list;
								ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 288));
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(1000f, 4000f));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+120]");
								particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+130]");
								_ = 0;
								ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 320));
								_ = 0;
								_ = 20;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+378]");
								particleSystemConfig._quantity = (int?)(object)0;
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(2f, 1f));
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+140]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+150]");
								_ = 0;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-70]");
								particleSystemConfig._scaleX = (ParticleSystem.MinMaxCurve?)(object)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-60]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-50]");
								_ = 0;
								ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 352));
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(1f, 1600f));
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+160]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+170]");
								_ = 0;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-48]");
								particleSystemConfig._scaleY = (ParticleSystem.MinMaxCurve?)(object)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-38]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-28]");
								_ = 0;
								ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 384));
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(0.65f, 0f));
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+180]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+190]");
								_ = 0;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-20]");
								particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-10]");
								_ = 0;
								EmitZone emitZone = new EmitZone();
								emitZone._type = EmitZoneType.Edge;
								emitZone._source = rectangle;
								_ = 0;
								_ = 48;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+378]");
								emitZone._quantity = (int?)(object)0;
								emitZone._yoyo = false;
								particleSystemConfig._emitZone = emitZone;
								_ = 0;
								_ = 1120403456;
								_ = 1;
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+378]");
								particleSystemConfig._frequency = (float?)(object)0;
								particleSystemConfig._on = true;
								_ = 11141120;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+378]");
								particleSystemConfig._tint = (uint?)(object)0;
								ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("backgroundDevil");
								List<string> list2 = new List<string>();
								if (list2 != null)
								{
									int version2 = list2._version + 1;
									list2._version = version2;
									string[] items2 = list2._items;
									if (list2._items != null)
									{
										if (list2._size >= items2.Length)
										{
											((List<object>)(object)list2).AddWithResize((object)"dk_Hand2");
										}
										else
										{
											int size2 = list2._size + 1;
											list2._size = size2;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										int version3 = list2._version + 1;
										list2._version = version3;
										string[] items3 = list2._items;
										if (list2._items != null)
										{
											if (list2._size >= items3.Length)
											{
												((List<object>)(object)list2).AddWithResize((object)"dk_Hand3");
											}
											else
											{
												int size3 = list2._size + 1;
												list2._size = size3;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											}
											if (particleSystemConfig2 != null)
											{
												particleSystemConfig2._frame = list2;
												ParticleSystem.MinMaxCurve minMaxCurve5 = new ParticleSystem.MinMaxCurve(0f);
												particleSystemConfig2._x = (ParticleSystem.MinMaxCurve)0;
												_ = 0;
												minMaxCurve5 = new ParticleSystem.MinMaxCurve(0f);
												particleSystemConfig2._y = (ParticleSystem.MinMaxCurve)0;
												_ = 0;
												ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 416));
												_ = 0;
												_ = 0;
												System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(500f, 1750f));
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1A0]");
												particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1B0]");
												_ = 0;
												ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 448));
												_ = 0;
												_ = 0;
												System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(300f, 400f));
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1C0]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1D0]");
												_ = 0;
												_ = 1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+8]");
												particleSystemConfig2._speedY = (ParticleSystem.MinMaxCurve?)(object)0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+18]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+28]");
												_ = 0;
												_ = 0;
												ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 480));
												_ = 4;
												_ = 1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+378]");
												particleSystemConfig2._quantity = (int?)(object)0;
												_ = 0;
												_ = 0;
												System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(2f, 2f));
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1E0]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1F0]");
												_ = 0;
												_ = 1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+30]");
												particleSystemConfig2._scaleX = (ParticleSystem.MinMaxCurve?)(object)0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+40]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+50]");
												_ = 0;
												ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 512));
												_ = 0;
												_ = 0;
												System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(2f, 6f));
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+200]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+210]");
												_ = 0;
												_ = 1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+58]");
												particleSystemConfig2._scaleY = (ParticleSystem.MinMaxCurve?)(object)0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+68]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+78]");
												_ = 0;
												ParticleSystem.MinMaxCurve minMaxCurve10 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 544));
												_ = 0;
												_ = 0;
												System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve10, new ParticleSystem.MinMaxCurve(0.65f, 0.35f));
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+220]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+230]");
												_ = 0;
												_ = 1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+80]");
												particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+90]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+A0]");
												_ = 0;
												EmitZone emitZone2 = new EmitZone();
												emitZone2._type = EmitZoneType.Random;
												emitZone2._source = rectangle2;
												particleSystemConfig2._emitZone = emitZone2;
												_ = 0;
												particleSystemConfig2._on = true;
												_ = 1137180672;
												_ = 1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+378]");
												particleSystemConfig2._frequency = (float?)(object)0;
												ParticleSystemConfig particleSystemConfig3 = new ParticleSystemConfig("backgroundDevil");
												List<string> list3 = new List<string>();
												if (list3 != null)
												{
													int version4 = list3._version + 1;
													list3._version = version4;
													string[] items4 = list3._items;
													if (list3._items != null)
													{
														if (list3._size >= items4.Length)
														{
															((List<object>)(object)list3).AddWithResize((object)"dk_skull1");
														}
														else
														{
															int size4 = list3._size + 1;
															list3._size = size4;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
														}
														int version5 = list3._version + 1;
														list3._version = version5;
														string[] items5 = list3._items;
														if (list3._items != null)
														{
															if (list3._size >= items5.Length)
															{
																((List<object>)(object)list3).AddWithResize((object)"dk_skull2");
															}
															else
															{
																int size5 = list3._size + 1;
																list3._size = size5;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															}
															int version6 = list3._version + 1;
															list3._version = version6;
															string[] items6 = list3._items;
															if (list3._items != null)
															{
																if (list3._size >= items6.Length)
																{
																	((List<object>)(object)list3).AddWithResize((object)"dk_skulo1");
																}
																else
																{
																	int size6 = list3._size + 1;
																	list3._size = size6;
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																}
																int version7 = list3._version + 1;
																list3._version = version7;
																string[] items7 = list3._items;
																if (list3._items != null)
																{
																	if (list3._size >= items7.Length)
																	{
																		((List<object>)(object)list3).AddWithResize((object)"dk_skulo2");
																	}
																	else
																	{
																		int size7 = list3._size + 1;
																		list3._size = size7;
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																	}
																	int version8 = list3._version + 1;
																	list3._version = version8;
																	string[] items8 = list3._items;
																	if (list3._items != null)
																	{
																		if (list3._size >= items8.Length)
																		{
																			((List<object>)(object)list3).AddWithResize((object)"dk_skulo3");
																		}
																		else
																		{
																			int size8 = list3._size + 1;
																			list3._size = size8;
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																		}
																		list3.Add("dk_skulo4");
																		if (particleSystemConfig3 != null)
																		{
																			particleSystemConfig3._frame = list3;
																			minMaxCurve5 = new ParticleSystem.MinMaxCurve(0f);
																			particleSystemConfig3._x = (ParticleSystem.MinMaxCurve)0;
																			_ = 0;
																			minMaxCurve5 = new ParticleSystem.MinMaxCurve(0f);
																			particleSystemConfig3._y = (ParticleSystem.MinMaxCurve)0;
																			_ = 0;
																			ParticleSystem.MinMaxCurve minMaxCurve11 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 576));
																			_ = 0;
																			_ = 0;
																			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve11, new ParticleSystem.MinMaxCurve(1000f, 1750f));
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+240]");
																			particleSystemConfig3._lifespan = (ParticleSystem.MinMaxCurve)0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+250]");
																			_ = 0;
																			ParticleSystem.MinMaxCurve minMaxCurve12 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 608));
																			_ = 0;
																			_ = 0;
																			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve12, new ParticleSystem.MinMaxCurve(300f, 1000f));
																			_ = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+260]");
																			_ = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+270]");
																			_ = 0;
																			_ = 1;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+A8]");
																			particleSystemConfig3._speedY = (ParticleSystem.MinMaxCurve?)(object)0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+B8]");
																			_ = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+C8]");
																			_ = 0;
																			ParticleSystem.MinMaxCurve minMaxCurve13 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 640));
																			_ = 0;
																			_ = 50;
																			_ = 1;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+378]");
																			particleSystemConfig3._quantity = (int?)(object)0;
																			_ = 0;
																			_ = 0;
																			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve13, new ParticleSystem.MinMaxCurve(1f, 0.75f));
																			_ = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+280]");
																			_ = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+290]");
																			_ = 0;
																			_ = 1;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+D0]");
																			particleSystemConfig3._scale = (ParticleSystem.MinMaxCurve?)(object)0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+E0]");
																			_ = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+F0]");
																			_ = 0;
																			ParticleSystem.MinMaxCurve minMaxCurve14 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 672));
																			_ = 0;
																			_ = 0;
																			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve14, new ParticleSystem.MinMaxCurve(0f, 360f));
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+2A0]");
																			particleSystemConfig3._rotate = (ParticleSystem.MinMaxCurve)0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+2B0]");
																			_ = 0;
																			ParticleSystem.MinMaxCurve minMaxCurve15 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 704));
																			_ = 0;
																			_ = 0;
																			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve15, new ParticleSystem.MinMaxCurve(1f, 0.8f));
																			_ = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+2C0]");
																			_ = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+2D0]");
																			_ = 0;
																			_ = 1;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+F8]");
																			particleSystemConfig3._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+108]");
																			_ = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+118]");
																			_ = 0;
																			EmitZone emitZone3 = new EmitZone();
																			emitZone3._type = EmitZoneType.Random;
																			emitZone3._source = rectangle2;
																			particleSystemConfig3._emitZone = emitZone3;
																			_ = 0;
																			_ = 1120403456;
																			_ = 1;
																			_ = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+378]");
																			particleSystemConfig3._frequency = (float?)(object)0;
																			_ = 12303291;
																			_ = 1;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+378]");
																			particleSystemConfig3._tint = (uint?)(object)0;
																			particleSystemConfig3._on = true;
																			PhaserScene phaserScene2 = scene;
																			PhaserScene.Renderer renderer2 = phaserScene2._renderer;
																			float num2 = renderer2.screenHeight * 0.5f;
																			Camera main = Camera.main;
																			Transform transform = main.transform;
																			ParticleSystem topEmitter = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, transform, "_glitchEmitterTop");
																			TopEmitter = topEmitter;
																			Transform transform2 = TopEmitter.transform;
																			object obj3 = default(object);
																			transform2.localPosition = (Vector3)(&obj3);
																			RenderingExtensions.SetDepth(TopEmitter, -6000);
																			ParticleSystemRenderer component = TopEmitter.GetComponent<ParticleSystemRenderer>();
																			component.maxParticleSize = 100f;
																			Camera main2 = Camera.main;
																			Transform transform3 = main2.transform;
																			ParticleSystem bottomEmitter = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig2, transform3, "_glitchEmitterBottom");
																			BottomEmitter = bottomEmitter;
																			Transform transform4 = BottomEmitter.transform;
																			object obj4 = num2 ^ -0f;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1318 @ rax_v145 (UnityEngine.Transform)+10]");
																			bool flag2 = (nint)0 == 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1318 @ rax_v145 (UnityEngine.Transform)+10]");
																			Vector3 value = default(Vector3);
																			Transform.set_localPosition_Injected((IntPtr)0, ref value);
																			RenderingExtensions.SetDepth(BottomEmitter, -6000);
																			Camera main3 = Camera.main;
																			Transform transform5 = main3.transform;
																			ParticleSystem skullsEmitter = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig3, transform5, "_glitchEmitterSkulls");
																			SkullsEmitter = skullsEmitter;
																			Transform transform6 = SkullsEmitter.transform;
																			_ = 5f;
																			bool flag3 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
																			object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
																			Transform.set_localPosition_Injected(((UnityEngine.Object)transform6).m_CachedPtr, ref *(Vector3*)obj5);
																			RenderingExtensions.SetDepth(SkullsEmitter, -9002);
																			_ = TopEmitter;
																			_ = TopEmitter;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
																			object obj6 = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
																			if ((nint)0 == 0)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
																				bool flag4 = obj6 == null;
																			}
																			object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 880));
																			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v3518 @ rax_v164 (should have been resolved before IL gen)");
																			if ((object)BottomEmitter != null)
																			{
																				_ = BottomEmitter;
																				_ = BottomEmitter;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
																				object obj8 = 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
																				if ((nint)0 == 0)
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
																					bool flag5 = obj8 == null;
																				}
																				object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 880));
																				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v3605 @ rax_v169 (should have been resolved before IL gen)");
																				if ((object)SkullsEmitter != null)
																				{
																					_ = SkullsEmitter;
																					_ = SkullsEmitter;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
																					object obj10 = 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
																					if ((nint)0 == 0)
																					{
																						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
																						bool flag6 = obj10 == null;
																					}
																					object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 880));
																					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v3692 @ rax_v174 (should have been resolved before IL gen)");
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
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe void MakeBackgrounds()
	{
		//IL_0050: Expected O, but got I4
		//IL_00e3: Expected O, but got I4
		//IL_0143: Expected I4, but got I8
		//IL_0203: Expected O, but got I4
		//IL_0296: Expected O, but got I4
		//IL_02f6: Expected I4, but got I8
		//IL_03d0: Expected O, but got I4
		//IL_041a: Expected O, but got I4
		//IL_0435: Expected I4, but got I8
		//IL_0494: Expected O, but got I4
		//IL_04c9: Expected O, but got I4
		//IL_04e5: Expected O, but got I4
		//IL_0501: Expected O, but got I4
		//IL_054b: Expected O, but got I4
		//IL_0566: Expected I4, but got I8
		//IL_057d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0582: Expected I4, but got Unknown
		//IL_0590: Expected O, but got Ref
		//IL_0678: Unknown result type (might be due to invalid IL or missing references)
		//IL_067d: Expected O, but got Unknown
		//IL_06c1: Expected O, but got I4
		//IL_06f6: Expected O, but got I4
		//IL_0712: Expected O, but got I4
		//IL_072e: Expected O, but got I4
		//IL_0778: Expected O, but got I4
		//IL_0793: Expected I4, but got I8
		//IL_07aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_07af: Expected I4, but got Unknown
		//IL_07bd: Expected O, but got Ref
		//IL_08a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_08aa: Expected O, but got Unknown
		GameObject gameObject = GM.Core.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "vfx", "whiteFog");
		PhaserSprite phaserSprite2 = phaserSprite.setOrigin(0f, (float?)(object)0);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			if ((object)GM.Core != null)
			{
				float num = renderer.width * 100f;
				float xScale = num / 160f;
				PhaserSprite phaserSprite3 = phaserSprite2.setScale(xScale, (float?)(object)1);
				PhaserSprite phaserSprite4 = phaserSprite3.setBlendMode(BlendMode.Add);
				PhaserSprite component = phaserSprite4.setAlpha(0f);
				PhaserSprite phaserSprite5 = RenderingExtensions.SetScrollFactor(component, 0f);
				PhaserSprite phaserSprite6 = phaserSprite5.setDepth(-9001);
				PhaserSprite phaserSprite7 = phaserSprite6.setTint(6684774u);
				GameObject gameObject2 = phaserSprite7.gameObject;
				((UnityEngine.Object)gameObject2).SetName("darkBackground");
				_darkBackground = phaserSprite7;
				PhaserSprite darkBackground = _darkBackground;
				SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(darkBackground._spriteRenderer, 1f);
				GameObject gameObject3 = GM.Core.gameObject;
				PhaserSprite phaserSprite8 = RenderingExtensions.AddPhaserSprite(gameObject3, pos, "vfx", "whiteFog");
				PhaserSprite phaserSprite9 = phaserSprite8.setOrigin(0f, (float?)(object)0);
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene2 = ArcadePhysics.s_scene;
					PhaserScene.Renderer renderer2 = s_scene2._renderer;
					if ((object)GM.Core != null)
					{
						float num2 = renderer2.width * 100f;
						float xScale2 = num2 / 160f;
						PhaserSprite phaserSprite10 = phaserSprite9.setScale(xScale2, (float?)(object)1);
						PhaserSprite phaserSprite11 = phaserSprite10.setBlendMode(BlendMode.Normal);
						PhaserSprite component2 = phaserSprite11.setAlpha(0f);
						PhaserSprite phaserSprite12 = RenderingExtensions.SetScrollFactor(component2, 0f);
						PhaserSprite phaserSprite13 = phaserSprite12.setDepth(-9000);
						PhaserSprite phaserSprite14 = phaserSprite13.setTint(16711680u);
						GameObject gameObject4 = phaserSprite14.gameObject;
						((UnityEngine.Object)gameObject4).SetName("darkBackground");
						_lightBackground = phaserSprite14;
						PhaserSprite lightBackground = _lightBackground;
						SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(lightBackground._spriteRenderer, 1f);
						if ((object)GM.Core != null)
						{
							GameObject gameObject5 = GM.Core.gameObject;
							PhaserSprite phaserSprite15 = RenderingExtensions.AddPhaserSprite(gameObject5, pos, "BackgroundDevil", "dk_eye3");
							PhaserSprite phaserSprite16 = phaserSprite15.setScale(1f, (float?)(object)1);
							PhaserSprite phaserSprite17 = phaserSprite16.setBlendMode(BlendMode.Normal);
							PhaserSprite phaserSprite18 = phaserSprite17.setAlpha(1f);
							PhaserSprite phaserSprite19 = phaserSprite18.setOrigin(0.5f, (float?)(object)1);
							PhaserSprite phaserSprite20 = phaserSprite19.setDepth(-30001);
							GameObject gameObject6 = phaserSprite20.gameObject;
							((UnityEngine.Object)gameObject6).SetName("STARE");
							_centralSprite = phaserSprite20;
							List<PhaserSprite> eyeSprites = new List<PhaserSprite>();
							_eyeSprites = eyeSprites;
							float? num3 = (float?)(object)0;
							object obj = default(object);
							do
							{
								GameObject gameObject7 = GM.Core.gameObject;
								PhaserSprite phaserSprite21 = RenderingExtensions.AddPhaserSprite(gameObject7, (Vector2)0, "backgroundDevil", "dk_eye1");
								PhaserSprite phaserSprite22 = phaserSprite21.setOrigin(0f, (float?)(object)0);
								PhaserSprite phaserSprite23 = phaserSprite22.setScale(1f, (float?)(object)1);
								PhaserSprite phaserSprite24 = phaserSprite23.setBlendMode(BlendMode.Normal);
								PhaserSprite phaserSprite25 = phaserSprite24.setAlpha(0.65f);
								PhaserSprite phaserSprite26 = phaserSprite25.setOrigin(0.5f, (float?)(object)1);
								PhaserSprite phaserSprite27 = phaserSprite26.setDepth(-19000);
								int value = (_003F?)num3 + 1;
								string text = System.Number.FormatInt32(value, (ReadOnlySpan<char>)(&obj), null);
								string name = "EYESPRITE BACKGROUND " + text;
								GameObject gameObject8 = phaserSprite27.gameObject;
								((UnityEngine.Object)gameObject8).SetName(name);
								List<object> eyeSprites2 = (List<object>)(object)_eyeSprites;
								int version = eyeSprites2._version + 1;
								eyeSprites2._version = version;
								object[] items = eyeSprites2._items;
								if (eyeSprites2._size >= items.Length)
								{
									eyeSprites2.AddWithResize((object)phaserSprite27);
								}
								else
								{
									int size = eyeSprites2._size + 1;
									eyeSprites2._size = size;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								}
								num3 = (float?)(object)((_003F?)num3 + 1);
							}
							while ((nint)num3 < 4);
							List<PhaserSprite> eyeWallSprites = new List<PhaserSprite>();
							_eyeWallSprites = eyeWallSprites;
							float? num4 = (float?)(object)0;
							do
							{
								GameObject gameObject9 = GM.Core.gameObject;
								PhaserSprite phaserSprite28 = RenderingExtensions.AddPhaserSprite(gameObject9, (Vector2)0, "backgroundDevil", "dk_eye1");
								PhaserSprite phaserSprite29 = phaserSprite28.setOrigin(0f, (float?)(object)0);
								PhaserSprite phaserSprite30 = phaserSprite29.setScale(1f, (float?)(object)1);
								PhaserSprite phaserSprite31 = phaserSprite30.setBlendMode(BlendMode.Normal);
								PhaserSprite phaserSprite32 = phaserSprite31.setAlpha(0.65f);
								PhaserSprite phaserSprite33 = phaserSprite32.setOrigin(0.5f, (float?)(object)1);
								PhaserSprite phaserSprite34 = phaserSprite33.setDepth(-19000);
								int value2 = (_003F?)num4 + 1;
								string text2 = System.Number.FormatInt32(value2, (ReadOnlySpan<char>)(&obj), null);
								string name2 = "EYESPRITE WALL " + text2;
								GameObject gameObject10 = phaserSprite34.gameObject;
								((UnityEngine.Object)gameObject10).SetName(name2);
								List<object> eyeWallSprites2 = (List<object>)(object)_eyeWallSprites;
								int version2 = eyeWallSprites2._version + 1;
								eyeWallSprites2._version = version2;
								object[] items2 = eyeWallSprites2._items;
								if (eyeWallSprites2._size >= items2.Length)
								{
									eyeWallSprites2.AddWithResize((object)phaserSprite34);
								}
								else
								{
									int size2 = eyeWallSprites2._size + 1;
									eyeWallSprites2._size = size2;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								}
								num4 = (float?)(object)((_003F?)num4 + 1);
							}
							while ((nint)num4 < 4);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void TweenEye(PhaserSprite sprite)
	{
		//IL_0229: Expected O, but got F4
		//IL_023d: Expected O, but got F4
		//IL_026a: Expected O, but got F4
		//IL_00f3: Invalid comparison between F4 and I4
		//IL_0278: Expected O, but got F4
		//IL_0161: Expected I, but got O
		//IL_01cf: Expected O, but got I4
		//IL_0184->IL0184: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass54_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass54_0();
		CS_0024_003C_003E8__locals8.sprite = sprite;
		if (_bgEnabled)
		{
			string text = VampireSurvivors.App.Tools.Extensions.PickRnd(_eyeFrames);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
			Sprite frame = default(Sprite);
			PhaserSprite phaserSprite = CS_0024_003C_003E8__locals8.sprite.setFrame(frame);
			GameManager core = GM.Core;
			GameSessionData gameSessionData = core._gameSessionData;
			float2 position = gameSessionData._activeCharacter.position;
			object obj = UnityEngine.Random.value;
			object obj2 = UnityEngine.Random.value;
			object obj3 = default(object);
			float num = (float)obj3 - 0.5f;
			object obj4 = default(object);
			float num2 = num + (float)obj4;
			float2 position2 = default(float2);
			PhaserSprite phaserSprite2 = CS_0024_003C_003E8__locals8.sprite.setPosition(position2);
			object obj5 = UnityEngine.Random.value;
			bool flag = num2 < 0.5f;
			float num3 = num2 - 0.5f;
			bool flag2 = num3 == 0f;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			bool flipX = flag4 & flag3;
			PhaserSprite phaserSprite3 = CS_0024_003C_003E8__locals8.sprite.setFlipX(flipX);
			object obj6 = UnityEngine.Random.value;
			float num4 = num2 * 0.5f;
			float _scale = num4 + 1f;
			CS_0024_003C_003E8__locals8.__scale = _scale;
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if ((object)CS_0024_003C_003E8__locals8.sprite != null)
			{
				nint num5 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj7 = default(object);
				bool flag5 = obj7 == null;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.yoyo = true;
			tweenConfig.duration = 100f;
			tweenConfig.scaleY = (float?)(object)1;
			TweenCallback onStart = delegate
			{
				PhaserSprite phaserSprite4 = RenderingExtensions.SetScale(CS_0024_003C_003E8__locals8.sprite, CS_0024_003C_003E8__locals8.__scale, 0f);
			};
			tweenConfig.onStart = onStart;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		}
	}

	public unsafe void AddRotatingBackground()
	{
		//IL_0987: Expected O, but got I4
		//IL_098f: Expected F4, but got O
		//IL_06cc: Expected O, but got I4
		//IL_0739: Expected O, but got I4
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Expected I4, but got Unknown
		//IL_0828: Expected O, but got I4
		//IL_03b9: Expected O, but got F4
		//IL_08d5: Expected I4, but got I8
		//IL_03f0: Expected O, but got Ref
		//IL_0436: Expected O, but got I
		//IL_044f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0454: Expected O, but got Unknown
		//IL_055c: Expected O, but got I4
		//IL_0565: Unknown result type (might be due to invalid IL or missing references)
		//IL_056a: Expected O, but got Unknown
		//IL_05a7: Expected I4, but got I8
		//IL_05fe: Expected I4, but got O
		//IL_09d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d5: Expected O, but got Unknown
		//IL_06a1: Expected F4, but got O
		//IL_06aa: Expected F4, but got I4
		//IL_00ba->IL08da: Incompatible stack heights: 1 vs 0
		//IL_0a3e->IL08da: Incompatible stack heights: 3 vs 0
		//IL_0721->IL08da: Incompatible stack heights: 3 vs 0
		//IL_014d->IL08da: Incompatible stack heights: 3 vs 0
		//IL_0756->IL08da: Incompatible stack heights: 3 vs 0
		//IL_01a9->IL08da: Incompatible stack heights: 3 vs 0
		//IL_0a65->IL08da: Incompatible stack heights: 3 vs 0
		//IL_01d3->IL08da: Incompatible stack heights: 3 vs 0
		//IL_078a->IL08da: Incompatible stack heights: 3 vs 0
		//IL_07a8->IL08da: Incompatible stack heights: 3 vs 0
		//IL_0251->IL08da: Incompatible stack heights: 3 vs 0
		//IL_0a8c->IL08da: Incompatible stack heights: 3 vs 0
		//IL_07cf->IL08da: Incompatible stack heights: 3 vs 0
		//IL_02af->IL08da: Incompatible stack heights: 3 vs 0
		//IL_07ec->IL08da: Incompatible stack heights: 3 vs 0
		//IL_02eb->IL08da: Incompatible stack heights: 3 vs 0
		//IL_0844->IL08da: Incompatible stack heights: 3 vs 0
		//IL_0314->IL08da: Incompatible stack heights: 3 vs 0
		//IL_0873->IL08da: Incompatible stack heights: 3 vs 0
		//IL_08be->IL08da: Incompatible stack heights: 3 vs 0
		//IL_03de->IL08da: Incompatible stack heights: 3 vs 0
		//IL_0414->IL08da: Incompatible stack heights: 3 vs 0
		//IL_04be->IL08da: Incompatible stack heights: 3 vs 0
		//IL_052c->IL08da: Incompatible stack heights: 3 vs 0
		//IL_050a->IL050a: Incompatible stack heights: 4 vs 3
		//IL_05e1->IL08da: Incompatible stack heights: 3 vs 0
		//IL_0627->IL08da: Incompatible stack heights: 3 vs 0
		//IL_0669->IL08da: Incompatible stack heights: 3 vs 0
		BackgroundDevilRoom backgroundDevilRoom = backgroundManager;
		if ((object)backgroundManager != null && (object)((BackgroundManager)backgroundDevilRoom)._mainCamera != null)
		{
			Transform transform = ((BackgroundManager)backgroundDevilRoom)._mainCamera.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				float ret;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
				GameObject gameObject = new GameObject();
				GameObject.Internal_CreateGameObject(gameObject, "Background5SpritesRoot");
				if ((object)gameObject != null)
				{
					Transform transform2 = gameObject.transform;
					_spritesRootTransform = transform2;
					Transform spritesRootTransform = _spritesRootTransform;
					bool flag2 = (object)_spritesRootTransform == null;
					bool flag3 = ((UnityEngine.Object)spritesRootTransform).m_CachedPtr == (IntPtr)0;
					Vector2 value = default(Vector2);
					Transform.set_position_Injected(((UnityEngine.Object)spritesRootTransform).m_CachedPtr, ref *(Vector3*)(&value));
					List<MultiTargetTween>.Enumerator enumerator = (List<MultiTargetTween>.Enumerator)0;
					Vector2 vector = default(Vector2);
					float num = (float)vector;
					float num3 = default(float);
					float num2 = num3;
					Transform transform3 = null;
					string spriteName = default(string);
					object arg = default(object);
					object arg2 = default(object);
					Vector2 vector2 = default(Vector2);
					List<MultiTargetTween>.Enumerator enumerator2 = default(List<MultiTargetTween>.Enumerator);
					while (true)
					{
						if ((nint)transform3 < 1)
						{
							List<Transform> list = new List<Transform>();
							Transform transform4 = null;
							List<Transform> list2 = list;
							while ((nint)transform4 < 9)
							{
								GameManager core = GM.Core;
								if ((object)GM.Core == null)
								{
									goto end_IL_0a05;
								}
								SpriteRenderer component = RenderingExtensions.AddSprite(core._stage, ret, num3, "backgroundDevil", spriteName);
								SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(component, 0f);
								if ((object)spriteRenderer == null)
								{
									goto end_IL_0a05;
								}
								Transform transform5 = spriteRenderer.transform;
								if ((object)transform5 == null)
								{
									goto end_IL_0a05;
								}
								transform5.SetParent(_spritesRootTransform, worldPositionStays: true);
								int sortingOrder = (int)(4294937296L - transform4);
								spriteRenderer.sortingOrder = sortingOrder;
								SpriteRenderer spriteRenderer2 = RenderingExtensions.SetTint(spriteRenderer, 13421772u);
								SpriteRenderer spriteRenderer3 = RenderingExtensions.SetAlpha(spriteRenderer2, 0f);
								if ((object)spriteRenderer3 == null)
								{
									goto end_IL_0a05;
								}
								GameObject gameObject2 = spriteRenderer3.gameObject;
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
								string name = $"PurpleCloud[{arg}][{arg2}]";
								if ((object)gameObject2 == null)
								{
									goto end_IL_0a05;
								}
								((UnityEngine.Object)gameObject2).SetName(name);
								Transform transform6 = spriteRenderer3.transform;
								if (list2 == null)
								{
									goto end_IL_0a05;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049F4B0");
								if (_backgroundClouds == null)
								{
									goto end_IL_0a05;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5230");
								float value2 = UnityEngine.Random.value;
								bool flag4 = value2 < 0.5f;
								bool flipX = !flag4;
								spriteRenderer3.flipX = flipX;
								float value3 = UnityEngine.Random.value;
								bool flag5 = value3 < 0.5f;
								bool flipY = !flag5;
								spriteRenderer3.flipY = flipY;
								float value4 = UnityEngine.Random.value;
								float num4 = value4 * 360f;
								object obj = num4 ^ -0f;
								Transform transform7 = spriteRenderer3.transform;
								if ((object)transform7 == null)
								{
									goto end_IL_0a05;
								}
								transform7.localEulerAngles = (Vector3)(&vector2);
								BackgroundDevilRoom backgroundDevilRoom2 = backgroundManager;
								if ((object)backgroundManager == null)
								{
									goto end_IL_0a05;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v681 @ rax_v91 (VampireSurvivors.Objects.Stages.BackgroundDevilRoom)+3C]");
								nint num5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v681 @ rax_v91 (VampireSurvivors.Objects.Stages.BackgroundDevilRoom)+3C]");
								object obj2 = num5 + 0;
								float num6 = (float)obj2 / 3.2f;
								object obj3 = transform4 + 1;
								float num7 = (float)obj3 * 0.25f;
								num2 = num7 * num6;
								SpriteRenderer spriteRenderer4 = RenderingExtensions.SetScale(spriteRenderer3, num2);
								TweenConfig tweenConfig = new TweenConfig();
								object[] array = new object[1];
								if (array == null)
								{
									goto end_IL_0a05;
								}
								if ((object)transform6 != null)
								{
									SpriteRenderer spriteRenderer5 = RenderingExtensions.SetScale((SpriteRenderer)(object)transform6, num2);
									bool flag6 = (object)spriteRenderer5 == null;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								if (tweenConfig == null)
								{
									goto end_IL_0a05;
								}
								tweenConfig.targets = array;
								float num8 = num4 + 360f;
								tweenConfig.angle = (float?)(object)1;
								object obj4 = transform4 * 307;
								num = (float)obj4 + 40000f;
								tweenConfig.duration = num;
								tweenConfig.ease = Ease.InOutSine;
								tweenConfig.repeat = -1;
								tweenConfig.rotateMode = RotateMode.Fast;
								MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
								if (_movingBgTweens == null)
								{
									goto end_IL_0a05;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
								ReTween(spriteRenderer3, (int)transform4);
								BackgroundDevilRoom backgroundDevilRoom3 = backgroundManager;
								if ((object)backgroundManager == null)
								{
									goto end_IL_0a05;
								}
								if (((BackgroundManager)backgroundDevilRoom3)._003CDisableMovingBg_003Ek__BackingField)
								{
									if (_movingBgTweens == null)
									{
										goto end_IL_0a05;
									}
									while (enumerator.MoveNext())
									{
									}
									enumerator = enumerator2;
									list2 = list;
									num = (float)enumerator2;
									num2 = 0f;
								}
								else
								{
									list2 = list;
								}
								transform4 = (Transform)(transform4 + 1);
								vector2 = vector;
							}
							transform3 = (Transform)(0 + 1);
							continue;
						}
						if ((object)GM.Core == null)
						{
							break;
						}
						GameObject gameObject3 = GM.Core.gameObject;
						PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject3, vector, "backgroundDevil", "dkCloudsOverlay");
						if ((object)phaserSprite == null)
						{
							break;
						}
						PhaserSprite phaserSprite2 = phaserSprite.setOrigin(0f, (float?)(object)0);
						if ((object)GM.Core == null)
						{
							break;
						}
						PhaserScene s_scene = ArcadePhysics.s_scene;
						if (ArcadePhysics.s_scene == null)
						{
							break;
						}
						PhaserScene.Renderer renderer = s_scene._renderer;
						if (s_scene._renderer == null || (object)GM.Core == null)
						{
							break;
						}
						PhaserScene s_scene2 = ArcadePhysics.s_scene;
						if (ArcadePhysics.s_scene == null || s_scene2._renderer == null || (object)phaserSprite2 == null)
						{
							break;
						}
						float num9 = renderer.width * 100f;
						float xScale = num9 / 320f;
						PhaserSprite phaserSprite3 = phaserSprite2.setScale(xScale, (float?)(object)1);
						if ((object)phaserSprite3 == null)
						{
							break;
						}
						PhaserSprite phaserSprite4 = phaserSprite3.setBlendMode(BlendMode.Normal);
						if ((object)phaserSprite4 == null)
						{
							break;
						}
						PhaserSprite component2 = phaserSprite4.setAlpha(1f);
						PhaserSprite phaserSprite5 = RenderingExtensions.SetScrollFactor(component2, 0f);
						if ((object)phaserSprite5 == null)
						{
							break;
						}
						PhaserSprite phaserSprite6 = phaserSprite5.setDepth(-30030);
						return;
						continue;
						end_IL_0a05:
						break;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void ReTween(SpriteRenderer s, int i)
	{
		//IL_008c: Expected I, but got O
		//IL_00e2: Expected O, but got I4
		//IL_00f5: Expected O, but got I4
		_003C_003Ec__DisplayClass56_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass56_0();
		CS_0024_003C_003E8__locals8._003C_003E4__this = this;
		CS_0024_003C_003E8__locals8.s = s;
		int i2 = default(int);
		CS_0024_003C_003E8__locals8.i = i2;
		if (!_bgEnabled)
		{
			return;
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)CS_0024_003C_003E8__locals8.s != null)
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
		tweenConfig.alpha = (float?)(object)1;
		object obj2 = CS_0024_003C_003E8__locals8.i * 307;
		tweenConfig.yoyo = true;
		tweenConfig.ease = Ease.InOutSine;
		float duration = (float)obj2 + 30000f;
		tweenConfig.duration = duration;
		TweenCallback onComplete = delegate
		{
			CS_0024_003C_003E8__locals8._003C_003E4__this.ReTween(CS_0024_003C_003E8__locals8.s, CS_0024_003C_003E8__locals8.i);
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	public void StartGeigerNoise()
	{
		//IL_00b4: Expected O, but got I4
		//IL_013d: Expected O, but got I4
		//IL_01c6: Expected O, but got I4
		//IL_024f: Expected O, but got I4
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rcx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				return;
			}
		}
		_isPlayingGeigerNoise = true;
		float time = default(float);
		if (_geiger1AL == null)
		{
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			soundConfig.Loop = true;
			PlaySoundResult geiger1AL = SoundManager.PlaySound(SfxType.sfx_geiger1, soundConfig, 0f, 10, time);
			_geiger1AL = geiger1AL;
		}
		if (_geiger2AR == null)
		{
			SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
			soundConfig2.Volume = (float?)(object)1;
			soundConfig2.Rate = 1f;
			soundConfig2.Loop = true;
			PlaySoundResult geiger2AR = SoundManager.PlaySound(SfxType.sfx_geiger2, soundConfig2, 0f, 10, time);
			_geiger2AR = geiger2AR;
		}
		if (_geiger3BL == null)
		{
			SoundManager.SoundConfig soundConfig3 = new SoundManager.SoundConfig();
			soundConfig3.Volume = (float?)(object)1;
			soundConfig3.Rate = 1f;
			soundConfig3.Loop = true;
			PlaySoundResult geiger3BL = SoundManager.PlaySound(SfxType.sfx_geiger3, soundConfig3, 0f, 10, time);
			_geiger3BL = geiger3BL;
		}
		if (_geiger4BR == null)
		{
			SoundManager.SoundConfig soundConfig4 = new SoundManager.SoundConfig();
			soundConfig4.Volume = (float?)(object)1;
			soundConfig4.Rate = 1f;
			soundConfig4.Loop = true;
			PlaySoundResult geiger4BR = SoundManager.PlaySound(SfxType.sfx_geiger4, soundConfig4, 0f, 10, time);
			_geiger4BR = geiger4BR;
		}
	}

	public void StopGeigerNoise()
	{
		PlaySoundResult geiger1AL = _geiger1AL;
		SoundGroupVariation soundGroupVariation = ((_geiger1AL == null) ? null : geiger1AL._003CActingVariation_003Ek__BackingField);
		if ((object)soundGroupVariation != null && ((UnityEngine.Object)soundGroupVariation).m_CachedPtr != (IntPtr)0)
		{
			PlaySoundResult geiger1AL2 = _geiger1AL;
			if (_geiger1AL != null)
			{
				geiger1AL2._003CActingVariation_003Ek__BackingField.AdjustVolume(0f);
			}
		}
		PlaySoundResult geiger2AR = _geiger2AR;
		SoundGroupVariation soundGroupVariation2 = ((_geiger2AR == null) ? null : geiger2AR._003CActingVariation_003Ek__BackingField);
		if ((object)soundGroupVariation2 != null && ((UnityEngine.Object)soundGroupVariation2).m_CachedPtr != (IntPtr)0)
		{
			PlaySoundResult geiger2AR2 = _geiger2AR;
			if (_geiger2AR != null)
			{
				geiger2AR2._003CActingVariation_003Ek__BackingField.AdjustVolume(0f);
			}
		}
		PlaySoundResult geiger3BL = _geiger3BL;
		SoundGroupVariation soundGroupVariation3 = ((_geiger3BL == null) ? null : geiger3BL._003CActingVariation_003Ek__BackingField);
		if ((object)soundGroupVariation3 != null && ((UnityEngine.Object)soundGroupVariation3).m_CachedPtr != (IntPtr)0)
		{
			PlaySoundResult geiger3BL2 = _geiger3BL;
			if (_geiger3BL != null)
			{
				geiger3BL2._003CActingVariation_003Ek__BackingField.AdjustVolume(0f);
			}
		}
		PlaySoundResult geiger4BR = _geiger4BR;
		bool flag = _geiger4BR == null;
		SoundGroupVariation soundGroupVariation4 = null;
		if (!flag)
		{
			soundGroupVariation4 = geiger4BR._003CActingVariation_003Ek__BackingField;
		}
		if ((object)soundGroupVariation4 != null && ((UnityEngine.Object)soundGroupVariation4).m_CachedPtr != (IntPtr)0)
		{
			PlaySoundResult geiger4BR2 = _geiger4BR;
			if (_geiger4BR != null)
			{
				geiger4BR2._003CActingVariation_003Ek__BackingField.AdjustVolume(0f);
			}
		}
		_isPlayingGeigerNoise = false;
		SoundManager.StopSound(SfxType.sfx_geiger1);
		SoundManager.StopSound(SfxType.sfx_geiger2);
		SoundManager.StopSound(SfxType.sfx_geiger3);
		SoundManager.StopSound(SfxType.sfx_geiger4);
	}

	public unsafe void Update()
	{
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected O, but got Unknown
		//IL_061f: Expected O, but got I4
		//IL_0628: Expected F4, but got I4
		//IL_0c82: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c87: Expected O, but got Unknown
		//IL_0706: Expected O, but got I4
		//IL_070f: Expected F4, but got I4
		//IL_027b: Expected O, but got I4
		//IL_07ed: Expected O, but got I4
		//IL_07f6: Expected F4, but got I4
		//IL_0367: Expected O, but got I4
		//IL_08ce: Expected F4, but got I4
		//IL_0b03: Expected O, but got I4
		//IL_045b: Expected O, but got I4
		//IL_09ee->IL09ee: Incompatible stack heights: 2 vs 0
		//IL_062d->IL062d: Incompatible stack heights: 1 vs 0
		//IL_09be->IL0ca2: Incompatible stack heights: 7 vs 3
		//IL_0714->IL0714: Incompatible stack heights: 1 vs 0
		//IL_0280->IL0280: Incompatible stack heights: 5 vs 4
		//IL_07fb->IL07fb: Incompatible stack heights: 1 vs 0
		//IL_0374->IL0374: Incompatible stack heights: 5 vs 4
		//IL_0b08->IL08d3: Incompatible stack heights: 1 vs 0
		//IL_0ae8->IL08d3: Incompatible stack heights: 4 vs 0
		//IL_0460->IL0460: Incompatible stack heights: 5 vs 4
		//IL_04d1->IL08d3: Incompatible stack heights: 4 vs 0
		//IL_04fa->IL08d3: Incompatible stack heights: 4 vs 0
		//IL_0546->IL0aed: Incompatible stack heights: 5 vs 1
		Transform transform5;
		while (true)
		{
			float num2;
			SoundGroupVariation soundGroupVariation;
			float num3;
			object obj2;
			if (_isPlayingGeigerNoise)
			{
				if (!PauseSystem._paused)
				{
					BackgroundDevilRoom backgroundDevilRoom = backgroundManager;
					bool flag = (object)backgroundManager == null;
					float num = (float)backgroundDevilRoom.currentLevel * 0.0625f;
					num2 = num * 0.1f;
					if (!(num2 > 0.1f))
					{
						object obj = 0.1f & -2147483649L;
						if ((nint)obj <= 2139095040)
						{
							goto IL_0a2e;
						}
					}
					num2 = 0.1f;
					goto IL_0a2e;
				}
				PlaySoundResult geiger1AL = _geiger1AL;
				Transform transform = (Transform)(object)((_geiger1AL == null) ? null : geiger1AL._003CActingVariation_003Ek__BackingField);
				if ((object)transform != null && ((UnityEngine.Object)transform).m_CachedPtr != (IntPtr)0)
				{
					PlaySoundResult geiger1AL2 = _geiger1AL;
					if (_geiger1AL != null)
					{
						bool flag2 = (object)geiger1AL2._003CActingVariation_003Ek__BackingField == null;
						geiger1AL2._003CActingVariation_003Ek__BackingField.AdjustVolume(0f);
						obj2 = 0;
						num3 = 0f;
					}
				}
				PlaySoundResult geiger2AR = _geiger2AR;
				Transform transform2 = (Transform)(object)((_geiger2AR == null) ? null : geiger2AR._003CActingVariation_003Ek__BackingField);
				if ((object)transform2 != null && ((UnityEngine.Object)transform2).m_CachedPtr != (IntPtr)0)
				{
					PlaySoundResult geiger2AR2 = _geiger2AR;
					if (_geiger2AR != null)
					{
						bool flag3 = (object)geiger2AR2._003CActingVariation_003Ek__BackingField == null;
						geiger2AR2._003CActingVariation_003Ek__BackingField.AdjustVolume(0f);
						obj2 = 0;
						num3 = 0f;
					}
				}
				PlaySoundResult geiger3BL = _geiger3BL;
				Transform transform3 = (Transform)(object)((_geiger3BL == null) ? null : geiger3BL._003CActingVariation_003Ek__BackingField);
				if ((object)transform3 != null && ((UnityEngine.Object)transform3).m_CachedPtr != (IntPtr)0)
				{
					PlaySoundResult geiger3BL2 = _geiger3BL;
					if (_geiger3BL != null)
					{
						bool flag4 = (object)geiger3BL2._003CActingVariation_003Ek__BackingField == null;
						geiger3BL2._003CActingVariation_003Ek__BackingField.AdjustVolume(0f);
						obj2 = 0;
						num3 = 0f;
					}
				}
				PlaySoundResult geiger4BR = _geiger4BR;
				Transform transform4 = (Transform)(object)((_geiger4BR == null) ? null : geiger4BR._003CActingVariation_003Ek__BackingField);
				if ((object)transform4 != null && ((UnityEngine.Object)transform4).m_CachedPtr != (IntPtr)0)
				{
					PlaySoundResult geiger4BR2 = _geiger4BR;
					if (_geiger4BR != null)
					{
						soundGroupVariation = geiger4BR2._003CActingVariation_003Ek__BackingField;
						bool flag5 = (object)geiger4BR2._003CActingVariation_003Ek__BackingField == null;
						num3 = 0f;
						goto IL_0aed;
					}
				}
			}
			goto IL_08d3;
			IL_08d3:
			Camera main = Camera.main;
			bool flag6 = (object)main == null;
			transform5 = main.transform;
			bool flag7 = (object)transform5 == null;
			if (((UnityEngine.Object)transform5).m_CachedPtr != (IntPtr)0)
			{
				break;
			}
			UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(transform5);
			continue;
			IL_0a2e:
			GameManager core = GM.Core;
			bool flag8 = (object)GM.Core == null;
			PlayerOptions playerOptions = core._playerOptions;
			bool flag9 = core._playerOptions == null;
			PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
			bool flag10 = playerOptions._mainGameConfig == null;
			float num4 = num2 * mainGameConfig._003CSoundsVolume_003Ek__BackingField;
			float deltaTime = PauseSystem.DeltaTime;
			float num5 = deltaTime * 1000f;
			float num6 = (_geigerTime = num5 + _geigerTime);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			PlaySoundResult geiger1AL3 = _geiger1AL;
			float num7 = num6 + 1f;
			float num8 = num7 * 0.5f;
			float num9 = 1f - num8;
			Transform transform6 = (Transform)(object)((_geiger1AL == null) ? null : geiger1AL3._003CActingVariation_003Ek__BackingField);
			if ((object)transform6 != null && ((UnityEngine.Object)transform6).m_CachedPtr != (IntPtr)0)
			{
				PlaySoundResult geiger1AL4 = _geiger1AL;
				if (_geiger1AL != null)
				{
					bool flag11 = (object)geiger1AL4._003CActingVariation_003Ek__BackingField == null;
					num3 = num8 * num4;
					geiger1AL4._003CActingVariation_003Ek__BackingField.AdjustVolume(num3);
					obj2 = 0;
				}
			}
			PlaySoundResult geiger4BR3 = _geiger4BR;
			Transform transform7 = (Transform)(object)((_geiger4BR == null) ? null : geiger4BR3._003CActingVariation_003Ek__BackingField);
			if ((object)transform7 != null && ((UnityEngine.Object)transform7).m_CachedPtr != (IntPtr)0)
			{
				PlaySoundResult geiger4BR4 = _geiger4BR;
				if (_geiger4BR != null)
				{
					bool flag12 = (object)geiger4BR4._003CActingVariation_003Ek__BackingField == null;
					float num10 = num8 * num4;
					geiger4BR4._003CActingVariation_003Ek__BackingField.AdjustVolume(num10);
					obj2 = 0;
					num3 = num10;
				}
			}
			PlaySoundResult geiger2AR3 = _geiger2AR;
			Transform transform8 = (Transform)(object)((_geiger2AR == null) ? null : geiger2AR3._003CActingVariation_003Ek__BackingField);
			if ((object)transform8 != null && ((UnityEngine.Object)transform8).m_CachedPtr != (IntPtr)0)
			{
				PlaySoundResult geiger2AR4 = _geiger2AR;
				if (_geiger2AR != null)
				{
					bool flag13 = (object)geiger2AR4._003CActingVariation_003Ek__BackingField == null;
					num3 = num9 * num4;
					geiger2AR4._003CActingVariation_003Ek__BackingField.AdjustVolume(num3);
					obj2 = 0;
				}
			}
			PlaySoundResult geiger3BL3 = _geiger3BL;
			Transform transform9 = (Transform)(object)((_geiger3BL == null) ? null : geiger3BL3._003CActingVariation_003Ek__BackingField);
			if ((object)transform9 != null && ((UnityEngine.Object)transform9).m_CachedPtr != (IntPtr)0)
			{
				PlaySoundResult geiger3BL4 = _geiger3BL;
				if (_geiger3BL != null)
				{
					soundGroupVariation = geiger3BL4._003CActingVariation_003Ek__BackingField;
					bool flag14 = (object)geiger3BL4._003CActingVariation_003Ek__BackingField == null;
					float num11 = num9 * num4;
					num3 = num11;
					goto IL_0aed;
				}
			}
			goto IL_08d3;
			IL_0aed:
			soundGroupVariation.AdjustVolume(num3);
			obj2 = 0;
			goto IL_08d3;
		}
		Transform.get_position_Injected(((UnityEngine.Object)transform5).m_CachedPtr, out Vector3 _);
		List<SpriteRenderer> backgroundClouds = _backgroundClouds;
		bool flag15 = _backgroundClouds == null;
		Transform transform10 = null;
		Transform transform11 = null;
		float value = default(float);
		float num12 = default(float);
		float num13 = default(float);
		while ((nint)transform11 < backgroundClouds._size)
		{
			List<SpriteRenderer> backgroundClouds2 = _backgroundClouds;
			bool flag16 = (nint)transform10 >= backgroundClouds2._size;
			SpriteRenderer[] items = backgroundClouds2._items;
			Transform transform12 = (Transform)(object)items[(object)transform10];
			bool flag17 = ((UnityEngine.Object)transform12).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)transform12).m_CachedPtr);
			Transform transform13 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			bool flag18 = ((UnityEngine.Object)transform13).m_CachedPtr == (IntPtr)0;
			Transform.set_position_Injected(((UnityEngine.Object)transform13).m_CachedPtr, ref *(Vector3*)(&value));
			backgroundClouds = _backgroundClouds;
			transform10 = (Transform)(transform10 + 1);
			bool flag19 = _backgroundClouds == null;
			float num3 = num12;
			float num6 = num13;
			transform11 = transform10;
		}
		bool flag20 = (object)_centralSprite == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
	}

	public void DisableMovingBackground()
	{
		//IL_0134: Expected O, but got I4
		//IL_013d: Expected O, but got I4
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Expected O, but got Unknown
		//IL_0078->IL00f7: Incompatible stack heights: 1 vs 0
		//IL_00cf->IL00f7: Incompatible stack heights: 1 vs 0
		//IL_01a0->IL00f7: Incompatible stack heights: 2 vs 0
		//IL_0208->IL00f7: Incompatible stack heights: 3 vs 0
		//IL_00f6->IL020d: Incompatible stack heights: 3 vs 0
		_bgEnabled = false;
		ResetCameraRotation();
		List<SpriteRenderer> backgroundClouds = _backgroundClouds;
		bool flag = _backgroundClouds == null;
		object obj = 0;
		object obj2 = 0;
		if (!flag)
		{
			while (true)
			{
				if ((nint)obj2 < backgroundClouds._size)
				{
					List<SpriteRenderer> backgroundClouds2 = _backgroundClouds;
					if (_backgroundClouds == null)
					{
						break;
					}
					bool flag2 = (nint)obj >= backgroundClouds2._size;
					SpriteRenderer[] items = backgroundClouds2._items;
					if (backgroundClouds2._items == null)
					{
						break;
					}
					SpriteRenderer spriteRenderer = items[obj];
					SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(items[obj], 0f);
					if ((object)items[obj] == null)
					{
						break;
					}
					bool flag3 = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
					IntPtr gcHandlePtr = Component.get_gameObject_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr);
					GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
					if ((object)gameObject == null)
					{
						break;
					}
					bool flag4 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					GameObject.SetActive_Injected(((UnityEngine.Object)gameObject).m_CachedPtr, false);
					backgroundClouds = _backgroundClouds;
					obj++;
					if (_backgroundClouds == null)
					{
						break;
					}
					obj2 = obj;
					continue;
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void _003C_002Ector_003Eb__31_0()
	{
		if (_darkToLightTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_darkToLightTween);
		}
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		float x = default(float);
		((BackgroundDevilRoom_Helper)(object)dOSetter)._003CDarkToLight_003Eb__33_1(x);
		TweenerCore<float, float, FloatOptions> darkToLightTween = DOTween.To(getter, dOSetter, 1f, 0.25f);
		_darkToLightTween = darkToLightTween;
	}

	private void _003C_002Ector_003Eb__31_1()
	{
		StartMusic();
	}

	private float _003CDarkToLight_003Eb__33_0()
	{
		Light2D globalLight = _globalLight;
		return globalLight.m_Intensity;
	}

	private void _003CDarkToLight_003Eb__33_1(float x)
	{
		Light2D globalLight = _globalLight;
		globalLight.m_Intensity = x;
	}

	private void _003CStartMusic_003Eb__34_0()
	{
		RegisterMusicLoopEvents();
		Action onComplete = RegisterMusicLoopEvents;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		Timer musicLoopEvent = TimerHelper.RegisterMillisUI(LoopDurationMS, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat);
		_musicLoopEvent = musicLoopEvent;
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_0()
	{
		RedLightSwoop(10);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_1()
	{
		WallEyes(1);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_2()
	{
		RedLightSwoop(9);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_3()
	{
		WallEyes(2);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_4()
	{
		WallEyes(5);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_5()
	{
		WallEyes(5);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_6()
	{
		RedLightSwoop(8);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_7()
	{
		WallEyes(6);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_8()
	{
		RedLightSwoop(7);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_9()
	{
		WallEyes(7);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_10()
	{
		WallEyes(7);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_11()
	{
		WallEyes(7);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_12()
	{
		WallEyes(7);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_13()
	{
		RedLightSwoop(6);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_14()
	{
		WallEyes(8);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_15()
	{
		WallEyes(8);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_16()
	{
		WallEyes(8);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_17()
	{
		RedLightSwoop(5);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_18()
	{
		WallEyes(9);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_19()
	{
		WallEyes(10);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_20()
	{
		RedLightSwoop(4);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_21()
	{
		WallEyes(11);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_22()
	{
		WallEyes(11);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_23()
	{
		WallEyes(11);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_24()
	{
		WallEyes(11);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_25()
	{
		WallEyes(11);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_26()
	{
		WallEyes(11);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_27()
	{
		WallEyes(11);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_28()
	{
		WallEyes(11);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_29()
	{
		BackgroundEyes(3);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_30()
	{
		BackgroundEyes(4);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_31()
	{
		BackgroundEyes(7);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_32()
	{
		BackgroundEyes(7);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_33()
	{
		BackgroundEyes(8);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_34()
	{
		BackgroundEyes(9);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_35()
	{
		BackgroundEyes(9);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_36()
	{
		BackgroundEyes(9);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_37()
	{
		BackgroundEyes(9);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_38()
	{
		BackgroundEyes(10);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_39()
	{
		BackgroundEyes(10);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_40()
	{
		BackgroundEyes(10);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_41()
	{
		BackgroundEyes(11);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_42()
	{
		BackgroundEyes(12);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_43()
	{
		BackgroundEyes(13);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_44()
	{
		BackgroundEyes(13);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_45()
	{
		BackgroundEyes(13);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_46()
	{
		BackgroundEyes(13);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_47()
	{
		BackgroundEyes(13);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_48()
	{
		BackgroundEyes(13);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_49()
	{
		BackgroundEyes(13);
	}

	private void _003CRegisterMusicLoopEvents_003Eb__35_50()
	{
		BackgroundEyes(13);
	}

	private void _003CRedLightSwoop_003Eb__36_0()
	{
		Light2D redLight = _redLight;
		redLight.m_Intensity = 0f;
	}

	private float _003CPulseLight_003Eb__46_0()
	{
		Light2D globalLight = _globalLight;
		return globalLight.m_Intensity;
	}

	private void _003CPulseLight_003Eb__46_1(float x)
	{
		Light2D globalLight = _globalLight;
		globalLight.m_Intensity = x;
	}

	private float _003CPulseLight_003Eb__46_2()
	{
		Light2D globalLight = _globalLight;
		return globalLight.m_Intensity;
	}

	private void _003CPulseLight_003Eb__46_3(float x)
	{
		Light2D globalLight = _globalLight;
		globalLight.m_Intensity = x;
	}

	private void _003CPulseBlood_003Eb__47_0()
	{
		TopEmitter.Stop();
	}
}
