using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CommandSuggestion : MonoBehaviour
{
	public TextMeshProUGUI textMesh;

	public RawImage selected;

	public void SetCommand(DebugCommandBase command)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172EEB]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172EEC]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string text = command._003CcommandId_003Ek__BackingField + " " + "";
		textMesh.text = text;
		GameObject gameObject = selected.gameObject;
		gameObject.SetActive(value: false);
	}

	public void Select(bool t)
	{
		GameObject gameObject = selected.gameObject;
		gameObject.SetActive(t);
	}

	private string FindSettingValue(DebugCommandBase command)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172EEC]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		return "";
	}
}
