using Coherence.Toolkit;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors;

public class GameplaySceneConnector : MonoBehaviour
{
	private CoherenceSyncConfig _onlineStageManager;

	private CoherenceSyncConfig _hostPlayerOptions;

	public GameplaySceneConnector()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
