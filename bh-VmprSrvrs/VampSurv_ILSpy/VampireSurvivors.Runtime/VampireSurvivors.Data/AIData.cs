using Cpp2ILInjected;

namespace VampireSurvivors.Data;

public class AIData
{
	public string AINameLocalTerm;

	public string AIIconSprite;

	public string AIIconTexture;

	public AIData()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C16]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		AINameLocalTerm = "";
		AIIconSprite = "";
		AIIconTexture = "";
	}
}
