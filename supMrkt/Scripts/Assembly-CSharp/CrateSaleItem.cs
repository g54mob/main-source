using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CrateSaleItem : MonoBehaviour
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

	private bool m_IsWarningShowed;

	private bool IsPurchased => false;

	private void OnEnable()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnComputerInteractionStopped()
	{
	}

	public void Setup()
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

	public void Purchase()
	{
	}

	private void UpdateButtonInteraction(float _, MoneyManager.TransitionType type)
	{
	}
}
