using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class EME_Blood1Weapon : EME_Weapon
{
	private sealed class _003C_003Ec__DisplayClass21_0
	{
		public EME_Blood1Weapon _003C_003E4__this;

		public BulletPool pool;
	}

	private sealed class _003C_003Ec__DisplayClass21_1
	{
		public Vector2 location;

		public int localIndex;

		public _003C_003Ec__DisplayClass21_0 CS_0024_003C_003E8__locals1;

		internal void _003CSpawnSpecialProjectiles_003Eb__0()
		{
			//IL_0131: Expected O, but got I4
			//IL_00a8->IL00fa: Incompatible stack heights: 1 vs 0
			//IL_00ca->IL00fa: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass21_0 obj = CS_0024_003C_003E8__locals1;
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
					_003C_003Ec__DisplayClass21_0 obj3 = CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals1 != null && obj3.pool != null)
					{
						float2 pos = default(float2);
						Projectile projectile = obj3.pool.SpawnAt(pos, obj3._003C_003E4__this, localIndex);
						return;
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	protected Projectile _BasicBloodPrefab;

	protected Projectile _BloodRagePrefab;

	protected Projectile _ScarletPrefab;

	protected BulletPool _basicBloodPool;

	protected BulletPool _bloodRagePool;

	protected BulletPool _scarletPool;

	protected override int EvolutionLevel => 8;

	protected override int _comboIndex1 => 5;

	protected override int _comboIndex2 => 10;

	protected override int _comboIndex3 => 15;

	protected override int ComboIndexFinal => base.ComboIndex1;

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		_secondaryOvarlapDamageType = WeaponType.CURSE;
		base.InitWeapon(characterController, weaponType);
	}

	protected override WeaponType GetWeaponTypeForGlimmerLevel(int level)
	{
		if (level == 1)
		{
			return WeaponType.EME_BLOOD_TECH_01;
		}
		bool flag = level != 2;
		WeaponType result = WeaponType.VOID;
		if (!flag)
		{
			result = WeaponType.EME_BLOOD_TECH_02;
		}
		return result;
	}

	protected override void OnStart()
	{
		//IL_00bd: Expected I, but got O
		//IL_0160: Expected I, but got O
		//IL_02f7: Expected I, but got O
		//IL_048e: Expected I, but got O
		((Weapon)this).OnStart();
		base.InitGlimmer1BulletPool();
		base.InitGlimmer2BulletPool();
		base.InitGlimmer3BulletPool();
		Projectile basicBloodPrefab = _BasicBloodPrefab;
		if ((object)_BasicBloodPrefab == null || ((UnityEngine.Object)basicBloodPrefab).m_CachedPtr == (IntPtr)0)
		{
			goto IL_0198;
		}
		BulletPool basicBloodPool = new BulletPool(_BasicBloodPrefab, 20);
		_basicBloodPool = basicBloodPool;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1141 @ r8_v29 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Blood1Weapon>)+350]");
			ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			Collider collider = physics.add.overlap(_basicBloodPool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				ArcadePhysics physics2 = s_scene2.physics;
				GameManager core2 = GM.Core;
				PhysicsManager physicsManager = core2._physicsManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1305 @ r8_v32 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Blood1Weapon>)+3A0]");
				ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num2 = (nint)this;
				Collider collider2 = physics2.add.overlap(_basicBloodPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
				goto IL_0198;
			}
		}
		goto IL_04c7;
		IL_04c7:
		throw new NullReferenceException();
		IL_0198:
		Projectile bloodRagePrefab = _BloodRagePrefab;
		if ((object)_BloodRagePrefab == null || ((UnityEngine.Object)bloodRagePrefab).m_CachedPtr == (IntPtr)0)
		{
			goto IL_032f;
		}
		BulletPool bloodRagePool = new BulletPool(_BloodRagePrefab, 20);
		_bloodRagePool = bloodRagePool;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene3 = ArcadePhysics.s_scene;
			ArcadePhysics physics3 = s_scene3.physics;
			GameManager core3 = GM.Core;
			ArcadePhysicsCallback collideCallback3 = OnBulletOverlapsEnemyDamagex2;
			Collider collider3 = physics3.add.overlap(_bloodRagePool, core3.Enemies, collideCallback3, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene4 = ArcadePhysics.s_scene;
				ArcadePhysics physics4 = s_scene4.physics;
				GameManager core4 = GM.Core;
				PhysicsManager physicsManager2 = core4._physicsManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1327 @ r8_v20 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Blood1Weapon>)+3A0]");
				ArcadePhysicsCallback collideCallback4 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num3 = (nint)this;
				Collider collider4 = physics4.add.overlap(_bloodRagePool, physicsManager2._destructiblesGroup, collideCallback4, processCallback, callbackContext);
				goto IL_032f;
			}
		}
		goto IL_04c7;
		IL_032f:
		Projectile scarletPrefab = _ScarletPrefab;
		if ((object)_ScarletPrefab == null || ((UnityEngine.Object)scarletPrefab).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		BulletPool scarletPool = new BulletPool(_ScarletPrefab, 20);
		_scarletPool = scarletPool;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene5 = ArcadePhysics.s_scene;
			ArcadePhysics physics5 = s_scene5.physics;
			GameManager core5 = GM.Core;
			ArcadePhysicsCallback collideCallback5 = OnBulletOverlapsEnemyDamageGreed;
			Collider collider5 = physics5.add.overlap(_scarletPool, core5.Enemies, collideCallback5, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene6 = ArcadePhysics.s_scene;
				ArcadePhysics physics6 = s_scene6.physics;
				GameManager core6 = GM.Core;
				PhysicsManager physicsManager3 = core6._physicsManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1337 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Blood1Weapon>)+3A0]");
				ArcadePhysicsCallback collideCallback6 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num4 = (nint)this;
				Collider collider6 = physics6.add.overlap(_scarletPool, physicsManager3._destructiblesGroup, collideCallback6, processCallback, callbackContext);
				return;
			}
		}
		goto IL_04c7;
	}

	protected override void Fire_FireBasicProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		if (index == 0)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnMagicAttackAnim();
			Projectile projectile = base.FireOneProjectile(pos, 0, target);
		}
	}

	protected override void Fire_FireGlimmerProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		if (index == 0)
		{
			Projectile projectile = base.FireOneProjectile(pos, index, target);
		}
	}

	public unsafe void SpawnSpecialProjectiles(float2 position, BulletPool pool, float amountMul = 1f, float areaMul = 1f)
	{
		//IL_0056: Expected O, but got Ref
		//IL_005f: Expected I, but got O
		//IL_00aa: Invalid comparison between I4 and F4
		//IL_00cb: Expected F4, but got I4
		//IL_0481: Invalid comparison between F4 and I4
		//IL_0493: Expected F4, but got I4
		//IL_02a7: Expected O, but got I
		//IL_02c2: Expected I4, but got I8
		//IL_0563: Invalid comparison between F4 and I4
		//IL_02df: Invalid comparison between F4 and I4
		//IL_01df: Expected O, but got I
		//IL_023e: Expected O, but got I
		//IL_027f: Expected O, but got I
		//IL_052a->IL0556: Incompatible stack heights: 2 vs 0
		//IL_028d->IL02b5: Incompatible stack heights: 2 vs 0
		_003C_003Ec__DisplayClass21_0 obj = new _003C_003Ec__DisplayClass21_0();
		obj._003C_003E4__this = this;
		obj.pool = pool;
		float num = base.PArea();
		GameManager core = GM.Core;
		object obj2 = default(object);
		object obj3 = default(object);
		float maxRange = (float)obj2 * (float)obj3;
		float2 ret = default(float2);
		List<EnemyController> closestEnemiesSorted = core._stage.GetClosestEnemiesSorted((Vector3)(&ret), excludeDead: true, maxRange);
		nint num2 = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v623 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Blood1Weapon>)+408]");
		nint num3 = 0;
		float num4 = base.PAmount();
		float2 float5 = default(float2);
		float num5 = (float)float5 - 1f;
		float num6 = num5 * amountMul;
		if (!((float)closestEnemiesSorted._size > num6))
		{
			num6 = closestEnemiesSorted._size;
		}
		WeaponData currentWeaponData = _currentWeaponData;
		float num7 = currentWeaponData._003CrepeatInterval_003Ek__BackingField;
		float num8 = base.PInterval();
		float num9 = num6 + 1f;
		float num10 = (float)closestEnemiesSorted._size / num9;
		if (!(num10 > currentWeaponData._003CrepeatInterval_003Ek__BackingField))
		{
			num7 = num10;
		}
		List<Vector2> list = new List<Vector2>();
		bool flag = !(num6 > 0f);
		float num11 = 0f;
		float num13 = default(float);
		int num14;
		bool canPause;
		bool flag5;
		if (!flag)
		{
			bool flag4;
			do
			{
				bool flag2 = !(num11 < (float)closestEnemiesSorted._size);
				EnemyController[] items = closestEnemiesSorted._items;
				ArcadeSprite arcadeSprite = items[num11];
				Transform cachedTrans = ((ArcadeSprite)items[num11]).CachedTrans;
				bool flag3 = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out *(Vector3*)(&ret));
				if (arcadeSprite.body != null)
				{
					BaseBody body = arcadeSprite.body;
					ArcadeTransform arcadeTransform = body._transform;
					arcadeTransform.position = ret;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v672 @ rax_v16 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v672 @ rax_v16 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v672 @ rax_v16 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				nint num12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rcx_v26+18]");
				if (num12 >= 0)
				{
					list.AddWithResize((Vector2)float5);
					num3 = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v672 @ rax_v16 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
					object obj5 = (nint)0 + (nint)1;
					num3 = 0;
				}
				num11++;
				flag4 = num6 > num11;
				num10 = num11;
				num9 = num13;
			}
			while (flag4);
			num14 = 0;
			canPause = false;
			num9 = num13;
			Weapon weapon = (Weapon)num3;
			flag5 = false;
		}
		else
		{
			num14 = 0;
			canPause = false;
			Weapon weapon = (Weapon)num3;
			flag5 = false;
		}
		int num15 = -1986357120;
		Vector2 location = default(Vector2);
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		while (true)
		{
			bool num16 = flag5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v672 @ rax_v16 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)(num16 ? 1 : 0) >= (nint)0)
			{
				break;
			}
			float num17 = (float)num14 * num7;
			Weapon weapon;
			if (!(num17 > 0f))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
				Projectile projectile = obj.pool.SpawnAt(float5, this, num14);
				num14++;
				num9 = num13;
				weapon = this;
				num15 = num14;
				flag5 = (byte)num14 != 0;
				continue;
			}
			_003C_003Ec__DisplayClass21_1 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass21_1();
			CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1 = obj;
			CS_0024_003C_003E8__locals8.localIndex = num14;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
			CS_0024_003C_003E8__locals8.location = location;
			Action onComplete = delegate
			{
				//IL_0131: Expected O, but got I4
				//IL_00a8->IL00fa: Incompatible stack heights: 1 vs 0
				//IL_00ca->IL00fa: Incompatible stack heights: 1 vs 0
				_003C_003Ec__DisplayClass21_0 obj6 = CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1;
				if (CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1 != null && (object)obj6._003C_003E4__this != null)
				{
					GameObject gameObject = obj6._003C_003E4__this.gameObject;
					if ((object)gameObject != null)
					{
						bool flag6 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
						object obj7 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
						if (obj7 == null)
						{
							return;
						}
						_003C_003Ec__DisplayClass21_0 obj8 = CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1;
						if (CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1 != null && obj8.pool != null)
						{
							float2 pos = default(float2);
							Projectile projectile2 = obj8.pool.SpawnAt(pos, obj8._003C_003E4__this, CS_0024_003C_003E8__locals8.localIndex);
							return;
						}
					}
				}
				throw new NullReferenceException();
			};
			float num18 = (float)num14 * num7;
			float duration = num18 * 0.001f;
			Timer lastShotTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause);
			_lastShotTimer = lastShotTimer;
			num14++;
			num9 = num13;
			weapon = null;
			num15 = 0;
			flag5 = (byte)num14 != 0;
		}
	}

	public void DoBasicAttacks(float2 position)
	{
		float areaMul = default(float);
		SpawnSpecialProjectiles(position, _basicBloodPool, 1f, areaMul);
	}

	public void DoBloodRage(float2 position)
	{
		float areaMul = default(float);
		SpawnSpecialProjectiles(position, _bloodRagePool, 2f, areaMul);
	}

	public void DoScarletHarbinger(float2 position)
	{
		float areaMul = default(float);
		SpawnSpecialProjectiles(position, _scarletPool, 1f, areaMul);
	}

	protected bool OnBulletOverlapsEnemyDamagex2(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0159: Expected I4, but got O
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
						goto IL_0176;
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
									object obj2 = default(object);
									object obj = obj2 + obj2;
									float damage = (float)obj2 * (float)obj;
									base.DealDamage(component, damage);
								}
								goto IL_0176;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0176:
		return false;
	}

	protected bool OnBulletOverlapsEnemyDamageGreed(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0397: Expected I4, but got O
		//IL_0013: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_0067: Expected O, but got I
		//IL_009d: Expected O, but got I4
		//IL_0110: Expected I, but got O
		//IL_0118: Expected I, but got O
		//IL_0128: Expected O, but got I
		//IL_0164: Expected O, but got I
		//IL_01a1: Expected O, but got I
		//IL_01e5: Expected O, but got I4
		//IL_01d7: Expected O, but got I4
		//IL_046b: Expected I, but got O
		if (first == null)
		{
			goto IL_0389;
		}
		nint num = (nint)typeof(EnemyController);
		nint num2 = (nint)first;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r8_v2 (Il2CppClass<ArcadeColliderType>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r8_v2 (Il2CppClass<ArcadeColliderType>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ rax_v51+FFFFFFF8+v61 @ rax_v4*8]");
			if (0 == (nint)typeof(EnemyController))
			{
				obj3 = 1;
				goto IL_03b4;
			}
		}
		obj3 = 0;
		goto IL_03b4;
		IL_0389:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_03d6:
		return false;
		IL_03b4:
		bool flag = obj3 == null;
		ArcadeColliderType arcadeColliderType = null;
		if (!flag)
		{
			arcadeColliderType = first;
		}
		if (arcadeColliderType != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rbx_v3 (ArcadeColliderType)+260]");
			if ((nint)0 != 0)
			{
				goto IL_03d6;
			}
			if (second != null)
			{
				nint num4 = (nint)typeof(Projectile);
				nint num5 = (nint)second;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ r8_v4 (Il2CppClass<ArcadeColliderType>)+130]");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
				if (num6 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ r8_v4 (Il2CppClass<ArcadeColliderType>)+C8]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rax_v9+FFFFFFF8+v138 @ rax_v8*8]");
					if (0 == (nint)typeof(Projectile))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
						object obj6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rax_v9+FFFFFFF8+v450 @ rcx_v6*8]");
						object obj7 = ((0 != (nint)typeof(Projectile)) ? ((object)0) : ((object)1));
						bool flag2 = obj7 == null;
						ArcadeColliderType arcadeColliderType2 = null;
						if (!flag2)
						{
							arcadeColliderType2 = second;
						}
						if (((Projectile)arcadeColliderType2).HasAlreadyHitObject((IDamageable)arcadeColliderType))
						{
							goto IL_03d6;
						}
						if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
						{
							float num7 = ((Equipment)this)._003COwner_003Ek__BackingField.PGreed();
							float num8 = default(float);
							bool flag3 = !(1f < num8);
							float num9 = 1f;
							if (!flag3)
							{
								num9 = num8;
							}
							float num10 = base.PPower();
							float num11 = base.CalcCritMul();
							WeaponData currentWeaponData = _currentWeaponData;
							float num12 = num9 * num8;
							float num13 = num8 * num12;
							if (_currentWeaponData != null)
							{
								HitVfxType hitVfxType = currentWeaponData._003ChitVFX_003Ek__BackingField;
							}
							else
							{
								HitVfxType hitVfxType = HitVfxType.Default;
							}
							float knockback = base.Knockback;
							nint num14 = (nint)arcadeColliderType;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v130 @ rdx_v13 (Il2CppClass<ArcadeColliderType>)+3E8] (should have been resolved before IL gen)");
							float num15 = num13 + ((Weapon)this)._003CStatsInflictedDamage_003Ek__BackingField;
							((Weapon)this)._003CStatsInflictedDamage_003Ek__BackingField = num15;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rbx_v3 (ArcadeColliderType)+260]");
							if ((nint)0 == 0)
							{
								goto IL_03d6;
							}
							float value = UnityEngine.Random.value;
							if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
							{
								float num16 = ((Equipment)this)._003COwner_003Ek__BackingField.PGreed();
								float2 position = ((ArcadeSprite)arcadeColliderType).position;
								float num17 = value * 0.1f;
								if (!(num17 > value))
								{
									goto IL_03d6;
								}
								if ((object)GM.Core != null && (GM.Core.IsStageHost || !NetworkItems.IsNetworkItem(ItemType.LITTLEHEART)))
								{
									Vector2 pos = default(Vector2);
									Pickup pickup = PickupManager.CreatePickup(pos, ItemType.LITTLEHEART);
									if ((object)pickup != null)
									{
										pickup.GoToLowestHealthPlayer();
										pickup.Time = 1f;
										goto IL_03d6;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0389;
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
				_explodeOnExpire = true;
			}
		}
	}
}
