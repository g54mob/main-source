using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.UI;

public class PopupTest : MonoBehaviour
{
	public void MakeLargeMultiOption()
	{
		OptionDataSet optionDataSet = new OptionDataSet("One", "oneoneone");
		OptionDataSet optionDataSet2 = new OptionDataSet("Two", "twotwotwo");
		optionDataSet2._002Ector("Two", "twotwotwo");
	}

	private void OnSelected(int i)
	{
		int num = default(int);
		string text = num.ToString();
		string message = "Selected : " + text;
		Debug.Log(message);
	}

	public PopupTest()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
