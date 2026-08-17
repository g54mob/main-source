using System;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;

public class ResolutionListener : MonoBehaviour
{
	private float timeout;

	public TextMeshProUGUI timerText;

	private Action<int> revertAction;

	private Action<int> acceptAction;

	private int oldValue;

	private int newValue;

	public GameObject content;

	public static ResolutionListener Instance;

	private void Awake()
	{
		if (!(Instance != null))
		{
			Instance = this;
			return;
		}
		GameObject obj = base.gameObject;
		UnityEngine.Object.Destroy(obj);
	}

	public void NewResolution(int newResolution, int oldResolution, Action<int> revert, Action<int> accept)
	{
		if (!content.activeInHierarchy)
		{
			content.SetActive(value: true);
			revertAction = revert;
			Action<int> action = default(Action<int>);
			acceptAction = action;
			oldValue = oldResolution;
			newValue = newResolution;
			timeout = 15f;
		}
	}

	private void Update()
	{
		//IL_00db: Invalid comparison between I4 and F4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172088]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (content.activeInHierarchy)
		{
			float deltaTime = Time.deltaTime;
			TextMeshProUGUI textMeshProUGUI = timerText;
			double num = Math.Floor(timeout -= deltaTime);
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			string text = $"{arg:D2}";
			timerText.text = text;
			if (!(0f < timeout))
			{
				Action<int> action = revertAction;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v68 @ rax_v15 (System.Action`1<System.Int32>)+18] (should have been resolved before IL gen)");
				content.SetActive(value: false);
				SaveManager._003CInstance_003Ek__BackingField.SaveConfig();
			}
		}
	}

	public void Response(bool r)
	{
		if (!r)
		{
			Action<int> action = revertAction;
			int num = oldValue;
		}
		else
		{
			Action<int> action = acceptAction;
			if (acceptAction == null)
			{
				goto IL_005b;
			}
			int num = newValue;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v135 @ rax_v12 (System.Action`1<System.Int32>)+18] (should have been resolved before IL gen)");
		goto IL_005b;
		IL_005b:
		content.SetActive(value: false);
		SaveManager._003CInstance_003Ek__BackingField.SaveConfig();
	}

	private bool IsActive()
	{
		//IL_0041: Expected I4, but got O
		if ((object)content != null)
		{
			return content.activeInHierarchy;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}
}
