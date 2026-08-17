using Cpp2ILInjected;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons;

public class EME_Mech3Weapon : EME_Mech2Weapon
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rdx_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Mech3Weapon>)+618]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rdx_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Mech3Weapon>)+620]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v2 @ rax_v1 (should have been resolved before IL gen)");
			/*Error: End of method reached without returning.*/;
		}
	}

	public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
	{
		((EME_Weapon)this).InitWeapon(characterController, weaponType);
		WeaponData currentWeaponData = _currentWeaponData;
		((Weapon)this)._003CFreezeChance_003Ek__BackingField = 0.25f;
		_explosionType = WeaponType.FIREEXPLOSION;
		currentWeaponData._003Cpenetrating_003Ek__BackingField = 65535;
	}
}
