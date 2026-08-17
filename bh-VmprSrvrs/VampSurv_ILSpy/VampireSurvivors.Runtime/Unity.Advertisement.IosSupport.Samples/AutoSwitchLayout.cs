using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;

namespace Unity.Advertisement.IosSupport.Samples;

public class AutoSwitchLayout : MonoBehaviour
{
	public Transform portraitModeLayoutTransform;

	public Transform landscapeModeLayoutTransform;

	private float m_PreviousAspectRatio;

	private void Update()
	{
		//IL_01df: Expected O, but got I4
		//IL_0149: Expected O, but got I4
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Expected O, but got Unknown
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Expected O, but got Unknown
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Expected O, but got Unknown
		//IL_0248: Invalid comparison between F4 and O
		object obj = Screen.width;
		object obj2 = Screen.height;
		float num = (float)obj / (float)obj2;
		float num2 = m_PreviousAspectRatio - num;
		float previousAspectRatio = m_PreviousAspectRatio;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj3 = previousAspectRatio & 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj4 = num & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
		{
			obj4 = obj3;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj5 = num2 & 0;
		float num3 = Mathf.Epsilon * 8f;
		float num4 = (float)obj4 * 1E-06f;
		if (num4 < num3)
		{
			num4 = num3;
		}
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num4) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5))
		{
			return;
		}
		Transform transform = portraitModeLayoutTransform;
		if ((object)portraitModeLayoutTransform != null && ((UnityEngine.Object)transform).m_CachedPtr != (IntPtr)0 && (bool)landscapeModeLayoutTransform)
		{
			m_PreviousAspectRatio = num;
			Component component;
			if (!(num > 1f))
			{
				GameObject gameObject = portraitModeLayoutTransform.gameObject;
				gameObject.SetActive(value: true);
				component = landscapeModeLayoutTransform;
			}
			else
			{
				GameObject gameObject2 = landscapeModeLayoutTransform.gameObject;
				gameObject2.SetActive(value: true);
				component = portraitModeLayoutTransform;
			}
			GameObject gameObject3 = component.gameObject;
			gameObject3.SetActive(value: false);
		}
	}

	public AutoSwitchLayout()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
