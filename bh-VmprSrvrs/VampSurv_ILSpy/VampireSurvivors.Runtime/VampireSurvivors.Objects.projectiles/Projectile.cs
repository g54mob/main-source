using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using Unity.Profiling;
using Unity.Profiling.LowLevel;
using Unity.Profiling.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class Projectile : ArcadeSprite, IDamageable
{
	private bool _BounceOffWalls;

	protected Transform _cachedTransform;

	protected Weapon _weapon;

	protected int _indexInWeapon;

	protected Transform _targetTransform;

	protected SpriteRenderer _renderer;

	protected GameSessionData _gameSessionData;

	protected Camera _mainCamera;

	protected SpriteTrail _spriteTrail;

	private float _pauseWallChecksTimer;

	[NonSerialized]
	public float _speed = 1f;

	protected int _penetrating;

	protected int _bounces;

	protected bool _isCullable = true;

	protected bool _bounceActivated;

	protected ArcadeSprite _sprite;

	protected BulletPool _pool;

	protected readonly HashSet<IDamageable> _objectsHit;

	private static readonly ProfilerMarker _markerInitProjectile;

	public HashSet<IDamageable> ObjectsHit => _objectsHit;

	public virtual float ProjectileSpeed
	{
		get
		{
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			float num = _weapon.PSpeed();
			object obj2 = default(object);
			object obj = obj2 * GameManager.ProjectileSpeed;
			return (float)obj * _speed;
		}
	}

	public int IndexInWeapon => _indexInWeapon;

	public Weapon Weapon => _weapon;

	protected Vector2 Velocity
	{
		get
		{
			Vector2 result = default(Vector2);
			if (body != null)
			{
				return result;
			}
			return (Vector2)new NullReferenceException();
		}
		private set
		{
			BaseBody baseBody = body;
			baseBody._velocity = value;
		}
	}

	protected virtual void Awake()
	{
		Transform component = GetComponent<Transform>();
		_cachedTransform = component;
		SpriteRenderer componentInChildren = GetComponentInChildren<SpriteRenderer>();
		_renderer = componentInChildren;
		SpriteTrail componentInChildren2 = GetComponentInChildren<SpriteTrail>();
		_spriteTrail = componentInChildren2;
		Camera main = Camera.main;
		_mainCamera = main;
		_bounceActivated = false;
		_sprite = this;
	}

	protected override void OnUpdate()
	{
		//IL_0011: Invalid comparison between F4 and I4
		CheckIfVisibleOnScreen();
		if (_pauseWallChecksTimer > 0f)
		{
			float deltaTime = PauseSystem.DeltaTime;
			float pauseWallChecksTimer = _pauseWallChecksTimer - deltaTime;
			_pauseWallChecksTimer = pauseWallChecksTimer;
		}
	}

	public virtual void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_00a1: Expected O, but got I8
		//IL_00e7: Expected O, but got I4
		GameManager core = GM.Core;
		_gameSessionData = core._gameSessionData;
		BulletPool pool2 = default(BulletPool);
		_pool = pool2;
		Weapon weapon2 = default(Weapon);
		_weapon = weapon2;
		_indexInWeapon = index;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		Weapon weapon3 = _weapon;
		WeaponData currentWeaponData = weapon3._currentWeaponData;
		_penetrating = currentWeaponData._003Cpenetrating_003Ek__BackingField;
		int bounces = _weapon.PBounces();
		_bounces = bounces;
		bool flag = body != null;
		object obj = 6603577472L;
		if (!flag)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			Factory add = s_scene.add;
			PhaserGameObject phaserGameObject = add._world.enableBody(this);
			obj = 0;
		}
		BaseBody baseBody = body;
		baseBody._enable = true;
		PhysicsManager sInstance = PhysicsManager._sInstance;
		Group obj2 = sInstance._bulletGroup.add(_sprite);
		SpriteTrail spriteTrail = _spriteTrail;
		if ((object)_spriteTrail != null && ((UnityEngine.Object)spriteTrail).m_CachedPtr != (IntPtr)0)
		{
			_spriteTrail.Reset();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1730");
		object obj3 = default(object);
		if (obj3 == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6A10");
		}
		GameManager core2 = GM.Core;
		ParticleSystem[] componentsInChildren = GetComponentsInChildren<ParticleSystem>();
		core2._particleManager.RegisterParticleSystem(componentsInChildren);
	}

	public virtual void SetNullTarget()
	{
		_targetTransform = null;
	}

	public virtual void SetTarget(Transform target)
	{
		_targetTransform = target;
	}

	public void SetVelocity(Vector2 velocity)
	{
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = velocity;
	}

	public virtual void InternalUpdate()
	{
	}

	public bool HasAlreadyHitPickUpObject(IDamageable damageable)
	{
		//IL_0074: Expected I4, but got O
		if (_objectsHit != null)
		{
			bool flag = ((HashSet<object>)(object)_objectsHit).Contains((object)damageable);
			if (!flag)
			{
				if (_objectsHit == null)
				{
					goto IL_0066;
				}
				bool flag2 = ((HashSet<object>)(object)_objectsHit).AddIfNotPresent((object)damageable);
				flag = false;
			}
			return flag;
		}
		goto IL_0066;
		IL_0066:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool HasAlreadyHitObject(IDamageable damageable)
	{
		//IL_007e: Expected I4, but got O
		if (_objectsHit != null)
		{
			bool flag = ((HashSet<object>)(object)_objectsHit).Contains((object)damageable);
			if (!flag)
			{
				if (_objectsHit == null)
				{
					goto IL_0070;
				}
				bool flag2 = ((HashSet<object>)(object)_objectsHit).AddIfNotPresent((object)damageable);
				OnHasHitAnObject(damageable);
				flag = false;
			}
			return flag;
		}
		goto IL_0070;
		IL_0070:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool HasAlreadyHitPlayerObject(IDamageable damageable)
	{
		//IL_007e: Expected I4, but got O
		if (_objectsHit != null)
		{
			bool flag = ((HashSet<object>)(object)_objectsHit).Contains((object)damageable);
			if (!flag)
			{
				if (_objectsHit == null)
				{
					goto IL_0070;
				}
				bool flag2 = ((HashSet<object>)(object)_objectsHit).AddIfNotPresent((object)damageable);
				OnHasHitAnotherPlayerObject(damageable);
				flag = false;
			}
			return flag;
		}
		goto IL_0070;
		IL_0070:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public void AddObjectHit(IDamageable obj)
	{
		bool flag = ((HashSet<object>)(object)_objectsHit).AddIfNotPresent((object)obj);
	}

	public unsafe float AngleFromTargetRadians(Transform target, Transform playerTransform)
	{
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected Ref, but got Unknown
		//IL_01c7->IL0134: Incompatible stack heights: 1 vs 0
		Transform transform2;
		if ((object)target != null)
		{
			bool flag = ((UnityEngine.Object)target).m_CachedPtr != (IntPtr)0;
			Transform transform = playerTransform;
			transform2 = target;
			if (flag)
			{
				goto IL_0162;
			}
		}
		Weapon weapon = _weapon;
		if ((object)_weapon != null)
		{
			GameManager gameMan = weapon._gameMan;
			if ((object)weapon._gameMan != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null && (object)gameMan._stage != null)
			{
				ref Unity.Mathematics.Random rng = ref *(Unity.Mathematics.Random*)(((Equipment)weapon)._003COwner_003Ek__BackingField + 176);
				Transform transform3 = gameMan._stage.PickRandomEnemy(ref rng);
				Transform transform = null;
				transform2 = transform3;
				goto IL_0162;
			}
		}
		goto IL_0134;
		IL_0134:
		throw new NullReferenceException();
		IL_0162:
		if ((object)playerTransform != null)
		{
			bool flag2 = ((UnityEngine.Object)playerTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)playerTransform).m_CachedPtr, out Vector3 ret);
			if ((object)transform2 != null)
			{
				bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 ret2);
				object obj = default(object);
				object obj2 = default(object);
				float result = (float)obj - (float)obj2;
				object obj3 = ret2 - ret;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
				return result;
			}
		}
		goto IL_0134;
	}

	public void ApplyPlayerFacingVelocity(Vector3 playerDirection, bool rotate = true)
	{
		//IL_01b8: Invalid comparison between F4 and I4
		//IL_011a: Expected F4, but got O
		//IL_0086: Invalid comparison between F4 and I4
		//IL_00ca: Expected O, but got F4
		//IL_01dd: Expected F4, but got O
		//IL_01a5->IL016a: Incompatible stack heights: 1 vs 0
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C6C6E0");
		float num2 = default(float);
		float num4;
		float num5;
		if (playerDirection.x > 1E-05f)
		{
			float num = num2 / playerDirection.x;
			float num3 = playerDirection.x / playerDirection.x;
			num4 = num;
			num5 = num3;
		}
		else
		{
			num5 = (float)Vector3.zeroVector;
			num4 = num2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001872C5DFAh\"");
		if (num5 == 0f)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001872C5DFAh\"");
			if (num4 == 0f)
			{
				num5 = 1f;
			}
		}
		float projectileSpeed = ProjectileSpeed;
		float num6 = 0f * num5;
		float projectileSpeed2 = ProjectileSpeed;
		ArcadeSprite sprite = _sprite;
		float num7 = 0f * num4;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = (float2)num6;
		if (rotate)
		{
			Transform transform = base.transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
			Vector3 axis = default(Vector3);
			Quaternion.AngleAxis_Injected((float)this, ref axis, out Quaternion _);
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Quaternion value = default(Quaternion);
			Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		}
	}

	public void ApplyInversePlayerFacingVelocity(Vector3 playerDirection, bool rotate = true)
	{
		//IL_01f8: Invalid comparison between F4 and I4
		//IL_0167: Expected O, but got F4
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_0197: Expected O, but got F4
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Expected O, but got Unknown
		//IL_0142: Expected F4, but got O
		//IL_00ae: Invalid comparison between F4 and I4
		//IL_021d: Expected F4, but got O
		//IL_01e5->IL01aa: Incompatible stack heights: 1 vs 0
		_ = playerDirection.x;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C6C6E0");
		float num2 = default(float);
		float num4;
		float num5;
		if (playerDirection.x > 1E-05f)
		{
			float num = num2 / playerDirection.x;
			float num3 = playerDirection.x / playerDirection.x;
			num4 = num;
			num5 = num3;
		}
		else
		{
			num5 = (float)Vector3.zeroVector;
			num4 = num2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001872C60C0h\"");
		if (num5 == 0f)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001872C60C0h\"");
			if (num4 == 0f)
			{
				num5 = 1f;
			}
		}
		float projectileSpeed = ProjectileSpeed;
		object obj = num5 ^ -0f;
		float2 velocity = (float2)(obj * 0);
		float projectileSpeed2 = ProjectileSpeed;
		ArcadeSprite sprite = _sprite;
		object obj2 = num4 ^ -0f;
		object obj3 = 0 * obj2;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = velocity;
		if (rotate)
		{
			Transform transform = base.transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
			Vector3 axis = default(Vector3);
			Quaternion.AngleAxis_Injected((float)this, ref axis, out Quaternion _);
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Quaternion value = default(Quaternion);
			Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		}
	}

	public virtual void OnHasHitWallPhaser(PhaserTile tile)
	{
		Despawn();
	}

	public virtual bool CanExplode()
	{
		return false;
	}

	public virtual void Explode(Vector2? position = null)
	{
	}

	private void CheckIfVisibleOnScreen()
	{
		//IL_02ef: Invalid comparison between O and F4
		//IL_01a4: Invalid comparison between F4 and O
		//IL_01c3: Invalid comparison between O and F4
		//IL_01ee: Invalid comparison between F4 and O
		//IL_020c: Invalid comparison between F4 and I4
		//IL_0235: Expected O, but got I4
		//IL_02b2->IL0260: Incompatible stack heights: 1 vs 0
		//IL_00bb->IL0260: Incompatible stack heights: 1 vs 0
		//IL_00e9->IL0260: Incompatible stack heights: 1 vs 0
		//IL_017e->IL0260: Incompatible stack heights: 1 vs 0
		//IL_0260->IL0267: Incompatible stack heights: 2 vs 0
		//IL_0250->IL0267: Incompatible stack heights: 2 vs 0
		if (!_isCullable)
		{
			return;
		}
		if ((object)_mainCamera != null)
		{
			Transform transform = _mainCamera.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				if ((object)_mainCamera != null)
				{
					float orthographicSize = _mainCamera.orthographicSize;
					if ((object)_mainCamera != null)
					{
						float aspect = _mainCamera.aspect;
						if ((object)_mainCamera != null)
						{
							float num = aspect * orthographicSize;
							object obj = default(object);
							float num2 = (float)obj - orthographicSize;
							float num3 = aspect * orthographicSize;
							float num4 = (float)ret - num;
							float num5 = num3 + num3;
							float orthographicSize2 = _mainCamera.orthographicSize;
							float num6 = orthographicSize2 + orthographicSize2;
							Transform transform2 = base.transform;
							if ((object)transform2 != null)
							{
								bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
								Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
								if (System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref ret) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num4))
								{
									float num7 = num4 + num5;
									if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num7) > System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref ret) && System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2))
									{
										float num8 = num2 + num6;
										bool flag3 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num8) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
										float num9 = num8 - (float)obj;
										bool flag4 = num9 == 0f;
										bool flag5 = !flag3;
										bool flag6 = !flag4;
										object obj2 = flag6 & flag5;
										if (obj2 != null)
										{
											return;
										}
									}
								}
								Despawn();
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public virtual void Despawn()
	{
		PhysicsManager sInstance = PhysicsManager._sInstance;
		if (PhysicsManager._sInstance != null)
		{
			sInstance._bulletGroup.remove(_sprite);
		}
		BaseBody baseBody = body;
		baseBody._enable = false;
		Weapon weapon = _weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1730");
		object obj = default(object);
		if (obj != null)
		{
			bool flag = ((List<object>)(object)weapon._spawnedProjectiles).Remove((object)this);
		}
		BulletPool pool = _pool;
		if (((UnityEngine.Object)this).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject = base.gameObject;
			if ((object)gameObject != null && ((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0 && (object)pool._pool != null)
			{
				GameObject obj2 = base.gameObject;
				pool._pool.Release(obj2);
			}
		}
	}

	protected void SetScaleToArea(float multiplier = 1f)
	{
		float num = _weapon.PArea();
		Projectile cachedTransform = (Projectile)(object)_cachedTransform;
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
	}

	protected Vector2 SetVelocityFromRotation(float rotation, float speed)
	{
		//IL_009c: Expected O, but got F4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		float num = rotation * speed;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		ArcadeSprite sprite = _sprite;
		float num2 = rotation * speed;
		if ((object)_sprite != null)
		{
			BaseBody baseBody = sprite.body;
			if (sprite.body != null)
			{
				baseBody._velocity = (float2)num;
				Vector2 result = default(Vector2);
				return result;
			}
		}
		return (Vector2)new NullReferenceException();
	}

	public bool TryFreeze(IDamageable target)
	{
		//IL_009a: Invalid comparison between F4 and O
		//IL_00b8: Invalid comparison between F4 and I4
		//IL_0434->IL035c: Incompatible stack heights: 1 vs 0
		//IL_0341->IL0341: Incompatible stack heights: 1 vs 0
		Weapon weapon = _weapon;
		bool flag5;
		bool result;
		if ((object)_weapon != null)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
			if ((object)((Equipment)weapon)._003COwner_003Ek__BackingField == null || ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0)
			{
				goto IL_034e;
			}
			float chanceFromArray = _weapon.GetChanceFromArray();
			if ((object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
			{
				float num = ((Equipment)weapon)._003COwner_003Ek__BackingField.PLuck();
				object obj = default(object);
				float num2 = (float)obj * weapon._003CFreezeChance_003Ek__BackingField;
				bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
				float num3 = num2 - (float)obj;
				bool flag2 = num3 == 0f;
				bool flag3 = !flag;
				bool flag4 = !flag2;
				flag5 = flag4 & flag3;
				if (!flag5)
				{
					goto IL_034e;
				}
				if (target != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					GameObject gameObject = default(GameObject);
					if ((object)gameObject != null)
					{
						EnemyController component = gameObject.GetComponent<EnemyController>();
						if ((object)component == null || ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0)
						{
							goto IL_021b;
						}
						if ((object)_weapon != null)
						{
							float num4 = _weapon.PDuration();
							Weapon weapon2 = _weapon;
							if ((object)_weapon != null)
							{
								bool flag6 = component.Freeze(num2, weapon2._003CFreezeChance_003Ek__BackingField);
								bool flag7 = !flag6;
								flag5 = flag6;
								result = flag6;
								if (!flag7)
								{
									goto IL_021b;
								}
								goto IL_0341;
							}
						}
					}
				}
			}
		}
		goto IL_035c;
		IL_034e:
		return false;
		IL_0341:
		return result;
		IL_021b:
		if ((object)_weapon != null)
		{
			bool flag8 = _weapon.HasActiveArcanaOfType(ArcanaType.T12_OUT_OF_TIME);
			bool flag9 = !flag8;
			result = flag5;
			if (flag9)
			{
				goto IL_0341;
			}
			Weapon weapon3 = _weapon;
			if ((object)_weapon != null)
			{
				GameManager gameMan = weapon3._gameMan;
				if ((object)weapon3._gameMan != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					GameObject gameObject2 = default(GameObject);
					if ((object)gameObject2 != null)
					{
						Transform transform = gameObject2.transform;
						if ((object)transform != null)
						{
							bool flag10 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
							if (gameMan._arcanaManager != null)
							{
								Vector2 pos = default(Vector2);
								gameMan._arcanaManager.TriggerColdExplosion(pos);
								result = flag5;
								goto IL_0341;
							}
						}
					}
				}
			}
		}
		goto IL_035c;
		IL_035c:
		throw new NullReferenceException();
	}

	public bool TryDefang(IDamageable target)
	{
		//IL_01cc: Expected I4, but got O
		Weapon weapon = _weapon;
		if ((object)_weapon != null)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
			if ((object)((Equipment)weapon)._003COwner_003Ek__BackingField == null || ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0)
			{
				goto IL_01b0;
			}
			float chanceFromArray = _weapon.GetChanceFromArray();
			float defangChance = _weapon.DefangChance;
			if ((object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
			{
				float num = ((Equipment)weapon)._003COwner_003Ek__BackingField.PLuck();
				object obj2 = default(object);
				object obj = obj2 * obj2;
				bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2);
				object obj3 = obj - obj2;
				bool flag2 = obj3 == null;
				bool flag3 = !flag;
				bool flag4 = !flag2;
				bool flag5 = flag4 & flag3;
				if (!flag5)
				{
					goto IL_01b0;
				}
				if (target != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					GameObject gameObject = default(GameObject);
					if ((object)gameObject != null)
					{
						EnemyController component = gameObject.GetComponent<EnemyController>();
						if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
						{
							bool flag6 = component.DoDefang();
							flag5 = flag6;
						}
						return flag5;
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_01b0:
		return false;
	}

	protected virtual void OnHasHitAnObject(IDamageable other)
	{
	}

	protected virtual void OnHasHitAnotherPlayerObject(IDamageable other)
	{
	}

	public float AngleFromVelocity(Vector2 velocity)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		object obj = default(object);
		return (float)obj * 57.29578f;
	}

	protected float AngleFromVelocityRadians(Vector2 velocity)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		float result = default(float);
		return result;
	}

	protected unsafe Transform SetForNearestEnemy(ref Vector2 v)
	{
		//IL_003a: Expected O, but got Ref
		//IL_014d: Invalid comparison between O and F4
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Expected O, but got Unknown
		//IL_0373: Invalid comparison between F4 and I4
		//IL_02eb: Expected Ref, but got F4
		//IL_029b: Expected I, but got O
		//IL_02bb: Expected O, but got I
		//IL_02c4: Expected F4, but got O
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected O, but got Unknown
		//IL_00dc: Invalid comparison between O and F4
		//IL_025f: Expected I, but got O
		//IL_0288: Expected O, but got I
		GameManager core = GM.Core;
		object cachedTransform = _cachedTransform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rdi_v3 (System.Object)+10]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rdi_v3 (System.Object)+10]");
			Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
			object obj = default(object);
			EnemyController enemyController = core._stage.FindClosestEnemy((Vector3)(&obj));
			Weapon weapon;
			ref Vector2 reference;
			if ((object)enemyController != null)
			{
				bool flag = ((UnityEngine.Object)enemyController).m_CachedPtr == (IntPtr)0;
				weapon = _weapon;
				if (!flag)
				{
					float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
					BaseBody baseBody = enemyController.body;
					object obj3 = default(object);
					object obj2 = (object)baseBody._position - obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rax_v37 (BaseBody)+54]");
					object obj5 = default(object);
					object obj4 = 0 - obj5;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A85B0");
					Vector2 vector;
					object obj6;
					if (System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref ret) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1E-05f))
					{
						vector = (Vector2)(obj2 / (object)ret);
						obj6 = obj4 / (object)ret;
					}
					else
					{
						nint num = (nint)typeof(Vector2);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v624 @ rax_v46 (Il2CppClass<UnityEngine.Vector2>)+B8]");
						nint num2 = 0;
						vector = Vector2.zeroVector;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v625 @ rcx_v34 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
						obj6 = 0;
					}
					float projectileSpeed = ProjectileSpeed;
					object obj7 = ret * vector;
					reference = ref *(Vector2*)obj7;
					float projectileSpeed2 = ProjectileSpeed;
					object obj8 = obj7 * obj6;
					return enemyController.transform;
				}
			}
			else
			{
				weapon = _weapon;
			}
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A85B0");
			float num3;
			object obj9;
			if (System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref ret) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1E-05f))
			{
				num3 = (float)characterController._lastFacingDirection / (float)ret;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rcx_v17 (VampireSurvivors.Objects.Characters.CharacterController)+238]");
				obj9 = 0 / ret;
			}
			else
			{
				nint num4 = (nint)typeof(Vector2);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ rax_v30 (Il2CppClass<UnityEngine.Vector2>)+B8]");
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v504 @ rcx_v23 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
				obj9 = 0;
				num3 = (float)Vector2.zeroVector;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001872C7435h\"");
			if (num3 == 0f)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001872C7435h\"");
				if (obj9 == null)
				{
					num3 = 1f;
				}
			}
			float projectileSpeed3 = ProjectileSpeed;
			float num6 = 0f * num3;
			reference = ref *(Vector2*)num6;
			float projectileSpeed4 = ProjectileSpeed;
			float num7 = num6 * (float)obj9;
			return null;
		}
		UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(cachedTransform);
		throw new NullReferenceException();
	}

	public unsafe virtual Transform AimForNearestEnemyToPlayer(bool rotate = true)
	{
		//IL_00a0: Expected O, but got Ref
		//IL_0123: Expected O, but got I4
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			Weapon weapon = _weapon;
			if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
			{
				float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
				if ((object)core._stage != null)
				{
					object obj = default(object);
					EnemyController enemyController = core._stage.FindClosestEnemy((Vector3)(&obj), excludeDead: true);
					if ((object)enemyController == null || ((UnityEngine.Object)enemyController).m_CachedPtr == (IntPtr)0)
					{
						return null;
					}
					if ((object)enemyController._EnemyRenderer != null)
					{
						Transform target = enemyController._EnemyRenderer.transform;
						ApplyInitialVelocity(target, _cachedTransform, rotate, (Vector3?)(object)0);
						if ((object)enemyController._EnemyRenderer != null)
						{
							return enemyController._EnemyRenderer.transform;
						}
					}
				}
			}
		}
		return (Transform)(object)new NullReferenceException();
	}

	public unsafe virtual Transform AimForNearestEnemy(bool rotate = true)
	{
		//IL_003a: Expected O, but got Ref
		//IL_00e9: Expected O, but got Ref
		//IL_00ba: Expected O, but got I4
		GameManager core = GM.Core;
		object cachedTransform = _cachedTransform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rbx_v3 (System.Object)+10]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rbx_v3 (System.Object)+10]");
			Transform.get_position_Injected((IntPtr)0, out Vector3 _);
			object obj = default(object);
			EnemyController enemyController = core._stage.FindClosestEnemy((Vector3)(&obj), excludeDead: true);
			if ((object)enemyController != null && ((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
			{
				Transform target = enemyController._EnemyRenderer.transform;
				Weapon weapon = _weapon;
				Transform playerTransform = ((Equipment)weapon)._003COwner_003Ek__BackingField.transform;
				ApplyInitialVelocity(target, playerTransform, rotate, (Vector3?)(object)0);
				return enemyController._EnemyRenderer.transform;
			}
			ApplyPlayerFacingVelocity((Vector3)(&obj), rotate);
			return null;
		}
		UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(cachedTransform);
		throw new NullReferenceException();
	}

	public unsafe virtual Transform AimForNearestEnemyFrom(Transform targetT, bool rotate = true, Vector3? customFromPosition = null)
	{
		//IL_003a: Expected O, but got Ref
		//IL_00c8: Expected O, but got Ref
		//IL_0099: Expected O, but got I4
		GameManager core = GM.Core;
		object cachedTransform = _cachedTransform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbx_v3 (System.Object)+10]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbx_v3 (System.Object)+10]");
			Transform.get_position_Injected((IntPtr)0, out Vector3 _);
			object obj = default(object);
			EnemyController enemyController = core._stage.FindClosestEnemy((Vector3)(&obj), excludeDead: true);
			if ((object)enemyController != null && ((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
			{
				Transform target = enemyController._EnemyRenderer.transform;
				ApplyInitialVelocity(target, targetT, rotate, (Vector3?)(object)0);
				return enemyController._EnemyRenderer.transform;
			}
			ApplyPlayerFacingVelocity((Vector3)(&obj), rotate);
			return null;
		}
		UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(cachedTransform);
		throw new NullReferenceException();
	}

	protected unsafe virtual Transform AimForRandomEnemy(bool rotate = true)
	{
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected Ref, but got Unknown
		//IL_0211: Expected O, but got Ref
		//IL_01b3: Expected O, but got I4
		Weapon weapon = _weapon;
		Transform transform;
		if ((object)_weapon != null)
		{
			GameManager gameMan = weapon._gameMan;
			if ((object)weapon._gameMan != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null && (object)gameMan._stage != null)
			{
				ref Unity.Mathematics.Random rng = ref *(Unity.Mathematics.Random*)(((Equipment)weapon)._003COwner_003Ek__BackingField + 176);
				transform = gameMan._stage.PickRandomEnemy(ref rng);
				if ((object)transform == null || ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0)
				{
					goto IL_01b8;
				}
				Weapon weapon2 = _weapon;
				if ((object)_weapon != null)
				{
					VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
					if ((object)((Equipment)weapon2)._003COwner_003Ek__BackingField == null || ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0)
					{
						goto IL_01b8;
					}
					Weapon weapon3 = _weapon;
					if ((object)_weapon != null && (object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null)
					{
						Transform playerTransform = ((Equipment)weapon3)._003COwner_003Ek__BackingField.transform;
						ApplyInitialVelocity(transform, playerTransform, rotate, (Vector3?)(object)0);
						goto IL_029b;
					}
				}
			}
		}
		goto IL_021b;
		IL_021b:
		return (Transform)(object)new NullReferenceException();
		IL_029b:
		return transform;
		IL_01b8:
		Weapon weapon4 = _weapon;
		if ((object)_weapon == null || (object)((Equipment)weapon4)._003COwner_003Ek__BackingField == null)
		{
			goto IL_021b;
		}
		object obj = default(object);
		ApplyPlayerFacingVelocity((Vector3)(&obj), rotate);
		transform = null;
		goto IL_029b;
	}

	protected unsafe virtual Transform GetNearestEnemyTransform()
	{
		//IL_00a0: Expected O, but got Ref
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			Weapon weapon = _weapon;
			if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
			{
				float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
				if ((object)core._stage != null)
				{
					object obj = default(object);
					EnemyController enemyController = core._stage.FindClosestEnemy((Vector3)(&obj), excludeDead: true);
					if ((object)enemyController == null || ((UnityEngine.Object)enemyController).m_CachedPtr == (IntPtr)0)
					{
						return null;
					}
					if ((object)enemyController._EnemyRenderer != null)
					{
						return enemyController._EnemyRenderer.transform;
					}
				}
			}
		}
		return (Transform)(object)new NullReferenceException();
	}

	protected unsafe virtual Transform AimForRandomEnemyInScreen(Rectangle _rect = null)
	{
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected Ref, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected Ref, but got Unknown
		Weapon weapon = _weapon;
		if (_rect != null)
		{
			if ((object)_weapon != null)
			{
				GameManager gameMan = weapon._gameMan;
				if ((object)weapon._gameMan != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null && (object)gameMan._stage != null)
				{
					ref Unity.Mathematics.Random rng = ref *(Unity.Mathematics.Random*)(((Equipment)weapon)._003COwner_003Ek__BackingField + 176);
					return gameMan._stage.PickRandomEnemyInRectBounds(_rect, ref rng);
				}
			}
		}
		else if ((object)_weapon != null)
		{
			GameManager gameMan2 = weapon._gameMan;
			if ((object)weapon._gameMan != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null && (object)gameMan2._stage != null)
			{
				ref Unity.Mathematics.Random rng2 = ref *(Unity.Mathematics.Random*)(((Equipment)weapon)._003COwner_003Ek__BackingField + 176);
				return gameMan2._stage.PickRandomEnemyInScreenBounds(ref rng2);
			}
		}
		return (Transform)(object)new NullReferenceException();
	}

	public virtual void AimForRandomDirection(bool rotate = false)
	{
		//IL_0010: Expected O, but got I
		//IL_0118: Expected O, but got I4
		//IL_013b: Expected O, but got I4
		//IL_0076: Expected O, but got I8
		//IL_0198: Expected F4, but got O
		//IL_018a->IL014f: Incompatible stack heights: 1 vs 0
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag = (nint)0 != 0;
		Projectile projectile = this;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			projectile = (Projectile)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v49 @ rax_v15 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
		float projectileSpeed = ProjectileSpeed;
		float2 velocity = (float2)(0 * 0);
		float projectileSpeed2 = ProjectileSpeed;
		ArcadeSprite sprite = _sprite;
		object obj2 = 0 * 0;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = velocity;
		if (rotate)
		{
			Transform transform = base.transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
			Vector3 axis = default(Vector3);
			Quaternion.AngleAxis_Injected((float)this, ref axis, out Quaternion _);
			bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Quaternion value = default(Quaternion);
			Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		}
	}

	public unsafe virtual void ApplyInitialVelocity(Transform target, Transform playerTransform, bool rotate = true, Vector3? customFromPosition = null)
	{
		//IL_034a: Expected I, but got O
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Expected O, but got Unknown
		//IL_0174: Expected O, but got I
		//IL_001f: Expected O, but got I
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Expected O, but got Unknown
		//IL_01c6: Expected O, but got I
		//IL_01e3: Expected O, but got I
		//IL_0200: Invalid comparison between O and F4
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Expected O, but got Unknown
		//IL_026e: Expected O, but got I
		//IL_028e: Expected I, but got O
		//IL_02b7: Expected O, but got I
		//IL_02cb: Expected I, but got O
		//IL_03ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ef: Expected O, but got Unknown
		//IL_03f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fd: Expected O, but got Unknown
		//IL_040b: Expected F4, but got O
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_0325: Expected O, but got Unknown
		//IL_004b->IL010e: Incompatible stack heights: 1 vs 0
		//IL_03dc->IL010e: Incompatible stack heights: 1 vs 0
		//IL_0280->IL0196: Incompatible stack heights: 2 vs 1
		//IL_00a8->IL010e: Incompatible stack heights: 1 vs 0
		//IL_033c->IL02bc: Incompatible stack heights: 3 vs 1
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v3 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		_ = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
		if ((object)target != null)
		{
			_ = 0;
			_ = 0;
			bool flag = ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0;
			object obj2 = default(object);
			object obj = obj2 - 64;
			Transform.get_position_Injected(((UnityEngine.Object)target).m_CachedPtr, out *(Vector3*)obj);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp+40]");
			object obj3 = 0;
			object obj4;
			if (obj3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-4C]");
				obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
			}
			else
			{
				if ((object)playerTransform == null)
				{
					goto IL_010e;
				}
				_ = 0;
				_ = 0;
				bool flag2 = ((UnityEngine.Object)playerTransform).m_CachedPtr == (IntPtr)0;
				obj = obj2 - 80;
				Transform.get_position_Injected(((UnityEngine.Object)playerTransform).m_CachedPtr, out *(Vector3*)obj);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-50]");
				obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-48]");
				_ = 0;
			}
			object obj5 = obj2 + 40;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-40]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-60]");
			object obj6 = num3 - 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-3C]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-5C]");
			object obj7 = num4 - 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A85B0");
			Vector2 vector;
			object obj8;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1E-05f))
			{
				vector = (Vector2)(obj6 / obj4);
				obj8 = obj7 / obj4;
			}
			else
			{
				nint num5 = (nint)typeof(Vector2);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v543 @ rax_v61 (Il2CppClass<UnityEngine.Vector2>)+B8]");
				nint num6 = 0;
				vector = Vector2.zeroVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v544 @ rcx_v44 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
				obj8 = 0;
			}
			float projectileSpeed = ProjectileSpeed;
			float2 velocity = obj4 * (object)vector;
			float projectileSpeed2 = ProjectileSpeed;
			ArcadeSprite sprite = _sprite;
			object obj9 = obj4 * obj8;
			if ((object)_sprite != null)
			{
				BaseBody baseBody = sprite.body;
				if (sprite.body != null)
				{
					baseBody._velocity = velocity;
					if (rotate)
					{
						Transform transform = base.transform;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
						nint num7 = (nint)typeof(Vector3);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v713 @ rax_v46 (Il2CppClass<UnityEngine.Vector3>)+B8]");
						nint num8 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v714 @ rax_v47 (Il2CppStaticFields<UnityEngine.Vector3>)+50]");
						_ = 0;
						_ = Vector3.forwardVector;
						_ = 0;
						object obj10 = obj2 - 80;
						object obj11 = obj2 - 64;
						Quaternion.AngleAxis_Injected((float)this, ref *(Vector3*)obj11, out *(Quaternion*)obj10);
						bool flag3 = (object)transform == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-50]");
						_ = 0;
						bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						object obj12 = obj2 - 96;
						Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Quaternion*)obj12);
					}
					return;
				}
			}
		}
		goto IL_010e;
		IL_010e:
		throw new NullReferenceException();
	}

	public virtual void ApplyAngleVelocity(float angleAim, bool rotate = true)
	{
		//IL_0079: Expected O, but got F4
		//IL_0109: Expected F4, but got O
		//IL_00fb->IL00c0: Incompatible stack heights: 1 vs 0
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
		float projectileSpeed = ProjectileSpeed;
		float num = angleAim * angleAim;
		float projectileSpeed2 = ProjectileSpeed;
		ArcadeSprite sprite = _sprite;
		float num2 = angleAim * angleAim;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = (float2)num;
		if (rotate)
		{
			Transform transform = base.transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
			Vector3 axis = default(Vector3);
			Quaternion.AngleAxis_Injected((float)this, ref axis, out Quaternion _);
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Quaternion value = default(Quaternion);
			Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		}
	}

	protected unsafe virtual float RotateTowardsEnemy()
	{
		//IL_0008: Expected O, but got Ref
		//IL_01f7: Expected O, but got Ref
		//IL_004e: Expected O, but got Ref
		//IL_0174: Expected F4, but got I4
		//IL_025e: Expected I, but got O
		//IL_02e8: Expected O, but got Ref
		//IL_0325: Expected O, but got I
		//IL_0342: Expected O, but got I
		//IL_0360: Invalid comparison between O and F4
		//IL_03be: Expected I, but got O
		//IL_0382: Expected I, but got O
		//IL_039b: Expected F4, but got O
		//IL_03ab: Expected F4, but got I
		//IL_0479: Expected O, but got Ref
		//IL_0487: Expected O, but got Ref
		//IL_049e: Expected F4, but got O
		//IL_041b: Expected O, but got Ref
		//IL_043d->IL043d: Incompatible stack heights: 3 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			object cachedTransform = _cachedTransform;
			if ((object)_cachedTransform != null)
			{
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rbx_v9 (System.Object)+10]");
				if ((nint)0 == 0)
				{
					UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(_cachedTransform);
				}
				else
				{
					object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rbx_v9 (System.Object)+10]");
					Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj3);
					if ((object)core._stage != null)
					{
						Vector3 queryPos = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-9]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-1]");
						_ = 0;
						EnemyController enemyController = core._stage.FindClosestEnemy(queryPos, excludeDead: true);
						Weapon weapon = _weapon;
						if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
						{
							Transform transform = ((Equipment)weapon)._003COwner_003Ek__BackingField.transform;
							if ((object)enemyController == null || ((UnityEngine.Object)enemyController).m_CachedPtr == (IntPtr)0)
							{
								return 0f;
							}
							nint num = (nint)typeof(Vector2);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v713 @ rax_v41 (Il2CppClass<UnityEngine.Vector2>)+B8]");
							nint num2 = 0;
							_ = Vector2.zeroVector;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rdx_v20 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
							_ = 0;
							float2 float5 = enemyController.position;
							if ((object)transform != null)
							{
								_ = 0;
								_ = 0;
								bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
								Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj4);
								nint num3 = (nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 119));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+7F]");
								nint num4 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-9]");
								object obj5 = num4 - 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+83]");
								nint num5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-5]");
								object obj6 = num5 - 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A85B0");
								float num7;
								if (System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref Vector2.zeroVector) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1E-05f))
								{
									float num6 = (float)obj5 / (float)Vector2.zeroVector;
									num7 = (float)obj6 / (float)Vector2.zeroVector;
								}
								else
								{
									nint num8 = (nint)typeof(Vector2);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v808 @ rax_v67 (Il2CppClass<UnityEngine.Vector2>)+B8]");
									num3 = 0;
									float num6 = (float)Vector2.zeroVector;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v816 @ rcx_v41 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
									num7 = 0f;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
								float result = num7 * 57.29578f;
								Transform transform2 = base.transform;
								nint num9 = (nint)typeof(Vector3);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v849 @ rcx_v44 (Il2CppClass<UnityEngine.Vector3>)+B8]");
								nint num10 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v850 @ rax_v53 (Il2CppStaticFields<UnityEngine.Vector3>)+50]");
								_ = 0;
								_ = Vector3.forwardVector;
								_ = 0;
								object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
								object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
								Quaternion.AngleAxis_Injected((float)typeof(Vector3), ref *(Vector3*)obj8, out *(Quaternion*)obj7);
								bool flag2 = (object)transform2 == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-9]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v51 (UnityEngine.Transform)+10]");
								bool flag3 = (nint)0 == 0;
								object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 23));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v51 (UnityEngine.Transform)+10]");
								Transform.set_rotation_Injected((IntPtr)0, ref *(Quaternion*)obj9);
								return result;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKnockBack = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
	}

	public void OnGetDamaged(HitVfxType hitVfxType, bool hasKb = true)
	{
	}

	public bool IsUnitDead()
	{
		return false;
	}

	public float MaxHp()
	{
		return 1f;
	}

	public float CurrentHealth()
	{
		return 1f;
	}

	public GameObject GetGameObject()
	{
		return base.gameObject;
	}

	public void GiveReward(Action<Pickup> onRewardGiven = null)
	{
	}

	public float AlphaFromScale(float weaponArea, float maxScale, float minAlpha)
	{
		//IL_0052: Invalid comparison between F4 and I4
		float num = maxScale - 1f;
		float num2 = 1f - minAlpha;
		bool flag = !(1f < weaponArea);
		float result = 1f;
		if (!flag)
		{
			bool flag2 = num < 0f;
			result = 1f;
			if (!flag2)
			{
				if (!(weaponArea < maxScale))
				{
					return minAlpha;
				}
				float num3 = weaponArea - 1f;
				float num4 = num3 * num2;
				float num5 = num4 / num;
				result = 1f - num5;
			}
		}
		return result;
	}

	public Projectile()
	{
		HashSet<IDamageable> objectsHit = (HashSet<IDamageable>)(object)new HashSet<object>();
		_objectsHit = objectsHit;
		((GameMonoBehaviour)this)._onResumeSent = true;
	}

	static Projectile()
	{
		//IL_002b: Expected O, but got I
		IntPtr intPtr = ProfilerUnsafeUtility.CreateMarker("Projectile.InitProjectile", 1, MarkerFlags.Default, 0);
		_markerInitProjectile = (ProfilerMarker)(nint)intPtr;
	}
}
