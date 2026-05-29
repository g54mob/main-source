using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using InputControl;
using ScriptableObjects.ScriptableObjectScripts.Settings;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class InGameShopDialog : BaseDialog
	{
		public enum eInGameShopCategory
		{
			None = 0,
			Hero = 1,
			Relic = 2,
			Motif = 3
		}

		[Serializable]
		private class InGameShopCategoryInfo
		{
			public eInGameShopCategory category;

			public GameObject panelPrefab;

			public GameObject panelObj;

			public Transform itemParent;

			public InGameShopItem itemPrefab;

			public RewardChoiceButton choiceButton;

			public List<InGameShopItem> items;
		}

		[CompilerGenerated]
		private sealed class _003CHeroInfoAutoSwitching_003Ed__62 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public InGameShopDialog _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CHeroInfoAutoSwitching_003Ed__62(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[SerializeField]
		[Header("Base Items")]
		private GameObject buttonArea;

		[SerializeField]
		private List<Button> switchButtons;

		[SerializeField]
		private GameObject freeTextArea;

		[SerializeField]
		private TMP_Text moneyText;

		[SerializeField]
		private TMP_Text purchaseText;

		[SerializeField]
		private TMP_Text priceText;

		[SerializeField]
		private TMP_Text purchasedText;

		[SerializeField]
		private Button purchaseButton;

		[SerializeField]
		private Color priceNomalColor;

		[SerializeField]
		private Color priceNotEnoughColor;

		[SerializeField]
		[Header("Category Infos")]
		private List<InGameShopCategoryInfo> categoryInfos;

		[SerializeField]
		private RewardChoiceButton otherChoiceButton;

		[SerializeField]
		private CursorUIGroup _purchaseGroup;

		[SerializeField]
		private CursorUIItem _purchaseItem;

		private bool isUseFree;

		private bool autoSwitch;

		private int heroInfoNum;

		private Coroutine autoSwitchCoroutine;

		private UISetting uiSetting;

		private RewardSetting rewardSetting;

		private InGameShopSettings inGameShopSettings;

		private InGameShopItem selectedItem;

		public const string MotifOutputIdForCircle = "InGameShop.Circle";

		public const string MotifOutputIdForTriangle = "InGameShop.Triangle";

		public const string MotifOutputIdForSquare = "InGameShop.Square";

		public const string FreeItemStr = "Free";

		public const string RemoveMachinePointArchiveId = "InGameShop.RemoveMachinePoint";

		private InGameShopDialog _openWindow;

		private bool IsOkPurchase => false;

		public InGameShopDialog OpenWindow => null;

		public override void Init()
		{
		}

		public override void Open()
		{
		}

		public override void OnBackOpen()
		{
		}

		public override void Init<T>(T args)
		{
		}

		public override void Open<T>(T args)
		{
		}

		private void InitAutoSwitchCoroutine()
		{
		}

		private void CreateItems()
		{
		}

		private void ClearSelectedItem()
		{
		}

		public void UpdateUI()
		{
		}

		private void InitDetailWindow()
		{
		}

		private void ClearPanels()
		{
		}

		private void ClearItems()
		{
		}

		public List<eLuggage> SelectionLuggage(int choiceCount)
		{
			return null;
		}

		protected List<T> ChooseItem<T>(List<T> pool, int choiceCount)
		{
			return null;
		}

		public List<eLuggage> GetUpgradeUnitPool(List<PlayUnlockData> unlockData)
		{
			return null;
		}

		public List<eLuggage> GetUnlockUnitPool(List<PlayUnlockData> unlockData)
		{
			return null;
		}

		public List<eLuggage> GetUnlockSpellPool(List<PlayUnlockData> unlockData)
		{
			return null;
		}

		private List<eRelic> ChooseRelic(int choiceCount)
		{
			return null;
		}

		private List<MstRelicDataEntities> GetRelicPool()
		{
			return null;
		}

		private int GetBuffPlusRarity(InGameShopSettings.RelicRarityPriceInfo rarityPriceInfo)
		{
			return 0;
		}

		private List<InGameShopItem.InGameShopItemData> GetInGameShopItemsForLuggages(List<eLuggage> targetLuggages)
		{
			return null;
		}

		private List<InGameShopItem.InGameShopItemData> GetInGameShopItemsForRelic(List<eRelic> targetRelics)
		{
			return null;
		}

		private List<InGameShopItem.InGameShopItemData> GetInGameShopItemsForMotif()
		{
			return null;
		}

		private List<InGameShopItem.InGameShopItemData> GetInGameShopItemsForOther()
		{
			return null;
		}

		public void OnClickItem(InGameShopItem targetItem)
		{
		}

		private void UpdatePrice()
		{
		}

		private void UpdateDetail()
		{
		}

		public void OnClickPurchaseButton()
		{
		}

		[IteratorStateMachine(typeof(_003CHeroInfoAutoSwitching_003Ed__62))]
		private IEnumerator HeroInfoAutoSwitching()
		{
			return null;
		}

		public void OnToggleInfo(int infoNumber)
		{
		}

		private void ToggleInfo(int infoNumber)
		{
		}

		public void OnNextInfo()
		{
		}

		public void OnPrevInfo()
		{
		}

		private void ResetButtonEnable(int infoIdx)
		{
		}

		public override void PushEscape()
		{
		}

		public override void Back()
		{
		}

		public void CloseAndCreateNotice()
		{
		}

		public void MovePurchaseGroup()
		{
		}

		public override void SetInFront()
		{
		}
	}
}
