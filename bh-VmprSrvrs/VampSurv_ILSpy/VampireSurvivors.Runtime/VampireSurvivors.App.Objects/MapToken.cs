using Cpp2ILInjected;

namespace VampireSurvivors.App.Objects;

public class MapToken
{
	public bool Hidden;

	public string texture;

	public string frameName;

	public float x;

	public float y;

	public MapToken()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2DE1]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		texture = "items";
		frameName = "QuestionMark";
	}
}
