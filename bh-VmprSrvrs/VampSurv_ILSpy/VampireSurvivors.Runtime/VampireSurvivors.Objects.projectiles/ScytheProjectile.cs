using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Events;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class ScytheProjectile : Projectile
{
	private Tween _angleTween;

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_002e: Expected I4, but got O
		//IL_0076: Expected O, but got Ref
		//IL_05e3: Expected O, but got I4
		//IL_04d8: Expected O, but got I4
		//IL_04d8: Expected O, but got I4
		//IL_03f3: Expected O, but got I4
		//IL_03f3: Expected O, but got I4
		//IL_05b9->IL050f: Incompatible stack heights: 1 vs 0
		//IL_024d->IL050f: Incompatible stack heights: 1 vs 0
		//IL_0347->IL050f: Incompatible stack heights: 1 vs 0
		//IL_0648->IL050f: Incompatible stack heights: 1 vs 0
		//IL_03ca->IL050f: Incompatible stack heights: 1 vs 0
		//IL_0677->IL050f: Incompatible stack heights: 1 vs 0
		//IL_041c->IL050f: Incompatible stack heights: 1 vs 0
		//IL_044b->IL050f: Incompatible stack heights: 1 vs 0
		//IL_046a->IL050f: Incompatible stack heights: 1 vs 0
		//IL_04ab->IL050f: Incompatible stack heights: 1 vs 0
		base.InitProjectile(pool, weapon, index);
		if (base.body != null)
		{
			BaseBody baseBody = base.body.setCircle(16f, (float?)(object)0, (float?)(object)0);
			int num = (int)_cachedTransform;
			_speed = 1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rsi_v5 (System.Int32)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rsi_v5 (System.Int32)+10]");
			Vector3 value = default(Vector3);
			Transform.set_localScale_Injected((IntPtr)0, ref value);
			if (_angleTween != null)
			{
				TweenExtensions.Kill(_angleTween);
			}
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(_cachedTransform, (Vector3)(&value), 0.5f, RotateMode.FastBeyond360);
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v522 @ rax_v22 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v522 @ rax_v22 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v522 @ rax_v22 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+98]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v522 @ rax_v22 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+99]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v522 @ rax_v22 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
					if ((nint)0 != 0)
					{
						_ = 1;
						_ = 0;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v522 @ rax_v22 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v522 @ rax_v22 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
					if ((nint)0 == 0)
					{
						_ = 4294967295L;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v522 @ rax_v22 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
						if ((nint)0 == 0)
						{
							_ = 2139095040;
						}
					}
				}
			}
			_angleTween = tweenerCore;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if (_angleTween != null)
			{
				SetScaleToArea();
				Weapon weapon2 = _weapon;
				if ((object)_weapon != null)
				{
					if (!weapon2.IsHoming)
					{
						float num2 = _weapon.PAmount();
						float num4 = default(float);
						float num3 = -360f / num4;
						float num5 = num3 * (float)_indexInWeapon;
						float projectileSpeed = base.ProjectileSpeed;
						float num6 = num5 + 90f;
						float num7 = num6 * ((float)Math.PI / 180f);
						Vector2 vector = SetVelocityFromRotation(num7, num4);
						float num8 = num7;
					}
					else
					{
						Transform transform = base.AimForNearestEnemy();
						float num8 = 1f;
					}
					SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
					{
						Rate = 1f,
						Volume = (float?)(object)1
					};
					float detune = (float)_indexInWeapon * -100f;
					soundConfig.Detune = detune;
					float time = default(float);
					PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Shot, soundConfig, 200f, 10, time);
					if ((object)_weapon != null)
					{
						int num9 = _weapon.PBounces();
						if (num9 <= 0)
						{
							goto IL_0607;
						}
						if (_bounceActivated)
						{
							goto IL_04c3;
						}
						_bounceActivated = true;
						PhaserScene s_scene = ArcadePhysics.s_scene;
						if (ArcadePhysics.s_scene != null && (object)s_scene.physics != null)
						{
							WORLD_BOUNDS_EVENT wORLD_BOUNDS_EVENT = Bounce;
							if (ArcadePhysics.s_world != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6950");
								setCollideWorldBounds(value: true, (float?)(object)1, (float?)(object)1);
								Weapon weapon3 = _weapon;
								if ((object)_weapon != null)
								{
									VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon3)._003COwner_003Ek__BackingField;
									if ((object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null && base.body != null)
									{
										Body body = base.body.setBoundsRectangle(characterController._worldBoxCollider);
										BaseBody baseBody2 = base.body;
										if (base.body != null)
										{
											baseBody2._onWorldBounds = true;
											goto IL_0607;
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
		IL_04c3:
		setCollideWorldBounds(value: true, (float?)(object)1, (float?)(object)1);
		return;
		IL_0607:
		if (!_bounceActivated)
		{
			return;
		}
		goto IL_04c3;
	}

	public override void Despawn()
	{
		if (_angleTween != null)
		{
			TweenExtensions.Kill(_angleTween);
		}
		_angleTween = null;
		base.Despawn();
	}

	private void Bounce(Body body, bool up, bool down, bool left, bool right)
	{
		//IL_0080: Expected O, but got F4
		//IL_0039: Expected O, but got I4
		//IL_0039: Expected O, but got I4
		if (base.body == body)
		{
			if (_bounces <= 0)
			{
				setCollideWorldBounds(value: false, (float?)(object)1, (float?)(object)1);
				return;
			}
			int bounces = _bounces - 1;
			_bounces = bounces;
			float num = (float)body._velocity * -2f;
			body._velocity = (float2)num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body @ rdx (Body)+74]");
			float num2 = 0f * -2f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
	}

	protected override void OnHasHitAnotherPlayerObject(IDamageable other)
	{
		//IL_001d: Expected I, but got O
		//IL_0025: Expected I, but got O
		//IL_0035: Expected O, but got I
		//IL_00b5: Expected O, but got I4
		//IL_01cd: Expected I, but got O
		//IL_0071: Expected O, but got I
		//IL_00c8: Expected I, but got O
		//IL_00a7: Expected O, but got I4
		//IL_0152: Expected O, but got F4
		//IL_010b: Expected O, but got I4
		//IL_010b: Expected O, but got I4
		BaseBody baseBody = body;
		BaseBody baseBody2;
		if (body == null)
		{
			baseBody2 = null;
			goto IL_01e0;
		}
		nint num = (nint)typeof(Body);
		nint num2 = (nint)baseBody;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r8_v5 (Il2CppClass<Body>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r9_v1 (Il2CppClass<BaseBody>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r8_v5 (Il2CppClass<Body>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r9_v1 (Il2CppClass<BaseBody>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rax_v15+FFFFFFF8+v47 @ rax_v11*8]");
			if (0 == (nint)typeof(Body))
			{
				obj3 = 1;
				goto IL_01b0;
			}
		}
		obj3 = 0;
		goto IL_01b0;
		IL_01b0:
		bool flag = obj3 == null;
		nint num4 = (nint)typeof(Body);
		baseBody2 = null;
		if (!flag)
		{
			num4 = (nint)typeof(Body);
			baseBody2 = body;
		}
		goto IL_01e0;
		IL_01e0:
		if (body == baseBody2)
		{
			if (_bounces <= 0)
			{
				setCollideWorldBounds(value: false, (float?)(object)1, (float?)(object)1);
				return;
			}
			int bounces = _bounces - 1;
			_bounces = bounces;
			float num5 = (float)baseBody2._velocity * -2f;
			baseBody2._velocity = (float2)num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rdi_v1 (BaseBody)+74]");
			float num6 = 0f * -2f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
	}
}
