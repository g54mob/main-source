using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Upgrades;
using Sirenix.OdinInspector;

namespace Assets.Nimbatus.Scripts.Receivables.ReceivableSettings
{
	public class TechnologyReceivableSetting : BaseReceivableSettings
	{
		public enum ETechnologyReceivableType
		{
			OfLevel = 0,
			Specific = 1,
			Random = 2
		}

		public ETechnologyReceivableType Type;

		[ShowIf("Type", ETechnologyReceivableType.OfLevel, true)]
		public EWeaponUpgradeLevel Level;

		[ShowIf("Type", ETechnologyReceivableType.Specific, true)]
		public List<WeaponAttributeUpgrade> Upgrades = new List<WeaponAttributeUpgrade>();

		public override BaseReceivable CreateReceivable(int seed, int amount)
		{
			WeaponAttributeUpgrade weaponAttributeUpgrade = ((Type == ETechnologyReceivableType.Specific && Upgrades != null && Upgrades.Count > 0) ? Upgrades : SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GetItems<WeaponAttributeUpgrade>()).Where(delegate(WeaponAttributeUpgrade u)
			{
				if (Type != ETechnologyReceivableType.OfLevel)
				{
					return !u.Unlocked;
				}
				return u.UpgradeLevel == Level && !u.Unlocked;
			}).ToList().RandomItemSeed(seed);
			if (weaponAttributeUpgrade != null)
			{
				return new TechnologyReceivable
				{
					UniqueId = weaponAttributeUpgrade.UniqueId
				};
			}
			return new NoReceivable();
		}
	}
}
