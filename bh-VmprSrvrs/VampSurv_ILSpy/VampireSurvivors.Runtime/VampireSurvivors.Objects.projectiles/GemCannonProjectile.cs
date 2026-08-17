using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class GemCannonProjectile : Projectile
{
	private ParticleEmitterManager _pfxManager;

	private ParticleSystem _pfxEmitter;

	private void Start()
	{
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0070: Expected O, but got I4
		//IL_0070: Expected O, but got I4
		//IL_0084: Expected O, but got I4
		//IL_0092: Expected I4, but got O
		//IL_0483: Expected O, but got F4
		//IL_0378: Expected O, but got F4
		//IL_0383: Expected I4, but got O
		//IL_0430: Expected O, but got I4
		//IL_019c: Expected O, but got Ref
		//IL_01d8: Expected I, but got O
		//IL_01e0: Expected I, but got O
		//IL_01f0: Expected O, but got I
		//IL_0270: Expected O, but got I4
		//IL_046c: Expected O, but got I4
		//IL_022c: Expected O, but got I
		//IL_0262: Expected O, but got I4
		//IL_0294: Expected O, but got I
		//IL_02fe: Expected O, but got I
		//IL_0151->IL0316: Incompatible stack heights: 5 vs 0
		//IL_017d->IL0316: Incompatible stack heights: 5 vs 0
		base.InitProjectile(pool, weapon, index);
		Sprite sprite = SpriteManager.GetSprite("GemBlue", "items");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		GenerateParticleSystem();
		object obj5;
		if (body != null)
		{
			BaseBody baseBody = body.setCircle(8f, (float?)(object)0, (float?)(object)0);
			ArcadeSprite arcadeSprite2 = setScale(1f, (float?)(object)0);
			int num = (int)_cachedTransform;
			if ((object)_cachedTransform != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rsi_v10 (System.Int32)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rsi_v10 (System.Int32)+10]");
				Transform.get_position_Injected((IntPtr)0, out Vector3 _);
				object obj = UnityEngine.Random.value;
				object obj2 = UnityEngine.Random.value;
				int num2 = (int)_cachedTransform;
				bool flag2 = (object)_cachedTransform == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ rsi_v11 (System.Int32)+10]");
				bool flag3 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ rsi_v11 (System.Int32)+10]");
				Vector3 value = default(Vector3);
				Transform.set_position_Injected((IntPtr)0, ref value);
				Transform transform = base.AimForRandomEnemy();
				Weapon weapon2 = _weapon;
				bool flag4 = (object)_weapon == null;
				WeaponData currentWeaponData = weapon2._currentWeaponData;
				bool flag5 = weapon2._currentWeaponData == null;
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
				if ((object)_renderer != null)
				{
					Transform transform2 = _renderer.transform;
					if ((object)transform2 != null)
					{
						Vector3 localEulerAngles = transform2.localEulerAngles;
						transform2.localEulerAngles = (Vector3)(&value);
						Weapon weapon3 = _weapon;
						if ((object)_weapon == null)
						{
							return;
						}
						nint num3 = (nint)typeof(GemCannonWeapon);
						nint num4 = (nint)weapon3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v897 @ rdx_v28 (Il2CppClass<VampireSurvivors.Objects.Weapons.GemCannonWeapon>)+130]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v898 @ r8_v18 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
						nint num5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v897 @ rdx_v28 (Il2CppClass<VampireSurvivors.Objects.Weapons.GemCannonWeapon>)+130]");
						if (num5 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v898 @ r8_v18 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
							object obj4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v968 @ rax_v66+FFFFFFF8+v899 @ rax_v57*8]");
							if (0 == (nint)typeof(GemCannonWeapon))
							{
								obj5 = 1;
								goto IL_0454;
							}
						}
						obj5 = 0;
						goto IL_0454;
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_0454:
		bool flag6 = obj5 == null;
		float? num6 = (float?)(object)0;
		if (!flag6)
		{
			num6 = (float?)_weapon;
		}
		if ((object)num6 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v914 @ rdi_v4 (System.Nullable`1<System.Single>)+168]");
			string text = (string)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v914 @ rdi_v4 (System.Nullable`1<System.Single>)+168]");
			if ((nint)0 != 0 && text._stringLength > 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v914 @ rdi_v4 (System.Nullable`1<System.Single>)+168]");
				Sprite sprite2 = SpriteManager.GetSprite((string)0, "items");
				ArcadeSprite arcadeSprite3 = setFrame(sprite2);
			}
		}
	}

	public override void InternalUpdate()
	{
		//IL_005b: Expected I, but got O
		//IL_0168: Expected F4, but got O
		//IL_0114->IL00c3: Incompatible stack heights: 1 vs 0
		//IL_0075->IL00c3: Incompatible stack heights: 1 vs 0
		//IL_00a4->IL00c3: Incompatible stack heights: 1 vs 0
		Transform cachedTransform = _cachedTransform;
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 ret);
			if ((object)_pfxManager != null)
			{
				Vector2 pos = default(Vector2);
				_pfxManager.EmitParticleAt(pos, 5);
				ArcadeSprite sprite = _sprite;
				nint num = (nint)_cachedTransform;
				if ((object)_sprite != null)
				{
					BaseBody baseBody = sprite.body;
					if (sprite.body != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
						Quaternion.AngleAxis_Injected((float)_pfxManager, ref ret, out Quaternion _);
						bool flag2 = (object)_cachedTransform == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rsi_v9 (System.IntPtr)+10]");
						bool flag3 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rsi_v9 (System.IntPtr)+10]");
						Quaternion value = default(Quaternion);
						Transform.set_rotation_Injected((IntPtr)0, ref value);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && --_penetrating <= 0)
		{
			base.Despawn();
		}
	}

	private unsafe void GenerateParticleSystem()
	{
		//IL_0008: Expected O, but got Ref
		//IL_01dd: Expected O, but got Ref
		//IL_01f7: Expected native int or pointer, but got O
		//IL_0373: Expected O, but got I
		//IL_022f: Expected O, but got Ref
		//IL_0256: Expected O, but got I
		//IL_026b: Expected native int or pointer, but got O
		//IL_0285: Expected O, but got I
		//IL_02a5: Expected O, but got Ref
		//IL_02bf: Expected native int or pointer, but got O
		//IL_03ad: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystem pfxEmitter = _pfxEmitter;
		if ((object)_pfxEmitter == null || ((UnityEngine.Object)pfxEmitter).m_CachedPtr == (IntPtr)0)
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
				((List<object>)(object)list).AddWithResize((object)"PfxColor1");
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
				((List<object>)(object)list).AddWithResize((object)"PfxColor2");
			}
			else
			{
				int num2 = list._size + 1;
				list._size = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig._frame = list;
			ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(15.000001f, 30.000002f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-19]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-9]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-69]");
			particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-59]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-49]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
			_ = 0;
			_ = 1;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
			particleSystemConfig._quantity = (int?)(object)0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(300f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+7]");
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+17]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 39));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(1f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+27]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+37]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-41]");
			particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-31]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-21]");
			_ = 0;
			particleSystemConfig._on = false;
			ParticleSystem pfxEmitter2 = _pfxManager.CreateEmitter(particleSystemConfig, null, "PfxEmitter");
			_pfxEmitter = pfxEmitter2;
		}
	}
}
