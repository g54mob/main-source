using System;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors.Player;
using Cpp2ILInjected;
using UnityEngine;

public class MinimapArrow : MonoBehaviour
{
	public Transform target;

	public MeshRenderer meshRenderer;

	private void Update()
	{
		UpdateBossArrow();
	}

	private unsafe void UpdateBossArrow()
	{
		//IL_0008: Expected O, but got Ref
		//IL_003b: Expected O, but got Ref
		//IL_007e: Expected O, but got Ref
		//IL_0535: Expected I, but got O
		//IL_04ed: Invalid comparison between I4 and F4
		//IL_01a6: Invalid comparison between F4 and I4
		//IL_0247: Expected O, but got Ref
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b5: Expected O, but got Unknown
		//IL_02c3: Expected O, but got Ref
		//IL_031e: Expected O, but got Ref
		//IL_0384: Expected O, but got Ref
		//IL_0392: Expected O, but got Ref
		//IL_05a1: Expected I, but got O
		//IL_0482: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Transform transform = MyPlayer.Instance.transform;
		Vector3 position = transform.position;
		Vector3 v = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
		_ = position.x;
		_ = position.z;
		Vector3 vector = VectorExtensions.XZVector(v);
		Vector3 position2 = target.position;
		Vector3 v2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
		_ = position2.x;
		_ = position2.z;
		Vector3 vector2 = VectorExtensions.XZVector(v2);
		nint num = (nint)typeof(Math);
		float num2 = vector.x - vector2.x;
		float num3 = vector.y - vector2.y;
		float num4 = vector.z - vector2.z;
		float num5 = num3 * num3;
		float num6 = num2 * num2;
		float num7 = num4 * num4;
		float num8 = num5 + num6;
		float num9 = num8 + num7;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v470 @ rcx_v10 (Il2CppClass<System.Math>)+E4]");
		if ((nint)0 <= (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
		}
		else
		{
			double num10 = Math.Sqrt(num9);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm6,xmm0\"");
		Renderer renderer;
		bool flag;
		if (!meshRenderer.enabled)
		{
			MyPlayer instance = MyPlayer.Instance;
			float orthographicSize = instance.minimapCamera.orthographicSize;
			float num11 = orthographicSize * 0.95f;
			if (!(0f > num11))
			{
				return;
			}
			renderer = meshRenderer;
			flag = true;
		}
		else
		{
			MyPlayer instance2 = MyPlayer.Instance;
			float orthographicSize2 = instance2.minimapCamera.orthographicSize;
			float num12 = orthographicSize2 * 0.95f;
			if (!(num12 > 0f))
			{
				Vector3 position3 = target.position;
				Transform transform2 = MyPlayer.Instance.transform;
				Vector3 position4 = transform2.position;
				float num13 = position3.x - position4.x;
				float num14 = position3.y - position4.y;
				float num15 = position3.z - position4.z;
				Vector3 v3 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
				Vector3 vector3 = VectorExtensions.XZVector(v3);
				_ = vector3.x;
				_ = vector3.z;
				Transform transform3 = base.transform;
				_ = 1070141403;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180301660");
				float z = vector3.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED90]");
				object obj3 = z ^ 0;
				Vector3 euler = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
				float num16 = (float)obj3 * 57.29578f;
				_ = 0;
				float num17 = num16 + 90f;
				float num18 = num17 * ((float)Math.PI / 180f);
				Quaternion quaternion = Quaternion.Internal_FromEulerRad(euler);
				Quaternion rotation = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
				_ = quaternion.x;
				transform3.rotation = rotation;
				Transform transform4 = base.transform;
				MyPlayer instance3 = MyPlayer.Instance;
				Transform transform5 = instance3.minimapCamera.transform;
				Vector3 position5 = transform5.position;
				object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
				object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
				MyPlayer instance4 = MyPlayer.Instance;
				float orthographicSize3 = instance4.minimapCamera.orthographicSize;
				object obj6 = default(object);
				float num19 = (float)obj6 * orthographicSize3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rax_v41+4]");
				float num20 = 0f * orthographicSize3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rax_v41+8]");
				float num21 = 0f * orthographicSize3;
				float num22 = num19 * 0.8f;
				float num23 = num20 * 0.8f;
				float num24 = num21 * 0.8f;
				float num25 = num22 + position5.x;
				float num26 = num23 + position5.y;
				float num27 = num24 + position5.z;
				nint num28 = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rax_v43 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num29 = 0;
				float num30 = (float)Vector3.downVector * 20f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rcx_v41 (Il2CppStaticFields<UnityEngine.Vector3>)+28]");
				float num31 = 0f * 20f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rcx_v41 (Il2CppStaticFields<UnityEngine.Vector3>)+2C]");
				float num32 = 0f * 20f;
				float num33 = num30 + num25;
				float num34 = num31 + num26;
				float num35 = num32 + num27;
				Vector3 position6 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
				transform4.position = position6;
				return;
			}
			renderer = meshRenderer;
			flag = false;
		}
		renderer.enabled = flag;
	}

	private bool IsVisible()
	{
		//IL_0041: Expected I4, but got O
		if ((object)meshRenderer != null)
		{
			return meshRenderer.enabled;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}
}
