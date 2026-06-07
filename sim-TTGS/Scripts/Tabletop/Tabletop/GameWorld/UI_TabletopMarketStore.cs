using Simulator.GameWorld;
using UnityEngine;
using UnityEngine.UI;

namespace Tabletop.GameWorld
{
	public class UI_TabletopMarketStore : UI_MarketStore
	{
		[Header("Tabletop Sort")]
		[SerializeField]
		private Image m_shopLevelSortDirectionIcon;

		[SerializeField]
		private Image m_nameSortDirectionIcon;

		[SerializeField]
		private Image m_priceSortDirectionIcon;

		[Header("Tabletop Filters")]
		[SerializeField]
		private UI_LicenseFilterDropdown m_licenseFilterDropdown;

		protected override void OnInit()
		{
			base.OnInit();
			m_licenseFilterDropdown.Init();
		}

		protected override void RegisterBrowserToolbarButtons(bool register)
		{
			base.RegisterBrowserToolbarButtons(register);
			if (register)
			{
				m_licenseFilterDropdown.AnyChange += OnAnyLicenseFilterToggleValueChanged;
			}
			else
			{
				m_licenseFilterDropdown.AnyChange -= OnAnyLicenseFilterToggleValueChanged;
			}
		}

		private void OnAnyLicenseFilterToggleValueChanged()
		{
			UpdateBrowsers();
		}

		protected override void OnSortByShopLevelToggleValueChanged(bool on)
		{
			base.OnSortByShopLevelToggleValueChanged(on);
			m_shopLevelSortDirectionIcon.rectTransform.localEulerAngles = ((m_sortType == EMarketStoreSortType.SHOP_LEVEL_UP) ? new Vector3(0f, 0f, 180f) : Vector3.zero);
		}

		protected override void OnSortByNameToggleValueChanged(bool on)
		{
			base.OnSortByNameToggleValueChanged(on);
			m_nameSortDirectionIcon.rectTransform.localEulerAngles = ((m_sortType == EMarketStoreSortType.NAME_UP) ? new Vector3(0f, 0f, 180f) : Vector3.zero);
		}

		protected override void OnSortByPriceToggleValueChanged(bool on)
		{
			base.OnSortByPriceToggleValueChanged(on);
			m_priceSortDirectionIcon.rectTransform.localEulerAngles = ((m_sortType == EMarketStoreSortType.PRICE_UP) ? new Vector3(0f, 0f, 180f) : Vector3.zero);
		}

		protected override bool DoesElementPassFilters(BaseShopBoxData item)
		{
			if (base.DoesElementPassFilters(item))
			{
				if (item is TabletopProductShopBoxData tabletopProductShopBoxData && tabletopProductShopBoxData.HasLicense(out var license))
				{
					return m_licenseFilterDropdown.IsLicenseActive(license);
				}
				return true;
			}
			return false;
		}
	}
}
