using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;

public class FakeRigidBodyMover : MonoBehaviour
{
	public float mass;

	public float drag;

	public float angularDrag;

	public bool useGravity;

	public Vector3 customGravity;

	private bool showDebugInfo;

	private Vector3 velocity;

	public Vector3 angularVelocity;

	public bool isKinematic;

	private Vector3 effectiveGravity;

	public unsafe Vector3 Velocity
	{
		get
		{
			//IL_000f: Expected F4, but got O
			//IL_000a: Expected native int or pointer, but got O
			//IL_0024: Expected F4, but got I
			//IL_001f: Expected native int or pointer, but got O
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = (float)velocity;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (FakeRigidBodyMover)+48]");
			((Vector3*)(nint)vector)->z = 0f;
			return vector;
		}
		set
		{
			//IL_000f: Expected O, but got F4
			velocity = (Vector3)value.x;
			_ = value.z;
		}
	}

	public unsafe Vector3 AngularVelocity
	{
		get
		{
			//IL_000f: Expected F4, but got O
			//IL_000a: Expected native int or pointer, but got O
			//IL_0024: Expected F4, but got I
			//IL_001f: Expected native int or pointer, but got O
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = (float)angularVelocity;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (FakeRigidBodyMover)+54]");
			((Vector3*)(nint)vector)->z = 0f;
			return vector;
		}
		set
		{
			//IL_000f: Expected O, but got F4
			angularVelocity = (Vector3)value.x;
			_ = value.z;
		}
	}

	public bool IsKinematic
	{
		get
		{
			return isKinematic;
		}
		set
		{
			isKinematic = value;
		}
	}

	public float Mass
	{
		get
		{
			return mass;
		}
		set
		{
			mass = value;
		}
	}

	public float Drag
	{
		get
		{
			return drag;
		}
		set
		{
			drag = value;
		}
	}

	public float AngularDrag
	{
		get
		{
			return angularDrag;
		}
		set
		{
			angularDrag = value;
		}
	}

	public bool UseGravity
	{
		get
		{
			return useGravity;
		}
		set
		{
			useGravity = value;
		}
	}

	private void Start()
	{
		//IL_0071: Expected O, but got I
		//IL_008e: Expected O, but got I
		//IL_001f: Expected O, but got I
		//IL_00e7: Expected O, but got I4
		object obj = (object)customGravity * (object)customGravity;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (FakeRigidBodyMover)+34]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (FakeRigidBodyMover)+34]");
		object obj2 = num * 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (FakeRigidBodyMover)+38]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (FakeRigidBodyMover)+38]");
		object obj3 = num2 * 0;
		object obj4 = obj + obj2;
		object obj5 = obj4 + obj3;
		Vector3 vector;
		if ((nint)obj5 > 0)
		{
			vector = customGravity;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (FakeRigidBodyMover)+38]");
			object obj6 = 0;
		}
		else
		{
			Physics.get_gravity_Injected(out Vector3 ret);
			vector = ret;
			object obj6 = 0;
		}
		effectiveGravity = vector;
	}

	private unsafe void Update()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_061f: Expected O, but got F4
		//IL_012d: Expected O, but got F4
		//IL_00e3: Expected O, but got F4
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Expected O, but got Unknown
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Expected O, but got Unknown
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Expected O, but got Unknown
		//IL_067d: Expected O, but got F4
		//IL_0690: Unknown result type (might be due to invalid IL or missing references)
		//IL_0695: Expected O, but got Unknown
		//IL_06a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ab: Expected O, but got Unknown
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Expected O, but got Unknown
		//IL_0260: Expected O, but got I
		//IL_027d: Expected O, but got I
		//IL_02c0: Expected O, but got F4
		//IL_06c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c8: Expected O, but got Unknown
		//IL_06d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d6: Expected O, but got Unknown
		//IL_0323: Unknown result type (might be due to invalid IL or missing references)
		//IL_0328: Expected O, but got Unknown
		//IL_0357: Expected O, but got I
		//IL_0374: Expected O, but got I
		//IL_0391: Expected O, but got I
		//IL_03ae: Expected O, but got I
		//IL_03d8: Expected O, but got I
		//IL_03f5: Expected O, but got I
		//IL_041f: Expected O, but got I
		//IL_043c: Expected O, but got I
		//IL_0466: Expected O, but got I
		//IL_0490: Expected O, but got I
		//IL_04ba: Expected O, but got I
		//IL_04d7: Expected O, but got I
		//IL_0501: Expected O, but got I
		//IL_051e: Expected O, but got I
		//IL_0548: Expected O, but got I
		//IL_0572: Expected O, but got I
		//IL_05fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ff: Expected O, but got Unknown
		//IL_02b2->IL00cd: Incompatible stack heights: 2 vs 0
		//IL_070f->IL00c6: Incompatible stack heights: 2 vs 0
		//IL_0616->IL00cd: Incompatible stack heights: 5 vs 0
		object obj2 = default(object);
		object obj = obj2 - 95;
		if (isKinematic)
		{
			return;
		}
		Vector3 vector = default(Vector3);
		if (useGravity)
		{
			_ = velocity;
			_ = effectiveGravity;
			object obj3 = Time.deltaTime;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rcx_v78 (FakeRigidBodyMover)+64]");
			object obj4 = 0 * effectiveGravity;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rcx_v78 (FakeRigidBodyMover)+48]");
			object obj5 = obj4 + 0;
			velocity = vector;
		}
		_ = velocity;
		object obj6 = Time.deltaTime;
		float num = (float)velocity * drag;
		float num2 = 1f - num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rcx_v78 (FakeRigidBodyMover)+48]");
		float num3 = 0f * num2;
		velocity = vector;
		_ = angularVelocity;
		object obj7 = Time.deltaTime;
		float num4 = (float)angularVelocity * angularDrag;
		float num5 = 1f - num4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rcx_v78 (FakeRigidBodyMover)+54]");
		float num6 = 0f * num5;
		angularVelocity = vector;
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			_ = 0;
			_ = 0;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			object obj8 = obj - 57;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj8);
			_ = velocity;
			object obj9 = Time.deltaTime;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rcx_v78 (FakeRigidBodyMover)+48]");
			object obj10 = 0 * velocity;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-31]");
			object obj11 = obj10 + 0;
			bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			object obj12 = obj - 41;
			Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)obj12);
			object obj13 = (object)angularVelocity * (object)angularVelocity;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rcx_v78 (FakeRigidBodyMover)+50]");
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rcx_v78 (FakeRigidBodyMover)+50]");
			object obj14 = num7 * 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rcx_v78 (FakeRigidBodyMover)+54]");
			nint num8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rcx_v78 (FakeRigidBodyMover)+54]");
			object obj15 = num8 * 0;
			object obj16 = obj13 + obj14;
			object obj17 = obj16 + obj15;
			if ((nint)obj17 <= 0)
			{
				return;
			}
			_ = angularVelocity;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rcx_v78 (FakeRigidBodyMover)+54]");
			float num9 = 0f * 57.29578f;
			object obj18 = Time.deltaTime;
			float num10 = num9 * (float)angularVelocity;
			float num11 = num10 * ((float)Math.PI / 180f);
			_ = 0;
			object obj19 = obj - 57;
			object obj20 = obj - 41;
			Quaternion.Internal_FromEulerRad_Injected(ref *(Vector3*)obj20, out *(Quaternion*)obj19);
			Transform transform2 = base.transform;
			Transform transform3 = base.transform;
			if ((object)transform3 != null)
			{
				_ = 0;
				bool flag3 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
				object obj21 = obj - 41;
				Transform.get_rotation_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out *(Quaternion*)obj21);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-1D]");
				nint num12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-39]");
				object obj22 = num12 * 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-25]");
				nint num13 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-31]");
				object obj23 = num13 * 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-29]");
				nint num14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-2D]");
				object obj24 = num14 * 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-25]");
				nint num15 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-2D]");
				object obj25 = num15 * 0;
				object obj26 = obj24 + obj22;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-21]");
				nint num16 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-2D]");
				object obj27 = num16 * 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-21]");
				nint num17 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-35]");
				object obj28 = num17 * 0;
				object obj29 = obj26 + obj23;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-21]");
				nint num18 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-39]");
				object obj30 = num18 * 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-21]");
				nint num19 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-31]");
				object obj31 = num19 * 0;
				object obj32 = obj29 - obj28;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-1D]");
				nint num20 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-35]");
				object obj33 = num20 * 0;
				object obj34 = obj25 + obj33;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-29]");
				nint num21 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-31]");
				object obj35 = num21 * 0;
				object obj36 = obj34 + obj30;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-29]");
				nint num22 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-39]");
				object obj37 = num22 * 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-29]");
				nint num23 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-35]");
				object obj38 = num23 * 0;
				object obj39 = obj36 - obj35;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-1D]");
				nint num24 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-31]");
				object obj40 = num24 * 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-1D]");
				nint num25 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-2D]");
				object obj41 = num25 * 0;
				object obj42 = obj27 + obj40;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-25]");
				nint num26 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-35]");
				object obj43 = num26 * 0;
				object obj44 = obj41 - obj37;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-25]");
				nint num27 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-39]");
				object obj45 = num27 * 0;
				object obj46 = obj42 + obj38;
				object obj47 = obj44 - obj43;
				object obj48 = obj46 - obj45;
				object obj49 = obj47 - obj31;
				bool flag4 = (object)transform2 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-39]");
				_ = 0;
				bool flag5 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				object obj50 = obj - 57;
				Transform.set_rotation_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Quaternion*)obj50);
				return;
			}
		}
		throw new NullReferenceException();
	}

	public void AddForce(Vector3 force, ForceMode mode = ForceMode.Force)
	{
		//IL_006a: Expected O, but got I8
		//IL_0089: Expected O, but got I8
		if (!isKinematic)
		{
			float num = mass;
			if (mode <= ForceMode.Acceleration)
			{
				object obj = 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v1+6941DF0+mode @ r8 (UnityEngine.ForceMode)*4]");
				object obj2 = 0 + 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v67 @ rcx_v2 (should have been resolved before IL gen)");
			}
		}
	}

	public unsafe void AddExplosionForce(float explosionForce, Vector3 explosionPosition, float explosionRadius, float upwardsModifier = 0f, ForceMode mode = ForceMode.Force)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected O, but got Unknown
		//IL_0178: Invalid comparison between F4 and O
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		//IL_008d: Invalid comparison between O and F4
		//IL_01d6: Expected I, but got O
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Expected O, but got Unknown
		//IL_0219: Expected O, but got I
		//IL_0236: Expected O, but got I
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Expected O, but got Unknown
		//IL_026e: Invalid comparison between O and F4
		//IL_019d: Expected I, but got O
		//IL_01bd: Expected O, but got I
		//IL_0306: Unknown result type (might be due to invalid IL or missing references)
		//IL_030b: Expected O, but got Unknown
		//IL_0290: Expected I, but got O
		//IL_02b0: Expected O, but got I
		//IL_018a->IL00e9: Incompatible stack heights: 1 vs 0
		//IL_0330->IL00e9: Incompatible stack heights: 1 vs 0
		object obj2 = default(object);
		object obj = obj2 - 71;
		if (isKinematic)
		{
			return;
		}
		Transform transform = base.transform;
		_ = 0;
		_ = 0;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		object obj3 = obj - 81;
		Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-49]");
		object obj4 = 0 - explosionPosition.z;
		object obj5 = obj - 81;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A8670");
		object obj6 = default(object);
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)explosionRadius) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6))
		{
			object obj7 = obj - 81;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C6C6E0");
			object obj9;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1E-05f))
			{
				object obj8 = obj4 / obj6;
				obj9 = obj8;
			}
			else
			{
				nint num = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ rax_v31 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ rcx_v24 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
				obj9 = 0;
				_ = Vector3.zeroVector;
			}
			nint num3 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v468 @ rax_v20 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num4 = 0;
			Vector3 upVector = Vector3.upVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+6F]");
			object obj10 = upVector * 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v469 @ rcx_v15 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+6F]");
			object obj11 = num5 * 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v469 @ rcx_v15 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+6F]");
			object obj12 = num6 * 0;
			object obj13 = obj9 + obj12;
			object obj14 = obj - 81;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C6C6E0");
			object obj16;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1E-05f))
			{
				object obj15 = obj13 / obj6;
				obj16 = obj15;
			}
			else
			{
				nint num7 = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v530 @ rax_v26 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v531 @ rcx_v20 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
				obj16 = 0;
				_ = Vector3.zeroVector;
			}
			float num9 = (float)obj16 * explosionForce;
			float num10 = (float)obj6 / explosionRadius;
			float num11 = 1f - num10;
			float num12 = num9 * num11;
			Vector3 force = (Vector3)(obj - 81);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+77]");
			AddForce(force);
		}
	}

	public void AddTorque(Vector3 torque, ForceMode mode = ForceMode.Force)
	{
		//IL_006a: Expected O, but got I8
		//IL_0089: Expected O, but got I8
		if (!isKinematic)
		{
			float num = mass;
			if (mode <= ForceMode.Acceleration)
			{
				object obj = 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v1+69422D0+mode @ r8 (UnityEngine.ForceMode)*4]");
				object obj2 = 0 + 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v67 @ rcx_v2 (should have been resolved before IL gen)");
			}
		}
	}

	public void ResetPhysics()
	{
		//IL_0013: Expected I, but got O
		//IL_004e: Expected I, but got O
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		velocity = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rdx_v1 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		nint num3 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rax_v5 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num4 = 0;
		angularVelocity = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		isKinematic = true;
	}

	private unsafe void OnDrawGizmos()
	{
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		//IL_010e: Expected O, but got I
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Expected O, but got Unknown
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Expected O, but got Unknown
		//IL_0286: Expected O, but got I
		//IL_02a3: Expected O, but got I
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Expected O, but got Unknown
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Expected O, but got Unknown
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Expected O, but got Unknown
		//IL_02e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02eb: Expected O, but got Unknown
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f9: Expected O, but got Unknown
		//IL_02d8->IL0079: Incompatible stack heights: 1 vs 0
		//IL_030b->IL0079: Incompatible stack heights: 3 vs 0
		if (showDebugInfo && !isKinematic)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F50]");
			_ = 0;
			object obj2 = default(object);
			object obj = obj2 - 16;
			Gizmos.set_color_Injected(ref *(Color*)obj);
			Transform transform = base.transform;
			_ = 0;
			_ = 0;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			object obj3 = obj2 - 48;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj3);
			_ = velocity;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-28]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (FakeRigidBodyMover)+48]");
			object obj4 = num + 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-28]");
			_ = 0;
			object obj5 = obj2 - 32;
			object obj6 = obj2 - 16;
			Gizmos.DrawLine_Injected(ref *(Vector3*)obj6, ref *(Vector3*)obj5);
			object obj7 = (object)angularVelocity * (object)angularVelocity;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (FakeRigidBodyMover)+50]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (FakeRigidBodyMover)+50]");
			object obj8 = num2 * 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (FakeRigidBodyMover)+54]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (FakeRigidBodyMover)+54]");
			object obj9 = num3 * 0;
			object obj10 = obj7 + obj8;
			object obj11 = obj10 + obj9;
			if ((nint)obj11 > 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12400]");
				_ = 0;
				object obj12 = obj2 - 48;
				Gizmos.set_color_Injected(ref *(Color*)obj12);
				Vector3 vector = (Vector3)(this + 76);
				Vector3 normalized = ((Vector3*)vector)->normalized;
				_ = normalized.x;
				Transform transform2 = base.transform;
				bool flag2 = (object)transform2 == null;
				_ = 0;
				_ = 0;
				bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				object obj13 = obj2 - 48;
				Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out *(Vector3*)obj13);
				float num4 = normalized.z * 2f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-28]");
				float num5 = 0f + num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-28]");
				_ = 0;
				object obj14 = obj2 - 16;
				object obj15 = obj2 - 32;
				Gizmos.DrawLine_Injected(ref *(Vector3*)obj15, ref *(Vector3*)obj14);
			}
		}
	}

	public FakeRigidBodyMover()
	{
		//IL_0041: Expected I, but got O
		//IL_00c2: Expected I, but got O
		//IL_007c: Expected I, but got O
		//IL_00fd: Expected I, but got O
		mass = 1f;
		drag = 1f;
		angularDrag = 1f;
		useGravity = true;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		customGravity = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v2 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		nint num3 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rax_v5 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num4 = 0;
		velocity = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rdx_v1 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		nint num5 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v8 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num6 = 0;
		angularVelocity = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rcx_v5 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		isKinematic = true;
		nint num7 = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rcx_v7 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
