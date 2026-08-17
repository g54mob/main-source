using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace Doozy.Engine.Progress;

public class ProgressTargetImage : ProgressTarget
{
	public Image Image;

	public TargetProgress TargetProgress;

	public override void UpdateTarget(Progressor progressor)
	{
		Image image = Image;
		if ((object)Image != null && ((UnityEngine.Object)image).m_CachedPtr != (IntPtr)0)
		{
			float fillAmount;
			if (TargetProgress == TargetProgress.Progress)
			{
				float progress = progressor.Progress;
				fillAmount = progress;
			}
			else
			{
				float progress2 = progressor.Progress;
				fillAmount = 1f - progress2;
			}
			Image.fillAmount = fillAmount;
		}
	}

	private void Reset()
	{
		Image image = Image;
		if ((object)Image == null || ((UnityEngine.Object)image).m_CachedPtr == (IntPtr)0)
		{
			Image component = GetComponent<Image>();
			Image = component;
		}
	}

	private void UpdateReference()
	{
		Image image = Image;
		if ((object)Image == null || ((UnityEngine.Object)image).m_CachedPtr == (IntPtr)0)
		{
			Image component = GetComponent<Image>();
			Image = component;
		}
	}

	public ProgressTargetImage()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
