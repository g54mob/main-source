using System;
using Cpp2ILInjected;

namespace VampireSurvivors.Data;

[Serializable]
public class PS5BaseGameData
{
	public string _MasterVersion;

	public PS5BaseGameData()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C1F]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_MasterVersion = "01.00";
	}
}
