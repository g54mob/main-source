using System.Collections.Generic;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using Zenject;

namespace VampireSurvivors.Framework
{
	public class ShopFactory
	{
		[Inject]
		private DataManager _data;

		[Inject]
		private PlayerOptions _playerOptions;

		private List<WeaponType> _availableWeapons;

		private List<ItemType> _availableItems;

		public List<WeaponType> AvailableWeapons => null;

		public List<ItemType> AvailableItems => null;

		public void GenerateShopInventory(CharacterController player)
		{
		}

		public void InjectRemoteShop(List<WeaponType> weapons, List<ItemType> items)
		{
		}

		public static List<WeaponType> GetValidAdventureWeaponsForMerchant(List<WeaponType> merchantInventory, PlayerOptions playerOptions)
		{
			return null;
		}

		public static List<WeaponType> GetValidCustomMerchantWeapons(List<WeaponType> merchantInventory, PlayerOptions playerOptions)
		{
			return null;
		}

		public static List<ItemType> GetValidCustomMerchantItems(List<ItemType> merchantInventoryItems, PlayerOptions playerOptions)
		{
			return null;
		}

		public bool DoesPlayerAlreadyHaveWeapon(WeaponType t)
		{
			return false;
		}

		private void MakeCustomInventory()
		{
		}

		private void MakeStandardInventory(CharacterController player)
		{
		}

		private void MakeArcanaInventory()
		{
		}

		private void MakeEggsInventory(CharacterController player)
		{
		}
	}
}
