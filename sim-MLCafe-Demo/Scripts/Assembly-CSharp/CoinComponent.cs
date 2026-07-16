using UnityEngine;

public class CoinComponent : MonoBehaviour
{
	public enum CoinType
	{
		ProductPay = 0,
		Tip = 1
	}

	[SerializeField]
	private CoinType coinType;

	[SerializeField]
	private int amount;

	[SerializeField]
	private GameObject coinGameObject;

	[Header("Sound")]
	[SerializeField]
	public string soundTakeCoin;

	public void Init(int amount)
	{
		this.amount = amount;
	}

	public void OnInteraction(CharacterControllerComponent character)
	{
		TakeCoin();
	}

	public void TakeCoin(bool playSound = true)
	{
		WalletSystem.GetPlayerWallet().AddAmount(amount);
		if (playSound)
		{
			SoundManager.PlaySoundOnce(soundTakeCoin);
		}
		if (base.gameObject != null)
		{
			Object.Destroy(base.gameObject);
		}
		if (coinType == CoinType.Tip)
		{
			ProgressionManager.GainXP("Tip", amount);
		}
	}
}
