using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadLevelView : BaseGUIView
{
	public enum PanelType
	{
		Play = 0,
		Load = 1,
		New = 2
	}

	public const string PlayLevelEvent = "LoadLevelView.PlayLevelEvent";

	public const string LoadLevelEvent = "LoadLevelView.LoadLevelEvent";

	public const string OpenLevelEvent = "LoadLevelView.OpenLevelEvent";

	public const string BackButtonEvent = "LoadLevelView.BackButtonEvent";

	public const string WorkshopLevelEvent = "LoadLevelView.WorkshopLevelEvent";

	public const string DeleteButtonEvent = "LoadLevelView.DeleteButtonEvent";

	[SerializeField]
	private GameObject userLevelSlotPrefab;

	[SerializeField]
	private GameObject workshopLevelSlotPrefab;

	[SerializeField]
	private GameObject noLevelSlotPrefab;

	[SerializeField]
	private GameObject findLevelSlotPrefab;

	[SerializeField]
	private GameObject templateInfoSlotPrefab;

	private TextMeshProUGUI headerText;

	private Toggle newTabToggle;

	private Toggle userTabToggle;

	private Toggle workshopTabToggle;

	private GameObject contentPanel;

	private ToggleGroup contentToggleGroup;

	private GameObject newLevelListContent;

	private GameObject userLevelListContent;

	private GameObject workshopLevelListContent;

	private GameObject noLevelSlotObject;

	private GameObject findLevelSlotObject;

	private Button backButton;

	private LoadLevelDetailSlot loadLevelDetailSlot;

	private OrderByPanel orderByPanel;

	private int lastOrderByType;

	private bool lastIsAscending;

	private int lastLoadLevelSlotIndex;

	private List<LoadLevelSlot> userAndWorkshopLoadLevelSlots;

	private List<LoadLevelSlot> newLoadLevelSlots;

	public override void Initialize()
	{
		headerText = mainPanel.transform.FindComponent<TextMeshProUGUI>("HeaderText", isRecursively: true);
		newTabToggle = mainPanel.transform.FindComponent<Toggle>("NewTab", isRecursively: true);
		userTabToggle = mainPanel.transform.FindComponent<Toggle>("UserTab", isRecursively: true);
		workshopTabToggle = mainPanel.transform.FindComponent<Toggle>("WorkshopTab", isRecursively: true);
		contentPanel = mainPanel.transform.FindChildRecursively("ContentPanel").gameObject;
		contentToggleGroup = mainPanel.transform.FindComponent<ToggleGroup>("ContentPanel", isRecursively: true);
		newLevelListContent = contentPanel.transform.FindChildRecursively("NewLevelListContent").gameObject;
		userLevelListContent = contentPanel.transform.FindChildRecursively("UserLevelListContent").gameObject;
		workshopLevelListContent = contentPanel.transform.FindChildRecursively("WorkshopLevelListContent").gameObject;
		backButton = mainPanel.transform.FindComponent<Button>("BackButton", isRecursively: true);
		loadLevelDetailSlot = mainPanel.transform.FindComponent<LoadLevelDetailSlot>("LevelDetailPanel", isRecursively: true);
		orderByPanel = mainPanel.transform.FindComponent<OrderByPanel>("OrderByPanel", isRecursively: true);
		backButton.onClick.AddListener(delegate
		{
			NotifyChange("LoadLevelView.BackButtonEvent");
		});
		loadLevelDetailSlot.OnUploadButtonEvent += delegate(LevelModel levelModel)
		{
			NotifyChange("LoadLevelView.WorkshopLevelEvent", levelModel);
		};
		loadLevelDetailSlot.OnPlayButtonEvent += delegate(LevelModel levelModel)
		{
			NotifyChange("LoadLevelView.PlayLevelEvent", levelModel);
		};
		loadLevelDetailSlot.OnLoadButtonEvent += delegate(LevelModel levelModel)
		{
			NotifyChange("LoadLevelView.LoadLevelEvent", levelModel);
		};
		loadLevelDetailSlot.OnOpenButtonEvent += delegate(LevelModel levelModel)
		{
			NotifyChange("LoadLevelView.OpenLevelEvent", levelModel);
		};
		newTabToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				NewTabSelectedHandler();
			}
		});
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
				WorkshopTabSelectedHandler();
			}
		});
		orderByPanel.OnOrderByChanged += OrderBy;
		userAndWorkshopLoadLevelSlots = new List<LoadLevelSlot>();
		newLoadLevelSlots = new List<LoadLevelSlot>();
		lastLoadLevelSlotIndex = 0;
		lastOrderByType = 0;
		lastIsAscending = true;
		ClearAllSlots();
		NewTabSelectedHandler();
	}

	private void NewTabSelectedHandler()
	{
		AutoSelectLevelSlot(newLevelListContent.transform);
		orderByPanel.gameObject.SetActive(value: false);
		loadLevelDetailSlot.SetBestTimeTextVisibility(isVisible: false);
		loadLevelDetailSlot.SetUploadButtonVisibility(isVisible: false);
		loadLevelDetailSlot.SetSubscriptionButtonVisibility(isVisible: false);
	}

	private void UserTabSelectedHandler()
	{
		AutoSelectLevelSlot(userLevelListContent.transform);
		orderByPanel.gameObject.SetActive(value: true);
		orderByPanel.SetToggleInteractivity(isInteractable: false, 2);
		orderByPanel.SetToggleInteractivity(isInteractable: false, 3);
		if (orderByPanel.GetToggleValue(2) || orderByPanel.GetToggleValue(3))
		{
			orderByPanel.SelectToggle(0);
		}
		loadLevelDetailSlot.SetBestTimeTextVisibility(isVisible: true);
		loadLevelDetailSlot.SetUploadButtonVisibility(isVisible: true);
		loadLevelDetailSlot.SetSubscriptionButtonVisibility(isVisible: false);
	}

	private void WorkshopTabSelectedHandler()
	{
		AutoSelectLevelSlot(workshopLevelListContent.transform);
		orderByPanel.gameObject.SetActive(value: true);
		orderByPanel.SetToggleInteractivity(isInteractable: true, 2);
		orderByPanel.SetToggleInteractivity(isInteractable: true, 3);
		loadLevelDetailSlot.SetBestTimeTextVisibility(isVisible: true);
		loadLevelDetailSlot.SetUploadButtonVisibility(isVisible: false);
		loadLevelDetailSlot.SetSubscriptionButtonVisibility(isVisible: true);
	}

	private void AutoSelectLevelSlot(Transform contentTransform)
	{
		Toggle[] componentsInChildren = contentTransform.GetComponentsInChildren<Toggle>(includeInactive: true);
		bool flag = false;
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (componentsInChildren[i].isOn)
			{
				LoadLevelSlot component = componentsInChildren[i].GetComponent<LoadLevelSlot>();
				if (component != null)
				{
					loadLevelDetailSlot.SetConfiguration(component.SelectedLevelModel);
					flag = true;
					break;
				}
			}
		}
		if (!flag && componentsInChildren.Length != 0)
		{
			componentsInChildren[0].isOn = true;
			LoadLevelSlot component2 = componentsInChildren[0].GetComponent<LoadLevelSlot>();
			if (component2 != null)
			{
				loadLevelDetailSlot.SetConfiguration(component2.SelectedLevelModel);
			}
		}
		else if (!flag)
		{
			loadLevelDetailSlot.SetConfiguration(null);
		}
	}

	public void ClearAllSlots()
	{
		userAndWorkshopLoadLevelSlots.Clear();
		newLevelListContent.transform.RemoveAllChildren();
		userLevelListContent.transform.RemoveAllChildren();
		workshopLevelListContent.transform.RemoveAllChildren();
		noLevelSlotObject = Util.InstantiateForGUI(noLevelSlotPrefab, userLevelListContent.transform, "NoLevelSlot");
		findLevelSlotObject = Util.InstantiateForGUI(findLevelSlotPrefab, workshopLevelListContent.transform, "FindLevelSlot");
		Util.InstantiateForGUI(templateInfoSlotPrefab, newLevelListContent.transform, "TemplateInfoSlot");
	}

	public void RefreshPages()
	{
	}

	public void AddUserLevelSlot(LevelModel levelModel)
	{
		Transform parent = null;
		string text = "";
		GameObject prefab = userLevelSlotPrefab;
		if (levelModel.Place == LevelModel.LevelPlace.User)
		{
			parent = userLevelListContent.transform;
			text = "UserLevel_";
		}
		else if (levelModel.Place == LevelModel.LevelPlace.Workshop)
		{
			parent = workshopLevelListContent.transform;
			text = "WorkshopLevel_";
			prefab = workshopLevelSlotPrefab;
		}
		else if (levelModel.Place == LevelModel.LevelPlace.New)
		{
			parent = newLevelListContent.transform;
			text = "NewLevel_";
		}
		GameObject gameObject = Util.InstantiateForGUI(prefab, parent, text + levelModel.Id);
		LoadLevelSlot loadLevelSlot = gameObject.GetComponent<LoadLevelSlot>();
		loadLevelSlot.SetConfiguration(levelModel, contentToggleGroup);
		loadLevelSlot.OnSlotSelectedEvent += delegate(LevelModel selectedLevelModel)
		{
			loadLevelDetailSlot.SetConfiguration(selectedLevelModel);
			if (levelModel.Place != LevelModel.LevelPlace.New)
			{
				lastLoadLevelSlotIndex = userAndWorkshopLoadLevelSlots.IndexOf(loadLevelSlot);
			}
		};
		loadLevelSlot.OnDeleteLevelEvent += delegate(LevelModel selectedLevelModel)
		{
			NotifyChange("LoadLevelView.DeleteButtonEvent", selectedLevelModel);
		};
		if (levelModel.Place != LevelModel.LevelPlace.New)
		{
			userAndWorkshopLoadLevelSlots.Add(loadLevelSlot);
		}
		else if (levelModel.Place == LevelModel.LevelPlace.New)
		{
			newLoadLevelSlots.Add(loadLevelSlot);
		}
		if (levelModel.Place == LevelModel.LevelPlace.User && noLevelSlotObject != null)
		{
			Object.Destroy(noLevelSlotObject);
		}
	}

	public void RemoveUserLoadLevelSlot(string levelModelId)
	{
		LoadLevelSlot[] array = userAndWorkshopLoadLevelSlots.ToArray();
		foreach (LoadLevelSlot loadLevelSlot in array)
		{
			if (loadLevelSlot.SelectedLevelModel.Id == levelModelId)
			{
				int num = userAndWorkshopLoadLevelSlots.IndexOf(loadLevelSlot);
				userAndWorkshopLoadLevelSlots.Remove(loadLevelSlot);
				Object.Destroy(loadLevelSlot.gameObject);
				if (loadLevelSlot.IsSelected)
				{
					SelectUserLoadLevelSlot(num - 1);
				}
				break;
			}
		}
		if (!userAndWorkshopLoadLevelSlots.Any((LoadLevelSlot levelSlot) => levelSlot.SelectedLevelModel.Place == LevelModel.LevelPlace.User))
		{
			noLevelSlotObject = Util.InstantiateForGUI(noLevelSlotPrefab, userLevelListContent.transform, "NoLevelSlot");
		}
	}

	public void SelectUserLoadLevelSlot(int index)
	{
		if (userAndWorkshopLoadLevelSlots.Count == 0)
		{
			userTabToggle.isOn = true;
			loadLevelDetailSlot.SetConfiguration(null);
			return;
		}
		index = Mathf.Clamp(index, 0, userAndWorkshopLoadLevelSlots.Count - 1);
		if (userAndWorkshopLoadLevelSlots[index].transform.parent == userLevelListContent.transform)
		{
			userTabToggle.isOn = true;
		}
		else if (userAndWorkshopLoadLevelSlots[index].transform.parent == workshopLevelListContent.transform)
		{
			workshopTabToggle.isOn = true;
		}
		userAndWorkshopLoadLevelSlots[index].SetToggleValue(isSelected: true);
		loadLevelDetailSlot.SetConfiguration(userAndWorkshopLoadLevelSlots[index].SelectedLevelModel);
		lastLoadLevelSlotIndex = index;
	}

	public void SelectLastUserLoadLevelSlot()
	{
		SelectUserLoadLevelSlot(lastLoadLevelSlotIndex);
	}

	public void RefreshOrderBy()
	{
		OrderBy(lastOrderByType, lastIsAscending);
	}

	private void OrderBy(int orderByType, bool isAscending)
	{
		LoadLevelSlot[] array;
		switch (orderByType)
		{
		case 0:
			array = ((!isAscending) ? userAndWorkshopLoadLevelSlots.OrderByDescending((LoadLevelSlot loadLevelSlot2) => loadLevelSlot2.SelectedLevelModel.Name).ToArray() : userAndWorkshopLoadLevelSlots.OrderBy((LoadLevelSlot loadLevelSlot2) => loadLevelSlot2.SelectedLevelModel.Name).ToArray());
			break;
		case 1:
			array = (isAscending ? userAndWorkshopLoadLevelSlots.OrderByDescending((LoadLevelSlot loadLevelSlot2) => loadLevelSlot2.SelectedLevelModel.FileLastModifiedDate).ToArray() : userAndWorkshopLoadLevelSlots.OrderBy((LoadLevelSlot loadLevelSlot2) => loadLevelSlot2.SelectedLevelModel.FileLastModifiedDate).ToArray());
			break;
		case 2:
			array = ((!isAscending) ? userAndWorkshopLoadLevelSlots.OrderByDescending(GetAuthorName).ToArray() : userAndWorkshopLoadLevelSlots.OrderBy(GetAuthorName).ToArray());
			break;
		default:
			array = ((!isAscending) ? userAndWorkshopLoadLevelSlots.OrderByDescending(GetScore).ToArray() : userAndWorkshopLoadLevelSlots.OrderBy(GetScore).ToArray());
			break;
		}
		int num = 0;
		int num2 = 1;
		LoadLevelSlot[] array2 = array;
		foreach (LoadLevelSlot loadLevelSlot in array2)
		{
			if (loadLevelSlot.SelectedLevelModel.Place == LevelModel.LevelPlace.User)
			{
				loadLevelSlot.transform.SetSiblingIndex(num++);
			}
			else if (loadLevelSlot.SelectedLevelModel.Place == LevelModel.LevelPlace.Workshop)
			{
				loadLevelSlot.transform.SetSiblingIndex(num2++);
			}
		}
		lastOrderByType = orderByType;
		lastIsAscending = isAscending;
		string GetAuthorName(LoadLevelSlot loadLevelSlot2)
		{
			if (loadLevelSlot2 is LoadWorkshopLevelSlot)
			{
				return (loadLevelSlot2 as LoadWorkshopLevelSlot).AuthorName;
			}
			return loadLevelSlot2.SelectedLevelModel.Name;
		}
		float GetScore(LoadLevelSlot loadLevelSlot2)
		{
			if (loadLevelSlot2 is LoadWorkshopLevelSlot)
			{
				return (loadLevelSlot2 as LoadWorkshopLevelSlot).Score;
			}
			return 0f;
		}
	}

	public bool IsNewTabSelected()
	{
		return newTabToggle.isOn;
	}

	public void SetPanelType(PanelType panelType)
	{
		if ((uint)panelType > 1u)
		{
			if (panelType == PanelType.New)
			{
				string text = "label.text.leveleditor.load.new";
				string text2 = LanguagesManager.Instance.GetText(text, text);
				headerText.SetText(text2);
				newTabToggle.gameObject.SetActive(value: true);
				newTabToggle.isOn = true;
				if (newLoadLevelSlots.Count > 0)
				{
					newLoadLevelSlots[0].SetToggleValue(isSelected: true);
					loadLevelDetailSlot.SetConfiguration(newLoadLevelSlots[0].SelectedLevelModel);
				}
			}
		}
		else
		{
			string text = ((panelType != PanelType.Play) ? "label.text.leveleditor.load.open" : "label.text.leveleditor.load.play");
			string text2 = LanguagesManager.Instance.GetText(text, text);
			headerText.SetText(text2);
			SelectLastUserLoadLevelSlot();
			newTabToggle.gameObject.SetActive(value: false);
		}
		loadLevelDetailSlot.SetPanelType(panelType);
	}
}
