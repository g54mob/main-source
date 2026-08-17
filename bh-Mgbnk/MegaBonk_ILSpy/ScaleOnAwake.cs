using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class ScaleOnAwake : MonoBehaviour
{
	private Vector3 defaultScale;

	public float scaleTime = 0.5f;

	private float t;

	private unsafe void OnEnable()
	{
		//IL_0066: Expected I, but got O
		//IL_00a3: Expected O, but got I
		//IL_00c0: Expected O, but got I
		//IL_010a: Invalid comparison between F4 and O
		//IL_004c: Expected O, but got Ref
		//IL_0030: Expected O, but got F4
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rax_v2 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		object obj = defaultScale - Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ScaleOnAwake)+24]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rcx_v2 (Il2CppStaticFields<UnityEngine.Vector3>)+4]");
		object obj2 = num3 - 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ScaleOnAwake)+28]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rcx_v2 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		object obj3 = num4 - 0;
		object obj4 = obj2 * obj2;
		object obj5 = obj * obj;
		object obj6 = obj3 * obj3;
		object obj7 = obj4 + obj5;
		object obj8 = obj7 + obj6;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8))
		{
			Transform transform = base.transform;
			Vector3 localScale = transform.localScale;
			defaultScale = (Vector3)localScale.x;
			_ = localScale.z;
		}
		Transform transform2 = base.transform;
		object obj9 = default(object);
		transform2.localScale = (Vector3)(&obj9);
		t = 0f;
	}

	private void FindScale()
	{
		//IL_002b: Expected O, but got F4
		Transform transform = base.transform;
		Vector3 localScale = transform.localScale;
		defaultScale = (Vector3)localScale.x;
		_ = localScale.z;
	}

	private unsafe void Update()
	{
		//IL_00c1: Invalid comparison between I4 and F4
		//IL_010c: Expected F4, but got I4
		//IL_0176: Invalid comparison between I4 and F4
		//IL_0148: Expected F4, but got I4
		//IL_015a: Expected O, but got Ref
		if (!(t < 1f))
		{
			return;
		}
		float deltaTime = Time.deltaTime;
		float num = deltaTime / scaleTime;
		float num2 = num + t;
		t = num2;
		Transform transform = base.transform;
		Transform transform2 = base.transform;
		Vector3 localScale = transform2.localScale;
		float num3 = t;
		if (!(0f > t))
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
		float num4 = Easing.InOutCirc(num3);
		if (!(0f > num4))
		{
			if (num4 > 1f)
			{
				num4 = 1f;
			}
		}
		else
		{
			num4 = 0f;
		}
		float num5 = default(float);
		transform.localScale = (Vector3)(&num5);
	}
}
