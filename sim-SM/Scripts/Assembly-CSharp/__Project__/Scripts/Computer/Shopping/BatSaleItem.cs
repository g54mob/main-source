using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace __Project__.Scripts.Computer.Shopping
{
	public class BatSaleItem : MonoBehaviour
	{
		[SerializeField]
		private float m_Price;

		[SerializeField]
		private TMP_Text m_PriceText;

		[SerializeField]
		private Image m_AlreadyPurchasedImage;

		[SerializeField]
		private Button m_PurchaseButton;

		[SerializeField]
		private Color m_False;

		[SerializeField]
		private Color m_True;

		private bool IsPurchased => false;

		private void OnEnable()
		{
		}

		public void Setup()
		{
		}

		private void LockBat()
		{
		}

		private void UnlockBat()
		{
		}

		private void AlreadyPurchased()
		{
		}

		public void Purchase()
		{
		}

		private void UpdateButtonInteraction(float _, MoneyManager.TransitionType type)
		{
		}
	}
}
