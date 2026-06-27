using System;
using Restory.Data.GameConfigs;
using Restory.Data.Localization;
using Restory.Data.Shops.Elements;
using Restory.Gameplay.Shops.Elements;
using Restory.ObjectPools;
using Restory.UI.Views.Shops.Elements;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.Shops.Elements
{
	public sealed class GUI_LicenseShopItem : MonoBehaviour, ICleanableComponent
	{
		[SerializeField]
		private GUI_LicenseShopItemView view;

		private LicenseShopItemData item;

		private GameConfig gameConfig;

		private LocalizationSystem localizationSystem;

		private ElementsShopService elementsShopService;

		public LicenseShopItemData Item => item;

		public event Action<GUI_LicenseShopItem> OnItemButtonClicked;

		public event Action<GUI_LicenseShopItem> OnAddToCartButtonClicked;

		public event Action<GUI_LicenseShopItem> OnRemoveFromCartButtonClicked;

		[Inject]
		private void Construct(GameConfig gameConfig, LocalizationSystem localizationSystem, ElementsShopService elementsShopService)
		{
			this.gameConfig = gameConfig;
			this.localizationSystem = localizationSystem;
			this.elementsShopService = elementsShopService;
		}

		private void OnEnable()
		{
			view.OnItemButtonClicked += ResolveItemButtonClicked;
			view.OnAddToCartButtonClicked += ResolveAddToCartButtonClicked;
			view.OnRemoveFromCartButtonClicked += ResolveRemoveFromCartButtonClicked;
		}

		private void OnDisable()
		{
			if (view.MonoShellExists())
			{
				view.OnItemButtonClicked -= ResolveItemButtonClicked;
				view.OnAddToCartButtonClicked -= ResolveAddToCartButtonClicked;
				view.OnRemoveFromCartButtonClicked -= ResolveRemoveFromCartButtonClicked;
			}
		}

		public void Clean()
		{
		}

		public void Init(LicenseShopItemData item, bool isSelected, bool insufficientFunds, bool available = true)
		{
			this.item = item;
			if (gameConfig.VersionType != VersionType.Release)
			{
				this.item.ContentRestriction = item.License.ContentRestriction;
			}
			view.Init(item.License.DeviceInfo.Icon, localizationSystem.GetTranslation(item.License.NameLocalizationKey), localizationSystem.GetTranslation(item.License.DescriptionLocalizationKey), elementsShopService.CalculatePrice(item));
			SetState(isSelected, insufficientFunds, available);
		}

		public void SetState(bool isSelected, bool insufficientFunds, bool available = true)
		{
			if ((bool)item.ContentRestriction)
			{
				view.SetComingSoonState();
			}
			else if (isSelected)
			{
				view.SetSelectedState();
			}
			else if (!available)
			{
				view.SetUnavailableState();
			}
			else if (insufficientFunds)
			{
				view.SetInsufficientFundsState();
			}
			else
			{
				view.SetNormalState();
			}
		}

		private void ResolveItemButtonClicked()
		{
			this.OnItemButtonClicked?.Invoke(this);
		}

		private void ResolveAddToCartButtonClicked()
		{
			this.OnAddToCartButtonClicked?.Invoke(this);
		}

		private void ResolveRemoveFromCartButtonClicked()
		{
			this.OnRemoveFromCartButtonClicked?.Invoke(this);
		}
	}
}
