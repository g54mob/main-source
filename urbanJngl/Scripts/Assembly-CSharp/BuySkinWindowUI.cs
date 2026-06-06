using System;
using Infrastructure.Services;
using Infrastructure.Services.CoinService;
using Infrastructure.Services.PersistentProgress;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuySkinWindowUI : MonoBehaviour
{
	public class OnNewSkinPurchasedEventArgs : EventArgs
	{
		public ObjectSO objectSO;

		public string GUID;

		public Sprite skinSprite;
	}

	[SerializeField]
	private Image skinImage;

	[SerializeField]
	private TextMeshProUGUI priceText;

	[SerializeField]
	private Button yesButton;

	[SerializeField]
	private Button noButton;

	private ObjectSO objectSO;

	private string variantGUID;

	private int price;

	public static BuySkinWindowUI Instance { get; private set; }

	public event EventHandler<OnNewSkinPurchasedEventArgs> OnNewSkinPurchased;

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		Hide();
		yesButton.onClick.AddListener(delegate
		{
			TryToBuySkin();
		});
		noButton.onClick.AddListener(delegate
		{
			Hide();
		});
	}

	private void Show()
	{
		base.gameObject.SetActive(value: true);
	}

	private void Hide()
	{
		base.gameObject.SetActive(value: false);
	}

	public void ShowBuySkinWindow(ObjectSO objectSO, string variantGUID, Sprite variantSprite)
	{
		skinImage.sprite = objectSO.variantsList.Find((Variant skin) => skin.GUID == variantGUID).variantSprite;
		this.objectSO = objectSO;
		this.variantGUID = variantGUID;
		price = CollectionManager.Instance.GetPrice(objectSO, variantGUID);
		priceText.text = price.ToString();
		Show();
	}

	private void OnDestroy()
	{
		noButton.onClick.RemoveAllListeners();
	}

	private void TryToBuySkin()
	{
		if (AllServices.Container.Single<IPersistentProgressService>().Progress.Coins >= price)
		{
			this.OnNewSkinPurchased?.Invoke(this, new OnNewSkinPurchasedEventArgs
			{
				objectSO = objectSO,
				GUID = variantGUID,
				skinSprite = skinImage.sprite
			});
			AllServices.Container.Single<ICoinService>().SubtractCoin(price);
			Hide();
		}
	}
}
