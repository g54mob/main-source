using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Gun1_Projectile : Projectile
{
	protected Timer _despawnTimer;

	private List<Projectile> shrapnelHitboxes;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("ProjectileBullet3", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_009b: Invalid comparison between F4 and I4
		//IL_00c4: Expected O, but got Ref
		//IL_00d1: Expected O, but got I4
		//IL_0130: Expected O, but got Ref
		//IL_0178: Expected O, but got I4
		//IL_0178: Expected O, but got I4
		//IL_0536: Expected O, but got F4
		//IL_0564: Expected O, but got I4
		//IL_02df: Expected O, but got I
		//IL_0338: Invalid comparison between I and F4
		//IL_03e2: Expected I, but got O
		//IL_042d: Expected I4, but got F4
		//IL_00fa->IL0441: Incompatible stack heights: 6 vs 0
		//IL_011c->IL0441: Incompatible stack heights: 6 vs 0
		//IL_0158->IL0441: Incompatible stack heights: 6 vs 0
		//IL_01dc->IL0441: Incompatible stack heights: 6 vs 0
		//IL_023c->IL0441: Incompatible stack heights: 6 vs 0
		//IL_026b->IL0441: Incompatible stack heights: 6 vs 0
		//IL_028d->IL0441: Incompatible stack heights: 6 vs 0
		//IL_02ff->IL0441: Incompatible stack heights: 7 vs 0
		//IL_0366->IL0441: Incompatible stack heights: 8 vs 0
		//IL_03b5->IL0441: Incompatible stack heights: 8 vs 0
		base.InitProjectile(pool, weapon, index);
		Transform cachedTransform = _cachedTransform;
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
			Transform cachedTransform2 = _cachedTransform;
			bool flag2 = (object)_cachedTransform == null;
			bool flag3 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_position_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, ref value);
			BaseBody baseBody = body;
			bool flag4 = body == null;
			baseBody._enable = true;
			_speed = 5f;
			SetScaleToArea();
			Weapon weapon2 = _weapon;
			bool flag5 = (object)_weapon == null;
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
			bool flag6 = (object)((Equipment)weapon2)._003COwner_003Ek__BackingField == null;
			object obj;
			if (!(characterController._walked > 0f))
			{
				Transform transform = base.AimForNearestEnemyFrom(_cachedTransform, rotate: true, (Vector3?)(object)(&value));
				obj = 0;
			}
			else
			{
				Weapon weapon3 = _weapon;
				if ((object)_weapon == null || (object)((Equipment)weapon3)._003COwner_003Ek__BackingField == null)
				{
					goto IL_0441;
				}
				ApplyPlayerFacingVelocity((Vector3)(&value));
				object obj2 = default(object);
				obj = obj2;
			}
			if (body != null)
			{
				BaseBody baseBody2 = body.setCircle(4f, (float?)(object)0, (float?)(object)0);
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
				{
					Rate = 2f
				};
				object obj3 = UnityEngine.Random.value;
				float num = (float)obj - 0.5f;
				float detune = num * 200f;
				soundConfig.Volume = (float?)(object)1;
				soundConfig.Detune = detune;
				float num2 = default(float);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_SwordFire, soundConfig, 100f, 1, num2);
				Weapon weapon4 = _weapon;
				if ((object)_weapon != null)
				{
					Weapon weapon5 = _weapon;
					List<float> critChancesArray = weapon4._critChancesArray;
					int critIndex = weapon5._critIndex + 1;
					weapon5._critIndex = critIndex;
					Weapon weapon6 = _weapon;
					if ((object)_weapon != null)
					{
						List<float> critChancesArray2 = weapon6._critChancesArray;
						if (weapon6._critChancesArray != null && weapon4._critChancesArray != null)
						{
							int critIndex2 = weapon5._critIndex;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ r9_v14 (System.Collections.Generic.List`1<System.Single>)+18]");
							int num3 = (int)((nint)critIndex2 % (nint)0);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ r8_v15 (System.Collections.Generic.List`1<System.Single>)+18]");
							bool flag7 = (nint)num3 >= (nint)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ r8_v15 (System.Collections.Generic.List`1<System.Single>)+10]");
							object obj4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ r8_v15 (System.Collections.Generic.List`1<System.Single>)+10]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rcx_v36+18]");
								bool flag8 = (nint)num3 >= (nint)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rcx_v36+20+v125 @ rdx_v23 (System.Int32)*4]");
								bool bounces;
								if (!(0f < 0.5f))
								{
									if ((object)_weapon == null)
									{
										goto IL_0441;
									}
									bounces = (byte)_weapon.PBounces() != 0;
								}
								else
								{
									bounces = false;
								}
								_bounces = (bounces ? 1 : 0);
								ArcadeSprite arcadeSprite = setVisible(visible: true);
								if (_despawnTimer != null)
								{
									_despawnTimer.Cancel();
								}
								if ((object)weapon != null)
								{
									float num4 = weapon.PDuration();
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1095 @ r8_v17 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Gun1_Projectile>)+370]");
									Action onComplete = new Action(this, (IntPtr)0);
									nint num5 = (nint)this;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rcx_v36+20+v125 @ rdx_v23 (System.Int32)*4]");
									float duration = 0f * 0.001f;
									MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
									int repeat = default(int);
									TimerType type = default(TimerType);
									Timer despawnTimer = Timers.Register(duration, onComplete, null, isLooped: false, (byte)(int)num2 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
									_despawnTimer = despawnTimer;
									return;
								}
							}
						}
					}
				}
			}
		}
		goto IL_0441;
		IL_0441:
		throw new NullReferenceException();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		//IL_00b8: Expected I, but got O
		//IL_00c0: Expected I, but got O
		//IL_00d0: Expected O, but got I
		//IL_010c: Expected O, but got I
		//IL_0149: Expected O, but got I
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		//IL_01ae: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null || --_penetrating > 0)
		{
			return;
		}
		Weapon weapon = _weapon;
		float2 float5 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07BB0");
		Transform cachedTrans = ((ArcadeSprite)this).CachedTrans;
		Vector3 localEulerAngles = cachedTrans.localEulerAngles;
		nint num = (nint)typeof(TP_Gun1_Weapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Gun1_Weapon>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Gun1_Weapon>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v9+FFFFFFF8+v76 @ rcx_v8*8]");
			if (0 == (nint)typeof(TP_Gun1_Weapon))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Gun1_Weapon>)+130]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v9+FFFFFFF8+v256 @ rdx_v7*8]");
				object obj5 = 0 - typeof(TP_Gun1_Weapon);
				bool flag = obj5 == null;
				bool flag2 = !flag;
				Weapon weapon2 = null;
				if (!flag2)
				{
					weapon2 = weapon;
				}
				nint num4 = (nint)weapon2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v183 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+5B8] (should have been resolved before IL gen)");
				Despawn();
				return;
			}
		}
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		if (_despawnTimer != null)
		{
			_despawnTimer.Cancel();
		}
		base.Despawn();
	}
}
