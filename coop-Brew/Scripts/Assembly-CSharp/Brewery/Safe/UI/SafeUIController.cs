using InventorySystem;
using UI.Core;
using UnityEngine;
using UnityEngine.UIElements;

namespace Brewery.Safe.UI
{
	[RequireComponent(typeof(UIDocument))]
	public class SafeUIController : MonoBehaviour, IUIPanel
	{
		[Header("UI References")]
		[SerializeField]
		private UIDocument uiDocument;

		[SerializeField]
		private VisualTreeAsset safeUITemplate;

		[SerializeField]
		private StyleSheet safeUIStyleSheet;

		private VisualElement root;

		private VisualElement container;

		private VisualElement panel;

		private Label titleLabel;

		private Label amountLabel;

		private Label capacityLabel;

		private Button closeButton;

		private VisualElement progressFill;

		private Button tabDepositButton;

		private Button tabWithdrawButton;

		private VisualElement depositContent;

		private VisualElement withdrawContent;

		private SliderInt depositSlider;

		private Label depositAmountLabel;

		private Label depositMaxLabel;

		private Button depositButton;

		private SliderInt withdrawSlider;

		private Label withdrawAmountLabel;

		private Label withdrawMaxLabel;

		private Button withdrawButton;

		private SafeInventoryManager currentSafe;

		private InventoryManager currentPlayerInventory;

		private ulong currentSafeNetworkId;

		private bool isOpen;

		private bool uiInitialized;

		private bool isDepositTab;

		public static SafeUIController Instance { get; private set; }

		public string PanelId => null;

		public int Priority => 0;

		public bool IsOpen => false;

		public bool HasActiveInventory => false;

		public void Close()
		{
		}

		public bool CanAcceptItem(Item item)
		{
			return false;
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void SetupUI()
		{
		}

		public void BindSafe(ulong safeNetworkObjectId)
		{
		}

		public void UnbindSafe()
		{
		}

		public void UnbindSafe(ulong safeNetworkObjectId)
		{
		}

		public bool IsBoundTo(ulong safeNetworkObjectId)
		{
			return false;
		}

		public void TransferPlayerMoneyToSafe(int playerSlotIndex)
		{
		}

		private void SwitchTab(bool deposit)
		{
		}

		private void Subscribe()
		{
		}

		private void Unsubscribe()
		{
		}

		private void OnCurrencyChanged(int newAmount)
		{
		}

		private void OnPlayerInventoryUpdated()
		{
		}

		private void Show()
		{
		}

		private void Hide()
		{
		}

		private void ReleaseCurrentSafe()
		{
		}

		private void HideImmediate()
		{
		}

		private void RefreshUI()
		{
		}

		private int GetIncrement()
		{
			return 0;
		}

		private int GetPlayerMoneyCount()
		{
			return 0;
		}

		private void OnDepositSliderChanged(ChangeEvent<int> evt)
		{
		}

		private void OnWithdrawSliderChanged(ChangeEvent<int> evt)
		{
		}

		private void OnDepositClicked()
		{
		}

		private void OnWithdrawClicked()
		{
		}
	}
}
