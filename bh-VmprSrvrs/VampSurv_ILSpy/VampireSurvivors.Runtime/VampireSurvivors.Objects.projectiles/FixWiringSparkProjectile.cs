using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class FixWiringSparkProjectile : Projectile
{
	private PhaserSprite _pulseSprite;

	private FixWiringWeapon _trueWeapon;

	private MultiTargetTween _pulseTween;

	private Timer _pulseTimer;

	private bool _follow;

	private float radius = 24f;

	protected override void Awake()
	{
		base.Awake();
		_isCullable = false;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_001d: Expected I, but got O
		//IL_0025: Expected I, but got O
		//IL_0035: Expected O, but got I
		//IL_00b5: Expected O, but got I4
		//IL_0071: Expected O, but got I
		//IL_00e2: Expected O, but got I4
		//IL_00e2: Expected O, but got I4
		//IL_00a7: Expected O, but got I4
		//IL_0178: Expected I4, but got O
		//IL_01f1: Expected I4, but got O
		//IL_02bb: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		Weapon trueWeapon;
		if ((object)weapon == null)
		{
			trueWeapon = null;
			goto IL_0317;
		}
		nint num = (nint)typeof(FixWiringWeapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v23 (Il2CppClass<VampireSurvivors.Objects.Weapons.FixWiringWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r8_v25 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v23 (Il2CppClass<VampireSurvivors.Objects.Weapons.FixWiringWeapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r8_v25 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rax_v57+FFFFFFF8+v71 @ rax_v52*8]");
			if (0 == (nint)typeof(FixWiringWeapon))
			{
				obj3 = 1;
				goto IL_0326;
			}
		}
		obj3 = 0;
		goto IL_0326;
		IL_0326:
		bool flag = obj3 == null;
		trueWeapon = null;
		if (!flag)
		{
			trueWeapon = weapon;
		}
		goto IL_0317;
		IL_0317:
		_trueWeapon = (FixWiringWeapon)trueWeapon;
		BaseBody baseBody = body.setCircle(10f, (float?)(object)1, (float?)(object)1);
		BaseBody baseBody2 = body;
		baseBody2._enable = false;
		_isCullable = false;
		Vector2 vector = default(Vector2);
		string text = default(string);
		int num4 = default(int);
		bool flag2 = default(bool);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("Electricity_", 1, 4, vector, text, num4, flag2);
		PhaserSprite pulseSprite = _pulseSprite;
		bool shouldLoop;
		if ((object)_pulseSprite != null)
		{
			bool flag3 = ((UnityEngine.Object)pulseSprite).m_CachedPtr != (IntPtr)0;
			shouldLoop = (byte)(int)text != 0;
			if (flag3)
			{
				goto IL_0280;
			}
		}
		PhaserWorld instance = PhaserWorld.Instance;
		PhaserSprite component = instance.AddPhaserSprite(vector, "vfx", "Electricity_01");
		PhaserSprite phaserSprite = RenderingExtensions.SetScrollFactor(component, 0f);
		if ((object)GM.Core != null)
		{
			shouldLoop = (byte)(int)text != 0;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			PhaserSprite phaserSprite2 = phaserSprite.setDepth(renderer.pixelHeight);
			PhaserSprite phaserSprite3 = phaserSprite2.setTint(16777215u);
			PhaserSprite phaserSprite4 = phaserSprite3.setVisible(visible: false);
			GameObject gameObject = phaserSprite4.gameObject;
			((UnityEngine.Object)gameObject).SetName("FixWiringSparkProjectile - PulseSprite");
			_pulseSprite = phaserSprite4;
			goto IL_0280;
		}
		throw new NullReferenceException();
		IL_0280:
		PhaserSprite pulseSprite2 = _pulseSprite;
		bool autoSetAnimation = default(bool);
		pulseSprite2._spriteAnimation.AddAnimation("idle", animationFrames, 20, shouldLoop, (byte)num4 != 0, (Action)flag2, autoSetAnimation);
		PhaserSprite pulseSprite3 = _pulseSprite;
		pulseSprite3._spriteAnimation.SetAnimation("idle");
	}

	public override void Despawn()
	{
		if (_pulseTimer != null)
		{
			_pulseTimer.Cancel();
		}
		if (_pulseTween != null)
		{
			_pulseTween.Kill();
		}
		PhaserSprite phaserSprite = _pulseSprite.setVisible(visible: false);
		BaseBody baseBody = body;
		baseBody._enable = false;
		_follow = false;
		base.Despawn();
	}

	public unsafe void Pulse(float2 from, float2 to, uint color, float speedMultiplier = 1f)
	{
		//IL_000d: Expected I, but got O
		//IL_00c8: Expected O, but got I4
		//IL_00c8: Expected O, but got I4
		//IL_018e: Expected O, but got Ref
		//IL_0227: Expected I, but got O
		//IL_0291: Expected O, but got I4
		//IL_02ba: Expected O, but got I4
		//IL_01fb->IL0383: Incompatible stack heights: 1 vs 0
		//IL_026c->IL0383: Incompatible stack heights: 1 vs 0
		//IL_024a->IL024a: Incompatible stack heights: 2 vs 1
		//IL_031d->IL0383: Incompatible stack heights: 1 vs 0
		//IL_0364->IL0383: Incompatible stack heights: 1 vs 0
		FixWiringWeapon trueWeapon = _trueWeapon;
		if ((object)_trueWeapon != null)
		{
			nint num = (nint)trueWeapon;
			float num2 = _trueWeapon.PSpeed();
			object obj2 = default(object);
			object obj3 = default(object);
			object obj = obj2 * obj3;
			float num3 = 2000f / (float)obj;
			bool flag = 500f > num3;
			float duration = 500f;
			if (!flag)
			{
				duration = num3;
			}
			object obj4 = to - from;
			object obj5 = default(object);
			object obj6 = default(object);
			float num4 = (float)obj5 - (float)obj6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
			if ((object)_trueWeapon != null)
			{
				float num5 = _trueWeapon.PArea();
				bool flag2 = num4 > 10f;
				float num6 = 10f;
				if (!flag2)
				{
					num6 = num4;
				}
				float num7 = num6 * radius;
				if (body != null)
				{
					BaseBody baseBody = body.setCircle(num7, (float?)(object)1, (float?)(object)1);
					if ((object)_pulseSprite != null)
					{
						PhaserSprite phaserSprite = _pulseSprite.setPosition(from);
						if ((object)_pulseSprite != null)
						{
							PhaserSprite phaserSprite2 = _pulseSprite.setVisible(visible: true);
							if ((object)_pulseSprite != null)
							{
								Transform transform = _pulseSprite.transform;
								if ((object)transform != null)
								{
									float? ret = default(float?);
									transform.localEulerAngles = (Vector3)(&ret);
									if ((object)_mainCamera != null)
									{
										Transform transform2 = _mainCamera.transform;
										if ((object)transform2 != null)
										{
											bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
											Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out *(Vector3*)(&ret));
											TweenConfig tweenConfig = new TweenConfig();
											object[] array = new object[1];
											if (array != null)
											{
												if ((object)_pulseSprite != null)
												{
													nint num8 = (nint)array;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
													object obj7 = default(object);
													bool flag4 = obj7 == null;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
												if (tweenConfig != null)
												{
													tweenConfig.targets = array;
													tweenConfig.localX = (float?)(object)1;
													tweenConfig.duration = duration;
													tweenConfig.ease = Ease.InOutSine;
													tweenConfig.localY = (float?)(object)1;
													TweenCallback onComplete = delegate
													{
														Despawn();
													};
													tweenConfig.onComplete = onComplete;
													MultiTargetTween pulseTween = Tweens.Add(tweenConfig);
													_pulseTween = pulseTween;
													if ((object)_pulseSprite != null)
													{
														float2 float5 = _pulseSprite.position;
														base.position = float5;
														BaseBody baseBody2 = body;
														if (body != null)
														{
															baseBody2._enable = true;
															_follow = true;
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

	protected override void OnUpdate()
	{
		if (_follow)
		{
			float2 float5 = _pulseSprite.position;
			base.position = float5;
		}
	}

	private void ClearLine()
	{
		if (_pulseTimer != null)
		{
			_pulseTimer.Cancel();
		}
		if (_pulseTween != null)
		{
			_pulseTween.Kill();
		}
		PhaserSprite phaserSprite = _pulseSprite.setVisible(visible: false);
		BaseBody baseBody = body;
		baseBody._enable = false;
		_follow = false;
	}

	private void _003CPulse_003Eb__9_0()
	{
		Despawn();
	}
}
