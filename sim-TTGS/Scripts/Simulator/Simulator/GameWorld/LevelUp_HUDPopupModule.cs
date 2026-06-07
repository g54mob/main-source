using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Simulator.GameWorld
{
	public class LevelUp_HUDPopupModule : HUDPopupModule
	{
		[Header("UI Components")]
		[SerializeField]
		protected TextMeshProUGUI m_currentLevelText;

		[SerializeField]
		protected TextMeshProUGUI m_newLevelText;

		[SerializeField]
		protected Button m_validateButton;

		[SerializeField]
		protected GameObject m_newObjectsContainer;

		[SerializeField]
		protected TextMeshProUGUI m_demoText;

		[SerializeField]
		private UI_LevelUpGridLayout m_gridLayout;

		[Header("References")]
		[SerializeField]
		protected RectTransform m_unlockedItemsContainer;

		[Header("Prefabs")]
		[SerializeField]
		protected GameObject m_unlockedItemPrefab;

		protected List<UI_LevelUpUnlockedItem> m_unlockedItems = new List<UI_LevelUpUnlockedItem>();

		private bool m_isReadingDemoText;

		public override EHUDPopupModuleType Type => EHUDPopupModuleType.LEVEL_UP;

		public override bool StackInputMap => true;

		protected override void OnSetActive()
		{
			base.OnSetActive();
			UpdateContent(GameState.ShopLevel);
			m_validateButton.onClick.AddListener(OnCloseButtonClick_Validate);
		}

		protected override void OnSetInactive()
		{
			base.OnSetInactive();
			ClearUnlockedItems();
			m_validateButton.onClick.RemoveListener(OnCloseButtonClick_Validate);
		}

		protected virtual void UpdateContent(int shopLevel)
		{
			m_isReadingDemoText = false;
			m_demoText.enabled = false;
			m_newObjectsContainer.SetActive(value: true);
			m_currentLevelText.text = (shopLevel - 1).ToString();
			m_newLevelText.text = shopLevel.ToString();
			CreateUnlockedItems(shopLevel);
		}

		protected virtual void CreateUnlockedItems(int shopLevel)
		{
			List<BaseShopBoxData> list = MarketStoreDatabase.GetDatasUnlockedAtLevel(shopLevel).ToList();
			m_gridLayout.SetGrid(list.Count);
			foreach (BaseShopBoxData item in list)
			{
				CreateUnlockedItem(item);
			}
			RebuildLayout();
		}

		protected virtual void CreateUnlockedItem(BaseShopBoxData data)
		{
			UI_LevelUpUnlockedItem component = Object.Instantiate(m_unlockedItemPrefab, m_unlockedItemsContainer).GetComponent<UI_LevelUpUnlockedItem>();
			m_unlockedItems.Add(component);
			component.Init(data);
		}

		protected virtual void ClearUnlockedItems()
		{
			foreach (UI_LevelUpUnlockedItem unlockedItem in m_unlockedItems)
			{
				Object.Destroy(unlockedItem.gameObject);
			}
			m_unlockedItems.Clear();
		}

		protected virtual void RebuildLayout()
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(m_unlockedItemsContainer);
		}

		private void OnCloseButtonClick_Validate()
		{
			if (!m_isReadingDemoText && GameStateSettings.Demo && GameState.ShopLevel == GameStateSettings.DemoMaxLevel)
			{
				m_isReadingDemoText = true;
				m_newObjectsContainer.SetActive(value: false);
				m_demoText.enabled = true;
			}
			else
			{
				Validate();
			}
		}
	}
}
