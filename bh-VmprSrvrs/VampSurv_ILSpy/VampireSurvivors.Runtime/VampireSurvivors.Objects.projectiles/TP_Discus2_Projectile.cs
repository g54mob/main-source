using Cpp2ILInjected;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Discus2_Projectile : TP_Discus1_Projectile
{
	protected override float SpeedFactor => 3f;

	protected override bool CanBounce => true;

	protected override string FrameName
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A43BE]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			return "TP_Discus01";
		}
	}
}
