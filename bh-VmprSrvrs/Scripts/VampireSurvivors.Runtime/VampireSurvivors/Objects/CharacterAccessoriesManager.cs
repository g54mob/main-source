using VampireSurvivors.Data;

namespace VampireSurvivors.Objects
{
	public class CharacterAccessoriesManager : EquipmentManager
	{
		private bool _playerIsDeadInMultiplayer;

		public Accessory GetAccessoryByType(WeaponType accessoryType, bool searchHidden = false)
		{
			return null;
		}

		protected override void OnUpdate()
		{
		}
	}
}
