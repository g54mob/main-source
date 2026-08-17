using System.Collections.Generic;
using Cpp2ILInjected;

namespace VampireSurvivors.Objects.Weapons;

public class EME_Greatsword3Weapon : EME_Greatsword2Weapon
{
	protected override int GlimmerTier => 3;

	protected override int ComboIndexFinal
	{
		get
		{
			//IL_0005: Expected I, but got O
			//IL_0015: Expected O, but got I
			//IL_0025: Expected O, but got I
			nint num = (nint)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rdx_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Greatsword3Weapon>)+618]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rdx_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Greatsword3Weapon>)+620]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v2 @ rax_v1 (should have been resolved before IL gen)");
			/*Error: End of method reached without returning.*/;
		}
	}

	public EME_Greatsword3Weapon()
	{
		List<AbsetzenInstance> absetzenInstances = new List<AbsetzenInstance>();
		((EME_Greatsword1Weapon)this)._absetzenInstances = absetzenInstances;
		((EME_Weapon)this)._002Ector();
	}
}
