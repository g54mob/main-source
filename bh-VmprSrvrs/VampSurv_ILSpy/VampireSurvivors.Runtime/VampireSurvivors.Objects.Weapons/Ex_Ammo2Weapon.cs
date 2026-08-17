using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Tools;
using Zenject;

namespace VampireSurvivors.Objects.Weapons;

public class Ex_Ammo2Weapon : Weapon
{
	private BulletPool InvisProjectilesPool;

	private Projectile InvisProjectilePrefab;

	private ParticleSystem[] _gunastropheParticleSystem;

	private float _particleLaunchVelocity;

	private float _particleGravity;

	private Camera _mainCamera;

	private ParticleSystem.Particle[] _activeParticles;

	private float[] _randomBounceValues;

	private readonly List<RapidDamageInstance> _rapidDamageInstances;

	private const WeaponType _counterWeaponType = WeaponType.EX_AMMO1_COUNTER;

	private Weapon _counterWeapon;

	private Vector3 _cameraOrthographicSize;

	private unsafe Vector3 _gravityVector
	{
		get
		{
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Expected F4, but got Unknown
			//IL_0020: Expected native int or pointer, but got O
			//IL_002e: Expected native int or pointer, but got O
			//IL_003b: Expected native int or pointer, but got O
			float particleGravity = _particleGravity;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			float y = particleGravity ^ 0;
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = 0f;
			((Vector3*)(nint)vector)->z = 0f;
			((Vector3*)(nint)vector)->y = y;
			return vector;
		}
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_007c: Expected I, but got O
		//IL_011f: Expected I, but got O
		base.InitWeapon(characterController, weaponType);
		if (InvisProjectilesPool == null)
		{
			BulletPool bulletPool = new BulletPool(InvisProjectilePrefab);
			bulletPool.UpperLimit = 100;
			InvisProjectilesPool = bulletPool;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v428 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Weapons.Ex_Ammo2Weapon>)+350]");
			ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = physics.add.overlap(InvisProjectilesPool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core == null)
			{
				throw new NullReferenceException();
			}
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Ex_Ammo2Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			Collider collider2 = physics2.add.overlap(InvisProjectilesPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
		}
	}

	protected override void Awake()
	{
		//IL_00cf: Expected O, but got I
		base.Awake();
		Camera main = Camera.main;
		_mainCamera = main;
		InitBounceValues();
		Bounds bounds = CameraExtensions.OrthographicBounds(_mainCamera);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rax_v7 (UnityEngine.Bounds)+10]");
		float num = 0f * 2f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rax_v7 (UnityEngine.Bounds)+14]");
		float num2 = 0f * 2f;
		Vector3 cameraOrthographicSize = default(Vector3);
		_cameraOrthographicSize = cameraOrthographicSize;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9C0]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9C0]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v320 @ rax_v19 (should have been resolved before IL gen)");
		object obj2 = default(object);
		ParticleSystem.Particle[] activeParticles = new ParticleSystem.Particle[obj2];
		_activeParticles = activeParticles;
	}

	public override void CheckArcanas()
	{
		//IL_0249: Expected I, but got O
		//IL_0257: Expected I, but got O
		//IL_0267: Expected O, but got I
		//IL_02e7: Expected O, but got I4
		//IL_02a3: Expected O, but got I
		//IL_02d9: Expected O, but got I4
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rcx_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				base._003CCanCrit_003Ek__BackingField = true;
			}
		}
		GameManager gameMan2 = _gameMan;
		ArcanaManager arcanaManager2 = gameMan2._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rcx_v9 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			if ((nint)obj2 != -1)
			{
				GameManager gameMan3 = _gameMan;
				float heartOfFirePower = base.HeartOfFirePower;
				float newWeaponPower = default(float);
				gameMan3._arcanaManager.AddHeartOfFireWeapon(this, newWeaponPower);
			}
		}
		GameManager core = GM.Core;
		ArcanaManager arcanaManager3 = core._arcanaManager;
		List<ArcanaType> list3 = arcanaManager3._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj3 = default(object);
		if ((nint)obj3 <= -1)
		{
			goto IL_035b;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		Weapon weaponByType = characterController._weaponsManager.GetWeaponByType(WeaponType.EX_AMMO1_COUNTER, searchHidden: true);
		if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
		{
			return;
		}
		GameManager core2 = GM.Core;
		bool allowDuplicates = default(bool);
		Weapon weapon = core2._weaponsFacade.AddHiddenWeapon(WeaponType.EX_AMMO1_COUNTER, ((Equipment)this)._003COwner_003Ek__BackingField, removeFromStore: true, allowDuplicates);
		bool flag = (object)weapon == null;
		UnityEngine.Object obj4 = null;
		object obj7;
		if (!flag)
		{
			nint num = (nint)weapon;
			nint num2 = (nint)typeof(Ex_Ammo1Weapon_Counter);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v671 @ rdx_v17 (Il2CppClass<VampireSurvivors.Objects.Weapons.Ex_Ammo1Weapon_Counter>)+130]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v670 @ r9_v13 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v671 @ rdx_v17 (Il2CppClass<VampireSurvivors.Objects.Weapons.Ex_Ammo1Weapon_Counter>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v670 @ r9_v13 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v725 @ rax_v42+FFFFFFF8+v672 @ rax_v38*8]");
				if (0 == (nint)typeof(Ex_Ammo1Weapon_Counter))
				{
					obj7 = 1;
					goto IL_0398;
				}
			}
			obj7 = 0;
			goto IL_0398;
		}
		goto IL_02f9;
		IL_035b:
		CheckBeginningArcana();
		return;
		IL_02f9:
		if ((bool)obj4)
		{
			_counterWeapon = (Weapon)obj4;
			Equipment counterWeapon = _counterWeapon;
			while (!counterWeapon.IsMaxLevel())
			{
				bool flag2 = _counterWeapon.LevelUp();
				counterWeapon = _counterWeapon;
			}
		}
		goto IL_035b;
		IL_0398:
		bool flag3 = obj7 == null;
		obj4 = null;
		if (!flag3)
		{
			obj4 = weapon;
		}
		goto IL_02f9;
	}

	private void InitBounceValues()
	{
		//IL_03d3: Expected O, but got F4
		//IL_03e1: Expected O, but got F4
		//IL_03ef: Expected O, but got F4
		//IL_03fd: Expected O, but got F4
		//IL_040b: Expected O, but got F4
		//IL_0419: Expected O, but got F4
		//IL_0427: Expected O, but got F4
		//IL_0435: Expected O, but got F4
		//IL_0443: Expected O, but got F4
		//IL_0451: Expected O, but got F4
		//IL_045f: Expected O, but got F4
		//IL_046d: Expected O, but got F4
		//IL_047b: Expected O, but got F4
		//IL_0489: Expected O, but got F4
		//IL_0497: Expected O, but got F4
		//IL_04a5: Expected O, but got F4
		//IL_04b3: Expected O, but got F4
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 * 0.2f;
		float num2 = num + 0.8f;
		object obj3 = UnityEngine.Random.value;
		float num3 = num2 * 0.2f;
		float num4 = num3 + 0.8f;
		object obj4 = UnityEngine.Random.value;
		float num5 = num4 * 0.2f;
		float num6 = num5 + 0.8f;
		object obj5 = UnityEngine.Random.value;
		float num7 = num6 * 0.2f;
		float num8 = num7 + 0.8f;
		object obj6 = UnityEngine.Random.value;
		float num9 = num8 * 0.2f;
		float num10 = num9 + 0.8f;
		object obj7 = UnityEngine.Random.value;
		float num11 = num10 * 0.2f;
		float num12 = num11 + 0.8f;
		object obj8 = UnityEngine.Random.value;
		float num13 = num12 * 0.2f;
		float num14 = num13 + 0.8f;
		object obj9 = UnityEngine.Random.value;
		float num15 = num14 * 0.2f;
		float num16 = num15 + 0.8f;
		object obj10 = UnityEngine.Random.value;
		float num17 = num16 * 0.2f;
		float num18 = num17 + 0.8f;
		object obj11 = UnityEngine.Random.value;
		float num19 = num18 * 0.2f;
		float num20 = num19 + 0.8f;
		object obj12 = UnityEngine.Random.value;
		float num21 = num20 * 0.2f;
		float num22 = num21 + 0.8f;
		object obj13 = UnityEngine.Random.value;
		float num23 = num22 * 0.2f;
		float num24 = num23 + 0.8f;
		object obj14 = UnityEngine.Random.value;
		float num25 = num24 * 0.2f;
		float num26 = num25 + 0.8f;
		object obj15 = UnityEngine.Random.value;
		float num27 = num26 * 0.2f;
		float num28 = num27 + 0.8f;
		object obj16 = UnityEngine.Random.value;
		float num29 = num28 * 0.2f;
		float num30 = num29 + 0.8f;
		object obj17 = UnityEngine.Random.value;
		float num31 = num30 * 0.2f;
		float num32 = num31 + 0.8f;
		object obj18 = UnityEngine.Random.value;
		float num33 = num32 * 0.2f;
		float num34 = num33 + 0.8f;
		_randomBounceValues = new float[17]
		{
			num2, num4, num6, num8, num10, num12, num14, num16, num18, num20,
			num22, num24, num26, num28, num30, num32, num34
		};
	}

	protected unsafe override void OnUpdate()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0653: Expected O, but got I
		//IL_03c3: Expected O, but got I
		//IL_06b9: Expected O, but got I
		//IL_0b81: Expected I4, but got I8
		//IL_0410: Unknown result type (might be due to invalid IL or missing references)
		//IL_0415: Expected O, but got Unknown
		//IL_0706: Unknown result type (might be due to invalid IL or missing references)
		//IL_070b: Expected O, but got Unknown
		//IL_01f1: Invalid comparison between F4 and I4
		//IL_020b: Expected O, but got I4
		//IL_0c2f: Expected O, but got F4
		//IL_0c3f: Expected F4, but got I
		//IL_043d: Expected F4, but got I4
		//IL_0317: Unknown result type (might be due to invalid IL or missing references)
		//IL_031c: Expected O, but got Unknown
		//IL_0324: Expected O, but got I4
		//IL_08a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ad: Expected O, but got Unknown
		//IL_08b8: Expected O, but got I4
		//IL_0798: Expected O, but got I
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Expected I4, but got Unknown
		//IL_025a: Expected O, but got Ref
		//IL_0274: Expected O, but got I
		//IL_02a3: Expected I4, but got O
		//IL_02a3: Expected O, but got F4
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b5: Expected O, but got Unknown
		//IL_02bd: Invalid comparison between F4 and O
		//IL_02cb: Expected I4, but got O
		//IL_02d8: Expected F4, but got O
		//IL_02e8: Expected O, but got I
		//IL_02f0: Expected I4, but got O
		//IL_02f8: Expected F4, but got O
		//IL_07e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ea: Expected O, but got Unknown
		//IL_0807: Expected O, but got I
		//IL_0c83: Expected I4, but got F4
		//IL_050c: Expected O, but got I
		//IL_0559: Unknown result type (might be due to invalid IL or missing references)
		//IL_055e: Expected O, but got Unknown
		//IL_05cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d1: Expected O, but got Unknown
		//IL_04a9: Expected O, but got I
		//IL_08d1->IL08d1: Incompatible stack heights: 2 vs 0
		//IL_0a6b->IL00f2: Incompatible stack heights: 13 vs 12
		//IL_0ba0->IL08c6: Incompatible stack heights: 20 vs 18
		//IL_0331->IL0bc0: Incompatible stack heights: 20 vs 16
		//IL_08c1->IL0661: Incompatible stack heights: 23 vs 18
		//IL_08c6->IL08c6: Incompatible stack heights: 23 vs 18
		//IL_0309->IL0ba5: Incompatible stack heights: 22 vs 20
		//IL_030e->IL030e: Incompatible stack heights: 22 vs 20
		//IL_085f->IL089f: Incompatible stack heights: 27 vs 23
		//IL_0864->IL0864: Incompatible stack heights: 27 vs 22
		//IL_0602->IL0caa: Incompatible stack heights: 25 vs 17
		//IL_0607->IL0607: Incompatible stack heights: 25 vs 17
		//IL_04f7->IL0c6c: Incompatible stack heights: 23 vs 22
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Transform transform;
		while (true)
		{
			bool flag = (object)_mainCamera == null;
			transform = _mainCamera.transform;
			bool flag2 = (object)transform == null;
			if (((UnityEngine.Object)transform).m_CachedPtr != (IntPtr)0)
			{
				break;
			}
			UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(transform);
		}
		float ret;
		Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
		float num = (float)_cameraOrthographicSize * 0.5f;
		float left = ret - num;
		bool flag3 = (object)_mainCamera == null;
		Transform transform2 = _mainCamera.transform;
		bool flag4 = (object)transform2 == null;
		bool flag5 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out *(Vector3*)(&ret));
		bool flag6 = (object)_mainCamera == null;
		Transform transform3 = _mainCamera.transform;
		bool flag7 = (object)transform3 == null;
		bool flag8 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out *(Vector3*)(&ret));
		bool flag9 = (object)_mainCamera == null;
		Transform transform4 = _mainCamera.transform;
		bool flag10 = (object)transform4 == null;
		bool flag11 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out *(Vector3*)(&ret));
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		bool flag12 = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
		Transform transform5 = default(Transform);
		if (!characterController._isFlipped)
		{
			transform5 = base.transform;
			bool flag13 = (object)transform5 == null;
		}
		bool flag14 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform5).m_CachedPtr, out *(Vector3*)(&ret));
		Transform transform6 = base.transform;
		bool flag15 = (object)transform6 == null;
		bool flag16 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform6).m_CachedPtr, out Vector3 _);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.Ex_Ammo2Weapon)+1A4]");
		float num2 = 0f * -0.5f;
		ParticleSystem[] gunastropheParticleSystem = _gunastropheParticleSystem;
		bool flag17 = _gunastropheParticleSystem == null;
		Transform transform7 = null;
		Transform transform8 = null;
		float num3 = default(float);
		float top = default(float);
		float bottom = default(float);
		float num5 = default(float);
		Weapon weapon = default(Weapon);
		RapidDamageInstance rapidDamageInstance3 = default(RapidDamageInstance);
		EnemyController enemyController2 = default(EnemyController);
		while (true)
		{
			if ((nint)transform8 < gunastropheParticleSystem.Length)
			{
				bool flag18 = (nint)transform7 >= gunastropheParticleSystem.Length;
				bool flag19 = (object)gunastropheParticleSystem[(object)transform7] == null;
				Transform transform9 = gunastropheParticleSystem[(object)transform7].transform;
				bool flag20 = (object)transform9 == null;
				bool flag21 = ((UnityEngine.Object)transform9).m_CachedPtr == (IntPtr)0;
				Transform.set_position_Injected(((UnityEngine.Object)transform9).m_CachedPtr, ref *(Vector3*)(&ret));
				int particles = gunastropheParticleSystem[(object)transform7].GetParticles(_activeParticles, -1, 0);
				if (particles <= 0)
				{
					break;
				}
				ApplyParticleVelocity(_activeParticles, particles, left, num3, top, bottom);
				gunastropheParticleSystem[(object)transform7].SetParticles(_activeParticles, particles, 0);
				Extensions.Shuffle(_activeParticles);
				float num4 = base.PAmount();
				bool flag22 = !(num5 > 0f);
				int num6 = 0;
				weapon = (Weapon)particles;
				num2 = num5;
				EnemyController enemyController = enemyController2;
				int num7 = 0;
				float num8 = num5;
				Transform transform10 = null;
				if (!flag22)
				{
					bool flag25;
					do
					{
						bool flag23 = _activeParticles == null;
						int num9 = transform10 % particles;
						object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 80));
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800048B0");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-4C]");
						enemyController2 = (EnemyController)0;
						bool flag24 = InvisProjectilesPool == null;
						Projectile projectile = InvisProjectilesPool.SpawnAt((float2)num5, this, (int)transform10);
						Transform transform11 = (Transform)(transform10 + 1);
						flag25 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num5) > System.Runtime.CompilerServices.Unsafe.As<Transform, UIntPtr>(ref transform11);
						num6 = (int)transform10;
						weapon = this;
						num2 = (float)transform11;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-4C]");
						enemyController = (EnemyController)0;
						num7 = (int)transform10;
						num8 = (float)transform11;
						transform10 = transform11;
					}
					while (flag25);
				}
				transform7 = (Transform)(transform7 + 1);
				SignalBus signalBus = (SignalBus)num6;
				transform8 = transform7;
				continue;
			}
			List<RapidDamageInstance> rapidDamageInstances = _rapidDamageInstances;
			bool flag26 = _rapidDamageInstances == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ rax_v89 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.RapidDamageInstance>)+18]");
			bool flag27 = (nint)0 <= (nint)0;
			RapidDamageInstance rapidDamageInstance = (RapidDamageInstance)weapon;
			if (!flag27)
			{
				Transform transform12 = null;
				bool flag37;
				do
				{
					List<RapidDamageInstance> rapidDamageInstances2 = _rapidDamageInstances;
					bool flag28 = _rapidDamageInstances == null;
					Transform obj4 = transform12;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ r14_v19 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.RapidDamageInstance>)+18]");
					bool flag29 = (nint)obj4 >= 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ r14_v19 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.RapidDamageInstance>)+10]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ r14_v19 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.RapidDamageInstance>)+10]");
					bool flag30 = (nint)0 == 0;
					Transform obj6 = transform12;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ rdx_v59+18]");
					bool flag31 = (nint)obj6 >= 0;
					object obj7 = transform12 * 4;
					object obj8 = (object)transform12 + obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ rdx_v59+40+v2350 @ rcx_v79*8]");
					_ = 0;
					float deltaTime;
					if (PauseSystem._paused)
					{
						deltaTime = 0f;
					}
					else
					{
						object obj9 = Time.deltaTime;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ rdx_v59+40+v2350 @ rcx_v79*8]");
						deltaTime = 0f;
					}
					Transform playerOptions = (Transform)(object)_playerOptions;
					bool flag32 = _playerOptions == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rdi_v35 (UnityEngine.Transform)+68]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rdi_v35 (UnityEngine.Transform)+58]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rdi_v35 (UnityEngine.Transform)+78]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rdi_v35 (UnityEngine.Transform)+78]");
								object obj10 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2565 @ rax_v118+2CC]");
								if ((nint)0 != 0)
								{
									goto IL_0c6c;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rdi_v35 (UnityEngine.Transform)+50]");
							bool flag33 = (nint)0 == 0;
						}
					}
					goto IL_0c6c;
					IL_0c6c:
					RapidDamageInstance rapidDamageInstance2 = rapidDamageInstance3.Update(deltaTime, _signalBus, (byte)(int)num3 != 0);
					Transform obj11 = transform12;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ r14_v19 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.RapidDamageInstance>)+18]");
					bool flag34 = (nint)obj11 >= 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ r14_v19 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.RapidDamageInstance>)+10]");
					object obj12 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ r14_v19 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.RapidDamageInstance>)+10]");
					bool flag35 = (nint)0 == 0;
					Transform obj13 = transform12;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v376 @ rcx_v85+18]");
					bool flag36 = (nint)obj13 >= 0;
					object obj14 = transform12 * 4;
					object obj15 = (object)transform12 + obj14;
					_ = rapidDamageInstance2.RemainingDamage;
					enemyController2 = rapidDamageInstance2.Target;
					_ = rapidDamageInstance2.Target;
					num2 = rapidDamageInstance2._timeUntilNextDamage;
					_ = rapidDamageInstance2._timeUntilNextDamage;
					rapidDamageInstance = rapidDamageInstance2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ r14_v19 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.RapidDamageInstance>)+1C]");
					_ = (nint)0 + (nint)1;
					transform12 = (Transform)(transform12 + 1);
					Transform obj16 = transform12;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ rax_v89 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.RapidDamageInstance>)+18]");
					flag37 = (nint)obj16 < 0;
					SignalBus signalBus = _signalBus;
					num3 = num3;
				}
				while (flag37);
			}
			Transform rapidDamageInstances3 = (Transform)(object)_rapidDamageInstances;
			bool flag38 = (nint)_rapidDamageInstances < 0;
			bool flag39 = _rapidDamageInstances == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rdi_v29 (UnityEngine.Transform)+18]");
			Transform transform13 = (Transform)(-1);
			if (flag38)
			{
				break;
			}
			object obj28;
			do
			{
				List<RapidDamageInstance> rapidDamageInstances4 = _rapidDamageInstances;
				bool flag40 = _rapidDamageInstances == null;
				Transform obj17 = transform13;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v316 @ rdx_v51 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.RapidDamageInstance>)+18]");
				bool flag41 = (nint)obj17 >= 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v316 @ rdx_v51 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.RapidDamageInstance>)+10]");
				object obj18 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v316 @ rdx_v51 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.RapidDamageInstance>)+10]");
				bool flag42 = (nint)0 == 0;
				Transform obj19 = transform13;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ rdx_v52+18]");
				bool flag43 = (nint)obj19 >= 0;
				object obj20 = transform13 * 4;
				object obj21 = (object)transform13 + obj20;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ rdx_v52+20+v379 @ rcx_v73*8]");
				bool flag49;
				if ((nint)0 < (nint)0)
				{
					List<RapidDamageInstance> rapidDamageInstances5 = _rapidDamageInstances;
					bool flag44 = _rapidDamageInstances == null;
					Transform obj22 = transform13;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ rdx_v56 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.RapidDamageInstance>)+18]");
					bool flag45 = (nint)obj22 >= 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ rdx_v56 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.RapidDamageInstance>)+10]");
					object obj23 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ rdx_v56 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.RapidDamageInstance>)+10]");
					bool flag46 = (nint)0 == 0;
					Transform obj24 = transform13;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ rdx_v57+18]");
					bool flag47 = (nint)obj24 >= 0;
					object obj25 = transform13 * 4;
					object obj26 = (object)transform13 + obj25;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ rdx_v57+30+v380 @ rcx_v77*8]");
					object obj27 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ rdx_v57+30+v380 @ rcx_v77*8]");
					bool flag48 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v356 @ rax_v97+260]");
					flag49 = (nint)0 < (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v356 @ rax_v97+260]");
					if ((nint)0 == 0)
					{
						goto IL_089f;
					}
				}
				flag49 = (nint)_rapidDamageInstances < 0;
				bool flag50 = _rapidDamageInstances == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805F9370");
				goto IL_089f;
				IL_089f:
				transform13 = (Transform)(transform13 - 1);
				obj28 = !flag49;
			}
			while (obj28 != null);
			break;
		}
	}

	public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		//IL_001c: Expected O, but got I4
		if (index == 0)
		{
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			float num = base.PDuration();
			float durationMillis = default(float);
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.EX_Ammo2_Gunastrophe_SFX, soundConfig, durationMillis, 1, time);
		}
		EmitParticles(5);
		return null;
	}

	public unsafe Vector3 GetRandomActiveParticlePosition()
	{
		//IL_00bb: Expected O, but got I4
		//IL_003a: Expected I4, but got I8
		//IL_00ea: Expected O, but got I4
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		//IL_008d: Expected F4, but got I
		//IL_0088: Expected native int or pointer, but got O
		//IL_00a2: Expected F4, but got I
		//IL_009d: Expected native int or pointer, but got O
		ParticleSystem[] gunastropheParticleSystem = _gunastropheParticleSystem;
		object obj = UnityEngine.Random.RandomRangeInt(0, gunastropheParticleSystem.Length);
		bool flag = (nint)obj >= gunastropheParticleSystem.Length;
		int particles = gunastropheParticleSystem[obj].GetParticles(_activeParticles, -1, 0);
		ParticleSystem.Particle[] activeParticles = _activeParticles;
		object obj2 = UnityEngine.Random.RandomRangeInt(0, particles);
		bool flag2 = (nint)obj2 >= activeParticles.Length;
		object obj3 = obj2 * 132;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ rcx_v14+20+v91 @ rbx_v6 (Particle[])]");
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ rcx_v14+28+v91 @ rbx_v6 (Particle[])]");
		((Vector3*)(nint)vector)->z = 0f;
		return vector;
	}

	public unsafe void EmitParticles(int amount)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_00b8: Expected O, but got I4
		//IL_00c9: Expected O, but got I4
		//IL_0144: Expected I4, but got I8
		//IL_01a4: Expected O, but got I4
		//IL_038e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0393: Expected O, but got Unknown
		//IL_03cf: Expected I4, but got I8
		//IL_042c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0431: Expected O, but got Unknown
		//IL_0444: Expected O, but got Ref
		//IL_045e: Expected O, but got I4
		//IL_046e: Expected O, but got Ref
		//IL_02a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02aa: Expected O, but got Unknown
		//IL_02b3: Expected O, but got I4
		//IL_02bc: Expected O, but got I4
		//IL_0205: Expected O, but got F4
		//IL_0236: Expected O, but got I4
		//IL_02c9->IL04b3: Incompatible stack heights: 5 vs 2
		//IL_0266->IL047c: Incompatible stack heights: 6 vs 5
		//IL_026b->IL026b: Incompatible stack heights: 6 vs 5
		object obj2 = default(object);
		object obj = obj2 - 360;
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		_ = 0;
		bool flag = !characterController._isFlipped;
		Vector3 vector = _cameraOrthographicSize;
		if (!flag)
		{
			Vector3 vector2 = vector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			vector = (Vector3)(vector2 ^ 0);
		}
		float num = (float)vector * 0.5f;
		Transform transform = base.transform;
		bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
		Transform transform2 = base.transform;
		bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
		ParticleSystem[] gunastropheParticleSystem = _gunastropheParticleSystem;
		object obj3 = 0;
		int count = amount;
		object obj4 = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = default(ParticleSystem.MinMaxCurve);
		while ((nint)obj4 < gunastropheParticleSystem.Length)
		{
			bool flag4 = (nint)obj3 >= gunastropheParticleSystem.Length;
			ParticleSystem particleSystem = gunastropheParticleSystem[obj3];
			bool flag5 = (object)gunastropheParticleSystem[obj3] == null;
			int particles = gunastropheParticleSystem[obj3].GetParticles(_activeParticles, -1, 0);
			_ = 0;
			_ = 1f;
			_ = 0;
			_ = 1;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rbp_v1+A0]");
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			obj = 0;
			bool flag6 = ((UnityEngine.Object)particleSystem).m_CachedPtr == (IntPtr)0;
			object obj5 = obj - 112;
			ParticleSystem.Emit_Injected(((UnityEngine.Object)particleSystem).m_CachedPtr, ref *(ParticleSystem.EmitParams*)obj5, count);
			int particles2 = gunastropheParticleSystem[obj3].GetParticles(_activeParticles, -1, 0);
			_ = gunastropheParticleSystem[obj3];
			_ = gunastropheParticleSystem[obj3];
			float num2 = base.PDuration();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rbp_v1+A0]");
			float constant = 0f / 1000f;
			ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(constant);
			ParticleSystem.MainModule mainModule = (ParticleSystem.MainModule)(obj + 392);
			_ = 0;
			((ParticleSystem.MainModule*)mainModule)->startLifetime = (ParticleSystem.MinMaxCurve)(&minMaxCurve2);
			bool flag7 = particles >= particles2;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)0;
			int num3 = particles;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)(&minMaxCurve2);
			if (!flag7)
			{
				do
				{
					float value = UnityEngine.Random.value;
					Transform activeParticles = (Transform)(object)_activeParticles;
					float num4 = value * (float)Math.PI;
					num = num4 + num4;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
					float num5 = num * _particleLaunchVelocity;
					float num6 = num5 + num5;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
					float num7 = num * _particleLaunchVelocity;
					minMaxCurve3 = (ParticleSystem.MinMaxCurve)(num7 + num7);
					int num8 = num3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rbx_v16 (UnityEngine.Transform)+18]");
					bool flag8 = (nint)num8 >= (nint)0;
					minMaxCurve4 = (ParticleSystem.MinMaxCurve)(num3 * 132);
					num3++;
					_ = 0;
				}
				while (num3 < particles2);
			}
			gunastropheParticleSystem[obj3].SetParticles(_activeParticles, particles2, 0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rbp_v1+178]");
			count = 0;
			obj3++;
			minMaxCurve = (ParticleSystem.MinMaxCurve)0;
			minMaxCurve2 = (ParticleSystem.MinMaxCurve)0;
			obj4 = obj3;
		}
	}

	private void ApplyParticleVelocity(ParticleSystem.Particle[] particles, int particleCount, float left, float right, float top, float bottom)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		//IL_0073: Expected O, but got I4
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		//IL_01a9: Expected O, but got F4
		//IL_01bf: Expected O, but got I
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Expected O, but got Unknown
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected O, but got Unknown
		//IL_00e8: Invalid comparison between F4 and I
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Expected O, but got Unknown
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Expected O, but got Unknown
		if (particleCount <= 0)
		{
			return;
		}
		object obj2 = default(object);
		object obj = obj2 - 40;
		object obj3 = 0;
		object obj10 = default(object);
		object obj12 = default(object);
		do
		{
			object obj4 = obj3 * 132;
			object obj5 = Time.deltaTime;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rsi_v6+2C+particles @ rdx (Particle[])]");
			object obj6 = (nint)0 * (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rsi_v6+34+particles @ rdx (Particle[])]");
			float num = 0f + (float)obj6;
			object obj7 = obj3 * 132;
			object obj8 = obj3 * 132;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v445 @ rax_v19+20+particles @ rdx (Particle[])]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ rbp_v2+50]");
			if (num2 <= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v446 @ rax_v21+20+particles @ rdx (Particle[])]");
				if (!(left > 0f))
				{
					goto IL_010b;
				}
			}
			Ex_Ammo2Weapon ex_Ammo2Weapon = (Ex_Ammo2Weapon)(obj3 * 132);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rcx_v12 (VampireSurvivors.Objects.Weapons.Ex_Ammo2Weapon)+34+particles @ rdx (Particle[])]");
			_ = 0;
			_ = 0;
			goto IL_010b;
			IL_0215:
			obj3++;
			continue;
			IL_010b:
			object obj9 = obj3 * 132;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ rbp_v2+60]");
			if (0 <= (nint)obj10)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v449 @ rax_v28+24+particles @ rdx (Particle[])]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ rbp_v2+58]");
				if (num3 <= 0)
				{
					goto IL_0215;
				}
				object obj11 = obj12;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v449 @ rax_v28+20+particles @ rdx (Particle[])]");
				_ = 0;
				object obj11 = obj12;
			}
			ex_Ammo2Weapon = (Ex_Ammo2Weapon)(obj3 * 132);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rcx_v12 (VampireSurvivors.Objects.Weapons.Ex_Ammo2Weapon)+34+particles @ rdx (Particle[])]");
			_ = 0;
			_ = 0;
			goto IL_0215;
		}
		while ((nint)obj3 < particleCount);
	}

	protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0236: Expected I4, but got O
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
						goto IL_0222;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							Projectile component2 = gameObject2.GetComponent<Projectile>();
							if (base._003CCanCrit_003Ek__BackingField)
							{
								base.StandardCritical(second, first);
								if ((object)component2 == null)
								{
									goto IL_0228;
								}
							}
							else
							{
								if ((object)component2 == null)
								{
									goto IL_0228;
								}
								if (!component2.HasAlreadyHitObject(component))
								{
									base.DealDamage(component);
								}
							}
							HashSet<IDamageable> objectsHit = component2._objectsHit;
							if (component2._objectsHit != null)
							{
								if (objectsHit._count != 1 || !HasActiveArcanaOfType(ArcanaType.T19_FIRE))
								{
									goto IL_0222;
								}
								GameManager gameMan = _gameMan;
								if ((object)_gameMan != null)
								{
									float2 position = component.position;
									if (gameMan._arcanaManager != null)
									{
										Vector2 pos = default(Vector2);
										gameMan._arcanaManager.TriggerFireExplosion(pos);
										goto IL_0222;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0228;
		IL_0222:
		return false;
		IL_0228:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public Ex_Ammo2Weapon()
	{
		List<RapidDamageInstance> rapidDamageInstances = new List<RapidDamageInstance>();
		_rapidDamageInstances = rapidDamageInstances;
		base._002Ector();
	}

	internal unsafe static void _003CApplyParticleVelocity_003Eg__BounceParticle_007C22_0(ref ParticleSystem.Particle particle, float bouncePositionX, float bouncePositionY, float xBounce = 1f, float yBounce = 1f)
	{
		object obj = default(object);
		ref ParticleSystem.Particle reference = ref *(ParticleSystem.Particle*)obj;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [particle @ rcx (Particle&)+14]");
		_ = 0;
	}
}
