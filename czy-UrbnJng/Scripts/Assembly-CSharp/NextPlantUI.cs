using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Data.Enums;
using Infrastructure.Services;
using Infrastructure.Services.CoinService;
using Infrastructure.Services.PersistentProgress;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class NextPlantUI : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private Image plantImage;

	[SerializeField]
	private TextMeshProUGUI plantName;

	[SerializeField]
	private List<TextMeshProUGUI> plantNameColors;

	[SerializeField]
	private Transform skinTemplate;

	[SerializeField]
	private Image notifyerNew;

	[SerializeField]
	private List<Transform> cards;

	[SerializeField]
	private List<Transform> rarityInfo;

	[SerializeField]
	private Transform outline;

	[SerializeField]
	private TextMeshProUGUI skinPriceText;

	[SerializeField]
	private Transform skinPrice;

	[SerializeField]
	private Transform skinPriceFree;

	[SerializeField]
	private Button randomButton;

	[SerializeField]
	private TextMeshProUGUI score;

	[SerializeField]
	private TextMeshProUGUI tip;

	[SerializeField]
	private TextMeshProUGUI cost;

	[SerializeField]
	private Transform humidity;

	[SerializeField]
	private Transform light;

	[SerializeField]
	private Transform noHumidity;

	[SerializeField]
	private Transform noLight;

	[SerializeField]
	private ScrollRect scrollRect;

	private ObjectSO objectSO;

	private int variantNumber;

	private int index;

	private int price;

	private List<NextPlantSkinUI> nextPlantSkinUIList = new List<NextPlantSkinUI>();

	private NextPlantSkinUI chosenSkin;

	private bool hover;

	private PlayerInputActions playerInputActions;

	private bool isPlantChosen;

	private bool isPointerOver;

	private CanvasGroup canvasGroup;

	private Sequence appearAnimation;

	private Tween loopAnimation;

	private void Awake()
	{
		playerInputActions = new PlayerInputActions();
		canvasGroup = GetComponent<CanvasGroup>();
	}

	private void Update()
	{
		CardTilt();
	}

	private void OnEnable()
	{
		playerInputActions.Enable();
		playerInputActions.ChoosePlant.LeftSkin.performed += OnLeftArrow;
		playerInputActions.ChoosePlant.RightSkin.performed += OnRightArrow;
		playerInputActions.ChoosePlant.RandomSkin.performed += OnRandomSkinButton;
	}

	private void OnDisable()
	{
		playerInputActions.ChoosePlant.LeftSkin.performed -= OnLeftArrow;
		playerInputActions.ChoosePlant.RightSkin.performed -= OnRightArrow;
		playerInputActions.ChoosePlant.RandomSkin.performed -= OnRandomSkinButton;
		playerInputActions.Disable();
	}

	public static NextPlantUI Create(Transform nextPlantTemplate, ObjectSO objSO, int index, int variantNumber)
	{
		Transform transform = Object.Instantiate(nextPlantTemplate, nextPlantTemplate.parent);
		transform.gameObject.SetActive(value: true);
		NextPlantUI nextPlantUI = transform.GetComponent<NextPlantUI>();
		nextPlantUI.objectSO = objSO;
		nextPlantUI.variantNumber = variantNumber;
		nextPlantUI.price = objSO.variantsList[variantNumber].price;
		nextPlantUI.cost.text = nextPlantUI.price.ToString();
		nextPlantUI.GetComponent<Button>().onClick.AddListener(delegate
		{
			nextPlantUI.PlantChosen(isSkinClick: false);
		});
		nextPlantUI.plantName.text = CollectionManager.Instance.GetPlantNameLocalize(objSO.objectName);
		nextPlantUI.index = index;
		nextPlantUI.tip.text = CollectionManager.Instance.GetPlantTipLocalize(objSO.objectName);
		CollectionManager.Instance.AddPlantToCollection(objSO.GUID);
		if (CollectionManager.Instance.PlantCardOpen(objSO.variantsList[variantNumber].GUID))
		{
			nextPlantUI.notifyerNew.gameObject.SetActive(value: true);
		}
		nextPlantUI.randomButton.onClick.AddListener(delegate
		{
			nextPlantUI.GetRandomSkin();
		});
		nextPlantUI.SetSkins();
		foreach (NextPlantSkinUI nextPlantSkinUI in nextPlantUI.nextPlantSkinUIList)
		{
			nextPlantSkinUI.OnSkinChosen += nextPlantUI.NextPlantSkin_OnSkinChosen;
		}
		nextPlantUI.skinTemplate.gameObject.SetActive(value: false);
		nextPlantUI.chosenSkin = nextPlantUI.nextPlantSkinUIList[variantNumber];
		switch (objSO.variantsList[variantNumber].rareLevel)
		{
		case PlantRareLevel.Common:
			nextPlantUI.cards[0].gameObject.SetActive(value: true);
			nextPlantUI.rarityInfo[0].gameObject.SetActive(value: true);
			nextPlantUI.plantName.color = nextPlantUI.plantNameColors[0].color;
			break;
		case PlantRareLevel.Uncommon:
			nextPlantUI.cards[1].gameObject.SetActive(value: true);
			nextPlantUI.rarityInfo[1].gameObject.SetActive(value: true);
			nextPlantUI.plantName.color = nextPlantUI.plantNameColors[1].color;
			break;
		case PlantRareLevel.Rare:
			nextPlantUI.cards[2].gameObject.SetActive(value: true);
			nextPlantUI.rarityInfo[2].gameObject.SetActive(value: true);
			nextPlantUI.plantName.color = nextPlantUI.plantNameColors[2].color;
			break;
		}
		nextPlantUI.UpdateVisual();
		nextPlantUI.canvasGroup.alpha = 0f;
		return nextPlantUI;
	}

	private void NextPlantSkin_OnSkinChosen(object sender, NextPlantSkinUI.OnSkinChosenEventArgs e)
	{
		PlantChosen(isSkinClick: true);
		chosenSkin = e.chosenSkin;
		UpdateVisual();
		ChooseNextPlantWindowUI.Instance.UpdateButtonOnSkinChange();
	}

	public void AppearAnimation()
	{
		appearAnimation = DOTween.Sequence();
		base.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
		canvasGroup.alpha = 1f;
		appearAnimation.Append(base.transform.DOScale(1.05f, 0.2f).SetEase(Ease.OutSine)).Append(base.transform.DOScale(1f, 0.1f).SetEase(Ease.InOutSine)).Play();
	}

	public void Hide()
	{
		canvasGroup.alpha = 0f;
	}

	public void LoopAnimation()
	{
		loopAnimation = base.transform.DOScale(0.9f, 1.5f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo)
			.Play();
	}

	private void UpdateVisual()
	{
		plantImage.sprite = chosenSkin.GetSkinSprite();
		int num = chosenSkin.GetSkinPrice();
		if (num != 0)
		{
			skinPrice.gameObject.SetActive(value: true);
			skinPriceText.text = num.ToString();
		}
		else
		{
			skinPriceFree.gameObject.SetActive(value: true);
		}
		int num2 = 0;
		if (objectSO.variantsList[variantNumber].rareLevel == PlantRareLevel.Uncommon)
		{
			num2 = 5;
		}
		if (objectSO.variantsList[variantNumber].rareLevel == PlantRareLevel.Rare)
		{
			num2 = 10;
		}
		score.text = (objectSO.score + num2).ToString();
		tip.text = CollectionManager.Instance.GetPlantTipLocalize(objectSO.objectName);
		if (objectSO.sunlight == EnvironmentSunlight.Sunlight.Low)
		{
			noLight.gameObject.SetActive(value: true);
		}
		else
		{
			light.gameObject.SetActive(value: true);
		}
		if (objectSO.humidity == EnvironmentHumidity.Humidity.Low)
		{
			noHumidity.gameObject.SetActive(value: true);
		}
		else
		{
			humidity.gameObject.SetActive(value: true);
		}
		foreach (NextPlantSkinUI nextPlantSkinUI in nextPlantSkinUIList)
		{
			nextPlantSkinUI.ToggleOutline(nextPlantSkinUI == chosenSkin);
		}
	}

	private void GetRandomSkin()
	{
		List<NextPlantSkinUI> list = new List<NextPlantSkinUI>();
		foreach (NextPlantSkinUI nextPlantSkinUI2 in nextPlantSkinUIList)
		{
			if (nextPlantSkinUI2.IsUnlocked())
			{
				list.Add(nextPlantSkinUI2);
			}
		}
		if (list.Count > 1)
		{
			NextPlantSkinUI nextPlantSkinUI;
			do
			{
				nextPlantSkinUI = list[Random.Range(0, list.Count)];
			}
			while (nextPlantSkinUI == chosenSkin);
			chosenSkin = nextPlantSkinUI;
			UpdateVisual();
		}
	}

	public void TryToBuySkin()
	{
		if (chosenSkin != null && !chosenSkin.IsUnlocked())
		{
			int num = chosenSkin.GetSkinPrice();
			if (AllServices.Container.Single<IPersistentProgressService>().Progress.Coins >= num)
			{
				AllServices.Container.Single<ICoinService>().SubtractCoin(num);
				chosenSkin.Unlock();
				chosenSkin.HidePrice();
				CollectionManager.Instance.NewSkinPurchased(chosenSkin.GetGUID(), objectSO);
				UpdateVisual();
				Debug.Log("You purchased skin!");
				ChooseNextPlantWindowUI.Instance.UpdateButtonOnSkinChange();
			}
			else
			{
				Debug.Log("You don't have enough flowers");
			}
		}
		else
		{
			Debug.Log("There is no chosen skin");
		}
	}

	private void OnLeftArrow(InputAction.CallbackContext context)
	{
		if (hover)
		{
			ChangeSkin(-1);
		}
	}

	private void OnRightArrow(InputAction.CallbackContext context)
	{
		if (hover)
		{
			ChangeSkin(1);
		}
	}

	private void OnRandomSkinButton(InputAction.CallbackContext obj)
	{
		if (hover)
		{
			GetRandomSkin();
		}
	}

	private void ChangeSkin(int direction)
	{
		int num = (nextPlantSkinUIList.IndexOf(chosenSkin) + direction + nextPlantSkinUIList.Count) % nextPlantSkinUIList.Count;
		chosenSkin = nextPlantSkinUIList[num];
		PlantChosenFromGamepad(isSkinClick: true);
		UpdateVisual();
		ScrollToSelectedSkin();
	}

	private void ScrollToSelectedSkin()
	{
		Vector3 localPosition = chosenSkin.GetComponent<RectTransform>().localPosition;
		RectTransform content = scrollRect.content;
		RectTransform viewport = scrollRect.viewport;
		float width = content.rect.width;
		float width2 = viewport.rect.width;
		if (!(width <= width2))
		{
			Vector2 anchoredPosition = content.anchoredPosition;
			float x = Mathf.Clamp(0f - localPosition.x + width2 / 2f, 0f - (width - width2), 0f);
			content.anchoredPosition = new Vector2(x, anchoredPosition.y);
		}
	}

	private void SetSkins()
	{
		if (objectSO.variantsList.Count > 0)
		{
			foreach (Variant variants in objectSO.variantsList)
			{
				NextPlantSkinUI item = NextPlantSkinUI.Create(objectSO, variants.GUID, variants.variantSprite, variants.variantSpriteBW, variants.size, skinTemplate, this);
				nextPlantSkinUIList.Add(item);
			}
			return;
		}
		NextPlantSkinUI item2 = NextPlantSkinUI.Create(objectSO, objectSO.GUID, objectSO.sprite, objectSO.sprite, objectSO.size, skinTemplate, this);
		nextPlantSkinUIList.Add(item2);
	}

	public int GetIndex()
	{
		return index;
	}

	public ObjectSO GetSO()
	{
		return objectSO;
	}

	public string GetGUID()
	{
		return chosenSkin.GetGUID();
	}

	public int GetPrice()
	{
		return price;
	}

	public string GetVariantGUID()
	{
		return objectSO.variantsList[variantNumber].GUID;
	}

	public void PlantChosen(bool isSkinClick)
	{
		if (isPlantChosen || !isPointerOver)
		{
			return;
		}
		isPlantChosen = true;
		if (isSkinClick)
		{
			if (chosenSkin.IsUnlocked())
			{
				if (!ChooseNextPlantWindowUI.Instance.IsPlantSelected(this))
				{
					ChooseNextPlantWindowUI.Instance.PlantChosen(this);
				}
			}
			else
			{
				ChooseNextPlantWindowUI.Instance.DeselectSkin(this);
			}
		}
		else
		{
			chosenSkin.ToggleOutline(value: true);
			ChooseNextPlantWindowUI.Instance.PlantChosen(this);
		}
		StartCoroutine(ResetChangeSkinFlag());
	}

	public void PlantChosenFromGamepad(bool isSkinClick)
	{
		if (isSkinClick)
		{
			if (chosenSkin.IsUnlocked())
			{
				if (!ChooseNextPlantWindowUI.Instance.IsPlantSelected(this))
				{
					ChooseNextPlantWindowUI.Instance.PlantChosen(this);
				}
			}
			else
			{
				ChooseNextPlantWindowUI.Instance.DeselectSkin(this);
			}
		}
		else
		{
			chosenSkin.ToggleOutline(value: true);
			if (chosenSkin.IsUnlocked())
			{
				ChooseNextPlantWindowUI.Instance.PlantChosen(this);
			}
			else
			{
				ChooseNextPlantWindowUI.Instance.DeselectSkin(this);
			}
		}
	}

	private IEnumerator ResetChangeSkinFlag()
	{
		yield return new WaitForSeconds(0.6f);
		isPlantChosen = false;
	}

	public void ToggleChosen(bool value)
	{
		outline.gameObject.SetActive(value);
	}

	public void DestroySelf()
	{
		Object.Destroy(base.gameObject);
	}

	private void OnDestroy()
	{
		GetComponent<Button>().onClick.RemoveAllListeners();
		randomButton.onClick.RemoveAllListeners();
	}

	public bool IsChosenSkinUnlocked()
	{
		return chosenSkin.IsUnlocked();
	}

	private void CardTilt()
	{
		float num = Mathf.Sin(Time.time);
		float num2 = Mathf.Cos(Time.time);
		float num3 = 4f;
		float num4 = 8f;
		if (hover)
		{
			num4 = 4f;
		}
		float x = Mathf.LerpAngle(base.transform.eulerAngles.x, num * num4, num3 * Time.deltaTime);
		float y = Mathf.LerpAngle(base.transform.eulerAngles.y, num2 * num4, num3 * Time.deltaTime);
		float z = Mathf.LerpAngle(base.transform.eulerAngles.z, 0f, num3 / 2f * Time.deltaTime);
		base.transform.eulerAngles = new Vector3(x, y, z);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		ChooseNextPlantWindowUI.Instance.DeactivateAllChooses(this);
		ActivateChoose();
		isPointerOver = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		isPointerOver = false;
		DeactivateChoose();
	}

	public void ActivateChoose()
	{
		hover = true;
		float num = 1.1f;
		base.transform.DOScale(new Vector3(num, num, num), 0.3f).SetEase(Ease.InOutSine);
	}

	public void DeactivateChoose()
	{
		hover = false;
		base.transform.DOComplete();
		base.transform.DOScale(Vector3.one, 0.1f).SetEase(Ease.InOutSine);
	}
}
