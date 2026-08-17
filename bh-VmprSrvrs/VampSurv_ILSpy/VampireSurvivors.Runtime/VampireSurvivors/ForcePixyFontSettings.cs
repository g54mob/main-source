using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors;

public class ForcePixyFontSettings : MonoBehaviour
{
	public Material m;

	public string PropertyName;

	public float Value;

	private void Start()
	{
	}

	private void Update()
	{
		int num = Shader.PropertyToID(PropertyName);
		m.SetFloatImpl(num, Value);
	}

	public ForcePixyFontSettings()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
