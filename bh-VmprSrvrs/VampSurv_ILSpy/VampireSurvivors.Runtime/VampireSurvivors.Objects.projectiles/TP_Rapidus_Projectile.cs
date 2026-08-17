using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Rapidus_Projectile : Projectile
{
	protected Timer _expireTimer;

	protected MultiTargetTween _tween2;

	protected bool isDespawning;

	protected float currentBarrierScale;

	protected const float Radius = 16f;

	public SpriteAnimation _spriteAnimation;

	private Timer _hitboxTimer;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("aeroBubble1", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		bool flag = default(bool);
		List<Sprite> animation = SpriteManager.GetAnimation("aeroBubble", 1, 9, "vfx", flag);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_spriteAnimation.AddAnimation("idle", animation, 30, flag, startRandomFrame, onComplete, autoSetAnimation);
		_spriteAnimation.SetAnimation("idle");
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0012: Expected I4, but got O
		//IL_0078: Expected O, but got I
		//IL_0575: Expected I4, but got O
		//IL_00e7: Expected O, but got I
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Expected O, but got Unknown
		//IL_01ff: Expected O, but got I4
		//IL_01ff: Expected O, but got I4
		//IL_027b: Expected I, but got O
		//IL_0617: Expected I4, but got O
		//IL_046e: Expected O, but got I4
		//IL_049d: Expected F4, but got I4
		//IL_04bd: Expected O, but got I4
		//IL_04e7: Expected F4, but got I4
		//IL_0592->IL04f1: Incompatible stack heights: 1 vs 0
		//IL_00d1->IL04f1: Incompatible stack heights: 1 vs 0
		//IL_0103->IL04f1: Incompatible stack heights: 1 vs 0
		//IL_0606->IL04f1: Incompatible stack heights: 2 vs 0
		//IL_01ab->IL04f1: Incompatible stack heights: 2 vs 0
		//IL_01cd->IL04f1: Incompatible stack heights: 2 vs 0
		//IL_024c->IL04f1: Incompatible stack heights: 2 vs 0
		base.InitProjectile(pool, weapon, index);
		_isCullable = false;
		Rect ret;
		float2 float5 = default(float2);
		float2 float7;
		if ((object)weapon != null)
		{
			int num = (int)((Equipment)weapon)._003COwner_003Ek__BackingField;
			if ((object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
			{
				((ArcadeSprite)((Equipment)weapon)._003COwner_003Ek__BackingField).CheckRenderer();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdi_v13 (System.Int32)+48]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdi_v13 (System.Int32)+48]");
					Sprite sprite = ((SpriteRenderer)0).sprite;
					if ((object)sprite != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rax_v30 (UnityEngine.Sprite)+10]");
						bool flag = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rax_v30 (UnityEngine.Sprite)+10]");
						Sprite.get_rect_Injected((IntPtr)0, out ret);
						int num2 = (int)((Equipment)weapon)._003COwner_003Ek__BackingField;
						if ((object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
						{
							((ArcadeSprite)((Equipment)weapon)._003COwner_003Ek__BackingField).CheckRenderer();
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rdi_v15 (System.Int32)+48]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rdi_v15 (System.Int32)+48]");
								Sprite sprite2 = ((SpriteRenderer)0).sprite;
								if ((object)sprite2 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rax_v36 (UnityEngine.Sprite)+10]");
									bool flag2 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rax_v36 (UnityEngine.Sprite)+10]");
									Sprite.get_rect_Injected((IntPtr)0, out Rect _);
									float2 float6 = default(float2);
									if (float5 <= float6 != 0)
									{
										object obj = float5 & -2147483649L;
										bool flag3 = (nint)obj <= 2139095040;
										float7 = float6;
										if (flag3)
										{
											goto IL_05d2;
										}
									}
									float7 = float5;
									goto IL_05d2;
								}
							}
						}
					}
				}
			}
		}
		goto IL_04f1;
		IL_05d2:
		SpriteAnimation spriteAnimation = _spriteAnimation;
		float num3 = (float)float7 * (1f / 32f);
		if ((object)_spriteAnimation != null)
		{
			spriteAnimation._originalSpriteSize = float7;
			ArcadeSprite sprite3 = _sprite;
			if ((object)_sprite != null && sprite3.body != null)
			{
				float radius = num3 * 16f;
				BaseBody baseBody = sprite3.body.setCircle(radius, (float?)(object)0, (float?)(object)0);
				if (_expireTimer != null)
				{
					_expireTimer.Cancel();
				}
				if ((object)_weapon != null)
				{
					float num4 = _weapon.PDuration();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1238 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Rapidus_Projectile>)+370]");
					Action onComplete = new Action(this, (IntPtr)0);
					nint num5 = (nint)this;
					float duration = (float)float5 * 0.001f;
					bool flag4 = default(bool);
					MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
					int repeat = default(int);
					TimerType type = default(TimerType);
					Timer expireTimer = Timers.Register(duration, onComplete, null, isLooped: false, flag4, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					_expireTimer = expireTimer;
					int num6 = (int)_cachedTransform;
					bool flag5 = (object)_cachedTransform == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v571 @ rdi_v18 (System.Int32)+10]");
					bool flag6 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v571 @ rdi_v18 (System.Int32)+10]");
					Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)(&ret));
					isDespawning = false;
					if (_hitboxTimer != null)
					{
						_hitboxTimer.Cancel();
					}
					float hitBoxDelay = weapon.HitBoxDelay;
					Action onComplete2 = delegate
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
					};
					float duration2 = hitBoxDelay * 0.001f;
					Timer hitboxTimer = Timers.Register(duration2, onComplete2, null, isLooped: true, flag4, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					_hitboxTimer = hitboxTimer;
					Transform transform = base.transform;
					bool flag7 = (object)((Equipment)weapon)._003COwner_003Ek__BackingField == null;
					Transform parent = ((Equipment)weapon)._003COwner_003Ek__BackingField.transform;
					bool flag8 = (object)transform == null;
					transform.SetParent(parent, worldPositionStays: true);
					Transform transform2 = base.transform;
					bool flag9 = (object)transform2 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v993 @ rax_v67 (UnityEngine.Transform)+10]");
					bool flag10 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v993 @ rax_v67 (UnityEngine.Transform)+10]");
					Transform.set_localPosition_Injected((IntPtr)0, ref *(Vector3*)(&ret));
					currentBarrierScale = num3;
					OnRecycle();
					bool flag11 = (object)_weapon == null;
					float num7 = _weapon.PInterval();
					bool flag12 = (object)_weapon == null;
					float num8 = _weapon.PDuration();
					object obj2 = default(object);
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
					{
						PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_SwordThrow, new SoundManager.SoundConfig
						{
							Volume = (float?)(object)1,
							Rate = 2f
						}, 200f, 3, flag4 ? 1 : 0);
						PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.TP_sfx_SwordBrothers1, new SoundManager.SoundConfig
						{
							Volume = (float?)(object)1,
							Rate = 1f
						}, 200f, 3, flag4 ? 1 : 0);
					}
					return;
				}
			}
		}
		goto IL_04f1;
		IL_04f1:
		throw new NullReferenceException();
	}

	public virtual void OnRecycle()
	{
		//IL_003f: Expected I, but got O
		//IL_00b1: Expected O, but got I4
		if (_tween2 != null)
		{
			_tween2.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 200f;
			tweenConfig.ease = Ease.Linear;
			tweenConfig.alpha = (float?)(object)1;
			TweenCallback onStart = delegate
			{
				ArcadeSprite arcadeSprite = setAlpha(0f);
			};
			tweenConfig.onStart = onStart;
			MultiTargetTween tween = Tweens.Add(tweenConfig);
			_tween2 = tween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	public virtual void OnDespawn()
	{
		//IL_006e: Expected I, but got O
		//IL_00e0: Expected O, but got I4
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_tween2 != null)
		{
			_tween2.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 200f;
			tweenConfig.ease = Ease.Linear;
			tweenConfig.alpha = (float?)(object)1;
			TweenCallback onComplete = delegate
			{
				base.Despawn();
			};
			tweenConfig.onComplete = onComplete;
			MultiTargetTween tween = Tweens.Add(tweenConfig);
			_tween2 = tween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	protected override void OnUpdate()
	{
		//IL_03de: Invalid comparison between F4 and I4
		//IL_00d6: Expected O, but got I
		//IL_010c: Expected O, but got I
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Expected O, but got Unknown
		//IL_039c: Expected O, but got I4
		//IL_03b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b7: Expected I4, but got Unknown
		//IL_0472->IL03c6: Incompatible stack heights: 1 vs 0
		//IL_00f6->IL03c6: Incompatible stack heights: 1 vs 0
		//IL_0129->IL03c6: Incompatible stack heights: 1 vs 0
		//IL_0158->IL03c6: Incompatible stack heights: 1 vs 0
		//IL_01b0->IL01b0: Incompatible stack heights: 2 vs 3
		//IL_0234->IL03c6: Incompatible stack heights: 7 vs 0
		//IL_027c->IL03c6: Incompatible stack heights: 7 vs 0
		//IL_029e->IL03c6: Incompatible stack heights: 7 vs 0
		//IL_02ec->IL03c6: Incompatible stack heights: 7 vs 0
		//IL_030e->IL03c6: Incompatible stack heights: 7 vs 0
		//IL_033e->IL03c6: Incompatible stack heights: 7 vs 0
		//IL_0546->IL03c6: Incompatible stack heights: 7 vs 0
		//IL_0372->IL03c6: Incompatible stack heights: 7 vs 0
		CheckIfVisibleOnScreen();
		if (base._pauseWallChecksTimer > 0f)
		{
			float deltaTime = PauseSystem.DeltaTime;
			float pauseWallChecksTimer = base._pauseWallChecksTimer - deltaTime;
			base._pauseWallChecksTimer = pauseWallChecksTimer;
		}
		Weapon weapon = _weapon;
		Transform transform = default(Transform);
		if ((object)_weapon != null)
		{
			ArcadeSprite arcadeSprite = ((Equipment)weapon)._003COwner_003Ek__BackingField;
			if ((object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
			{
				((ArcadeSprite)((Equipment)weapon)._003COwner_003Ek__BackingField).CheckRenderer();
				if ((object)arcadeSprite._spriteRenderer != null)
				{
					Sprite sprite = arcadeSprite._spriteRenderer.sprite;
					if ((object)sprite != null)
					{
						bool flag = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
						Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect _);
						ArcadeSprite weapon2 = (ArcadeSprite)(object)_weapon;
						if ((object)_weapon != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rdi_v12 (ArcadeSprite)+58]");
							ArcadeSprite arcadeSprite2 = (ArcadeSprite)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rdi_v12 (ArcadeSprite)+58]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rdi_v12 (ArcadeSprite)+58]");
								((ArcadeSprite)0).CheckRenderer();
								if ((object)arcadeSprite2._spriteRenderer != null)
								{
									Sprite sprite2 = arcadeSprite2._spriteRenderer.sprite;
									if ((object)sprite2 != null)
									{
										bool flag2 = ((UnityEngine.Object)sprite2).m_CachedPtr == (IntPtr)0;
										Sprite.get_rect_Injected(((UnityEngine.Object)sprite2).m_CachedPtr, out Rect _);
										object obj = default(object);
										object obj2 = default(object);
										if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
										{
											object obj3 = obj & -2147483649L;
											if ((nint)obj3 > 2139095040)
											{
												goto IL_04cf;
											}
										}
										transform = base.transform;
										bool flag3 = (object)transform == null;
										goto IL_04cf;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_03c6;
		IL_04cf:
		bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		Weapon weapon3 = _weapon;
		bool flag5 = (object)_weapon == null;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon3)._003COwner_003Ek__BackingField;
		bool flag6 = (object)((Equipment)weapon3)._003COwner_003Ek__BackingField == null;
		BaseBody baseBody = characterController.body;
		bool flag7 = characterController.body == null;
		BaseBody baseBody2 = body;
		if (body != null)
		{
			baseBody2._velocity = baseBody._velocity;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v682 @ rax_v43 (BaseBody)+74]");
			_ = 0;
			Weapon weapon4 = _weapon;
			if ((object)_weapon != null && (object)((Equipment)weapon4)._003COwner_003Ek__BackingField != null)
			{
				bool flag8 = ((Equipment)weapon4)._003COwner_003Ek__BackingField.flipX;
				ArcadeSprite arcadeSprite3 = setFlipX(flag8);
				Weapon weapon5 = _weapon;
				if ((object)_weapon != null && (object)((Equipment)weapon5)._003COwner_003Ek__BackingField != null)
				{
					int num = ((Equipment)weapon5)._003COwner_003Ek__BackingField.Depth;
					if ((object)GM.Core != null)
					{
						PhaserScene s_scene = ArcadePhysics.s_scene;
						if (ArcadePhysics.s_scene != null)
						{
							PhaserScene.Renderer renderer = s_scene._renderer;
							if (s_scene._renderer != null)
							{
								int num2 = renderer.pixelHeight >> 31;
								object obj4 = renderer.pixelHeight - num2;
								object obj5 = obj4 >> 1;
								int num3 = num - obj5;
								ArcadeSprite arcadeSprite4 = setDepth(num3);
								return;
							}
						}
					}
				}
			}
		}
		goto IL_03c6;
		IL_03c6:
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		if (!isDespawning)
		{
			isDespawning = true;
			if (_hitboxTimer != null)
			{
				_hitboxTimer.Cancel();
			}
			OnDespawn();
		}
	}

	private void _003CInitProjectile_003Eb__8_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}

	private void _003COnRecycle_003Eb__9_0()
	{
		ArcadeSprite arcadeSprite = setAlpha(0f);
	}

	private void _003COnDespawn_003Eb__10_0()
	{
		base.Despawn();
	}
}
