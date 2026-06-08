using System.Collections.Generic;
using UnityEngine;

namespace KitchenData
{
	[CreateAssetMenu(menuName = "Kitchen/Player Cosmetic", fileName = "Player Cosmetic")]
	public class PlayerCosmetic : LocalisedGameDataObject<CosmeticInfo>
	{
		public CosmeticType CosmeticType;

		public List<RestaurantSetting> CustomerSettings = new List<RestaurantSetting>();

		public bool DisableInGame;

		public bool IsDefault;

		public bool BlockHats;

		public float HeadSize = 1f;

		public bool HideBody;

		public ContentPack RequiresDLC;

		public GameObject Visual;

		[SerializeField]
		private GameObject _IconPrefab;

		public GameObject IconPrefab
		{
			get
			{
				if (!(_IconPrefab == null))
				{
					return _IconPrefab;
				}
				return Visual;
			}
		}

		protected override void InitialiseDefaults()
		{
		}

		public override void SetupFinal()
		{
			base.SetupFinal();
			if (CustomerSettings == null)
			{
				CustomerSettings = new List<RestaurantSetting>();
			}
		}
	}
}
