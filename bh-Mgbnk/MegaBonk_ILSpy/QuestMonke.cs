using System;
using System.Runtime.CompilerServices;
using Assets.Scripts.MapGeneration;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

public class QuestMonke : MonoBehaviour
{
	public Animator animator;

	public Rigidbody rb;

	private Vector3 runDir;

	private float speed = 12f;

	public GameObject dissapearFx;

	private float aliveTime = 120f;

	private float deadTime;

	private bool isWalking;

	private Vector3 savedVelocity;

	private float stopMusicAtTime;

	private bool isClimbingWall;

	private float climbSpeed = 8f;

	private void Start()
	{
		//IL_0021: Expected O, but got F4
		Transform transform = base.transform;
		Vector3 forward = transform.forward;
		runDir = (Vector3)forward.x;
		_ = forward.z;
		float num = MyTime.time + aliveTime;
		deadTime = num;
		float num2 = MyTime.time + 10f;
		stopMusicAtTime = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180359310");
	}

	private void OnDestroy()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180359310");
	}

	private void Update()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172AFA]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		AnimatorStateInfo currentAnimatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
		AnimatorStateInfo animatorStateInfo = default(AnimatorStateInfo);
		bool flag = animatorStateInfo.IsName("Walking");
		if (!flag)
		{
			isWalking = flag;
		}
		else if (!isWalking)
		{
			isWalking = true;
			rb.isKinematic = true;
		}
	}

	private unsafe void FixedUpdate()
	{
		//IL_0436: Expected O, but got F4
		//IL_00c9: Expected O, but got Ref
		//IL_0077: Expected O, but got Ref
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Expected O, but got Unknown
		//IL_027b: Expected O, but got Ref
		//IL_027b: Expected O, but got Ref
		//IL_0128: Expected O, but got Ref
		//IL_0128: Expected O, but got Ref
		//IL_048b: Expected O, but got Ref
		//IL_048b: Expected O, but got Ref
		//IL_049c: Expected O, but got Ref
		//IL_0193: Expected O, but got I
		//IL_01b0: Expected O, but got I
		//IL_01d3: Invalid comparison between O and F4
		//IL_01f7: Expected O, but got Ref
		//IL_01f7: Expected O, but got Ref
		if (!isWalking)
		{
			return;
		}
		float x = default(float);
		float fixedDeltaTime;
		float num6;
		Rigidbody rigidbody;
		if (!MyTime.paused)
		{
			Vector3 vector = default(Vector3);
			if (rb.isKinematic)
			{
				rb.isKinematic = false;
				rb.velocity = (Vector3)(&vector);
				vector = savedVelocity;
			}
			TryClimb();
			Vector3 velocity = rb.velocity;
			float num = speed;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (QuestMonke)+38]");
			float num2 = num * 0f;
			rb.velocity = (Vector3)(&vector);
			if (!isClimbingWall)
			{
				Transform transform = base.transform;
				Vector3 position = transform.position;
				float num3 = default(float);
				if (Physics.Raycast((Vector3)(&x), (Vector3)(&num3), out var _, 2f))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182268200");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331740");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
					object obj2 = default(object);
					object obj = obj2 * obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v788 @ rax_v60+4]");
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v788 @ rax_v60+4]");
					object obj3 = num4 * 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v788 @ rax_v60+8]");
					nint num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v788 @ rax_v60+8]");
					object obj4 = num5 * 0;
					object obj5 = obj + obj3;
					object obj6 = obj5 + obj4;
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.001f))
					{
						Quaternion quaternion = Quaternion.LookRotation((Vector3)(&vector), (Vector3)(&x));
						Quaternion rotation = rb.rotation;
						fixedDeltaTime = Time.fixedDeltaTime;
						num6 = quaternion.x;
						x = rotation.x;
						rigidbody = rb;
						goto IL_046a;
					}
				}
				goto IL_04bc;
			}
			object obj7 = this + 48;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
			Transform transform2 = base.transform;
			Vector3 up = transform2.up;
			Quaternion quaternion2 = Quaternion.FromToRotation((Vector3)(&vector), (Vector3)(&x));
			Transform transform3 = base.transform;
			Quaternion rotation2 = transform3.rotation;
			float num7 = rotation2.w * quaternion2.x;
			float num8 = rotation2.z * quaternion2.y;
			float num9 = rotation2.x * quaternion2.w;
			float num10 = num9 + num7;
			float num11 = rotation2.y * quaternion2.z;
			float num12 = num10 + num8;
			float num13 = num12 - num11;
			Quaternion rotation3 = rb.rotation;
			fixedDeltaTime = Time.fixedDeltaTime;
			num6 = num13;
			x = rotation3.x;
			rigidbody = rb;
			goto IL_046a;
		}
		if (!rb.isKinematic)
		{
			rb.isKinematic = true;
			Vector3 velocity2 = rb.velocity;
			savedVelocity = (Vector3)velocity2.x;
			_ = velocity2.z;
		}
		return;
		IL_04bc:
		Transform transform4 = base.transform;
		Vector3 position2 = transform4.position;
		float num14 = MapInfo.DespawnEnemyHeight();
		if (num14 > position2.y)
		{
			Die();
		}
		if (MyTime.time > deadTime)
		{
			Die();
		}
		isClimbingWall = false;
		return;
		IL_046a:
		float t = fixedDeltaTime * 10f;
		Quaternion quaternion3 = Quaternion.Slerp((Quaternion)(&x), (Quaternion)(&num6), t);
		rigidbody.MoveRotation((Quaternion)(&num6));
		goto IL_04bc;
	}

	private unsafe void TryClimb()
	{
		//IL_00ab: Expected I, but got O
		//IL_003d: Expected O, but got Ref
		//IL_007e: Expected O, but got Ref
		Transform transform = base.transform;
		Vector3 position = transform.position;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rax_v7 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ rcx_v6 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
		float num3 = 0f * 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ rcx_v6 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
		float num4 = 0f * 0.5f;
		float num5 = num3 + position.y;
		float num6 = num4 + position.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		GameManager instance = GameManager.Instance;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
		object obj = default(object);
		int layerMask = default(int);
		if (Physics.SphereCast((Ray)(&obj), 0.3f, 2.5f, layerMask))
		{
			Vector3 velocity = rb.velocity;
			float num7 = default(float);
			rb.velocity = (Vector3)(&num7);
			isClimbingWall = true;
		}
	}

	private void CheckDead()
	{
		Transform transform = base.transform;
		Vector3 position = transform.position;
		float num = MapInfo.DespawnEnemyHeight();
		if (num > position.y)
		{
			Die();
		}
		if (MyTime.time > deadTime)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 112 Invalid \"Jump target not found in method: 0x18049AC70\"");
		}
	}

	private void Die()
	{
		dissapearFx.SetActive(value: true);
		Transform transform = dissapearFx.transform;
		transform.parentInternal = null;
		GameObject obj = base.gameObject;
		UnityEngine.Object.Destroy(obj);
	}
}
