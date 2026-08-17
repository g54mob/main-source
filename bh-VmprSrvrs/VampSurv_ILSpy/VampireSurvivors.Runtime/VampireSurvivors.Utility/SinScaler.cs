using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.Utility;

public class SinScaler : MonoBehaviour
{
	public float Min;

	public float Max;

	public float Speed;

	private float _restartTime;

	private void Update()
	{
		//IL_0045: Expected O, but got F4
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		//IL_000e: Invalid comparison between O and F4
		object obj = Time.timeSinceLevelLoad;
		object obj3 = default(object);
		object obj2 = obj3 - _restartTime;
		object obj4 = obj2 * Speed;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj5 = obj4 & 0;
		if (0 > (nint)obj5 || System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f))
		{
		}
		Transform transform = base.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
	}

	public void RestartFromMin()
	{
		//IL_000e: Expected O, but got F4
		object obj = Time.timeSinceLevelLoad;
		float restartTime = default(float);
		_restartTime = restartTime;
	}

	public void Reset()
	{
		_restartTime = 0f;
	}

	public SinScaler()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
