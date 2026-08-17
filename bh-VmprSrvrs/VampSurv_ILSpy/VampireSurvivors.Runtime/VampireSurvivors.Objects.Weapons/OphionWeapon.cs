using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class OphionWeapon : Weapon
{
	private ParticleEmitterManager _pfxEmitter;

	private GravityWell _well;

	private WeaponType _counterWeaponType = WeaponType.SHADOWSERVANT_COUNTER;

	private ShadowServantCounterWeapon _counterWeapon;

	protected unsafe override void Awake()
	{
		//IL_0008: Expected O, but got Ref
		//IL_02c8: Expected O, but got Ref
		//IL_02e2: Expected native int or pointer, but got O
		//IL_02fc: Expected O, but got I
		//IL_031c: Expected O, but got Ref
		//IL_0336: Expected native int or pointer, but got O
		//IL_0350: Expected O, but got I
		//IL_0370: Expected O, but got Ref
		//IL_038a: Expected native int or pointer, but got O
		//IL_0593: Expected O, but got I4
		//IL_03a2: Expected O, but got Ref
		//IL_03c9: Expected O, but got I
		//IL_03de: Expected native int or pointer, but got O
		//IL_03f8: Expected O, but got I
		//IL_0418: Expected O, but got Ref
		//IL_0432: Expected native int or pointer, but got O
		//IL_05b0: Expected O, but got I4
		//IL_044a: Expected O, but got Ref
		//IL_0464: Expected native int or pointer, but got O
		//IL_05da: Expected O, but got I
		//IL_0503: Expected O, but got I
		//IL_0518: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.Awake();
		GameObject gameObject = base.gameObject;
		ParticleEmitterManager pfxEmitter = gameObject.AddComponent<ParticleEmitterManager>();
		_pfxEmitter = pfxEmitter;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"OPpfx");
		}
		else
		{
			int size = list._size + 1;
			list._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list._version + 1;
		list._version = version2;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"OPpfx2");
		}
		else
		{
			int size2 = list._size + 1;
			list._size = size2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version3 = list._version + 1;
		list._version = version3;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PfxPurple2");
		}
		else
		{
			int size3 = list._size + 1;
			list._size = size3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version4 = list._version + 1;
		list._version = version4;
		string[] items4 = list._items;
		if (list._size >= items4.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PfxPurple3");
		}
		else
		{
			int size4 = list._size + 1;
			list._size = size4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 88));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-58]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-48]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 56));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-38]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-28]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(1f, 400f));
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
		_ = 0;
		_ = 4;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+B0]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(400f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+8]");
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+18]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(0.65f, 0f));
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+48]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+58]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-80]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-70]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-60]");
		_ = 0;
		particleSystemConfig._on = false;
		ParticleSystem particleSystem = _pfxEmitter.CreateEmitter(particleSystemConfig);
		GravityWellConfig gravityWellConfig = new GravityWellConfig();
		_ = 0;
		_ = 0;
		_ = 1;
		_ = 0;
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+B0]");
		gravityWellConfig._y = (float?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+B0]");
		gravityWellConfig._x = (float?)(object)0;
		gravityWellConfig._power = 10f;
		gravityWellConfig._epsilon = 500f;
		gravityWellConfig._gravity = 200f;
		GravityWell well = _pfxEmitter.CreateGravityWell(gravityWellConfig, null, "Well");
		_well = well;
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		_skipAddingEvolution = true;
		base.InitWeapon(characterController, weaponType);
	}

	public override void CheckArcanas()
	{
		//IL_01a2: Expected I, but got O
		//IL_01b0: Expected I, but got O
		//IL_01c0: Expected O, but got I
		//IL_0240: Expected O, but got I4
		//IL_01fc: Expected O, but got I
		//IL_0232: Expected O, but got I4
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rcx_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				HasCooldownSpeedBonus = true;
				IsHoming = true;
			}
		}
		GameManager core = GM.Core;
		ArcanaManager arcanaManager2 = core._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj2 = default(object);
		if ((nint)obj2 <= -1)
		{
			goto IL_0277;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		Weapon weaponByType = characterController._weaponsManager.GetWeaponByType(_counterWeaponType, searchHidden: true);
		if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
		{
			return;
		}
		GameManager core2 = GM.Core;
		bool allowDuplicates = default(bool);
		Weapon weapon = core2._weaponsFacade.AddHiddenWeapon(_counterWeaponType, ((Equipment)this)._003COwner_003Ek__BackingField, removeFromStore: true, allowDuplicates);
		bool flag = (object)weapon == null;
		Weapon weapon2 = null;
		if (flag)
		{
			goto IL_02b8;
		}
		nint num = (nint)weapon;
		nint num2 = (nint)typeof(ShadowServantCounterWeapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v499 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Weapons.ShadowServantCounterWeapon>)+130]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v498 @ r9_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v499 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Weapons.ShadowServantCounterWeapon>)+130]");
		object obj5;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v498 @ r9_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v552 @ rax_v42+FFFFFFF8+v500 @ rax_v38*8]");
			if (0 == (nint)typeof(ShadowServantCounterWeapon))
			{
				obj5 = 1;
				goto IL_02c7;
			}
		}
		obj5 = 0;
		goto IL_02c7;
		IL_02c7:
		bool flag2 = obj5 == null;
		weapon2 = null;
		if (!flag2)
		{
			weapon2 = weapon;
		}
		goto IL_02b8;
		IL_0277:
		CheckBeginningArcana();
		return;
		IL_02b8:
		_counterWeapon = (ShadowServantCounterWeapon)weapon2;
		weapon2._skipAddingEvolution = true;
		while (((Equipment)weapon2)._003CLevel_003Ek__BackingField < ((Equipment)this)._003CLevel_003Ek__BackingField)
		{
			bool flag3 = weapon2.LevelUp();
		}
		goto IL_0277;
	}

	public override bool LevelUp()
	{
		//IL_0077: Expected I4, but got O
		bool result = LevelUp(skipFire: false);
		ShadowServantCounterWeapon counterWeapon = _counterWeapon;
		if ((object)_counterWeapon != null && ((UnityEngine.Object)counterWeapon).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_counterWeapon == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			bool flag = _counterWeapon.LevelUp();
		}
		return result;
	}

	protected override void OnUpdate()
	{
		if ((object)_well != null)
		{
			Transform transform = _well.transform;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0226: Expected I4, but got O
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Expected O, but got Unknown
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				EnemyController component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					if (component._003CIsDead_003Ek__BackingField)
					{
						goto IL_0243;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							Projectile component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 != null)
							{
								if (!component2.HasAlreadyHitObject(component))
								{
									float num = base.PPower();
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001873AE383h\"");
									object obj = default(object);
									HitVfxType hitVfxType = ((obj == null) ? HitVfxType.Default : HitVfxType.None);
									object obj2 = hitVfxType & (_003F?)component._003CResRosary_003Ek__BackingField;
									bool flag = obj2 == null;
									float num3 = default(float);
									float num2 = num3;
									if (!flag)
									{
										float chanceFromArray = base.GetChanceFromArray();
										WeaponData currentWeaponData = _currentWeaponData;
										if (_currentWeaponData == null || (object)((Equipment)this)._003COwner_003Ek__BackingField == null)
										{
											goto IL_0218;
										}
										float num4 = ((Equipment)this)._003COwner_003Ek__BackingField.PLuck();
										float num5 = num3 * currentWeaponData._003Cchance_003Ek__BackingField;
										bool flag2 = !(num5 > num3);
										num2 = num3;
										if (!flag2)
										{
											num2 = component._hp;
										}
									}
									WeaponData currentWeaponData2 = _currentWeaponData;
									bool flag3 = _currentWeaponData == null;
									HitVfxType showHitVfx = HitVfxType.Default;
									if (!flag3)
									{
										showHitVfx = currentWeaponData2._003ChitVFX_003Ek__BackingField;
									}
									float knockback = base.Knockback;
									component.GetDamaged(num2, showHitVfx, knockback, WeaponType.VOID, hasKb: false);
									float num6 = num2 + base._003CStatsInflictedDamage_003Ek__BackingField;
									base._003CStatsInflictedDamage_003Ek__BackingField = num6;
								}
								goto IL_0243;
							}
						}
					}
				}
			}
		}
		goto IL_0218;
		IL_0243:
		return false;
		IL_0218:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}
}
