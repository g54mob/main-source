using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Simulator.GameWorld
{
	public class SellFurniture_HUDPopupModule : HUDPopupModule
	{
		[Header("UI Components")]
		[SerializeField]
		protected SimulatorText m_furnitureNameText;

		[SerializeField]
		protected TextMeshProUGUI m_moneyText;

		[SerializeField]
		protected Button m_validateButton;

		public override EHUDPopupModuleType Type => EHUDPopupModuleType.SELL_FURNITURE;

		protected override void OnEnable()
		{
			base.OnEnable();
			m_validateButton.onClick.AddListener(base.Validate);
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			m_validateButton.onClick.RemoveListener(base.Validate);
		}

		protected override void OnSetActive()
		{
			base.OnSetActive();
			UpdateContent(Bin.FurnitureBeingSold);
		}

		protected virtual void UpdateContent(Furniture furniture)
		{
			m_moneyText.text = (PriceManager.GetFurnitureMarketStorePrice(furniture.UID) * FurnitureSettings.ResellPricePercentage).ToStringMoneyFormat();
		}
	}
}
