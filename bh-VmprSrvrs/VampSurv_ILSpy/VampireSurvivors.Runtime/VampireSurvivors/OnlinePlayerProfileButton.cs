using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Framework;
using VampireSurvivors.UI;

namespace VampireSurvivors;

public class OnlinePlayerProfileButton : MonoBehaviour
{
	private string platformPlayerID;

	private Button _button;

	private SelectableUI _selectable;

	public void SetPlayerID(string playerID)
	{
		platformPlayerID = playerID;
		string message = "<OnlinePlayerProfileButton.SetPlayerID> playerID =" + playerID;
		Debug.Log(message);
	}

	private void Start()
	{
	}

	private void ButtonClicked()
	{
		if (OnlinePlatformSupport.OnlinePlatformSupportInstance == null)
		{
			OnlinePlatformSupport.Setup();
		}
		OnlinePlatformSupport.OnlinePlatformSupportInstance.ShowUsersProfile(platformPlayerID);
	}

	public OnlinePlayerProfileButton()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
