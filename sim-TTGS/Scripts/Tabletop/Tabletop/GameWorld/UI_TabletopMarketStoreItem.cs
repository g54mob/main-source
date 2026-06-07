using Simulator.GameWorld;
using UnityEngine;
using UnityEngine.UI;

namespace Tabletop.GameWorld
{
	public class UI_TabletopMarketStoreItem : UI_MarketStoreItem
	{
		[Space(10f)]
		[SerializeField]
		private Image m_background;

		[SerializeField]
		private Sprite m_buyableBackgroundSprite;

		[SerializeField]
		private Sprite m_lockedBackgroundSprite;

		[Space(15f)]
		[SerializeField]
		private GameObject m_productsDescriptionZone;

		protected override void UpdateContent(BaseShopBoxData data)
		{
			base.UpdateContent(data);
			m_background.sprite = (base.Locked ? m_lockedBackgroundSprite : m_buyableBackgroundSprite);
			m_shopLevelToUnlockValueText.text = $"{MarketStore.GetRequiredShopLevel(data)}";
			m_productsDescriptionZone.SetActive(data.Type < 4);
		}
	}
}
