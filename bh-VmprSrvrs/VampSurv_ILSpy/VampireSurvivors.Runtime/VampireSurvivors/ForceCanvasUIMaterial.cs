using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors;

public class ForceCanvasUIMaterial : MonoBehaviour
{
	private void Awake()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A494F]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Material defaultCanvasMaterial = Canvas.GetDefaultCanvasMaterial();
		int num = Shader.PropertyToID("_StencilWriteMask");
		defaultCanvasMaterial.SetFloatImpl(num, 80f);
		Material defaultCanvasMaterial2 = Canvas.GetDefaultCanvasMaterial();
		int num2 = Shader.PropertyToID("_StencilReadMask");
		defaultCanvasMaterial2.SetFloatImpl(num2, 80f);
	}

	public ForceCanvasUIMaterial()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
