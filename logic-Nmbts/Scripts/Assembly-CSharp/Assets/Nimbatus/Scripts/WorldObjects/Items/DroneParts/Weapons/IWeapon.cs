namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons
{
	public interface IWeapon
	{
		void ApplyWeaponPreset(WeaponPreset preset);

		NimbatusItem Instantiate();
	}
}
