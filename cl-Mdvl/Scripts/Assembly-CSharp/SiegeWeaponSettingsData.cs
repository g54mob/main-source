using NSEipix.Repository;

public class SiegeWeaponSettingsData : DynamicSettingsData<SiegeWeaponSettingsData, SiegeWeaponSettings>
{
	protected override string JsonFile()
	{
		return "Settings/SiegeWeaponSettings.json";
	}
}
