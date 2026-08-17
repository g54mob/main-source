using System;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI.DynamicWindows;

public class DWindowPrompt : DWindowBase
{
	public TextMeshProUGUI t_header;

	public TextMeshProUGUI t_content;

	private Action A_Accept;

	public void Set(string header, string content, Action A_Accept)
	{
		t_header.text = header;
		t_content.text = content;
		this.A_Accept = A_Accept;
		base.rebuildAfterFrames = 3;
	}

	public void Accept()
	{
		Action a_Accept = A_Accept;
		if (A_Accept != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		GameObject obj = base.gameObject;
		UnityEngine.Object.Destroy(obj);
	}

	public void Close()
	{
		GameObject obj = base.gameObject;
		UnityEngine.Object.Destroy(obj);
	}

	public DWindowPrompt()
	{
		//IL_000f: Expected I4, but got I8
		base.rebuildAfterFrames = -1;
		((MonoBehaviour)this)._002Ector();
	}
}
