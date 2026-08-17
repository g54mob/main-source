using System;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts._Data.Hats;

[Serializable]
public class HatOrientation
{
	public ECharacter character;

	public EMeshForHat meshForHat;

	public Vector3 pos;

	public Vector3 rot;

	public Vector3 scale;

	public HatOrientation()
	{
		//IL_0013: Expected I, but got O
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rax_v2 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		scale = Vector3.oneVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ rdx_v1 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
	}
}
