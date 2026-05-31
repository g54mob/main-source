using System.Collections.Generic;
using UnityEngine;

public class SFXManager : NoktaSingleton<SFXManager>
{
	[Header("Settings")]
	[SerializeField]
	private Vector2 m_RandomPitchRange;

	[Header("Sounds")]
	[SerializeField]
	private AudioSource m_DroppingBoxSFX;

	[SerializeField]
	private AudioSource m_CoinSFX;

	[SerializeField]
	private AudioSource m_MoneyPaperSFX;

	[SerializeField]
	private AudioSource m_CashRegisterOpen;

	[SerializeField]
	private AudioSource m_CashRegisterClose;

	[SerializeField]
	private AudioSource m_PickingUpBox;

	[SerializeField]
	private AudioSource m_ScanningProduct;

	[SerializeField]
	private AudioSource m_Checkout;

	[SerializeField]
	private AudioSource m_PlacingProduct;

	[SerializeField]
	private AudioSource m_MouseClick;

	[SerializeField]
	private AudioSource m_CheckoutWarning;

	[SerializeField]
	private AudioSource m_ScaleWarning;

	[SerializeField]
	private AudioSource m_SwitchOn;

	[SerializeField]
	private AudioSource m_SwitchOff;

	[SerializeField]
	private AudioSource m_CustomerNeedHelp;

	[SerializeField]
	private AudioSource m_DirtyStoreWarning;

	[SerializeField]
	private AudioSource m_MopCleaning;

	[SerializeField]
	private AudioSource m_WindowCleaning;

	[SerializeField]
	private AudioSource m_GarbageCollect;

	[SerializeField]
	private AudioSource m_BaseballBatSwing;

	[SerializeField]
	private AudioSource m_CityEdgeWarning;

	[SerializeField]
	private AudioSource m_WholesaleOfferWarning;

	[SerializeField]
	private AudioSource m_OnlineOrderWarning;

	[SerializeField]
	private List<AudioSource> m_BaseballBatHit;

	[SerializeField]
	private List<AudioSource> m_CustomerHitMale;

	[SerializeField]
	private List<AudioSource> m_CustomerHitFemale;

	public bool IsMopCleaningPlaying => false;

	public void PlayPlacingProductSFX(Vector3 playSoundPosition)
	{
	}

	public void PlayDroppingBoxSFX(Vector3 playSoundPosition)
	{
	}

	public void PlayDroppingUpPaintSFX(Vector3 playSoundPosition)
	{
	}

	public void PlayPickingUpBoxSFX(Vector3 playSoundPosition)
	{
	}

	public void PlayPickingUpPaintSFX(Vector3 playSoundPosition)
	{
	}

	public void PlayCheckoutSFX(Vector3 playSoundPosition)
	{
	}

	public void PlayCoinSFX(Vector3 playSoundPosition)
	{
	}

	public void PlayMoneyPaperSFX(Vector3 playSoundPosition)
	{
	}

	public void PlayCashRegister(bool open, Vector3 playSoundPosition)
	{
	}

	public void PlayScanningProductSFX(Vector3 playSoundPosition)
	{
	}

	public void PlayCheckoutWarningSFX(Vector3 playSoundPosition)
	{
	}

	public void PlayBaseballBatHitSFX(Vector3 hitPosition)
	{
	}

	public void PlayCustomerHitMaleSFX(Vector3 hitPosition)
	{
	}

	public void PlayCustomerHitFemaleSFX(Vector3 hitPosition)
	{
	}

	public void PlaySwitchSFX(bool on, Vector3 playSoundPosition)
	{
	}

	public void PlayCustomerNeedHelpSFX(Vector3 playSoundPosition)
	{
	}

	public void PlayMopCleaningSFX(Vector3 playSoundPosition)
	{
	}

	public void StopMopCleaningSFX(Vector3 playSoundPosition)
	{
	}

	public void PlayWindowCleaningSFX(Vector3 playSoundPosition)
	{
	}

	public void StopWindowCleaningSFX(Vector3 playSoundPosition)
	{
	}

	public void PlayGarbageCollectSFX(Vector3 playSoundPosition)
	{
	}

	public void PlayBaseballBatSwingSFX(Vector3 playSoundPosition)
	{
	}

	public void PlayScaleWarning(Vector3 playSoundPosition)
	{
	}

	public void PlayCityEdgeWarning()
	{
	}

	public void PlayWholesaleOfferSFX()
	{
	}

	public void PlayOnlineOrderSFX()
	{
	}

	public void PlayMouseClickSFX()
	{
	}

	public void PlayDirtyStoreWarningSFX()
	{
	}

	public void PlayPickingUpBaseballBatSFX()
	{
	}
}
