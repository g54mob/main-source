using Cpp2ILInjected;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Javelin2_Projectile : TP_Javelin1_Projectile
{
	protected override string FrameName
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A452D]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			return "TP_VFX_Javelin02";
		}
	}

	protected override bool IsEvolution => true;

	protected override bool WrapX => true;

	protected override bool WrapY => true;
}
