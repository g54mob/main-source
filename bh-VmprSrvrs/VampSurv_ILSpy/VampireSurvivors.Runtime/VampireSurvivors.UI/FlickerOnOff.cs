using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.UI;

public class FlickerOnOff : MonoBehaviour
{
	private float Duration;

	private Graphic Graphic;

	private float mTimer;

	private void Update()
	{
		//IL_004f: Expected O, but got F4
		object obj = Time.deltaTime;
		object obj2 = default(object);
		if ((mTimer = (float)obj2 + mTimer) > Duration)
		{
			mTimer = 0f;
			bool flag = Graphic.enabled;
			bool flag2 = (byte)((flag ? 1u : 0u) ^ 1u) != 0;
			Graphic.enabled = flag2;
		}
	}

	public FlickerOnOff()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
