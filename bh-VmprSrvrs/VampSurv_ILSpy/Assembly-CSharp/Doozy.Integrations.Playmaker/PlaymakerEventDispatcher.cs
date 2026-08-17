using Cpp2ILInjected;
using UnityEngine;

namespace Doozy.Integrations.Playmaker;

public class PlaymakerEventDispatcher : MonoBehaviour
{
	public PlaymakerEventDispatcher()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
