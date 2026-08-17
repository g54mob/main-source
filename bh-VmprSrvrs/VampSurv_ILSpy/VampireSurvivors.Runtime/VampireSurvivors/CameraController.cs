using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Framework;

namespace VampireSurvivors;

public class CameraController : MonoBehaviour
{
	private void LateUpdate()
	{
		GameManager core = GM.Core;
		if ((object)GM.Core != null && ((UnityEngine.Object)core).m_CachedPtr != (IntPtr)0)
		{
			GM.Core.HandleCameraUpdate();
		}
	}

	public CameraController()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
