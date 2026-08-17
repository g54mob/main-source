using System;
using Cpp2ILInjected;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D;

public class BasicBlit : MonoBehaviour
{
	public Material CurrentMaterial;

	private void OnRenderImage(RenderTexture src, RenderTexture dst)
	{
		Material currentMaterial = CurrentMaterial;
		if ((object)CurrentMaterial != null && ((UnityEngine.Object)currentMaterial).m_CachedPtr != (IntPtr)0)
		{
			Graphics.Blit(src, dst, CurrentMaterial);
		}
	}

	public BasicBlit()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
