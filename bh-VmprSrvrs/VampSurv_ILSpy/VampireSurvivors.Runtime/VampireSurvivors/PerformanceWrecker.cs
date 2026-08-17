using System.Threading;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Framework;

namespace VampireSurvivors;

public class PerformanceWrecker : MonoBehaviour
{
	private Slider _slider;

	private unsafe void Update()
	{
		//IL_002f: Expected I4, but got O
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			int num = (int)_slider;
			int value = ((int*)num)->m_value;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v144 @ rdx_v5 (System.Int32)+418] (should have been resolved before IL gen)");
			object obj = default(object);
			if (0 < (nint)obj)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,xmm0\"");
				Thread.Sleep(num);
			}
		}
	}

	public PerformanceWrecker()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
