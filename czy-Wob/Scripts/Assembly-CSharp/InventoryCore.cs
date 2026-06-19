using UnityEngine;

public class InventoryCore : UICoreBase
{
	public GameObject itemPane;

	public GameObject itemInfo;

	public GameObject exitButton;

	public GameObject useButton;

	public GameObject tossButton;

	public GameObject extraBars;

	public GameObject inventoryTitle;

	private int elementsNeeded = 7;

	private int loadedElements;

	private bool unloading;

	private bool interactButtonsActive;

	private bool interactButtonsNeedUnload;

	private ItemBoxes boxesRef;

	private void Start()
	{
		boxesRef = itemPane.GetComponent<ItemPane>().itemBoxes.GetComponent<ItemBoxes>();
	}

	private void Update()
	{
		if (interactButtonsNeedUnload && loadedElements == elementsNeeded)
		{
			HideInteractButtons();
		}
	}

	public override void Load(ScalableUIContainer.LoadCallback loadCallback)
	{
		base.Load(loadCallback);
		interactButtonsActive = true;
		itemPane.GetComponent<ItemPane>().Load(OnElementLoadedCallback);
		itemInfo.GetComponent<ItemInfo>().Load(OnElementLoadedCallback);
		exitButton.GetComponent<InventoryExitButton>().Load(OnElementLoadedCallback);
		useButton.GetComponent<UseButton>().Load(OnElementLoadedCallback);
		tossButton.GetComponent<TossButton>().Load(OnElementLoadedCallback);
		extraBars.GetComponent<ExtraBars>().Load(OnElementLoadedCallback);
		inventoryTitle.GetComponent<StandardGUIElementLoader>().Load(OnElementLoadedCallback);
	}

	public override void Unload(ScalableUIContainer.LoadCallback unloadCallback)
	{
		unloading = true;
		base.Unload(unloadCallback);
		itemPane.GetComponent<ItemPane>().Unload(OnElementUnloadedCallback);
		itemInfo.GetComponent<ItemInfo>().Unload(OnElementUnloadedCallback);
		exitButton.GetComponent<InventoryExitButton>().Unload(OnElementUnloadedCallback);
		extraBars.GetComponent<ExtraBars>().Unload(OnElementUnloadedCallback);
		inventoryTitle.GetComponent<StandardGUIElementLoader>().Unload(OnElementUnloadedCallback);
		if (interactButtonsActive)
		{
			useButton.GetComponent<UseButton>().Unload(OnElementUnloadedCallback);
			tossButton.GetComponent<TossButton>().Unload(OnElementUnloadedCallback);
		}
		else
		{
			loadedElements -= 2;
		}
	}

	private void OnElementLoadedCallback()
	{
		loadedElements++;
		if (loadedElements >= elementsNeeded)
		{
			interactButtonsActive = true;
			AllElementsLoadedCallback();
		}
	}

	private void OnElementUnloadedCallback()
	{
		loadedElements--;
		if (loadedElements <= 0)
		{
			AllElementsUnloadedCallback();
		}
	}

	public void HideInteractButtons()
	{
		if (unloading)
		{
			return;
		}
		if (!interactButtonsActive)
		{
			if (loadedElements < elementsNeeded)
			{
				interactButtonsNeedUnload = true;
			}
		}
		else
		{
			interactButtonsNeedUnload = false;
			interactButtonsActive = false;
			useButton.GetComponent<UseButton>().Unload(OnInteractButtonsUpdated);
			tossButton.GetComponent<TossButton>().Unload(OnInteractButtonsUpdated);
		}
	}

	public void ShowInteractButtons()
	{
		if (!unloading && !interactButtonsActive)
		{
			interactButtonsActive = true;
			useButton.GetComponent<UseButton>().Load(OnInteractButtonsUpdated);
			tossButton.GetComponent<TossButton>().Load(OnInteractButtonsUpdated);
		}
	}

	private void OnInteractButtonsUpdated()
	{
	}

	public void TossSelectedItem()
	{
		boxesRef.TossSelectedItem();
	}
}
