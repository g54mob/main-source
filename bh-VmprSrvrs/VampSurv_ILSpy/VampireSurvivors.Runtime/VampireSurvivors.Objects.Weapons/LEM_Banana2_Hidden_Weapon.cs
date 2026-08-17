using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Objects.VFX.Shatter;
using VampireSurvivors.Tools;
using Zenject;

namespace VampireSurvivors.Objects.Weapons;

public class LEM_Banana2_Hidden_Weapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass29_0
	{
		public Transform parent;

		internal void _003CShatterCard_003Eb__0()
		{
			Transform transform = parent;
			if ((object)parent != null && ((UnityEngine.Object)transform).m_CachedPtr != (IntPtr)0)
			{
				GameObject gameObject = parent.gameObject;
				gameObject.SetActive(value: false);
			}
		}
	}

	private Projectile _InvisProjectilePrefab;

	private ParticleSystem[] _ParticleSystems;

	private float _ParticleLaunchVelocity;

	private float _ParticleGravity;

	private Camera _mainCamera;

	private ParticleSystem.Particle[] _activeParticles;

	private BulletPool _invisProjectilesPool;

	private float[] _randomBounceValues;

	private readonly List<RapidDamageInstance> _rapidDamageInstances;

	private Vector3 _cameraOrthographicSize;

	private PhaserSprite _card;

	private ShatterVFX _shatterVfx;

	private MultiTargetTween[] _shatterTweens;

	private unsafe Vector3 _gravityVector
	{
		get
		{
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Expected F4, but got Unknown
			//IL_0020: Expected native int or pointer, but got O
			//IL_002e: Expected native int or pointer, but got O
			//IL_003b: Expected native int or pointer, but got O
			float particleGravity = _ParticleGravity;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			float y = particleGravity ^ 0;
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = 0f;
			((Vector3*)(nint)vector)->z = 0f;
			((Vector3*)(nint)vector)->y = y;
			return vector;
		}
	}

	private unsafe Vector3 ParticleStartPos
	{
		get
		{
			//IL_009f: Expected I, but got O
			//IL_00b7: Expected native int or pointer, but got O
			//IL_00d1: Expected F4, but got I
			//IL_00cc: Expected native int or pointer, but got O
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				Transform transform = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
					nint num = (nint)typeof(Vector3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rax_v15 (Il2CppClass<UnityEngine.Vector3>)+B8]");
					nint num2 = 0;
					Vector3 vector = default(Vector3);
					float x = default(float);
					((Vector3*)(nint)vector)->x = x;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rcx_v11 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
					((Vector3*)(nint)vector)->z = 0f;
					return vector;
				}
			}
			throw new NullReferenceException();
		}
	}

	private int ParticleAmount
	{
		get
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Expected I4, but got Unknown
			float num = base.PAmount();
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,xmm0\"");
			return 50 - this;
		}
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_007c: Expected I, but got O
		//IL_011f: Expected I, but got O
		base.InitWeapon(characterController, weaponType);
		if (_invisProjectilesPool == null)
		{
			BulletPool bulletPool = new BulletPool(_InvisProjectilePrefab);
			bulletPool.UpperLimit = 100;
			_invisProjectilesPool = bulletPool;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v428 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Weapons.LEM_Banana2_Hidden_Weapon>)+350]");
			ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = physics.add.overlap(_invisProjectilesPool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core == null)
			{
				throw new NullReferenceException();
			}
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.LEM_Banana2_Hidden_Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			Collider collider2 = physics2.add.overlap(_invisProjectilesPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
		}
	}

	protected override void Awake()
	{
		//IL_01af: Expected O, but got I
		//IL_0156: Expected O, but got I4
		base.Awake();
		Camera main = Camera.main;
		_mainCamera = main;
		InitBounceValues();
		Bounds bounds = CameraExtensions.OrthographicBounds(_mainCamera);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rax_v7 (UnityEngine.Bounds)+10]");
		float num = 0f * 2f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rax_v7 (UnityEngine.Bounds)+14]");
		float num2 = 0f * 2f;
		Vector2 vector = default(Vector2);
		_cameraOrthographicSize = vector;
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
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v502 @ rax_v19 (should have been resolved before IL gen)");
		object obj2 = default(object);
		ParticleSystem.Particle[] activeParticles = new ParticleSystem.Particle[obj2];
		_activeParticles = activeParticles;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E42]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		GameObject gameObject = base.gameObject;
		PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "LEM_vfx", "LEM_VFX_Card_Cavendish");
		Transform transform = phaserSprite.transform;
		transform.SetParent(_cachedTransform, worldPositionStays: true);
		PhaserSprite phaserSprite2 = phaserSprite.setLocalPosition(vector);
		PhaserSprite phaserSprite3 = phaserSprite2.setScale(0f, (float?)(object)0);
		PhaserSprite card = phaserSprite3.setDepth(1001);
		_card = card;
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
		//IL_0688: Expected O, but got I
		//IL_03f8: Expected O, but got I
		//IL_06ee: Expected O, but got I
		//IL_0445: Unknown result type (might be due to invalid IL or missing references)
		//IL_044a: Expected O, but got Unknown
		//IL_0aea: Expected I4, but got I8
		//IL_073b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0740: Expected O, but got Unknown
		//IL_0b98: Expected O, but got F4
		//IL_0ba8: Expected F4, but got I
		//IL_0472: Expected F4, but got I4
		//IL_01c1: Expected I, but got O
		//IL_020a: Expected O, but got I
		//IL_0248: Expected O, but got I4
		//IL_08dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e2: Expected O, but got Unknown
		//IL_08ed: Expected O, but got I4
		//IL_034c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0351: Expected O, but got Unknown
		//IL_0359: Expected O, but got I4
		//IL_07cd: Expected O, but got I
		//IL_027c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Expected I4, but got Unknown
		//IL_028f: Expected O, but got Ref
		//IL_02a9: Expected O, but got I
		//IL_081a: Unknown result type (might be due to invalid IL or missing references)
		//IL_081f: Expected O, but got Unknown
		//IL_083c: Expected O, but got I
		//IL_0bec: Expected I4, but got F4
		//IL_02d8: Expected I4, but got O
		//IL_02d8: Expected O, but got F4
		//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ea: Expected O, but got Unknown
		//IL_0300: Expected I4, but got O
		//IL_031d: Expected O, but got I
		//IL_0325: Expected I4, but got O
		//IL_0541: Expected O, but got I
		//IL_058e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0593: Expected O, but got Unknown
		//IL_0601: Unknown result type (might be due to invalid IL or missing references)
		//IL_0606: Expected O, but got Unknown
		//IL_04de: Expected O, but got I
		//IL_0906->IL0906: Incompatible stack heights: 2 vs 0
		//IL_0b09->IL08fb: Incompatible stack heights: 16 vs 14
		//IL_08f6->IL0696: Incompatible stack heights: 19 vs 14
		//IL_0366->IL0b29: Incompatible stack heights: 16 vs 12
		//IL_08fb->IL08fb: Incompatible stack heights: 19 vs 14
		//IL_033e->IL0b0e: Incompatible stack heights: 18 vs 16
		//IL_0894->IL08d4: Incompatible stack heights: 23 vs 19
		//IL_0343->IL0343: Incompatible stack heights: 18 vs 16
		//IL_0899->IL0899: Incompatible stack heights: 23 vs 18
		//IL_0637->IL0c13: Incompatible stack heights: 21 vs 13
		//IL_063c->IL063c: Incompatible stack heights: 21 vs 13
		//IL_052c->IL0bd5: Incompatible stack heights: 19 vs 18
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
		Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
		float num = (float)_cameraOrthographicSize * 0.5f;
		float left = (float)ret - num;
		bool flag3 = (object)_mainCamera == null;
		Transform transform2 = _mainCamera.transform;
		bool flag4 = (object)transform2 == null;
		bool flag5 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
		bool flag6 = (object)_mainCamera == null;
		Transform transform3 = _mainCamera.transform;
		bool flag7 = (object)transform3 == null;
		bool flag8 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out ret);
		bool flag9 = (object)_mainCamera == null;
		Transform transform4 = _mainCamera.transform;
		bool flag10 = (object)transform4 == null;
		bool flag11 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out ret);
		ParticleSystem[] particleSystems = _ParticleSystems;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.LEM_Banana2_Hidden_Weapon)+19C]");
		float num2 = 0f * 0.5f;
		bool flag12 = _ParticleSystems == null;
		Transform transform5 = null;
		Transform transform6 = null;
		float value = default(float);
		float num3 = default(float);
		float top = default(float);
		float bottom = default(float);
		Weapon weapon = default(Weapon);
		float num10 = default(float);
		RapidDamageInstance rapidDamageInstance3 = default(RapidDamageInstance);
		EnemyController enemyController2 = default(EnemyController);
		while (true)
		{
			if ((nint)transform6 < particleSystems.Length)
			{
				bool flag13 = (nint)transform5 >= particleSystems.Length;
				bool flag14 = (object)particleSystems[(object)transform5] == null;
				Transform transform7 = particleSystems[(object)transform5].transform;
				Vector3 particleStartPos = ParticleStartPos;
				bool flag15 = (object)transform7 == null;
				bool flag16 = ((UnityEngine.Object)transform7).m_CachedPtr == (IntPtr)0;
				Transform.set_position_Injected(((UnityEngine.Object)transform7).m_CachedPtr, ref *(Vector3*)(&value));
				int particles = particleSystems[(object)transform5].GetParticles(_activeParticles, -1, 0);
				if (particles <= 0)
				{
					break;
				}
				ApplyParticleVelocity(_activeParticles, particles, left, num3, top, bottom);
				particleSystems[(object)transform5].SetParticles(_activeParticles, particles, 0);
				VampireSurvivors.App.Tools.Extensions.Shuffle(_activeParticles);
				nint num4 = (nint)this;
				float num5 = base.PAmount();
				num2 = particleStartPos.x * -10f;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1993 @ rdx_v60 (Il2CppClass<VampireSurvivors.Objects.Weapons.LEM_Banana2_Hidden_Weapon>)+410]");
				object obj3 = (nint)0 >> 1;
				object obj4 = obj3 >> 31;
				object obj5 = obj3 + obj4;
				bool flag17 = (nint)obj5 <= 0;
				int num6 = 0;
				weapon = (Weapon)particles;
				EnemyController enemyController = enemyController2;
				int num7 = 0;
				float num8 = num2;
				Transform transform8 = null;
				if (!flag17)
				{
					bool flag20;
					do
					{
						bool flag18 = _activeParticles == null;
						int num9 = transform8 % particles;
						object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 64));
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800048B0");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-3C]");
						enemyController2 = (EnemyController)0;
						bool flag19 = _invisProjectilesPool == null;
						Projectile projectile = _invisProjectilesPool.SpawnAt((float2)num10, this, (int)transform8);
						Transform transform9 = (Transform)(transform8 + 1);
						flag20 = System.Runtime.CompilerServices.Unsafe.As<Transform, UIntPtr>(ref transform9) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5);
						num6 = (int)transform8;
						num2 = num10;
						weapon = this;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-3C]");
						enemyController = (EnemyController)0;
						num7 = (int)transform8;
						num8 = num10;
						transform8 = transform9;
					}
					while (flag20);
				}
				transform5 = (Transform)(transform5 + 1);
				SignalBus signalBus = (SignalBus)num6;
				transform6 = transform5;
				continue;
			}
			List<RapidDamageInstance> rapidDamageInstances = _rapidDamageInstances;
			bool flag21 = _rapidDamageInstances == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ rax_v64 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.RapidDamageInstance>)+18]");
			bool flag22 = (nint)0 <= (nint)0;
			RapidDamageInstance rapidDamageInstance = (RapidDamageInstance)weapon;
			if (!flag22)
			{
				Transform transform10 = null;
				bool flag32;
				do
				{
					List<RapidDamageInstance> rapidDamageInstances2 = _rapidDamageInstances;
					bool flag23 = _rapidDamageInstances == null;
					Transform obj7 = transform10;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ r14_v16 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.RapidDamageInstance>)+18]");
					bool flag24 = (nint)obj7 >= 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ r14_v16 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.RapidDamageInstance>)+10]");
					object obj8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ r14_v16 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.RapidDamageInstance>)+10]");
					bool flag25 = (nint)0 == 0;
					Transform obj9 = transform10;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ rdx_v46+18]");
					bool flag26 = (nint)obj9 >= 0;
					object obj10 = transform10 * 4;
					object obj11 = (object)transform10 + obj10;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ rdx_v46+40+v1845 @ rcx_v60*8]");
					_ = 0;
					float deltaTime;
					if (PauseSystem._paused)
					{
						deltaTime = 0f;
					}
					else
					{
						object obj12 = Time.deltaTime;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ rdx_v46+40+v1845 @ rcx_v60*8]");
						deltaTime = 0f;
					}
					Transform playerOptions = (Transform)(object)_playerOptions;
					bool flag27 = _playerOptions == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ rdi_v28 (UnityEngine.Transform)+68]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ rdi_v28 (UnityEngine.Transform)+58]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ rdi_v28 (UnityEngine.Transform)+78]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ rdi_v28 (UnityEngine.Transform)+78]");
								object obj13 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2079 @ rax_v93+2CC]");
								if ((nint)0 != 0)
								{
									goto IL_0bd5;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ rdi_v28 (UnityEngine.Transform)+50]");
							bool flag28 = (nint)0 == 0;
						}
					}
					goto IL_0bd5;
					IL_0bd5:
					RapidDamageInstance rapidDamageInstance2 = rapidDamageInstance3.Update(deltaTime, _signalBus, (byte)(int)num3 != 0);
					Transform obj14 = transform10;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ r14_v16 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.RapidDamageInstance>)+18]");
					bool flag29 = (nint)obj14 >= 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ r14_v16 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.RapidDamageInstance>)+10]");
					object obj15 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ r14_v16 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.RapidDamageInstance>)+10]");
					bool flag30 = (nint)0 == 0;
					Transform obj16 = transform10;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v338 @ rcx_v66+18]");
					bool flag31 = (nint)obj16 >= 0;
					object obj17 = transform10 * 4;
					object obj18 = (object)transform10 + obj17;
					_ = rapidDamageInstance2.RemainingDamage;
					enemyController2 = rapidDamageInstance2.Target;
					_ = rapidDamageInstance2.Target;
					num2 = rapidDamageInstance2._timeUntilNextDamage;
					_ = rapidDamageInstance2._timeUntilNextDamage;
					rapidDamageInstance = rapidDamageInstance2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ r14_v16 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.RapidDamageInstance>)+1C]");
					_ = (nint)0 + (nint)1;
					transform10 = (Transform)(transform10 + 1);
					Transform obj19 = transform10;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ rax_v64 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.RapidDamageInstance>)+18]");
					flag32 = (nint)obj19 < 0;
					SignalBus signalBus = _signalBus;
					num3 = num3;
				}
				while (flag32);
			}
			Transform rapidDamageInstances3 = (Transform)(object)_rapidDamageInstances;
			bool flag33 = (nint)_rapidDamageInstances < 0;
			bool flag34 = _rapidDamageInstances == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v271 @ rdi_v22 (UnityEngine.Transform)+18]");
			Transform transform11 = (Transform)(-1);
			if (flag33)
			{
				break;
			}
			object obj31;
			do
			{
				List<RapidDamageInstance> rapidDamageInstances4 = _rapidDamageInstances;
				bool flag35 = _rapidDamageInstances == null;
				Transform obj20 = transform11;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rdx_v38 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.RapidDamageInstance>)+18]");
				bool flag36 = (nint)obj20 >= 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rdx_v38 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.RapidDamageInstance>)+10]");
				object obj21 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rdx_v38 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.RapidDamageInstance>)+10]");
				bool flag37 = (nint)0 == 0;
				Transform obj22 = transform11;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v286 @ rdx_v39+18]");
				bool flag38 = (nint)obj22 >= 0;
				object obj23 = transform11 * 4;
				object obj24 = (object)transform11 + obj23;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v286 @ rdx_v39+20+v341 @ rcx_v54*8]");
				bool flag44;
				if ((nint)0 < (nint)0)
				{
					List<RapidDamageInstance> rapidDamageInstances5 = _rapidDamageInstances;
					bool flag39 = _rapidDamageInstances == null;
					Transform obj25 = transform11;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ rdx_v43 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.RapidDamageInstance>)+18]");
					bool flag40 = (nint)obj25 >= 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ rdx_v43 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.RapidDamageInstance>)+10]");
					object obj26 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ rdx_v43 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.RapidDamageInstance>)+10]");
					bool flag41 = (nint)0 == 0;
					Transform obj27 = transform11;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v288 @ rdx_v44+18]");
					bool flag42 = (nint)obj27 >= 0;
					object obj28 = transform11 * 4;
					object obj29 = (object)transform11 + obj28;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v288 @ rdx_v44+30+v342 @ rcx_v58*8]");
					object obj30 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v288 @ rdx_v44+30+v342 @ rcx_v58*8]");
					bool flag43 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ rax_v72+260]");
					flag44 = (nint)0 < (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ rax_v72+260]");
					if ((nint)0 == 0)
					{
						goto IL_08d4;
					}
				}
				flag44 = (nint)_rapidDamageInstances < 0;
				bool flag45 = _rapidDamageInstances == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805F9370");
				goto IL_08d4;
				IL_08d4:
				transform11 = (Transform)(transform11 - 1);
				obj31 = !flag44;
			}
			while (obj31 != null);
			break;
		}
	}

	public override void Fire(bool skipTriggers = false)
	{
		DoCardTween();
	}

	public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		//IL_004f: Expected I, but got O
		//IL_009c: Expected O, but got I4
		if (index == 0)
		{
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.EX_Ammo2_Gunastrophe_SFX, soundConfig, 1000f, 1, time);
		}
		nint num = (nint)this;
		float num2 = base.PAmount();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm0\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.LEM_Banana2_Hidden_Weapon>)+410]");
		int amount = (int)((nint)0 + (nint)50);
		EmitParticles(amount);
		return null;
	}

	private unsafe void DoCardTween()
	{
		//IL_036c: Expected O, but got I4
		//IL_003f: Expected O, but got I4
		//IL_0069: Expected O, but got Ref
		//IL_00bf: Expected O, but got I8
		//IL_0278: Expected O, but got Ref
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Expected O, but got Unknown
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected O, but got Unknown
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Expected O, but got Unknown
		//IL_037f: Expected O, but got I4
		//IL_038f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0394: Expected O, but got Unknown
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.LEM_sfx_explosion_buildup1, soundConfig, 1000f, 1, time);
		PhaserSprite phaserSprite = _card.setScale(0f, (float?)(object)0);
		Transform transform = _card.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
		PhaserSprite phaserSprite2 = _card.setVisible(visible: true);
		Transform target = _card.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, 1.2f, 1.5000001f);
		object obj2 = 6603577472L;
		TweenCallback tweenCallback2;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ rax_v14 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 21;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag = (nint)0 == 0;
				_ = 0;
				if (!flag)
				{
					object obj3 = tweenerCore + 184;
					object obj4 = obj3 >> 12;
					object obj5 = obj4 & 0x1FFFFF;
					object obj6 = obj5 >> 6;
					object obj7 = obj5 & 0x3F;
					nint num2;
					do
					{
						object obj8 = 1 << (int)obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ r14_v2+462E0+v427 @ rdx_v25*8]");
						object obj9 = 0 | obj8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ r14_v2+462E0+v427 @ rdx_v25*8]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ r14_v2+462E0+v427 @ rdx_v25*8]");
						if (num == 0)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ r14_v2+462E0+v427 @ rdx_v25*8]");
						num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ r14_v2+462E0+v427 @ rdx_v25*8]");
					}
					while (num2 != 0);
					TweenCallback tweenCallback = ShatterCard;
					tweenCallback2 = tweenCallback;
					goto IL_01e5;
				}
			}
		}
		TweenCallback tweenCallback3 = ShatterCard;
		bool flag2 = tweenerCore == null;
		tweenCallback2 = tweenCallback3;
		if (!flag2)
		{
			goto IL_01e5;
		}
		goto IL_0214;
		IL_0214:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Transform target2 = _card.transform;
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = ShortcutExtensions.DORotate(target2, (Vector3)(&obj), 0.75000006f, RotateMode.LocalAxisAdd);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v651 @ rax_v20 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 27;
				_ = 0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		return;
		IL_01e5:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ rax_v14 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_0214;
	}

	private void PlayBuildUpSfx()
	{
		//IL_003d: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.LEM_sfx_explosion_buildup1, soundConfig, 1000f, 1, time);
	}

	private void PlayShatterSfx()
	{
		//IL_0095: Expected O, but got I4
		//IL_0041: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.LEM_sfx_glass1, soundConfig, 1000f, 1, time);
		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
		soundConfig2.Volume = (float?)(object)1;
		soundConfig2.Rate = 1f;
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.ExploGH2, soundConfig2, 1000f, 1, time);
	}

	private void PlayBananastropheSfx()
	{
		//IL_003d: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.EX_Ammo2_Gunastrophe_SFX, soundConfig, 1000f, 1, time);
	}

	private unsafe void ShatterCard()
	{
		//IL_0620: Expected O, but got I4
		//IL_006a: Expected O, but got I4
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Expected O, but got Unknown
		//IL_0877: Expected O, but got I4
		//IL_087f: Expected F4, but got O
		//IL_0888: Expected O, but got I4
		//IL_0503: Expected I, but got O
		//IL_0519: Expected O, but got I
		//IL_0522: Unknown result type (might be due to invalid IL or missing references)
		//IL_0527: Expected O, but got Unknown
		//IL_059d: Expected I, but got O
		//IL_09da: Expected O, but got I4
		//IL_09f1: Expected I, but got I8
		//IL_0579: Expected I, but got I8
		//IL_02b0: Expected I, but got O
		//IL_037b: Expected I, but got O
		//IL_03ee: Expected O, but got I4
		//IL_0915: Expected O, but got F4
		//IL_0943: Expected O, but got I4
		//IL_0a56: Expected O, but got F4
		//IL_0a94: Expected O, but got I4
		//IL_0951: Expected O, but got F4
		//IL_09ab: Expected O, but got I4
		//IL_0444: Expected I, but got O
		//IL_04a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a8: Expected O, but got Unknown
		//IL_0141->IL0625: Incompatible stack heights: 1 vs 0
		//IL_027c->IL05c1: Incompatible stack heights: 9 vs 0
		//IL_0a48->IL05c1: Incompatible stack heights: 8 vs 0
		//IL_02d4->IL02d4: Incompatible stack heights: 10 vs 9
		//IL_0361->IL05c1: Incompatible stack heights: 11 vs 0
		//IL_0399->IL0399: Incompatible stack heights: 13 vs 12
		//IL_0907->IL05c1: Incompatible stack heights: 13 vs 0
		//IL_041a->IL05c1: Incompatible stack heights: 13 vs 0
		//IL_0467->IL0467: Incompatible stack heights: 14 vs 13
		//IL_04b5->IL09b0: Incompatible stack heights: 14 vs 8
		_003C_003Ec__DisplayClass29_0 obj = new _003C_003Ec__DisplayClass29_0();
		InitShatterVfx();
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			Vector2 vector = default(Vector2);
			Projectile projectile = FireOneProjectile(vector, 0);
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			soundConfig.Volume = (float?)(object)1;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.LEM_sfx_glass1, soundConfig, 1000f, 1, time);
			SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
			soundConfig2.Volume = (float?)(object)1;
			soundConfig2.Rate = 1f;
			PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.ExploGH2, soundConfig2, 1000f, 1, time);
			MultiTargetTween[] shatterTweens = _shatterTweens;
			bool flag = _shatterTweens == null;
			object obj2 = null;
			object obj3 = null;
			if (!flag)
			{
				while ((nint)obj3 < shatterTweens.Length)
				{
					bool flag2 = (nint)obj2 >= shatterTweens.Length;
					if (shatterTweens[obj2] != null)
					{
						shatterTweens[obj2].Kill();
					}
					obj2++;
					obj3 = obj2;
				}
				SpriteRenderer[] array = _shatterVfx.Shatter();
				MultiTargetTween[] shatterTweens2 = new MultiTargetTween[array.Length];
				_shatterTweens = shatterTweens2;
				if (array.Length <= 0)
				{
					throw new IndexOutOfRangeException();
				}
				SpriteRenderer spriteRenderer = array[0];
				bool flag3 = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
				IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr);
				Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
				bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				IntPtr parent_Injected = Transform.GetParent_Injected(((UnityEngine.Object)transform).m_CachedPtr);
				Transform parent = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(parent_Injected);
				obj.parent = parent;
				object parent2 = obj.parent;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v829 @ rbx_v34 (System.Object)+10]");
				bool flag5 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v829 @ rbx_v34 (System.Object)+10]");
				IntPtr gcHandlePtr2 = Component.get_transform_Injected((IntPtr)0);
				Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v888 @ rax_v104 (UnityEngine.Transform)+10]");
				bool flag6 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v888 @ rax_v104 (UnityEngine.Transform)+10]");
				float value = default(float);
				Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)(&value));
				object parent3 = obj.parent;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v833 @ rbx_v36 (System.Object)+10]");
				bool flag7 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v833 @ rbx_v36 (System.Object)+10]");
				IntPtr gcHandlePtr3 = Component.get_gameObject_Injected((IntPtr)0);
				GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v889 @ rax_v113 (UnityEngine.GameObject)+10]");
				bool flag8 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v889 @ rax_v113 (UnityEngine.GameObject)+10]");
				GameObject.SetActive_Injected((IntPtr)0, true);
				object shatterVfx = _shatterVfx;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v834 @ rbx_v38 (System.Object)+10]");
				bool flag9 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v834 @ rbx_v38 (System.Object)+10]");
				IntPtr gcHandlePtr4 = Component.get_gameObject_Injected((IntPtr)0);
				GameObject gameObject2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr4);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v122 (UnityEngine.GameObject)+10]");
				bool flag10 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v890 @ rax_v122 (UnityEngine.GameObject)+10]");
				GameObject.SetActive_Injected((IntPtr)0, true);
				object obj4 = 0;
				float num = (float)vector;
				object obj5 = 0;
				object obj6 = default(object);
				object obj11 = default(object);
				while (true)
				{
					if ((nint)obj5 < array.Length)
					{
						MultiTargetTween[] shatterTweens3 = _shatterTweens;
						TweenConfig tweenConfig = new TweenConfig();
						object[] array2 = new object[2];
						bool flag11 = (nint)obj4 >= array.Length;
						if (array2 == null)
						{
							break;
						}
						if ((object)array[obj4] != null)
						{
							nint num2 = (nint)array2;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							bool flag12 = obj6 == null;
						}
						bool flag13 = array2.Length <= 0;
						array2[0] = array[obj4];
						bool flag14 = (nint)obj4 >= array.Length;
						object obj7 = array[obj4];
						if ((object)array[obj4] == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rbx_v44 (System.Object)+10]");
						bool flag15 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rbx_v44 (System.Object)+10]");
						IntPtr gcHandlePtr5 = Component.get_transform_Injected((IntPtr)0);
						Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr5);
						if ((object)transform3 != null)
						{
							Transform transform4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>((IntPtr)transform3);
							bool flag16 = (object)transform4 == null;
						}
						bool flag17 = array2.Length <= 1;
						array2[1] = transform3;
						if (tweenConfig == null)
						{
							break;
						}
						tweenConfig.targets = array2;
						tweenConfig.alpha = (float?)(object)1;
						object obj8 = UnityEngine.Random.value;
						float num3 = num * 360f;
						float num4 = num3 - 90f;
						tweenConfig.angle = (float?)(object)1;
						object obj9 = UnityEngine.Random.value;
						float num5 = num4 - 0.5f;
						float num6 = num5 * 1.5f;
						float num7 = num6 * 16f;
						tweenConfig.localX = (float?)(object)1;
						object obj10 = UnityEngine.Random.value;
						float num8 = num7 - 0.5f;
						tweenConfig.ease = Ease.InOutSine;
						tweenConfig.duration = 2000f;
						float num9 = num8 * 1.2f;
						num = num9 * 16f;
						tweenConfig.localY = (float?)(object)1;
						MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
						if (_shatterTweens == null)
						{
							break;
						}
						if (multiTargetTween != null)
						{
							nint num10 = (nint)shatterTweens3;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							bool flag18 = obj11 == null;
						}
						bool flag19 = (nint)obj4 >= shatterTweens3.Length;
						shatterTweens3[obj4] = multiTargetTween;
						obj4++;
						obj5 = obj4;
						continue;
					}
					TweenCallback tweenCallback = null;
					nint num11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ r10_v30 (Il2CppMethodInfo)+8]");
					((Delegate)tweenCallback).method_ptr = (IntPtr)0;
					((Delegate)tweenCallback).m_target = obj;
					((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec__DisplayClass29_0._003CShatterCard_003Eb__0);
					((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ r10_v30 (Il2CppMethodInfo)+4C]");
					object obj12 = (nint)0 >> 4;
					object obj13 = obj12 & 1;
					nint num12;
					if (obj13 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ r10_v30 (Il2CppMethodInfo)+52]");
						if ((nint)0 == 0)
						{
							num12 = unchecked((nint)6447293664L);
							goto IL_09d1;
						}
					}
					num12 = ((Delegate)tweenCallback).method_ptr;
					((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
					goto IL_09d1;
					IL_09d1:
					object obj14 = 24;
					((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
					Tween tween = DOVirtual.DelayedCall(2f, tweenCallback, ignoreTimeScale: false);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					if (tween == null)
					{
						break;
					}
					tween.stringId = "DefaultGameTweenId";
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void InitShatterVfx()
	{
		//IL_0096: Expected O, but got I4
		ShatterVFX shatterVfx = _shatterVfx;
		if ((object)_shatterVfx == null || ((UnityEngine.Object)shatterVfx).m_CachedPtr == (IntPtr)0)
		{
			ShatterVFX.ShatterDetails shatterDetails = new ShatterVFX.ShatterDetails();
			shatterDetails.horizontalCuts = 8;
			shatterDetails.verticalCuts = 8;
			shatterDetails.shatterType = ShatterVFX.ShatterType.Radial;
			shatterDetails.radialSectors = 16;
			shatterDetails.radials = 4;
			shatterDetails.radialCentre = (Vector2)1056964608;
			_ = 1056964608;
			shatterDetails.randomizeAtRunTime = true;
			shatterDetails.randomness = 1f;
			PhaserSprite card = _card;
			GameObject gameObject = card._spriteRenderer.gameObject;
			ShatterVFX shatterVfx2 = gameObject.AddComponent<ShatterVFX>();
			_shatterVfx = shatterVfx2;
			ShatterVFX shatterVfx3 = _shatterVfx;
			shatterVfx3.shatterDetails = shatterDetails;
			GameObject gameObject2 = _shatterVfx.gameObject;
			gameObject2.SetActive(value: false);
		}
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
		ParticleSystem[] particleSystems = _ParticleSystems;
		object obj = UnityEngine.Random.RandomRangeInt(0, particleSystems.Length);
		bool flag = (nint)obj >= particleSystems.Length;
		int particles = particleSystems[obj].GetParticles(_activeParticles, -1, 0);
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
		//IL_0057: Expected O, but got I4
		//IL_0060: Expected O, but got I4
		//IL_00a1: Expected I4, but got I8
		//IL_011e: Expected O, but got I4
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Expected O, but got Unknown
		//IL_02c5: Expected I4, but got I8
		//IL_0322: Unknown result type (might be due to invalid IL or missing references)
		//IL_0327: Expected O, but got Unknown
		//IL_0334: Expected O, but got Ref
		//IL_034e: Expected O, but got I4
		//IL_035e: Expected O, but got Ref
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Expected O, but got Unknown
		//IL_0246: Expected O, but got I4
		//IL_024f: Expected O, but got I4
		//IL_01b6: Expected O, but got F4
		//IL_01c9: Expected O, but got I4
		//IL_025c->IL036c: Incompatible stack heights: 1 vs 0
		object obj2 = default(object);
		object obj = obj2 - 312;
		ParticleSystem[] particleSystems = _ParticleSystems;
		_ = 0;
		int count = amount;
		object obj3 = 0;
		object obj4 = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = default(ParticleSystem.MinMaxCurve);
		while ((nint)obj4 < particleSystems.Length)
		{
			ParticleSystem particleSystem = particleSystems[obj3];
			int particles = particleSystems[obj3].GetParticles(_activeParticles, -1, 0);
			_ = 0;
			_ = 0;
			Vector3 particleStartPos = ParticleStartPos;
			_ = 1;
			_ = 0;
			_ = particleStartPos.z;
			_ = 0;
			_ = particleStartPos.x;
			_ = particleStartPos.x;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rbp_v1+A0]");
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			obj = 0;
			bool flag = ((UnityEngine.Object)particleSystem).m_CachedPtr == (IntPtr)0;
			object obj5 = obj - 112;
			ParticleSystem.Emit_Injected(((UnityEngine.Object)particleSystem).m_CachedPtr, ref *(ParticleSystem.EmitParams*)obj5, count);
			int particles2 = particleSystems[obj3].GetParticles(_activeParticles, -1, 0);
			_ = particleSystems[obj3];
			_ = particleSystems[obj3];
			float num = base.PDuration();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rbp_v1+A0]");
			float constant = 0f / 1000f;
			ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(constant);
			ParticleSystem.MainModule mainModule = (ParticleSystem.MainModule)(obj + 344);
			((ParticleSystem.MainModule*)mainModule)->startLifetime = (ParticleSystem.MinMaxCurve)(&minMaxCurve2);
			bool flag2 = particles >= particles2;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)0;
			int num2 = particles;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)(&minMaxCurve2);
			if (!flag2)
			{
				do
				{
					float value = UnityEngine.Random.value;
					ParticleSystem.Particle[] activeParticles = _activeParticles;
					float num3 = value * (float)Math.PI;
					float num4 = num3 + num3;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
					float num5 = num4 * _ParticleLaunchVelocity;
					float num6 = num5 + num5;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
					float num7 = num4 * _ParticleLaunchVelocity;
					minMaxCurve3 = (ParticleSystem.MinMaxCurve)(num7 + num7);
					minMaxCurve4 = (ParticleSystem.MinMaxCurve)(num2 * 132);
					num2++;
					_ = 0;
				}
				while (num2 < particles2);
			}
			particleSystems[obj3].SetParticles(_activeParticles, particles2, 0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ rbp_v1+148]");
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
			LEM_Banana2_Hidden_Weapon lEM_Banana2_Hidden_Weapon = (LEM_Banana2_Hidden_Weapon)(obj3 * 132);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rcx_v12 (VampireSurvivors.Objects.Weapons.LEM_Banana2_Hidden_Weapon)+34+particles @ rdx (Particle[])]");
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
			lEM_Banana2_Hidden_Weapon = (LEM_Banana2_Hidden_Weapon)(obj3 * 132);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rcx_v12 (VampireSurvivors.Objects.Weapons.LEM_Banana2_Hidden_Weapon)+34+particles @ rdx (Particle[])]");
			_ = 0;
			_ = 0;
			goto IL_0215;
		}
		while ((nint)obj3 < particleCount);
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public override void Cleanup()
	{
		ShatterVFX shatterVfx = _shatterVfx;
		if ((object)_shatterVfx != null && ((UnityEngine.Object)shatterVfx).m_CachedPtr != (IntPtr)0)
		{
			_shatterVfx.Destroy();
		}
		base.Cleanup();
	}

	public LEM_Banana2_Hidden_Weapon()
	{
		List<RapidDamageInstance> rapidDamageInstances = new List<RapidDamageInstance>();
		_rapidDamageInstances = rapidDamageInstances;
		_shatterTweens = new MultiTargetTween[0];
		base._002Ector();
	}

	internal unsafe static void _003CApplyParticleVelocity_003Eg__BounceParticle_007C33_0(ref ParticleSystem.Particle particle, float bouncePositionX, float bouncePositionY, float xBounce = 1f, float yBounce = 1f)
	{
		object obj = default(object);
		ref ParticleSystem.Particle reference = ref *(ParticleSystem.Particle*)obj;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [particle @ rcx (Particle&)+14]");
		_ = 0;
	}
}
