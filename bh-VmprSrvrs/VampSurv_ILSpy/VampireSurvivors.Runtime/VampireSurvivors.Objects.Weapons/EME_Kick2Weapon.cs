using Cpp2ILInjected;

namespace VampireSurvivors.Objects.Weapons;

public class EME_Kick2Weapon : EME_Kick1Weapon
{
	protected override int GlimmerTier => 2;

	protected override int ComboIndexFinal
	{
		get
		{
			//IL_0005: Expected I, but got O
			//IL_0015: Expected O, but got I
			//IL_0025: Expected O, but got I
			nint num = (nint)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rdx_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Kick2Weapon>)+608]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rdx_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Kick2Weapon>)+610]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v2 @ rax_v1 (should have been resolved before IL gen)");
			/*Error: End of method reached without returning.*/;
		}
	}

	public override bool IsEvolved => true;

	public override int WallBounces => 3;

	public EME_Kick2Weapon()
	{
		overhealingTotal = 1f;
		((EME_Weapon)this)._002Ector();
	}
}
