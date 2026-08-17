using System;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Objects;

public class ColorFilter : MonoBehaviour
{
	public Color color;

	public static Action<ColorFilter> A_FilterEnter;

	public static Action<ColorFilter> A_FilterExit;

	private void OnTriggerEnter(Collider c)
	{
		GameObject gameObject = c.gameObject;
		if (gameObject.CompareTag("MainCamera"))
		{
			Action<ColorFilter> a_FilterEnter = A_FilterEnter;
			if (A_FilterEnter != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v117 @ rax_v8 (System.Action`1<Assets.Scripts.Objects.ColorFilter>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	private void OnTriggerExit(Collider c)
	{
		GameObject gameObject = c.gameObject;
		if (gameObject.CompareTag("MainCamera"))
		{
			Action<ColorFilter> a_FilterExit = A_FilterExit;
			if (A_FilterExit != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v117 @ rax_v8 (System.Action`1<Assets.Scripts.Objects.ColorFilter>)+18] (should have been resolved before IL gen)");
			}
		}
	}
}
