using System;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

namespace Assets.Scripts.Inventory__Items__Pickups.Items.ItemProjectiles;

public class ItemProjectileOrb : ItemProjectile
{
	private float startTime;

	private float hoverTime;

	private float offsetTime;

	private float spinSpeed;

	private float currentAngle;

	private float moveTimer;

	private Vector3 offset;

	private Transform orbitTarget;

	private Vector3 defaultScale;

	private bool fired;

	public GameObject fireSfx;

	private Vector3 movementDirection;

	protected override void Init()
	{
		//IL_0111: Expected I, but got O
		//IL_014e: Expected O, but got I
		//IL_016b: Expected O, but got I
		//IL_01b5: Invalid comparison between F4 and O
		//IL_01c7: Expected O, but got I4
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		//IL_0045: Expected O, but got F4
		//IL_0058: Expected O, but got I4
		//IL_01e3: Expected I, but got O
		fireSfx.SetActive(value: false);
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v6 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		object obj = defaultScale - Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Inventory__Items__Pickups.Items.ItemProjectiles.ItemProjectileOrb)+DC]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rcx_v5 (Il2CppStaticFields<UnityEngine.Vector3>)+4]");
		object obj2 = num3 - 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Inventory__Items__Pickups.Items.ItemProjectiles.ItemProjectileOrb)+E0]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rcx_v5 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		object obj3 = num4 - 0;
		object obj4 = obj2 * obj2;
		object obj5 = obj * obj;
		object obj6 = obj3 * obj3;
		object obj7 = obj4 + obj5;
		object obj8 = obj7 + obj6;
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8);
		object obj9 = 0;
		if (!flag)
		{
			Transform transform = base.transform;
			Vector3 localScale = transform.localScale;
			defaultScale = (Vector3)localScale.x;
			_ = localScale.z;
			obj9 = 0;
		}
		currentAngle = 0f;
		fired = false;
		Transform transform2 = MyPlayer.Instance.transform;
		object obj10 = this + 208;
		orbitTarget = transform2;
		float num5 = 360f / (float)projectilesCount;
		float num6 = num5 * (float)projectileIndex;
		float num7 = num6 * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE090");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE830");
		float num8 = num7 * 4f;
		Vector3 vector = default(Vector3);
		offset = vector;
		nint num9 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rax_v17 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rcx_v11 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
		float num11 = 0f * 1.5f;
		float num12 = num11 + num8;
		offset = vector;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,dword ptr [rbx+4Ch]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm2,dword ptr [rbx+4Ch]\"");
		float num13 = 0f * 0.2f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm1,dword ptr [rbx+48h]\"");
		if (num13 > 1.5f)
		{
			num13 = 1.5f;
		}
		float num14 = num13 / 0f;
		float num15 = startTime + spawnedAtTime;
		float num16 = num14 * 0f;
		float num17 = num15 + hoverTime;
		offsetTime = num16;
		float num18 = num17 + num16;
		float num19 = num18 + 2.5f;
		expirationTime = num19;
	}

	private unsafe void FireOrb()
	{
		//IL_0008: Expected O, but got Ref
		//IL_002d: Expected O, but got Ref
		//IL_0380: Expected I, but got O
		//IL_02ff: Expected O, but got Ref
		//IL_030d: Expected O, but got Ref
		//IL_0102: Expected O, but got Ref
		//IL_0110: Expected O, but got Ref
		//IL_013c: Expected O, but got Ref
		//IL_0159: Expected O, but got I
		//IL_0167: Expected O, but got Ref
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		//IL_0199: Expected O, but got I
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Expected O, but got Unknown
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Expected O, but got Unknown
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Expected O, but got Unknown
		//IL_023c: Invalid comparison between I4 and F4
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = (object)(&obj2);
		fired = true;
		Transform transform = base.transform;
		Vector3 position = transform.position;
		Vector3 position2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
		_ = position.x;
		_ = position.z;
		GameObject exceptObject = default(GameObject);
		Enemy enemy = EnemyTargeting.GetEnemy(position2, 70f, projectileIndex, useVision: false, exceptObject);
		if (enemy == null)
		{
			nint num = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ rax_v18 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num2 = 0;
			_ = Vector3.upVector;
			Transform transform2 = base.transform;
			Vector3 position3 = transform2.position;
			Vector3 position4 = orbitTarget.position;
			float num3 = position3.x - position4.x;
			float num4 = position3.y - position4.y;
			float num5 = position3.z - position4.z;
			object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
			object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
			object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rcx_v17 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ rax_v22+4]");
			object obj6 = num6 * 0;
			object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rcx_v17 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
			object obj9 = default(object);
			object obj8 = 0 * obj9;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-25]");
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ rax_v22+8]");
			object obj10 = num7 * 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-25]");
			object obj11 = 0 * obj9;
			object obj12 = obj10 - obj6;
			Vector3 upVector = Vector3.upVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ rax_v22+8]");
			object obj13 = upVector * 0;
			Vector3 upVector2 = Vector3.upVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ rax_v22+4]");
			object obj14 = upVector2 * 0;
			object obj15 = obj8 - obj13;
			object obj16 = obj14 - obj11;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
			object obj17 = default(object);
			movementDirection = (Vector3)obj17;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ rax_v23+8]");
			_ = 0;
			if (0f > spinSpeed)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Inventory__Items__Pickups.Items.ItemProjectiles.ItemProjectileOrb)+F8]");
				object obj18 = 0 ^ -0f;
				Vector3 vector = default(Vector3);
				movementDirection = vector;
			}
		}
		else
		{
			Vector3 centerPosition = enemy.GetCenterPosition();
			Transform transform3 = base.transform;
			Vector3 position5 = transform3.position;
			float num8 = centerPosition.x - position5.x;
			float num9 = centerPosition.y - position5.y;
			float num10 = centerPosition.z - position5.z;
			object obj19 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
			object obj20 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
			object obj21 = default(object);
			movementDirection = (Vector3)obj21;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ rax_v16+8]");
			_ = 0;
		}
		fireSfx.SetActive(value: true);
	}

	protected override void Step()
	{
		float num = startTime + spawnedAtTime;
		float num2 = num + hoverTime;
		float num3 = num2 + offsetTime;
		if (!(num3 > MyTime.time))
		{
			if (!fired)
			{
				FireOrb();
			}
			base.StepAttackMovement();
		}
		else
		{
			StepHoverMovement();
		}
	}

	protected unsafe override Vector3 GetMovementDirection()
	{
		//IL_000f: Expected F4, but got O
		//IL_000a: Expected native int or pointer, but got O
		//IL_0024: Expected F4, but got I
		//IL_001f: Expected native int or pointer, but got O
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = (float)movementDirection;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Assets.Scripts.Inventory__Items__Pickups.Items.ItemProjectiles.ItemProjectileOrb)+F8]");
		((Vector3*)(nint)vector)->z = 0f;
		return vector;
	}

	protected void StepHoverMovement()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_0364: Unknown result type (might be due to invalid IL or missing references)
		//IL_0369: Expected O, but got Unknown
		//IL_0390: Unknown result type (might be due to invalid IL or missing references)
		//IL_0395: Expected O, but got Unknown
		//IL_039e: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a3: Expected O, but got Unknown
		//IL_0135: Invalid comparison between I4 and F4
		//IL_0180: Expected F4, but got I4
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Expected O, but got Unknown
		//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fa: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = obj2 - 95;
		float num = MyTime.fixedDeltaTime * spinSpeed;
		float num2 = MyTime.time - spawnedAtTime;
		float num3 = (currentAngle = num + currentAngle) * ((float)Math.PI / 180f);
		Vector3 euler = (Vector3)(obj - 41);
		_ = 0;
		_ = 0;
		Quaternion quaternion = Quaternion.Internal_FromEulerRad(euler);
		Vector3 vector = (Vector3)(obj - 41);
		Quaternion quaternion2 = (Quaternion)(obj - 9);
		_ = offset;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Inventory__Items__Pickups.Items.ItemProjectiles.ItemProjectileOrb)+C8]");
		_ = 0;
		_ = quaternion.x;
		Vector3 vector2 = quaternion2 * vector;
		Transform transform2;
		if (!(startTime > num2))
		{
			if (!(orbitTarget != null))
			{
				return;
			}
			Vector3 position = orbitTarget.position;
			float num4 = vector2.x + position.x;
			float num5 = vector2.y + position.y;
			float num6 = vector2.z + position.z;
			Transform transform = base.transform;
			Vector3 position2 = (Vector3)(obj - 41);
			transform.position = position2;
			transform2 = base.transform;
			_ = defaultScale;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Inventory__Items__Pickups.Items.ItemProjectiles.ItemProjectileOrb)+E0]");
			_ = 0;
		}
		else
		{
			float num7 = num2 / startTime;
			if (!(0f > num7))
			{
				if (num7 > 1f)
				{
					num7 = 1f;
				}
			}
			else
			{
				num7 = 0f;
			}
			float num8 = Easing.OutBack(num7);
			if (!(orbitTarget != null))
			{
				return;
			}
			Vector3 position3 = orbitTarget.position;
			float num9 = num8 * vector2.x;
			float num10 = num8 * vector2.y;
			float num11 = num9 + position3.x;
			float num12 = num8 * vector2.z;
			float num13 = num10 + position3.y;
			float num14 = num12 + position3.z;
			Transform transform3 = base.transform;
			Vector3 position4 = (Vector3)(obj - 41);
			transform3.position = position4;
			transform2 = base.transform;
			float num15 = num8 * (float)defaultScale;
			float num16 = num8;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Inventory__Items__Pickups.Items.ItemProjectiles.ItemProjectileOrb)+DC]");
			float num17 = num16 * 0f;
			float num18 = num8;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Inventory__Items__Pickups.Items.ItemProjectiles.ItemProjectileOrb)+E0]");
			float num19 = num18 * 0f;
		}
		Vector3 localScale = (Vector3)(obj - 41);
		transform2.localScale = localScale;
	}

	protected override void ProjectileDone()
	{
		base.ProjectileDone();
		if (fireSfx != null)
		{
			fireSfx.SetActive(value: false);
		}
	}

	public ItemProjectileOrb()
	{
		//IL_007b: Expected I, but got O
		//IL_0040: Expected I, but got O
		startTime = 0.5f;
		hoverTime = 0.5f;
		spinSpeed = 90f;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v3 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		defaultScale = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rdx_v1 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		nint num3 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rax_v6 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num4 = 0;
		movementDirection = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rcx_v4 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		base._002Ector();
	}
}
