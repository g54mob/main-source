using Cpp2ILInjected;

namespace VampireSurvivors.Objects.Weapons;

public class CandyboxWeapon : WeaponSelector
{
	public override void OnWeaponAdded()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A50A0]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		((Equipment)this)._003COwner_003Ek__BackingField.QueueWeaponSelectionSelector(((Equipment)this)._equipmentType, "normal");
	}
}
