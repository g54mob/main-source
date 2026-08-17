using System;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Tools;

namespace VampireSurvivors;

public class UICameraResizer : MonoBehaviour
{
	private Camera _mainCam;

	private void Update()
	{
		Camera mainCam = _mainCam;
		if ((object)_mainCam == null || ((UnityEngine.Object)mainCam).m_CachedPtr == (IntPtr)0)
		{
			Camera main = Camera.main;
			_mainCam = main;
		}
		Camera mainCam2 = _mainCam;
		if ((object)_mainCam != null && ((UnityEngine.Object)mainCam2).m_CachedPtr != (IntPtr)0)
		{
			int2 renderTextureSize = CameraExtensions.GetRenderTextureSize(_mainCam);
			object obj = (object)renderTextureSize >> 32;
			float num = (float)obj * 0.5f;
			float orthographicSize = num * 0.01f;
			_mainCam.orthographicSize = orthographicSize;
		}
	}

	public UICameraResizer()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
