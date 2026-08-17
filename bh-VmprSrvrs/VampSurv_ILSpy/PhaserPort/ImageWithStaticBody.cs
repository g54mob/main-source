using Cpp2ILInjected;
using UnityEngine;

public class ImageWithStaticBody : GameMonoBehaviour
{
	private void Start()
	{
	}

	protected override void OnUpdate()
	{
	}

	public ImageWithStaticBody()
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
