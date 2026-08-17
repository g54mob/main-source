using Cpp2ILInjected;
using Doozy.Engine.UI;
using UnityEngine;

namespace Doozy.Examples;

public class ExampleShowPopup : MonoBehaviour
{
	public void ShowPopup(string popupName)
	{
		UIPopup uIPopup = UIPopupManager.ShowPopup(popupName, addToPopupQueue: false, instantAction: false);
	}

	public void ShowQueuedPopup(string popupName)
	{
		UIPopup uIPopup = UIPopupManager.ShowPopup(popupName, addToPopupQueue: true, instantAction: false);
	}

	public void HidePopup(string popupName)
	{
		bool flag = UIPopup.HidePopup(popupName);
	}

	public ExampleShowPopup()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
