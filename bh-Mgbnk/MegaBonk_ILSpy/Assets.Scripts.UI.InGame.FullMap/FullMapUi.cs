using System;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.UI.InGame.FullMap;

public class FullMapUi : MonoBehaviour
{
	public static Action<bool> A_Toggle;

	private void OnEnable()
	{
		Action<bool> a_Toggle = A_Toggle;
		if (A_Toggle != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v26 @ rax_v3 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
		}
	}

	private void OnDisable()
	{
		Action<bool> a_Toggle = A_Toggle;
		if (A_Toggle != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v26 @ rax_v3 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
		}
	}
}
