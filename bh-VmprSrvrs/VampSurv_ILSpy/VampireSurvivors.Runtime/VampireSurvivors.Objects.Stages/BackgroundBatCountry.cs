using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Objects;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.VFX;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Stages;

public class BackgroundBatCountry : BackgroundManager
{
	private sealed class _003C_003Ec__DisplayClass39_0
	{
		public float value;

		public BackgroundBatCountry _003C_003E4__this;

		internal void _003CFadeSphere_003Eb__0()
		{
			//IL_000b: Invalid comparison between I4 and F4
			if (!(0f < value))
			{
				BackgroundBatCountry backgroundBatCountry = _003C_003E4__this;
				backgroundBatCountry._sphereImage.enabled = false;
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass40_0
	{
		public float value;

		public BackgroundBatCountry _003C_003E4__this;

		internal void _003CFadeCheckerboard_003Eb__0()
		{
			//IL_000b: Invalid comparison between I4 and F4
			if (!(0f < value))
			{
				BackgroundBatCountry backgroundBatCountry = _003C_003E4__this;
				backgroundBatCountry._checkerboardImage.enabled = false;
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass44_0
	{
		public BackgroundBatCountry _003C_003E4__this;

		public ItemType relicType;

		internal void _003CSpawnRelicInConcrete_003Eb__0()
		{
			//IL_0047: Expected O, but got I4
			//IL_0047: Expected O, but got I4
			//IL_0047: Expected O, but got I4
			//IL_0130: Expected I4, but got O
			//IL_00d3: Expected I4, but got O
			//IL_00d3: Expected F4, but got O
			_003C_003Ec__DisplayClass44_1 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass44_1();
			GameManager core = GM.Core;
			Stage stage = core._stage;
			BackgroundBatCountry backgroundBatCountry = _003C_003E4__this;
			EnemyType? enemyType = default(EnemyType?);
			stage._stageEventManager.PlayDiamondConcrete((float?)(object)1, (float?)(object)1, (float?)(object)1, enemyType);
			CS_0024_003C_003E8__locals6.item = null;
			GameManager core2 = GM.Core;
			PlayerOptionsData config = core2._playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
			object obj = default(object);
			MonoBehaviour monoBehaviour = default(MonoBehaviour);
			int num = default(int);
			if (obj == null)
			{
				Vector2 pos = default(Vector2);
				Pickup item = GM.Core.MakeStagePickup(pos, ItemType.RELIC, WeaponType.VOID, (float)enemyType, (ItemType)monoBehaviour, (byte)num != 0);
				CS_0024_003C_003E8__locals6.item = item;
			}
			Action onComplete = delegate
			{
				Pickup item2 = CS_0024_003C_003E8__locals6.item;
				if ((object)CS_0024_003C_003E8__locals6.item != null && ((UnityEngine.Object)item2).m_CachedPtr != (IntPtr)0)
				{
					Pickup item3 = CS_0024_003C_003E8__locals6.item;
					if (item3.body != null)
					{
						item3.Despawn();
						GameManager core3 = GM.Core;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA52F0");
						object obj2 = default(object);
						if (obj2 != null)
						{
							GameManager core4 = GM.Core;
							bool flag = ((List<object>)(object)core4._stagePickups).Remove((object)CS_0024_003C_003E8__locals6.item);
						}
					}
				}
			};
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(60.000004f, onComplete, null, isLooped: false, (byte)(int)enemyType != 0, monoBehaviour, num, type, isOnlineTimer: false, canPause: false);
		}
	}

	private sealed class _003C_003Ec__DisplayClass44_1
	{
		public Pickup item;

		internal void _003CSpawnRelicInConcrete_003Eb__1()
		{
			Pickup pickup = item;
			if ((object)item == null || ((UnityEngine.Object)pickup).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			Pickup pickup2 = item;
			if (pickup2.body != null)
			{
				pickup2.Despawn();
				GameManager core = GM.Core;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA52F0");
				object obj = default(object);
				if (obj != null)
				{
					GameManager core2 = GM.Core;
					bool flag = ((List<object>)(object)core2._stagePickups).Remove((object)item);
				}
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass45_0
	{
		public BackgroundBatCountry _003C_003E4__this;

		public PhaserSprite groundWarning;

		public TweenCallback _003C_003E9__2;

		internal void _003CDisplayWarningZone_003Eb__0()
		{
			float2 position = default(float2);
			_003C_003E4__this.SingleWarning(position);
		}

		internal void _003CDisplayWarningZone_003Eb__1()
		{
			//IL_002c: Expected I, but got O
			//IL_0082: Expected O, but got I4
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if ((object)groundWarning != null)
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
			tweenConfig.duration = 100f;
			TweenCallback onComplete = _003C_003E9__2;
			if (_003C_003E9__2 == null)
			{
				onComplete = (_003C_003E9__2 = delegate
				{
					GameObject gameObject = groundWarning.gameObject;
					UnityEngine.Object.Destroy(gameObject, 0f);
				});
			}
			tweenConfig.onComplete = onComplete;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		}

		internal void _003CDisplayWarningZone_003Eb__2()
		{
			GameObject gameObject = groundWarning.gameObject;
			UnityEngine.Object.Destroy(gameObject, 0f);
		}
	}

	private sealed class _003C_003Ec__DisplayClass46_0
	{
		public PhaserSprite s;

		public TweenCallback _003C_003E9__1;

		internal void _003CSingleWarning_003Eb__0()
		{
			//IL_002c: Expected I, but got O
			//IL_0082: Expected O, but got I4
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if ((object)s != null)
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
			tweenConfig.scale = (float?)(object)1;
			tweenConfig.duration = 200f;
			tweenConfig.delay = 200f;
			TweenCallback onComplete = _003C_003E9__1;
			if (_003C_003E9__1 == null)
			{
				onComplete = (_003C_003E9__1 = delegate
				{
					GameObject gameObject = s.gameObject;
					UnityEngine.Object.Destroy(gameObject, 0f);
				});
			}
			tweenConfig.onComplete = onComplete;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		}

		internal void _003CSingleWarning_003Eb__1()
		{
			GameObject gameObject = s.gameObject;
			UnityEngine.Object.Destroy(gameObject, 0f);
		}
	}

	public float _LerpV;

	private bool _canChangeColor;

	private bool _fixedBgColor;

	private int _colorIndex;

	private float2 _center;

	private readonly uint[] _colorsTop;

	private readonly uint[] _colorsBottom;

	private GottaSphereFast _sphereImage;

	private RainbowCheckerboard _checkerboardImage;

	private MultiTargetTween _sphereAlphaTween;

	private MultiTargetTween _checkerboardAlphaTween;

	private Timer _colorChangeTimeout;

	private PhaserSprite _backgroundTile;

	private Timer _pizzaDelayTimer;

	private bool _customBG;

	private bool _canPizza;

	private bool _isTilesetVisible;

	private bool _isCheckerBoardVisible;

	private bool _isSphereVisible;

	private Circle _pizzaA;

	private PhaserSprite _pizzaAsprite;

	private PhaserSprite _pizzaBsprite;

	private Circle _pizzaB;

	private PhaserSprite _pizzaCsprite;

	private Circle _pizzaC;

	private MapToken _mapToken;

	private Timer _checkSecretTimer;

	protected override void OnUpdate()
	{
		base.OnUpdate();
		if (_canChangeColor)
		{
			ChangeColor();
		}
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		while (enumerator.MoveNext())
		{
			if (_canPizza)
			{
				CheckPizzas(null);
			}
		}
	}

	public override void Cleanup()
	{
		base._003CIsBackgroundActive_003Ek__BackingField = false;
		if (_colorChangeTimeout != null)
		{
			_colorChangeTimeout.Cancel();
		}
		if (_checkSecretTimer != null)
		{
			_checkSecretTimer.Cancel();
		}
		CheckSecret();
	}

	public override void Create()
	{
		base.Create();
		base._003CHasMovingBg_003Ek__BackingField = true;
		_fixedBgColor = false;
		InitVFX();
	}

	public unsafe override void OnInitCompleted()
	{
		base.OnInitCompleted();
		InitBackground();
		_canChangeColor = false;
		Action action = StartColorChange;
		action._002Ector(this, (nint)__ldftn(BackgroundBatCountry.StartColorChange));
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer colorChangeTimeout = Timers.Register(10.200001f, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_colorChangeTimeout = colorChangeTimeout;
		GameManager core = GM.Core;
		Stage stage = core._stage;
		TilingTileset tilingTileset = stage._tilingTileset;
		bool flag = !tilingTileset._inverted;
		float num = 10.200001f;
		if (!flag)
		{
			GameManager core2 = GM.Core;
			PlayerOptionsData config = core2._playerOptions.Config;
			bool flag2 = !config._003CVisuallyInvertStages_003Ek__BackingField;
			num = 10.200001f;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.BackgroundBatCountry)+90]");
				num = 0f + 10.24f;
			}
		}
		GameManager core3 = GM.Core;
		PlayerOptionsData config2 = core3._playerOptions.Config;
		List<ItemType> list = config2._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rcx_v13 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 == 0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj = default(object);
		if ((nint)obj == -1)
		{
			return;
		}
		GameManager core4 = GM.Core;
		PlayerOptionsData config3 = core4._playerOptions.Config;
		List<ItemType> list2 = config3._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rcx_v19 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			if ((nint)obj2 != -1)
			{
				_canPizza = true;
				MakePizza();
				MakeRings();
				Action onComplete = CheckSecret;
				Timer checkSecretTimer = Timers.Register(10f, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				_checkSecretTimer = checkSecretTimer;
			}
		}
	}

	public override void CheckMinute(int minute)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 16 Invalid \"Jump target not found in method: 0x186F05509\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 31 Invalid \"Jump target not found in method: 0x186F05509\"");
	}

	private void InitBackground()
	{
		//IL_007d: Expected F4, but got O
		//IL_00ae: Expected F4, but got O
		//IL_0132: Expected I4, but got I8
		GameManager core = GM.Core;
		TilingBackground bgMan = core._bgMan;
		TileSprite bgtile = bgMan._bgtile;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(bgtile._spriteRenderer, 0f);
		Camera main = Camera.main;
		int2 renderTextureSize = CameraExtensions.GetRenderTextureSize(main);
		float height = (object)renderTextureSize >> 32;
		PhaserWorld instance = PhaserWorld.Instance;
		Vector2 pos = default(Vector2);
		uint num = default(uint);
		PhaserSprite backgroundTile = instance.AddRectangle(pos, (float)renderTextureSize, height, num);
		_backgroundTile = backgroundTile;
		PhaserSprite phaserSprite = RenderingExtensions.SetScrollFactor(_backgroundTile, 0f);
		BlendMode blendMode = default(BlendMode);
		PhaserSprite phaserSprite2 = RenderingExtensions.SetTint(_backgroundTile, 0u, 0u, 0u, num, blendMode);
		PhaserSprite phaserSprite3 = _backgroundTile.setAlpha(0f);
		PhaserSprite phaserSprite4 = _backgroundTile.setDepth(-32768);
		GameObject gameObject = _backgroundTile.gameObject;
		((UnityEngine.Object)gameObject).SetName("BatCountryBackgroundTile");
	}

	private unsafe void InitVFX()
	{
		//IL_0039: Expected O, but got Ref
		//IL_0039: Expected O, but got Ref
		//IL_009b: Expected O, but got Ref
		//IL_009b: Expected O, but got Ref
		ObjectPool pool = HeroVfxManager._factory.GetPool(HeroVfxType.RainbowCheckerboard);
		int num = default(int);
		Quaternion quaternion2 = default(Quaternion);
		GameObject obj = pool.GetObject((Vector3)(&num), (Quaternion)(&quaternion2));
		RainbowCheckerboard objectComponent = pool.GetObjectComponent<RainbowCheckerboard>(obj);
		_checkerboardImage = objectComponent;
		ObjectPool pool2 = HeroVfxManager._factory.GetPool(HeroVfxType.GottaSphereFast);
		Vector3 vector = default(Vector3);
		GameObject obj2 = pool2.GetObject((Vector3)(&vector), (Quaternion)(&quaternion2));
		GottaSphereFast objectComponent2 = pool2.GetObjectComponent<GottaSphereFast>(obj2);
		_sphereImage = objectComponent2;
		_checkerboardImage.enabled = false;
		_sphereImage.enabled = false;
		GameManager core = GM.Core;
		Stage stage = core._stage;
		TilingTileset tilingTileset = stage._tilingTileset;
		if (tilingTileset._inverted)
		{
			GameManager core2 = GM.Core;
			PlayerOptionsData config = core2._playerOptions.Config;
			if (config._003CVisuallyInvertStages_003Ek__BackingField)
			{
				RainbowCheckerboard rainbowCheckerboard = RenderingExtensions.SetScale(_checkerboardImage, 1f, -1f);
				GottaSphereFast gottaSphereFast = RenderingExtensions.SetScale(_sphereImage, 1f, -1f);
			}
		}
	}

	private void StartColorChange()
	{
		//IL_002c: Expected I, but got O
		//IL_0090: Expected O, but got I4
		//IL_00cc: Expected I, but got O
		//IL_017f: Expected I4, but got I8
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_backgroundTile != null)
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
		tweenConfig.duration = 200f;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value = default(object);
			bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_LerpV", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig2.custom = dictionary;
			tweenConfig2.duration = 10000f;
			tweenConfig2.repeat = -1;
			TweenCallback onRepeat = delegate
			{
				uint[] colorsTop = _colorsTop;
				int num3 = _colorIndex + 1;
				_LerpV = 0f;
				_colorIndex = num3;
				if (num3 >= colorsTop.Length)
				{
					_colorIndex = 0;
				}
			};
			tweenConfig2.onRepeat = onRepeat;
			MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
			_colorIndex = 0;
			_canChangeColor = true;
			return;
		}
		ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
		throw ex2;
	}

	private void GetCenter()
	{
		//IL_0048: Expected O, but got F4
		GameManager core = GM.Core;
		Stage stage = core._stage;
		TilingTileset tilingTileset = stage._tilingTileset;
		float num = (float)tilingTileset._currentBounds + 10.24f;
		_center = (float2)num;
		GameManager core2 = GM.Core;
		Stage stage2 = core2._stage;
		TilingTileset tilingTileset2 = stage2._tilingTileset;
		float num2 = (float)tilingTileset2._currentBounds - 15.36f;
		GameManager core3 = GM.Core;
		Stage stage3 = core3._stage;
		TilingTileset tilingTileset3 = stage3._tilingTileset;
		if (tilingTileset3._inverted)
		{
			GameManager core4 = GM.Core;
			PlayerOptionsData config = core4._playerOptions.Config;
			if (config._003CVisuallyInvertStages_003Ek__BackingField)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.BackgroundBatCountry)+90]");
				float num3 = 0f + 10.24f;
			}
		}
	}

