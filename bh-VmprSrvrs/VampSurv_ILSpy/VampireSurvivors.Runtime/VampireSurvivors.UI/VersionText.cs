using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using VampireSurvivors.Framework.DLC;

namespace VampireSurvivors.UI;

public class VersionText : MonoBehaviour
{
	private TextMeshProUGUI _VersionText;

	private VersionData _VersionData;

	private void Start()
	{
		string version = Application.version;
		string text = "v" + version;
		_VersionText.text = text;
		string text2 = _VersionText.text;
		string formattedBuildId = _VersionData.GetFormattedBuildId();
		string text3 = text2 + " (" + formattedBuildId + ")";
		_VersionText.text = text3;
	}

	public VersionText()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
