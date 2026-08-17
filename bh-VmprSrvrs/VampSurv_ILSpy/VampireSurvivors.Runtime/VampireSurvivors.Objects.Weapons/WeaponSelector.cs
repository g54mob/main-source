namespace VampireSurvivors.Objects.Weapons;

public class WeaponSelector : Weapon
{
	protected void SetupWeaponSelection(string selectionType = "normal")
	{
		((Equipment)this)._003COwner_003Ek__BackingField.QueueWeaponSelectionSelector(((Equipment)this)._equipmentType, selectionType);
	}
}
