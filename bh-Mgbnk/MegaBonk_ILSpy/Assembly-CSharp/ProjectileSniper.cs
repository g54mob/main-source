using System;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using Assets.Scripts.Managers;
using Assets.Scripts.Objects.Pooling;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

public class ProjectileSniper : ProjectileBase
{
	public Vector3 attackDir;

	private float bulletSpeed;

	private float maxDistance;

	private float distTravelled;

	private RaycastHit hitRaycast;

	protected new static readonly RaycastHit[] raycastBuffer;

	protected unsafe override bool TryInit(int projectileIndex)
	{
		//IL_0008: Expected O, but got Ref
		//IL_02c9: Expected O, but got Ref
		//IL_02d7: Expected O, but got Ref
		//IL_029b: Expected I4, but got O
		//IL_0042: Expected O, but got Ref
		//IL_0080: Expected O, but got Ref
		//IL_00cc: Expected O, but got Ref
		//IL_0329: Expected I, but got O
		//IL_010a: Expected O, but got Ref
		//IL_01b6: Expected O, but got Ref
		//IL_01ce: Expected O, but got Ref
		//IL_0230: Expected O, but got Ref
		//IL_0259: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		_ = 0;
		Vector3 vector = GetAttackDir(projectileIndex);
		object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
		object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
		_ = vector.x;
		_ = vector.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		object obj5 = default(object);
		attackDir = (Vector3)obj5;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v4+8]");
		_ = 0;
		Transform transform = base.transform;
		Vector3 shootingPosition = GetShootingPosition();
		if ((object)transform != null)
		{
			Vector3 position = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
			_ = shootingPosition.z;
			_ = shootingPosition.x;
			transform.position = position;
			Transform transform2 = base.transform;
			Vector3 forward = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ProjectileSniper)+70]");
			_ = 0;
			_ = attackDir;
			Quaternion quaternion = Quaternion.LookRotation(forward);
			if ((object)transform2 != null)
			{
				Quaternion rotation = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
				_ = quaternion.x;
				transform2.rotation = rotation;
				Transform transform3 = base.transform;
				nint num = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rcx_v16 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num2 = 0;
				_ = Vector3.oneVector;
				float num3 = projectileRadius;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-35]");
				float num4 = num3 * 0f;
				float num5 = projectileRadius;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rdx_v11 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
				float num6 = num5 * 0f;
				float num7 = projectileRadius * (float)Vector3.oneVector;
				if ((object)transform3 != null)
				{
					Vector3 localScale = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
					transform3.localScale = localScale;
					Transform transform4 = base.transform;
					if ((object)transform4 != null)
					{
						Vector3 position2 = transform4.position;
						GameManager instance = GameManager.Instance;
						if ((object)GameManager.Instance != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
							_ = position2.x;
							ref RaycastHit hitInfo = ref System.Runtime.CompilerServices.Unsafe.As<object, RaycastHit>(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
							Vector3 vector2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
							_ = position2.z;
							Vector3 origin = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
							_ = attackDir;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ProjectileSniper)+70]");
							_ = 0;
							int layerMask = default(int);
							bool flag = Physics.Raycast(origin, vector2, out hitInfo, 999f, layerMask);
							bool flag2 = !flag;
							float num8 = 999f;
							if (!flag2)
							{
								object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18231C560");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-19]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-29]");
								hitRaycast = (RaycastHit)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-D]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+17]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-D]");
								_ = 0;
								float num9 = default(float);
								num8 = num9;
							}
							maxDistance = num8;
							distTravelled = 0f;
							Hitscan(weaponBase, projectileRadius);
							return true;
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private unsafe Vector3 GetShootingPosition()
	{
		//IL_007f: Expected I, but got O
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00c2: Expected O, but got I
		//IL_00df: Expected O, but got I
		//IL_0123: Expected native int or pointer, but got O
		//IL_0130: Expected native int or pointer, but got O
		//IL_013d: Expected native int or pointer, but got O
		if ((object)MyPlayer.Instance != null)
		{
			Transform transform = MyPlayer.Instance.transform;
			if ((object)transform != null)
			{
				Vector3 position = transform.position;
				WeaponBase weaponBase = base.weaponBase;
				if (base.weaponBase != null)
				{
					WeaponData weaponData = weaponBase.weaponData;
					if ((object)weaponBase.weaponData != null)
					{
						nint num = (nint)typeof(Vector3);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rax_v11 (Il2CppClass<UnityEngine.Vector3>)+B8]");
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdx_v4 (WeaponData)+C4]");
						object obj = 0 * Vector3.upVector;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdx_v4 (WeaponData)+C4]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rcx_v7 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
						object obj2 = num3 * 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdx_v4 (WeaponData)+C4]");
						nint num4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rcx_v7 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
						object obj3 = num4 * 0;
						float x = (float)obj + position.x;
						float y = (float)obj2 + position.y;
						float z = (float)obj3 + position.z;
						Vector3 vector = default(Vector3);
						((Vector3*)(nint)vector)->x = x;
						((Vector3*)(nint)vector)->y = y;
						((Vector3*)(nint)vector)->z = z;
						return vector;
					}
				}
			}
		}
		return (Vector3)new NullReferenceException();
	}

	private unsafe Vector3 GetAttackDir(int projectileIndex)
	{
		//IL_0008: Expected O, but got Ref
		//IL_053c: Expected native int or pointer, but got O
		//IL_054a: Expected native int or pointer, but got O
		//IL_0078: Expected native int or pointer, but got O
		//IL_008a: Expected native int or pointer, but got O
		//IL_02b8: Expected O, but got Ref
		//IL_02c4: Expected native int or pointer, but got O
		//IL_02d1: Expected native int or pointer, but got O
		//IL_0328: Expected I4, but got O
		//IL_0328: Expected O, but got Ref
		//IL_01ce: Expected O, but got Ref
		//IL_039a: Expected I4, but got O
		//IL_039a: Expected O, but got Ref
		//IL_03c5: Expected O, but got Ref
		//IL_04b2: Expected O, but got I
		//IL_0423: Expected O, but got I4
		//IL_05a6: Expected F4, but got O
		//IL_05a1: Expected native int or pointer, but got O
		//IL_05bb: Expected F4, but got I
		//IL_05b6: Expected native int or pointer, but got O
		//IL_0520: Expected O, but got I4
		//IL_0257: Expected F4, but got O
		//IL_0252: Expected native int or pointer, but got O
		//IL_026c: Expected F4, but got I
		//IL_0267: Expected native int or pointer, but got O
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = 0f;
		((Vector3*)(nint)vector)->z = 0f;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		MyPlayer instance = MyPlayer.Instance;
		if ((object)MyPlayer.Instance != null && (object)instance.playerRenderer != null)
		{
			Transform transform = instance.playerRenderer.transform;
			if ((object)transform != null)
			{
				Vector3 forward = transform.forward;
				((Vector3*)(nint)vector)->x = forward.x;
				((Vector3*)(nint)vector)->z = forward.z;
				MyPlayer instance2 = MyPlayer.Instance;
				if ((object)MyPlayer.Instance != null)
				{
					PlayerInput playerInput = instance2.playerInput;
					if ((object)instance2.playerInput != null)
					{
						float num = default(float);
						GameObject gameObject = default(GameObject);
						if (!playerInput.aiming)
						{
							Transform transform2 = base.transform;
							if ((object)transform2 != null)
							{
								Vector3 position = transform2.position;
								float weaponRange = WeaponUtility.GetWeaponRange(base.weaponBase);
								WeaponBase weaponBase = base.weaponBase;
								if (base.weaponBase != null)
								{
									WeaponData weaponData = weaponBase.weaponData;
									if ((object)weaponBase.weaponData != null)
									{
										Enemy enemy = EnemyTargeting.GetEnemy((Vector3)(&num), weaponRange, projectileIndex, weaponData.useVision, gameObject);
										if (!(enemy != null))
										{
											goto IL_056c;
										}
										if ((object)enemy != null)
										{
											Vector3 feetPosition = enemy.GetFeetPosition();
											if ((object)MyPlayer.Instance != null)
											{
												Vector3 feetPosition2 = MyPlayer.Instance.GetFeetPosition();
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
												object obj3 = default(object);
												((Vector3*)(nint)vector)->x = (float)obj3;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v741 @ rax_v65+8]");
												((Vector3*)(nint)vector)->z = 0f;
												goto IL_056c;
											}
										}
									}
								}
							}
						}
						else
						{
							Vector3 crosshairRaycastPosition = CrosshairUi.GetCrosshairRaycastPosition();
							Camera main = Camera.main;
							if ((object)main != null)
							{
								Ray ray = main.ScreenPointToRay((Vector3)(&num));
								float num2 = default(float);
								((Vector3*)(nint)vector)->x = num2;
								float z = default(float);
								((Vector3*)(nint)vector)->z = z;
								GameManager instance3 = GameManager.Instance;
								if ((object)GameManager.Instance != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
									Vector3 origin = default(Vector3);
									if (!Physics.SphereCast((Ray)(&origin), projectileRadius, out var hitInfo, 999f, (int)gameObject))
									{
										GameManager instance4 = GameManager.Instance;
										if ((object)GameManager.Instance != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
											if (!Physics.SphereCast((Ray)(&origin), projectileRadius, out System.Runtime.CompilerServices.Unsafe.As<object, RaycastHit>(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112)), 999f, (int)gameObject))
											{
												goto IL_056c;
											}
											object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822681E0");
											object obj5 = default(object);
											float num3 = (float)obj5 - GetShootingPosition().x;
											float num4 = 999f;
											origin = ray.m_Origin;
											float num5 = projectileRadius;
											num = num3;
											object obj6 = 0;
											float num6 = num2;
											goto IL_058f;
										}
									}
									else
									{
										Collider collider = hitInfo.collider;
										if ((object)EnemyManager.Instance != null)
										{
											if (!EnemyManager.Instance.GetEnemy(collider, out System.Runtime.CompilerServices.Unsafe.As<object, Enemy>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 96))))
											{
												goto IL_056c;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822681E0");
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+60]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+60]");
												Vector3 feetPosition3 = ((Enemy)0).GetFeetPosition();
												if ((object)MyPlayer.Instance != null)
												{
													Vector3 feetPosition4 = MyPlayer.Instance.GetFeetPosition();
													object obj7 = default(object);
													float num6 = (float)obj7 - feetPosition4.x;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rax_v32+8]");
													float num5 = 0f - feetPosition4.z;
													float num4 = 999f;
													origin = ray.m_Origin;
													num = num6;
													object obj6 = 0;
													goto IL_058f;
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
		}
		return (Vector3)new NullReferenceException();
		IL_058f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		object obj8 = default(object);
		((Vector3*)(nint)vector)->x = (float)obj8;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v764 @ rax_v25+8]");
		((Vector3*)(nint)vector)->z = 0f;
		goto IL_056c;
		IL_056c:
		return vector;
	}

	protected unsafe override Vector3 GetMovementDirection()
	{
		//IL_000f: Expected F4, but got O
		//IL_000a: Expected native int or pointer, but got O
		//IL_0024: Expected F4, but got I
		//IL_001f: Expected native int or pointer, but got O
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = (float)attackDir;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (ProjectileSniper)+70]");
		((Vector3*)(nint)vector)->z = 0f;
		return vector;
	}

	protected override void MyFixedUpdate()
	{
	}

	protected unsafe override void MyUpdate()
	{
		//IL_0036: Expected O, but got Ref
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected O, but got Unknown
		//IL_0107: Expected O, but got Ref
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected O, but got Unknown
		//IL_0137: Expected O, but got Ref
		//IL_014d: Expected O, but got Ref
		if (!(distTravelled < maxDistance))
		{
			return;
		}
		Transform transform = base.transform;
		float num = MyTime.deltaTime * bulletSpeed;
		Vector3 position = transform.position;
		float num2 = default(float);
		transform.position = (Vector3)(&num2);
		if (!((distTravelled = num + distTravelled) < maxDistance))
		{
			PoolManager instance = PoolManager.Instance;
			GameObject gameObject = instance.bulletHitPool.Get();
			if (gameObject != null)
			{
				Transform transform2 = gameObject.transform;
				object obj = this + 128;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822681E0");
				object obj2 = this + 128;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182268200");
				transform2.position = (Vector3)(&num2);
				Transform transform3 = gameObject.transform;
				object obj3 = this + 128;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182268200");
				Quaternion quaternion = Quaternion.LookRotation((Vector3)(&num2));
				object obj4 = default(object);
				transform3.rotation = (Quaternion)(&obj4);
			}
		}
	}

	protected override void FindMovementDirection()
	{
	}

	public unsafe void Hitscan(WeaponBase weaponBase, float radius)
	{
		//IL_0008: Expected O, but got Ref
		//IL_004f: Expected O, but got Ref
		//IL_004f: Expected O, but got Ref
		//IL_0093: Expected O, but got I4
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected O, but got Unknown
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Expected O, but got Unknown
		//IL_015e: Expected O, but got Ref
		//IL_0189: Expected O, but got Ref
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Expected O, but got Unknown
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Expected O, but got Unknown
		//IL_020a: Expected O, but got Ref
		//IL_024e: Expected O, but got Ref
		//IL_027e: Expected I4, but got F4
		//IL_027e: Expected O, but got Ref
		//IL_0286: Expected F4, but got O
		//IL_028e: Expected O, but got F4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Transform transform = base.transform;
		Vector3 position = transform.position;
		GameManager instance = GameManager.Instance;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
		float num2 = default(float);
		Vector3 vector = default(Vector3);
		float num3 = default(float);
		int layerMask = default(int);
		int num = Physics.SphereCastNonAlloc((Vector3)(&num2), radius, (Vector3)(&vector), raycastBuffer, num3, layerMask);
		if (num <= 0)
		{
			return;
		}
		num2 = position.x;
		vector = attackDir;
		object obj3 = 0;
		float num5 = default(float);
		object obj9 = default(object);
		do
		{
			object obj4 = raycastBuffer + 32;
			object obj5 = obj3 * 44;
			RaycastHit raycastHit = (RaycastHit)(obj5 + obj4);
			Collider collider = ((RaycastHit*)raycastHit)->collider;
			if (EnemyManager.Instance.GetEnemy(collider, out var enemy))
			{
				Vector3 centerPosition = enemy.GetCenterPosition();
				Transform transform2 = MyPlayer.Instance.transform;
				Vector3 position2 = transform2.position;
				float num4 = centerPosition.x - position2.x;
				object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 64));
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
				DamageContainer damageContainer = WeaponUtility.GetDamageContainer(weaponBase, this, enemy, (Vector3)(&num2), num3);
				enemy.DamageFromPlayerWeapon(damageContainer);
				object obj7 = raycastBuffer + 32;
				object obj8 = obj3 * 44;
				RaycastHit raycastHit2 = (RaycastHit)(obj8 + obj7);
				Collider collider2 = ((RaycastHit*)raycastHit2)->collider;
				Transform transform3 = base.transform;
				Vector3 position3 = transform3.position;
				Vector3 position4 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
				_ = position3.x;
				_ = position3.z;
				Vector3 vector2 = collider2.ClosestPoint(position4);
				Vector3 movementDirection = GetMovementDirection();
				Vector3 moveDir = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
				_ = movementDirection.x;
				_ = movementDirection.z;
				weaponAttack.ProjectileHit((Vector3)(&num5), moveDir, hitEnemy: true, (byte)(int)num3 != 0);
				num2 = (float)obj9;
				vector = (Vector3)num4;
			}
			obj3++;
		}
		while ((nint)obj3 < num);
	}

	protected override bool CheckCollision(Collider collider, Vector3 normal)
	{
		return false;
	}

	protected override void StepMovement()
	{
	}

	protected override void CheckSpawnCollision()
	{
	}

	public ProjectileSniper()
	{
		//IL_001f: Expected I, but got O
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v3 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		attackDir = Vector3.forwardVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector3>)+50]");
		_ = 0;
		bulletSpeed = 800f;
		base._002Ector();
	}

	static ProjectileSniper()
	{
		//IL_0019: Expected O, but got I4
		object obj = EnemyManager.maxNumEnemiesPooled + 1;
		RaycastHit[] array = new RaycastHit[obj];
		raycastBuffer = array;
	}
}
