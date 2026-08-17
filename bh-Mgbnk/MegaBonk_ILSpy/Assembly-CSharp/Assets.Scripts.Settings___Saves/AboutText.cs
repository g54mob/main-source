using Cpp2ILInjected;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Settings___Saves;

public class AboutText : MonoBehaviour
{
	public TextMeshProUGUI text;

	public void SetText(string header, string body)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831725C4]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string text = header + "<size=75%>\n\n" + body;
		this.text.text = text;
	}
}
