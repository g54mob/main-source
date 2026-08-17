using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class JetBlackWeapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass16_0
	{
		public int localIndex;

		public JetBlackWeapon _003C_003E4__this;

		internal void _003CFire_003Eb__0()
		{
			//IL_012f: Expected O, but got I4
			//IL_00b4: Expected O, but got I
			//IL_00e9: Expected I, but got O
			//IL_0079->IL00f8: Incompatible stack heights: 1 vs 0
			//IL_009e->IL00f8: Incompatible stack heights: 1 vs 0
			//IL_00dc->IL00f8: Incompatible stack heights: 1 vs 0
			if ((object)_003C_003E4__this != null)
			{
				GameObject gameObject = _003C_003E4__this.gameObject;
				if ((object)gameObject != null)
				{
					bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					object obj = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					if (obj == null)
					{
						return;
					}
					GameObject gameObject2 = (GameObject)(object)_003C_003E4__this;
					if ((object)_003C_003E4__this != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v7 (UnityEngine.GameObject)+58]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v7 (UnityEngine.GameObject)+58]");
							float2 position = ((ArcadeSprite)0).position;
							JetBlackWeapon jetBlackWeapon = _003C_003E4__this;
							if ((object)_003C_003E4__this != null)
							{
								nint num = (nint)gameObject2;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v246 @ r10_v2 (Il2CppClass<UnityEngine.GameObject>)+4D8] (should have been resolved before IL gen)");
								return;
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass18_0
	{
		public JetBlackWeapon _003C_003E4__this;

		public float2 _pos;
	}

	private sealed class _003C_003Ec__DisplayClass18_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass18_0 CS_0024_003C_003E8__locals1;

		internal void _003CSpawnExplosionsAt_003Eb__0()
		{
			//IL_0131: Expected O, but got I4
			//IL_00a8->IL00fa: Incompatible stack heights: 1 vs 0
			//IL_00ca->IL00fa: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass18_0 obj = CS_0024_003C_003E8__locals1;
			if (CS_0024_003C_003E8__locals1 != null && (object)obj._003C_003E4__this != null)
			{
				GameObject gameObject = obj._003C_003E4__this.gameObject;
				if ((object)gameObject != null)
				{
					bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					object obj2 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					if (obj2 == null)
					{
						return;
					}
					_003C_003Ec__DisplayClass18_0 obj3 = CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals1 != null && (object)obj3._003C_003E4__this != null)
					{
						float2 pos = default(float2);
						Projectile projectile = obj3._003C_003E4__this.SpawnExplosionAt(pos, localIndex, 1, 0f);
						return;
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private List<GravityWell> _gravityWells;

	private List<System.Numerics.Vector3> _offsets;

	private bool _initialisedParticles;

	private ParticleSystem ownerBloodVfx;

	private bool canFire = true;

	private float firingTimer;

	private float accumulatedDamage;

	private float accumulatedRecovery;

	public ParticleSystem DamageVfx;

	public override float PPower()
	{
		//IL_0055: Invalid comparison between F4 and I
		//IL_007c: Expected F4, but got I
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		PlayerModifierStats playerStats = characterController._playerStats;
		EggFloat eggFloat = playerStats._003CMagnet_003Ek__BackingField;
		float num = eggFloat._val;
		float val = eggFloat._val;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A104DC]");
		if (val < 0f)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A104DC]");
			num = 0f;
		}
		float num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
		float num3 = num2 * 0.5f;
		return num3 * num;
	}

	public override float SecondaryPPower()
	{
		//IL_00a9: Invalid comparison between F4 and I
		//IL_00d0: Expected F4, but got I
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			PlayerModifierStats playerStats = characterController._playerStats;
			if (characterController._playerStats != null)
			{
				EggFloat eggFloat = playerStats._003CMagnet_003Ek__BackingField;
				if (playerStats._003CMagnet_003Ek__BackingField != null)
				{
					float num = eggFloat._val;
					float val = eggFloat._val;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A104DC]");
					if (val < 0f)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A104DC]");
						num = 0f;
					}
					float num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
					WeaponData currentWeaponData = _currentWeaponData;
					if (_currentWeaponData != null && (object)((Equipment)this)._003COwner_003Ek__BackingField != null)
					{
						float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
						float num3 = currentWeaponData._003Cpower_003Ek__BackingField * num2;
						float num4 = num3 * num;
						float num5 = num4 + accumulatedDamage;
						float num6 = num5 + accumulatedRecovery;
						return num2 + num6;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	protected override void OnStart()
	{
		_explosionType = WeaponType.D20_JETBLACK_EXPLOSION;
		base.OnStart();
	}

	public unsafe override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0049: Expected O, but got Ref
		//IL_0058: Expected O, but got I4
		//IL_0066: Expected native int or pointer, but got O
		//IL_007f: Expected O, but got Ref
		//IL_0177: Expected O, but got I
		//IL_0193: Expected O, but got I4
		//IL_01ac: Expected O, but got Ref
		//IL_01c6: Expected native int or pointer, but got O
		//IL_03d7: Expected O, but got I4
		//IL_01de: Expected O, but got Ref
		//IL_01f8: Expected native int or pointer, but got O
		//IL_0212: Expected O, but got I
		//IL_0232: Expected O, but got Ref
		//IL_024c: Expected native int or pointer, but got O
		//IL_03f4: Expected O, but got I4
		//IL_027e: Expected O, but got Ref
		//IL_0298: Expected native int or pointer, but got O
		//IL_042e: Expected O, but got I
		//IL_02de: Expected O, but got I4
		//IL_0310: Expected O, but got I
		//IL_0468: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.InitWeapon(characterController, weaponType);
		firingTimer = 0f;
		accumulatedRecovery = 0f;
		if (!_initialisedParticles)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
			_initialisedParticles = true;
			ownerBloodVfx = characterController2._damageVfx;
			ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 16));
			_ = 0;
			obj = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(4f, 1f));
			ParticleSystem.MinMaxCurve minMaxCurve2 = default(ParticleSystem.MinMaxCurve);
			RenderingExtensions.SetScale(ownerBloodVfx, (ParticleSystem.MinMaxCurve)(&minMaxCurve2));
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
			List<string> list = new List<string>();
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"WhiteDot");
			}
			else
			{
				int size = list._size + 1;
				list._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig._frame = list;
			_ = 0;
			_ = 10;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+B0]");
			particleSystemConfig._quantity = (int?)(object)0;
			minMaxCurve2 = new ParticleSystem.MinMaxCurve(3000f);
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 16));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(1f, 0f));
			particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 48));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(225f, 315f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+30]");
			particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+40]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(75f, 125f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+60]");
			_ = 0;
			particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-78]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-68]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 112));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(4f, 1f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+70]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+80]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-60]");
			particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-40]");
			_ = 0;
			minMaxCurve2 = new ParticleSystem.MinMaxCurve(300f);
			particleSystemConfig._gravity = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			_ = 0;
			_ = 2228224;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+B0]");
			particleSystemConfig._tint = (uint?)(object)0;
			minMaxCurve2 = new ParticleSystem.MinMaxCurve(0.1f);
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-38]");
			particleSystemConfig._bounce = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-18]");
			_ = 0;
			particleSystemConfig._on = false;
			Transform parent = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
			ParticleSystem damageVfx = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, parent);
			DamageVfx = damageVfx;
		}
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 1000f;
		if (!canFire)
		{
			num = (firingTimer = num + firingTimer);
		}
		float num2 = base.PInterval();
		if (firingTimer > num)
		{
			firingTimer = 0f;
			canFire = true;
		}
	}

	public void OnPlayerHitDamage(float value)
	{
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null || ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		ParticleSystem damageVfx = DamageVfx;
		if ((object)DamageVfx == null || ((UnityEngine.Object)damageVfx).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		ParticleSystem particleSystem = ownerBloodVfx;
		if ((object)ownerBloodVfx != null && ((UnityEngine.Object)particleSystem).m_CachedPtr != (IntPtr)0)
		{
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			UnityEngine.Vector2 pos = default(UnityEngine.Vector2);
			RenderingExtensions.EmitParticleAt(DamageVfx, pos, 50);
			float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			RenderingExtensions.EmitParticleAt(ownerBloodVfx, pos, 25);
			if (canFire)
			{
				base.Fire();
				canFire = false;
			}
			else
			{
				float num = ((5f > accumulatedDamage) ? (value * 0.01f) : (value * 0.001f));
				float num2 = num + accumulatedDamage;
				accumulatedDamage = num2;
			}
		}
	}

	public void OnPlayerRecovery(float value)
	{
		//IL_00c1: Expected O, but got I4
		object obj = 388;
		float num = ((5f > accumulatedRecovery) ? (value * 0.005f) : (value * 0.001f));
		float num2 = accumulatedRecovery + num;
		if (canFire && !(value < 3.3f))
		{
			base.Fire();
			canFire = false;
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			UnityEngine.Vector2 pos = default(UnityEngine.Vector2);
			RenderingExtensions.EmitParticleAt(DamageVfx, pos, 50);
			float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			RenderingExtensions.EmitParticleAt(ownerBloodVfx, pos, 25);
		}
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0065: Invalid comparison between O and F4
		//IL_008f: Invalid comparison between O and F4
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		//IL_0104: Expected F4, but got O
		//IL_01d0: Invalid comparison between F4 and I4
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		UnityEngine.Vector2 vector = default(UnityEngine.Vector2);
		Projectile projectile = base.FireOneProjectile(vector, 0, _targetTransform);
		WeaponData currentWeaponData = _currentWeaponData;
		float num = currentWeaponData._003CrepeatInterval_003Ek__BackingField * 3f;
		float num2 = base.PAmount();
		if (System.Runtime.CompilerServices.Unsafe.As<UnityEngine.Vector2, UIntPtr>(ref vector) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f))
		{
			return;
		}
		float num3 = base.PAmount();
		if (System.Runtime.CompilerServices.Unsafe.As<UnityEngine.Vector2, UIntPtr>(ref vector) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f))
		{
			return;
		}
		bool flag = true;
		float num4;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		do
		{
			WeaponData currentWeaponData2 = _currentWeaponData;
			object obj = flag * currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
			if ((nint)obj <= 0)
			{
				UnityEngine.Vector2 playerPos = base.PlayerPos;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
				num4 = (float)playerPos;
			}
			else
			{
				_003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass16_0();
				CS_0024_003C_003E8__locals8._003C_003E4__this = this;
				CS_0024_003C_003E8__locals8.localIndex = (flag ? 1 : 0);
				Action onComplete = delegate
				{
					//IL_012f: Expected O, but got I4
					//IL_00b4: Expected O, but got I
					//IL_00e9: Expected I, but got O
					//IL_0079->IL00f8: Incompatible stack heights: 1 vs 0
					//IL_009e->IL00f8: Incompatible stack heights: 1 vs 0
					//IL_00dc->IL00f8: Incompatible stack heights: 1 vs 0
					if ((object)CS_0024_003C_003E8__locals8._003C_003E4__this != null)
					{
						GameObject gameObject = CS_0024_003C_003E8__locals8._003C_003E4__this.gameObject;
						if ((object)gameObject != null)
						{
							bool flag2 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
							object obj2 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
							if (obj2 == null)
							{
								return;
							}
							GameObject gameObject2 = (GameObject)(object)CS_0024_003C_003E8__locals8._003C_003E4__this;
							if ((object)CS_0024_003C_003E8__locals8._003C_003E4__this != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v7 (UnityEngine.GameObject)+58]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v7 (UnityEngine.GameObject)+58]");
									float2 position2 = ((ArcadeSprite)0).position;
									JetBlackWeapon jetBlackWeapon = CS_0024_003C_003E8__locals8._003C_003E4__this;
									if ((object)CS_0024_003C_003E8__locals8._003C_003E4__this != null)
									{
										nint num7 = (nint)gameObject2;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v246 @ r10_v2 (Il2CppClass<UnityEngine.GameObject>)+4D8] (should have been resolved before IL gen)");
										return;
									}
								}
							}
						}
					}
					throw new NullReferenceException();
				};
				float num5 = (float)(flag ? 1 : 0) * num;
				num4 = num5 * 0.001f;
				Timer lastShotTimer = Timers.Register(num4, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				_lastShotTimer = lastShotTimer;
			}
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
			float num6 = base.PAmount();
		}
		while (num4 > (float)(flag ? 1 : 0));
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public void SpawnExplosionsAt(float2 _pos)
	{
		//IL_0040: Expected O, but got F4
		//IL_00a1: Expected O, but got I4
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		//IL_0128: Expected I4, but got O
		//IL_00ef: Expected I4, but got O
		//IL_00ef: Expected O, but got F4
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Expected O, but got Unknown
		//IL_01d9: Invalid comparison between F4 and O
		_003C_003Ec__DisplayClass18_0 obj = new _003C_003Ec__DisplayClass18_0();
		obj._003C_003E4__this = this;
		obj._pos = _pos;
		float num = default(float);
		Projectile projectile = base.SpawnExplosionAt((float2)num, 0, 1, 0f);
		float num2 = base.PAmount();
		if (!(num > 1f))
		{
			return;
		}
		float num3 = base.PAmount();
		if (!(num > 1f))
		{
			return;
		}
		Action<float> action = (Action<float>)1;
		float num4;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		do
		{
			WeaponData currentWeaponData = _currentWeaponData;
			object obj2 = action * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
			if ((nint)obj2 <= 0)
			{
				Projectile projectile2 = base.SpawnExplosionAt((float2)num, (int)action, 1, 0f);
				num4 = num;
			}
			else
			{
				_003C_003Ec__DisplayClass18_1 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass18_1();
				CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1 = obj;
				CS_0024_003C_003E8__locals7.localIndex = (int)action;
				WeaponData currentWeaponData2 = _currentWeaponData;
				Action onComplete = delegate
				{
					//IL_0131: Expected O, but got I4
					//IL_00a8->IL00fa: Incompatible stack heights: 1 vs 0
					//IL_00ca->IL00fa: Incompatible stack heights: 1 vs 0
					_003C_003Ec__DisplayClass18_0 obj3 = CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1 != null && (object)obj3._003C_003E4__this != null)
					{
						GameObject gameObject = obj3._003C_003E4__this.gameObject;
						if ((object)gameObject != null)
						{
							bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
							object obj4 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
							if (obj4 == null)
							{
								return;
							}
							_003C_003Ec__DisplayClass18_0 obj5 = CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1;
							if (CS_0024_003C_003E8__locals7.CS_0024_003C_003E8__locals1 != null && (object)obj5._003C_003E4__this != null)
							{
								float2 pos = default(float2);
								Projectile projectile3 = obj5._003C_003E4__this.SpawnExplosionAt(pos, CS_0024_003C_003E8__locals7.localIndex, 1, 0f);
								return;
							}
						}
					}
					throw new NullReferenceException();
				};
				float num5 = (float)action * currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
				num4 = num5 * 0.001f;
				Timer lastShotTimer = Timers.Register(num4, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				_lastShotTimer = lastShotTimer;
			}
			action = (Action<float>)(action + 1);
			float num6 = base.PAmount();
		}
		while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num4) > System.Runtime.CompilerServices.Unsafe.As<Action<float>, UIntPtr>(ref action));
	}
}
