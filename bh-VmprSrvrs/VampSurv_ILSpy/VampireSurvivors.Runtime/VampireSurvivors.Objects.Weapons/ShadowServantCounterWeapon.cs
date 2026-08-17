using Cpp2ILInjected;

namespace VampireSurvivors.Objects.Weapons;

public class ShadowServantCounterWeapon : ShadowServantWeapon
{
	protected override void Awake()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A510A]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		BaseSpriteName = "bubbleSphere3.png";
		SnakeSpriteName = "snakeS_i0";
		SnakeDieSpriteName = "snakeS_";
		TrailSpriteName = "BlackTrail2.png";
		base.Awake();
	}

	public override void CheckArcanas()
	{
	}
}
