using Cpp2ILInjected;
using Steamworks;
using UnityEngine;

namespace VampireSurvivors.Framework.Platforms;

public class EarlyInitHackSystem : MonoBehaviour
{
	public void Awake()
	{
		SteamClient.Init(1794680u, asyncCallbacks: false);
	}

	public EarlyInitHackSystem()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
