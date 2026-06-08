using KitchenData.Localisations;
using UnityEngine;

namespace KitchenData
{
	[CreateAssetMenu(fileName = "Contract", menuName = "Kitchen/Upgrades/Contract")]
	public class Contract : ContractLocalisation, IUpgrade, ICard
	{
		public RestaurantStatus Status;

		public float ExperienceMultiplier = 1f;

		int IUpgrade.MaximumUpgradeCount => 1;

		string IUpgrade.UpgradeName => Name;

		string IUpgrade.UpgradeDescription => Description;

		int IUpgrade.ID => ID;

		int ICard.CardID => ID;

		CardType ICard.CardType => CardType.Contract;

		public Color Colour => new Color(0.24f, 0.69f, 0.53f);

		public string Icon => "";

		string ICard.Name => Name;

		string ICard.FlavourText => "";

		string ICard.Description => Description;

		public Unlock.RewardLevel ExpReward => Unlock.RewardLevel.None;

		protected override void InitialiseDefaults()
		{
		}
	}
}
