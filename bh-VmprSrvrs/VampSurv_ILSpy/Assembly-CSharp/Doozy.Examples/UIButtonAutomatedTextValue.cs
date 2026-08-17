using Cpp2ILInjected;
using Doozy.Engine.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Doozy.Examples;

public class UIButtonAutomatedTextValue : MonoBehaviour
{
	public Text PresetCategory;

	public Text PresetName;

	public UIButtonBehaviorType BehaviorType;

	public UIButtonAutomatedTextValue()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
