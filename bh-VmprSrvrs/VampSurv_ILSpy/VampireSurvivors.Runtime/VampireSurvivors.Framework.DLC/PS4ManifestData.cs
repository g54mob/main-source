using System;
using Cpp2ILInjected;

namespace VampireSurvivors.Framework.DLC;

[Serializable]
public class PS4ManifestData
{
	private string _MasterVersion;

	public string MasterVersion => _MasterVersion;

	public PS4ManifestData()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2AD8]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_MasterVersion = "01.00";
	}
}
