using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Projectiles;

public class unused_EME_PistolProjectile_Basic : Projectile
{
	private ParticleSystem pistolBasicVFX;

	private ParticleSystem pistolTargetingVFX;

	private ParticleEventCall pistolBasicParticleEventCall;

	private ParticleEventCall pistolTargetingParticleEventCall;

	private const float MAX_HOMING_ANGLE_CHANGE_PER_SECOND = 360f;

	private bool _projectileLaunched;

	private float penetrationAmount;

	protected EnemyController _targetEnemyController;

	private SpriteAnimation _anims;

	private bool _useHoming = true;

	private Timer _prefireTimer;

	protected override void Awake()
	{
		base.Awake();
		if ((object)pistolTargetingVFX != null)
		{
			Transform component = pistolTargetingVFX.transform;
			Transform transform = RenderingExtensions.SetScale(component, 0.33f);
		}
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0223->IL0228: Incompatible stack heights: 1 vs 0
		//IL_0193->IL0228: Incompatible stack heights: 1 vs 0
		int index2 = default(int);
		base.InitProjectile(pool, weapon, index2);
		object obj = default(object);
		float x = (float)CameraExtensions.OrthographicBounds(_mainCamera).m_Center - (float)obj;
		float num = (float)obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rax_v5 (UnityEngine.Bounds)+10]");
		float y = num - 0f;
		float width = (float)obj * 2f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rax_v5 (UnityEngine.Bounds)+10]");
		float height = 0f * 2f;
		Rectangle rectangle = new Rectangle();
		rectangle._x = x;
		rectangle._y = y;
		rectangle._width = width;
		rectangle._height = height;
		EnemyController randomEnemyControllerOnScreen = GetRandomEnemyControllerOnScreen(rectangle);
		_targetEnemyController = randomEnemyControllerOnScreen;
		EnemyController targetEnemyController = _targetEnemyController;
		if ((object)_targetEnemyController != null && ((UnityEngine.Object)targetEnemyController).m_CachedPtr != (IntPtr)0)
		{
			SetupMechanics();
			EnemyController targetEnemyController2 = _targetEnemyController;
			Vector2 vector = targetEnemyController2._EnemyRenderer.size;
			Transform transform = pistolTargetingVFX.transform;
			float2 float5 = _targetEnemyController.position;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			if ((object)pistolTargetingVFX != null)
			{
				pistolTargetingVFX.Play(withChildren: true);
			}
		}
		else
		{
			Despawn();
		}
	}

	private void SetupMechanics()
	{
		//IL_0040: Expected O, but got I4
		//IL_0040: Expected O, but got I4
		//IL_0054: Expected O, but got I4
		//IL_006f: Expected I, but got O
		BaseBody baseBody = body;
		_projectileLaunched = false;
		baseBody._enable = false;
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody2 = sprite.body.setCircle(8f, (float?)(object)0, (float?)(object)0);
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		Weapon weapon = _weapon;
		nint num = (nint)weapon;
		float num2 = weapon.PSpeed();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
		float num3 = default(float);
		penetrationAmount = num3;
		if (_prefireTimer != null)
		{
			_prefireTimer.Cancel();
		}
		Action onComplete = EnableProjectileLaunch;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer prefireTimer = Timers.Register(1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_prefireTimer = prefireTimer;
		Weapon weapon2 = _weapon;
		if (weapon2._currentWeaponData != null)
		{
			return;
		}
		throw new NullReferenceException();
	}

	private void SetupVisuals()
	{
		EnemyController targetEnemyController = _targetEnemyController;
		if ((object)_targetEnemyController != null && (object)targetEnemyController._EnemyRenderer != null)
		{
			Vector2 vector = targetEnemyController._EnemyRenderer.size;
			if ((object)pistolTargetingVFX != null)
			{
				Transform transform = pistolTargetingVFX.transform;
				if ((object)_targetEnemyController != null)
				{
					float2 float5 = _targetEnemyController.position;
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					if ((object)pistolTargetingVFX != null)
					{
						pistolTargetingVFX.Play(withChildren: true);
					}
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public void EnableProjectileLaunch()
	{
		EnemyController targetEnemyController = _targetEnemyController;
		if ((object)_targetEnemyController != null && ((UnityEngine.Object)targetEnemyController).m_CachedPtr != (IntPtr)0)
		{
			EnemyController targetEnemyController2 = _targetEnemyController;
			if (targetEnemyController2.body != null)
			{
				BaseBody baseBody = body;
				_projectileLaunched = true;
				baseBody._enable = true;
				Weapon weapon = _weapon;
				Transform playerTransform = ((Equipment)weapon)._003COwner_003Ek__BackingField.transform;
				Vector2 targetPosition = default(Vector2);
				Vector3? customFromPosition = default(Vector3?);
				ApplyInitialVelocity(targetPosition, playerTransform, rotate: true, customFromPosition);
				if ((object)pistolBasicVFX != null)
				{
					pistolBasicVFX.Play(withChildren: true);
				}
				return;
			}
		}
		Despawn();
	}

	private unsafe void ApplyInitialVelocity(Vector2 targetPosition, Transform playerTransform, bool rotate = true, Vector3? customFromPosition = null)
	{
		//IL_0176: Expected O, but got Ref
		//IL_0183: Expected O, but got I
		//IL_00a6: Expected O, but got I
		//IL_0188->IL010e: Incompatible stack heights: 1 vs 0
		//IL_01d3->IL01d3: Incompatible stack heights: 1 vs 0
		unused_EME_PistolProjectile_Basic unused_EME_PistolProjectile_Basic2 = this;
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
			Vector2 vector = targetPosition;
		}
		else
		{
			if ((object)playerTransform == null)
			{
				goto IL_0137;
			}
			bool flag = ((UnityEngine.Object)playerTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)playerTransform).m_CachedPtr, out Vector3 ret);
			Vector2 vector = (Vector2)(&ret);
			unused_EME_PistolProjectile_Basic2 = (unused_EME_PistolProjectile_Basic)(nint)((UnityEngine.Object)playerTransform).m_CachedPtr;
		}
		EnemyController targetEnemyController = _targetEnemyController;
		if ((object)_targetEnemyController != null)
		{
			BaseBody baseBody = targetEnemyController.body;
			if (targetEnemyController.body != null)
			{
				object obj2 = baseBody._velocity * baseBody._velocity;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ rax_v19 (BaseBody)+74]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ rax_v19 (BaseBody)+74]");
				object obj3 = num * 0;
				object obj4 = obj3 + obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
				object obj5 = default(object);
				if (obj5 == null)
				{
					if ((object)playerTransform == null)
					{
						goto IL_0137;
					}
					bool flag2 = ((UnityEngine.Object)playerTransform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)playerTransform).m_CachedPtr, out Vector3 _);
					Vector2 vector2 = default(Vector2);
					Vector2 leadAimPosition = GetLeadAimPosition(vector2, targetPosition, vector2);
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 310 Invalid \"Jump target not found in method: 0x18724A0F0\"");
			}
		}
		goto IL_0137;
		IL_0137:
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		BaseBody baseBody = body;
		baseBody._enable = false;
		_projectileLaunched = false;
		if ((object)pistolBasicVFX != null)
		{
			pistolBasicVFX.Stop();
		}
		if ((object)pistolBasicVFX != null)
		{
			pistolBasicVFX.Clear(withChildren: true);
		}
		if ((object)pistolTargetingVFX != null)
		{
			pistolTargetingVFX.Stop();
		}
		if ((object)pistolTargetingVFX != null)
		{
			pistolTargetingVFX.Stop();
		}
		base.Despawn();
	}

	private void DespawnAfterParticlesStopped()
	{
		base.Despawn();
	}

	private void FinishDespawn()
	{
		base.Despawn();
	}

	private Vector2 GetLeadAimPosition(Vector2 firePosition, Vector2 targetPosition, Vector2 targetVelocity)
	{
		//IL_004c: Expected I, but got O
		//IL_0136: Invalid comparison between I4 and F4
		//IL_0153: Invalid comparison between I4 and F4
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Expected O, but got Unknown
		//IL_017a: Expected F4, but got I4
		//IL_0227: Invalid comparison between F4 and I4
		object obj2 = default(object);
		object obj3 = default(object);
		object obj = obj2 - obj3;
		object obj4 = targetPosition - firePosition;
		float projectileSpeed = base.ProjectileSpeed;
		nint num = (nint)this;
		object obj6 = default(object);
		object obj5 = obj6 * obj6;
		object obj8 = default(object);
		object obj7 = obj8 * obj8;
		object obj9 = obj5 + obj7;
		float projectileSpeed2 = base.ProjectileSpeed;
		object obj11 = default(object);
		object obj10 = obj11 * obj11;
		object obj12 = obj9 - obj10;
		object obj13 = obj6 * obj;
		object obj14 = obj8 * obj4;
		object obj15 = obj13 + obj14;
		object obj16 = obj15 + obj15;
		object obj17 = obj * obj;
		float num2 = (float)obj12 * 4f;
		object obj18 = obj4 * obj4;
		object obj19 = obj16 * obj16;
		object obj20 = obj17 + obj18;
		float num3 = (float)obj20 * num2;
		float num4 = (float)obj19 - num3;
		Vector2 result = default(Vector2);
		if (!(0f > num4))
		{
			float num5;
			if (!(0f > num4))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm0,xmm1\"");
				num5 = 0f;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
				num5 = num4;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			object obj21 = obj16 ^ 0;
			object obj22 = obj12 + obj12;
			object obj23 = obj12 + obj12;
			float num6 = num5 / (float)obj22;
			object obj24 = obj21 / obj23;
			float num7 = (float)obj24 + num6;
			float num8 = (float)obj24 - num6;
			if (!(num8 > num7) || num7 > 0f)
			{
				return result;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C244F0");
		float projectileSpeed3 = base.ProjectileSpeed;
		return result;
	}

	private void SetProjectileVelocity(Vector2 projectileDirection, bool rotate)
	{
		//IL_00eb: Expected F4, but got O
		//IL_00dd->IL00a2: Incompatible stack heights: 1 vs 0
		Vector2 vector = default(Vector2);
		vector.Normalize();
		float projectileSpeed = base.ProjectileSpeed;
		object obj = default(object);
		float2 velocity = (object)projectileDirection * obj;
		object obj3 = default(object);
		object obj2 = obj3 * obj;
		ArcadeSprite sprite = _sprite;
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

	public unsafe override void InternalUpdate()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0589: Expected O, but got Ref
		//IL_05ef: Expected O, but got Ref
		//IL_043b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0440: Expected O, but got Unknown
		//IL_045d: Expected O, but got Ref
		//IL_047a: Invalid comparison between O and F4
		//IL_06c7: Expected O, but got Ref
		//IL_06ed: Expected O, but got Ref
		//IL_04d0: Expected O, but got Ref
		//IL_04de: Expected O, but got Ref
		//IL_04ec: Expected O, but got Ref
		//IL_0617: Expected I, but got O
		//IL_0637: Expected O, but got I
		//IL_0650: Expected I, but got O
		//IL_065e: Expected O, but got Ref
		//IL_0671: Expected O, but got Ref
		//IL_02df->IL04fb: Incompatible stack heights: 1 vs 0
		//IL_0223->IL04fb: Incompatible stack heights: 1 vs 0
		//IL_0329->IL04fb: Incompatible stack heights: 1 vs 0
		//IL_0245->IL04fb: Incompatible stack heights: 1 vs 0
		//IL_034b->IL04fb: Incompatible stack heights: 1 vs 0
		//IL_0274->IL04fb: Incompatible stack heights: 1 vs 0
		//IL_0374->IL04fb: Incompatible stack heights: 1 vs 0
		//IL_0396->IL04fb: Incompatible stack heights: 1 vs 0
		//IL_03da->IL04fb: Incompatible stack heights: 1 vs 0
		//IL_0609->IL0535: Incompatible stack heights: 3 vs 0
		//IL_041b->IL04fb: Incompatible stack heights: 1 vs 0
		//IL_06b9->IL0535: Incompatible stack heights: 1 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		EnemyController targetEnemyController = _targetEnemyController;
		if ((object)_targetEnemyController != null && ((UnityEngine.Object)targetEnemyController).m_CachedPtr != (IntPtr)0)
		{
			EnemyController targetEnemyController2 = _targetEnemyController;
			if ((object)_targetEnemyController == null)
			{
				goto IL_04fb;
			}
			if (targetEnemyController2._003CIsDead_003Ek__BackingField)
			{
				_targetEnemyController = null;
			}
		}
		if (!_useHoming)
		{
			return;
		}
		EnemyController targetEnemyController3 = _targetEnemyController;
		if ((object)_targetEnemyController == null || ((UnityEngine.Object)targetEnemyController3).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		EnemyController targetEnemyController4 = _targetEnemyController;
		if ((object)_targetEnemyController != null)
		{
			if (targetEnemyController4.body == null)
			{
				return;
			}
			if ((object)targetEnemyController4._EnemyRenderer != null)
			{
				Vector2 vector = targetEnemyController4._EnemyRenderer.size;
				if ((object)pistolTargetingVFX != null)
				{
					Transform transform = pistolTargetingVFX.transform;
					if ((object)_targetEnemyController != null)
					{
						float2 float5 = _targetEnemyController.position;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v515 @ rax_v31 (UnityEngine.Transform)+10]");
						bool flag = (nint)0 == 0;
						object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v515 @ rax_v31 (UnityEngine.Transform)+10]");
						Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)obj3);
						if (!_projectileLaunched)
						{
							Transform transform2 = base.transform;
							Weapon weapon = _weapon;
							if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
							{
								Transform transform3 = ((Equipment)weapon)._003COwner_003Ek__BackingField.transform;
								if ((object)transform3 != null)
								{
									Vector3 vector2 = transform3.position;
									bool flag2 = (object)transform2 == null;
									_ = vector2.x;
									_ = vector2.z;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v516 @ rax_v64 (UnityEngine.Transform)+10]");
									bool flag3 = (nint)0 == 0;
									object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v516 @ rax_v64 (UnityEngine.Transform)+10]");
									Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)obj4);
									return;
								}
							}
						}
						else
						{
							Transform transform4 = base.transform;
							if ((object)transform4 != null)
							{
								Vector3 vector3 = transform4.position;
								_ = vector3.z;
								EnemyController targetEnemyController5 = _targetEnemyController;
								_ = vector3.x;
								if ((object)_targetEnemyController != null && targetEnemyController5.body != null)
								{
									EnemyController targetEnemyController6 = _targetEnemyController;
									if ((object)_targetEnemyController != null && targetEnemyController6.body != null)
									{
										Vector2 vector4 = default(Vector2);
										Vector2 leadAimPosition = GetLeadAimPosition(vector4, vector4, vector4);
										BaseBody baseBody = body;
										if (body != null)
										{
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185015910");
											Transform transform5 = base.transform;
											if ((object)transform5 != null)
											{
												Vector3 vector5 = transform5.position;
												object obj5 = 0 - vector5.z;
												_ = vector5.x;
												object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C6C6E0");
												if (System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector4) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1E-05f))
												{
													object obj7 = obj5 / (object)vector4;
													object obj8 = obj7;
												}
												else
												{
													nint num = (nint)typeof(Vector3);
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1188 @ rax_v61 (Il2CppClass<UnityEngine.Vector3>)+B8]");
													nint num2 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1189 @ rcx_v52 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
													object obj8 = 0;
													_ = Vector3.zeroVector;
												}
												Vector3 forward = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
												_ = 0;
												Quaternion quaternion2 = Quaternion.LookRotation(forward);
												Vector3 forward2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
												Quaternion quaternion3 = Quaternion.LookRotation(forward2);
												_ = quaternion2.x;
												_ = quaternion3.x;
												float deltaTime = PauseSystem.DeltaTime;
												float num3 = deltaTime * 360f;
												object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
												object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
												object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1870D8E20");
												nint num4 = (nint)typeof(Vector3);
												Vector3 vector6 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
												Quaternion quaternion4 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1253 @ rax_v53 (Il2CppClass<UnityEngine.Vector3>)+B8]");
												nint num5 = 0;
												_ = Vector3.forwardVector;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1258 @ rax_v54 (Il2CppStaticFields<UnityEngine.Vector3>)+50]");
												_ = 0;
												Vector3 vector7 = quaternion4 * vector6;
												SetProjectileVelocity(vector4, rotate: true);
												return;
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_04fb;
		IL_04fb:
		throw new NullReferenceException();
	}

	private unsafe static void FireDirectlyAtTarget(Vector2 targetPosition, Vector2 playerPosition, ref Vector2 projectileDirection)
	{
		object obj = targetPosition - playerPosition;
		object obj3 = default(object);
		object obj4 = default(object);
		object obj2 = obj3 - obj4;
		ref Vector2 reference = ref *(Vector2*)obj;
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		//IL_003a: Invalid comparison between F4 and I4
		//IL_01d4: Expected O, but got I4
		//IL_01ee: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		if (penetrationAmount > 0f)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			EnemyController component = gameObject.GetComponent<EnemyController>();
			if (!component || !_targetEnemyController)
			{
				goto IL_0179;
			}
			EnemyController targetEnemyController = _targetEnemyController;
			bool flag = (object)_targetEnemyController == null;
			bool flag2 = (object)component == null;
			object obj2 = flag2 & flag;
			bool flag3 = obj2 == null;
			object obj3 = !flag3;
			if (obj3 == null)
			{
				bool flag4;
				if ((object)_targetEnemyController != null)
				{
					if ((object)component != null)
					{
						object obj4 = (object)component - (object)_targetEnemyController;
						flag4 = obj4 == null;
					}
					else
					{
						flag4 = ((UnityEngine.Object)targetEnemyController).m_CachedPtr == (IntPtr)0;
					}
				}
				else
				{
					flag4 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
				}
				if (!flag4)
				{
					goto IL_0179;
				}
			}
		}
		Despawn();
		return;
		IL_0179:
		float num = penetrationAmount - 1f;
		penetrationAmount = num;
	}

	private static EnemyController GetRandomEnemyControllerOnScreen(Rectangle _rect)
	{
		//IL_0134: Expected O, but got I4
		//IL_03cf: Expected O, but got I4
		//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Expected O, but got Unknown
		//IL_02f4: Expected O, but got I4
		//IL_0322->IL036d: Incompatible stack heights: 4 vs 0
		//IL_036d->IL03ef: Incompatible stack heights: 6 vs 0
		//IL_020c->IL03b3: Incompatible stack heights: 6 vs 7
		//IL_02fd->IL0142: Incompatible stack heights: 7 vs 4
		//IL_0302->IL0302: Incompatible stack heights: 7 vs 4
		//IL_02c7->IL02db: Incompatible stack heights: 8 vs 7
		//IL_02db->IL02db: Incompatible stack heights: 8 vs 7
		if (_rect != null)
		{
			List<EnemyController> list = new List<EnemyController>();
			bool flag = (object)GM.Core == null;
			bool flag2 = (object)ArcadePhysics.s_instance == null;
			float height = default(float);
			bool includeDynamic = default(bool);
			bool includeStatic = default(bool);
			Group specificGroup = default(Group);
			List<BaseBody> list2 = ArcadePhysics.s_instance.OverlapRect(_rect._x, _rect._y, _rect._width, height, includeDynamic, includeStatic, specificGroup);
			bool flag3 = list == null;
			int version = list._version + 1;
			list._version = version;
			list._size = 0;
			if (list._size > 0)
			{
				Array.Clear(list._items, 0, list._size);
			}
			bool flag4 = (nint)list2 < 0;
			bool flag5 = list2 == null;
			object obj = list2._size - 1;
			if (!flag4)
			{
				object obj4;
				do
				{
					bool flag6 = (nint)obj >= list2._size;
					BaseBody[] items = list2._items;
					bool flag7 = list2._items == null;
					BaseBody baseBody = items[obj];
					bool flag8 = items[obj] == null;
					UnityEngine.Object obj2 = (UnityEngine.Object)(object)items[obj];
					if (!flag8)
					{
						obj2 = baseBody._gameObject;
					}
					UnityEngine.Object obj3;
					if (!obj2)
					{
						obj3 = null;
					}
					else
					{
						bool flag9 = (object)obj2 == null;
						EnemyController component = ((Component)obj2).GetComponent<EnemyController>();
						obj3 = component;
					}
					bool flag10 = obj3;
					bool flag11 = (flag10 ? 1 : 0) < (false ? 1 : 0);
					if (flag10)
					{
						bool flag12 = (object)obj3 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rbx_v13 (UnityEngine.Object)+260]");
						flag11 = (nint)0 < (nint)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rbx_v13 (UnityEngine.Object)+260]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FE520");
						}
					}
					obj--;
					obj4 = !flag11;
				}
				while (obj4 != null);
			}
			if (list._size > 0)
			{
				object obj5 = UnityEngine.Random.RandomRangeInt(0, list._size);
				bool flag13 = (nint)obj5 >= list._size;
				EnemyController[] items2 = list._items;
				bool flag14 = list._items == null;
				return items2[obj5];
			}
		}
		return null;
	}
}
