using System;
using Cpp2ILInjected;
using UnityEngine;

namespace Doozy.Engine.Progress;

public class ProgressTargetAnimator : ProgressTarget
{
	public Animator Animator;

	public string ParameterName;

	public TargetProgress TargetProgress;

	public override void UpdateTarget(Progressor progressor)
	{
		Animator animator = Animator;
		if ((object)Animator == null || ((UnityEngine.Object)animator).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		GameObject gameObject = Animator.gameObject;
		if (gameObject.activeSelf && Animator.isActiveAndEnabled)
		{
			float value;
			if (TargetProgress == TargetProgress.Progress)
			{
				float progress = progressor.Progress;
				value = progress;
			}
			else
			{
				float progress2 = progressor.Progress;
				value = 1f - progress2;
			}
			Animator.SetFloatString(ParameterName, value);
		}
	}

	private void Reset()
	{
		Animator animator = Animator;
		if ((object)Animator == null || ((UnityEngine.Object)animator).m_CachedPtr == (IntPtr)0)
		{
			Animator component = GetComponent<Animator>();
			Animator = component;
		}
	}

	private void UpdateReference()
	{
		Animator animator = Animator;
		if ((object)Animator == null || ((UnityEngine.Object)animator).m_CachedPtr == (IntPtr)0)
		{
			Animator component = GetComponent<Animator>();
			Animator = component;
		}
	}

	public ProgressTargetAnimator()
	{
		//IL_0058: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980AF5]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		ParameterName = "Progress";
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rcx_v4 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
