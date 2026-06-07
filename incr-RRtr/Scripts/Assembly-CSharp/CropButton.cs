using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CropButton : MonoBehaviour
{
	public CropType cropType;

	[Header("Unlock button")]
	[SerializeField]
	private GameObject unlockButton;

	[SerializeField]
	private TMP_Text unlockPriceText;

	private int unlockPrice;

	[SerializeField]
	private Image unlockLogo;

	[Header("Buy button")]
	[SerializeField]
	private GameObject buyButton;

	[SerializeField]
	private TMP_Text individualPriceText;

	private int individualPrice;

	[SerializeField]
	private Image cropLogo;

	private const string COIN = "<color=#C38E00>©</color>";

	private void Start()
	{
		if (GameManager.ins.isCropUnlocked(cropType))
		{
			unlockButton.SetActive(value: false);
			buyButton.SetActive(value: true);
		}
		else
		{
			buyButton.SetActive(value: false);
			unlockButton.SetActive(value: true);
		}
		unlockLogo.sprite = GameManager.ins.getCropSprite(cropType);
		cropLogo.sprite = unlockLogo.sprite;
		unlockPriceText.text = "<color=#C38E00>©</color>" + unlockPrice;
		individualPriceText.text = "<color=#C38E00>©</color>" + individualPrice;
	}

	public void UnlockCrop()
	{
		unlockButton.SetActive(value: false);
		buyButton.SetActive(value: true);
	}

	public void BuySeed()
	{
		GameManager.ins.SetCurrentCropSelectedTo(cropType);
		GameManager.ins.state = GameManager.State.CanPlantSeed;
	}
}
