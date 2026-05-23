using System;
using System.Collections;
using System.Collections.Generic;
using RainbowArt.CleanFlatUI;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Localization;
using UnityEngine.UI;

public class LapTop : MonoBehaviour, IInteractable
{
	public LocalizedString interactionText;

	private LocalizedString attachModeString = new LocalizedString("MyTable", "crafting-attach mode");

	private LocalizedString InstallString = new LocalizedString("MyTable", "install");

	private LocalizedString InstalledString = new LocalizedString("MyTable", "installed");

	private LocalizedString purchaseString = new LocalizedString("MyTable", "purcahse");

	private LocalizedString purchasedString = new LocalizedString("MyTable", "purchased");

	private LocalizedString satietyString = new LocalizedString("MyTable", "Satiety");

	private LocalizedString matString = new LocalizedString("MyTable", "matforgrain");

	private LocalizedString shopRocketTitleString = new LocalizedString("MyTable", "shopRocketTitle");

	private LocalizedString headSelectedString = new LocalizedString("MyTable", "headselected");

	private LocalizedString massString = new LocalizedString("MyTable", "crafting-mass");

	private LocalizedString frontDragString = new LocalizedString("MyTable", "crafting-frontdrag");

	private LocalizedString bodySelectedString = new LocalizedString("MyTable", "bodyselected");

	private LocalizedString thrustTimeBonusString = new LocalizedString("MyTable", "crafting-thrust time bouns");

	private LocalizedString typeString = new LocalizedString("MyTable", "crafting-type");

	private LocalizedString waterRocketString = new LocalizedString("MyTable", "crafting-waterrocket");

	private LocalizedString solidFuelRocketString = new LocalizedString("MyTable", "crafting-solidfuelrocket");

	private LocalizedString wingSelectedString = new LocalizedString("MyTable", "wingselected");

	private LocalizedString liftString = new LocalizedString("MyTable", "crafting-lift");

	private LocalizedString dragString = new LocalizedString("MyTable", "crafting-drag");

	private LocalizedString motorSelectedString = new LocalizedString("MyTable", "motorselected");

	private LocalizedString thrustPowerString = new LocalizedString("MyTable", "crafting-thrustpower");

	private LocalizedString thrustTimeString = new LocalizedString("MyTable", "crafting-thrusttime");

	private LocalizedString waterString = new LocalizedString("MyTable", "crafting- water");

	private LocalizedString solidFuelString = new LocalizedString("MyTable", "crafting-solidfuel");

	private LocalizedString nozzleSelectedString = new LocalizedString("MyTable", "nozzleselected");

	private LocalizedString multiplierString = new LocalizedString("MyTable", "crafitng-thrustpowermultiplier");

	private LocalizedString shopFoodString = new LocalizedString("MyTable", "shopFoodDesc");

	private LocalizedString shopFoodTitleString = new LocalizedString("MyTable", "shopFoodTitle");

	private LocalizedString shopMatTitleString = new LocalizedString("MyTable", "shopMatTitle");

	public Outline outLine;

	[SerializeField]
	private CinemachineCamera laptopCam;

	[SerializeField]
	private CinemachineCamera rocketComputerCam;

	[SerializeField]
	private CinemachineCamera codeCam;

	[SerializeField]
	private ModalWindowMultiButton shopDescriptionUI;

	[SerializeField]
	private ModalWindowMultiButton chipDescriptionUI;

	[SerializeField]
	private ModalWindowMultiButton videoDescriptionUI;

	[SerializeField]
	private Image shopDescriptionUIMainImage;

	[SerializeField]
	private Image chipDescriptionUIMainImage;

	[SerializeField]
	private GameObject partTimeLocked;

	[SerializeField]
	private GameObject[] powderRocketKit;

	[SerializeField]
	private ShopItem[] foodList;

	[SerializeField]
	private ShopItem[] materialList;

	[SerializeField]
	private GameObject rocketCameraKit;

	[SerializeField]
	private GameObject rocketWingControlKit;

	[SerializeField]
	private TextMeshProUGUI purchaseText;

	[SerializeField]
	private TextMeshProUGUI codePurchaseText;

	[SerializeField]
	private Animator purchaseBtnAnimator;

