using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class EME_Katana1Weapon : EME_Weapon
{
	private sealed class _003C_003Ec__DisplayClass34_0
	{
		public int localIndex;

		public EME_Katana1Weapon _003C_003E4__this;

		internal void _003CFireScatteredPetalsMiniSlashes_003Eb__0()
		{
			EME_Katana1Weapon eME_Katana1Weapon = _003C_003E4__this;
			float2 position = ((Equipment)eME_Katana1Weapon)._003COwner_003Ek__BackingField.position;
			EME_Katana1Weapon eME_Katana1Weapon2 = _003C_003E4__this;
			Vector2 pos = default(Vector2);
			Projectile projectile = _003C_003E4__this.FireOneProjectile(pos, localIndex, eME_Katana1Weapon2._targetTransform);
		}
	}

	private float MaxBonus = 1f;

	private float MaxEnemies = 300f;

	private float currentBonus;

	private Projectile _gravediggerRockPrefab;

	private Projectile _scatteredPetalsMiniSlashPrefab;

	private Projectile _scatteredPetalsMoonPrefab;

	protected BulletPool _gravediggerRockPool;

	protected BulletPool _scatteredPetalsMiniSlashPool;

	protected BulletPool _scatteredPetalsMoonPool;

	private Timer _glimmerShotTimer;

	private const float _scatteredPetalsMaxArea = 2.5f;

	private float2 _scatteredPetalsOffsetFromPlayer;

	public BulletPool GravediggerRockPool => _gravediggerRockPool;

	public float ScatteredPetalsMaxArea => 2.5f;

	public float2 ScatteredPetalsOffsetFromPlayer
	{
		get
		{
			float2 result = default(float2);
			return result;
		}
	}

	protected override int EvolutionLevel => 8;

	protected override int _comboIndex1 => 3;

	protected override int _comboIndex2 => 7;

	protected override int _comboIndex3
	{
		get
		{
			//IL_000a: Expected I4, but got I8
			return -1;
		}
	}

	protected override int ComboIndexFinal => base.ComboIndex1;

	public override float PPower()
	{
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float num = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
			WeaponData currentWeaponData = _currentWeaponData;
			if (_currentWeaponData != null && (object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
				float num2 = currentBonus + currentWeaponData._003Cpower_003Ek__BackingField;
				float num3 = num2 * num;
				return num + num3;
			}
		}
		throw new NullReferenceException();
	}

	protected override WeaponType GetWeaponTypeForGlimmerLevel(int level)
	{
		if (level == 1)
		{
			return WeaponType.EME_KATANA_TECH_01;
		}
		bool flag = level != 2;
		WeaponType result = WeaponType.VOID;
		if (!flag)
		{
			result = WeaponType.EME_KATANA_TECH_02;
		}
		return result;
	}

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Melee;
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0019: Expected O, but got I4
		base.InitWeapon(characterController, weaponType);
		_scatteredPetalsOffsetFromPlayer = (float2)0;
		_ = 1048576000;
	}

	private void LateUpdate()
	{
		GameManager core = GM.Core;
		Stage stage = core._stage;
		List<EnemyController> spawnedEnemies = stage._spawnedEnemies;
		float num = (float)spawnedEnemies._size / MaxEnemies;
		bool flag = !(1f > num);
		float num2 = 1f;
		if (!flag)
		{
			num2 = num;
		}
		float num3 = num2 * MaxBonus;
		currentBonus = num3;
	}

	protected override void OnStart()
	{
		//IL_0205: Expected I, but got O
		//IL_0389: Expected I, but got O
		//IL_0124: Expected I, but got O
		//IL_02a8: Expected I, but got O
		//IL_042c: Expected I, but got O
		((Weapon)this).OnStart();
		InitGlimmer1BulletPool();
		base.InitGlimmer2BulletPool();
		base.InitGlimmer3BulletPool();
		if (_gravediggerRockPool != null)
		{
			goto IL_015c;
		}
		BulletPool gravediggerRockPool = new BulletPool(_gravediggerRockPrefab, 20);
		_gravediggerRockPool = gravediggerRockPool;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			ArcadePhysicsCallback collideCallback = OnBulletOverlapsEnemyHighDamage;
			Collider collider = physics.add.overlap(_gravediggerRockPool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				ArcadePhysics physics2 = s_scene2.physics;
				GameManager core2 = GM.Core;
				PhysicsManager physicsManager = core2._physicsManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1068 @ r8_v33 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Katana1Weapon>)+3A0]");
				ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num = (nint)this;
				Collider collider2 = physics2.add.overlap(_gravediggerRockPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
				goto IL_015c;
			}
		}
		goto IL_0465;
		IL_015c:
		if (_scatteredPetalsMiniSlashPool != null)
		{
			goto IL_02e0;
		}
		BulletPool scatteredPetalsMiniSlashPool = new BulletPool(_scatteredPetalsMiniSlashPrefab, 20);
		_scatteredPetalsMiniSlashPool = scatteredPetalsMiniSlashPool;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene3 = ArcadePhysics.s_scene;
			ArcadePhysics physics3 = s_scene3.physics;
			GameManager core3 = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1003 @ r8_v19 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Katana1Weapon>)+350]");
			ArcadePhysicsCallback collideCallback3 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			Collider collider3 = physics3.add.overlap(_scatteredPetalsMiniSlashPool, core3.Enemies, collideCallback3, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene4 = ArcadePhysics.s_scene;
				ArcadePhysics physics4 = s_scene4.physics;
				GameManager core4 = GM.Core;
				PhysicsManager physicsManager2 = core4._physicsManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1071 @ r8_v22 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Katana1Weapon>)+3A0]");
				ArcadePhysicsCallback collideCallback4 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num3 = (nint)this;
				Collider collider4 = physics4.add.overlap(_scatteredPetalsMiniSlashPool, physicsManager2._destructiblesGroup, collideCallback4, processCallback, callbackContext);
				goto IL_02e0;
			}
		}
		goto IL_0465;
		IL_0465:
		throw new NullReferenceException();
		IL_02e0:
		if (_scatteredPetalsMoonPool != null)
		{
			return;
		}
		BulletPool scatteredPetalsMoonPool = new BulletPool(_scatteredPetalsMoonPrefab, 20);
		_scatteredPetalsMoonPool = scatteredPetalsMoonPool;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene5 = ArcadePhysics.s_scene;
			ArcadePhysics physics5 = s_scene5.physics;
			GameManager core5 = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1010 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Katana1Weapon>)+350]");
			ArcadePhysicsCallback collideCallback5 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num4 = (nint)this;
			Collider collider5 = physics5.add.overlap(_scatteredPetalsMoonPool, core5.Enemies, collideCallback5, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene6 = ArcadePhysics.s_scene;
				ArcadePhysics physics6 = s_scene6.physics;
				GameManager core6 = GM.Core;
				PhysicsManager physicsManager3 = core6._physicsManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1074 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Katana1Weapon>)+3A0]");
				ArcadePhysicsCallback collideCallback6 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num5 = (nint)this;
				Collider collider6 = physics6.add.overlap(_scatteredPetalsMoonPool, physicsManager3._destructiblesGroup, collideCallback6, processCallback, callbackContext);
				return;
			}
		}
		goto IL_0465;
	}

	public unsafe virtual void FireScatteredPetalsMiniSlashes()
	{
		//IL_006f: Expected I, but got O
		//IL_0085: Expected O, but got I
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_00fc: Expected I, but got O
		//IL_0151: Expected O, but got I4
		//IL_0168: Expected I, but got I8
		//IL_00e5: Expected I, but got I8
		bool flag = false;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		do
		{
			_003C_003Ec__DisplayClass34_0 obj = new _003C_003Ec__DisplayClass34_0();
			obj._003C_003E4__this = this;
			obj.localIndex = (flag ? 1 : 0);
			Action action = null;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ r10_v2 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass34_0._003CFireScatteredPetalsMiniSlashes_003Eb__0);
			((Delegate)action).m_target = obj;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ r10_v2 (Il2CppMethodInfo)+4C]");
			object obj2 = (nint)0 >> 4;
			object obj3 = obj2 & 1;
			nint num2;
			if (obj3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ r10_v2 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num2 = unchecked((nint)6447293664L);
					goto IL_0148;
				}
			}
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			num2 = ((Delegate)action).method_ptr;
			goto IL_0148;
			IL_0148:
			object obj4 = 24;
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			float num3 = (float)(flag ? 1 : 0) * 100f;
			float duration = num3 * 0.001f;
			Timer glimmerShotTimer = Timers.Register(duration, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_glimmerShotTimer = glimmerShotTimer;
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
		}
		while ((flag ? 1 : 0) < 6);
	}

	public void FireScatteredPetalsMoon(Vector2 position, int index, Action onProjectileDespawn)
	{
		//IL_0017: Expected I, but got O
		//IL_0025: Expected I, but got O
		//IL_0035: Expected O, but got I
		//IL_00b5: Expected O, but got I4
		//IL_0071: Expected O, but got I
		//IL_00a7: Expected O, but got I4
		//IL_0256: Expected O, but got I
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Expected O, but got Unknown
		Projectile projectile = base.FireOneProjectile(position, index, _targetTransform);
		Projectile projectile2;
		if ((object)projectile == null)
		{
			projectile2 = null;
			goto IL_0228;
		}
		nint num = (nint)projectile;
		nint num2 = (nint)typeof(EME_KatanaProjectile_ScatteredPetals_Moon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_KatanaProjectile_ScatteredPetals_Moon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r8_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_KatanaProjectile_ScatteredPetals_Moon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r8_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rax_v37+FFFFFFF8+v69 @ rax_v33*8]");
			if (0 == (nint)typeof(EME_KatanaProjectile_ScatteredPetals_Moon))
			{
				obj3 = 1;
				goto IL_0201;
			}
		}
		obj3 = 0;
		goto IL_0201;
		IL_0201:
		bool flag = obj3 == null;
		projectile2 = null;
		if (!flag)
		{
			projectile2 = projectile;
		}
		goto IL_0228;
		IL_0228:
		if ((object)projectile2 == null || ((UnityEngine.Object)projectile2).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rdi_v2 (VampireSurvivors.Objects.Projectiles.Projectile)+120]");
		Delegate obj4 = (Delegate)0;
		object obj5 = projectile2 + 288;
		while (true)
		{
			Delegate obj6 = Delegate.Combine(obj4, onProjectileDespawn);
			bool flag2 = (object)obj6 == null;
			Delegate obj7 = null;
			if (!flag2)
			{
				bool flag3 = (object)obj6.GetType() != typeof(Action);
				obj7 = null;
				if (!flag3)
				{
					obj7 = obj6;
				}
				if ((object)obj7 == null)
				{
					break;
				}
			}
			bool flag4 = obj4 == obj5;
			Delegate obj8;
			if (obj4 == obj5)
			{
				obj5 = obj7;
				obj8 = obj4;
			}
			else
			{
				obj8 = (Delegate)obj5;
			}
			Delegate obj9 = obj4;
			if (!flag4)
			{
				obj9 = obj8;
			}
			bool flag5 = (object)obj9 != obj4;
			obj4 = obj9;
			if (!flag5)
			{
				return;
			}
		}
		throw new InvalidCastException();
	}

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				((Weapon)this)._003CCanCrit_003Ek__BackingField = true;
			}
		}
	}

	public override void Cleanup()
	{
		if (_glimmerShotTimer != null)
		{
			_glimmerShotTimer.Cancel();
		}
		((Weapon)this).Cleanup();
		if (base.glimmerUnlockTimer != null)
		{
			base.glimmerUnlockTimer.Cancel();
		}
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Katana1Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			Collider collider2 = physics2.add.overlap(_glimmer1Pool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
		}
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
									float num = PPower();
									float num2 = base.CalcCritMul();
									object obj = default(object);
									float num3 = (float)obj * 4f;
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
}
