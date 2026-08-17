using Cpp2ILInjected;

namespace VampireSurvivors.Objects.Weapons;

public class Candybox2Weapon : WeaponSelector
{
	public override void OnWeaponAdded()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A509F]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		((Equipment)this)._003COwner_003Ek__BackingField.QueueWeaponSelectionSelector(((Equipment)this)._equipmentType, "evo");
	}
}
