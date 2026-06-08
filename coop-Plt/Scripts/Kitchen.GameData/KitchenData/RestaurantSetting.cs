using System.Collections.Generic;
using KitchenData.Localisations;
using UnityEngine;

namespace KitchenData
{
	[CreateAssetMenu(fileName = "Setting", menuName = "Kitchen/Restaurant Setting")]
	public class RestaurantSetting : GenericLocalisation, IUpgrade
	{
		public WeatherMode WeatherMode;

		public List<IDecorationConfiguration> Decorators;

		public UnlockPack UnlockPack;

		public Unlock StartingUnlock;

		public Dish FixedDish;

		public GameObject Prefab;

		public LayoutProfile ForceLayout;

		public bool AlwaysLight;

		public Season FixedRunSeason;

		int IUpgrade.MaximumUpgradeCount => 1;

		string IUpgrade.UpgradeName => Name;

		string IUpgrade.UpgradeDescription => Description;

		int IUpgrade.ID => ID;

		protected override void InitialiseDefaults()
		{
			Decorators = new List<IDecorationConfiguration>();
		}

		public override void SetupFinal()
		{
			base.SetupFinal();
		}
	}
}
