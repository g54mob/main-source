using System.Collections.Generic;
using KitchenData.Localisations;
using UnityEngine;

namespace KitchenData
{
	[CreateAssetMenu(fileName = "FranchiseUpgrade", menuName = "Kitchen/Upgrades/Franchise")]
	public class FranchiseUpgrade : GenericLocalisation, IUpgrade, IHasPrefab
	{
		public int MaximumUpgradeCount = 1;

		public List<IFranchiseUpgrade> Upgrades;

		public GameObject Prefab;

		int IUpgrade.MaximumUpgradeCount => MaximumUpgradeCount;

		string IUpgrade.UpgradeName => Name;

		string IUpgrade.UpgradeDescription => Description;

		int IUpgrade.ID => ID;

		GameObject IHasPrefab.Prefab => Prefab;

		protected override void InitialiseDefaults()
		{
			if (Upgrades == null)
			{
				Upgrades = new List<IFranchiseUpgrade>();
			}
		}
	}
}
