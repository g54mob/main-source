using System.Collections.Generic;
using Cpp2ILInjected;

namespace VampireSurvivors.Objects.Weapons;

public class Ex_Ammo1Weapon_Counter : Ex_Ammo1Weapon
{
	public override bool FireInTheFacedDirection => false;

	public override void CheckArcanas()
	{
	}

	public override bool LevelUp()
	{
		//IL_0005: Expected I, but got O
		//IL_0015: Expected O, but got I
		//IL_0025: Expected O, but got I
		nint num = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ r8_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.Ex_Ammo1Weapon_Counter>)+208]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ r8_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.Ex_Ammo1Weapon_Counter>)+210]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v3 @ rax_v1 (should have been resolved before IL gen)");
		/*Error: End of method reached without returning.*/;
	}

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Ranged;
	}

	public Ex_Ammo1Weapon_Counter()
	{
		base._rapidFireDamageInterval = 0.7f;
		base._ticksPerRapidFire = 10;
		List<RapidDamageInstance> rapidDamageInstances = new List<RapidDamageInstance>();
		base._rapidDamageInstances = rapidDamageInstances;
		((Weapon)this)._002Ector();
	}
}
