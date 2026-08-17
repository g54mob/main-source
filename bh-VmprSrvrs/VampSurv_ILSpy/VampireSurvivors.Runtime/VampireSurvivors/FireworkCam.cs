using System;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors;

public class FireworkCam : MonoBehaviour
{
	private Camera _UICam;

	private Camera _cam;

	private Camera _main;

	private void Start()
	{
		Camera main = Camera.main;
		_main = main;
		Camera component = GetComponent<Camera>();
		_cam = component;
	}

	private void Update()
	{
		//IL_0168: Expected O, but got F4
		Transform transform = base.transform;
		if ((object)_UICam != null)
		{
			Transform transform2 = _UICam.transform;
			if ((object)transform2 != null)
			{
				bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 ret);
				bool flag2 = (object)transform == null;
				bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				Transform main = (Transform)(object)_main;
				bool flag4 = (object)_main == null;
				bool flag5 = ((UnityEngine.Object)main).m_CachedPtr == (IntPtr)0;
				object obj = Camera.get_orthographicSize_Injected(((UnityEngine.Object)main).m_CachedPtr);
				bool flag6 = (object)_cam == null;
				float orthographicSize = (float)ret / 1.6f;
				_cam.orthographicSize = orthographicSize;
				return;
			}
		}
		throw new NullReferenceException();
	}

	public FireworkCam()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
