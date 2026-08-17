using System;
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
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Shield1_Projectile : Projectile
{
	private float _bodyRadius = 20f;

	private PhaserSprite _displaySprite1;

	private PhaserSprite _displaySprite2;

	private MultiTargetTween _alphaTween1;

	private MultiTargetTween _alphaTween2;

	private Timer _hitBoxTimer;

	private Timer _durationTimer;

	private TP_Shield1_Weapon _trueWeapon;

	private Timer _selfDelayTimer;

	private bool _canShoot = true;

	protected override void Awake()
	{
		//IL_0095: Expected O, but got I4
		//IL_00f7: Expected O, but got I4
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_ShieldIron_01");
		PhaserSprite phaserSprite2 = phaserSprite.setAlpha(0f);
		PhaserSprite displaySprite = phaserSprite2.setScale(1.4f, (float?)(object)0);
		_displaySprite1 = displaySprite;
		GameObject gameObject2 = base.gameObject;
		PhaserSprite phaserSprite3 = RenderingExtensions.AddPhaserSprite(gameObject2, pos, "ThosePeople", "TP_VFX_ShieldIron_02");
		PhaserSprite phaserSprite4 = phaserSprite3.setAlpha(0f);
		PhaserSprite phaserSprite5 = phaserSprite4.setScale(1.4f, (float?)(object)0);
		PhaserSprite displaySprite2 = phaserSprite5.setBlendMode(BlendMode.Add);
		_displaySprite2 = displaySprite2;
		_canShoot = true;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0021: Expected I, but got O
		//IL_0029: Expected I, but got O
		//IL_0039: Expected O, but got I
		//IL_00b9: Expected O, but got I4
		//IL_000e: Expected O, but got I4
		//IL_050e: Expected O, but got I4
		//IL_0075: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_0123: Expected O, but got I4
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Expected F4, but got Unknown
		//IL_0164: Expected O, but got I4
		//IL_0164: Expected O, but got I4
		//IL_01e4: Expected O, but got I4
		//IL_0284: Expected I, but got O
		//IL_02e8: Expected O, but got I4
		//IL_0534: Expected O, but got F4
		//IL_0552: Expected O, but got I4
		//IL_049f: Expected F4, but got I4
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		float? trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_04e7;
		}
		nint num = (nint)typeof(TP_Shield1_Weapon);
		nint num2 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rdx_v57 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Shield1_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ r9_v17 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rdx_v57 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Shield1_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ r9_v17 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rax_v101+FFFFFFF8+v72 @ rax_v96*8]");
			if (0 == (nint)typeof(TP_Shield1_Weapon))
			{
				obj3 = 1;
				goto IL_04f6;
			}
		}
		obj3 = 0;
		goto IL_04f6;
		IL_04f6:
		bool flag = obj3 == null;
		trueWeapon = (float?)(object)0;
		if (!flag)
		{
			trueWeapon = (float?)_weapon;
		}
		goto IL_04e7;
		IL_04e7:
		_trueWeapon = (TP_Shield1_Weapon)trueWeapon;
		float2 localPosition = default(float2);
		PhaserSprite phaserSprite = _displaySprite1.setLocalPosition(localPosition);
		PhaserSprite phaserSprite2 = _displaySprite2.setLocalPosition(localPosition);
		_canShoot = true;
		_isCullable = false;
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		float bodyRadius = _bodyRadius;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		float num4 = bodyRadius ^ 0;
		BaseBody baseBody = body.setCircle(_bodyRadius, (float?)(object)1, (float?)(object)1);
		float num5 = _weapon.PArea();
		if (!(1f < num4) || num4 < 3f)
		{
		}
		PhaserSprite phaserSprite3 = _displaySprite1.setAlpha(0f);
		ArcadeSprite arcadeSprite2 = setScale(num4, (float?)(object)0);
		UpdatePosition();
		PhaserSprite phaserSprite4 = _displaySprite2.setAlpha(0f);
		if (_alphaTween1 != null)
		{
			_alphaTween1.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_displaySprite1 != null)
		{
			nint num6 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 100f;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			PhaserSprite phaserSprite5 = _displaySprite1.setAlpha(0f);
		};
		tweenConfig.onStart = onStart;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
		_alphaTween1 = alphaTween;
		float hitBoxDelay = weapon.HitBoxDelay;
		Action onComplete = delegate
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		};
		float num7 = hitBoxDelay * 0.001f;
		bool flag2 = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer hitBoxTimer = Timers.Register(num7, onComplete, null, isLooped: true, flag2, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_hitBoxTimer = hitBoxTimer;
		float num8 = weapon.PDuration();
		Action onComplete2 = StartDespawn;
		float num9 = num7 * 0.001f;
		Timer durationTimer = Timers.Register(num9, onComplete2, null, isLooped: false, flag2, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_durationTimer = durationTimer;
		float num10 = _weapon.PInterval();
		Weapon weapon3 = _weapon;
		float num11 = weapon3.PDuration();
		if (num9 > num9)
		{
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			object obj5 = UnityEngine.Random.value;
			float num12 = num9 - 0.5f;
			soundConfig.Volume = (float?)(object)1;
			float detune = num12 * 200f;
			soundConfig.Detune = detune;
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Spinning, soundConfig, 200f, 10, flag2 ? 1 : 0);
		}
	}

	public void StartDespawn()
	{
		//IL_005e: Expected I, but got O
		//IL_00c2: Expected O, but got I4
		//IL_00dd: Expected I, but got O
		if (_alphaTween1 != null)
		{
			_alphaTween1.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_displaySprite1 != null)
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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Shield1_Projectile>)+370]");
		TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
		nint num2 = (nint)this;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
		_alphaTween1 = alphaTween;
	}

	public override void InternalUpdate()
	{
		UpdatePosition();
	}

	private void UpdatePosition()
	{
		//IL_0281: Expected O, but got I4
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		//IL_028f: Expected O, but got Unknown
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Expected O, but got Unknown
		//IL_0384->IL026d: Incompatible stack heights: 1 vs 0
		//IL_0152->IL026d: Incompatible stack heights: 1 vs 0
		//IL_0181->IL026d: Incompatible stack heights: 1 vs 0
		//IL_040a->IL026d: Incompatible stack heights: 2 vs 0
		//IL_01bd->IL026d: Incompatible stack heights: 2 vs 0
		//IL_0206->IL026d: Incompatible stack heights: 2 vs 0
		//IL_0246->IL026d: Incompatible stack heights: 2 vs 0
		Weapon weapon = _weapon;
		if ((object)_weapon != null)
		{
			TP_Shield1_Weapon trueWeapon = _trueWeapon;
			ArcadeSprite arcadeSprite = ((Equipment)weapon)._003COwner_003Ek__BackingField;
			if ((object)_trueWeapon != null)
			{
				float num = (float)trueWeapon.SlotNumber / 3f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
				bool flag = (object)((Equipment)weapon)._003COwner_003Ek__BackingField == null;
				if (!flag)
				{
					bool flag2 = ((Equipment)weapon)._003COwner_003Ek__BackingField.flipX;
					bool flag3 = (byte)((flag2 ? 1u : 0u) ^ 1u) != 0;
					if (!flag)
					{
						flag3 = flag2;
					}
					object obj = (flag3 ? 1 : 0) + (flag3 ? 1 : 0);
					object obj2 = obj - 1;
					object obj3 = obj ^ 1;
					object obj4 = obj ^ obj2;
					object obj5 = obj3 & obj4;
					bool flag4 = (nint)obj5 < 0;
					bool flag5 = (nint)obj2 < 0;
					bool flag6 = obj2 == null;
					bool flag7 = flag5 == flag4;
					bool flag8 = !flag6;
					bool flag9 = flag8 & flag7;
					((ArcadeSprite)((Equipment)weapon)._003COwner_003Ek__BackingField).CheckRenderer();
					if ((object)arcadeSprite._spriteRenderer != null)
					{
						Sprite sprite = arcadeSprite._spriteRenderer.sprite;
						if ((object)sprite != null)
						{
							bool flag10 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
							Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect ret);
							if (body != null)
							{
								float num2 = base.scale;
								((ArcadeSprite)((Equipment)weapon)._003COwner_003Ek__BackingField).CheckRenderer();
								if ((object)arcadeSprite._spriteRenderer != null)
								{
									Sprite sprite2 = arcadeSprite._spriteRenderer.sprite;
									if ((object)sprite2 != null)
									{
										bool flag11 = ((UnityEngine.Object)sprite2).m_CachedPtr == (IntPtr)0;
										Sprite.get_rect_Injected(((UnityEngine.Object)sprite2).m_CachedPtr, out ret);
										if ((nint)obj > 1)
										{
										}
										float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
										float2 float6 = default(float2);
										base.position = float6;
										if ((object)_displaySprite1 != null)
										{
											PhaserSprite phaserSprite = _displaySprite1.setFlipX(flag9);
											if ((object)_displaySprite2 != null)
											{
												PhaserSprite phaserSprite2 = _displaySprite2.setFlipX(flag9);
												int num3 = ((Equipment)weapon)._003COwner_003Ek__BackingField.Depth;
												if ((object)_displaySprite1 != null)
												{
													int num4 = num3 + 1;
													PhaserSprite phaserSprite3 = _displaySprite1.setDepth(num4);
													if ((object)_displaySprite2 != null)
													{
														int num5 = num3 + 2;
														PhaserSprite phaserSprite4 = _displaySprite2.setDepth(num5);
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

	public override void Despawn()
	{
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		if (_selfDelayTimer != null)
		{
			_selfDelayTimer.Cancel();
		}
		if (_hitBoxTimer != null)
		{
			_hitBoxTimer.Cancel();
		}
		if (_durationTimer != null)
		{
			_durationTimer.Cancel();
		}
		if (_alphaTween1 != null)
		{
			_alphaTween1.Kill();
		}
		if (_alphaTween2 != null)
		{
			_alphaTween2.Kill();
		}
		base.Despawn();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		//IL_02ce: Expected O, but got F4
		//IL_0307: Expected O, but got I4
		//IL_012c: Expected F4, but got I4
		//IL_01ef: Expected I, but got O
		//IL_025d: Expected O, but got I4
		//IL_0212->IL0212: Incompatible stack heights: 1 vs 0
		if (!_canShoot)
		{
			return;
		}
		_canShoot = false;
		if (_selfDelayTimer != null)
		{
			_selfDelayTimer.Cancel();
		}
		float hitBoxDelay = _weapon.HitBoxDelay;
		Action onComplete = delegate
		{
			_canShoot = true;
		};
		float duration = hitBoxDelay * 0.001f;
		bool flag = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer selfDelayTimer = Timers.Register(duration, onComplete, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_selfDelayTimer = selfDelayTimer;
		TP_Shield1_Weapon trueWeapon = _trueWeapon;
		float2 float5 = base.position;
		Vector2 vector = default(Vector2);
		_trueWeapon.FireProjectiles(trueWeapon._standardPool, vector);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj = UnityEngine.Random.value;
		float detune = (float)vector * -500f;
		soundConfig.Rate = 1f;
		soundConfig.Detune = detune;
		soundConfig.Volume = (float?)(object)1;
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_ShieldRod, soundConfig, 200f, 1, flag ? 1 : 0);
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (config._003CFlashingVFXEnabled_003Ek__BackingField)
		{
			if (_alphaTween2 != null)
			{
				_alphaTween2.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if ((object)_displaySprite2 != null)
			{
				nint num = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				bool flag2 = obj2 == null;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 100f;
			tweenConfig.yoyo = true;
			tweenConfig.alpha = (float?)(object)1;
			TweenCallback onStart = delegate
			{
				PhaserSprite phaserSprite = _displaySprite2.setAlpha(0f);
			};
			tweenConfig.onStart = onStart;
			MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
			_alphaTween2 = alphaTween;
		}
	}

	private void _003CInitProjectile_003Eb__11_1()
	{
		PhaserSprite phaserSprite = _displaySprite1.setAlpha(0f);
	}

	private void _003CInitProjectile_003Eb__11_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}

	private void _003COnHasHitAnObject_003Eb__16_0()
	{
		_canShoot = true;
	}

	private void _003COnHasHitAnObject_003Eb__16_1()
	{
		PhaserSprite phaserSprite = _displaySprite2.setAlpha(0f);
	}
}
