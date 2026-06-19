using System.Collections;
using Aggro.Core;
using Aggro.Core.Networking;
using FMODUnity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanelUI : AggroManagerBase<ShopPanelUI>
{
	public struct Data
	{
		public ShopHolder holder;

		public string itemName;

		public int itemPrice;

		public string itemDesc;

		public Sprite itemIcon;
	}

	public RectTransform container;

	public TextMeshProUGUI itemPriceText;

	public LocalizedText itemNameLocalizedText;

	public LocalizedText itemDescLocalizedText;

	public Image itemIcon;

	public Image priceBackground;

	public GameObject purchasedIndicator;

	public float animationTime = 1f;

	public float hideOffset;

	public bool shouldDisplay;

	public bool isTransitioning;

	public bool isVisible;

	public Color canAffordColor = Color.white;

	public Color cannotAffordColor = Color.white;

	public StudioEventEmitter slideInSFXEmitter;

	public StudioEventEmitter slideOutSFXEmitter;

	public GameObject buyHintGameObject;

	public GameObject onSaleObject;

	public TextMeshProUGUI oldTextSale;

	private Data currentData;

	private Data nextData;

	private int _prevPrice = -1;

	public EasingFunction.Ease ease = EasingFunction.Ease.Linear;

	protected override void OnEntityCreated()
	{
		container.transform.localPosition = new Vector3(container.transform.localPosition.x, hideOffset, container.transform.localPosition.z);
		itemDescLocalizedText.onRefreshText = (string x) => GlobalScriptableObject<TextTagData>.instance.ParseText(x);
	}

	protected override void OnUpdatePresentation()
	{
		if (shouldDisplay && !isTransitioning && !isVisible)
		{
			StartPresentationCoroutine(SlideInCo());
			slideInSFXEmitter.Play();
		}
		if (!shouldDisplay && !isTransitioning && isVisible)
		{
			StartPresentationCoroutine(SlideOutCo());
			slideOutSFXEmitter.Play();
		}
		if (currentData.holder != nextData.holder && !isTransitioning && isVisible)
		{
			StartPresentationCoroutine(SlideOutCo());
			slideOutSFXEmitter.Play();
		}
		itemIcon.sprite = currentData.itemIcon;
		if (currentData.itemName != null)
		{
			itemNameLocalizedText.SetIndex(currentData.itemName);
		}
		if (currentData.itemDesc != null)
		{
			itemDescLocalizedText.SetIndex(currentData.itemDesc);
		}
		if (_prevPrice != currentData.itemPrice)
		{
			itemPriceText.text = "$" + currentData.itemPrice;
		}
		if (currentData.holder != null)
		{
			purchasedIndicator.SetActive(!currentData.holder.LocalPlayerCanPurchase());
			buyHintGameObject.SetActive(currentData.holder.LocalPlayerCanPurchase());
			onSaleObject.SetActive(currentData.holder.OnSale);
			oldTextSale.gameObject.SetActive(currentData.holder.OnSale);
			if (_prevPrice != currentData.itemPrice)
			{
				oldTextSale.text = "$" + (float)currentData.itemPrice * 2f;
			}
		}
		_prevPrice = currentData.itemPrice;
	}

	protected override void OnUpdatePresentationLate()
	{
		shouldDisplay = false;
		if (NetworkAggroManagerBase<ShiftManager>.ManagerExists())
		{
			if (NetworkAggroManagerBase<ShiftManager>.instance.GetMoney() < currentData.itemPrice)
			{
				priceBackground.color = cannotAffordColor;
			}
			else
			{
				priceBackground.color = canAffordColor;
			}
		}
	}

	public void SetVisibleThisFrame()
	{
		shouldDisplay = true;
	}

	public void SetData(Data data)
	{
		nextData = data;
	}

	private IEnumerator SlideInCo()
	{
		currentData = nextData;
		isTransitioning = true;
		isVisible = true;
		float time = 0f;
		while (time < animationTime)
		{
			float num = time / animationTime;
			time += Time.deltaTime;
			container.transform.localPosition = new Vector3(container.transform.localPosition.x, EasingFunction.Evaluate(ease, 1f - num) * hideOffset, container.transform.localPosition.z);
			yield return null;
		}
		container.transform.localPosition = new Vector3(container.transform.localPosition.x, 0f, container.transform.localPosition.z);
		isTransitioning = false;
	}

	private IEnumerator SlideOutCo()
	{
		isTransitioning = true;
		float time = 0f;
		while (time < animationTime)
		{
			float value = time / animationTime;
			time += Time.deltaTime;
			container.transform.localPosition = new Vector3(container.transform.localPosition.x, EasingFunction.Evaluate(ease, value) * hideOffset, container.transform.localPosition.z);
			yield return null;
		}
		container.transform.localPosition = new Vector3(container.transform.localPosition.x, hideOffset, container.transform.localPosition.z);
		isTransitioning = false;
		isVisible = false;
	}
}
