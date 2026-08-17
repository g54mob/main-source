using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class KnifeProjectile : Projectile
{
	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_00b5: Expected O, but got I4
		//IL_00b5: Expected O, but got I4
		//IL_00d9: Expected I4, but got O
		//IL_0696: Expected O, but got F4
		//IL_057d: Expected O, but got F4
		//IL_01be: Expected O, but got Ref
		//IL_0670: Expected O, but got I4
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Expected O, but got Unknown
		//IL_0426: Expected O, but got I
		//IL_047f: Invalid comparison between I and F4
		//IL_056f->IL04d7: Incompatible stack heights: 1 vs 0
		//IL_0634->IL04d7: Incompatible stack heights: 5 vs 0
		//IL_01aa->IL04d7: Incompatible stack heights: 5 vs 0
		//IL_0201->IL04d7: Incompatible stack heights: 5 vs 0
		//IL_0323->IL04d7: Incompatible stack heights: 5 vs 0
		//IL_024c->IL04d7: Incompatible stack heights: 5 vs 0
		//IL_0383->IL04d7: Incompatible stack heights: 5 vs 0
		//IL_026e->IL04d7: Incompatible stack heights: 5 vs 0
		//IL_03b2->IL04d7: Incompatible stack heights: 5 vs 0
		//IL_03d4->IL04d7: Incompatible stack heights: 5 vs 0
		//IL_02df->IL0639: Incompatible stack heights: 6 vs 5
		//IL_0446->IL04d7: Incompatible stack heights: 6 vs 0
		//IL_04b6->IL04d7: Incompatible stack heights: 7 vs 0
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		if ((object)_weapon != null)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
			if ((object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
			{
				if (characterController._characterType == CharacterType.TP_MALPHAS)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
					Sprite sprite = default(Sprite);
					ArcadeSprite arcadeSprite = setFrame(sprite);
				}
				if (body != null)
				{
					BaseBody baseBody = body.setCircle(8f, (float?)(object)0, (float?)(object)0);
					_speed = 2f;
					SetScaleToArea();
					int num = (int)_cachedTransform;
					if ((object)_cachedTransform != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ rsi_v13 (System.Int32)+10]");
						bool flag = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ rsi_v13 (System.Int32)+10]");
						Transform.get_position_Injected((IntPtr)0, out Vector3 value);
						object obj = UnityEngine.Random.value;
						if (_indexInWeapon == 0)
						{
						}
						if ((object)_weapon != null)
						{
							float num2 = _weapon.PArea();
							object obj2 = UnityEngine.Random.value;
							if (_indexInWeapon == 0)
							{
							}
							bool flag2 = (object)_weapon == null;
							float num3 = _weapon.PArea();
							Weapon cachedTransform = (Weapon)(object)_cachedTransform;
							bool flag3 = (object)_cachedTransform == null;
							bool flag4 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
							Transform.set_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
							Weapon weapon3 = _weapon;
							bool flag5 = (object)_weapon == null;
							if (!weapon3.IsHoming)
							{
								if ((object)((Equipment)weapon3)._003COwner_003Ek__BackingField == null)
								{
									goto IL_04d7;
								}
								ApplyPlayerFacingVelocity((Vector3)(&value));
							}
							else
							{
								Transform transform = base.AimForNearestEnemy();
							}
							Weapon weapon4 = _weapon;
							if ((object)_weapon != null)
							{
								WeaponData currentWeaponData = weapon4._currentWeaponData;
								if (weapon4._currentWeaponData != null)
								{
									if ((object)currentWeaponData._003Cvolume_003Ek__BackingField != null)
									{
										Weapon weapon5 = _weapon;
										if ((object)_weapon == null || weapon5._currentWeaponData == null)
										{
											goto IL_04d7;
										}
										object obj3 = default(object);
										bool flag6 = (nint)obj3 < 0;
										bool flag7 = !flag6;
										object obj4 = (_003F?)currentWeaponData._003Cvolume_003Ek__BackingField & flag7;
										if (obj4 != null)
										{
											bool flag8 = (object)currentWeaponData._003Cvolume_003Ek__BackingField == null;
										}
									}
									SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
									{
										Rate = 1f
									};
									float detune = (float)_indexInWeapon * -100f;
									soundConfig.Volume = (float?)(object)1;
									soundConfig.Detune = detune;
									float time = default(float);
									PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Shot, soundConfig, 200f, 10, time);
									Weapon weapon6 = _weapon;
									if ((object)_weapon != null)
									{
										Weapon weapon7 = _weapon;
										List<float> critChancesArray = weapon6._critChancesArray;
										int critIndex = weapon7._critIndex + 1;
										weapon7._critIndex = critIndex;
										Weapon weapon8 = _weapon;
										if ((object)_weapon != null)
										{
											List<float> critChancesArray2 = weapon8._critChancesArray;
											if (weapon8._critChancesArray != null && weapon6._critChancesArray != null)
											{
												int critIndex2 = weapon7._critIndex;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ r9_v16 (System.Collections.Generic.List`1<System.Single>)+18]");
												int num4 = (int)((nint)critIndex2 % (nint)0);
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ r8_v18 (System.Collections.Generic.List`1<System.Single>)+18]");
												bool flag9 = (nint)num4 >= (nint)0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ r8_v18 (System.Collections.Generic.List`1<System.Single>)+10]");
												object obj5 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ r8_v18 (System.Collections.Generic.List`1<System.Single>)+10]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ rcx_v48+18]");
													bool flag10 = (nint)num4 >= (nint)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ rcx_v48+20+v180 @ rdx_v32 (System.Int32)*4]");
													bool flag11 = 0f < 0.5f;
													int bounces = 0;
													if (!flag11)
													{
														if ((object)_weapon == null)
														{
															goto IL_04d7;
														}
														int num5 = _weapon.PBounces();
														bounces = num5;
													}
													_bounces = bounces;
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
		goto IL_04d7;
		IL_04d7:
		throw new NullReferenceException();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		OnHasHitAnObjectLogic(other, triggerHit: true);
	}

	protected override void OnHasHitAnotherPlayerObject(IDamageable other)
	{
		//IL_0056: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && _bounces > 0)
		{
			nint num = (nint)this;
			int bounces = _bounces - 1;
			_bounces = bounces;
			Transform transform = base.AimForRandomEnemy();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
	}

	protected void OnHasHitAnObjectLogic(IDamageable other, bool triggerHit)
	{
		//IL_00ae: Expected I, but got O
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
				base.Despawn();
			}
		}
		else
		{
			nint num = (nint)this;
			int bounces = _bounces - 1;
			_bounces = bounces;
			Transform transform = base.AimForRandomEnemy();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
	}
}
