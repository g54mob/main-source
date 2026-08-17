using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Game.Combat.EnemyDebuffs;
using Assets.Scripts.Game.Combat.EnemyDebuffs.Implementations;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

namespace Actors.Enemies;

public class EnemyMovementRb : MonoBehaviour
{
	public enum State
	{
		Normal,
		Sucked,
		Charmed
	}

	public Enemy enemy;

	public Rigidbody rb;

	private float nextStepTime;

	private Vector3 offsetBias;

	private Vector3 desiredVelocity;

	private Quaternion desiredRotation;

	private float knockbackResetSpeed;

	private Vector3 knockbackVelocity;

	private float randomOffset;

	private float randomGroundedCheckOffset;

	public State state;

	private float flyingKnockupVel;

	private bool canRotate;

	private string ignoreTag;

	private bool isClimbing;

	private float nextClimbCheckTime;

	private float nextGroundedCheckTime;

	private float groundCheckInterval;

	private bool _003Cgrounded_003Ek__BackingField;

	private bool dashing;

	private float dashStopTime;

	private Vector3 dashDirection;

	private float dashSpeed;

	private bool isDashingWall;

	private HashSet<EDebuff> debuffs;

	private Vector3 baseVelocity;

	private const float baseRotationSpeed = 10f;

	private float rotationSpeed;

	private Vector3 flyingOffset;

	public float distanceToTarget;

	private bool isStationary;

	private float nextGetSpeedTime;

	private float getSpeedCooldown;

	private float storedSpeed;

	private static float knockbackConstant = 10f;

	private const float maxKnockback = 5f;

	private const float maxBossKnockback = 2.25f;

	private float maxKnockbackVelSqrBoss;

	private bool isBoss;

	private float knockbackResistance;

	private float lastFoundKnockbackResTime;

	private Transform suckTarget;

	private float totalSuckTime;

	private float totalSuckTimeMax;

	private float nextCheckDamageTime;

	public bool grounded
	{
		get
		{
			return _003Cgrounded_003Ek__BackingField;
		}
		private set
		{
			_003Cgrounded_003Ek__BackingField = value;
		}
	}

