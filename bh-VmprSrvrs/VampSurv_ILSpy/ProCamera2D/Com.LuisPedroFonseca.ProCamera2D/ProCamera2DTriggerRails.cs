using System;
using Cpp2ILInjected;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D;

public class ProCamera2DTriggerRails : BaseTrigger
{
	public static string TriggerName = "Rails Trigger";

	public ProCamera2DRails ProCamera2DRails;

	public TriggerRailsMode Mode;

	public float TransitionDuration;

	private void Start()
	{
		ProCamera2D proCamera2D = base.ProCamera2D;
		if ((object)proCamera2D != null && ((UnityEngine.Object)proCamera2D).m_CachedPtr != (IntPtr)0)
		{
			ProCamera2DRails proCamera2DRails = ProCamera2DRails;
			if ((object)ProCamera2DRails == null || ((UnityEngine.Object)proCamera2DRails).m_CachedPtr == (IntPtr)0)
			{
				ProCamera2DRails proCamera2DRails2 = UnityEngine.Object.FindObjectOfType<ProCamera2DRails>();
				ProCamera2DRails = proCamera2DRails2;
			}
			ProCamera2DRails proCamera2DRails3 = ProCamera2DRails;
			if ((object)ProCamera2DRails == null || ((UnityEngine.Object)proCamera2DRails3).m_CachedPtr == (IntPtr)0)
			{
				Debug.LogWarning("Rails extension couldn't be found on ProCamera2D. Please enable it to use this trigger.");
			}
		}
	}

	protected override void EnteredTrigger()
	{
		bool flag = OnEnteredTrigger == null;
		_insideTrigger = true;
		if (!flag)
		{
			Action onEnteredTrigger = OnEnteredTrigger;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v14.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		if (Mode != TriggerRailsMode.Enable)
		{
			ProCamera2DRails.DisableTargets(TransitionDuration);
		}
		else
		{
			ProCamera2DRails.EnableTargets(TransitionDuration);
		}
	}

	public ProCamera2DTriggerRails()
	{
		//IL_0036: Expected I, but got O
		TransitionDuration = 1f;
		UpdateInterval = 0.1f;
		UseTargetsMidPoint = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
