using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace __Project__.Scripts.Computer.Shopping
{
	public class ScannerSaleItem : ToolSalesItem
	{
		[SerializeField]
		private float m_Price;

		[SerializeField]
		private int m_RequiredLicenceCount;

		[SerializeField]
		private TMP_Text m_PriceText;

		[SerializeField]
		private Image m_AlreadyPurchasedImage;

		[SerializeField]
		private Button m_PurchaseButton;

		[SerializeField]
		private TMP_Text m_RequiredLicenceCountText;

		[SerializeField]
		private TMP_Text m_RequiredLicenceText;

		[SerializeField]
		private Color m_False;

		[SerializeField]
		private Color m_True;

		private bool m_IsWarningShowed;

		private NetworkScannerSaleItem m_NetworkScannerSaleItem;

		public bool IsPurchased => false;

		public bool IsUnlocked => false;

		public NetworkScannerSaleItem NetworkScannerSaleItem => null;

		private void OnEnable()
		{
		}

		private void OnDestroy()
		{
		}

		private void Start()
		{
		}

		private void OnComputerInteractionStopped()
		{
		}

		public void OnLicencePurchased(int _)
		{
		}

		public void Setup()
		{
		}

		public void SetupNetwork(bool _IsPurchased, bool _IsUnlocked)
		{
		}

		private void LockScanner()
		{
		}

		private void UnlockScanner()
		{
		}

		private void AlreadyPurchased()
		{
		}

		public void AlreadyPurchasedNetwork()
		{
		}

		public void Purchase()
		{
		}

		public void PurchaseNetwork()
		{
		}

		public bool IsScannerPurchable()
		{
			return false;
		}

		private void UpdateButtonInteraction(float _, MoneyManager.TransitionType type)
		{
		}
	}
}
