using System;
using Cpp2ILInjected;
using Unity.Advertisement.IosSupport.Components;
using UnityEngine;
using VampireSurvivors.App.Framework.System;

namespace VampireSurvivors.App.Scripts.Framework.Initialisation;

public static class ServicesIntegration
{
	public static void InitServices(UnityServicesManager unityServicesManager, Action completeCallback)
	{
		if (completeCallback != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: completeCallback.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private static void CheckIOSTracking(UnityServicesManager unityServicesManager, Action completeCallback)
	{
		Debug.Log("Unity iOS Support: App Tracking Transparency status not checked, because the platform is not iOS.");
		if (completeCallback != null)
		{
			IntPtr method = ((Delegate)completeCallback).method;
			IntPtr method_code = ((Delegate)completeCallback).method_code;
			IntPtr invoke_impl = ((Delegate)completeCallback).invoke_impl;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v61 @ rax_v4 (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private static ContextScreenView GetContextScreenPrefab()
	{
		return Resources.Load<ContextScreenView>("ContextScreenPrefab");
	}
}