	[SerializeField]
	private Animator[] jobBtnAnimators;

	[SerializeField]
	private RocketComputer rocketComputer;

	[SerializeField]
	private GameObject codingTab;

	[SerializeField]
	private CanvasGroup blockEngineCanvas;

	[SerializeField]
	private GameObject codeBlock;

	[SerializeField]
	private GameObject groceryBlock;

	[SerializeField]
	private GameObject materialBlock;

	[SerializeField]
	private GameObject chipBlock;

	[SerializeField]
	private ShopItemChip[] shopItemChips;

	[SerializeField]
	private GameObject[] windows;

	private GameObject currentSelectedItem;

	private GameObject currentSelectedWindow;

	private List<GameObject> purchasedFood;

	private List<GameObject> purchasedRocket;

	public Toggle[] shopTabs;

	private Coroutine myRoutine;

	private int shopTabIndex;

	private bool isChipInstalling;

	public string InteractionText
	{
		get
		{
			if (interactionText != null && !interactionText.IsEmpty)
			{
				return interactionText.GetLocalizedString();
			}
			return "Use";
		}
	}

	public static event Action OnLapTop;

	public static event Action OffLapTop;

	public static event Action<GameObject> OnBuyRocketParts;

	private void Start()
	{
		ShoppingBag.OnUnlockFood += ShoppingBag_OnUnlockFood;
		ShoppingBag.OnUnlockMaterial += ShoppingBag_OnUnlockMaterial;
		RocketComputer.OnCpuInstalled += RocketComputer_OnCpuInstalled;
		GameManager.S.OnShopItemClicked += Gm_OnShopItemClicked;
		TearDownController.OnTeardownComplete += TearDownController_OnTeardownComplete;
		GameManager.S.OnPartTimeUnlocked += Gm_OnPartTimeUnlocked;
		QuestManager.S.OnPowerRocketUnlocked += S_OnPowerRocketUnlocked;
		QuestManager.S.OnRocketChipUnlocked += S_OnRocketChipUnlocked;
		purchasedFood = new List<GameObject>();
		purchasedRocket = new List<GameObject>();
		outLine = GetComponent<Outline>();
		if (outLine != null)
		{
			outLine.enabled = false;
		}
		if (GameManager.S.isPartTimeUnlocked)
		{
			partTimeLocked.SetActive(value: false);
		}
		if (GameManager.S.isCodingUnlocked)
		{
			codeBlock.SetActive(value: false);
		}
		if (GameManager.S.isCpuInstalled)
		{
			codingTab.SetActive(value: true);
		}
		if (GameManager.S.isPowderRocketUnlocked)
		{
			GameObject[] array = powderRocketKit;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetActive(value: true);
			}
		}
		else
		{
			GameObject[] array = powderRocketKit;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetActive(value: false);
			}
		}
	}

	private void ShoppingBag_OnUnlockMaterial(MotorIngredientItem obj)
	{
		ShopItem[] array = materialList;
		foreach (ShopItem shopItem in array)
		{
			MotorIngredientItem component = shopItem.itemGO.GetComponent<MotorIngredientItem>();
			if (obj.mainImage == component.mainImage)
			{
				materialBlock.SetActive(value: false);
				shopItem.gameObject.SetActive(value: true);
				break;
			}
		}
	}

	private void ShoppingBag_OnUnlockFood(Food obj)
	{
		ShopItem[] array = foodList;
		foreach (ShopItem shopItem in array)
		{
			Food component = shopItem.itemGO.GetComponent<Food>();
			if (obj.mainImage == component.mainImage)
			{
				groceryBlock.SetActive(value: false);
				shopItem.gameObject.SetActive(value: true);
				break;
			}
		}
	}

	private void RocketComputer_OnCpuInstalled()
	{
		codingTab.SetActive(value: true);
	}

	private void TearDownController_OnTeardownComplete(Chips obj)
	{
		GameManager.S.isCodingUnlocked = true;
		codeBlock.SetActive(value: false);
		ShopItemChip[] array = shopItemChips;
		foreach (ShopItemChip shopItemChip in array)
		{
			if (shopItemChip.itemGO.GetComponent<Chips>().chipName.GetLocalizedString() == obj.chipName.GetLocalizedString())
			{
				shopItemChip.gameObject.SetActive(value: true);
				chipBlock.SetActive(value: false);
				break;
			}
		}
	}

	private void S_OnRocketChipUnlocked()
	{
		rocketCameraKit.SetActive(value: true);
		rocketWingControlKit.SetActive(value: true);
	}

	private void S_OnPowerRocketUnlocked()
	{
		GameObject[] array = powderRocketKit;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(value: true);
		}
	}

	private void Gm_OnPartTimeUnlocked()
	{
		partTimeLocked.SetActive(value: false);
	}

	private void Gm_OnPlayerPressTab(object sender, EventArgs e)
	{
		OffLaptop();
		GameManager.S.OnPlayerUI();
	}

	private void OnDestroy()
	{
		ShoppingBag.OnUnlockFood -= ShoppingBag_OnUnlockFood;
		ShoppingBag.OnUnlockMaterial -= ShoppingBag_OnUnlockMaterial;
		RocketComputer.OnCpuInstalled -= RocketComputer_OnCpuInstalled;
		TearDownController.OnTeardownComplete -= TearDownController_OnTeardownComplete;
		GameManager.S.OnShopItemClicked -= Gm_OnShopItemClicked;
		GameManager.S.OnPartTimeUnlocked -= Gm_OnPartTimeUnlocked;
		QuestManager.S.OnPowerRocketUnlocked -= S_OnPowerRocketUnlocked;
		QuestManager.S.OnRocketChipUnlocked -= S_OnRocketChipUnlocked;
	}

	private void Gm_OnShopItemClicked(object sender, GameManager.OnShopItemClickedArg e)
	{
		currentSelectedItem = e.shopItem;
		currentSelectedWindow = e.shopwindow;
		purchaseText.text = purchaseString.GetLocalizedString();
		codePurchaseText.text = purchaseString.GetLocalizedString();
		if (e.shopItem.TryGetComponent<Food>(out var component))
		{
			shopFoodTitleString.Arguments = new object[2]
			{
				component.itemNameTemp.GetLocalizedString(),
				component.value
			};
			shopDescriptionUIMainImage.sprite = component.mainImage;
			shopDescriptionUI.TitleValue = shopFoodTitleString.GetLocalizedString();
			shopFoodString.Arguments = new object[2]
			{
				satietyString.GetLocalizedString(),
				component.hungerGain
			};
			shopDescriptionUI.DescriptionValue = shopFoodString.GetLocalizedString();
		}
		else
		{
			if (currentSelectedItem.TryGetComponent<Chips>(out var component2))
			{
				chipDescriptionUIMainImage.sprite = component2.mainImage;
				chipDescriptionUI.TitleValue = component2.chipName.GetLocalizedString();
				chipDescriptionUI.DescriptionValue = component2.description.GetLocalizedString();
				if (component2.type == ChipType.Cpu)
				{
					if (rocketComputer.cpuSlot.attachedModule != null)
					{
						codePurchaseText.text = InstalledString.GetLocalizedString();
					}
				}
				else if (rocketComputer.CheckModuleExist(component2.type))
				{
					codePurchaseText.text = InstalledString.GetLocalizedString();
				}
				else
				{
					codePurchaseText.text = InstallString.GetLocalizedString();
				}
				chipDescriptionUI.ShowModalWindow();
				return;
			}
			if (e.shopItem.TryGetComponent<Item>(out var component3))
			{
				shopMatTitleString.Arguments = new object[2]
				{
					component3.itemNameTemp.GetLocalizedString(),
					component3.value
				};
				shopDescriptionUIMainImage.sprite = component3.mainImage;
				shopDescriptionUI.TitleValue = shopMatTitleString.GetLocalizedString();
				if (e.shopItem.TryGetComponent<MotorIngredientItem>(out var _))
				{
					shopDescriptionUI.DescriptionValue = matString.GetLocalizedString();
				}
				else
				{
					shopDescriptionUI.DescriptionValue = "";
				}
			}
			else
			{
				if (currentSelectedWindow.GetComponent<ShopItemRocket>().purchased)
				{
					purchaseText.text = purchasedString.GetLocalizedString();
				}
				RocketAttachment componentInChildren = e.shopItem.GetComponentInChildren<RocketAttachment>();
				shopDescriptionUIMainImage.sprite = componentInChildren.mainImage;
				shopRocketTitleString.Arguments = new object[2]
				{
					componentInChildren.partNameTemp.GetLocalizedString(),
					componentInChildren.partValue
				};
				shopDescriptionUI.TitleValue = shopRocketTitleString.GetLocalizedString();
				componentInChildren.GetLiftDrag();
				if (componentInChildren.partType == 0)
				{
					headSelectedString.Arguments = new object[4]
					{
						massString.GetLocalizedString(),
						componentInChildren.mass,
						frontDragString.GetLocalizedString(),
						(float)Math.Round(componentInChildren.inspectorForce * 100f, 2)
					};
					shopDescriptionUI.DescriptionValue = headSelectedString.GetLocalizedString();
				}
				else if (componentInChildren.partType == 1)
				{
					RocketBody component5 = componentInChildren.GetComponent<RocketBody>();
					string text = null;
					if (component5.type == RocketType.Gunpowder)
					{
						text = solidFuelRocketString.GetLocalizedString();
					}
					else if (component5.type == RocketType.Water)
					{
						text = waterRocketString.GetLocalizedString();
					}
					bodySelectedString.Arguments = new object[8]
					{
						massString.GetLocalizedString(),
						(float)Math.Round(component5.mass, 2),
						dragString.GetLocalizedString(),
						(float)Math.Round(component5.inspectorForce * 100f, 2),
						thrustTimeBonusString.GetLocalizedString(),
						component5.powTimeBonus,
						typeString.GetLocalizedString(),
						text
					};
					shopDescriptionUI.DescriptionValue = bodySelectedString.GetLocalizedString();
				}
				else if (componentInChildren.partType == 2)
				{
					wingSelectedString.Arguments = new object[4]
					{
						massString.GetLocalizedString(),
						componentInChildren.mass,
						liftString.GetLocalizedString(),
						(float)Math.Round(componentInChildren.inspectorForce * 100f, 2)
					};
					shopDescriptionUI.DescriptionValue = wingSelectedString.GetLocalizedString();
				}
				else if (componentInChildren.partType == 3)
				{
					RocketMotor component6 = componentInChildren.GetComponent<RocketMotor>();
					string text2 = null;
					if (component6.type == RocketType.Gunpowder)
					{
						text2 = solidFuelString.GetLocalizedString();
					}
					else if (component6.type == RocketType.Water)
					{
						text2 = waterString.GetLocalizedString();
					}
					motorSelectedString.Arguments = new object[8]
					{
						massString.GetLocalizedString(),
						component6.mass,
						thrustPowerString.GetLocalizedString(),
						component6.trustPow,
						thrustTimeString.GetLocalizedString(),
						component6.launchDuration,
						typeString.GetLocalizedString(),
						text2
					};
					shopDescriptionUI.DescriptionValue = motorSelectedString.GetLocalizedString();
				}
				else if (componentInChildren.partType == 4)
				{
					RocketNozzle component7 = componentInChildren.GetComponent<RocketNozzle>();
					nozzleSelectedString.Arguments = new object[4]
					{
						massString.GetLocalizedString(),
						component7.mass,
						multiplierString.GetLocalizedString(),
						component7.rocketPowMultiplier
					};
					shopDescriptionUI.DescriptionValue = nozzleSelectedString.GetLocalizedString();
				}
			}
		}
		shopDescriptionUI.ShowModalWindow();
		purchaseBtnAnimator.Play("Transition", 0, 0.95f);
	}

	public void CodeTabClicked()
	{
		laptopCam.Priority = 0;
		rocketComputerCam.Priority = 2;
		codeCam.Priority = 0;
		rocketComputer.gameObject.SetActive(value: true);
	}

	public void CodeTabClosed()
	{
		laptopCam.Priority = 2;
		codeCam.Priority = 0;
		rocketComputerCam.Priority = 0;
		blockEngineCanvas.alpha = 0f;
		blockEngineCanvas.interactable = false;
		blockEngineCanvas.blocksRaycasts = false;
		if (myRoutine != null)
		{
			StopCoroutine(myRoutine);
		}
		rocketComputer.gameObject.SetActive(value: false);
	}

	public void JobBtnClicked()
	{
		Animator[] array = jobBtnAnimators;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Play("Transition", 0, 0.95f);
		}
	}

	private void Update()
	{
		if (isChipInstalling)
		{
			ChipInstallControl();
		}
	}

	public void ChipInstallControl()
	{
		if (FirstPersonController.S.playerInput.Player.MouseLeftClick.WasPressedThisFrame())
		{
			TryClickChipSlot();
		}
	}

	public void TryClickChipSlot()
	{
		Vector2 vector = Mouse.current.position.ReadValue();
		Ray ray = Camera.main.ScreenPointToRay(vector);
		int layerMask = 1 << LayerMask.NameToLayer("Device");
		if (Physics.Raycast(ray, out var hitInfo, 3f, layerMask) && hitInfo.collider.TryGetComponent<ModuleSlotGizmo>(out var component))
		{
			component.Clicked(currentSelectedItem);
			isChipInstalling = false;
			codePurchaseText.text = InstalledString.GetLocalizedString();
		}
	}

	public void Interact()
	{
		laptopCam.Priority = 2;
		Cursor.visible = true;
		FirstPersonController.S.canControl = false;
		GameManager.S.OnPlayerPressTab += Gm_OnPlayerPressTab;
		GameManager.S.OffPlayerUI();
		LapTop.OnLapTop?.Invoke();
		if (outLine != null)
		{
			outLine.enabled = false;
		}
		AudioManager.S.PlaySFX(AudioManager.S.computerOn);
	}

	public void OnDetected()
	{
		if (outLine != null)
		{
			outLine.enabled = true;
		}
	}

	public void OnLost()
	{
		if (outLine != null)
		{
			outLine.enabled = false;
		}
	}

	public void Perchase()
	{
		Debug.Log(shopTabIndex);
		if (shopTabIndex == 0)
		{
			if (currentSelectedItem.TryGetComponent<RocketBox>(out var component))
			{
				if (FirstPersonController.S.money >= component.value)
				{
					FirstPersonController.S.MoneyUpdated(0f - component.value);
					purchasedRocket.Add(currentSelectedItem);
					AudioManager.S.PlaySFX(AudioManager.S.computerBuy);
				}
				else
				{
					AudioManager.S.PlaySFX(AudioManager.S.notEnoughMoney);
				}
				return;
			}
			if (currentSelectedWindow.GetComponent<ShopItemRocket>().purchased)
			{
				AudioManager.S.PlaySFX(AudioManager.S.notEnoughMoney);
				return;
			}
			RocketAttachment componentInChildren = currentSelectedItem.GetComponentInChildren<RocketAttachment>();
			if (FirstPersonController.S.money >= (float)componentInChildren.partValue)
			{
				FirstPersonController.S.MoneyUpdated(-componentInChildren.partValue);
				LapTop.OnBuyRocketParts?.Invoke(currentSelectedItem);
				purchaseText.text = purchasedString.GetLocalizedString();
				currentSelectedWindow.GetComponent<ShopItemRocket>().purchased = true;
				AudioManager.S.PlaySFX(AudioManager.S.computerBuy);
			}
			else
			{
				AudioManager.S.PlaySFX(AudioManager.S.notEnoughMoney);
			}
		}
		else if (shopTabIndex == 1)
		{
			Item component2 = currentSelectedItem.GetComponent<Item>();
			if (FirstPersonController.S.money >= component2.value)
			{
				FirstPersonController.S.MoneyUpdated(0f - component2.value);
				purchasedFood.Add(currentSelectedItem);
				AudioManager.S.PlaySFX(AudioManager.S.computerBuy);
			}
			else
			{
				AudioManager.S.PlaySFX(AudioManager.S.notEnoughMoney);
			}
		}
		else if (shopTabIndex == 2)
		{
			Item component3 = currentSelectedItem.GetComponent<Item>();
			if (FirstPersonController.S.money >= component3.value)
			{
				FirstPersonController.S.MoneyUpdated(0f - component3.value);
				purchasedRocket.Add(currentSelectedItem);
				AudioManager.S.PlaySFX(AudioManager.S.computerBuy);
			}
			else
			{
				AudioManager.S.PlaySFX(AudioManager.S.notEnoughMoney);
			}
		}
		else
		{
			if (shopTabIndex != 3)
			{
				return;
			}
			Chips component4 = currentSelectedItem.GetComponent<Chips>();
			if (component4.type == ChipType.Cpu)
			{
				if (rocketComputer.cpuSlot.attachedModule == null)
				{
					isChipInstalling = true;
					codePurchaseText.text = attachModeString.GetLocalizedString();
					rocketComputer.ActiveGizmos(component4.type);
				}
				else
				{
					AudioManager.S.PlaySFX(AudioManager.S.notEnoughMoney);
				}
			}
			else if (rocketComputer.cpuSlot.attachedModule != null)
			{
				if (rocketComputer.CheckModuleExist(component4.type))
				{
					AudioManager.S.PlaySFX(AudioManager.S.notEnoughMoney);
					return;
				}
				rocketComputer.ActiveGizmos(component4.type);
				isChipInstalling = true;
				codePurchaseText.text = attachModeString.GetLocalizedString();
			}
			else
			{
				GameManager.S.CpuNeeded();
			}
		}
	}

	public void OffLaptop()
	{
		laptopCam.Priority = 0;
		codeCam.Priority = 0;
		rocketComputerCam.Priority = 0;
		if (myRoutine != null)
		{
			StopCoroutine(myRoutine);
		}
		blockEngineCanvas.alpha = 0f;
		blockEngineCanvas.interactable = false;
		blockEngineCanvas.blocksRaycasts = false;
		rocketComputer.gameObject.SetActive(value: false);
		Cursor.visible = false;
		FirstPersonController.S.canControl = true;
		currentSelectedItem = null;
		isChipInstalling = false;
		if (purchasedFood != null || purchasedRocket != null)
		{
			GameManager.S.GroceryArrived(purchasedFood, purchasedRocket);
			purchasedFood.Clear();
			purchasedRocket.Clear();
		}
		chipDescriptionUI.gameObject.SetActive(value: false);
		shopDescriptionUI.gameObject.SetActive(value: false);
		videoDescriptionUI.gameObject.SetActive(value: false);
		GameObject[] array = windows;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(value: false);
		}
		GameManager.S.OnPlayerPressTab -= Gm_OnPlayerPressTab;
		LapTop.OffLapTop?.Invoke();
	}

	public void ChangeShopCategoryIndex(int index)
	{
		Debug.Log(index);
		if (shopTabs[index].isOn)
		{
			shopTabIndex = index;
		}
	}

	public void CodingTabInteracted(bool isOn)
	{
		if (isOn)
		{
			laptopCam.Priority = 0;
			rocketComputerCam.Priority = 0;
			codeCam.Priority = 2;
			myRoutine = StartCoroutine(DelayedOpenCodingTab(1f));
		}
	}

	public void CodingTabClosed()
	{
		if (myRoutine != null)
		{
			StopCoroutine(myRoutine);
		}
		laptopCam.Priority = 0;
		rocketComputerCam.Priority = 2;
		codeCam.Priority = 0;
		blockEngineCanvas.alpha = 0f;
		blockEngineCanvas.interactable = false;
		blockEngineCanvas.blocksRaycasts = false;
	}

	private IEnumerator DelayedOpenCodingTab(float duration)
	{
		blockEngineCanvas.interactable = true;
		blockEngineCanvas.blocksRaycasts = true;
		float time = 0f;
		yield return new WaitForSeconds(0.2f);
		while (time < duration)
		{
			time += Time.deltaTime;
			blockEngineCanvas.alpha = Mathf.Lerp(0f, 1f, time / duration);
			yield return null;
		}
		blockEngineCanvas.alpha = 1f;
		myRoutine = null;
	}

	private IEnumerator DelayedCloseCodingTab(float duration)
	{
		float time = 0f;
		while (time < duration)
		{
			time += Time.deltaTime;
			blockEngineCanvas.alpha = Mathf.Lerp(1f, 0f, time / duration);
			yield return null;
		}
		blockEngineCanvas.alpha = 0f;
		blockEngineCanvas.interactable = false;
		blockEngineCanvas.blocksRaycasts = false;
		myRoutine = null;
	}
}
