using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class Sample1Weapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass12_0
	{
		public int localIndex;

		public Sample1Weapon _003C_003E4__this;

		internal void _003CFire_003Eb__0()
		{
			//IL_013c: Expected O, but got I4
			//IL_00b4: Expected O, but got I
			//IL_0079->IL0105: Incompatible stack heights: 1 vs 0
			//IL_009e->IL0105: Incompatible stack heights: 1 vs 0
			//IL_00dc->IL0105: Incompatible stack heights: 1 vs 0
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
							Sample1Weapon sample1Weapon = _003C_003E4__this;
							if ((object)_003C_003E4__this != null)
							{
								Vector2 pos = default(Vector2);
								_003C_003E4__this.FireSample(pos, localIndex, sample1Weapon._targetTransform);
								return;
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public Sample1Weapon _003C_003E4__this;

		public float2 pos;
	}

	private sealed class _003C_003Ec__DisplayClass14_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals1;

		internal void _003CSpawnExplosionClustersAt_003Eb__0()
		{
			//IL_0131: Expected O, but got I4
			//IL_00a8->IL00fa: Incompatible stack heights: 1 vs 0
			//IL_00ca->IL00fa: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass14_0 obj = CS_0024_003C_003E8__locals1;
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
					_003C_003Ec__DisplayClass14_0 obj3 = CS_0024_003C_003E8__locals1;
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

	protected int _samplesAmount = 8;

	protected List<float2> screenGrid;

	private ParticleEmitterManager _particlesManager;

	private ParticleSystem _pfxEmitter;

	private ParticleSystem _pfxEmitter2;

	protected uint[] tints;

	private float[] _randomOffsets;

	private int _randomOffsetsIndex;

	public override float SecondaryPPower()
	{
		//IL_0005: Expected I, but got O
		//IL_0015: Expected O, but got I
		//IL_0025: Expected O, but got I
		nint num = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rdx_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.Sample1Weapon>)+428]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rdx_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.Sample1Weapon>)+430]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v2 @ rax_v1 (should have been resolved before IL gen)");
		/*Error: End of method reached without returning.*/;
	}

	protected override void MakeLevelOne()
	{
		//IL_005c: Expected O, but got I4
		//IL_0073: Expected O, but got I4
		base.MakeLevelOne();
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		CharacterWeaponsManager weaponsManager = characterController._weaponsManager;
		List<Equipment> list = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField;
		Action onComplete = delegate
		{
			base.Fire();
		};
		bool flag = list._size == 0;
		object obj = 1000;
		if (!flag)
		{
			obj = 100;
		}
		float duration = (float)obj * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	protected override void OnStart()
	{
		//IL_0053: Expected I, but got O
		//IL_00b1: Expected O, but got I4
		//IL_00c0: Expected O, but got I4
		_explosionType = WeaponType.C1_SAMPLES1_EXPLOSION;
		base.ResetFiringTimer();
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		GameManager gameMan = _gameMan;
		PhysicsManager physicsManager = gameMan._physicsManager;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Weapons.Sample1Weapon>)+360]");
		ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
		nint num = (nint)this;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		Collider collider = physics.add.overlap(_projectilePool, physicsManager._playerGroup, collideCallback, processCallback, callbackContext);
		Collider collider2 = collider.setName("Projectiles>Player");
		object obj2;
		object obj3 = default(object);
		do
		{
			float[] randomOffsets = _randomOffsets;
			object obj = -64;
			obj2 = 0 + 1;
			float num2 = (float)obj * (1f / 128f);
			float num3 = num2 * 0.64f;
			randomOffsets[obj3] = num3;
		}
		while ((nint)obj2 < 128);
		Extensions.Shuffle(_randomOffsets);
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_008b: Expected O, but got I4
		//IL_0140: Expected O, but got I4
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected O, but got Unknown
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		base.InitWeapon(characterController, weaponType);
		ParticleEmitterManager particlesManager = _particlesManager;
		if ((object)_particlesManager == null || ((UnityEngine.Object)particlesManager).m_CachedPtr == (IntPtr)0)
		{
			GenerateParticleSystems();
		}
		List<float2> list = screenGrid;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rax_v8 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
		if ((nint)0 > (nint)0)
		{
			return;
		}
		object obj = 1;
		float2 item = default(float2);
		do
		{
			object obj2 = 1;
			do
			{
				screenGrid.Add(item);
				obj2++;
			}
			while ((nint)obj2 < 10);
			obj++;
		}
		while ((nint)obj < 10);
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Expected O, but got Unknown
		//IL_0188: Invalid comparison between O and F4
		//IL_0030: Invalid comparison between F4 and I4
		Extensions.Shuffle(screenGrid);
		float num2 = default(float);
		if (_samplesAmount > 0)
		{
			int num = 0;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			do
			{
				WeaponData currentWeaponData = _currentWeaponData;
				num2 = (float)num * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
				if (!(num2 > 0f))
				{
					Vector2 playerPos = base.PlayerPos;
					FireSample(playerPos, num, _targetTransform);
				}
				else
				{
					_003C_003Ec__DisplayClass12_0 CS_0024_003C_003E8__locals10 = new _003C_003Ec__DisplayClass12_0();
					CS_0024_003C_003E8__locals10._003C_003E4__this = this;
					CS_0024_003C_003E8__locals10.localIndex = num;
					WeaponData currentWeaponData2 = _currentWeaponData;
					Action onComplete = delegate
					{
						//IL_013c: Expected O, but got I4
						//IL_00b4: Expected O, but got I
						//IL_0079->IL0105: Incompatible stack heights: 1 vs 0
						//IL_009e->IL0105: Incompatible stack heights: 1 vs 0
						//IL_00dc->IL0105: Incompatible stack heights: 1 vs 0
						if ((object)CS_0024_003C_003E8__locals10._003C_003E4__this != null)
						{
							GameObject gameObject = CS_0024_003C_003E8__locals10._003C_003E4__this.gameObject;
							if ((object)gameObject != null)
							{
								bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
								object obj2 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
								if (obj2 == null)
								{
									return;
								}
								GameObject gameObject2 = (GameObject)(object)CS_0024_003C_003E8__locals10._003C_003E4__this;
								if ((object)CS_0024_003C_003E8__locals10._003C_003E4__this != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v7 (UnityEngine.GameObject)+58]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v7 (UnityEngine.GameObject)+58]");
										float2 position = ((ArcadeSprite)0).position;
										Sample1Weapon sample1Weapon = CS_0024_003C_003E8__locals10._003C_003E4__this;
										if ((object)CS_0024_003C_003E8__locals10._003C_003E4__this != null)
										{
											Vector2 pos = default(Vector2);
											CS_0024_003C_003E8__locals10._003C_003E4__this.FireSample(pos, CS_0024_003C_003E8__locals10.localIndex, sample1Weapon._targetTransform);
											return;
										}
									}
								}
							}
						}
						throw new NullReferenceException();
					};
					float num3 = (float)num * currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
					num2 = num3 * 0.001f;
					Timer lastShotTimer = Timers.Register(num2, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					_lastShotTimer = lastShotTimer;
				}
				num++;
			}
			while (num < _samplesAmount);
		}
		float num4 = base.PInterval();
		float num5 = _lastFiringInterval - num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj = num5 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num6 = base.PInterval();
			_lastFiringInterval = num2;
			base.ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	public void FireSample(Vector2 pos, int index, Transform target = null)
	{
		//IL_0062: Expected I, but got O
		//IL_0070: Expected I, but got O
		//IL_0080: Expected O, but got I
		//IL_0100: Expected O, but got I4
		//IL_01f5: Expected O, but got I
		//IL_00bc: Expected O, but got I
		//IL_0116: Expected O, but got I
		//IL_00f2: Expected O, but got I4
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Transform targetTransform = _targetTransform;
		float2 float5 = default(float2);
		Projectile projectile = base.FireOneProjectile(float5, index, _targetTransform);
		bool flag = (object)projectile == null;
		ArcadeSprite arcadeSprite = null;
		nint num;
		object obj3;
		if (!flag)
		{
			num = (nint)projectile;
			nint num2 = (nint)typeof(Sample1Projectile);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Sample1Projectile>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Sample1Projectile>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ rax_v33+FFFFFFF8+v169 @ rax_v29*8]");
				if (0 == (nint)typeof(Sample1Projectile))
				{
					obj3 = 1;
					goto IL_01d8;
				}
			}
			obj3 = 0;
			goto IL_01d8;
		}
		goto IL_0208;
		IL_0208:
		if ((object)arcadeSprite != null && ((UnityEngine.Object)arcadeSprite).m_CachedPtr != (IntPtr)0)
		{
			float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			List<float2> list = screenGrid;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rax_v20 (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
			if ((nint)index < (nint)0)
			{
				float2 position3 = arcadeSprite.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C24430");
				float duration = (float)float5 / 0.005f;
				((Sample1Projectile)arcadeSprite).SetFloorTarget(duration, float5);
			}
			else
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			}
		}
		return;
		IL_01d8:
		bool flag2 = obj3 == null;
		arcadeSprite = null;
		targetTransform = (Transform)num;
		if (!flag2)
		{
			arcadeSprite = projectile;
			targetTransform = (Transform)num;
		}
		goto IL_0208;
	}

	public unsafe void SpawnExplosionClustersAt(float2 pos)
	{
		//IL_0056: Invalid comparison between O and F4
		//IL_00f7: Expected I, but got O
		//IL_010d: Expected O, but got I
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Expected O, but got Unknown
		//IL_0184: Expected I, but got O
		//IL_01e2: Expected O, but got I4
		//IL_01f9: Expected I, but got I8
		//IL_01b6: Invalid comparison between F4 and I4
		//IL_016d: Expected I, but got I8
		_003C_003Ec__DisplayClass14_0 obj = new _003C_003Ec__DisplayClass14_0();
		obj._003C_003E4__this = this;
		obj.pos = pos;
		float2 float5 = default(float2);
		Projectile projectile = SpawnExplosionAt(float5, 0, 1, 0f);
		float num = base.PAmount();
		if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float5) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f))
		{
			return;
		}
		int num2 = 1;
		float num6;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		do
		{
			_003C_003Ec__DisplayClass14_1 obj2 = new _003C_003Ec__DisplayClass14_1();
			obj2.CS_0024_003C_003E8__locals1 = obj;
			obj2.localIndex = num2;
			WeaponData currentWeaponData = _currentWeaponData;
			Action action = null;
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v290 @ r10_v5 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass14_1._003CSpawnExplosionClustersAt_003Eb__0);
			((Delegate)action).m_target = obj2;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v290 @ r10_v5 (Il2CppMethodInfo)+4C]");
			object obj3 = (nint)0 >> 4;
			object obj4 = obj3 & 1;
			nint num4;
			if (obj4 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v290 @ r10_v5 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num4 = unchecked((nint)6447293664L);
					goto IL_01d9;
				}
			}
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			num4 = ((Delegate)action).method_ptr;
			goto IL_01d9;
			IL_01d9:
			object obj5 = 24;
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			float num5 = (float)num2 * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
			num6 = num5 * 0.001f;
			Timer lastShotTimer = Timers.Register(num6, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_lastShotTimer = lastShotTimer;
			num2++;
			float num7 = base.PAmount();
		}
		while (num6 > (float)num2);
	}

	public override Projectile SpawnExplosionAt(float2 pos, int enemiesHit = 0, int damage = 1, float area = 1f)
	{
		//IL_027b: Expected I4, but got I8
		//IL_02ab: Expected O, but got I4
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b9: Expected O, but got Unknown
		//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c7: Expected I4, but got Unknown
		//IL_02fb: Expected I4, but got I8
		//IL_032b: Expected O, but got I4
		//IL_0334: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Expected O, but got Unknown
		//IL_0342: Unknown result type (might be due to invalid IL or missing references)
		//IL_0347: Expected I4, but got Unknown
		//IL_0156: Expected I, but got O
		//IL_00d0: Expected I, but got O
		//IL_0206: Expected I, but got O
		if (_secondaryPool != null)
		{
			goto IL_023e;
		}
		Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(_explosionType);
		BulletPool secondaryPool = new BulletPool(projectilePrefab);
		_secondaryPool = secondaryPool;
		Factory add;
		ArcadeColliderType enemies;
		ArcadePhysicsCallback collideCallback;
		ArcadeColliderType secondaryPool2;
		if (_secondaryOvarlapDamageType != WeaponType.CURSE)
		{
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene = ArcadePhysics.s_scene;
				ArcadePhysics physics = s_scene.physics;
				add = physics.add;
				GameManager core = GM.Core;
				enemies = core.Enemies;
				nint method = default(nint);
				collideCallback = new ArcadePhysicsCallback(this, method);
				nint num = (nint)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v638 @ r8_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.Sample1Weapon>)+370]");
				method = 0;
				secondaryPool2 = _secondaryPool;
				goto IL_0175;
			}
		}
		else if ((object)GM.Core != null)
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			add = physics2.add;
			GameManager core2 = GM.Core;
			enemies = core2.Enemies;
			collideCallback = null;
			nint num2 = (nint)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ r8_v13 (Il2CppClass<VampireSurvivors.Objects.Weapons.Sample1Weapon>)+380]");
			nint method = 0;
			secondaryPool2 = _secondaryPool;
			goto IL_0175;
		}
		goto IL_0369;
		IL_0369:
		throw new NullReferenceException();
		IL_0175:
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		Collider collider = add.overlap(secondaryPool2, enemies, collideCallback, processCallback, callbackContext);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene3 = ArcadePhysics.s_scene;
			ArcadePhysics physics3 = s_scene3.physics;
			GameManager core3 = GM.Core;
			PhysicsManager physicsManager = core3._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v678 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Sample1Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num3 = (nint)this;
			Collider collider2 = physics3.add.overlap(_secondaryPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
			goto IL_023e;
		}
		goto IL_0369;
		IL_023e:
		float[] randomOffsets = _randomOffsets;
		int num4 = ++_randomOffsetsIndex;
		int num5 = (int)(_randomOffsetsIndex & 0x8000007FL);
		if ((nint)_randomOffsets < 0)
		{
			object obj = num5 - 1;
			object obj2 = obj | -128;
			num5 = obj2 + 1;
		}
		if (num5 < randomOffsets.Length)
		{
			int randomOffsetsIndex = num4 + 1;
			_randomOffsetsIndex = randomOffsetsIndex;
			int num6 = (int)(num4 & 0x8000007FL);
			if ((nint)_randomOffsets < 0)
			{
				object obj3 = num6 - 1;
				object obj4 = obj3 | -128;
				num6 = obj4 + 1;
			}
			float2 pos2 = default(float2);
			if (num6 < randomOffsets.Length)
			{
				return _secondaryPool.SpawnAt(pos2, this, enemiesHit);
			}
		}
		return (Projectile)(object)new IndexOutOfRangeException();
	}

	protected override bool OnBulletOverlapsPlayer(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_021d: Expected I4, but got O
		//IL_0119: Expected I, but got O
		//IL_0127: Expected I, but got O
		//IL_0137: Expected O, but got I
		//IL_01b7: Expected O, but got I4
		//IL_0173: Expected O, but got I
		//IL_01a9: Expected O, but got I4
		Projectile component2;
		Sample1Projectile sample1Projectile;
		object obj3;
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				VampireSurvivors.Objects.Characters.CharacterController component = gameObject.GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
				if ((object)component != null)
				{
					if (component._isDead || component.IsDisconnectedFromOnlinePlay)
					{
						goto IL_0209;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 == null)
							{
								sample1Projectile = null;
								goto IL_0266;
							}
							nint num = (nint)component2;
							nint num2 = (nint)typeof(Sample1Projectile);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Sample1Projectile>)+130]");
							object obj = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Sample1Projectile>)+130]");
							if (num3 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
								object obj2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ rax_v28+FFFFFFF8+v240 @ rax_v24*8]");
								if (0 == (nint)typeof(Sample1Projectile))
								{
									obj3 = 1;
									goto IL_023f;
								}
							}
							obj3 = 0;
							goto IL_023f;
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_023f:
		bool flag = obj3 == null;
		sample1Projectile = null;
		if (!flag)
		{
			sample1Projectile = (Sample1Projectile)component2;
		}
		goto IL_0266;
		IL_0266:
		if ((object)sample1Projectile != null && ((UnityEngine.Object)sample1Projectile).m_CachedPtr != (IntPtr)0)
		{
			sample1Projectile.Break();
			return true;
		}
		goto IL_0209;
		IL_0209:
		return false;
	}

	protected override bool OnSecondaryBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_01a8: Expected I4, but got O
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
						goto IL_01c5;
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
									float num = SecondaryPPower();
									WeaponData currentWeaponData = _currentWeaponData;
									HitVfxType showHitVfx = ((_currentWeaponData == null) ? HitVfxType.Default : currentWeaponData._003ChitVFX_003Ek__BackingField);
									float knockback = base.Knockback;
									float num2 = default(float);
									component.GetDamaged(num2, showHitVfx, knockback, WeaponType.VOID, hasKb: false);
									float num3 = num2 + base._003CStatsInflictedDamage_003Ek__BackingField;
									base._003CStatsInflictedDamage_003Ek__BackingField = num3;
									float2 position = component.position;
									Vector2 pos = default(Vector2);
									RenderingExtensions.EmitParticleAt(_pfxEmitter, pos, 10);
									float2 position2 = component.position;
									RenderingExtensions.EmitParticleAt(_pfxEmitter2, pos, 5);
								}
								goto IL_01c5;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_01c5:
		return false;
	}

	private unsafe void GenerateParticleSystems()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0060: Expected O, but got I
		//IL_0205: Expected O, but got I4
		//IL_021e: Expected O, but got Ref
		//IL_0238: Expected native int or pointer, but got O
		//IL_0252: Expected O, but got I
		//IL_0272: Expected O, but got Ref
		//IL_028c: Expected native int or pointer, but got O
		//IL_02a6: Expected O, but got I
		//IL_02c6: Expected O, but got Ref
		//IL_02e0: Expected native int or pointer, but got O
		//IL_08ad: Expected O, but got I4
		//IL_0305: Expected O, but got Ref
		//IL_031f: Expected native int or pointer, but got O
		//IL_08e7: Expected O, but got I
		//IL_0357: Expected O, but got Ref
		//IL_037e: Expected O, but got I
		//IL_0398: Expected native int or pointer, but got O
		//IL_0921: Expected O, but got I
		//IL_03d0: Expected O, but got Ref
		//IL_03f7: Expected O, but got I
		//IL_041e: Expected O, but got I
		//IL_0438: Expected native int or pointer, but got O
		//IL_0460: Expected O, but got I
		//IL_095b: Expected O, but got I
		//IL_057e: Expected O, but got I4
		//IL_0597: Expected O, but got Ref
		//IL_05b1: Expected native int or pointer, but got O
		//IL_05cb: Expected O, but got I
		//IL_05eb: Expected O, but got Ref
		//IL_0605: Expected native int or pointer, but got O
		//IL_061f: Expected O, but got I
		//IL_063f: Expected O, but got Ref
		//IL_0659: Expected native int or pointer, but got O
		//IL_09e2: Expected O, but got I
		//IL_0691: Expected O, but got Ref
		//IL_06ab: Expected native int or pointer, but got O
		//IL_0a1c: Expected O, but got I
		//IL_06e3: Expected O, but got Ref
		//IL_070a: Expected O, but got I
		//IL_0724: Expected native int or pointer, but got O
		//IL_0a56: Expected O, but got I
		//IL_075c: Expected O, but got Ref
		//IL_0776: Expected native int or pointer, but got O
		//IL_0a90: Expected O, but got I
		//IL_07ae: Expected O, but got Ref
		//IL_07c8: Expected native int or pointer, but got O
		//IL_0aca: Expected O, but got I
		//IL_0b6f: Expected O, but got I
		//IL_0b90: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		GameObject gameObject = base.gameObject;
		_ = 0;
		ParticleEmitterManager particlesManager;
		if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 704))))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+2C0]");
			particlesManager = (ParticleEmitterManager)0;
		}
		else
		{
			particlesManager = gameObject.AddComponent<ParticleEmitterManager>();
		}
		_particlesManager = particlesManager;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"HitCloud1");
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
			((List<object>)(object)list).AddWithResize((object)"HitCloud2");
		}
		else
		{
			int size2 = list._size + 1;
			list._size = size2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(500f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 216));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+D8]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+E8]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 248));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+F8]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+108]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 280));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(50f, 100f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+128]");
		_ = 0;
		particleSystemConfig._speedX = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-80]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-70]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 312));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(-80f, -100f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+138]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+148]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-68]");
		particleSystemConfig._speedY = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-58]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-48]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 344));
		_ = 0;
		_ = 4;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+2C0]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+158]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+168]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-40]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-30]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-20]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 376));
		_ = 0;
		_ = 1082130432;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+2C0]");
		particleSystemConfig._frequency = (float?)(object)0;
		_ = 0;
		_ = 2;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+2C0]");
		particleSystemConfig._blendMode = (BlendMode?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0.35f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+178]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+188]");
		obj = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-18]");
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+8]");
		_ = 0;
		particleSystemConfig._on = false;
		particleSystemConfig._tintRandom = tints;
		ParticleSystem pfxEmitter = _particlesManager.CreateEmitter(particleSystemConfig, null, "PfxEmitter2");
		_pfxEmitter2 = pfxEmitter;
		Transform transform = _pfxEmitter2.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
		List<string> list2 = new List<string>();
		list2._002Ector();
		int version3 = list2._version + 1;
		list2._version = version3;
		string[] items3 = list2._items;
		if (list2._size >= items3.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"PfxLine2");
		}
		else
		{
			int size3 = list2._size + 1;
			list2._size = size3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig2._frame = list2;
		minMaxCurve = new ParticleSystem.MinMaxCurve(300f);
		particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 408));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(0f, 0f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+198]");
		particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1A8]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 440));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1B8]");
		particleSystemConfig2._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1C8]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve10 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 472));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve10, new ParticleSystem.MinMaxCurve(20f, 30f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1D8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1E8]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+10]");
		particleSystemConfig2._speedX = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+20]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+30]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve11 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 504));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve11, new ParticleSystem.MinMaxCurve(-80f, -100f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1F8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+208]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+38]");
		particleSystemConfig2._speedY = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+48]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+58]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve12 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 536));
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+2C0]");
		particleSystemConfig2._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve12, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+218]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+228]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+60]");
		particleSystemConfig2._scaleX = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+70]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+80]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve13 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 568));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve13, new ParticleSystem.MinMaxCurve(0.05f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+238]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+248]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+88]");
		particleSystemConfig2._scaleY = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+98]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+A8]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve14 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 600));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve14, new ParticleSystem.MinMaxCurve(0.35f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+258]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+268]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+B0]");
		particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+C0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+D0]");
		_ = 0;
		_ = 0;
		_ = 1065353216;
		_ = 1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+2C0]");
		particleSystemConfig2._frequency = (float?)(object)0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+2C0]");
		particleSystemConfig2._blendMode = (BlendMode?)(object)0;
		particleSystemConfig2._tintRandom = tints;
		particleSystemConfig2._on = false;
		bool flag2 = (object)_particlesManager == null;
		ParticleSystem pfxEmitter2 = _particlesManager.CreateEmitter(particleSystemConfig2, null, "PfxEmitter");
		_pfxEmitter = pfxEmitter2;
		bool flag3 = (object)_pfxEmitter == null;
		Transform transform2 = _pfxEmitter.transform;
		bool flag4 = (object)transform2 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v619 @ rax_v104 (UnityEngine.Transform)+10]");
		bool flag5 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v619 @ rax_v104 (UnityEngine.Transform)+10]");
		Vector3 value2 = default(Vector3);
		Transform.set_localPosition_Injected((IntPtr)0, ref value2);
	}

	public Sample1Weapon()
	{
		List<float2> list = new List<float2>();
		screenGrid = list;
		tints = new uint[3] { 16738030u, 13378252u, 16711935u };
		_randomOffsets = new float[128];
		base._002Ector();
	}

	private void _003CMakeLevelOne_003Eb__9_0()
	{
		base.Fire();
	}
}
