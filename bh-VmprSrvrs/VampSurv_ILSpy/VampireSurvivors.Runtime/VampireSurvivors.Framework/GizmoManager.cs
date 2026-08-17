using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Scripts.Graphics;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.VFX;
using VampireSurvivors.Objects.VFX.Gizmos;
using Zenject;

namespace VampireSurvivors.Framework;

public class GizmoManager : IInitializable, IDisposable, ITickable
{
	private sealed class _003C_003Ec__DisplayClass25_0
	{
		public int i1;

		internal void _003CDisplayQuickTreasureChestAnimation_003Eb__0()
		{
			//IL_004b: Expected O, but got I4
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			soundConfig.Volume = (float?)(object)1;
			float detune = (float)i1 * 50f;
			soundConfig.Detune = detune;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Coin, soundConfig, 0f, 10, time);
		}
	}

	private sealed class _003C_003Ec__DisplayClass29_0
	{
		public GizmoManager _003C_003E4__this;

		public SpriteRenderer angel;

		public VampireSurvivors.Objects.Characters.CharacterController character;

		public ObjectPool angelPool;

		public TweenCallback _003C_003E9__3;

		internal void _003CDisplayAngel_003Eb__0()
		{
			GizmoManager gizmoManager = _003C_003E4__this;
			if (_003C_003E4__this != null)
			{
				gizmoManager.AngelYOffset = 0f;
				SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(angel, 1f);
				if ((object)angel != null)
				{
					angel.enabled = true;
					if ((object)character != null)
					{
						float2 position = character.position;
						if ((object)character != null)
						{
							float2 position2 = character.position;
							if ((object)angel != null)
							{
								Transform transform = angel.transform;
								bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								Vector3 value = default(Vector3);
								Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
								return;
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}

		internal void _003CDisplayAngel_003Eb__1()
		{
			float2 position = character.position;
			float2 position2 = character.position;
			Transform transform = angel.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		}

		internal void _003CDisplayAngel_003Eb__2()
		{
			TweenCallback callback = _003C_003E9__3;
			if (_003C_003E9__3 == null)
			{
				callback = (_003C_003E9__3 = delegate
				{
					GameObject gameObject = angel.gameObject;
					angelPool.Release(gameObject);
				});
			}
			Tween tween = DOVirtual.DelayedCall(0.1f, callback, ignoreTimeScale: false);
		}

		internal void _003CDisplayAngel_003Eb__3()
		{
			GameObject gameObject = angel.gameObject;
			angelPool.Release(gameObject);
		}
	}

	public float AngelYOffset;

	public float IconYOffset;

	public float LevelUpYOffset;

	private GameSessionData _gameSessionData;

	private GameObject _particlesObject;

	private ParticleEmitterManager _particleEmitterManager;

	private ParticleSystem _pfxEmitter;

	private ParticleSystem _quickTreasureEmitter;

	private List<Sprite> _angelFrames;

	private PhaserSprite _highlight;

	private PhaserSprite _rainbow;

	private MultiTargetTween _highlightTween;

	private MultiTargetTween _highlightTween2;

	private MultiTargetTween _rainbowTween;

	private MultiTargetTween _rainbowTween2;

	public void Initialize()
	{
		InitLevelUp();
		InitQuickTreasureChest();
	}

	public void Dispose()
	{
	}

	public void Tick()
	{
	}

	public unsafe void ShowHighlightAt(float x, float y)
	{
		//IL_0069: Expected O, but got I4
		//IL_0143: Expected I4, but got O
		//IL_0248: Expected I4, but got O
		//IL_0347: Expected I, but got O
		//IL_039d: Expected O, but got I4
		//IL_03c7: Expected O, but got I4
		//IL_04df: Expected I, but got O
		//IL_0535: Expected O, but got I4
		//IL_0543: Expected O, but got I4
		//IL_056d: Expected O, but got I4
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Lucky, null, 500f, 1, time);
		PhaserSprite highlight = _highlight;
		if ((object)_highlight != null)
		{
			bool flag = ((UnityEngine.Object)highlight).m_CachedPtr != (IntPtr)0;
			int num = 1;
			Vector2 vector = (Vector2)0;
			if (flag)
			{
				goto IL_0150;
			}
		}
		PhaserWorld instance = PhaserWorld.Instance;
		Vector2 vector2 = default(Vector2);
		PhaserSprite phaserSprite = instance.AddPhaserSprite(vector2, "vfx", "sPFX_ring_64");
		PhaserSprite phaserSprite2 = phaserSprite.setVisible(visible: false);
		PhaserSprite phaserSprite3 = phaserSprite2.setBlendMode(BlendMode.Add);
		PhaserSprite phaserSprite4 = phaserSprite3.setTint(65280u);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			PhaserSprite highlight2 = phaserSprite4.setDepth(renderer.pixelHeight);
			_highlight = highlight2;
			int num = (int)"sPFX_ring_64";
			Vector2 vector = vector2;
			goto IL_0150;
		}
		goto IL_05df;
		IL_0150:
		PhaserSprite rainbow = _rainbow;
		if ((object)_rainbow == null || ((UnityEngine.Object)rainbow).m_CachedPtr == (IntPtr)0)
		{
			PhaserWorld instance2 = PhaserWorld.Instance;
			PhaserSprite phaserSprite5 = instance2.AddPhaserSprite(vector2, "vfx", "s_pfx_rainbow_64");
			PhaserSprite phaserSprite6 = phaserSprite5.setVisible(visible: false);
			PhaserSprite phaserSprite7 = phaserSprite6.setBlendMode(BlendMode.Add);
			if ((object)GM.Core == null)
			{
				goto IL_05df;
			}
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer2 = s_scene2._renderer;
			PhaserSprite rainbow2 = phaserSprite7.setDepth(renderer2.pixelHeight);
			_rainbow = rainbow2;
			int num = (int)"s_pfx_rainbow_64";
			Vector2 vector = vector2;
		}
		_highlight.X = x;
		_highlight.Y = y;
		_rainbow.X = x;
		_rainbow.Y = y;
		if (_highlightTween != null)
		{
			_highlightTween.Kill();
		}
		if (_highlightTween2 != null)
		{
			_highlightTween2.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_highlight != null)
		{
			nint num2 = (nint)array;
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
		tweenConfig.duration = 250f;
		tweenConfig.ease = Ease.OutSine;
		tweenConfig.scale = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			//IL_0058: Expected O, but got Ref
			PhaserSprite phaserSprite8 = RenderingExtensions.SetScale(_highlight, 0f);
			PhaserSprite phaserSprite9 = _highlight.setAlpha(0f);
			Transform transform = _highlight.transform;
			object obj3 = default(object);
			transform.localEulerAngles = (Vector3)(&obj3);
			PhaserSprite phaserSprite10 = _highlight.setVisible(visible: true);
		};
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = delegate
		{
			//IL_002c: Expected I, but got O
			//IL_0090: Expected O, but got I4
			TweenConfig tweenConfig3 = new TweenConfig();
			object[] array3 = new object[1];
			if ((object)_highlight != null)
			{
				nint num4 = (nint)array3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj3 = default(object);
				if (obj3 == null)
				{
					ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
					throw ex3;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig3.targets = array3;
			tweenConfig3.duration = 250f;
			tweenConfig3.alpha = (float?)(object)1;
			TweenCallback onComplete3 = delegate
			{
				PhaserSprite phaserSprite8 = _highlight.setVisible(visible: false);
			};
			tweenConfig3.onComplete = onComplete3;
			MultiTargetTween highlightTween2 = Tweens.Add(tweenConfig3);
			_highlightTween2 = highlightTween2;
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween highlightTween = Tweens.Add(tweenConfig);
		_highlightTween = highlightTween;
		if (_rainbowTween != null)
		{
			_rainbowTween.Kill();
		}
		if (_rainbowTween2 != null)
		{
			_rainbowTween2.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		if ((object)_rainbow != null)
		{
			nint num3 = (nint)array2;
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
		tweenConfig2.scale = (float?)(object)1;
		tweenConfig2.duration = 300f;
		tweenConfig2.ease = Ease.OutSine;
		tweenConfig2.angle = (float?)(object)1;
		TweenCallback onStart2 = delegate
		{
			//IL_0058: Expected O, but got Ref
			PhaserSprite phaserSprite8 = RenderingExtensions.SetScale(_rainbow, 0f);
			PhaserSprite phaserSprite9 = _rainbow.setAlpha(0f);
			Transform transform = _rainbow.transform;
			object obj3 = default(object);
			transform.localEulerAngles = (Vector3)(&obj3);
			PhaserSprite phaserSprite10 = _rainbow.setVisible(visible: true);
		};
		tweenConfig2.onStart = onStart2;
		TweenCallback onComplete2 = delegate
		{
			//IL_002c: Expected I, but got O
			//IL_0090: Expected O, but got I4
			//IL_009e: Expected O, but got I4
			TweenConfig tweenConfig3 = new TweenConfig();
			object[] array3 = new object[1];
			if ((object)_rainbow != null)
			{
				nint num4 = (nint)array3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj3 = default(object);
				if (obj3 == null)
				{
					ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
					throw ex3;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig3.targets = array3;
			tweenConfig3.duration = 250f;
			tweenConfig3.alpha = (float?)(object)1;
			tweenConfig3.angle = (float?)(object)1;
			TweenCallback onComplete3 = delegate
			{
				PhaserSprite phaserSprite8 = _rainbow.setVisible(visible: false);
			};
			tweenConfig3.onComplete = onComplete3;
			MultiTargetTween rainbowTween2 = Tweens.Add(tweenConfig3);
			_rainbowTween2 = rainbowTween2;
		};
		tweenConfig2.onComplete = onComplete2;
		MultiTargetTween rainbowTween = Tweens.Add(tweenConfig2);
		_rainbowTween = rainbowTween;
		return;
		IL_05df:
		throw new NullReferenceException();
	}

	public void DisplayLevelUp(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_0155: Expected O, but got I4
		//IL_01b0->IL0127: Incompatible stack heights: 1 vs 0
		LevelUpGizmo objectComponent;
		if ((object)HeroVfxManager._factory != null)
		{
			ObjectPool pool = HeroVfxManager._factory.GetPool(HeroVfxType.LevelUpGizmo);
			if ((object)pool != null)
			{
				objectComponent = pool.GetObjectComponent<LevelUpGizmo>();
				if ((object)objectComponent != null)
				{
					objectComponent._activePlayer = character;
					objectComponent.SetupEmitter();
					if (objectComponent._defaultBlurPositionSet)
					{
						goto IL_0127;
					}
					if ((object)objectComponent._Blur != null)
					{
						Transform transform = objectComponent._Blur.transform;
						if ((object)transform != null)
						{
							bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Transform.get_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
							objectComponent._blurDefaultLocalPosition = ret;
							_ = 0;
							objectComponent._defaultBlurPositionSet = true;
							goto IL_0127;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_0127:
		objectComponent.Play();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.AutoLV, soundConfig, 200f, 1, time);
	}

	public void DisplayLimitBreakLevelUp(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_0021: Expected O, but got I4
		DisplayAngel(character);
		DisplayLevelUp(character);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.AutoLB, soundConfig, 200f, 1, time);
	}

	public void DisplayMultiplayerRevive(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_0055: Expected O, but got I4
		DisplayAngel(character);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.AutoLB, soundConfig, 200f, 1, time);
	}

	public void DisplayWeaponLevelup(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_0055: Expected O, but got I4
		DisplayLevelUp(character);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.AutoLV, soundConfig, 200f, 1, time);
	}

	public unsafe void DisplayWeaponIconOverhead(WeaponType weaponType, string value, Color? color, VampireSurvivors.Objects.Characters.CharacterController character, float displayTimeMultiplier = 1f, Vector2 vOffset = default(Vector2))
	{
		//IL_00d5: Expected O, but got I
		//IL_00ea: Expected O, but got I
		//IL_0139: Expected O, but got Ref
		//IL_0139: Expected O, but got I
		if (weaponType == WeaponType.VOID)
		{
			return;
		}
		GameManager core = GM.Core;
		Dictionary<WeaponType, List<WeaponData>> convertedWeapons = core._dataManager.GetConvertedWeapons();
		if (!((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).TryGetValue((System.Int32Enum)weaponType, out object value2) || value2 == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ stack_-38_v6 (System.Object)+18]");
		if ((nint)0 <= (nint)0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ stack_-38_v6 (System.Object)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ stack_-38_v6 (System.Object)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rcx_v10+20]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rcx_v10+20]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rdx_v7+40]");
				object obj3 = default(object);
				VampireSurvivors.Objects.Characters.CharacterController character2 = default(VampireSurvivors.Objects.Characters.CharacterController);
				float displayTimeMultiplier2 = default(float);
				Vector2 vOffset2 = default(Vector2);
				string textureName = default(string);
				DisplayIconOverhead((string)0, value, (Color?)(object)(&obj3), character2, displayTimeMultiplier2, vOffset2, textureName);
			}
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public unsafe void DisplayIconOverhead(string frameName, string value, Color? color, VampireSurvivors.Objects.Characters.CharacterController character, float displayTimeMultiplier = 1f, Vector2 vOffset = default(Vector2), string textureName = "items")
	{
		//IL_0085: Expected O, but got Ref
		ObjectPool pool = HeroVfxManager._factory.GetPool(HeroVfxType.OverheadIconGizmo);
		OverheadIconGizmo objectComponent = pool.GetObjectComponent<OverheadIconGizmo>();
		if ((object)objectComponent != null && ((UnityEngine.Object)objectComponent).m_CachedPtr != (IntPtr)0)
		{
			object obj = default(object);
			VampireSurvivors.Objects.Characters.CharacterController character2 = default(VampireSurvivors.Objects.Characters.CharacterController);
			float displayTimeMultiplier2 = default(float);
			Vector2 vOffset2 = default(Vector2);
			string textureName2 = default(string);
			objectComponent.Play(frameName, value, (Color?)(object)(&obj), character2, displayTimeMultiplier2, vOffset2, textureName2);
		}
	}

	public unsafe void DisplayQuickTreasureChestAnimation(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_002f: Expected I4, but got I8
		//IL_0059: Expected O, but got I4
		//IL_00e7: Expected I, but got O
		//IL_00fd: Expected O, but got I
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Expected O, but got Unknown
		//IL_0174: Expected I, but got O
		//IL_0190: Expected O, but got I4
		//IL_01a7: Expected I, but got I8
		//IL_01f4: Expected I4, but got F4
		//IL_015d: Expected I, but got I8
		float2 position = character.position;
		Vector2 pos = default(Vector2);
		RenderingExtensions.EmitParticleAt(_quickTreasureEmitter, pos, -1);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float num = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Coin, soundConfig, 0f, 10, num);
		int num2 = 1;
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		do
		{
			_003C_003Ec__DisplayClass25_0 obj = new _003C_003Ec__DisplayClass25_0();
			obj.i1 = num2;
			Action action = null;
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ r10_v3 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass25_0._003CDisplayQuickTreasureChestAnimation_003Eb__0);
			((Delegate)action).m_target = obj;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ r10_v3 (Il2CppMethodInfo)+4C]");
			object obj2 = (nint)0 >> 4;
			object obj3 = obj2 & 1;
			nint num4;
			if (obj3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ r10_v3 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num4 = unchecked((nint)6447293664L);
					goto IL_0187;
				}
			}
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			num4 = ((Delegate)action).method_ptr;
			goto IL_0187;
			IL_0187:
			object obj4 = 24;
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			float num5 = (float)num2 * 100f;
			float duration = num5 * 0.001f;
			Timer timer = Timers.Register(duration, action, null, isLooped: false, (byte)(int)num != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			num2++;
		}
		while (num2 <= 4);
	}

	private void Init()
	{
		InitLevelUp();
		InitQuickTreasureChest();
	}

	private unsafe void InitLevelUp()
	{
		//IL_0008: Expected O, but got Ref
		//IL_01a2: Expected O, but got I4
		//IL_01c9: Expected O, but got I4
		//IL_01f0: Expected O, but got I4
		//IL_0209: Expected O, but got Ref
		//IL_0218: Expected O, but got I4
		//IL_0226: Expected native int or pointer, but got O
		//IL_0240: Expected O, but got I
		//IL_0258: Expected O, but got Ref
		//IL_0272: Expected native int or pointer, but got O
		//IL_028c: Expected O, but got I
		//IL_02ac: Expected O, but got Ref
		//IL_02c6: Expected native int or pointer, but got O
		//IL_04ae: Expected O, but got I4
		//IL_02de: Expected O, but got Ref
		//IL_0305: Expected O, but got I
		//IL_031f: Expected native int or pointer, but got O
		//IL_04cb: Expected O, but got I4
		//IL_0351: Expected O, but got Ref
		//IL_036b: Expected native int or pointer, but got O
		//IL_0505: Expected O, but got I
		//IL_03a3: Expected O, but got Ref
		//IL_03bd: Expected native int or pointer, but got O
		//IL_053f: Expected O, but got I
		//IL_043d: Expected O, but got I
		//IL_045e: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		int zeroPad = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("angel_", 1, 8, "angel", zeroPad);
		_angelFrames = animationFrames;
		Line line = null;
		line._x1 = -0.16f;
		line._y1 = 0f;
		line._x2 = 0.16f;
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, "GizmoManagerParticles");
		_particlesObject = gameObject;
		ParticleEmitterManager particleEmitterManager = _particlesObject.AddComponent<ParticleEmitterManager>();
		_particleEmitterManager = particleEmitterManager;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PfxLine2");
		}
		else
		{
			int size = list._size + 1;
			list._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(250f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 16));
		_ = 0;
		obj = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 0f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-10]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 16));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+10]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+20]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 48));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(60f, 90f));
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+E0]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(0.5f, 0f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+60]");
		_ = 0;
		particleSystemConfig._scaleX = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-78]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-68]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 112));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(4f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+70]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+80]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-60]");
		particleSystemConfig._scaleY = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-40]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 144));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0.35f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+90]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+A0]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-38]");
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-18]");
		_ = 0;
		EmitZone emitZone = new EmitZone();
		emitZone._type = EmitZoneType.Edge;
		emitZone._source = line;
		particleSystemConfig._emitZone = emitZone;
		_ = 0;
		_ = 1065353216;
		_ = 1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+E0]");
		particleSystemConfig._frequency = (float?)(object)0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+E0]");
		particleSystemConfig._blendMode = (BlendMode?)(object)0;
		particleSystemConfig._on = false;
		ParticleSystem pfxEmitter = _particleEmitterManager.CreateEmitter(particleSystemConfig);
		_pfxEmitter = pfxEmitter;
	}

	private unsafe void InitQuickTreasureChest()
	{
		//IL_0008: Expected O, but got Ref
		//IL_02ea: Expected O, but got I
		//IL_0306: Expected O, but got I4
		//IL_031f: Expected O, but got Ref
		//IL_0339: Expected native int or pointer, but got O
		//IL_04d0: Expected O, but got I4
		//IL_0351: Expected O, but got Ref
		//IL_036b: Expected native int or pointer, but got O
		//IL_0385: Expected O, but got I
		//IL_03a5: Expected O, but got Ref
		//IL_03bf: Expected native int or pointer, but got O
		//IL_04ed: Expected O, but got I4
		//IL_03f1: Expected O, but got Ref
		//IL_040b: Expected native int or pointer, but got O
		//IL_0527: Expected O, but got I
		//IL_0451: Expected O, but got I4
		//IL_04ae: Expected I4, but got I8
		object obj2 = default(object);
		object obj = (object)(&obj2);
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, "GizmoManagerTreasureParticles");
		ParticleEmitterManager particleEmitterManager = gameObject.AddComponent<ParticleEmitterManager>();
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("items");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"MoneyBagGreen");
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
			((List<object>)(object)list).AddWithResize((object)"CoinGold");
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
			((List<object>)(object)list).AddWithResize((object)"CoinGold");
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
			((List<object>)(object)list).AddWithResize((object)"CoinGold");
		}
		else
		{
			int size4 = list._size + 1;
			list._size = size4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		_ = 0;
		_ = 20;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+90]");
		particleSystemConfig._quantity = (int?)(object)0;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(2000f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 56));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(1f, 0f));
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(245f, 295f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-18]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-8]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(425f, 475f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+18]");
		_ = 0;
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-78]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-68]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(2f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+38]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-60]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-40]");
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(800f);
		particleSystemConfig._gravity = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		particleSystemConfig._on = false;
		ParticleSystem quickTreasureEmitter = particleEmitterManager.CreateEmitter(particleSystemConfig);
		_quickTreasureEmitter = quickTreasureEmitter;
		Vector2 pos = default(Vector2);
		RenderingExtensions.EmitParticleAt(_quickTreasureEmitter, pos, -1);
	}

	private void DisplayAngel(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_00e2: Expected I, but got O
		//IL_0135: Expected I, but got O
		//IL_0199: Expected O, but got I4
		_003C_003Ec__DisplayClass29_0 CS_0024_003C_003E8__locals26 = new _003C_003Ec__DisplayClass29_0();
		CS_0024_003C_003E8__locals26._003C_003E4__this = this;
		CS_0024_003C_003E8__locals26.character = character;
		ObjectPool pool = HeroVfxManager._factory.GetPool(HeroVfxType.AngelGizmo);
		CS_0024_003C_003E8__locals26.angelPool = pool;
		SpriteRenderer objectComponent = CS_0024_003C_003E8__locals26.angelPool.GetObjectComponent<SpriteRenderer>();
		CS_0024_003C_003E8__locals26.angel = objectComponent;
		SpriteAnimation component = CS_0024_003C_003E8__locals26.angel.GetComponent<SpriteAnimation>();
		((BaseSpriteAnimation)component)._currentAnimation = null;
		component.SetAnimation("angel");
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[2];
		if ((object)CS_0024_003C_003E8__locals26.angel != null)
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
		if (this != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 500f;
		tweenConfig.alpha = (float?)(object)1;
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object value = default(object);
		bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"AngelYOffset", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		tweenConfig.custom = dictionary;
		TweenCallback onStart = delegate
		{
			GizmoManager gizmoManager = CS_0024_003C_003E8__locals26._003C_003E4__this;
			if (CS_0024_003C_003E8__locals26._003C_003E4__this != null)
			{
				gizmoManager.AngelYOffset = 0f;
				SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(CS_0024_003C_003E8__locals26.angel, 1f);
				if ((object)CS_0024_003C_003E8__locals26.angel != null)
				{
					CS_0024_003C_003E8__locals26.angel.enabled = true;
					if ((object)CS_0024_003C_003E8__locals26.character != null)
					{
						float2 position = CS_0024_003C_003E8__locals26.character.position;
						if ((object)CS_0024_003C_003E8__locals26.character != null)
						{
							float2 position2 = CS_0024_003C_003E8__locals26.character.position;
							if ((object)CS_0024_003C_003E8__locals26.angel != null)
							{
								Transform transform = CS_0024_003C_003E8__locals26.angel.transform;
								bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								Vector3 value2 = default(Vector3);
								Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value2);
								return;
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		};
		tweenConfig.onStart = onStart;
		TweenCallback onUpdate = delegate
		{
			float2 position = CS_0024_003C_003E8__locals26.character.position;
			float2 position2 = CS_0024_003C_003E8__locals26.character.position;
			Transform transform = CS_0024_003C_003E8__locals26.angel.transform;
			bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value2 = default(Vector3);
			Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value2);
		};
		tweenConfig.onUpdate = onUpdate;
		TweenCallback onComplete = delegate
		{
			TweenCallback callback = CS_0024_003C_003E8__locals26._003C_003E9__3;
			if (CS_0024_003C_003E8__locals26._003C_003E9__3 == null)
			{
				callback = (CS_0024_003C_003E8__locals26._003C_003E9__3 = delegate
				{
					GameObject gameObject = CS_0024_003C_003E8__locals26.angel.gameObject;
					CS_0024_003C_003E8__locals26.angelPool.Release(gameObject);
				});
			}
			Tween tween = DOVirtual.DelayedCall(0.1f, callback, ignoreTimeScale: false);
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	private unsafe void _003CShowHighlightAt_003Eb__18_0()
	{
		//IL_0058: Expected O, but got Ref
		PhaserSprite phaserSprite = RenderingExtensions.SetScale(_highlight, 0f);
		PhaserSprite phaserSprite2 = _highlight.setAlpha(0f);
		Transform transform = _highlight.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
		PhaserSprite phaserSprite3 = _highlight.setVisible(visible: true);
	}

	private void _003CShowHighlightAt_003Eb__18_1()
	{
		//IL_002c: Expected I, but got O
		//IL_0090: Expected O, but got I4
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_highlight != null)
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
		tweenConfig.duration = 250f;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			PhaserSprite phaserSprite = _highlight.setVisible(visible: false);
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween highlightTween = Tweens.Add(tweenConfig);
		_highlightTween2 = highlightTween;
	}

	private void _003CShowHighlightAt_003Eb__18_2()
	{
		PhaserSprite phaserSprite = _highlight.setVisible(visible: false);
	}

	private unsafe void _003CShowHighlightAt_003Eb__18_3()
	{
		//IL_0058: Expected O, but got Ref
		PhaserSprite phaserSprite = RenderingExtensions.SetScale(_rainbow, 0f);
		PhaserSprite phaserSprite2 = _rainbow.setAlpha(0f);
		Transform transform = _rainbow.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
		PhaserSprite phaserSprite3 = _rainbow.setVisible(visible: true);
	}

	private void _003CShowHighlightAt_003Eb__18_4()
	{
		//IL_002c: Expected I, but got O
		//IL_0090: Expected O, but got I4
		//IL_009e: Expected O, but got I4
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_rainbow != null)
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
		tweenConfig.duration = 250f;
		tweenConfig.alpha = (float?)(object)1;
		tweenConfig.angle = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			PhaserSprite phaserSprite = _rainbow.setVisible(visible: false);
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween rainbowTween = Tweens.Add(tweenConfig);
		_rainbowTween2 = rainbowTween;
	}

	private void _003CShowHighlightAt_003Eb__18_5()
	{
		PhaserSprite phaserSprite = _rainbow.setVisible(visible: false);
	}
}
