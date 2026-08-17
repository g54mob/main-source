using System;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors.Enemies;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;

public class ProjectileBasic : ProjectileBase
{
	protected GameObject currentTarget;

	protected override bool TryInit(int projectileIndex)
	{
		//IL_0419: Expected I4, but got O
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Expected O, but got Unknown
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_0455: Expected I, but got O
		//IL_0496: Expected O, but got I
		//IL_04b3: Expected O, but got I
		//IL_04fd: Invalid comparison between F4 and O
		//IL_051c: Invalid comparison between F4 and I4
		//IL_0545: Expected O, but got I4
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Expected O, but got Unknown
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Expected O, but got Unknown
		//IL_0344: Unknown result type (might be due to invalid IL or missing references)
		//IL_0349: Expected O, but got Unknown
		//IL_035e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0363: Expected O, but got Unknown
		//IL_0378: Unknown result type (might be due to invalid IL or missing references)
		//IL_037d: Expected O, but got Unknown
		//IL_0392: Unknown result type (might be due to invalid IL or missing references)
		//IL_0397: Expected O, but got Unknown
		currentTarget = null;
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			Vector3 position = transform.position;
			float weaponRange = WeaponUtility.GetWeaponRange(base.weaponBase);
			WeaponBase weaponBase = base.weaponBase;
			if (base.weaponBase != null)
			{
				WeaponData weaponData = weaponBase.weaponData;
				if ((object)weaponBase.weaponData != null)
				{
					object obj = default(object);
					Vector3 position2 = (Vector3)(obj - 80);
					_ = position.x;
					_ = position.z;
					GameObject exceptObject = default(GameObject);
					Enemy enemy = EnemyTargeting.GetEnemy(position2, weaponRange, projectileIndex, weaponData.useVision, exceptObject);
					if (!(enemy != null))
					{
						return false;
					}
					if ((object)enemy != null)
					{
						Vector3 centerPosition = enemy.GetCenterPosition();
						Transform transform2 = base.transform;
						if ((object)transform2 != null)
						{
							Vector3 position3 = transform2.position;
							float num = centerPosition.x - position3.x;
							float num2 = centerPosition.y - position3.y;
							float num3 = centerPosition.z - position3.z;
							object obj2 = obj - 80;
							object obj3 = obj - 64;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
							object obj4 = default(object);
							direction = (Vector3)obj4;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v387 @ rax_v19+8]");
							_ = 0;
							nint num4 = (nint)typeof(Vector3);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v405 @ rax_v21 (Il2CppClass<UnityEngine.Vector3>)+B8]");
							nint num5 = 0;
							_ = Vector3.zeroVector;
							object obj5 = obj4 - (object)Vector3.zeroVector;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-4C]");
							nint num6 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-3C]");
							object obj6 = num6 - 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v387 @ rax_v19+8]");
							nint num7 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rcx_v18 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
							object obj7 = num7 - 0;
							object obj8 = obj6 * obj6;
							object obj9 = obj5 * obj5;
							object obj10 = obj7 * obj7;
							object obj11 = obj8 + obj9;
							object obj12 = obj11 + obj10;
							bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj12);
							float num8 = 9.9999994E-11f - (float)obj12;
							bool flag2 = num8 == 0f;
							bool flag3 = !flag;
							bool flag4 = !flag2;
							object obj13 = flag4 & flag3;
							if (obj13 == null)
							{
								Transform transform3 = base.transform;
								Vector3 forward = (Vector3)(obj - 80);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles.ProjectileBasic)+40]");
								_ = 0;
								_ = direction;
								Quaternion quaternion = Quaternion.LookRotation(forward);
								if ((object)transform3 == null)
								{
									goto IL_040b;
								}
								Quaternion rotation = (Quaternion)(obj - 64);
								_ = quaternion.x;
								transform3.rotation = rotation;
							}
							Transform transform4 = base.transform;
							if ((object)transform4 != null)
							{
								Vector3 position4 = transform4.position;
								Transform transform5 = base.transform;
								if ((object)transform5 != null)
								{
									Vector3 forward2 = transform5.forward;
									WeaponBase weaponBase2 = base.weaponBase;
									if (base.weaponBase != null)
									{
										WeaponData weaponData2 = weaponBase2.weaponData;
										if ((object)weaponBase2.weaponData != null)
										{
											Vector3 position5 = (Vector3)(obj - 80);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rcx_v25 (WeaponData)+C8]");
											object obj14 = 0 * forward2.x;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rcx_v25 (WeaponData)+C8]");
											object obj15 = 0 * forward2.y;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rcx_v25 (WeaponData)+C8]");
											object obj16 = 0 * forward2.z;
											float num9 = (float)obj14 + position4.x;
											float num10 = (float)obj15 + position4.y;
											float num11 = (float)obj16 + position4.z;
											transform4.position = position5;
											return true;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_040b;
		IL_040b:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	protected unsafe override void FindMovementDirection()
	{
		//IL_006c: Expected O, but got Ref
		//IL_0107: Expected I, but got O
		Transform transform = base.transform;
		Vector3 position = transform.position;
		float weaponRange = WeaponUtility.GetWeaponRange(base.weaponBase);
		WeaponBase weaponBase = base.weaponBase;
		WeaponData weaponData = weaponBase.weaponData;
		float num = default(float);
		GameObject exceptObject = default(GameObject);
		Enemy enemy = EnemyTargeting.GetEnemy((Vector3)(&num), weaponRange, 1, weaponData.useVision, exceptObject);
		if (!(enemy == null))
		{
			Vector3 centerPosition = enemy.GetCenterPosition();
			Transform transform2 = base.transform;
			Vector3 position2 = transform2.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
			object obj = default(object);
			direction = (Vector3)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ rax_v22+8]");
			_ = 0;
		}
		else
		{
			nint num2 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v290 @ rax_v16 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num3 = 0;
			direction = Vector3.zeroVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ rcx_v13 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
			_ = 0;
		}
	}

	protected unsafe override Vector3 GetMovementDirection()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_0022: Expected F4, but got O
		//IL_001d: Expected native int or pointer, but got O
		//IL_0037: Expected F4, but got I
		//IL_0032: Expected native int or pointer, but got O
		object obj = this + 56;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		Vector3 vector = default(Vector3);
		object obj2 = default(object);
		((Vector3*)(nint)vector)->x = (float)obj2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rax_v1+8]");
		((Vector3*)(nint)vector)->z = 0f;
		return vector;
	}

	protected override void MyFixedUpdate()
	{
	}

	protected override void MyUpdate()
	{
	}

	private unsafe void OnCollisionEnter(Collision collision)
	{
		//IL_0097: Expected O, but got Ref
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		//IL_006e: Expected O, but got Ref
		int contactCount = collision.contactCount;
		Vector3 normal;
		object obj2 = default(object);
		Collider collider2;
		if (contactCount > 0)
		{
			Collider collider = collision.collider;
			ContactPoint[] contacts = collision.contacts;
			object obj = contacts + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182268200");
			normal = (Vector3)(&obj2);
			collider2 = collider;
		}
		else
		{
			Collider collider3 = collision.collider;
			normal = (Vector3)(&obj2);
			collider2 = collider3;
		}
		bool flag = base.CheckCollision(collider2, normal);
	}

	private unsafe void OnTriggerEnter(Collider collider)
	{
		//IL_0013: Expected O, but got Ref
		object obj = default(object);
		bool flag = base.CheckCollision(collider, (Vector3)(&obj));
	}
}
