using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class CharacterControllerSpaceDude : CharacterController
{
	private float _paradoxHazeDelay = 10000f;

	private float _paradoxHazeTime;

	private Timer _activationTimer;

	private PhaserSprite _highlight;

	private PhaserSprite _rainbow;

	private MultiTargetTween _highlightTween;

	private MultiTargetTween _rainbowTween;

	private MultiTargetTween _highlightTween2;

	private MultiTargetTween _rainbowTween2;

	public float ParadoxHazeInterval()
	{
		float num = base.PCooldownFinal(0.3f);
		object obj = default(object);
		return (float)obj * _paradoxHazeDelay;
	}

	public override void OnWeaponFired(Weapon weapon)
	{
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected O, but got Unknown
		//IL_00cc: Invalid comparison between F4 and O
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		if (arcanaManager._003CActiveArcanas_003Ek__BackingField != null)
		{
			GameManager core2 = GM.Core;
			ArcanaManager arcanaManager2 = core2._arcanaManager;
			List<ArcanaType> list = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rcx_v13 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			if ((nint)0 > (nint)0)
			{
				GameManager core3 = GM.Core;
				core3._arcanaManager.OnWeaponFired(weapon);
			}
		}
		float num = base.PCooldownFinal(0.3f);
		object obj2 = default(object);
		object obj = obj2 * _paradoxHazeDelay;
		float paradoxHazeTime = _paradoxHazeTime;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)paradoxHazeTime) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
		{
			_paradoxHazeTime = 0f;
			if (_activationTimer != null)
			{
				_activationTimer.Cancel();
			}
			Action onComplete = ActivateAllWeapons;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer activationTimer = Timers.Register(0.15f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_activationTimer = activationTimer;
		}
	}

	protected void ActivateAllWeapons()
	{
		//IL_01bb: Expected O, but got I4
		//IL_0013: Expected O, but got I4
		//IL_0135: Expected F4, but got O
		CharacterWeaponsManager weaponsManager = base._weaponsManager;
		List<Equipment>.Enumerator enumerator = default(List<Equipment>.Enumerator);
		while (enumerator.MoveNext())
		{
			object obj = 0;
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Clones, soundConfig, 200f, 4, time);
		float2 float5 = base.position;
		float2 float6 = base.position;
		ShowHighlightAt((float)float5, 0.65f);
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 1000f;
		float paradoxHazeTime = num + _paradoxHazeTime;
		_paradoxHazeTime = paradoxHazeTime;
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
			PhaserSprite phaserSprite4 = phaserSprite3.setTint(255u);
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
			PhaserSprite phaserSprite8 = phaserSprite7.setTint(52479u);
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
		tweenConfig.scaleY = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			//IL_005d: Expected O, but got Ref
			PhaserSprite phaserSprite9 = RenderingExtensions.SetScale(_highlight, 1f, 0f);
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
		tweenConfig2.scaleY = (float?)(object)1;
		tweenConfig2.duration = 300f;
		tweenConfig2.ease = Ease.OutSine;
		tweenConfig2.angle = (float?)(object)1;
		TweenCallback onStart2 = delegate
		{
			//IL_005d: Expected O, but got Ref
			PhaserSprite phaserSprite9 = RenderingExtensions.SetScale(_rainbow, 1f, 0f);
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

	private unsafe void _003CShowHighlightAt_003Eb__13_0()
	{
		//IL_005d: Expected O, but got Ref
		PhaserSprite phaserSprite = RenderingExtensions.SetScale(_highlight, 1f, 0f);
		PhaserSprite phaserSprite2 = _highlight.setAlpha(0f);
		Transform transform = _highlight.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
		PhaserSprite phaserSprite3 = _highlight.setVisible(visible: true);
	}

	private void _003CShowHighlightAt_003Eb__13_1()
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

	private void _003CShowHighlightAt_003Eb__13_2()
	{
		PhaserSprite phaserSprite = _highlight.setVisible(visible: false);
	}

	private unsafe void _003CShowHighlightAt_003Eb__13_3()
	{
		//IL_005d: Expected O, but got Ref
		PhaserSprite phaserSprite = RenderingExtensions.SetScale(_rainbow, 1f, 0f);
		PhaserSprite phaserSprite2 = _rainbow.setAlpha(0f);
		Transform transform = _rainbow.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
		PhaserSprite phaserSprite3 = _rainbow.setVisible(visible: true);
	}

	private void _003CShowHighlightAt_003Eb__13_4()
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

	private void _003CShowHighlightAt_003Eb__13_5()
	{
		PhaserSprite phaserSprite = _rainbow.setVisible(visible: false);
	}
}
