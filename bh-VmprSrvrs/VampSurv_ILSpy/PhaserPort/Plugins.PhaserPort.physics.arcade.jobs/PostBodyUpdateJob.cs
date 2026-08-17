using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Jobs;

namespace Plugins.PhaserPort.physics.arcade.jobs;

public struct PostBodyUpdateJob : IJobParallelForTransform
{
	public NativeArray<bool> _enabledArray;

	public NativeArray<float2> _positionArray;

	public NativeArray<float2> _previousFrameArray;

	public NativeArray<float2> _deltaMaxArray;

	public NativeArray<bool> _movesArray;

	public NativeArray<int> _facingArray;

	public NativeArray<bool> _allowRotationArray;

	public NativeArray<float> _deltaZArray;

	public unsafe void Execute(int index, TransformAccess transform)
	{
		//IL_0060: Expected O, but got I
		//IL_0091: Expected O, but got I
		//IL_0520: Unknown result type (might be due to invalid IL or missing references)
		//IL_0525: Expected O, but got Unknown
		//IL_03c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cd: Expected O, but got Unknown
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Expected O, but got Unknown
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Expected O, but got Unknown
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Expected O, but got Unknown
		//IL_01e7: Expected O, but got I
		//IL_02da: Expected O, but got I
		//IL_044c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0451: Expected O, but got Unknown
		//IL_0467: Unknown result type (might be due to invalid IL or missing references)
		//IL_046c: Expected O, but got Unknown
		//IL_04e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ea: Expected O, but got Unknown
		//IL_04f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f8: Expected O, but got Unknown
		//IL_0553: Unknown result type (might be due to invalid IL or missing references)
		//IL_0558: Expected O, but got Unknown
		NativeArray<bool> enabledArray = _enabledArray;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [index @ rdx (System.Int32)+v10 @ rax_v1 (Unity.Collections.NativeArray`1<System.Boolean>)]");
		if ((nint)0 == 0)
		{
			return;
		}
		NativeArray<float2> positionArray = _positionArray;
		NativeArray<float2> previousFrameArray = _previousFrameArray;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rax_v3 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+index @ rdx (System.Int32)*8]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rax_v4 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+index @ rdx (System.Int32)*8]");
		object obj = num - 0;
		NativeArray<float2> positionArray2 = _positionArray;
		NativeArray<float2> previousFrameArray2 = _previousFrameArray;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v5 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+4+index @ rdx (System.Int32)*8]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v6 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+4+index @ rdx (System.Int32)*8]");
		object obj2 = num2 - 0;
		NativeArray<bool> movesArray = _movesArray;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [index @ rdx (System.Int32)+v39 @ rax_v7 (Unity.Collections.NativeArray`1<System.Boolean>)]");
		if ((nint)0 == 0)
		{
			return;
		}
		NativeArray<float2> deltaMaxArray = _deltaMaxArray;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v9 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+index @ rdx (System.Int32)*8]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000185014587h\"");
		if (!flag)
		{
			bool flag2 = obj == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018501458Fh\"");
			if (!flag2)
			{
				if (0 > (nint)obj)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v9 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+index @ rdx (System.Int32)*8]");
					object obj3 = 0 ^ -0f;
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v9 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+index @ rdx (System.Int32)*8]");
						obj = 0 ^ -0f;
						goto IL_037f;
					}
				}
				if ((nint)obj > 0)
				{
					object obj4 = obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v9 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+index @ rdx (System.Int32)*8]");
					if ((nint)obj4 > 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v9 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+index @ rdx (System.Int32)*8]");
						obj = 0;
					}
				}
			}
		}
		goto IL_037f;
		IL_03ae:
		_ = 0;
		_ = 0;
		object obj6 = default(object);
		object obj5 = obj6 - 96;
		TransformAccess.GetPosition(ref *(TransformAccess*)transform, out *(Vector3*)obj5);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-58]");
		_ = 0;
		object obj7 = obj6 - 80;
		TransformAccess.SetPosition(ref *(TransformAccess*)transform, ref *(Vector3*)obj7);
		if (0 <= (nint)obj)
		{
			if ((nint)obj > 0)
			{
				NativeArray<int> facingArray = _facingArray;
				_ = 4;
			}
		}
		else
		{
			NativeArray<int> facingArray2 = _facingArray;
			_ = 3;
		}
		if (0 <= (nint)obj2)
		{
			if ((nint)obj2 > 0)
			{
				NativeArray<int> facingArray3 = _facingArray;
				_ = 2;
			}
		}
		else
		{
			NativeArray<int> facingArray4 = _facingArray;
			_ = 1;
		}
		NativeArray<bool> allowRotationArray = _allowRotationArray;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [index @ rdx (System.Int32)+v629 @ rax_v19 (Unity.Collections.NativeArray`1<System.Boolean>)]");
		if ((nint)0 != 0)
		{
			_ = 0;
			object obj8 = obj6 - 96;
			TransformAccess.GetLocalRotation(ref *(TransformAccess*)transform, out *(Quaternion*)obj8);
			Quaternion quaternion2 = (Quaternion)(obj6 - 64);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-60]");
			_ = 0;
			Vector3 eulerAngles = ((Quaternion*)quaternion2)->eulerAngles;
			NativeArray<float> deltaZArray = _deltaZArray;
			float num3 = eulerAngles.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v736 @ rax_v25 (Unity.Collections.NativeArray`1<System.Single>)+index @ rdx (System.Int32)*4]");
			float num4 = num3 + 0f;
			_ = eulerAngles.x;
			float num5 = num4 * ((float)Math.PI / 180f);
			_ = 0;
			object obj9 = obj6 - 64;
			object obj10 = obj6 - 80;
			Quaternion.Internal_FromEulerRad_Injected(ref *(Vector3*)obj10, out *(Quaternion*)obj9);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-40]");
			_ = 0;
			object obj11 = obj6 - 96;
			TransformAccess.SetLocalRotation(ref *(TransformAccess*)transform, ref *(Quaternion*)obj11);
		}
		return;
		IL_037f:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v9 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+4+index @ rdx (System.Int32)*8]");
		bool flag3 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001850145C2h\"");
		if (!flag3)
		{
			bool flag4 = obj2 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001850145C9h\"");
			if (!flag4)
			{
				if (0 > (nint)obj2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v9 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+4+index @ rdx (System.Int32)*8]");
					object obj3 = 0 ^ -0f;
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v9 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+4+index @ rdx (System.Int32)*8]");
						obj2 = 0 ^ -0f;
						goto IL_03ae;
					}
				}
				if ((nint)obj2 > 0)
				{
					object obj12 = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v9 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+4+index @ rdx (System.Int32)*8]");
					if ((nint)obj12 > 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v9 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+4+index @ rdx (System.Int32)*8]");
						obj2 = 0;
					}
				}
			}
		}
		goto IL_03ae;
	}
}
