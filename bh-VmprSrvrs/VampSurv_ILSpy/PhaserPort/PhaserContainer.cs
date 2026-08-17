using Cpp2ILInjected;
using UnityEngine;

public class PhaserContainer : PhaserGameObject
{
	public unsafe Matrix4x4 getBoundsTransformMatrix()
	{
		//IL_0013: Expected I, but got O
		//IL_0031: Expected F4, but got O
		//IL_002c: Expected native int or pointer, but got O
		//IL_0046: Expected F4, but got I
		//IL_0041: Expected native int or pointer, but got O
		//IL_005b: Expected F4, but got I
		//IL_0056: Expected native int or pointer, but got O
		//IL_0070: Expected F4, but got I
		//IL_006b: Expected native int or pointer, but got O
		nint num = (nint)typeof(Matrix4x4);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v2 (Il2CppClass<UnityEngine.Matrix4x4>)+B8]");
		nint num2 = 0;
		Matrix4x4 matrix4x = default(Matrix4x4);
		((Matrix4x4*)(nint)matrix4x)->m00 = (float)Matrix4x4.identityMatrix;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rdx_v1 (Il2CppStaticFields<UnityEngine.Matrix4x4>)+50]");
		((Matrix4x4*)(nint)matrix4x)->m01 = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rdx_v1 (Il2CppStaticFields<UnityEngine.Matrix4x4>)+60]");
		((Matrix4x4*)(nint)matrix4x)->m02 = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rdx_v1 (Il2CppStaticFields<UnityEngine.Matrix4x4>)+70]");
		((Matrix4x4*)(nint)matrix4x)->m03 = 0f;
		return matrix4x;
	}

	public PhaserContainer()
	{
		//IL_0020: Expected I, but got O
		((GameMonoBehaviour)this)._onResumeSent = true;
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
