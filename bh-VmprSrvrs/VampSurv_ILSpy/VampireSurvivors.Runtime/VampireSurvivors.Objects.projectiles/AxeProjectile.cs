using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class AxeProjectile : Projectile
{
	private Tween _angleTween;

	private Tween _scaleTween;

	private Vector2 _initialVel;

	private float _startingAngle;

	private const float Grav = 6.25f;

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0092: Expected O, but got Ref
		//IL_0571: Expected O, but got Ref
		//IL_02ab: Expected I, but got O
		//IL_02c9: Expected O, but got I4
		//IL_02f7: Expected O, but got I4
		//IL_0313: Expected O, but got I4
		//IL_065c: Expected O, but got I4
		//IL_05b2: Expected I, but got O
		//IL_05f2: Expected O, but got I
		//IL_03d6: Expected I, but got O
		//IL_0449: Expected I, but got O
		//IL_03bd: Expected I4, but got I8
		base.InitProjectile(pool, weapon, index);
		BaseBody baseBody = body.setCircle(12f, (float?)(object)0, (float?)(object)0);
		_speed = 2f;
		_isCullable = false;
		SetScaleToArea();
		if (_angleTween != null)
		{
			TweenExtensions.Kill(_angleTween);
		}
		Vector2 vector = default(Vector2);
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(_cachedTransform, (Vector3)(&vector), 1f, RotateMode.FastBeyond360);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rax_v9 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rax_v9 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rax_v9 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+98]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rax_v9 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+99]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rax_v9 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 1;
					_ = 0;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rax_v9 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rax_v9 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 4294967295L;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rax_v9 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
					if ((nint)0 == 0)
					{
						_ = 2139095040;
					}
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_angleTween = tweenerCore;
		if (_scaleTween != null)
		{
			TweenExtensions.Kill(_scaleTween);
		}
		TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOScale(_cachedTransform, (Vector3)(&vector), 0.5f);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = TweenSettingsExtensions.SetDelay(t, 4f);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v750 @ rax_v21 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v813 @ r8_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.AxeProjectile>)+370]");
		TweenCallback tweenCallback = new TweenCallback(this, (IntPtr)0);
		nint num = (nint)this;
		bool flag = tweenerCore2 == null;
		object obj = 0;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v750 @ rax_v21 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			bool flag2 = (nint)0 == 0;
			obj = 0;
			if (!flag2)
			{
				obj = 0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_scaleTween = tweenerCore2;
		Weapon weapon2 = _weapon;
		if (!weapon2.IsHoming)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
			nint num2 = (nint)typeof(Vector2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rax_v40 (Il2CppClass<UnityEngine.Vector2>)+B8]");
			nint num3 = 0;
			object obj2 = Vector2.rightVector * characterController._lastFacingDirection;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1092 @ rcx_v30 (Il2CppStaticFields<UnityEngine.Vector2>)+2C]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rcx_v28 (VampireSurvivors.Objects.Characters.CharacterController)+238]");
			object obj3 = num4 * 0;
			object obj4 = obj2 + obj3;
			bool flag3 = 0 <= (nint)obj4;
			RotateMode rotateMode = RotateMode.FastBeyond360;
			if (!flag3)
			{
				rotateMode = (RotateMode)(-1);
			}
			float num5 = _weapon.PAmount();
			nint num6 = (nint)this;
			float num7 = (float)rotateMode * 45f;
			float num8 = num7 / (float)obj3;
			float num9 = num8 * (float)_indexInWeapon;
			float num10 = num9 - 90f;
			float num11 = (_startingAngle = num10 * ((float)Math.PI / 180f));
			float projectileSpeed = base.ProjectileSpeed;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			nint num12 = (nint)this;
			float projectileSpeed2 = base.ProjectileSpeed;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			float num13 = num11 * num11;
			float num14 = num13 * -1f;
			if (num14 > 6f)
			{
				Vector2 initialVel = default(Vector2);
				_initialVel = initialVel;
				goto IL_0637;
			}
		}
		Transform transform = base.AimForNearestEnemy();
		BaseBody baseBody2 = body;
		_initialVel = baseBody2._velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rax_v38 (BaseBody)+74]");
		_ = 0;
		goto IL_0637;
		IL_0637:
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * -100f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Shot, soundConfig, 200f, 10, time);
	}

	public override void InternalUpdate()
	{
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Expected O, but got Unknown
		//IL_023f->IL01e4: Incompatible stack heights: 1 vs 0
		//IL_0169->IL01e4: Incompatible stack heights: 1 vs 0
		//IL_0198->IL01e4: Incompatible stack heights: 1 vs 0
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 6.25f;
		float num2 = num * -1f;
		float num3 = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.AxeProjectile)+E4]");
		float num4 = num3 + 0f;
		ArcadeSprite sprite = _sprite;
		if ((object)_sprite != null)
		{
			BaseBody baseBody = sprite.body;
			if (sprite.body != null)
			{
				baseBody._velocity = _initialVel;
				float2 float5 = base.position;
				Weapon weapon = _weapon;
				if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
				{
					Transform transform = ((Equipment)weapon)._003COwner_003Ek__BackingField.transform;
					if ((object)transform != null)
					{
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
						Weapon weapon2 = _weapon;
						if ((object)_weapon != null)
						{
							VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
							if ((object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
							{
								ArcadeBodyBounds worldBoxCollider = characterController._worldBoxCollider;
								if (characterController._worldBoxCollider != null)
								{
									object obj2 = default(object);
									object obj = obj2 - worldBoxCollider.height;
									object obj3 = default(object);
									if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
									{
										_isCullable = true;
										Despawn();
									}
									return;
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
		if (_angleTween != null)
		{
			TweenExtensions.Kill(_angleTween);
		}
		_angleTween = null;
		if (_scaleTween != null)
		{
			TweenExtensions.Kill(_scaleTween);
		}
		_scaleTween = null;
		base.Despawn();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		OnHasHitAnObjectLogic(other, triggerHit: true);
	}

	protected override void OnHasHitAnotherPlayerObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 2 Invalid \"Jump target not found in method: 0x186FEEEA0\"");
	}

	private void OnHasHitAnObjectLogic(IDamageable other, bool triggerHit)
	{
		//IL_00ae: Expected I, but got O
		//IL_010c: Expected O, but got F4
		//IL_012e: Expected F4, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		if (_bounces <= 0)
		{
			if (triggerHit && --_penetrating <= 0)
			{
				Despawn();
			}
			return;
		}
		nint num = (nint)this;
		int bounces = _bounces - 1;
		_bounces = bounces;
		float projectileSpeed = base.ProjectileSpeed;
		float speed = default(float);
		Vector2 vector = SetVelocityFromRotation(_startingAngle, speed);
		float num2 = (float)_initialVel * -1f;
		BaseBody baseBody = body;
		_initialVel = (Vector2)num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rax_v9 (BaseBody)+74]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		float num4 = num3 ^ 0;
		bool flag = !(-6f < num4);
		float num5 = -6f;
		if (!flag)
		{
			num5 = num4;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}
}
