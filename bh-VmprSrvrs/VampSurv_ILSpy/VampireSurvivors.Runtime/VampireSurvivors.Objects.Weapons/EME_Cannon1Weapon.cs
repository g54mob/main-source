using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class EME_Cannon1Weapon : EME_Weapon
{
	private const float QUANTISATION_STEP = 1f;

	private const float SECONDS_TO_ROTATE_AIM_360 = 0.9f;

	protected float _amount;

	private float _firingAngleDegrees;

	private List<float> _shuffledIndexes;

	protected override int EvolutionLevel => 6;

	protected override int _comboIndex1 => 3;

	protected override int _comboIndex2 => 6;

	protected override int _comboIndex3 => 9;

	protected override int ComboIndexFinal => base.ComboIndex1;

	protected override WeaponType GetWeaponTypeForGlimmerLevel(int level)
	{
		//IL_000e: Expected O, but got I4
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		object obj = level - 1;
		object obj2 = default(object);
		if (obj2 == null)
		{
			object obj3 = obj - 1;
			if (obj2 == null)
			{
				if ((nint)obj3 != 1)
				{
					return WeaponType.VOID;
				}
				return WeaponType.EME_CANNON_TECH_03;
			}
			return WeaponType.EME_CANNON_TECH_02;
		}
		return WeaponType.EME_CANNON_TECH_01;
	}

	protected override void InitGlimmer1BulletPool()
	{
		//IL_0137: Expected I, but got O
		Projectile glimmer1Prefab = _Glimmer1Prefab;
		if ((object)_Glimmer1Prefab != null && ((UnityEngine.Object)glimmer1Prefab).m_CachedPtr != (IntPtr)0)
		{
			BulletPool glimmer1Pool = new BulletPool(_Glimmer1Prefab, 20);
			_glimmer1Pool = glimmer1Pool;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			ArcadePhysicsCallback collideCallback = OnBulletOverlapsEnemyHighDamage;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = physics.add.overlap(_glimmer1Pool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core == null)
			{
				throw new NullReferenceException();
			}
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Cannon1Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			Collider collider2 = physics2.add.overlap(_glimmer1Pool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
		}
	}

	protected override void InitGlimmer2BulletPool()
	{
		//IL_0137: Expected I, but got O
		Projectile glimmer2Prefab = _Glimmer2Prefab;
		if ((object)_Glimmer2Prefab != null && ((UnityEngine.Object)glimmer2Prefab).m_CachedPtr != (IntPtr)0)
		{
			BulletPool glimmer2Pool = new BulletPool(_Glimmer2Prefab, 20);
			_glimmer2Pool = glimmer2Pool;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			ArcadePhysicsCallback collideCallback = OnBulletOverlapsEnemyHighDamage;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = physics.add.overlap(_glimmer2Pool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core == null)
			{
				throw new NullReferenceException();
			}
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Cannon1Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			Collider collider2 = physics2.add.overlap(_glimmer2Pool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
		}
	}

	protected override void InitGlimmer3BulletPool()
	{
		//IL_0137: Expected I, but got O
		Projectile glimmer3Prefab = _Glimmer3Prefab;
		if ((object)_Glimmer3Prefab != null && ((UnityEngine.Object)glimmer3Prefab).m_CachedPtr != (IntPtr)0)
		{
			BulletPool glimmer3Pool = new BulletPool(_Glimmer3Prefab, 20);
			_glimmer3Pool = glimmer3Pool;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			ArcadePhysicsCallback collideCallback = OnBulletOverlapsEnemyHighDamage;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = physics.add.overlap(_glimmer3Pool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core == null)
			{
				throw new NullReferenceException();
			}
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Cannon1Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			Collider collider2 = physics2.add.overlap(_glimmer3Pool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
		}
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		_explosionType = WeaponType.FIREEXPLOSION;
	}

	public override void InternalUpdate()
	{
		//IL_008f: Expected O, but got F4
		base.InternalUpdate();
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003DD0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rax_v2 (VampireSurvivors.Objects.Characters.CharacterController)+184]");
		float num = 0f * 57.29578f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
		float num2 = Mathf.DeltaAngle(_firingAngleDegrees, num);
		if (num2 > 170f)
		{
			_firingAngleDegrees = num;
			return;
		}
		object obj = Time.deltaTime;
		float maxDelta = num2 * 400f;
		float firingAngleDegrees = Mathf.MoveTowardsAngle(_firingAngleDegrees, num, maxDelta);
		_firingAngleDegrees = firingAngleDegrees;
	}

	public override float PAmount()
	{
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PAmount();
		float num2 = default(float);
		bool flag = !(10f > num2);
		float num3 = 10f;
		if (!flag)
		{
			num3 = num2;
		}
		WeaponData currentWeaponData = _currentWeaponData;
		float num4 = (float)currentWeaponData._003Camount_003Ek__BackingField + num3;
		return num4 * 50f;
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0022: Invalid comparison between F4 and I4
		//IL_0034: Expected F4, but got I4
		//IL_0074: Expected O, but got I
		//IL_0084: Expected O, but got I
		//IL_00dd: Expected O, but got I
		float num = PAmount();
		float num2 = default(float);
		_amount = num2;
		List<float> shuffledIndexes = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003990");
		_shuffledIndexes = shuffledIndexes;
		bool flag = !(num2 > 0f);
		float num3 = 0f;
		if (!flag)
		{
			do
			{
				List<float> shuffledIndexes2 = _shuffledIndexes;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rcx_v9 (System.Collections.Generic.List`1<System.Single>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rcx_v9 (System.Collections.Generic.List`1<System.Single>)+10]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rcx_v9 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rcx_v9 (System.Collections.Generic.List`1<System.Single>)+18]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ r8_v7+18]");
				if (num4 >= 0)
				{
					shuffledIndexes2.AddWithResize(num3);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rcx_v9 (System.Collections.Generic.List`1<System.Single>)+18]");
					object obj3 = (nint)0 + (nint)1;
				}
				num3++;
			}
			while (num2 > num3);
		}
		Extensions.Shuffle(_shuffledIndexes);
		base.Fire(skipTriggers);
	}

	protected override void Fire_FireBasicProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		//IL_0080: Expected O, but got I
		//IL_0175: Expected I, but got O
		//IL_0227: Expected O, but got F4
		//IL_03f8: Expected F4, but got O
		//IL_00a0->IL0282: Incompatible stack heights: 1 vs 0
		//IL_0137->IL030d: Incompatible stack heights: 1 vs 0
		//IL_03b7->IL0355: Incompatible stack heights: 1 vs 0
		float num = _amount - 3f;
		List<float> shuffledIndexes = _shuffledIndexes;
		float num2 = _firingAngleDegrees;
		float num3 = num * 0.5f;
		float num4 = num3 * 5f;
		float num5 = num4 + 30f;
		bool flag = !(60f > num5);
		float num6 = 60f;
		if (!flag)
		{
			num6 = num5;
		}
		float num7 = num6 / _amount;
		if (_shuffledIndexes != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.Single>)+18]");
			if ((nint)index < (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.Single>)+18]");
				bool flag2 = (nint)index >= (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.Single>)+10]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v3 (System.Collections.Generic.List`1<System.Single>)+10]");
				if ((nint)0 == 0)
				{
					goto IL_0282;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rcx_v39+18]");
				if ((nint)index >= (nint)0)
				{
					throw new IndexOutOfRangeException();
				}
				float num8 = _amount - 1f;
				float num9 = num7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rcx_v39+20+index @ r8 (System.Int32)*4]");
				float num10 = num9 * 0f;
				num7 *= 0.5f;
				num5 = num8 * num7;
				float num11 = num10 - num5;
				num2 += num11;
			}
			BulletPool pool2 = default(BulletPool);
			Projectile projectile = base.FireOneProjectile(pos, index, target, pool2);
			if ((object)projectile == null || ((UnityEngine.Object)projectile).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				nint num12 = (nint)projectile;
				float projectileSpeed = projectile.ProjectileSpeed;
				EME_Cannon1Weapon body = (EME_Cannon1Weapon)(object)projectile.body;
				if (projectile.body != null && (object)s_scene.physics != null)
				{
					float num13 = num2 * ((float)Math.PI / 180f);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
					float num14 = num13 * num5;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
					float num15 = num13 * num5;
					body._gameMan = (GameManager)num14;
					Transform transform = projectile.transform;
					BaseBody body2 = projectile.body;
					if (projectile.body != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
						Vector3 axis = default(Vector3);
						Quaternion.AngleAxis_Injected((float)projectile, ref axis, out Quaternion _);
						bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Quaternion value = default(Quaternion);
						Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
						return;
					}
				}
			}
		}
		goto IL_0282;
		IL_0282:
		throw new NullReferenceException();
	}

	private void GenerateShuffleIndexes(float amount)
	{
		//IL_000e: Invalid comparison between F4 and I4
		//IL_0020: Expected F4, but got I4
		//IL_0051: Expected O, but got I
		//IL_00aa: Expected O, but got I
		List<float> shuffledIndexes = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003990");
		_shuffledIndexes = shuffledIndexes;
		bool flag = !(amount > 0f);
		float num = 0f;
		if (!flag)
		{
			do
			{
				List<float> shuffledIndexes2 = _shuffledIndexes;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rcx_v6 (System.Collections.Generic.List`1<System.Single>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rcx_v6 (System.Collections.Generic.List`1<System.Single>)+10]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rcx_v6 (System.Collections.Generic.List`1<System.Single>)+18]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ r8_v5+18]");
				if (num2 >= 0)
				{
					shuffledIndexes2.AddWithResize(num);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rcx_v6 (System.Collections.Generic.List`1<System.Single>)+18]");
					object obj2 = (nint)0 + (nint)1;
				}
				num++;
			}
			while (amount > num);
		}
		Extensions.Shuffle(_shuffledIndexes);
	}

	protected override void Fire_FireGlimmerProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		//IL_002a: Expected O, but got I4
		//IL_006b: Expected O, but got I4
		//IL_00c3: Expected O, but got I4
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Expected O, but got Unknown
		//IL_015c: Expected O, but got I4
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Expected O, but got Unknown
		object obj = default(object);
		if (obj != _glimmer1Pool)
		{
			return;
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_shockwave, soundConfig, 500f, 4, time);
		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
		soundConfig2.Volume = (float?)(object)1;
		soundConfig2.Rate = 1f;
		soundConfig2.Detune = -500f;
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Sfx_eme_shockwave, soundConfig2, 500f, 4, time);
		SoundManager.SoundConfig soundConfig3 = new SoundManager.SoundConfig();
		soundConfig3.Volume = (float?)(object)1;
		soundConfig3.Rate = 1f;
		soundConfig3.Detune = -1000f;
		PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.Sfx_eme_shockwave, soundConfig3, 500f, 4, time);
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PAmount();
		WeaponData currentWeaponData = _currentWeaponData;
		object obj3 = default(object);
		object obj2 = currentWeaponData._003Camount_003Ek__BackingField + obj3;
		object obj4 = obj2 + obj2;
		bool flag = (nint)obj4 <= 0;
		object obj5 = 0;
		if (!flag)
		{
			do
			{
				Projectile projectile = base.FireOneProjectile(pos, index, target);
				obj5++;
			}
			while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5));
		}
	}

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				GameManager gameMan2 = _gameMan;
				float heartOfFirePower = base.HeartOfFirePower;
				float newWeaponPower = default(float);
				gameMan2._arcanaManager.AddHeartOfFireWeapon(this, newWeaponPower);
			}
		}
	}

	protected unsafe override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_028d: Expected I4, but got O
		//IL_0343: Expected O, but got I4
		//IL_0231: Expected O, but got Ref
		float num2 = default(float);
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
						goto IL_02aa;
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
								if (component2.HasAlreadyHitObject(component))
								{
									goto IL_02aa;
								}
								float num = base.PPower();
								if (!(1f > num2))
								{
									WeaponData currentWeaponData = _currentWeaponData;
									HitVfxType showHitVfx = ((_currentWeaponData == null) ? HitVfxType.Default : currentWeaponData._003ChitVFX_003Ek__BackingField);
									float knockback = base.Knockback;
									component.GetDamaged(num2, showHitVfx, knockback, WeaponType.VOID, hasKb: false);
									goto IL_02d6;
								}
								float2 position = component.position;
								float num3 = UnityEngine.Random.Range(-0.1f, 0.1f);
								float num4 = UnityEngine.Random.Range(0f, 0.1f);
								if (_playerOptions != null)
								{
									PlayerOptionsData config = _playerOptions.Config;
									if (config != null)
									{
										if (config._003CDamageNumbersEnabled_003Ek__BackingField)
										{
											float2 position2 = component.position;
											if ((object)GameManager.DamageNumberManager == null)
											{
												goto IL_027f;
											}
											object obj = default(object);
											GameManager.DamageNumberManager.AddBob_Number1((Vector3)(&obj));
										}
										WeaponData currentWeaponData2 = _currentWeaponData;
										HitVfxType showHitVfx2 = ((_currentWeaponData == null) ? HitVfxType.Default : currentWeaponData2._003ChitVFX_003Ek__BackingField);
										float knockback2 = base.Knockback;
										component.GetDamagedSpecial(num2, showHitVfx2, knockback2, WeaponType.VOID, hasKb: false, (Vector3?)(object)0);
										goto IL_02d6;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_027f;
		IL_02d6:
		float num5 = num2 + ((Weapon)this)._003CStatsInflictedDamage_003Ek__BackingField;
		((Weapon)this)._003CStatsInflictedDamage_003Ek__BackingField = num5;
		goto IL_02aa;
		IL_02aa:
		return false;
		IL_027f:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	protected bool OnBulletOverlapsEnemyHighDamage(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_015c: Expected I4, but got O
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
						goto IL_0179;
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
									float num2 = base.CalcCritMul();
									object obj = default(object);
									float num3 = (float)obj * 20f;
									float damage = (float)obj * num3;
									base.DealDamage(component, damage);
								}
								goto IL_0179;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0179:
		return false;
	}

	public void ShowTinyDamage(float value, Vector3 position)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm6\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CC9590");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAE780");
	}
}