	private unsafe void ChangeColor()
	{
		//IL_0024: Expected O, but got I4
		//IL_0074: Invalid comparison between I4 and F4
		//IL_017f: Invalid comparison between I4 and F4
		//IL_00e6: Expected F4, but got I4
		//IL_0117: Expected O, but got I4
		//IL_0117: Expected O, but got Ref
		//IL_0117: Expected O, but got Ref
		//IL_0117: Expected O, but got Ref
		uint num2 = default(uint);
		BlendMode blendMode = default(BlendMode);
		if (!_fixedBgColor)
		{
			uint[] colorsTop = _colorsTop;
			object obj = _colorIndex + 1;
			if ((nint)obj >= colorsTop.Length)
			{
			}
			if (0f > _LerpV || _LerpV > 1f)
			{
			}
			float lerpV = _LerpV;
			if (!(0f > _LerpV))
			{
				if (lerpV > 1f)
				{
					lerpV = 1f;
				}
			}
			else
			{
				lerpV = 0f;
			}
			PhaserSprite backgroundTile = _backgroundTile;
			object obj2 = default(object);
			object obj3 = default(object);
			float num = default(float);
			SpriteRenderer spriteRenderer = RenderingExtensions.SetTint(backgroundTile._spriteRenderer, (Color)(&obj2), (Color)(&obj3), (Color)(&num), (Color)num2, blendMode);
		}
		else
		{
			PhaserSprite phaserSprite = RenderingExtensions.SetTint(_backgroundTile, 6591981u, 6591981u, 922914u, num2, blendMode);
		}
	}

