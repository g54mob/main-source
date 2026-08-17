using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Profiling;
using Unity.Profiling.LowLevel;
using Unity.Profiling.LowLevel.Unsafe;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class MagicMissileProjectile : Projectile
{
	private float _IndexOffsetScaleFactor = 0.1f;

	private ParticleEmitterManager _pfxManager;

	private ParticleSystem _pfx;

	private MagicMissileWeapon _trueWeapon;

	private static readonly ProfilerMarker _markerInitProjectile;

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0045: Expected O, but got I4
		//IL_0045: Expected O, but got I4
		//IL_0086: Expected O, but got I4
		//IL_00ce: Expected I, but got O
		//IL_00d6: Expected I, but got O
		//IL_00e6: Expected O, but got I
		//IL_0166: Expected O, but got I4
		//IL_0122: Expected O, but got I
		//IL_0158: Expected O, but got I4
		//IL_0410: Expected O, but got F4
		//IL_0337: Expected O, but got F4
		//IL_0398: Expected O, but got Ref
		//IL_03e3: Expected O, but got I4
		//IL_0204->IL0285: Incompatible stack heights: 4 vs 0
		//IL_0233->IL0285: Incompatible stack heights: 4 vs 0
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite sprite = _sprite;
		Weapon trueWeapon;
		object obj3;
		if ((object)_sprite != null && sprite.body != null)
		{
			BaseBody baseBody = sprite.body.setCircle(8f, (float?)(object)0, (float?)(object)0);
			if ((object)_weapon != null)
			{
				float num = _weapon.PArea();
				float xScale = default(float);
				ArcadeSprite arcadeSprite = setScale(xScale, (float?)(object)0);
				GenerateParticleSystem();
				if ((object)weapon == null)
				{
					trueWeapon = null;
					goto IL_02c7;
				}
				nint num2 = (nint)typeof(MagicMissileWeapon);
				nint num3 = (nint)weapon;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ rdx_v29 (Il2CppClass<VampireSurvivors.Objects.Weapons.MagicMissileWeapon>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ r8_v19 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ rdx_v29 (Il2CppClass<VampireSurvivors.Objects.Weapons.MagicMissileWeapon>)+130]");
				if (num4 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ r8_v19 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ rax_v72+FFFFFFF8+v307 @ rax_v67*8]");
					if (0 == (nint)typeof(MagicMissileWeapon))
					{
						obj3 = 1;
						goto IL_02d6;
					}
				}
				obj3 = 0;
				goto IL_02d6;
			}
		}
		goto IL_0285;
		IL_02d6:
		bool flag = obj3 == null;
		trueWeapon = null;
		if (!flag)
		{
			trueWeapon = weapon;
		}
		goto IL_02c7;
		IL_02c7:
		_trueWeapon = (MagicMissileWeapon)trueWeapon;
		Weapon cachedTransform = (Weapon)(object)_cachedTransform;
		if ((object)_cachedTransform != null)
		{
			bool flag2 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
			object obj4 = UnityEngine.Random.value;
			object obj5 = UnityEngine.Random.value;
			bool flag3 = (object)_trueWeapon == null;
			Weapon cachedTransform2 = (Weapon)(object)_cachedTransform;
			bool flag4 = (object)_cachedTransform == null;
			bool flag5 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_position_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, ref value);
			object obj6 = default(object);
			Transform transform = base.AimForNearestEnemyFrom(_cachedTransform, rotate: true, (Vector3?)(object)(&obj6));
			if (_indexInWeapon >= 7)
			{
				return;
			}
			Weapon weapon2 = _weapon;
			if ((object)_weapon != null)
			{
				WeaponData currentWeaponData = weapon2._currentWeaponData;
				if (weapon2._currentWeaponData != null)
				{
					if ((object)currentWeaponData._003Cvolume_003Ek__BackingField != null)
					{
					}
					SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
					{
						Rate = 1f,
						Volume = (float?)(object)1
					};
					float detune = (float)_indexInWeapon * -100f;
					soundConfig.Detune = detune;
					float time = default(float);
					PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.MagicMissile, soundConfig, 200f, 12, time);
					return;
				}
			}
		}
		goto IL_0285;
		IL_0285:
		throw new NullReferenceException();
	}

	private unsafe void GenerateParticleSystem()
	{
		//IL_0008: Expected O, but got Ref
		//IL_01dd: Expected O, but got Ref
		//IL_01f7: Expected native int or pointer, but got O
		//IL_0381: Expected O, but got I4
		//IL_020f: Expected O, but got Ref
		//IL_0236: Expected O, but got I
		//IL_024b: Expected native int or pointer, but got O
		//IL_0265: Expected O, but got I
		//IL_0285: Expected O, but got Ref
		//IL_029f: Expected native int or pointer, but got O
		//IL_039e: Expected O, but got I4
		//IL_02b7: Expected O, but got Ref
		//IL_02d1: Expected native int or pointer, but got O
		//IL_03c8: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystem pfx = _pfx;
		if ((object)_pfx == null || ((UnityEngine.Object)pfx).m_CachedPtr == (IntPtr)0)
		{
			GameObject gameObject = base.gameObject;
			ParticleEmitterManager pfxManager = gameObject.AddComponent<ParticleEmitterManager>();
			_pfxManager = pfxManager;
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
			List<string> list = new List<string>();
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"PfxHoly1.png");
			}
			else
			{
				int num = list._size + 1;
				list._size = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version2 = list._version + 1;
			list._version = version2;
			string[] items2 = list._items;
			if (list._size >= items2.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"PfxHoly2.png");
			}
			else
			{
				int num2 = list._size + 1;
				list._size = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig._frame = list;
			ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 88));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(15.000001f, 30.000002f));
			particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 56));
			_ = 0;
			_ = 1;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+50]");
			particleSystemConfig._quantity = (int?)(object)0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(300f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-38]");
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-28]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(1f, 0f));
			particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 1f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+18]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
			particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-70]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-60]");
			_ = 0;
			particleSystemConfig._on = false;
			Transform parent = base.transform;
			ParticleSystem pfx2 = _pfxManager.CreateEmitter(particleSystemConfig, parent);
			_pfx = pfx2;
		}
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

	private void OnHasHitAnObjectLogic(IDamageable other, bool triggerHit)
	{
		//IL_00ef: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		if (_bounces <= 0)
		{
			if (triggerHit)
			{
				if (--_penetrating <= 0)
				{
					base.Despawn();
				}
				if (_weapon.HasActiveArcanaOfType(ArcanaType.T14_JEWELS))
				{
					bool flag = TryFreeze(other);
				}
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

	public override void InternalUpdate()
	{
		//IL_0068->IL009b: Incompatible stack heights: 1 vs 0
		ParticleSystem pfx = _pfx;
		if ((object)_pfx != null && ((UnityEngine.Object)pfx).m_CachedPtr != (IntPtr)0)
		{
			object cachedTransform = _cachedTransform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rbx_v4 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rbx_v4 (System.Object)+10]");
			Transform.get_position_Injected((IntPtr)0, out Vector3 _);
			Vector2 pos = default(Vector2);
			_pfxManager.EmitParticleAt(pos);
		}
	}

	static MagicMissileProjectile()
	{
		//IL_002b: Expected O, but got I
		IntPtr intPtr = ProfilerUnsafeUtility.CreateMarker("MagicMissileProjectile.InitProjectile", 1, MarkerFlags.Default, 0);
		_markerInitProjectile = (ProfilerMarker)(nint)intPtr;
	}
}
