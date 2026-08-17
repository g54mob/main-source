using System;
using Cpp2ILInjected;

namespace VampireSurvivors.Framework.DLC;

[Serializable]
public class PS5ManifestData
{
	private string _MasterVersion;

	public string MasterVersion => _MasterVersion;

	public PS5ManifestData()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2AD7]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_MasterVersion = "01.00";
	}
}
