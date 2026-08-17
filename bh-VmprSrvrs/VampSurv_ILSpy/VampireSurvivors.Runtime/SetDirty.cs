using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

public class SetDirty : MonoBehaviour
{
	public Graphic m_graphic;

	private void Reset()
	{
		Graphic component = GetComponent<Graphic>();
		m_graphic = component;
	}

	private void Update()
	{
		m_graphic.SetVerticesDirty();
	}

	public SetDirty()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
