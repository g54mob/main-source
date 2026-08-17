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
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Savrog2Union_Spinning_Projectile : Projectile
{
	private MultiTargetTween _tween1;

	protected PhaserSprite _spikeSprite;

	private Timer _hitboxTimer;

	private bool _isFading;

	private Timer _expireTimer;

	private float _radius = 8f;

	private TP_Savrog2Union_Weapon _trueWeapon;

	private float _deltaTime;

	private bool _isInverted;

	protected override void Awake()
	{
		//IL_008b: Expected O, but got I4
		//IL_0237->IL01c2: Incompatible stack heights: 1 vs 0
		//IL_0073->IL01c2: Incompatible stack heights: 1 vs 0
		//IL_00b8->IL01c2: Incompatible stack heights: 1 vs 0
		base.Awake();
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
			if ((object)this != null)
			{
				GameObject gameObject = base.gameObject;
				Vector2 pos = default(Vector2);
				PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_FireValve02");
				if ((object)phaserSprite != null)
				{
					PhaserSprite spikeSprite = phaserSprite.setOrigin(0.5f, (float?)(object)1);
					_spikeSprite = spikeSprite;
					if ((object)_spikeSprite != null)
					{
						Transform transform2 = _spikeSprite.transform;
						bool flag2 = (object)transform2 == null;
						bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref ret);
						int num = default(int);
						List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_FireValve", 2, 5, "ThosePeople", num);
						PhaserSprite spikeSprite2 = _spikeSprite;
						bool flag4 = (object)_spikeSprite == null;
						bool flag5 = (object)spikeSprite2._spriteAnimation == null;
						bool startRandomFrame = default(bool);
						Action onComplete = default(Action);
						bool autoSetAnimation = default(bool);
						spikeSprite2._spriteAnimation.AddAnimation("idle", animationFrames, 16, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
						PhaserSprite spikeSprite3 = _spikeSprite;
						bool flag6 = (object)_spikeSprite == null;
						bool flag7 = (object)spikeSprite3._spriteAnimation == null;
						spikeSprite3._spriteAnimation.SetAnimation("idle");
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_04cc: Expected O, but got I4
		//IL_04ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f1: Expected O, but got Unknown
		//IL_0021: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		//IL_006c: Invalid comparison between F4 and O
		//IL_013d: Expected O, but got I4
		//IL_0095: Invalid comparison between O and F4
		//IL_0167: Expected O, but got Ref
		//IL_0190: Expected O, but got I4
		//IL_01f2: Expected I, but got O
		//IL_0256: Expected O, but got I4
		//IL_0467: Expected I4, but got I8
		//IL_0484: Expected I4, but got I8
		//IL_0407: Expected O, but got I4
		//IL_0444: Expected F4, but got I4
		base.InitProjectile(pool, weapon, index);
		_radius = 16f;
		_isCullable = false;
		_isFading = false;
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		BaseBody baseBody = body;
		float radius = _radius;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj = radius ^ 0;
		BaseBody baseBody2 = body.setCircle(_radius, (float?)(object)1, (float?)(object)1);
		BaseBody baseBody3 = body;
		baseBody3._enable = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		float num = weapon.PArea();
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
		float alpha = 1f;
		if (!flag)
		{
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)2.5f))
			{
				float num2 = (float)obj - 1f;
				float num3 = num2 * 0.35000002f;
				float num4 = num3 / 1.5f;
				alpha = 1f - num4;
			}
			else
			{
				alpha = 0.65f;
			}
		}
		PhaserSprite phaserSprite = _spikeSprite.setAlpha(alpha);
		float xScale = _radius / 46f;
		PhaserSprite phaserSprite2 = _spikeSprite.setScale(xScale, (float?)(object)0);
		Transform transform = _spikeSprite.transform;
		object obj2 = default(object);
		transform.localEulerAngles = (Vector3)(&obj2);
		PhaserSprite phaserSprite3 = _spikeSprite.setVisible(visible: true);
		ArcadeSprite arcadeSprite2 = setScale(0f, (float?)(object)0);
		if (_tween1 != null)
		{
			_tween1.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num5 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj3 = default(object);
		if (obj3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 300f;
			tweenConfig.scale = (float?)(object)1;
			TweenCallback onStart = delegate
			{
				//IL_0010: Expected O, but got I4
				ArcadeSprite arcadeSprite4 = setScale(0f, (float?)(object)0);
			};
			tweenConfig.onStart = onStart;
			MultiTargetTween tween = Tweens.Add(tweenConfig);
			_tween1 = tween;
			if (_hitboxTimer != null)
			{
				_hitboxTimer.Cancel();
			}
			float hitBoxDelay = _weapon.HitBoxDelay;
			Action onComplete = delegate
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
			};
			float duration = hitBoxDelay * 0.001f;
			bool flag2 = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer hitboxTimer = Timers.Register(duration, onComplete, null, isLooped: true, flag2, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_hitboxTimer = hitboxTimer;
			if (_expireTimer != null)
			{
				_expireTimer.Cancel();
			}
			Action onComplete2 = FadeOut;
			Timer expireTimer = Timers.Register(0.4f, onComplete2, null, isLooped: true, flag2, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_expireTimer = expireTimer;
			if (_indexInWeapon == 0)
			{
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				soundConfig.Volume = (float?)(object)1;
				soundConfig.Rate = 0.8f;
				soundConfig.Detune = -2500f;
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Spinning, soundConfig, 200f, 5, flag2 ? 1 : 0);
			}
			_deltaTime = 0f;
			ArcadeSprite arcadeSprite3 = setDepth(-2);
			PhaserSprite phaserSprite4 = _spikeSprite.setDepth(-2);
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	public void SetInversion(bool isInverted = false)
	{
		_isInverted = isInverted;
	}

	public override void InternalUpdate()
	{
		//IL_001d: Expected I, but got O
		//IL_0025: Expected I, but got O
		//IL_0035: Expected O, but got I
		//IL_00b5: Expected O, but got I4
		//IL_02ed: Expected I, but got O
		//IL_0071: Expected O, but got I
		//IL_00c8: Expected I, but got O
		//IL_00a7: Expected O, but got I4
		//IL_0354->IL028e: Incompatible stack heights: 1 vs 0
		//IL_01b9->IL028e: Incompatible stack heights: 1 vs 0
		//IL_01fa->IL028e: Incompatible stack heights: 1 vs 0
		//IL_027e->IL028e: Incompatible stack heights: 1 vs 0
		Weapon weapon = _weapon;
		TP_Savrog2Union_Weapon trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = null;
			goto IL_02c1;
		}
		nint num = (nint)typeof(TP_Savrog2Union_Weapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Savrog2Union_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ r9_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Savrog2Union_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ r9_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v38+FFFFFFF8+v47 @ rax_v33*8]");
			if (0 == (nint)typeof(TP_Savrog2Union_Weapon))
			{
				obj3 = 1;
				goto IL_02d0;
			}
		}
		obj3 = 0;
		goto IL_02d0;
		IL_02d0:
		bool flag = obj3 == null;
		nint num4 = (nint)typeof(TP_Savrog2Union_Weapon);
		trueWeapon = null;
		if (!flag)
		{
			num4 = (nint)typeof(TP_Savrog2Union_Weapon);
			trueWeapon = (TP_Savrog2Union_Weapon)_weapon;
		}
		goto IL_02c1;
		IL_02c1:
		_trueWeapon = trueWeapon;
		float deltaTime = PauseSystem.DeltaTime;
		float num5 = deltaTime * 4f;
		Weapon weapon2 = _weapon;
		float deltaTime2 = num5 + _deltaTime;
		_deltaTime = deltaTime2;
		if ((object)_weapon != null && (object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
		{
			Transform transform = ((Equipment)weapon2)._003COwner_003Ek__BackingField.transform;
			if ((object)transform != null)
			{
				bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				Weapon weapon3 = _weapon;
				if ((object)_weapon != null)
				{
					VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon3)._003COwner_003Ek__BackingField;
					if ((object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v284 @ rax_v18 (VampireSurvivors.Objects.Characters.CharacterController)+238]");
						float num6 = 0f * 0.35f;
						TP_Savrog2Union_Weapon trueWeapon2 = _trueWeapon;
						if ((object)_trueWeapon != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rax_v19 (VampireSurvivors.Objects.Weapons.TP_Savrog2Union_Weapon)+1A0]");
							float num7 = 0f * -1f;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
							bool flag3 = _isInverted;
							float num8 = -1f;
							if (!flag3)
							{
								num8 = 1f;
							}
							float num9 = num8 * _deltaTime;
							float num10 = num9 + num7;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
							float num11 = num10 * 0.75f;
							float2 float5 = default(float2);
							base.position = float5;
							float2 float6 = base.position;
							if ((object)_spikeSprite != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
								return;
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
		//IL_00b1: Expected O, but got I4
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if (_tween1 != null)
		{
			_tween1.Kill();
		}
		PhaserSprite phaserSprite = _spikeSprite.setVisible(visible: false);
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		ArcadeSprite arcadeSprite2 = setVisible(visible: false);
		BaseBody baseBody = body;
		baseBody._enable = false;
		base.Despawn();
	}

	protected void FadeOut()
	{
		//IL_003a: Expected I, but got O
		//IL_0092: Expected I, but got O
		//IL_00f6: Expected O, but got I4
		//IL_0104: Expected O, but got I4
		//IL_011f: Expected I, but got O
		if (_isFading)
		{
			return;
		}
		_isFading = true;
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[2];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			if ((object)_spikeSprite != null)
			{
				nint num2 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				if (obj2 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 300f;
			tweenConfig.scale = (float?)(object)1;
			tweenConfig.alpha = (float?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v446 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Spinning_Projectile>)+370]");
			TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
			nint num3 = (nint)this;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
			if (_weapon.HasActiveArcanaOfType(ArcanaType.T19_FIRE))
			{
				Weapon weapon = _weapon;
				GameManager gameMan = weapon._gameMan;
				float2 float5 = base.position;
				Vector2 pos = default(Vector2);
				gameMan._arcanaManager.TriggerFireExplosion(pos);
			}
			return;
		}
		ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
		throw ex2;
	}

	private void _003CInitProjectile_003Eb__10_1()
	{
		//IL_0010: Expected O, but got I4
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
	}

	private void _003CInitProjectile_003Eb__10_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}
}