	private void Awake()
	{
		//IL_0101: Expected I, but got O
		Action b = TimescaleVelocity;
		Delegate obj = Delegate.Combine(MyTime.A_TimeScaleChange, b);
		if ((object)obj == null)
		{
			MyTime.A_TimeScaleChange = null;
			return;
		}
		bool flag = (object)obj.GetType() != typeof(Action);
		Delegate obj2 = null;
		if (!flag)
		{
			obj2 = obj;
		}
		if ((object)obj2 != null)
		{
			MyTime.A_TimeScaleChange = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag2)
			{
				obj3 = obj;
			}
			bool flag3 = (object)obj3 == null;
			nint num = (nint)typeof(Action);
			if (!flag3)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnDestroy()
	{
		//IL_0101: Expected I, but got O
		Action value = TimescaleVelocity;
		Delegate obj = Delegate.Remove(MyTime.A_TimeScaleChange, value);
		if ((object)obj == null)
		{
			MyTime.A_TimeScaleChange = null;
			return;
		}
		bool flag = (object)obj.GetType() != typeof(Action);
		Delegate obj2 = null;
		if (!flag)
		{
			obj2 = obj;
		}
		if ((object)obj2 != null)
		{
			MyTime.A_TimeScaleChange = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag2)
			{
				obj3 = obj;
			}
			bool flag3 = (object)obj3 == null;
			nint num = (nint)typeof(Action);
			if (!flag3)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public unsafe void Init()
	{
		//IL_0045: Expected O, but got Ref
		//IL_01fe: Expected I, but got O
		//IL_0239: Expected I, but got O
		nextGetSpeedTime = 0f;
		_003Cgrounded_003Ek__BackingField = true;
		state = State.Normal;
		totalSuckTime = 0f;
		if (!this.enemy.IsImportantEnemy())
		{
			Vector3 insideUnitSphere = UnityEngine.Random.insideUnitSphere;
			float num = default(float);
			Vector3 vector = VectorExtensions.XZVector((Vector3)(&num));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
			float num2 = UnityEngine.Random.Range(0.5f, 1f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ rax_v27+8]");
			float num3 = 0f * num2;
			Vector3 vector2 = default(Vector3);
			offsetBias = vector2;
		}
		else
		{
			nint num4 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v278 @ rax_v29 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num5 = 0;
			offsetBias = Vector3.zeroVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v279 @ rcx_v19 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
			_ = 0;
		}
		nint num6 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ rax_v8 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num7 = 0;
		knockbackVelocity = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rcx_v6 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		Enemy enemy = this.enemy;
		EnemyData enemyData = enemy._003CenemyData_003Ek__BackingField;
		bool useGravity = !enemyData.isFlying;
		rb.useGravity = useGravity;
		float num8 = UnityEngine.Random.Range(0f, 1f);
		randomOffset = num8;
		float num9 = UnityEngine.Random.Range(0f, 0.35f);
		randomGroundedCheckOffset = num9;
		distanceToTarget = 100f;
		dashing = false;
		float num10 = MyTime.time + randomGroundedCheckOffset;
		nextGroundedCheckTime = num10;
		debuffs.Clear();
		bool flag = this.enemy.IsBoss();
		isBoss = flag;
		float speed = this.enemy.GetSpeed();
		float speed2 = this.enemy.GetSpeed();
		Enemy enemy2 = this.enemy;
		float num11 = speed2 * speed;
		float num12 = num11 + 5.0625f;
		maxKnockbackVelSqrBoss = num12;
		EnemyData enemyData2 = enemy2._003CenemyData_003Ek__BackingField;
		totalSuckTimeMax = enemyData2.maxSuckTime;
	}

	public unsafe void MyFixedUpdate()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00bc: Expected F4, but got I
		//IL_00c7: Invalid comparison between F4 and I4
		//IL_0824: Expected I, but got O
		//IL_0867: Expected O, but got I
		//IL_0884: Expected O, but got I
		//IL_08ce: Invalid comparison between F4 and O
		//IL_08ed: Invalid comparison between F4 and I4
		//IL_0916: Expected O, but got I4
		//IL_06cf: Expected O, but got I
		//IL_032a: Expected O, but got Ref
		//IL_02a2: Expected I, but got O
		//IL_02c2: Invalid comparison between I4 and F4
		//IL_03b1: Expected O, but got Ref
		//IL_03d3: Expected O, but got Ref
		//IL_030d: Expected F4, but got I4
		//IL_0450: Expected O, but got Ref
		//IL_070c: Expected O, but got I
		//IL_076f: Expected O, but got I
		//IL_04c8: Expected O, but got Ref
		//IL_04fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0503: Expected O, but got Unknown
		//IL_050c: Invalid comparison between O and F4
		//IL_01df: Expected I, but got O
		//IL_07c5: Expected I, but got O
		//IL_020c: Expected O, but got Ref
		//IL_0220: Expected O, but got Ref
		//IL_055f: Expected O, but got Ref
		//IL_056d: Expected O, but got Ref
		//IL_05a1: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (state == State.Sucked && (totalSuckTime += MyTime.fixedDeltaTime) > totalSuckTimeMax)
		{
			state = State.Normal;
		}
		if (!this.enemy.CanMove())
		{
			return;
		}
		if (!(MyTime.time < nextStepTime))
		{
			FindNextPosition();
		}
		Vector3 velocity = rb.velocity;
		Enemy enemy = this.enemy;
		EnemyData enemyData = enemy._003CenemyData_003Ek__BackingField;
		if (enemyData.isFlying)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Actors.Enemies.EnemyMovementRb)+44]");
			float num = 0f;
			if (flyingKnockupVel > 0f)
			{
				num += flyingKnockupVel;
				float num2 = Physics.gravity.y * MyTime.fixedDeltaTime;
				float num3 = num2 + flyingKnockupVel;
				flyingKnockupVel = num3;
			}
		}
		else
		{
			float num = velocity.y;
		}
		float num4 = TryClimbWall();
		if (isClimbing)
		{
			float num = num4;
		}
		if (!(nextGroundedCheckTime > MyTime.time))
		{
			Enemy enemy2 = this.enemy;
			EnemyData enemyData2 = enemy2._003CenemyData_003Ek__BackingField;
			if (!enemyData2.isFlying)
			{
				float num5 = MyTime.time + randomGroundedCheckOffset;
				float num6 = num5 + groundCheckInterval;
				nextGroundedCheckTime = num6;
				Vector3 groundCheckPosition = this.enemy.GetGroundCheckPosition();
				GameManager instance = GameManager.Instance;
				nint num7 = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1028 @ rax_v51 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
				Vector3 direction = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
				_ = Vector3.downVector;
				Vector3 origin = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1030 @ rcx_v46 (Il2CppStaticFields<UnityEngine.Vector3>)+2C]");
				_ = 0;
				_ = groundCheckPosition.x;
				_ = groundCheckPosition.z;
				int layerMask = default(int);
				bool flag = Physics.Raycast(origin, direction, 1.5f, layerMask);
				bool flag2 = !flag;
				bool flag3 = !flag2;
				_003Cgrounded_003Ek__BackingField = flag3;
			}
			else
			{
				_003Cgrounded_003Ek__BackingField = false;
			}
		}
		_ = knockbackVelocity;
		nint num9 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v769 @ rdx_v9 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num10 = 0;
		_ = Vector3.zeroVector;
		object obj3 = knockbackVelocity - Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-45]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-55]");
		object obj4 = num11 - 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Actors.Enemies.EnemyMovementRb)+68]");
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v770 @ rax_v19 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		object obj5 = num12 - 0;
		object obj6 = obj3 * obj3;
		object obj7 = obj4 * obj4;
		object obj8 = obj5 * obj5;
		object obj9 = obj6 + obj7;
		object obj10 = obj9 + obj8;
		bool flag4 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj10);
		float num13 = 9.9999994E-11f - (float)obj10;
		bool flag5 = num13 == 0f;
		bool flag6 = !flag4;
		bool flag7 = !flag5;
		object obj11 = flag7 & flag6;
		if (obj11 == null)
		{
			nint num14 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v843 @ rdx_v20 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num15 = 0;
			_ = Vector3.zeroVector;
			float num16 = MyTime.fixedDeltaTime * knockbackResetSpeed;
			if (!(0f > num16))
			{
				if (num16 > 1f)
				{
					num16 = 1f;
				}
			}
			else
			{
				num16 = 0f;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v898 @ rax_v35 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
			nint num17 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Actors.Enemies.EnemyMovementRb)+68]");
			object obj12 = num17 - 0;
			float num18 = (float)obj12 * num16;
			float num19 = num18;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Actors.Enemies.EnemyMovementRb)+68]");
			float num20 = num19 + 0f;
			Vector3 vector = default(Vector3);
			knockbackVelocity = vector;
			object obj13 = (object)knockbackVelocity * (object)knockbackVelocity;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Actors.Enemies.EnemyMovementRb)+64]");
			nint num21 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Actors.Enemies.EnemyMovementRb)+64]");
			object obj14 = num21 * 0;
			float num22 = num20 * num20;
			object obj15 = obj13 + obj14;
			float num23 = (float)obj15 + num22;
			if (!(1f < num23))
			{
				nint num24 = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1038 @ rax_v39 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num25 = 0;
				knockbackVelocity = Vector3.zeroVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v847 @ rcx_v37 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
				_ = 0;
			}
		}
		object obj16 = knockbackVelocity + desiredVelocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Actors.Enemies.EnemyMovementRb)+48]");
		nint num26 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Actors.Enemies.EnemyMovementRb)+68]");
		object obj17 = num26 + 0;
		Vector3 velocity2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
		rb.velocity = velocity2;
		if ((state == State.Normal || state == State.Charmed) && canRotate)
		{
			Quaternion rotation = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
			_ = desiredRotation;
			Vector3 vector2 = Quaternion.Internal_ToEulerRad(rotation);
			Vector3 euler = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
			float num27 = vector2.x * 57.29578f;
			float num28 = vector2.z * 57.29578f;
			float num29 = vector2.y * 57.29578f;
			Vector3 vector3 = Quaternion.Internal_MakePositive(euler);
			Quaternion rotation2 = rb.rotation;
			Quaternion rotation3 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
			_ = rotation2.x;
			Vector3 vector4 = Quaternion.Internal_ToEulerRad(rotation3);
			float num30 = vector4.x * 57.29578f;
			float num31 = vector4.y * 57.29578f;
			float num32 = vector4.z * 57.29578f;
			Vector3 euler2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
			Vector3 vector5 = Quaternion.Internal_MakePositive(euler2);
			float num33 = vector3.y - vector5.y;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
			object obj18 = num33 & 0;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj18) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)8f))
			{
				Quaternion rotation4 = rb.rotation;
				float deltaTime = Time.deltaTime;
				float t = deltaTime * rotationSpeed;
				Quaternion b = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
				Quaternion a = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
				_ = desiredRotation;
				_ = rotation4.x;
				Quaternion quaternion = Quaternion.Lerp(a, b, t);
				Quaternion rot = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
				_ = quaternion.x;
				rb.MoveRotation(rot);
			}
		}
	}

	private unsafe float TryClimbWall()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0465: Expected F4, but got I4
		//IL_021c: Expected F4, but got I4
		//IL_0089: Expected O, but got Ref
		//IL_02ab: Expected O, but got Ref
		//IL_0160: Expected O, but got Ref
		//IL_0160: Expected O, but got Ref
		//IL_0211: Expected F4, but got I4
		//IL_0372: Expected F4, but got I4
		//IL_0372: Expected O, but got Ref
		//IL_0372: Expected O, but got Ref
		//IL_039d: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		_ = 0;
		bool flag = isClimbing;
		float num = 0f;
		if (!flag)
		{
			if (nextClimbCheckTime > MyTime.time)
			{
				return 0f;
			}
			float num2 = MyTime.time + 1f;
			num = num2 + randomOffset;
			nextClimbCheckTime = num;
		}
		if ((object)this.enemy != null)
		{
			bool flag2 = this.enemy.IsImportantEnemy();
			Enemy enemy = this.enemy;
			if ((object)this.enemy != null)
			{
				float num3 = default(float);
				object obj3 = default(object);
				int num4 = default(int);
				if (!flag2)
				{
					Vector3 bottomPosition = this.enemy.GetBottomPosition();
					Vector3 targetPosition = GetTargetPosition();
					bool flag3 = (object)this.enemy == null;
					num = 0.1f;
					if (!flag3)
					{
						Vector3 centerPosition = this.enemy.GetCenterPosition();
						Vector3 vector = VectorExtensions.XZVector((Vector3)(&num3));
						Enemy enemy2 = this.enemy;
						bool flag4 = (object)this.enemy == null;
						num = 0.1f;
						if (!flag4)
						{
							bool flag5 = (object)enemy2.collider == null;
							num = 0.1f;
							if (!flag5)
							{
								num = enemy2.collider.radius;
								GameManager instance = GameManager.Instance;
								if ((object)GameManager.Instance != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
									float maxDistance = num + 1f;
									if (!Physics.Raycast((Vector3)(&num3), (Vector3)(&obj3), out var hitInfo, maxDistance, num4))
									{
										goto IL_01fd;
									}
									Collider collider = hitInfo.collider;
									if ((object)collider != null)
									{
										GameObject gameObject = collider.gameObject;
										if ((object)gameObject != null)
										{
											if (gameObject.CompareTag(ignoreTag))
											{
												goto IL_01fd;
											}
											goto IL_0412;
										}
									}
								}
							}
						}
					}
				}
				else if ((object)enemy.collider != null)
				{
					num = enemy.collider.radius;
					if ((object)this.enemy != null)
					{
						float radius = num * 0.75f;
						Vector3 bottomPosition2 = this.enemy.GetBottomPosition();
						Vector3 targetPosition2 = GetTargetPosition();
						if ((object)this.enemy != null)
						{
							Vector3 centerPosition2 = this.enemy.GetCenterPosition();
							Vector3 vector2 = VectorExtensions.XZVector((Vector3)(&num3));
							Enemy enemy3 = this.enemy;
							if ((object)this.enemy != null && (object)enemy3.collider != null)
							{
								num = enemy3.collider.radius;
								GameManager instance2 = GameManager.Instance;
								if ((object)GameManager.Instance != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
									int layerMask = default(int);
									if (!Physics.SphereCast((Vector3)(&num3), radius, (Vector3)(&obj3), out System.Runtime.CompilerServices.Unsafe.As<object, RaycastHit>(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112)), num4, layerMask))
									{
										goto IL_01fd;
									}
									RaycastHit raycastHit = (RaycastHit)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
									Collider collider2 = ((RaycastHit*)raycastHit)->collider;
									if ((object)collider2 != null)
									{
										GameObject gameObject2 = collider2.gameObject;
										if ((object)gameObject2 != null)
										{
											if (gameObject2.CompareTag(ignoreTag))
											{
												goto IL_01fd;
											}
											goto IL_0412;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_01fd:
		isClimbing = false;
		return 0f;
		IL_0412:
		isClimbing = true;
		return 8f;
	}

	private unsafe void CheckGrounded()
	{
		//IL_0089: Expected O, but got Ref
		//IL_0089: Expected O, but got Ref
		if (!(nextGroundedCheckTime > MyTime.time))
		{
			Enemy enemy = this.enemy;
			EnemyData enemyData = enemy._003CenemyData_003Ek__BackingField;
			if (!enemyData.isFlying)
			{
				float num = MyTime.time + randomGroundedCheckOffset;
				float num2 = num + groundCheckInterval;
				nextGroundedCheckTime = num2;
				Vector3 groundCheckPosition = this.enemy.GetGroundCheckPosition();
				GameManager instance = GameManager.Instance;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
				object obj = default(object);
				object obj2 = default(object);
				int layerMask = default(int);
				bool flag = Physics.Raycast((Vector3)(&obj), (Vector3)(&obj2), 1.5f, layerMask);
				bool flag2 = !flag;
				bool flag3 = !flag2;
				_003Cgrounded_003Ek__BackingField = flag3;
			}
			else
			{
				_003Cgrounded_003Ek__BackingField = false;
			}
		}
	}

	private unsafe Vector3 GetTargetPosition()
	{
		//IL_02bb: Expected native int or pointer, but got O
		//IL_02cd: Expected native int or pointer, but got O
		//IL_00e7: Expected native int or pointer, but got O
		//IL_00f9: Expected native int or pointer, but got O
		//IL_026e: Expected native int or pointer, but got O
		//IL_027b: Expected native int or pointer, but got O
		//IL_0288: Expected native int or pointer, but got O
		Transform transform;
		Vector3 vector = default(Vector3);
		if (state != State.Sucked)
		{
			if ((object)this.enemy != null)
			{
				if (!this.enemy.IsRunningFromPlayer())
				{
					Enemy enemy = this.enemy;
					if ((object)this.enemy != null)
					{
						if (enemy.state == EEnemyState.FollowTarget)
						{
							transform = enemy._003CfollowTarget_003Ek__BackingField;
							goto IL_02ea;
						}
						if ((object)enemy._003Ctarget_003Ek__BackingField != null)
						{
							Vector3 position = enemy._003Ctarget_003Ek__BackingField.position;
							((Vector3*)(nint)vector)->x = position.x;
							((Vector3*)(nint)vector)->z = position.z;
							goto IL_02e5;
						}
					}
				}
				else
				{
					Transform transform2 = base.transform;
					if ((object)transform2 != null)
					{
						Vector3 position2 = transform2.position;
						Enemy enemy2 = this.enemy;
						if ((object)this.enemy != null && (object)enemy2._003Ctarget_003Ek__BackingField != null)
						{
							Vector3 position3 = enemy2._003Ctarget_003Ek__BackingField.position;
							float num = position2.x - position3.x;
							float num2 = position2.y - position3.y;
							float num3 = position2.z - position3.z;
							Transform transform3 = base.transform;
							if ((object)transform3 != null)
							{
								Vector3 position4 = transform3.position;
								float x = num + position4.x;
								float y = num2 + position4.y;
								float z = num3 + position4.z;
								((Vector3*)(nint)vector)->x = x;
								((Vector3*)(nint)vector)->y = y;
								((Vector3*)(nint)vector)->z = z;
								goto IL_02e5;
							}
						}
					}
				}
			}
			goto IL_02d7;
		}
		transform = suckTarget;
		goto IL_02ea;
		IL_02e5:
		return vector;
		IL_02ea:
		if ((object)transform == null)
		{
			goto IL_02d7;
		}
		Vector3 position5 = transform.position;
		((Vector3*)(nint)vector)->x = position5.x;
		((Vector3*)(nint)vector)->z = position5.z;
		goto IL_02e5;
		IL_02d7:
		return (Vector3)new NullReferenceException();
	}

	public unsafe void DashStart(Vector3 dir, float dashTime, float dashSpeed)
	{
		//IL_0029: Expected O, but got Ref
		//IL_00a1: Expected O, but got Ref
		//IL_0072: Expected O, but got Ref
		rb.isKinematic = false;
		this.dashSpeed = dashSpeed;
		float num = default(float);
		Vector3 vector = VectorExtensions.XZVector((Vector3)(&num));
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		object obj = default(object);
		dashDirection = (Vector3)obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rax_v8+8]");
		_ = 0;
		dashing = true;
		float num2 = dashTime + MyTime.time;
		dashStopTime = num2;
		Quaternion quaternion = Quaternion.LookRotation((Vector3)(&num));
		object obj2 = default(object);
		rb.MoveRotation((Quaternion)(&obj2));
		isDashingWall = false;
	}

	public unsafe void SetDashDirection(Vector3 dir)
	{
		//IL_000a: Expected O, but got Ref
		//IL_0022: Expected O, but got Ref
		float num = default(float);
		Quaternion quaternion = Quaternion.LookRotation((Vector3)(&num));
		rb.MoveRotation((Quaternion)(&num));
	}

	private unsafe void Dashing()
	{
		//IL_0008: Expected O, but got Ref
		//IL_007f: Expected O, but got Ref
		//IL_00f5: Expected O, but got Ref
		//IL_0299: Expected O, but got Ref
		//IL_0184: Expected O, but got Ref
		//IL_01af: Expected O, but got Ref
		//IL_0319: Expected O, but got I
		//IL_0336: Expected O, but got I
		//IL_0362: Invalid comparison between F4 and O
		//IL_01dc: Expected O, but got I
		//IL_0208: Expected O, but got I
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Expected O, but got Unknown
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		_ = 0;
		Vector3 velocity = rb.velocity;
		Enemy enemy = this.enemy;
		float radius = enemy.collider.radius;
		float radius2 = radius * 0.75f;
		Vector3 bottomPosition = this.enemy.GetBottomPosition();
		Vector3 targetPosition = GetTargetPosition();
		Vector3 centerPosition = this.enemy.GetCenterPosition();
		float num = default(float);
		Vector3 vector = VectorExtensions.XZVector((Vector3)(&num));
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		Enemy enemy2 = this.enemy;
		float radius3 = enemy2.collider.radius;
		GameManager instance = GameManager.Instance;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
		float maxDistance = radius3 + 1f;
		float num2 = default(float);
		int layerMask = default(int);
		if (!(isDashingWall = ((Physics.SphereCast((Ray)(&num2), radius2, maxDistance, layerMask) || isDashingWall) ? true : false)))
		{
			Transform transform = base.transform;
			Vector3 position = transform.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
			GameManager instance2 = GameManager.Instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
			int layerMask2 = default(int);
			if (Physics.Raycast((Ray)(&num2), out System.Runtime.CompilerServices.Unsafe.As<object, RaycastHit>(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128)), 1000f, layerMask2))
			{
				object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182268200");
				object obj5 = default(object);
				object obj4 = obj5 * obj5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v602 @ rax_v33+4]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v602 @ rax_v33+4]");
				object obj6 = num3 * 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v602 @ rax_v33+8]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v602 @ rax_v33+8]");
				object obj7 = num4 * 0;
				object obj8 = obj6 + obj4;
				float epsilon = Mathf.Epsilon;
				object obj9 = obj8 + obj7;
				bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj9);
				float num5 = 1000f;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Actors.Enemies.EnemyMovementRb)+A4]");
					nint num6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v602 @ rax_v33+4]");
					object obj10 = num6 * 0;
					object obj11 = (object)dashDirection * obj5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Actors.Enemies.EnemyMovementRb)+A8]");
					nint num7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v602 @ rax_v33+8]");
					object obj12 = num7 * 0;
					object obj13 = obj10 + obj11;
					object obj14 = obj13 + obj12;
					object obj15 = obj14 * obj5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v602 @ rax_v33+4]");
					object obj16 = obj14 * 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v602 @ rax_v33+8]");
					object obj17 = obj14 * 0;
					epsilon = (float)obj15 / (float)obj9;
					obj7 = obj16 / obj9;
					num5 = (float)obj17 / (float)obj9;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
				object obj18 = default(object);
				dashDirection = (Vector3)obj18;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v518 @ rax_v36+8]");
				_ = 0;
			}
		}
		rb.velocity = (Vector3)(&num);
	}

	public void StopDash()
	{
		dashing = false;
	}

	public void StopMovement()
	{
		rb.isKinematic = true;
	}

	public void StartMovement()
	{
		rb.isKinematic = false;
	}

	private void SetVelocity(Vector3 vel)
	{
		//IL_0112: Expected I, but got O
		//IL_013b: Expected F4, but got I
		//IL_006b: Expected O, but got F4
		Enemy enemy = this.enemy;
		Vector3 vector = default(Vector3);
		Vector3 vector2;
		if (!((Dictionary<System.Int32Enum, object>)(object)enemy.debuffs).ContainsKey((System.Int32Enum)8))
		{
			Enemy enemy2 = this.enemy;
			if (((Dictionary<System.Int32Enum, object>)(object)enemy2.debuffs).ContainsKey((System.Int32Enum)2))
			{
				float num = vel.z * DebuffIce.slowMultiplier;
				desiredVelocity = vector;
				goto IL_014f;
			}
			vector2 = (Vector3)vel.x;
			float z = vel.z;
		}
		else
		{
			nint num2 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rax_v26 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num3 = 0;
			vector2 = Vector3.zeroVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rcx_v18 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
			float z = 0f;
		}
		desiredVelocity = vector2;
		goto IL_014f;
		IL_014f:
		baseVelocity = desiredVelocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Actors.Enemies.EnemyMovementRb)+48]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Actors.Enemies.EnemyMovementRb)+C8]");
		float num4 = 0f * MyTime._003CtimeScale_003Ek__BackingField;
		desiredVelocity = vector;
		float num5 = MyTime._003CtimeScale_003Ek__BackingField * 10f;
		rotationSpeed = num5;
	}

	private void TimescaleVelocity()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Actors.Enemies.EnemyMovementRb)+C8]");
		float num = 0f * MyTime._003CtimeScale_003Ek__BackingField;
		Vector3 vector = default(Vector3);
		desiredVelocity = vector;
		float num2 = MyTime._003CtimeScale_003Ek__BackingField * 10f;
		rotationSpeed = num2;
	}

	public void FindNextPosition()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_0546: Expected I, but got O
		//IL_05a0: Invalid comparison between F4 and I4
		//IL_00fd: Invalid comparison between F4 and I4
		//IL_0272: Invalid comparison between F4 and I
		//IL_024b: Expected F4, but got I4
		//IL_011b: Invalid comparison between F4 and I4
		//IL_0299: Expected F4, but got I
		//IL_0139: Invalid comparison between F4 and I4
		//IL_07cb: Expected I, but got O
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Expected O, but got Unknown
		//IL_0157: Invalid comparison between F4 and I4
		//IL_072d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0732: Expected O, but got Unknown
		//IL_073b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0740: Expected O, but got Unknown
		//IL_076c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0771: Expected O, but got Unknown
		//IL_0474: Unknown result type (might be due to invalid IL or missing references)
		//IL_0479: Expected O, but got Unknown
		//IL_082c: Expected I, but got O
		//IL_0859: Expected O, but got I
		//IL_0912: Expected F4, but got O
		//IL_04bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c1: Expected O, but got Unknown
		//IL_08fa: Expected O, but got F4
		object obj2 = default(object);
		object obj = obj2 - 95;
		Vector3 targetPosition = GetTargetPosition();
		Transform transform = base.transform;
		Vector3 position = transform.position;
		nint num = (nint)typeof(Math);
		float num2 = targetPosition.x - position.x;
		float num3 = targetPosition.y - position.y;
		float num4 = targetPosition.z - position.z;
		float num5 = num3 * num3;
		float num6 = num2 * num2;
		float num7 = num4 * num4;
		float num8 = num5 + num6;
		float num9 = num8 + num7;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ rcx_v7 (Il2CppClass<System.Math>)+E4]");
		if ((nint)0 <= (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
		}
		else
		{
			double num10 = Math.Sqrt(num9);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm7,xmm0\"");
		distanceToTarget = 0f;
		float num11 = ((20f > 0f || MyTime.finalSwarmTimer > 60f) ? MyTime.time : ((40f > 0f) ? (MyTime.time + 0.2f) : ((80f > 0f) ? (MyTime.time + 0.5f) : ((150f > 0f) ? (MyTime.time + 1f) : ((300f > 0f) ? (MyTime.time + 3f) : (MyTime.time + 5f))))));
		nextStepTime = num11;
		bool flag = 20f > distanceToTarget;
		float num12 = 0.5f;
		if (!flag)
		{
			num12 = ((40f > distanceToTarget) ? 0.8f : ((80f > distanceToTarget) ? 1.5f : ((150f > distanceToTarget) ? 2.5f : ((!(300f > distanceToTarget)) ? (MyTime.time + 5f) : 4f))));
		}
		groundCheckInterval = num12;
		float num13;
		if (20f > distanceToTarget)
		{
			num13 = 0f;
		}
		else
		{
			num13 = distanceToTarget * 0.4f;
			float num14 = num13;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ECD0]");
			if (num14 > 0f)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ECD0]");
				num13 = 0f;
			}
		}
		Vector3 targetPosition2 = GetTargetPosition();
		float num15 = num13 * (float)offsetBias;
		float num16 = num13;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Actors.Enemies.EnemyMovementRb)+38]");
		float num17 = num16 * 0f;
		float num18 = num13;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Actors.Enemies.EnemyMovementRb)+3C]");
		float num19 = num18 * 0f;
		float num20 = num15 + targetPosition2.x;
		float num21 = num17 + targetPosition2.y;
		float num22 = num19 + targetPosition2.z;
		Enemy enemy = this.enemy;
		EnemyData enemyData = enemy._003CenemyData_003Ek__BackingField;
		if (!enemyData.isFlying)
		{
			Vector3 position2 = rb.position;
			Vector3 v = (Vector3)(obj - 57);
			float num23 = num20 - position2.x;
			float num24 = num21 - position2.y;
			float num25 = num22 - position2.z;
			Vector3 vector = VectorExtensions.XZVector(v);
			num11 = vector.x;
			_ = vector.x;
			_ = vector.z;
		}
		else
		{
			num20 += (float)flyingOffset;
			float num26 = num21;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Actors.Enemies.EnemyMovementRb)+D4]");
			num21 = num26 + 0f;
			float num27 = num22;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Actors.Enemies.EnemyMovementRb)+D8]");
			num22 = num27 + 0f;
			nint num28 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ rax_v34 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num29 = 0;
			float num30 = num20 + (float)Vector3.upVector;
			float num31 = num21;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rcx_v30 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
			float num32 = num31 + 0f;
			float num33 = num22;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rcx_v30 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
			float num34 = num33 + 0f;
			Vector3 position3 = rb.position;
			float num35 = num30 - position3.x;
			float num36 = num32 - position3.y;
			float num37 = num34 - position3.z;
			float num24 = num9;
		}
		object obj3 = obj - 57;
		object obj4 = obj - 41;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		float speed = GetSpeed();
		object obj5 = default(object);
		float num38 = (float)obj5 * speed;
		Vector3 velocity = (Vector3)(obj - 57);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v797 @ rax_v18+4]");
		float num39 = 0f * speed;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v797 @ rax_v18+8]");
		float num40 = 0f * speed;
		SetVelocity(velocity);
		Vector3 centerPosition = this.enemy.GetCenterPosition();
		float num41 = num20 - centerPosition.x;
		float num42 = num21 - centerPosition.y;
		float num43 = num22 - centerPosition.z;
		Vector3 v2 = (Vector3)(obj - 57);
		Vector3 vector2 = VectorExtensions.XZVector(v2);
		_ = vector2.x;
		nint num44 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v829 @ rax_v23 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num45 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-35]");
		nint num46 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v830 @ rcx_v21 (Il2CppStaticFields<UnityEngine.Vector3>)+4]");
		object obj6 = num46 - 0;
		float num47 = vector2.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v830 @ rcx_v21 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		float num48 = num47 - 0f;
		float num49 = vector2.x - (float)Vector3.zeroVector;
		object obj7 = obj6 * obj6;
		float num50 = num49 * num49;
		float num51 = num48 * num48;
		float num52 = (float)obj7 + num50;
		float num53 = num52 + num51;
		float num54;
		if (!(9.9999994E-11f > num53))
		{
			_ = vector2.x;
			Vector3 forward = (Vector3)(obj - 57);
			_ = vector2.z;
			num54 = Quaternion.LookRotation(forward).x;
		}
		else
		{
			num54 = (float)Quaternion.identityQuaternion;
		}
		desiredRotation = (Quaternion)num54;
		Enemy enemy2 = this.enemy;
		bool flag2 = ((Dictionary<System.Int32Enum, object>)(object)enemy2.debuffs).ContainsKey((System.Int32Enum)8);
		bool flag3 = (byte)((flag2 ? 1u : 0u) ^ 1u) != 0;
		canRotate = flag3;
	}

	public unsafe void SetDesiredRotation(Vector3 targetPos)
	{
		//IL_0019: Expected O, but got Ref
		//IL_002b: Expected O, but got Ref
		//IL_003e: Expected O, but got F4
		//IL_0052: Expected O, but got Ref
		Vector3 centerPosition = enemy.GetCenterPosition();
		float num = default(float);
		Vector3 vector = VectorExtensions.XZVector((Vector3)(&num));
		desiredRotation = (Quaternion)Quaternion.LookRotation((Vector3)(&num)).x;
		float num2 = default(float);
		rb.MoveRotation((Quaternion)(&num2));
	}

	private float GetSpeed()
	{
		//IL_003a: Invalid comparison between F4 and I
		//IL_0061: Expected F4, but got I
		if (!(MyTime.time < nextGetSpeedTime))
		{
			float num = MyTime.time + getSpeedCooldown;
			nextGetSpeedTime = num;
			float speed = enemy.GetSpeed();
			storedSpeed = speed;
		}
		float result = storedSpeed;
		if (state == State.Sucked)
		{
			float num2 = storedSpeed;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ECC8]");
			if (num2 > 0f)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ECC8]");
				result = 0f;
			}
		}
		return result;
	}

	public void MyUpdate()
	{
	}

	public void Pause(bool isPaused)
	{
		if (!isPaused)
		{
			rb.constraints = RigidbodyConstraints.FreezeRotation;
		}
		else
		{
			rb.constraints = RigidbodyConstraints.FreezeAll;
		}
	}

	public unsafe void KnockUp(float knockbackForce)
	{
		//IL_00b2: Invalid comparison between I4 and F4
		//IL_00ec: Invalid comparison between I4 and F4
		//IL_018e: Expected O, but got Ref
		if (rb.isKinematic)
		{
			return;
		}
		Enemy enemy = this.enemy;
		EnemyData enemyData = enemy._003CenemyData_003Ek__BackingField;
		if (enemyData.nukeProtection)
		{
			return;
		}
		float num = knockbackForce + 1f;
		float num2 = EnemyStats.GetKnockbackResistance(enemy);
		float num3 = num2 * 0.5f;
		float num4 = num - num3;
		if (0f > num4 || (!(num4 > 10f) && !(0f < num4)))
		{
			return;
		}
		float num5 = knockbackForce * knockbackConstant;
		float num6 = num5 * 0.5f;
		bool flag = !(20f > num6);
		float num7 = 20f;
		if (!flag)
		{
			num7 = num6;
		}
		if (20f == num6)
		{
			if (!rb.isKinematic)
			{
				Vector3 velocity = rb.velocity;
				Vector3 velocity2 = rb.velocity;
				float num8 = default(float);
				rb.velocity = (Vector3)(&num8);
			}
		}
		else
		{
			flyingKnockupVel = num7;
		}
	}

	public unsafe void Knockback(DamageContainer dc)
	{
		//IL_002b: Invalid comparison between I4 and F4
		//IL_0055: Expected O, but got Ref
		if (!rb.isKinematic && 0f < dc.knockback)
		{
			object obj = default(object);
			Knockback((Vector3)(&obj), dc.knockback);
		}
	}

	public void Knockback(Vector3 dir, float knockback)
	{
		//IL_0176: Invalid comparison between I4 and F4
		//IL_01ac: Invalid comparison between I4 and F4
		//IL_01d9: Invalid comparison between I4 and F4
		//IL_00fb: Expected O, but got I
		float num2 = default(float);
		float num = num2 + 1f;
		if (!(0f < num))
		{
			return;
		}
		float num3 = ((!isBoss) ? 5f : 2.25f);
		float time = MyTime.time;
		if (MyTime.time > lastFoundKnockbackResTime)
		{
			lastFoundKnockbackResTime = MyTime.fixedDeltaTime;
			time = EnemyStats.GetKnockbackResistance(enemy);
			knockbackResistance = time;
		}
		float num4 = num - knockbackResistance;
		if (0f > num4)
		{
			return;
		}
		if (num4 > num3)
		{
			num4 = num3;
		}
		if (!(0f < num4))
		{
			return;
		}
		if (isBoss)
		{
			object obj = (object)knockbackVelocity * (object)knockbackVelocity;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Actors.Enemies.EnemyMovementRb)+64]");
			float num5 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Actors.Enemies.EnemyMovementRb)+64]");
			time = num5 * 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Actors.Enemies.EnemyMovementRb)+68]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Actors.Enemies.EnemyMovementRb)+68]");
			object obj2 = num6 * 0;
			float num7 = (float)obj + time;
			num2 = num7 + (float)obj2;
			if (num2 > maxKnockbackVelSqrBoss)
			{
				return;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		float num8 = num4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v359 @ rax_v7+8]");
		float num9 = num8 * 0f;
		float num10 = knockbackConstant * num9;
		float num11 = num10;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Actors.Enemies.EnemyMovementRb)+68]");
		float num12 = num11 + 0f;
		Vector3 vector = default(Vector3);
		knockbackVelocity = vector;
	}

	public void Suck(Transform target)
	{
		if (state != State.Sucked && totalSuckTime < totalSuckTimeMax)
		{
			suckTarget = target;
			state = State.Sucked;
			FindNextPosition();
		}
	}

	public void StopSuck()
	{
		state = State.Normal;
	}

	private bool CanFindNextPosition()
	{
		bool flag = MyTime.time < nextStepTime;
		return !flag;
	}

	private float GetNextStepTime(float distanceToTarget)
	{
		if (!(20f > distanceToTarget) && !(MyTime.finalSwarmTimer > 60f))
		{
			if (!(40f > distanceToTarget))
			{
				if (!(80f > distanceToTarget))
				{
					if (!(150f > distanceToTarget))
					{
						if (!(300f > distanceToTarget))
						{
							return MyTime.time + 5f;
						}
						return MyTime.time + 3f;
					}
					return MyTime.time + 1f;
				}
				return MyTime.time + 0.5f;
			}
			return MyTime.time + 0.2f;
		}
		return MyTime.time;
	}

	private float GetNextGroundCheckOffset(float distanceToTarget)
	{
		if (!(20f > distanceToTarget))
		{
			if (!(40f > distanceToTarget))
			{
				if (!(80f > distanceToTarget))
				{
					if (!(150f > distanceToTarget))
					{
						if (300f > distanceToTarget)
						{
							return 4f;
						}
						return MyTime.time + 5f;
					}
					return 2.5f;
				}
				return 1.5f;
			}
			return 0.8f;
		}
		return 0.5f;
	}

	public EnemyMovementRb()
	{
		//IL_0073: Expected I, but got O
		knockbackResetSpeed = 2.5f;
		canRotate = true;
		ignoreTag = "Ignore";
		groundCheckInterval = 0.25f;
		_003Cgrounded_003Ek__BackingField = true;
		debuffs = (HashSet<EDebuff>)(object)new HashSet<System.Int32Enum>();
		rotationSpeed = 10f;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v8 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		getSpeedCooldown = 2f;
		maxKnockbackVelSqrBoss = 10.125f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rcx_v7 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
		float num3 = 0f * 1.6f;
		totalSuckTimeMax = 15f;
		Vector3 vector = default(Vector3);
		flyingOffset = vector;
		base._002Ector();
	}
}
