using System;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.App.Tools;

public class ClearUnusedAssets : MonoBehaviour
{
	private void Awake()
	{
		//IL_004d: Expected I4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B363E0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9F8]");
		if ((nint)0 != 0)
		{
			GC.InternalCollect((int)typeof(GC));
		}
		IntPtr intPtr = Resources.UnloadUnusedAssets_Injected();
		if (intPtr != (IntPtr)0)
		{
			AsyncOperation asyncOperation = AsyncOperation.BindingsMarshaller.ConvertToManaged(intPtr);
		}
	}

	public ClearUnusedAssets()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
