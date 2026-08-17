using System;
using Cpp2ILInjected;
using UnityEngine;

public class LateFixedUpdate : MonoBehaviour
{
	public static Action A_LateUpdate;

	private void FixedUpdate()
	{
		Action a_LateUpdate = A_LateUpdate;
		if (A_LateUpdate != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v26.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}
}
