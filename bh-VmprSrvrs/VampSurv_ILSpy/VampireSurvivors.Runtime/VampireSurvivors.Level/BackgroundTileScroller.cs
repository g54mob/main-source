using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.Level;

public class BackgroundTileScroller : GameMonoBehaviour
{
	public BackgroundTileScroller()
	{
		//IL_0020: Expected I, but got O
		base._onResumeSent = true;
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
