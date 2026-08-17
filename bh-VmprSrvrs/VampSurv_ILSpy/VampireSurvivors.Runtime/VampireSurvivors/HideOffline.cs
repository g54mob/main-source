using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Framework;

namespace VampireSurvivors;

public class HideOffline : MonoBehaviour
{
	private void Update()
	{
		GameObject gameObject = base.gameObject;
		GameManager core = GM.Core;
		bool isOnlineMultiplayer = core._multiplayer.IsOnlineMultiplayer;
		gameObject.SetActive(isOnlineMultiplayer);
	}

	public HideOffline()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
