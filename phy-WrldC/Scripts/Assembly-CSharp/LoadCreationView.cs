using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadCreationView : BaseGUIView
{
	public const string LoadButtonEvent = "LoadCreationView.LoadButtonEvent";

	public const string DeleteButtonEvent = "LoadCreationView.DeleteButtonEvent";

	public const string WorkshopButtonEvent = "LoadCreationView.WorkshopButtonEvent";

	public const string CloseButtonEvent = "LoadCreationView.CloseButtonEvent";

	[SerializeField]
	private GameObject loadCreationSlotPrefab;

	[SerializeField]
	private GameObject loadWorkshopCreationSlotPrefab;

	[SerializeField]
	private GameObject loadCreationPagePanelPrefab;

	[SerializeField]
	private int slotsPerPage = 8;

	private Toggle userTabToggle;

	private Toggle workshopTabToggle;

	private GameObject userCreationsPanel;

	private GameObject workshopCreationsPanel;

	private GameObject userPagesObject;

	private GameObject workshopPagesObject;

	private GameObject findCreationSlotObject;

	private TextMeshProUGUI noCreationText;

	private Button closeButton;

	private Quaternion blockReferenceRotation;

	private GameObject mouseOverCreationFolder;

	private bool isRotating;

	private OrderByPanel orderByPanel;

	private int lastOrderByType;

	private bool lastIsAscending;

	private List<LoadCreationSlot> creationSlots;

	private PagesSystemHandler userPagesSystemHandler;

	private PagesSystemHandler workshopPagesSystemHandler;

	public override void Initialize()
	{
		userTabToggle = mainPanel.transform.FindComponent<Toggle>("UserTab", isRecursively: true);
		workshopTabToggle = mainPanel.transform.FindComponent<Toggle>("WorkshopTab", isRecursively: true);
		userCreationsPanel = mainPanel.transform.FindChildRecursively("UserCreationsPanel").gameObject;
		workshopCreationsPanel = mainPanel.transform.FindChildRecursively("WorkshopCreationsPanel").gameObject;
		userPagesObject = mainPanel.transform.FindChildRecursively("UserPagesPanel").gameObject;
		workshopPagesObject = mainPanel.transform.FindChildRecursively("WorkshopPagesPanel").gameObject;
		findCreationSlotObject = mainPanel.transform.FindChildRecursively("FindCreationSlot").gameObject;
		noCreationText = mainPanel.transform.FindComponent<TextMeshProUGUI>("NoCreationText", isRecursively: true);
		closeButton = mainPanel.transform.FindComponent<Button>("CloseButton", isRecursively: true);
		blockReferenceRotation = mainPanel.transform.FindChildRecursively("BlockReference").transform.localRotation;
		orderByPanel = mainPanel.transform.FindComponent<OrderByPanel>("OrderByPanel", isRecursively: true);
		userPagesSystemHandler = new PagesSystemHandler(userPagesObject, userCreationsPanel, slotsPerPage);
		workshopPagesSystemHandler = new PagesSystemHandler(workshopPagesObject, workshopCreationsPanel, slotsPerPage);
		userTabToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				UserTabSelectedHandler();
			}
		});
		workshopTabToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				WorshkopTabSelectedHandler();
			}
		});
		closeButton.onClick.AddListener(delegate
		{
			NotifyChange("LoadCreationView.CloseButtonEvent");
		});
		orderByPanel.OnOrderByChanged += OrderBy;
		creationSlots = new List<LoadCreationSlot>();
		findCreationSlotObject.SetActive(value: false);
		noCreationText.gameObject.SetActive(value: true);
		lastOrderByType = 0;
		lastIsAscending = true;
		ClearAllSlots();
	}

	public override void SetVisibility(bool isVisible)
	{
		base.SetVisibility(isVisible);
		creationSlots.ForEach(delegate(LoadCreationSlot creationSlot)
		{
			if (creationSlot.CreationView.gameObject.activeSelf != isVisible)
			{
				creationSlot.CreationView.gameObject.SetActive(isVisible);
			}
		});
	}

	public void ClearAllSlots()
	{
		creationSlots.Clear();
		userCreationsPanel.transform.RemoveAllChildren();
		workshopCreationsPanel.transform.RemoveAllChildren();
		userPagesSystemHandler.AddFirstParentPagePanel(loadCreationPagePanelPrefab);
		workshopPagesSystemHandler.AddFirstParentPagePanel(loadCreationPagePanelPrefab);
	}

	public void RefreshPages()
	{
		userPagesSystemHandler.UpdatePagesSystem();
		workshopPagesSystemHandler.UpdatePagesSystem();
	}

	private void UserTabSelectedHandler()
	{
		orderByPanel.SetToggleInteractivity(isInteractable: false, 5);
		orderByPanel.SetToggleInteractivity(isInteractable: false, 6);
		if (orderByPanel.GetToggleValue(5) || orderByPanel.GetToggleValue(6))
		{
			orderByPanel.SelectToggle(0);
		}
		findCreationSlotObject.SetActive(value: false);
		if (creationSlots.Any((LoadCreationSlot slot) => slot.CreationModel.Place == CreationModel.CreationPlace.User))
		{
			noCreationText.gameObject.SetActive(value: false);
		}
		else
		{
			noCreationText.gameObject.SetActive(value: true);
		}
	}

	private void WorshkopTabSelectedHandler()
	{
		orderByPanel.gameObject.SetActive(value: true);
		orderByPanel.SetToggleInteractivity(isInteractable: true, 5);
		orderByPanel.SetToggleInteractivity(isInteractable: true, 6);
		findCreationSlotObject.SetActive(value: true);
		if (creationSlots.Any((LoadCreationSlot slot) => slot.CreationModel.Place == CreationModel.CreationPlace.Workshop))
		{
			noCreationText.gameObject.SetActive(value: false);
		}
		else
		{
			noCreationText.gameObject.SetActive(value: true);
		}
	}

	public void AddCreation(CreationModel creationModel, int index)
	{
		Transform parent = null;
		GameObject prefab = null;
		if (creationModel.Place == CreationModel.CreationPlace.User)
		{
			parent = userPagesSystemHandler.GetParentPagePanel(loadCreationPagePanelPrefab, index).transform;
			prefab = loadCreationSlotPrefab;
		}
		else if (creationModel.Place == CreationModel.CreationPlace.Workshop)
		{
			parent = workshopPagesSystemHandler.GetParentPagePanel(loadCreationPagePanelPrefab, index).transform;
			prefab = loadWorkshopCreationSlotPrefab;
		}
		LoadCreationSlot component = Util.InstantiateForGUI(prefab, parent, index, "CreationForLoad_" + index).GetComponent<LoadCreationSlot>();
		component.SetCreationModel(creationModel);
		component.OnLoadButtonEvent += delegate
		{
			LoadButtonHandler(creationModel);
		};
		component.OnDeleteButtonEvent += delegate
		{
			DeleteButtonHandler(creationModel);
		};
		component.OnWorkshopButtonEvent += delegate
		{
			WorkshopButtonHandler(creationModel);
		};
		component.OnMouseOverEvent += delegate(GameObject creationFolder, bool shouldRotate)
		{
			CreationRotationHandler(creationFolder, shouldRotate);
		};
		if (component.CreationView.gameObject.activeSelf != base.IsVisible)
		{
			component.CreationView.gameObject.SetActive(base.IsVisible);
		}
		noCreationText.gameObject.SetActive(value: false);
		creationSlots.Add(component);
	}

	public void RemoveCreationSlot(int index)
	{
		LoadCreationSlot loadCreationSlot = creationSlots[index];
		creationSlots.RemoveAt(index);
		loadCreationSlot.transform.SetParent(null);
		loadCreationSlot.CreationView?.RecycleAllBlocksBeforeDestroying();
		Object.Destroy(loadCreationSlot.gameObject);
		userPagesSystemHandler.ReorganizePages();
		if (creationSlots.Count == 0)
		{
			noCreationText.gameObject.SetActive(value: true);
		}
	}

	private void LoadButtonHandler(CreationModel creationModel)
	{
		NotifyChange("LoadCreationView.LoadButtonEvent", creationModel);
	}

	private void DeleteButtonHandler(CreationModel creationModel)
	{
		GUIManager.Instance.ShowMessageBox(LanguagesManager.Instance.GetText("message.header.load.delete", "Delete Creation"), LanguagesManager.Instance.GetText("message.info.load.delete", "Are you sure you want to remove this creation?"), delegate
		{
			NotifyChange("LoadCreationView.DeleteButtonEvent", creationModel);
		});
	}

	private void WorkshopButtonHandler(CreationModel creationModel)
	{
		NotifyChange("LoadCreationView.WorkshopButtonEvent", creationModel);
	}

	private void CreationRotationHandler(GameObject creationFolder, bool shouldRotate)
	{
		if (!shouldRotate)
		{
			creationFolder.transform.DOLocalRotate(blockReferenceRotation.eulerAngles, 0.5f, RotateMode.FastBeyond360);
			creationFolder.transform.DOScale(1f, 0.5f);
		}
		else
		{
			creationFolder.transform.DOScale(1.3f, 0.5f);
		}
		isRotating = shouldRotate;
		mouseOverCreationFolder = creationFolder;
	}

	public void RefreshOrderBy()
	{
		OrderBy(lastOrderByType, lastIsAscending);
	}

	private void OrderBy(int orderByType, bool isAscending)
	{
		LoadCreationSlot[] array;
		switch (orderByType)
		{
		case 0:
			array = ((!isAscending) ? creationSlots.OrderByDescending((LoadCreationSlot loadCreationSlot2) => loadCreationSlot2.CreationModel.Name).ToArray() : creationSlots.OrderBy((LoadCreationSlot loadCreationSlot2) => loadCreationSlot2.CreationModel.Name).ToArray());
			break;
		case 1:
			array = (isAscending ? creationSlots.OrderByDescending((LoadCreationSlot loadCreationSlot2) => loadCreationSlot2.CreationModel.FileLastModifiedDate).ToArray() : creationSlots.OrderBy((LoadCreationSlot loadCreationSlot2) => loadCreationSlot2.CreationModel.FileLastModifiedDate).ToArray());
			break;
		case 2:
			array = ((!isAscending) ? creationSlots.OrderByDescending((LoadCreationSlot loadCreationSlot2) => loadCreationSlot2.CreationModel.BlockModelCount).ToArray() : creationSlots.OrderBy((LoadCreationSlot loadCreationSlot2) => loadCreationSlot2.CreationModel.BlockModelCount).ToArray());
			break;
		case 3:
			array = ((!isAscending) ? creationSlots.OrderByDescending((LoadCreationSlot loadCreationSlot2) => loadCreationSlot2.CreationModel.TotalCost()).ToArray() : creationSlots.OrderBy((LoadCreationSlot loadCreationSlot2) => loadCreationSlot2.CreationModel.TotalCost()).ToArray());
			break;
		case 4:
			array = ((!isAscending) ? creationSlots.OrderByDescending((LoadCreationSlot loadCreationSlot2) => loadCreationSlot2.CreationModel.TotalWeight()).ToArray() : creationSlots.OrderBy((LoadCreationSlot loadCreationSlot2) => loadCreationSlot2.CreationModel.TotalWeight()).ToArray());
			break;
		case 5:
			array = ((!isAscending) ? creationSlots.OrderByDescending(GetAuthorName).ToArray() : creationSlots.OrderBy(GetAuthorName).ToArray());
			break;
		default:
			array = ((!isAscending) ? creationSlots.OrderByDescending(GetScore).ToArray() : creationSlots.OrderBy(GetScore).ToArray());
			break;
		}
		int num = 0;
		int num2 = 0;
		LoadCreationSlot[] array2 = array;
		foreach (LoadCreationSlot loadCreationSlot in array2)
		{
			if (loadCreationSlot.CreationModel.Place == CreationModel.CreationPlace.User)
			{
				int siblingIndex = num % slotsPerPage;
				loadCreationSlot.transform.SetParent(userPagesSystemHandler.GetParentPagePanel(loadCreationPagePanelPrefab, num).transform);
				loadCreationSlot.transform.SetSiblingIndex(siblingIndex);
				num++;
			}
			else if (loadCreationSlot.CreationModel.Place == CreationModel.CreationPlace.Workshop)
			{
				int siblingIndex2 = num2 % slotsPerPage;
				loadCreationSlot.transform.SetParent(workshopPagesSystemHandler.GetParentPagePanel(loadCreationPagePanelPrefab, num2).transform);
				loadCreationSlot.transform.SetSiblingIndex(siblingIndex2);
				num2++;
			}
		}
		lastOrderByType = orderByType;
		lastIsAscending = isAscending;
		string GetAuthorName(LoadCreationSlot loadCreationSlot2)
		{
			if (loadCreationSlot2 is LoadWorkshopCreationSlot)
			{
				return (loadCreationSlot2 as LoadWorkshopCreationSlot).AuthorName;
			}
			return loadCreationSlot2.CreationModel.Name;
		}
		float GetScore(LoadCreationSlot loadCreationSlot2)
		{
			if (loadCreationSlot2 is LoadWorkshopCreationSlot)
			{
				return (loadCreationSlot2 as LoadWorkshopCreationSlot).Score;
			}
			return 0f;
		}
	}

	private void Update()
	{
		if (isRotating && mouseOverCreationFolder != null)
		{
			if (mainPanel.activeSelf)
			{
				mouseOverCreationFolder.transform.Rotate(Vector3.up, Time.deltaTime * 100f, Space.World);
				return;
			}
			mouseOverCreationFolder.transform.localRotation = blockReferenceRotation;
			mouseOverCreationFolder.transform.localScale = Vector3.one;
			isRotating = false;
		}
	}
}
