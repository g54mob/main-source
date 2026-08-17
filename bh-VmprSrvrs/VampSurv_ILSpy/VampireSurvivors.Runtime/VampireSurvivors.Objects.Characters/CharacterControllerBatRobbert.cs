using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Characters;

public class CharacterControllerBatRobbert : CharacterController
{
	private int MaxHealthMaxBonus = 665;

	private int CurrentMaxHPBonus;

	private PhaserSprite _highlight;

	private PhaserSprite _rainbow;

	private MultiTargetTween _highlightTween;

	private MultiTargetTween _rainbowTween;

	private MultiTargetTween _highlightTween2;

	private MultiTargetTween _rainbowTween2;

	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		base._isCriticalHPEnabled = true;
		Action onCriticalHP = CriticalHP;
		base._onCriticalHP = onCriticalHP;
	}

	private void CriticalHP()
	{
		//IL_0193: Expected O, but got I4
		//IL_0025: Expected O, but got I4
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Expected I4, but got Unknown
		//IL_004b: Expected O, but got I4
		if (CurrentMaxHPBonus < MaxHealthMaxBonus)
		{
			PlayerModifierStats playerStats = _playerStats;
			object obj = MaxHealthMaxBonus - CurrentMaxHPBonus;
			if ((nint)obj >= 32)
			{
				obj = 32;
			}
			int currentMaxHPBonus = CurrentMaxHPBonus + obj;
			CurrentMaxHPBonus = currentMaxHPBonus;
			EggFloat eggFloat = playerStats._003CMaxHp_003Ek__BackingField;
			float value = default(float);
			EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
			value = (float)obj + eggFloat._val;
			playerStats._003CMaxHp_003Ek__BackingField = eggFloat2;
		}
		float num = base.MaxHp();
		object obj2 = default(object);
		float value2 = (float)obj2 * 0.3f;
		base.RecoverHp(value2, showRecovery: true);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Detune = -1000f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Ophion1, soundConfig, 200f, 4, time);
		float2 float5 = base.position;
		float2 float6 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 256 Invalid \"Jump target not found in method: 0x18759C980\"");
		throw new NullReferenceException();
	}

	private void CriticalAnim()
	{
		//IL_0060: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		soundConfig.Detune = -1000f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Ophion1, soundConfig, 200f, 4, time);
		float2 float5 = base.position;
		float2 float6 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 73 Invalid \"Jump target not found in method: 0x18759C980\"");
	}

	public unsafe void ShowHighlightAt(float x, float y)
	{
		//IL_010d: Expected I, but got O
		//IL_0229: Expected I, but got O
		//IL_0320: Expected I, but got O
		//IL_0376: Expected O, but got I4
		//IL_03a0: Expected O, but got I4
		//IL_04b8: Expected I, but got O
		//IL_050e: Expected O, but got I4
		//IL_051c: Expected O, but got I4
		//IL_0546: Expected O, but got I4
		PhaserSprite highlight = _highlight;
		Vector2 vector = default(Vector2);
		if ((object)_highlight == null || ((UnityEngine.Object)highlight).m_CachedPtr == (IntPtr)0)
		{
			PhaserWorld instance = PhaserWorld.Instance;
			PhaserSprite phaserSprite = instance.AddPhaserSprite(vector, "vfx", "sPFX_ring_64");
			PhaserSprite phaserSprite2 = phaserSprite.setVisible(visible: false);
			PhaserSprite phaserSprite3 = phaserSprite2.setBlendMode(BlendMode.Add);
			PhaserSprite phaserSprite4 = phaserSprite3.setTint(16711680u);
			if ((object)GM.Core == null)
			{
				goto IL_05b8;
			}
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			PhaserSprite highlight2 = phaserSprite4.setDepth(renderer.pixelHeight);
			_highlight = highlight2;
			Vector2 vector2 = vector;
			nint num = unchecked((nint)"sPFX_ring_64");
		}
		PhaserSprite rainbow = _rainbow;
		if ((object)_rainbow == null || ((UnityEngine.Object)rainbow).m_CachedPtr == (IntPtr)0)
		{
			PhaserWorld instance2 = PhaserWorld.Instance;
			PhaserSprite phaserSprite5 = instance2.AddPhaserSprite(vector, "vfx", "s_pfx_rainbow_64");
			PhaserSprite phaserSprite6 = phaserSprite5.setVisible(visible: false);
			PhaserSprite phaserSprite7 = phaserSprite6.setBlendMode(BlendMode.Add);
			PhaserSprite phaserSprite8 = phaserSprite7.setTint(16711935u);
			if ((object)GM.Core == null)
			{
				goto IL_05b8;
			}
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer2 = s_scene2._renderer;
			PhaserSprite rainbow2 = phaserSprite8.setDepth(renderer2.pixelHeight);
			_rainbow = rainbow2;
			Vector2 vector2 = vector;
			nint num = unchecked((nint)"s_pfx_rainbow_64");
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
			PhaserSprite phaserSprite9 = RenderingExtensions.SetScale(_highlight, 0f);
			PhaserSprite phaserSprite10 = _highlight.setAlpha(0f);
			Transform transform = _highlight.transform;
			object obj3 = default(object);
			transform.localEulerAngles = (Vector3)(&obj3);
			PhaserSprite phaserSprite11 = _highlight.setVisible(visible: true);
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
				PhaserSprite phaserSprite9 = _highlight.setVisible(visible: false);
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
			PhaserSprite phaserSprite9 = RenderingExtensions.SetScale(_rainbow, 0f);
			PhaserSprite phaserSprite10 = _rainbow.setAlpha(0f);
			Transform transform = _rainbow.transform;
			object obj3 = default(object);
			transform.localEulerAngles = (Vector3)(&obj3);
			PhaserSprite phaserSprite11 = _rainbow.setVisible(visible: true);
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
				PhaserSprite phaserSprite9 = _rainbow.setVisible(visible: false);
			};
			tweenConfig3.onComplete = onComplete3;
			MultiTargetTween rainbowTween2 = Tweens.Add(tweenConfig3);
			_rainbowTween2 = rainbowTween2;
		};
		tweenConfig2.onComplete = onComplete2;
		MultiTargetTween rainbowTween = Tweens.Add(tweenConfig2);
		_rainbowTween = rainbowTween;
		return;
		IL_05b8:
		throw new NullReferenceException();
	}

	private void AddMaxHPBonus(int value)
	{
		if (CurrentMaxHPBonus < MaxHealthMaxBonus)
		{
			int num = MaxHealthMaxBonus - CurrentMaxHPBonus;
			if (value <= num)
			{
				num = value;
			}
			PlayerModifierStats playerStats = _playerStats;
			int currentMaxHPBonus = CurrentMaxHPBonus + num;
			CurrentMaxHPBonus = currentMaxHPBonus;
			EggFloat eggFloat = playerStats._003CMaxHp_003Ek__BackingField;
			float value2 = default(float);
			EggFloat eggFloat2 = new EggFloat(value2, eggFloat._eggVal);
			value2 = (float)num + eggFloat._val;
			playerStats._003CMaxHp_003Ek__BackingField = eggFloat2;
		}
	}

	private unsafe void _003CShowHighlightAt_003Eb__11_0()
	{
		//IL_0058: Expected O, but got Ref
		PhaserSprite phaserSprite = RenderingExtensions.SetScale(_highlight, 0f);
		PhaserSprite phaserSprite2 = _highlight.setAlpha(0f);
		Transform transform = _highlight.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
		PhaserSprite phaserSprite3 = _highlight.setVisible(visible: true);
	}

	private void _003CShowHighlightAt_003Eb__11_1()
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

	private void _003CShowHighlightAt_003Eb__11_2()
	{
		PhaserSprite phaserSprite = _highlight.setVisible(visible: false);
	}

	private unsafe void _003CShowHighlightAt_003Eb__11_3()
	{
		//IL_0058: Expected O, but got Ref
		PhaserSprite phaserSprite = RenderingExtensions.SetScale(_rainbow, 0f);
		PhaserSprite phaserSprite2 = _rainbow.setAlpha(0f);
		Transform transform = _rainbow.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
		PhaserSprite phaserSprite3 = _rainbow.setVisible(visible: true);
	}

	private void _003CShowHighlightAt_003Eb__11_4()
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

	private void _003CShowHighlightAt_003Eb__11_5()
	{
		PhaserSprite phaserSprite = _rainbow.setVisible(visible: false);
	}
}
