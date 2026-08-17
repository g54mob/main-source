using System;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.UI;

public class UIFollowPosition : MonoBehaviour
{
	private RectTransform _Target;

	private void Update()
	{
		Transform transform = base.transform;
		RectTransform target = _Target;
		bool flag = ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)target).m_CachedPtr, out Vector3 _);
		bool flag2 = (object)transform == null;
		bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
	}

	public UIFollowPosition()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
