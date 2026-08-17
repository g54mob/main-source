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
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Heads_Projectile : Projectile
{
	private float _radius = 12f;

	private PhaserSprite _animatedSprite;

	private Tween _radiusTween;

	private Timer _expireTimer;

	private Timer _hitBoxTimer;

	private MultiTargetTween _scaleTween;

	private bool _isDespawning;

	private float hDirection;

	private bool canTurnAround;

	private Timer turnAroundTimer;

	private Transform _cachedCameraTransform;

	private float angleTime;

	private Vector3 _center;

	protected override void Awake()
	{
		//IL_00d8: Expected O, but got I4
		//IL_00d8: Expected I4, but got O
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		GameObject gameObject = base.gameObject;
		Vector2 vector = default(Vector2);
		PhaserSprite animatedSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "ThosePeople", "TP_VFX_Head01");
		_animatedSprite = animatedSprite;
		string text = default(string);
		int num = default(int);
		bool flag = default(bool);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_Head", 1, 4, vector, text, num, flag);
		PhaserSprite animatedSprite2 = _animatedSprite;
		bool autoSetAnimation = default(bool);
		animatedSprite2._spriteAnimation.AddAnimation("loop", animationFrames, 8, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		PhaserSprite animatedSprite3 = _animatedSprite;
		animatedSprite3._spriteAnimation.SetAnimation("loop");
		Camera main = Camera.main;
		Transform cachedCameraTransform = main.transform;
		_cachedCameraTransform = cachedCameraTransform;
		ArcadeSprite arcadeSprite = setDepth(1);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_03f9: Expected O, but got I4
		//IL_004c: Invalid comparison between I4 and F4
		//IL_006c: Expected F4, but got I4
		//IL_008d: Expected O, but got I4
		//IL_008d: Expected O, but got I4
		//IL_00b0: Expected O, but got I4
		//IL_0466: Expected F4, but got I4
		//IL_050f: Expected O, but got F4
		//IL_0346: Expected I4, but got I8
		//IL_04d6: Expected O, but got F4
		//IL_039b: Expected F4, but got I4
		//IL_0167->IL03a0: Incompatible stack heights: 1 vs 0
		//IL_022b->IL03a0: Incompatible stack heights: 1 vs 0
		//IL_02d8->IL03a0: Incompatible stack heights: 1 vs 0
		//IL_02fa->IL03a0: Incompatible stack heights: 1 vs 0
		//IL_054a->IL03a0: Incompatible stack heights: 1 vs 0
		//IL_0370->IL03a0: Incompatible stack heights: 1 vs 0
		base.InitProjectile(pool, weapon, index);
		_isDespawning = false;
		_isCullable = false;
		canTurnAround = false;
		ArcadeSprite arcadeSprite = setDepth(1);
		ArcadeSprite arcadeSprite2 = setScale(1f, (float?)(object)0);
		if ((object)_weapon != null)
		{
			float num = _weapon.PArea();
			object obj = default(object);
			float num2 = (float)obj - 1f;
			if (0f > num2)
			{
				num2 = 0f;
			}
			if (body != null)
			{
				BaseBody baseBody = body.setCircle(_radius, (float?)(object)1, (float?)(object)1);
				float xScale = num2 + 1f;
				ArcadeSprite arcadeSprite3 = setScale(xScale, (float?)(object)0);
				if ((object)_animatedSprite != null)
				{
					Transform transform = _animatedSprite.transform;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v383 @ rax_v30 (UnityEngine.Transform)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v383 @ rax_v30 (UnityEngine.Transform)+10]");
					Vector3 value = default(Vector3);
					Transform.set_localPosition_Injected((IntPtr)0, ref value);
					PhaserSprite phaserSprite = _animatedSprite.setAlpha(1f);
					PhaserSprite phaserSprite2 = _animatedSprite.setVisible(visible: true);
					if (_expireTimer != null)
					{
						_expireTimer.Cancel();
					}
					if ((object)_weapon != null)
					{
						float num3 = _weapon.PDuration();
						Action onComplete = StartDespawn;
						float duration = (float)Vector3.zeroVector * 0.001f;
						bool flag2 = default(bool);
						MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
						int repeat = default(int);
						TimerType type = default(TimerType);
						Timer expireTimer = Timers.Register(duration, onComplete, null, isLooped: true, flag2, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
						_expireTimer = expireTimer;
						if (_hitBoxTimer != null)
						{
							_hitBoxTimer.Cancel();
						}
						if ((object)_weapon != null)
						{
							float hitBoxDelay = _weapon.HitBoxDelay;
							Action onComplete2 = delegate
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
							};
							float duration2 = hitBoxDelay * 0.001f;
							Timer hitBoxTimer = Timers.Register(duration2, onComplete2, null, isLooped: true, flag2, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
							_hitBoxTimer = hitBoxTimer;
							float2 float5 = base.position;
							Weapon weapon2 = _weapon;
							if ((object)_weapon != null && (object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
							{
								float2 float6 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.position;
								bool flag3 = (byte)(float5 <= float6) != 0;
								int num4 = 1;
								if (!flag3)
								{
									num4 = -1;
								}
								hDirection = num4;
								object obj2 = UnityEngine.Random.value;
								float num5 = (float)num4 * (float)Math.PI;
								angleTime = num5;
								Camera main = Camera.main;
								if ((object)main != null)
								{
									Transform transform2 = main.transform;
									if ((object)transform2 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rax_v60 (UnityEngine.Transform)+10]");
										bool flag4 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rax_v60 (UnityEngine.Transform)+10]");
										Transform.get_position_Injected((IntPtr)0, out value);
										_center = value;
										_ = 0;
										SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
										{
											Rate = 1.5f
										};
										object obj3 = UnityEngine.Random.value;
										float num6 = (float)value - 0.5f;
										float num7 = num6 * 500f;
										_ = 1;
										PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Javelin, soundConfig, 200f, 10, flag2 ? 1 : 0);
										return;
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

	private void StartDespawn()
	{
		//IL_0069: Expected I, but got O
		//IL_00cd: Expected O, but got I4
		//IL_00e8: Expected I, but got O
		if (!_isDespawning)
		{
			_isDespawning = true;
			if (_scaleTween != null)
			{
				_scaleTween.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 200f;
			tweenConfig.scale = (float?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Heads_Projectile>)+370]");
			TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
		}
	}

	public override void Despawn()
	{
		if (turnAroundTimer != null)
		{
			turnAroundTimer.Cancel();
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_radiusTween != null)
		{
			TweenExtensions.Kill(_radiusTween);
		}
		if (_hitBoxTimer != null)
		{
			_hitBoxTimer.Cancel();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		PhaserSprite phaserSprite = _animatedSprite.setVisible(visible: false);
		base.Despawn();
	}

	private void TurnAround()
	{
		//IL_00ed->IL008b: Incompatible stack heights: 1 vs 0
		if (!canTurnAround)
		{
			return;
		}
		canTurnAround = false;
		Camera main = Camera.main;
		if ((object)main != null)
		{
			Transform transform = main.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				_center = ret;
				float num = hDirection * -1f;
				_ = 0;
				hDirection = num;
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void LateUpdate()
	{
		//IL_04c0: Invalid comparison between F4 and O
		//IL_01a9: Invalid comparison between O and F4
		//IL_05b6: Expected I, but got O
		//IL_02bb: Expected O, but got F4
		//IL_040b->IL038b: Incompatible stack heights: 1 vs 0
		//IL_0432->IL038b: Incompatible stack heights: 1 vs 0
		//IL_0068->IL038b: Incompatible stack heights: 1 vs 0
		//IL_0482->IL038b: Incompatible stack heights: 2 vs 0
		//IL_04a9->IL038b: Incompatible stack heights: 2 vs 0
		//IL_00ca->IL038b: Incompatible stack heights: 2 vs 0
		//IL_0117->IL038b: Incompatible stack heights: 2 vs 0
		//IL_054b->IL038b: Incompatible stack heights: 2 vs 0
		//IL_020c->IL038b: Incompatible stack heights: 2 vs 0
		//IL_05f5->IL038b: Incompatible stack heights: 2 vs 0
		//IL_02a9->IL038b: Incompatible stack heights: 2 vs 0
		//IL_0236->IL038b: Incompatible stack heights: 2 vs 0
		//IL_0308->IL038b: Incompatible stack heights: 2 vs 0
		//IL_0327->IL038b: Incompatible stack heights: 2 vs 0
		//IL_05b1->IL04d4: Incompatible stack heights: 3 vs 2
		float2 float5 = base.position;
		Camera main = Camera.main;
		Vector3 ret;
		float num2;
		float num4;
		if ((object)main != null)
		{
			Transform transform = main.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out ret);
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene = ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene != null)
					{
						PhaserScene.Renderer renderer = s_scene._renderer;
						if (s_scene._renderer != null)
						{
							float num = renderer.width * 0.5f;
							num2 = (float)ret - num;
							bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret2);
							if ((object)GM.Core != null)
							{
								PhaserScene s_scene2 = ArcadePhysics.s_scene;
								if (ArcadePhysics.s_scene != null)
								{
									PhaserScene.Renderer renderer2 = s_scene2._renderer;
									if (s_scene2._renderer != null)
									{
										float num3 = renderer2.width * 0.5f;
										BaseBody baseBody = body;
										num4 = num3 + (float)ret2;
										if (body != null)
										{
											if ((nint)baseBody._velocity <= 0)
											{
												Vector3 center = _center;
												if (System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref center) > System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float5))
												{
													goto IL_0186;
												}
											}
											else
											{
												Vector3 center2 = _center;
												if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float5) > System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref center2))
												{
													goto IL_0186;
												}
											}
											goto IL_04ae;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_038b;
		IL_04ae:
		float2 float6 = base.position;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2) <= System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float6))
		{
			float2 float7 = base.position;
			if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float7) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num4))
			{
				goto IL_04d4;
			}
		}
		if (canTurnAround)
		{
			canTurnAround = false;
			Camera main2 = Camera.main;
			if ((object)main2 != null)
			{
				Transform transform2 = main2.transform;
				if ((object)transform2 != null)
				{
					bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
					_center = ret;
					float num5 = hDirection * -1f;
					_ = 0;
					hDirection = num5;
					goto IL_04d4;
				}
			}
			goto IL_038b;
		}
		goto IL_04d4;
		IL_038b:
		throw new NullReferenceException();
		IL_04d4:
		float deltaTime = PauseSystem.DeltaTime;
		float num6 = deltaTime * 1000f;
		float projectileSpeed = base.ProjectileSpeed;
		float num7 = num6 * 0.001f;
		float num8 = deltaTime * num7;
		float num9 = num8 + angleTime;
		angleTime = num9;
		if ((object)_weapon != null)
		{
			float num10 = _weapon.PArea();
			float num11 = deltaTime * 0.5f;
			ArcadeSprite sprite = default(ArcadeSprite);
			float num13 = default(float);
			if (!(2.28f > num11))
			{
				nint num12 = (nint)this;
				float projectileSpeed2 = base.ProjectileSpeed;
				sprite = _sprite;
				num13 = num11 * hDirection;
				if ((object)_sprite == null)
				{
					goto IL_038b;
				}
			}
			BaseBody baseBody2 = sprite.body;
			if (sprite.body != null)
			{
				baseBody2._velocity = (float2)num13;
				_ = 0;
				float2 float8 = base.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				float2 float9 = default(float2);
				base.position = float9;
				BaseBody baseBody3 = body;
				if (body != null && (object)_animatedSprite != null)
				{
					bool flag4 = (nint)baseBody3._velocity < 0;
					bool flag5 = (object)baseBody3._velocity == null;
					bool flag6 = !flag4;
					bool flag7 = !flag5;
					bool flag8 = flag7 & flag6;
					PhaserSprite phaserSprite = _animatedSprite.setFlipX(flag8);
					return;
				}
			}
		}
		goto IL_038b;
		IL_0186:
		canTurnAround = true;
		goto IL_04ae;
	}

	private void _003CInitProjectile_003Eb__14_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}
}
