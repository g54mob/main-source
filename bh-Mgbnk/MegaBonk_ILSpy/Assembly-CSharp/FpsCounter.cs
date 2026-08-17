using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;

public class FpsCounter : MonoBehaviour
{
	public TextMeshProUGUI text;

	private List<float> samples;

	private void Awake()
	{
		List<float> list = new List<float>();
		samples = list;
		InvokeRepeating("UpdateFps", 0.5f, 0.5f);
	}

	private void UpdateFps()
	{
		float num = Enumerable.Average(samples);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
		float num2 = default(float);
		string text = num2.ToString();
		this.text.text = text;
		List<float> list = new List<float>();
		samples = list;
	}

	private void Update()
	{
		//IL_0028: Expected O, but got I
		//IL_007d: Expected O, but got I
		float smoothDeltaTime = Time.smoothDeltaTime;
		float num = 1f / smoothDeltaTime;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
		List<float> list = samples;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rcx_v3 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rcx_v3 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rcx_v3 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ r8_v3+18]");
		if (num2 >= 0)
		{
			float item = default(float);
			list.AddWithResize(item);
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rcx_v3 (System.Collections.Generic.List`1<System.Single>)+18]");
		object obj2 = (nint)0 + (nint)1;
	}
}
