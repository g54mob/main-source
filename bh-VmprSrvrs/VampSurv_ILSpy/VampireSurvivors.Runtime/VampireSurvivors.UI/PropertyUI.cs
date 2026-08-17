using Cpp2ILInjected;
using TMPro;
using UnityEngine;

namespace VampireSurvivors.UI;

public class PropertyUI : MonoBehaviour
{
	private TextMeshProUGUI Name;

	private TextMeshProUGUI Value;

	public void SetValue(string val)
	{
		Value.text = val;
	}

	public void SetName(string name)
	{
		Name.text = name;
	}

	public TextMeshProUGUI GetName()
	{
		return Name;
	}

	public TextMeshProUGUI GetValue()
	{
		return Value;
	}

	public PropertyUI()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
