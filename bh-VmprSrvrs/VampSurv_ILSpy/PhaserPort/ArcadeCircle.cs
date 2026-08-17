using Cpp2ILInjected;
using Unity.Mathematics;

public struct ArcadeCircle
{
	public float2 pos;

	public float radius;

	public float x
	{
		get
		{
			//IL_0007: Expected F4, but got O
			return (float)pos;
		}
	}

	public float y
	{
		get
		{
			//IL_000d: Expected F4, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ArcadeCircle)+4]");
			return 0f;
		}
	}

	public ArcadeCircle(float x, float y, float radius)
	{
		float2 float5 = default(float2);
		pos = float5;
		this.radius = radius;
	}

	public void setTo(float x, float y, float radius)
	{
		float2 float5 = default(float2);
		pos = float5;
		this.radius = radius;
	}
}
