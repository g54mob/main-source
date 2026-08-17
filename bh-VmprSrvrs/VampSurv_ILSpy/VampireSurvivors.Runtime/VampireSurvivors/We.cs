using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors;

public class We : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
	}

	public We()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
