using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GardenSignGUIController : MonoBehaviour
{
	public GameObject growablesHolderBoxPrefab;

	public Image activeGrowableImage;

	public TextMeshProUGUI activeGrowableName;

	public TextMeshProUGUI activeGrowableTime;

	public TextMeshProUGUI activeGrowablePrice;

	public TextMeshProUGUI activeGrowableDescription;

	public GameObject growablesListHolder;

	public RectTransform sliderAreaTransform;

	public RectTransform growablesListTransform;

	public GameObject mulchesTab;

	private GardenPlot gardenPlotRef;

	private GrowableBox currentlySelectedBox;

	private Mulch currentMulch;

	private GrowableObject currentGrowable;

	private InventoryItem currentItemType;

	private int elementsPerRow = 3;

	private float finalOffset = 10f;

	private float initialOffset = -5f;

	private float verticalOffset = 50f;

	private float horizontalOffset = 50f;

	private List<GameObject> allGrowables = new List<GameObject>();

	private GUIManagerPens guiManagerRef;

	private InventoryManager inventoryRef;

	public void SetPlotRef(GardenPlot newRef)
	{
		gardenPlotRef = newRef;
		Initialize();
	}

	private void Initialize()
	{
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		guiManagerRef = registrationScript.GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI);
		inventoryRef = registrationScript.GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER);
		InitializeGUI();
	}

	private void InitializeGUI()
	{
		guiManagerRef.DisableBG(LockReason.GARDEN_SIGN);
		currentMulch = null;
		GrowableObject growableObject = gardenPlotRef.GetCurrentGrowable();
		if (growableObject != null)
		{
			UpdateGrowable(growableObject);
		}
		mulchesTab.SetActive(value: false);
		CreateBoxes();
	}

	public void CloseGUI()
	{
		guiManagerRef.EnableBG(LockReason.GARDEN_SIGN);
		Object.Destroy(base.gameObject);
	}

	public void UpdateGrowable(GrowableObject newItem)
	{
		currentGrowable = newItem;
		UpdateObjectTypeDisplay();
	}

	public void UpdateMulchType(Mulch newMulch)
	{
		currentMulch = newMulch;
		UpdateObjectTypeDisplay();
	}

	public void PlantGrowableAndCloseGUI()
	{
		gardenPlotRef.PlantNewGrowable(currentGrowable, currentMulch);
		UpdateObjectTypeDisplay();
		CloseGUI();
	}

	public void SelectBox(GrowableBox newBox)
	{
		if (currentlySelectedBox != null)
		{
			currentlySelectedBox.OnDeselected();
		}
		newBox.OnSelected();
		currentlySelectedBox = newBox;
		UpdateGrowable(currentlySelectedBox.GetContainedItem());
	}

	private void RefreshBoxes()
	{
		for (int num = allGrowables.Count - 1; num >= 0; num--)
		{
			Object.Destroy(allGrowables[num]);
		}
		allGrowables.Clear();
		CreateBoxes();
	}

	private void UpdateObjectTypeDisplay()
	{
		if (currentGrowable == null)
		{
			currentItemType = null;
			activeGrowableName.text = "";
			activeGrowableTime.text = "";
			activeGrowablePrice.text = "";
			activeGrowableImage.sprite = null;
			activeGrowableDescription.text = "";
		}
		else
		{
			currentItemType = currentGrowable.finalObject;
			activeGrowableName.text = currentItemType.itemNameLocalized;
			activeGrowableImage.sprite = currentGrowable.finalObject.icon;
			activeGrowableDescription.text = currentGrowable.finalObject.itemDescriptionLocalized;
			activeGrowableTime.text = GetGrowTimeSignifier(Mathf.RoundToInt(currentGrowable.growTime));
		}
	}

	private string GetGrowTimeSignifier(int time)
	{
		if (time < 10)
		{
			return "Quick";
		}
		if (time < 30)
		{
			return "Average";
		}
		if (time < 60)
		{
			return "Slow";
		}
		return "Very Slow";
	}

	private void CreateBoxes()
	{
		List<GrowableObject> list = inventoryRef.GetAllGrowables();
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i].startUnlocked)
			{
				GameObject gameObject = Object.Instantiate(growablesHolderBoxPrefab, growablesListTransform);
				GrowableBox component = gameObject.GetComponent<GrowableBox>();
				component.SetControllerRef(this);
				component.SetContainedItem(list[i], 1);
				PositionNewBox(gameObject);
			}
		}
		if (allGrowables.Count == 0)
		{
			sliderAreaTransform.sizeDelta = new Vector2(0f, verticalOffset + finalOffset);
			growablesListTransform.anchoredPosition3D = new Vector3(growablesListTransform.anchoredPosition3D.x, initialOffset + finalOffset / 2f, 0f);
		}
		else
		{
			SelectBox(allGrowables[0].GetComponent<GrowableBox>());
		}
	}

	private void PositionNewBox(GameObject obj)
	{
		int num = allGrowables.Count % elementsPerRow;
		int num2 = Mathf.FloorToInt(allGrowables.Count / elementsPerRow);
		obj.transform.localPosition = Vector3.right * horizontalOffset * num + Vector3.down * verticalOffset * num2;
		float num3 = (float)(num2 + 1) * verticalOffset;
		float num4 = (float)num2 * verticalOffset;
		sliderAreaTransform.sizeDelta = new Vector2(0f, num3 + finalOffset);
		growablesListTransform.anchoredPosition3D = new Vector3(growablesListTransform.anchoredPosition3D.x, initialOffset + (num4 + finalOffset) / 2f, 0f);
		allGrowables.Add(obj);
	}
}
