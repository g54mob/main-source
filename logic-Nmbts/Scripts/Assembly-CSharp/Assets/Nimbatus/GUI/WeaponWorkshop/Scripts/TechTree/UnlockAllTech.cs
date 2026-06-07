using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Upgrades;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.WeaponWorkshop.Scripts.TechTree
{
	public class UnlockAllTech : MonoBehaviour
	{
		public UILabel Label;

		public TechTreeDisplay TechTree;

		private List<WeaponAttributeUpgrade> _allUpgrades;

		private bool _allUnlocked;

		public void Start()
		{
			base.gameObject.SetActive(!RuntimeGlobals.GameModeSettings.AllTechnologyUnlocked && RuntimeGlobals.GameModeSettings.FreeTechnology);
			_allUpgrades = SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GetItems<WeaponAttributeUpgrade>();
			_allUnlocked = _allUpgrades.All((WeaponAttributeUpgrade u) => u.Unlocked);
			UpdateLabel();
		}

		public void Update()
		{
			if (_allUnlocked != _allUpgrades.All((WeaponAttributeUpgrade u) => u.Unlocked))
			{
				_allUnlocked = !_allUnlocked;
				UpdateLabel();
			}
		}

		public void Execute()
		{
			TechTree.ChangeAll(!_allUnlocked);
			_allUnlocked = !_allUnlocked;
			UpdateLabel();
		}

		private void UpdateLabel()
		{
			Label.text = LocalizationManager.GetTranslation(_allUnlocked ? "DroneWorkshop/LockAll" : "DroneWorkshop/UnlockAll");
		}
	}
}
