using System;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Spawning;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using Cpp2ILInjected;
using UnityEngine;

public class ProjectileArrow : ProjectileBase
{
	public TrailRenderer trailRenderer;

	private float upOffset;

	private Vector3 pushDir;

	private float trailStartWidth;

	private static Vector3 baseDir;

	private float speedReduction;

	private float nextCheckDamageTime;

	protected unsafe override bool TryInit(int projectileIndex)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0041: Invalid comparison between I4 and F4
		//IL_0666: Expected I, but got O
		//IL_0684: Expected I, but got O
		//IL_08a7: Expected O, but got I
		//IL_08c4: Expected O, but got I
		//IL_090e: Invalid comparison between F4 and O
		//IL_018b: Expected I, but got O
		//IL_0634: Expected I4, but got O
		//IL_06a7: Expected I, but got O
		//IL_01ba: Expected O, but got Ref
		//IL_043a: Expected F4, but got I4
		//IL_07d1: Expected O, but got Ref
		//IL_07fd: Expected I, but got O
		//IL_080b: Expected O, but got Ref
		//IL_0819: Expected O, but got Ref
		//IL_0380: Invalid comparison between I4 and F4
		//IL_0457: Expected O, but got Ref
		//IL_0472: Expected O, but got Ref
		//IL_03cb: Expected F4, but got I4
		//IL_029a: Expected O, but got Ref
		//IL_02a8: Expected O, but got Ref
		//IL_0748: Expected O, but got I4
		//IL_0758: Unknown result type (might be due to invalid IL or missing references)
		//IL_075d: Expected O, but got Unknown
		//IL_0765: Unknown result type (might be due to invalid IL or missing references)
		//IL_076a: Expected I4, but got Unknown
		//IL_02d4: Expected I, but got O
		//IL_04c2: Expected O, but got Ref
		//IL_0500: Expected O, but got Ref
		//IL_03d9: Invalid comparison between I4 and F4
		//IL_0542: Expected O, but got Ref
		//IL_05e9: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (!(trailRenderer != null))
		{
			goto IL_00f5;
		}
		if (!(0f < trailStartWidth))
		{
			if ((object)trailRenderer == null)
			{
				goto IL_0626;
			}
			float startWidth = trailRenderer.startWidth;
			trailStartWidth = startWidth;
		}
		if ((object)trailRenderer != null)
		{
			trailRenderer.Clear();
			float attackSizeMultiplier = WeaponUtility.GetAttackSizeMultiplier(weaponBase);
			if ((object)trailRenderer != null)
			{
				float startWidth2 = trailStartWidth * attackSizeMultiplier;
				trailRenderer.startWidth = startWidth2;
				goto IL_00f5;
			}
		}
		goto IL_0626;
		IL_0626:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_07b9:
		PlayerMovement playerMovement;
		_ = playerMovement.normalVector;
		Vector3 axis = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ rax_v17 (PlayerMovement)+138]");
		_ = 0;
		float angle;
		Quaternion quaternion = Quaternion.AngleAxis(angle, axis);
		nint num = (nint)typeof(ProjectileArrow);
		Vector3 vector = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
		Quaternion quaternion2 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v820 @ rcx_v16 (Il2CppClass<ProjectileArrow>)+B8]");
		nint num2 = 0;
		_ = baseDir;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v824 @ rcx_v17 (Il2CppStaticFields<ProjectileArrow>)+8]");
		_ = 0;
		_ = quaternion.x;
		Vector3 vector2 = quaternion2 * vector;
		Transform transform = base.transform;
		_ = playerMovement.normalVector;
		Vector3 upwards = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ rax_v17 (PlayerMovement)+138]");
		_ = 0;
		Vector3 forward = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		_ = vector2.x;
		_ = vector2.z;
		Quaternion quaternion3 = Quaternion.LookRotation(forward, upwards);
		if ((object)transform != null)
		{
			Quaternion rotation = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
			_ = quaternion3.x;
			transform.rotation = rotation;
			Transform transform2 = base.transform;
			_ = vector2.x;
			Vector3 forward2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
			_ = vector2.z;
			Quaternion quaternion4 = Quaternion.LookRotation(forward2);
			if ((object)transform2 != null)
			{
				Quaternion rotation2 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
				_ = quaternion4.x;
				transform2.rotation = rotation2;
				Transform transform3 = base.transform;
				if ((object)MyPlayer.Instance != null)
				{
					Transform transform4 = MyPlayer.Instance.transform;
					if ((object)transform4 != null)
					{
						Vector3 position = transform4.position;
						if ((object)transform3 != null)
						{
							Vector3 position2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
							_ = position.x;
							_ = position.z;
							transform3.position = position2;
							return true;
						}
					}
				}
			}
		}
		goto IL_0626;
		IL_0658:
		nint num3 = (nint)typeof(ProjectileArrow);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v455 @ rax_v9 (Il2CppClass<ProjectileArrow>)+B8]");
		nint num4 = 0;
		nint num5 = (nint)typeof(SpawnPositions);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v551 @ rax_v11 (Il2CppClass<Assets.Scripts.Game.Spawning.SpawnPositions>)+B8]");
		nint num6 = 0;
		object obj3 = baseDir - SpawnPositions.INVALID_POS;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v456 @ rcx_v10 (Il2CppStaticFields<ProjectileArrow>)+4]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v554 @ rax_v12 (Il2CppStaticFields<Assets.Scripts.Game.Spawning.SpawnPositions>)+4]");
		object obj4 = num7 - 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v456 @ rcx_v10 (Il2CppStaticFields<ProjectileArrow>)+8]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v554 @ rax_v12 (Il2CppStaticFields<Assets.Scripts.Game.Spawning.SpawnPositions>)+8]");
		object obj5 = num8 - 0;
		object obj6 = obj4 * obj4;
		object obj7 = obj3 * obj3;
		object obj8 = obj5 * obj5;
		object obj9 = obj6 + obj7;
		object obj10 = obj9 + obj8;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj10))
		{
			goto IL_0618;
		}
		MyPlayer instance = MyPlayer.Instance;
		if ((object)MyPlayer.Instance != null)
		{
			playerMovement = instance.playerMovement;
			if ((object)instance.playerMovement != null)
			{
				int attackQuantity = WeaponUtility.GetAttackQuantity(weaponBase);
				if (attackQuantity > 1)
				{
					float num9 = (float)attackQuantity * 2.5f;
					if (!(0f > num9))
					{
						if (num9 > 357.5f)
						{
							num9 = 357.5f;
						}
					}
					else
					{
						num9 = 0f;
					}
					object obj11 = attackQuantity - 1;
					float num10 = num9;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED90]");
					object obj12 = num10 ^ 0;
					int num11 = projectileIndex / obj11;
					if (0 <= num11)
					{
						if ((float)num11 > 1f)
						{
							float num12 = num9 - (float)obj12;
							float num13 = num12 * 1f;
							angle = num13 + (float)obj12;
							goto IL_07b9;
						}
					}
					else
					{
						num11 = 0;
					}
					float num14 = num9 - (float)obj12;
					float num15 = num14 * (float)num11;
					angle = num15 + (float)obj12;
				}
				else
				{
					angle = 0f;
				}
				goto IL_07b9;
			}
		}
		goto IL_0626;
		IL_00f5:
		float arrowSpeed = ProjectileUtility.GetArrowSpeed(weaponBase);
		projectileSpeed = arrowSpeed;
		float num16 = (speedReduction = ProjectileUtility.GetArrowSpeedReduction(weaponBase));
		float num17 = num16 + num16;
		float num18 = projectileSpeed * projectileSpeed;
		float range = num18 / num17;
		if (projectileIndex == 0)
		{
			nint num19 = (nint)typeof(SpawnPositions);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v542 @ rax_v44 (Il2CppClass<Assets.Scripts.Game.Spawning.SpawnPositions>)+B8]");
			nint num20 = 0;
			nint num21 = (nint)typeof(ProjectileArrow);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v547 @ rax_v46 (Il2CppClass<ProjectileArrow>)+B8]");
			nint num22 = 0;
			baseDir = SpawnPositions.INVALID_POS;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v545 @ rax_v45 (Il2CppStaticFields<Assets.Scripts.Game.Spawning.SpawnPositions>)+8]");
			_ = 0;
			Transform transform5 = base.transform;
			if ((object)transform5 != null)
			{
				Vector3 position3 = transform5.position;
				_ = position3.x;
				Vector3 position4 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
				_ = position3.z;
				GameObject exceptObject = default(GameObject);
				Enemy enemy = EnemyTargeting.GetEnemy(position4, range, 0, useVision: true, exceptObject);
				if (!(enemy != null))
				{
					goto IL_0618;
				}
				if ((object)enemy != null)
				{
					Vector3 feetPosition = enemy.GetFeetPosition();
					if ((object)MyPlayer.Instance != null)
					{
						Vector3 feetPosition2 = MyPlayer.Instance.GetFeetPosition();
						float num23 = feetPosition.x - feetPosition2.x;
						float num24 = feetPosition.y - feetPosition2.y;
						float num25 = feetPosition.z - feetPosition2.z;
						object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
						object obj14 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
						nint num26 = (nint)typeof(ProjectileArrow);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v441 @ rax_v60 (Il2CppClass<ProjectileArrow>)+B8]");
						nint num27 = 0;
						object obj15 = default(object);
						baseDir = (Vector3)obj15;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v859 @ rax_v59+8]");
						_ = 0;
						goto IL_0658;
					}
				}
			}
			goto IL_0626;
		}
		goto IL_0658;
		IL_0618:
		return false;
	}

	private float GetAngle(int projectileIndex, int maxIndex)
	{
		//IL_00f0: Expected F4, but got I4
		//IL_0039: Invalid comparison between I4 and F4
		//IL_0084: Expected F4, but got I4
		//IL_00fe: Expected O, but got I4
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Expected I4, but got Unknown
		//IL_0092: Invalid comparison between I4 and F4
		if (maxIndex > 1)
		{
			float num = (float)maxIndex * 2.5f;
			if (!(0f > num))
			{
				if (num > 357.5f)
				{
					num = 357.5f;
				}
			}
			else
			{
				num = 0f;
			}
			object obj = maxIndex - 1;
			float num2 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED90]");
			object obj2 = num2 ^ 0;
			int num3 = projectileIndex / obj;
			if (0 <= num3)
			{
				if ((float)num3 > 1f)
				{
					float num4 = num - (float)obj2;
					float num5 = num4 * 1f;
					return num5 + (float)obj2;
				}
			}
			else
			{
				num3 = 0;
			}
			float num6 = num - (float)obj2;
			float num7 = num6 * (float)num3;
			return num7 + (float)obj2;
		}
		return 0f;
	}

	protected unsafe override Vector3 GetMovementDirection()
	{
		//IL_0041: Expected native int or pointer, but got O
		//IL_0053: Expected native int or pointer, but got O
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			Vector3 forward = transform.forward;
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = forward.x;
			((Vector3*)(nint)vector)->z = forward.z;
			return vector;
		}
		return (Vector3)new NullReferenceException();
	}

	protected override void MyFixedUpdate()
	{
		//IL_000b: Invalid comparison between I4 and F4
		//IL_003e: Invalid comparison between I4 and F4
		//IL_0087: Expected F4, but got I4
		if (!(0f < projectileSpeed))
		{
			return;
		}
		float num = projectileSpeed - speedReduction;
		if (!(0f > num))
		{
			if (num > 99f)
			{
				projectileSpeed = 99f;
				return;
			}
		}
		else
		{
			num = 0f;
		}
		projectileSpeed = num;
	}

	protected override void MyUpdate()
	{
	}

	protected override void FindMovementDirection()
	{
	}

	private float GetRadius()
	{
		return projectileRadius;
	}

	private unsafe void OnDrawGizmosSelected()
	{
		//IL_002b: Expected O, but got Ref
		Transform transform = base.transform;
		Vector3 position = transform.position;
		object obj = default(object);
		Gizmos.DrawWireSphere((Vector3)(&obj), projectileRadius);
	}
}
