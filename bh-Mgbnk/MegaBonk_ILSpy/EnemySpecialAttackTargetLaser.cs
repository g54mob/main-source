using System;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Game.Combat.EnemySpecialAttacks;
using Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations;
using Assets.Scripts.Managers;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using Utility;

public class EnemySpecialAttackTargetLaser : EnemySpecialAttackPrefab
{
	public Transform laser;

	public Transform laserEnd;

	private float speed;

	private float defaultMaxSpeed = 35f;

	private float maxSpeed = 35f;

	public Transform blackhole;

	private float maxLaserLength = 999f;

	private float laserLength;

	private float overAtTime;

	private float timeToMaxSpeed = 5f;

	private float speedTimer;

	private float damageCooldown = 0.1f;

	private float nextDamageReadyTime;

	protected unsafe override void Init()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00c5: Expected O, but got Ref
		//IL_0178: Expected O, but got Ref
		//IL_0186: Expected O, but got Ref
		//IL_0424: Expected I, but got O
		//IL_02c5: Expected O, but got I
		//IL_0482: Expected I, but got O
		//IL_02ff: Expected O, but got Ref
		//IL_032e: Expected O, but got Ref
		//IL_039c: Expected I, but got O
		//IL_03aa: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		maxSpeed = defaultMaxSpeed;
		if (MapController.index == 1)
		{
			float num = maxSpeed * 1.5f;
			maxSpeed = num;
		}
		if (MapController.index >= 2)
		{
			float num2 = maxSpeed + maxSpeed;
			maxSpeed = num2;
		}
		speedTimer = 0f;
		speed = 0f;
		Transform transform = laser.transform;
		Vector3 laserPosition = GetLaserPosition();
		Vector3 position = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
		_ = laserPosition.z;
		_ = laserPosition.x;
		transform.position = position;
		Transform transform2 = MyPlayer.Instance.transform;
		Vector3 position2 = transform2.position;
		Vector3 centerPosition = enemy.GetCenterPosition();
		float num3 = position2.x - centerPosition.x;
		float num4 = position2.y - centerPosition.y;
		float num5 = position2.z - centerPosition.z;
		object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
		object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		Vector3 centerPosition2 = enemy.GetCenterPosition();
		_ = centerPosition2.y;
		_ = centerPosition2.z;
		Transform transform3 = MyPlayer.Instance.transform;
		Vector3 position3 = transform3.position;
		Vector3 centerPosition3 = enemy.GetCenterPosition();
		nint num6 = (nint)typeof(Math);
		float num7 = position3.x - centerPosition3.x;
		float num8 = position3.y - centerPosition3.y;
		float num9 = position3.z - centerPosition3.z;
		float num10 = num8 * num8;
		float num11 = num7 * num7;
		float num12 = num9 * num9;
		float num13 = num10 + num11;
		float num14 = num13 + num12;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v546 @ rcx_v26 (Il2CppClass<System.Math>)+E4]");
		if ((nint)0 <= (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
		}
		else
		{
			double num15 = Math.Sqrt(num14);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm1,xmm0\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v279 @ rax_v23+8]");
		object obj5 = (nint)0 * (nint)0;
		float num16 = (float)obj5 * 0.5f;
		float num17 = num16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+77]");
		float num18 = num17 + 0f;
		nint num19 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v600 @ rax_v31 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num20 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v601 @ rcx_v28 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
		float num21 = 0f * 500f;
		float num22 = num21 + num18;
		Vector3 pos = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
		Vector3 vector = RaycastUtility.RayToGround(pos);
		Vector3 worldPosition = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
		_ = vector.x;
		_ = vector.z;
		laser.LookAt(worldPosition);
		EnemySpecialAttack enemySpecialAttack = base._003CspecialAttack_003Ek__BackingField;
		float num23 = MyTime.time + enemySpecialAttack.duration;
		overAtTime = num23;
		Transform transform4 = blackhole.transform;
		nint num24 = (nint)typeof(Vector3);
		Vector3 localScale = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v658 @ rcx_v35 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num25 = 0;
		_ = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v659 @ rax_v41 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		transform4.localScale = localScale;
	}

	private unsafe Vector3 GetLaserPosition()
	{
		//IL_0041: Expected I, but got O
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_0107: Expected native int or pointer, but got O
		//IL_0114: Expected native int or pointer, but got O
		//IL_0121: Expected native int or pointer, but got O
		if ((object)enemy != null)
		{
			Vector3 headPosition = enemy.GetHeadPosition();
			if ((object)enemy != null)
			{
				nint num = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rax_v5 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804AD730");
				object obj2 = default(object);
				object obj = (object)Vector3.upVector * obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rdx_v2 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
				object obj3 = 0 * obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rdx_v2 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
				object obj4 = 0 * obj2;
				float num3 = (float)obj * 0.1f;
				float num4 = (float)obj3 * 0.1f;
				float x = num3 + headPosition.x;
				float num5 = (float)obj4 * 0.1f;
				float y = num4 + headPosition.y;
				float z = num5 + headPosition.z;
				Vector3 vector = default(Vector3);
				((Vector3*)(nint)vector)->x = x;
				((Vector3*)(nint)vector)->y = y;
				((Vector3*)(nint)vector)->z = z;
				return vector;
			}
		}
		return (Vector3)new NullReferenceException();
	}

	private unsafe void Update()
	{
		//IL_006d: Invalid comparison between I4 and F4
		//IL_0052: Expected O, but got Ref
		Vector3 localScale = blackhole.localScale;
		float num = MyTime.deltaTime + MyTime.deltaTime;
		if (0f > num || num > 1f)
		{
		}
		object obj = default(object);
		blackhole.localScale = (Vector3)(&obj);
	}

	private unsafe void FixedUpdate()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0034: Expected O, but got Ref
		//IL_0053: Expected O, but got Ref
		//IL_055b: Invalid comparison between I4 and F4
		//IL_018e: Expected O, but got Ref
		//IL_00b1: Expected F4, but got I4
		//IL_05a0: Invalid comparison between I4 and F4
		//IL_068f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0694: Expected F4, but got Unknown
		//IL_00f7: Expected F4, but got I4
		//IL_05d8: Invalid comparison between I4 and F4
		//IL_0133: Expected F4, but got I4
		//IL_0279: Expected O, but got Ref
		//IL_01eb: Invalid comparison between F4 and I4
		//IL_06c2: Expected O, but got Ref
		//IL_06c2: Expected O, but got Ref
		//IL_02ff: Expected O, but got Ref
		//IL_02ff: Expected O, but got Ref
		//IL_06e6: Expected O, but got Ref
		//IL_0407: Expected O, but got Ref
		//IL_0407: Expected O, but got Ref
		//IL_0441: Expected O, but got Ref
		//IL_045d: Expected O, but got Ref
		//IL_04e5: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		_ = 0;
		float num = default(float);
		float num23 = default(float);
		if (MyTime.time < overAtTime)
		{
			Transform transform = base.transform;
			Vector3 laserPosition = GetLaserPosition();
			transform.position = (Vector3)(&num);
			Vector3 laserPosition2 = GetLaserPosition();
			laser.position = (Vector3)(&num);
			if (1f > speedTimer)
			{
				float num2 = MyTime.fixedDeltaTime / timeToMaxSpeed;
				float num3 = num2 + speedTimer;
				if (!(0f > num3))
				{
					if (num3 > 1f)
					{
						num3 = 1f;
					}
				}
				else
				{
					num3 = 0f;
				}
				float num4 = num3 * num3;
				speedTimer = num3;
				float num5 = num4 * num3;
				float num6 = ((0f > num5) ? 0f : ((num5 > 1f) ? 1f : num5));
				float num7 = maxSpeed * num6;
				speed = num7;
				if (!(0f > num5))
				{
					if (num5 > 1f)
					{
						num5 = 1f;
					}
				}
				else
				{
					num5 = 0f;
				}
				float num8 = maxLaserLength * num5;
				laserLength = num8;
			}
			Transform transform2 = MyPlayer.Instance.transform;
			Vector3 position = transform2.position;
			Vector3 position2 = laser.position;
			float num9 = position.x - position2.x;
			Quaternion quaternion = Quaternion.LookRotation((Vector3)(&num));
			Quaternion rotation = laser.rotation;
			float num11 = default(float);
			float num10 = num11 * num11;
			float num12 = rotation.x * quaternion.x;
			float num13 = num11 * num11;
			float num14 = num10 + num12;
			float num15 = num11 * num11;
			float num16 = num14 + num13;
			float num17 = num16 + num15;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
			float num18 = num17 & 0;
			if (!(1f > num18))
			{
				num18 = 1f;
			}
			if (!(num18 > 0.999999f))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180301200");
				float num19 = num18 + num18;
				float num20 = num19 * 57.29578f;
				bool flag = num20 == 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018049068Fh\"");
				if (!flag)
				{
					float num21 = speed * MyTime.fixedDeltaTime;
					float num22 = num21 / num20;
					bool flag2 = num22 > 1f;
					float t = 1f;
					if (!flag2)
					{
						t = num22;
					}
					Quaternion quaternion2 = Quaternion.SlerpUnclamped((Quaternion)(&num), (Quaternion)(&num23), t);
					num = rotation.x;
					goto IL_026a;
				}
			}
			num = num9;
			goto IL_026a;
		}
		ReturnToPool();
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: false);
		return;
		IL_026a:
		laser.rotation = (Quaternion)(&num23);
		Transform transform3 = laser.transform;
		Vector3 position3 = transform3.position;
		Transform transform4 = laser.transform;
		Vector3 forward = transform4.forward;
		GameManager instance = GameManager.Instance;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
		int layerMask = default(int);
		Transform transform6;
		if (!Physics.Raycast((Vector3)(&num23), (Vector3)(&num), out var _, laserLength, layerMask))
		{
			Transform transform5 = laser.transform;
			transform6 = transform5;
		}
		else
		{
			Transform transform7 = laser.transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18231C560");
			transform6 = transform7;
		}
		transform6.localScale = (Vector3)(&num);
		Transform transform8 = laser.transform;
		Vector3 position4 = transform8.position;
		Transform transform9 = laser.transform;
		Vector3 forward2 = transform9.forward;
		Vector3 localScale = laser.localScale;
		GameManager instance2 = GameManager.Instance;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
		if (Physics.Raycast((Vector3)(&num), (Vector3)(&num23), out System.Runtime.CompilerServices.Unsafe.As<object, RaycastHit>(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128)), localScale.z, layerMask))
		{
			Transform transform10 = laser.transform;
			object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18231C560");
			transform10.localScale = (Vector3)(&num);
		}
		Transform transform11 = laser.transform;
		Vector3 position5 = transform11.position;
		Transform transform12 = laser.transform;
		Vector3 forward3 = transform12.forward;
		Transform transform13 = laser.transform;
		Vector3 localScale2 = transform13.localScale;
		laserEnd.position = (Vector3)(&num);
	}

	private unsafe void OnTriggerStay(Collider other)
	{
		//IL_0067: Expected O, but got Ref
		if (!(nextDamageReadyTime > MyTime.time))
		{
			float num = MyTime.time + damageCooldown;
			nextDamageReadyTime = num;
			float damage = base._003CspecialAttack_003Ek__BackingField.GetDamage(enemy);
			MyPlayer instance = MyPlayer.Instance;
			PlayerInventory inventory = instance.inventory;
			DcFlags damageFlags = GetDamageFlags();
			Vector3 vector = default(Vector3);
			bool ignoreShield = default(bool);
			string damageSource = default(string);
			DcFlags flags = default(DcFlags);
			EDamageEffect damageEffect = default(EDamageEffect);
			inventory.playerHealth.DamagePlayerExternal(damage, 0f, (Vector3)(&vector), ignoreShield, damageSource, flags, damageEffect);
		}
	}
}
