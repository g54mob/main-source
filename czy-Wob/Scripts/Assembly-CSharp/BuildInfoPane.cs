using TMPro;
using UnityEngine;

public class BuildInfoPane : PaneBase
{
	public GameObject objNameTab;

	public GameObject objPreviewHolder;

	public CoreButton buyButton;

	public TextMeshPro objNameText;

	public TextMeshPro objDescriptionText;

	public TextMeshPro priceText;

	public TextMeshPro buyText;

	public float validBuyAlpha = 1f;

	public float invalidBuyAlpha = 0.3f;

	public GameObject invalidBuyText;

	private BuildableObject currentObject;

	private float slideInTime = 0.1f;

	private float slideOutTime = 0.1f;

	private float elementsToLoad = 1f;

	private float elementsLoaded;

	private Vector3 originalNameTabPosition;

	private Vector3 slideVector = new Vector3(-8f, 0f, 0f);

	private Vector3 nameTabSlideVector = new Vector3(0f, 2f, 0f);

	private ConstructionManager constructionRef;

	protected override void AwakeBehavior()
	{
		base.AwakeBehavior();
		originalNameTabPosition = objNameTab.transform.localPosition;
		constructionRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<ConstructionManager>(GlobalObject.CONSTRUCTION_MANAGER);
		invalidBuyText.SetActive(value: false);
	}

	private void OnEnable()
	{
		objNameTab.SetActive(value: false);
		UpdateBuyButtonValidity();
	}

	private void OnDisable()
	{
		base.gameObject.SetActive(value: false);
	}

	public void SetActiveObject(BuildableObject newObj)
	{
		currentObject = newObj;
		UpdatePrice();
		UpdateNameAndDescription();
	}

	private void UpdateNameAndDescription()
	{
		if (currentObject == null)
		{
			objNameText.text = "";
			objDescriptionText.text = "";
		}
		else
		{
			objNameText.text = currentObject.GetName();
			objDescriptionText.text = currentObject.GetDescription();
		}
	}

	private void UpdatePrice()
	{
		if (currentObject == null)
		{
			priceText.text = null;
		}
		else
		{
			priceText.text = currentObject.GetFormattedPrice();
		}
		UpdateBuyButtonValidity();
	}

	public override void ForceImmediateUnload()
	{
		DisableBuyButton(fromUnload: true);
		elementsLoaded = 0f;
		base.ForceImmediateUnload();
	}

	protected override void LoadBehavior()
	{
		CancelCurrentEase();
		currentEase = inchwormRef.RequestEase(base.gameObject, slideVector, slideInTime, adjustStartingPos: true, Inchworm.EaseStyle.QuadraticOut, Inchworm.EaseType.Position, OnBasePaneLoaded);
	}

	private void OnBasePaneLoaded()
	{
		objNameTab.SetActive(value: true);
		inchwormRef.RequestEase(objNameTab, nameTabSlideVector, slideInTime, adjustStartingPos: true, Inchworm.EaseStyle.QuadraticOut, Inchworm.EaseType.Position, OnElementLoaded);
	}

	protected override void UnloadBehavior()
	{
		DisableBuyButton(fromUnload: true);
		inchwormRef.RequestEase(objNameTab, -nameTabSlideVector, slideOutTime, adjustStartingPos: false, Inchworm.EaseStyle.QuadraticOut, Inchworm.EaseType.Position, OnElementUnloaded);
	}

	private void OnElementLoaded()
	{
		elementsLoaded += 1f;
		if (elementsLoaded >= elementsToLoad)
		{
			OnChildrenLoaded();
		}
	}

	private void OnElementUnloaded()
	{
		elementsLoaded -= 1f;
		if (elementsLoaded <= 0f)
		{
			OnChildrenUnloaded();
		}
	}

	private void OnChildrenUnloaded()
	{
		objNameTab.transform.localPosition = originalNameTabPosition;
		objNameTab.SetActive(value: false);
		CancelCurrentEase();
		currentEase = inchwormRef.RequestEase(base.gameObject, -slideVector, slideOutTime, adjustStartingPos: false, Inchworm.EaseStyle.QuadraticOut, Inchworm.EaseType.Position, OnUnloadComplete);
	}

	private void OnChildrenLoaded()
	{
		UpdateBuyButtonValidity();
		OnLoadComplete();
	}

	public void UpdateBuyButtonValidity()
	{
		if (currentObject == null)
		{
			DisableBuyButton();
		}
		else
		{
			SetupBuyButton();
		}
	}

	private void SetupBuyButton()
	{
		buyButton.UnlockScale();
		invalidBuyText.SetActive(value: false);
		buyText.color = new Color(buyText.color.r, buyText.color.g, buyText.color.b, validBuyAlpha);
	}

	private void DisableBuyButton(bool fromUnload = false)
	{
		buyButton.LockScale();
		if (!fromUnload)
		{
			invalidBuyText.SetActive(value: true);
			buyText.color = new Color(buyText.color.r, buyText.color.g, buyText.color.b, invalidBuyAlpha);
		}
	}

	public void BuyButtonClicked()
	{
		constructionRef.BuildSpecificRoom(currentObject);
	}
}
