using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors;

public class Screenshotter : MonoBehaviour
{
	private string _FileName;

	private int _ssCount;

	private unsafe void TakeScreenshot()
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected I4, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A491B]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		int num = this + 40;
		string text = ((int*)num)->ToString("0000");
		string filename = _FileName + "_" + text + ".png";
		ScreenCapture.CaptureScreenshot(filename, 1, ScreenCapture.StereoScreenCaptureMode.LeftEye);
		int ssCount = _ssCount + 1;
		_ssCount = ssCount;
	}

	public Screenshotter()
	{
		//IL_0058: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A491C]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_FileName = "Screenshot";
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rcx_v4 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