	public override void DisableMovingBackground()
	{
		_fixedBgColor = true;
		GameObject gameObject = _sphereImage.gameObject;
		gameObject.SetActive(value: false);
		GameObject gameObject2 = _checkerboardImage.gameObject;
		gameObject2.SetActive(value: false);
	}

	public override void EnableMovingBackground()
	{
		_fixedBgColor = false;
		GameObject gameObject = _sphereImage.gameObject;
		gameObject.SetActive(value: true);
		GameObject gameObject2 = _checkerboardImage.gameObject;
		gameObject2.SetActive(value: true);
	}

	private void FadeSphere(float value, float duration)
	{
		//IL_0051: Invalid comparison between F4 and I4
		//IL_00f3: Expected I, but got O
		_003C_003Ec__DisplayClass39_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass39_0();
		CS_0024_003C_003E8__locals5.value = value;
		CS_0024_003C_003E8__locals5._003C_003E4__this = this;
		if (_fixedBgColor)
		{
			return;
		}
		if (CS_0024_003C_003E8__locals5.value > 0f)
		{
			_sphereImage.enabled = true;
			GottaSphereFast sphereImage = _sphereImage;
			sphereImage.alpha = 0f;
		}
		if (_sphereAlphaTween != null)
		{
			_sphereAlphaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_sphereImage != null)
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
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object value2 = default(object);
		bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"alpha", value2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		tweenConfig.custom = dictionary;
		tweenConfig.duration = duration;
		TweenCallback onComplete = delegate
		{
			//IL_000b: Invalid comparison between I4 and F4
			if (!(0f < CS_0024_003C_003E8__locals5.value))
			{
				BackgroundBatCountry backgroundBatCountry = CS_0024_003C_003E8__locals5._003C_003E4__this;
				backgroundBatCountry._sphereImage.enabled = false;
			}
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween sphereAlphaTween = Tweens.Add(tweenConfig);
		_sphereAlphaTween = sphereAlphaTween;
	}

	private void FadeCheckerboard(float value, float duration)
	{
		//IL_0051: Invalid comparison between F4 and I4
		//IL_00f3: Expected I, but got O
		_003C_003Ec__DisplayClass40_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass40_0();
		CS_0024_003C_003E8__locals5.value = value;
		CS_0024_003C_003E8__locals5._003C_003E4__this = this;
		if (_fixedBgColor)
		{
			return;
		}
		if (CS_0024_003C_003E8__locals5.value > 0f)
		{
			_checkerboardImage.enabled = true;
			RainbowCheckerboard checkerboardImage = _checkerboardImage;
			checkerboardImage.alpha = 0f;
		}
		if (_checkerboardAlphaTween != null)
		{
			_checkerboardAlphaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_checkerboardImage != null)
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
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object value2 = default(object);
		bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"alpha", value2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		tweenConfig.custom = dictionary;
		tweenConfig.duration = duration;
		TweenCallback onComplete = delegate
		{
			//IL_000b: Invalid comparison between I4 and F4
			if (!(0f < CS_0024_003C_003E8__locals5.value))
			{
				BackgroundBatCountry backgroundBatCountry = CS_0024_003C_003E8__locals5._003C_003E4__this;
				backgroundBatCountry._checkerboardImage.enabled = false;
			}
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween checkerboardAlphaTween = Tweens.Add(tweenConfig);
		_checkerboardAlphaTween = checkerboardAlphaTween;
	}

	private void BonusRound()
	{
		//IL_0062: Expected O, but got I4
		//IL_0054: Expected O, but got I4
		GameManager core = GM.Core;
		Stage stage = core._stage;
		StageModifiers stageModifiers = stage._003CStageMods_003Ek__BackingField;
		float? num = (float?)(((object)stageModifiers._003CEnemySpeed_003Ek__BackingField == null) ? ((object)0) : ((object)1));
		stageModifiers._003CEnemySpeed_003Ek__BackingField = num;
		GameManager core2 = GM.Core;
		core2._stage.CalculateEnemySpeed();
	}

	private void EndBonusRound()
	{
		//IL_0062: Expected O, but got I4
		//IL_0054: Expected O, but got I4
		GameManager core = GM.Core;
		Stage stage = core._stage;
		StageModifiers stageModifiers = stage._003CStageMods_003Ek__BackingField;
		float? num = (float?)(((object)stageModifiers._003CEnemySpeed_003Ek__BackingField == null) ? ((object)0) : ((object)1));
		stageModifiers._003CEnemySpeed_003Ek__BackingField = num;
		GameManager core2 = GM.Core;
		core2._stage.CalculateEnemySpeed();
	}

	private void FadeTileset(float alpha = 1f, float durationMillis = 1000f)
	{
		GameManager core = GM.Core;
		Stage stage = core._stage;
		stage._tilingTileset.FadeAllLayers(alpha, durationMillis);
	}

	private void SpawnRelicInConcrete(ItemType relicType)
	{
		_003C_003Ec__DisplayClass44_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass44_0();
		CS_0024_003C_003E8__locals4._003C_003E4__this = this;
		CS_0024_003C_003E8__locals4.relicType = relicType;
		GetCenter();
		DisplayWarningZone();
		Action onComplete = delegate
		{
			//IL_0047: Expected O, but got I4
			//IL_0047: Expected O, but got I4
			//IL_0047: Expected O, but got I4
			//IL_0130: Expected I4, but got O
			//IL_00d3: Expected I4, but got O
			//IL_00d3: Expected F4, but got O
			_003C_003Ec__DisplayClass44_1 CS_0024_003C_003E8__locals10 = new _003C_003Ec__DisplayClass44_1();
			GameManager core = GM.Core;
			Stage stage = core._stage;
			BackgroundBatCountry backgroundBatCountry = CS_0024_003C_003E8__locals4._003C_003E4__this;
			EnemyType? enemyType = default(EnemyType?);
			stage._stageEventManager.PlayDiamondConcrete((float?)(object)1, (float?)(object)1, (float?)(object)1, enemyType);
			CS_0024_003C_003E8__locals10.item = null;
			GameManager core2 = GM.Core;
			PlayerOptionsData config = core2._playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
			object obj = default(object);
			MonoBehaviour monoBehaviour = default(MonoBehaviour);
			int num = default(int);
			if (obj == null)
			{
				Vector2 pos = default(Vector2);
				Pickup item = GM.Core.MakeStagePickup(pos, ItemType.RELIC, WeaponType.VOID, (float)enemyType, (ItemType)monoBehaviour, (byte)num != 0);
				CS_0024_003C_003E8__locals10.item = item;
			}
			Action onComplete2 = delegate
			{
				Pickup item2 = CS_0024_003C_003E8__locals10.item;
				if ((object)CS_0024_003C_003E8__locals10.item != null && ((UnityEngine.Object)item2).m_CachedPtr != (IntPtr)0)
				{
					Pickup item3 = CS_0024_003C_003E8__locals10.item;
					if (item3.body != null)
					{
						item3.Despawn();
						GameManager core3 = GM.Core;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA52F0");
						object obj2 = default(object);
						if (obj2 != null)
						{
							GameManager core4 = GM.Core;
							bool flag = ((List<object>)(object)core4._stagePickups).Remove((object)CS_0024_003C_003E8__locals10.item);
						}
					}
				}
			};
			TimerType type2 = default(TimerType);
			Timer timer2 = Timers.Register(60.000004f, onComplete2, null, isLooped: false, (byte)(int)enemyType != 0, monoBehaviour, num, type2, isOnlineTimer: false, canPause: false);
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(2f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void DisplayWarningZone()
	{
		//IL_0059: Expected O, but got I4
		//IL_010a: Expected I, but got O
		//IL_018a: Expected O, but got I4
		_003C_003Ec__DisplayClass45_0 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass45_0();
		CS_0024_003C_003E8__locals9._003C_003E4__this = this;
		PhaserWorld instance = PhaserWorld.Instance;
		Vector2 vector = default(Vector2);
		uint fillColor = default(uint);
		PhaserSprite phaserSprite = instance.AddRectangle(vector, 448f, 448f, fillColor);
		PhaserSprite phaserSprite2 = phaserSprite.setOrigin(0.5f, (float?)(object)0);
		PhaserSprite phaserSprite3 = phaserSprite2.setAlpha(0.2f);
		PhaserSprite phaserSprite4 = phaserSprite3.setVisible(visible: true);
		PhaserSprite groundWarning = phaserSprite4.setBlendMode(BlendMode.Add);
		CS_0024_003C_003E8__locals9.groundWarning = groundWarning;
		SingleWarning(vector);
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)CS_0024_003C_003E8__locals9.groundWarning != null)
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
		tweenConfig.duration = 200f;
		tweenConfig.yoyo = true;
		tweenConfig.repeat = 3;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onRepeat = delegate
		{
			float2 position = default(float2);
			CS_0024_003C_003E8__locals9._003C_003E4__this.SingleWarning(position);
		};
		tweenConfig.onRepeat = onRepeat;
		TweenCallback onComplete = delegate
		{
			//IL_002c: Expected I, but got O
			//IL_0082: Expected O, but got I4
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			if ((object)CS_0024_003C_003E8__locals9.groundWarning != null)
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
			tweenConfig2.alpha = (float?)(object)1;
			tweenConfig2.duration = 100f;
			TweenCallback onComplete2 = CS_0024_003C_003E8__locals9._003C_003E9__2;
			if (CS_0024_003C_003E8__locals9._003C_003E9__2 == null)
			{
				onComplete2 = (CS_0024_003C_003E8__locals9._003C_003E9__2 = delegate
				{
					GameObject obj3 = CS_0024_003C_003E8__locals9.groundWarning.gameObject;
					UnityEngine.Object.Destroy(obj3, 0f);
				});
			}
			tweenConfig2.onComplete = onComplete2;
			MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	private void SingleWarning(float2 position)
	{
		//IL_01be: Expected O, but got I4
		//IL_01da: Expected O, but got F4
		//IL_0066: Expected O, but got I4
		//IL_0082: Expected O, but got I4
		//IL_0100: Expected I, but got O
		//IL_0160: Expected O, but got I4
		//IL_0123->IL0123: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass46_0 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass46_0();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float detune = (float)obj2 * 500f;
		soundConfig.Rate = 1f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Pizza, soundConfig, 150f, 2, time);
		PhaserWorld instance = PhaserWorld.Instance;
		Vector2 pos = default(Vector2);
		PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "UI", "ExclamationMark");
		PhaserSprite phaserSprite2 = phaserSprite.setScale(0f, (float?)(object)0);
		PhaserSprite phaserSprite3 = phaserSprite2.setOrigin(0.5f, (float?)(object)0);
		PhaserSprite s = phaserSprite3.setDepth(9000f);
		CS_0024_003C_003E8__locals7.s = s;
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)CS_0024_003C_003E8__locals7.s != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			bool flag = obj3 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 200f;
		tweenConfig.scale = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			//IL_002c: Expected I, but got O
			//IL_0082: Expected O, but got I4
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			if ((object)CS_0024_003C_003E8__locals7.s != null)
			{
				nint num2 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj4 = default(object);
				if (obj4 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			tweenConfig2.scale = (float?)(object)1;
			tweenConfig2.duration = 200f;
			tweenConfig2.delay = 200f;
			TweenCallback onComplete2 = CS_0024_003C_003E8__locals7._003C_003E9__1;
			if (CS_0024_003C_003E8__locals7._003C_003E9__1 == null)
			{
				onComplete2 = (CS_0024_003C_003E8__locals7._003C_003E9__1 = delegate
				{
					GameObject obj5 = CS_0024_003C_003E8__locals7.s.gameObject;
					UnityEngine.Object.Destroy(obj5, 0f);
				});
			}
			tweenConfig2.onComplete = onComplete2;
			MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	public void MakePizza()
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected F4, but got Unknown
		//IL_0085: Expected F4, but got I4
		//IL_008e: Expected F4, but got I4
		//IL_00de: Expected F4, but got I4
		//IL_00e7: Expected F4, but got I4
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float height = renderer.height;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		float depth = height ^ 0;
		GameManager core = GM.Core;
		Stage stage = core._stage;
		TilingTileset tilingTileset = stage._tilingTileset;
		bool flag = !tilingTileset._inverted;
		float num = 0f;
		float num2 = 0f;
		if (!flag)
		{
			GameManager core2 = GM.Core;
			PlayerOptionsData config = core2._playerOptions.Config;
			bool flag2 = !config._003CVisuallyInvertStages_003Ek__BackingField;
			num = 0f;
			num2 = 0f;
			if (!flag2)
			{
				num = -1024f;
				num2 = 1432f;
			}
		}
		float num3 = num2 + 248f;
		float y = num - 96f;
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "items", "PizzaA.png");
		PhaserSprite pizzaAsprite = phaserSprite.setDepth(depth);
		_pizzaAsprite = pizzaAsprite;
		Circle circle = new Circle();
		circle._x = num3;
		circle._y = y;
		circle._radius = 16f;
		_pizzaA = circle;
		float num4 = num3 + 64f;
		GameObject gameObject2 = base.gameObject;
		PhaserSprite phaserSprite2 = RenderingExtensions.AddPhaserSprite(gameObject2, pos, "items", "PizzaB.png");
		PhaserSprite pizzaBsprite = phaserSprite2.setDepth(depth);
		_pizzaBsprite = pizzaBsprite;
		Circle circle2 = new Circle();
		circle2._x = num4;
		circle2._y = y;
		circle2._radius = 16f;
		_pizzaB = circle2;
		float x = num4 + 64f;
		GameObject gameObject3 = base.gameObject;
		PhaserSprite phaserSprite3 = RenderingExtensions.AddPhaserSprite(gameObject3, pos, "items", "PizzaC.png");
		PhaserSprite pizzaCsprite = phaserSprite3.setDepth(depth);
		_pizzaCsprite = pizzaCsprite;
		Circle circle3 = new Circle();
		circle3._x = x;
		circle3._y = y;
		circle3._radius = 16f;
		_pizzaC = circle3;
		MapToken mapToken = new MapToken();
		_mapToken = mapToken;
		Circle pizzaB = _pizzaB;
		MapToken mapToken2 = _mapToken;
		float x2 = pizzaB._x * 0.01f;
		mapToken2.x = x2;
		Circle pizzaB2 = _pizzaB;
		MapToken mapToken3 = _mapToken;
		float y2 = pizzaB2._y * 0.01f;
		mapToken3.y = y2;
		GameManager core3 = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1340");
	}

	public void CheckPizzas(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_01a0: Expected F4, but got I4
		//IL_014b: Expected F4, but got I4
		//IL_00f6: Expected F4, but got I4
		if (!_canPizza || _pizzaA == null)
		{
			return;
		}
		float2 position = character.position;
		float2 position2 = character.position;
		Vector2 point = default(Vector2);
		PhaserSprite pizzaSprite;
		if (!_pizzaA.Contains(point))
		{
			if (!_pizzaB.Contains(point))
			{
				if (!_pizzaC.Contains(point))
				{
					return;
				}
				_customBG = true;
				bool flag = !_isSphereVisible;
				FadeSphere(flag ? 1 : 0, 500f);
				bool isSphereVisible = !_isSphereVisible;
				pizzaSprite = _pizzaCsprite;
				_isSphereVisible = isSphereVisible;
			}
			else
			{
				_customBG = true;
				bool flag2 = !_isCheckerBoardVisible;
				FadeCheckerboard(flag2 ? 1 : 0, 500f);
				bool isCheckerBoardVisible = !_isCheckerBoardVisible;
				pizzaSprite = _pizzaBsprite;
				_isCheckerBoardVisible = isCheckerBoardVisible;
			}
		}
		else
		{
			_customBG = true;
			bool flag3 = !_isTilesetVisible;
			FadeTileset(flag3 ? 1 : 0, 500f);
			bool isTilesetVisible = !_isTilesetVisible;
			pizzaSprite = _pizzaAsprite;
			_isTilesetVisible = isTilesetVisible;
		}
		AnimPizza(pizzaSprite);
		DelayPizza();
	}

	public void AnimPizza(PhaserSprite pizzaSprite)
	{
		//IL_0161: Expected O, but got I4
		//IL_00b7: Expected I, but got O
		//IL_0137: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Bumper, soundConfig, 100f, 4, time);
		PhaserSprite phaserSprite = _pizzaAsprite.setAlpha(0.65f);
		PhaserSprite phaserSprite2 = _pizzaBsprite.setAlpha(0.65f);
		PhaserSprite phaserSprite3 = _pizzaCsprite.setAlpha(0.65f);
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)pizzaSprite != null)
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
		tweenConfig.ease = Ease.InOutBounce;
		tweenConfig.yoyo = true;
		tweenConfig.duration = 300f;
		tweenConfig.scale = (float?)(object)1;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	public void DelayPizza()
	{
		_canPizza = false;
		Action onComplete = delegate
		{
			_canPizza = true;
			PhaserSprite phaserSprite = _pizzaAsprite.setAlpha(1f);
			PhaserSprite phaserSprite2 = _pizzaBsprite.setAlpha(1f);
			PhaserSprite phaserSprite3 = _pizzaCsprite.setAlpha(1f);
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer pizzaDelayTimer = Timers.Register(1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_pizzaDelayTimer = pizzaDelayTimer;
	}

	public void MakeRings()
	{
		//IL_0040: Expected I, but got O
		//IL_02b7: Expected I, but got O
		//IL_02d3: Expected O, but got I
		//IL_02ee: Expected O, but got I
		//IL_00a0: Expected I, but got O
		//IL_00ae: Expected I, but got O
		//IL_00be: Expected O, but got I
		//IL_013e: Expected O, but got I4
		//IL_0093: Expected I, but got O
		//IL_0279: Expected I, but got O
		//IL_00fa: Expected O, but got I
		//IL_014b: Expected I, but got O
		//IL_0130: Expected O, but got I4
		//IL_0221: Expected I4, but got I8
		//IL_023d: Expected O, but got I4
		GetCenter();
		if (!GM.Core.IsStageHost)
		{
			return;
		}
		List<Pickup> list = new List<Pickup>();
		nint num = unchecked((nint)null);
		Vector2 pos = default(Vector2);
		float value = default(float);
		ItemType relicType = default(ItemType);
		bool validatePickups = default(bool);
		do
		{
			nint num2 = (nint)typeof(GM);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,edi\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v376 @ rax_v11 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
			((List<Pickup>)0)._002Ector();
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,edi\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v376 @ rax_v11 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
			((List<Pickup>)0)._002Ector();
			Pickup pickup = GM.Core.MakeStagePickup(pos, ItemType.WEAPON, WeaponType.GOLD, value, relicType, validatePickups);
			nint num3;
			if ((object)pickup == null)
			{
				num3 = unchecked((nint)null);
				goto IL_028c;
			}
			nint num4 = (nint)pickup;
			nint num5 = (nint)typeof(PickupWeapon);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v418 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v417 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v418 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
			object obj3;
			if (num6 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v417 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v473 @ rax_v44+FFFFFFF8+v419 @ rax_v40*8]");
				if (0 == (nint)typeof(PickupWeapon))
				{
					obj3 = 1;
					goto IL_0265;
				}
			}
			obj3 = 0;
			goto IL_0265;
			IL_0265:
			bool flag = obj3 == null;
			num3 = unchecked((nint)null);
			if (!flag)
			{
				num3 = (nint)pickup;
			}
			goto IL_028c;
			IL_028c:
			if (num3 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rbx_v7 (Il2CppMethodInfo)+10]");
				if ((nint)0 != 0)
				{
					_ = 1135869952;
					_ = 199;
					_ = 1;
					_ = 1;
					_ = 1;
				}
			}
			list._002Ector();
			num++;
		}
		while (num < 9);
		Pickup[] targets = list.ToArray();
		TweenConfig tweenConfig = new TweenConfig();
		tweenConfig.targets = targets;
		tweenConfig.repeat = -1;
		tweenConfig.duration = 1000f;
		tweenConfig.angle = (float?)(object)1;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	public unsafe void CheckSecret()
	{
		//IL_002f: Expected O, but got I
		//IL_0065: Expected O, but got I
		//IL_015c: Expected O, but got I4
		//IL_016a: Expected O, but got I4
		//IL_0172: Expected O, but got Ref
		//IL_02fb: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3B1A]");
		bool flag = (nint)0 != 0;
		PlayerOptions core = (PlayerOptions)(object)GM.Core;
		if ((object)GM.Core != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rcx_v8 (VampireSurvivors.Objects.PlayerOptions)+90]");
			core = (PlayerOptions)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rcx_v8 (VampireSurvivors.Objects.PlayerOptions)+90]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rcx_v8 (VampireSurvivors.Objects.PlayerOptions)+90]");
				PlayerOptionsData config = ((PlayerOptions)0).Config;
				if (config != null)
				{
					core = (PlayerOptions)(object)config._003CUnlockedCharacters_003Ek__BackingField;
					if (config._003CUnlockedCharacters_003Ek__BackingField != null)
					{
						if (core.PowerUpPurchased != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
							object obj = default(object);
							if ((nint)obj != -1)
							{
								return;
							}
						}
						GameManager core2 = GM.Core;
						if ((object)GM.Core != null && core2._characters != null)
						{
							object obj2 = 0;
							List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
							if (enumerator.MoveNext())
							{
								object obj3 = 0;
								List<Equipment>.Enumerator enumerator2 = (List<Equipment>.Enumerator)(&enumerator);
								throw new NullReferenceException();
							}
							if ((nint)obj2 < 9)
							{
								return;
							}
							GameManager core3 = GM.Core;
							if ((object)GM.Core != null && core3._playerOptions != null)
							{
								PlayerOptionsData config2 = core3._playerOptions.Config;
								bool flag2 = core3._playerOptions.UnlockSecret(SecretType.GetRingOfRings, config2);
								if (_checkSecretTimer != null)
								{
									_checkSecretTimer.Cancel();
								}
								SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
								soundConfig.Volume = (float?)(object)1;
								soundConfig.Detune = -1000f;
								soundConfig.Rate = 0.5f;
								float time = default(float);
								PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ThingFound, soundConfig, 0f, 10, time);
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public BackgroundBatCountry()
	{
		//IL_0052: Expected O, but got I4
		_center = (float2)1092867850;
		_ = 3245720207L;
		_colorsTop = new uint[3] { 8912896u, 8947712u, 34952u };
		_colorsBottom = new uint[3] { 2228224u, 2236928u, 8738u };
		_isTilesetVisible = true;
		base._002Ector();
	}

	private void _003CStartColorChange_003Eb__34_0()
	{
		uint[] colorsTop = _colorsTop;
		int num = _colorIndex + 1;
		_LerpV = 0f;
		_colorIndex = num;
		if (num >= colorsTop.Length)
		{
			_colorIndex = 0;
		}
	}

	private void _003CDelayPizza_003Eb__50_0()
	{
		_canPizza = true;
		PhaserSprite phaserSprite = _pizzaAsprite.setAlpha(1f);
		PhaserSprite phaserSprite2 = _pizzaBsprite.setAlpha(1f);
		PhaserSprite phaserSprite3 = _pizzaCsprite.setAlpha(1f);
	}
}
