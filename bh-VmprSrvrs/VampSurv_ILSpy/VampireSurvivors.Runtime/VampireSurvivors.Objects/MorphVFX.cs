using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects;

public class MorphVFX
{
	private PhaserSprite _sparkSprite;

	private PhaserSprite _ringSprite;

	private MultiTargetTween _ringTween;

	private MultiTargetTween _sparkTween;

	private PhaserSprite _burstSprite;

	private PhaserSprite _darkSprite;

	private MultiTargetTween _darkTween;

	private float _x;

	private float _y;

	public uint[] _burstTint = new uint[4] { 65280u, 255u, 16776960u, 16711680u };

	public string _sparkName = "blurredSharpStar";

	public string _diskName = "disc";

	public void Make()
	{
		//IL_0112: Expected O, but got I4
		//IL_0223: Expected O, but got I4
		//IL_0333: Expected O, but got I4
		//IL_03a6: Expected O, but got I4
		//IL_0530: Expected O, but got I4
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float x = renderer.width * 0.5f;
		_x = x;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		PhaserSprite sparkSprite = _sparkSprite;
		float y = renderer2.height * 0.5f;
		_y = y;
		Vector2 pos = default(Vector2);
		if ((object)_sparkSprite == null || ((UnityEngine.Object)sparkSprite).m_CachedPtr == (IntPtr)0)
		{
			PhaserWorld instance = PhaserWorld.Instance;
			PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "vfx", _sparkName);
			PhaserSprite phaserSprite2 = phaserSprite.setAlpha(0f);
			PhaserSprite phaserSprite3 = phaserSprite2.setScale(0f, (float?)(object)0);
			PhaserSprite phaserSprite4 = phaserSprite3.setBlendMode(BlendMode.Add);
			if ((object)GM.Core == null)
			{
				goto IL_0679;
			}
			PhaserScene s_scene3 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer3 = s_scene3._renderer;
			PhaserSprite sparkSprite2 = phaserSprite4.setDepth(renderer3.height);
			_sparkSprite = sparkSprite2;
		}
		PhaserSprite ringSprite = _ringSprite;
		if ((object)_ringSprite == null || ((UnityEngine.Object)ringSprite).m_CachedPtr == (IntPtr)0)
		{
			PhaserWorld instance2 = PhaserWorld.Instance;
			PhaserSprite phaserSprite5 = instance2.AddPhaserSprite(pos, "vfx", _diskName);
			PhaserSprite phaserSprite6 = phaserSprite5.setAlpha(0f);
			PhaserSprite phaserSprite7 = phaserSprite6.setScale(0f, (float?)(object)0);
			PhaserSprite phaserSprite8 = phaserSprite7.setBlendMode(BlendMode.Add);
			if ((object)GM.Core == null)
			{
				goto IL_0679;
			}
			PhaserScene s_scene4 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer4 = s_scene4._renderer;
			PhaserSprite ringSprite2 = phaserSprite8.setDepth(renderer4.height);
			_ringSprite = ringSprite2;
		}
		PhaserSprite darkSprite = _darkSprite;
		if ((object)_darkSprite != null && ((UnityEngine.Object)darkSprite).m_CachedPtr != (IntPtr)0)
		{
			goto IL_0430;
		}
		PhaserWorld instance3 = PhaserWorld.Instance;
		PhaserSprite phaserSprite9 = instance3.AddPhaserSprite(pos, "vfx", "blackDot");
		PhaserSprite phaserSprite10 = phaserSprite9.setAlpha(0f);
		PhaserSprite phaserSprite11 = phaserSprite10.setOrigin(0.5f, (float?)(object)0);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene5 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer5 = s_scene5._renderer;
			if ((object)GM.Core != null)
			{
				PhaserSprite phaserSprite12 = phaserSprite11.setScale(renderer5.width, (float?)(object)1);
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene6 = ArcadePhysics.s_scene;
					PhaserScene.Renderer renderer6 = s_scene6._renderer;
					float depth = renderer6.height - 1f;
					PhaserSprite component = phaserSprite12.setDepth(depth);
					PhaserSprite darkSprite2 = RenderingExtensions.SetScrollFactor(component, 0f);
					_darkSprite = darkSprite2;
					goto IL_0430;
				}
			}
		}
		goto IL_0679;
		IL_061c:
		bool flag = default(bool);
		List<Sprite> animation = SpriteManager.GetAnimation("Burst", 1, 6, "vfx", flag);
		PhaserSprite burstSprite = _burstSprite;
		bool flag2 = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		burstSprite._spriteAnimation.AddAnimation("Enter", animation, 30, flag, flag2, onComplete, autoSetAnimation);
		return;
		IL_0679:
		throw new NullReferenceException();
		IL_0430:
		PhaserSprite burstSprite2 = _burstSprite;
		if ((object)_burstSprite == null || ((UnityEngine.Object)burstSprite2).m_CachedPtr == (IntPtr)0)
		{
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene7 = ArcadePhysics.s_scene;
				if ((object)GM.Core != null && (object)GM.Core != null)
				{
					PhaserSprite phaserSprite13 = RenderingExtensions.sprite(s_scene7.add, pos, "vfx", "Burst1.png");
					PhaserSprite phaserSprite14 = phaserSprite13.setAlpha(0f);
					PhaserSprite phaserSprite15 = phaserSprite14.setScale(10f, (float?)(object)0);
					PhaserSprite phaserSprite16 = phaserSprite15.setBlendMode(BlendMode.Add);
					if ((object)GM.Core != null)
					{
						PhaserScene s_scene8 = ArcadePhysics.s_scene;
						PhaserScene.Renderer renderer7 = s_scene8._renderer;
						PhaserSprite component2 = phaserSprite16.setDepth(renderer7.height);
						PhaserSprite phaserSprite17 = RenderingExtensions.SetScrollFactor(component2, 0f);
						uint[] burstTint = _burstTint;
						PhaserSprite burstSprite3 = phaserSprite17.setTint(burstTint[0], burstTint[1], burstTint[2], flag ? 1u : 0u, flag2 ? BlendMode.Add : BlendMode.Normal);
						_burstSprite = burstSprite3;
						flag = flag;
						goto IL_061c;
					}
				}
			}
			goto IL_0679;
		}
		goto IL_061c;
	}

	public unsafe void PlaySparkle(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_006f: Expected F4, but got O
		//IL_0121: Expected I, but got O
		//IL_0185: Expected O, but got I4
		//IL_0193: Expected O, but got I4
		//IL_01a1: Expected O, but got I4
		//IL_0262: Expected I, but got O
		//IL_02d4: Expected O, but got I4
		//IL_0395: Expected I, but got O
		//IL_03eb: Expected O, but got I4
		//IL_03f9: Expected O, but got I4
		//IL_0407: Expected O, but got I4
		//IL_0423: Expected O, but got I4
		PhaserSprite burstSprite = _burstSprite;
		burstSprite._spriteAnimation.SetAnimation("Enter");
		PhaserSprite burstSprite2 = _burstSprite;
		burstSprite2._spriteAnimation.SetAnimation("Enter");
		PhaserSprite phaserSprite = _burstSprite.setAlpha(1f);
		float2 position = character.position;
		_x = (float)position;
		float2 position2 = character.position;
		float y = default(float);
		_y = y;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		if (_ringTween != null)
		{
			_ringTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_ringSprite != null)
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
		tweenConfig.scaleX = (float?)(object)1;
		tweenConfig.scaleY = (float?)(object)1;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			//IL_0015: Expected O, but got I4
			PhaserSprite phaserSprite2 = _ringSprite.setScale(0f, (float?)(object)0);
			PhaserSprite phaserSprite3 = _ringSprite.setAlpha(1f);
		};
		tweenConfig.onStart = onStart;
		MultiTargetTween ringTween = Tweens.Add(tweenConfig);
		_ringTween = ringTween;
		if (_darkTween != null)
		{
			_darkTween.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		if ((object)_darkSprite != null)
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
		tweenConfig2.duration = 100f;
		tweenConfig2.yoyo = true;
		tweenConfig2.alpha = (float?)(object)1;
		TweenCallback onStart2 = delegate
		{
			PhaserSprite phaserSprite2 = _darkSprite.setAlpha(0f);
		};
		tweenConfig2.onStart = onStart2;
		MultiTargetTween darkTween = Tweens.Add(tweenConfig2);
		_darkTween = darkTween;
		if (_sparkTween != null)
		{
			_sparkTween.Kill();
		}
		TweenConfig tweenConfig3 = new TweenConfig();
		object[] array3 = new object[1];
		if ((object)_sparkSprite != null)
		{
			nint num3 = (nint)array3;
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
		tweenConfig3.scaleX = (float?)(object)1;
		tweenConfig3.scaleY = (float?)(object)1;
		tweenConfig3.alpha = (float?)(object)1;
		tweenConfig3.duration = 200f;
		tweenConfig3.angle = (float?)(object)1;
		TweenCallback onStart3 = delegate
		{
			//IL_001a: Expected O, but got I4
			//IL_005d: Expected O, but got Ref
			PhaserSprite phaserSprite2 = _sparkSprite.setScale(0f, (float?)(object)0);
			PhaserSprite phaserSprite3 = _sparkSprite.setAlpha(1f);
			Transform transform = _sparkSprite.transform;
			object obj4 = default(object);
			transform.localEulerAngles = (Vector3)(&obj4);
		};
		tweenConfig3.onStart = onStart3;
		TweenCallback onUpdate = delegate
		{
			float2 position3 = default(float2);
			PhaserSprite phaserSprite2 = _sparkSprite.setPosition(position3);
			PhaserSprite phaserSprite3 = _ringSprite.setPosition(position3);
		};
		tweenConfig3.onUpdate = onUpdate;
		TweenCallback onComplete = delegate
		{
			PhaserSprite phaserSprite2 = _ringSprite.setAlpha(0f);
			PhaserSprite phaserSprite3 = _sparkSprite.setAlpha(0f);
		};
		tweenConfig3.onComplete = onComplete;
		MultiTargetTween sparkTween = Tweens.Add(tweenConfig3);
		_sparkTween = sparkTween;
	}

	private void _003CPlaySparkle_003Eb__13_0()
	{
		//IL_0015: Expected O, but got I4
		PhaserSprite phaserSprite = _ringSprite.setScale(0f, (float?)(object)0);
		PhaserSprite phaserSprite2 = _ringSprite.setAlpha(1f);
	}

	private void _003CPlaySparkle_003Eb__13_1()
	{
		PhaserSprite phaserSprite = _darkSprite.setAlpha(0f);
	}

	private unsafe void _003CPlaySparkle_003Eb__13_2()
	{
		//IL_001a: Expected O, but got I4
		//IL_005d: Expected O, but got Ref
		PhaserSprite phaserSprite = _sparkSprite.setScale(0f, (float?)(object)0);
		PhaserSprite phaserSprite2 = _sparkSprite.setAlpha(1f);
		Transform transform = _sparkSprite.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
	}

	private void _003CPlaySparkle_003Eb__13_3()
	{
		float2 position = default(float2);
		PhaserSprite phaserSprite = _sparkSprite.setPosition(position);
		PhaserSprite phaserSprite2 = _ringSprite.setPosition(position);
	}

	private void _003CPlaySparkle_003Eb__13_4()
	{
		PhaserSprite phaserSprite = _ringSprite.setAlpha(0f);
		PhaserSprite phaserSprite2 = _sparkSprite.setAlpha(0f);
	}
}
