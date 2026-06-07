using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class FileListPanel : MenuListPanel
{
	public GameObject fileListItemPrefab;

	public TextMeshProUGUI fileNameLabel;

	public LabelButton actionButton;

	public TMP_InputField inputField;

	public LabelButton fileNameHeaderButton;

	public LabelButton cancelButton;

	public LabelButton dateModifiedHeaderButton;

	private readonly List<FileMetadata> unsortedMetadataList = new List<FileMetadata>();

	private readonly List<FileMetadata> sortedMetadataList = new List<FileMetadata>();

	private readonly Dictionary<FileMetadata, GameDataContainer> gameDataContainers = new Dictionary<FileMetadata, GameDataContainer>();

	private int currentSortDirection;

	private FileSortType currentSortMethod;

	private FilePanelMode currentPanelMode;

	public UnityAction cancelDelegate;

	public override void Initialize()
	{
		base.Initialize();
		currentSortDirection = -1;
		currentSortMethod = FileSortType.DateModified;
		fileNameHeaderButton.InitializeButton();
		fileNameHeaderButton.buttonState = CustomButtonState.Background;
		fileNameHeaderButton.AddPointerClickTrigger(OnLabelSortClicked);
		dateModifiedHeaderButton.InitializeButton();
		dateModifiedHeaderButton.AddPointerClickTrigger(OnDateSortClicked);
		dateModifiedHeaderButton.buttonState = CustomButtonState.Background;
		actionButton.InitializeButton();
		actionButton.buttonState = CustomButtonState.Default;
		actionButton.AddPointerClickTrigger(OnActionButtonClicked);
		cancelButton.InitializeButton();
		cancelButton.buttonState = CustomButtonState.Default;
		cancelButton.AddPointerClickTrigger(OnCancelClicked);
	}

	public void ShowForMode(FilePanelMode mode, UnityAction onCancel)
	{
		currentPanelMode = mode;
		cancelDelegate = onCancel;
		ReloadLabels();
		Show();
	}

	public override void ReloadLabels()
	{
		base.ReloadLabels();
		fileNameHeaderButton.label.text = "FileName".Localized();
		dateModifiedHeaderButton.label.text = "LastModified".Localized();
		fileNameLabel.text = "FileName".Localized();
		actionButton.label.text = ((currentPanelMode == FilePanelMode.Load) ? "MenuFunctionLoad".Localized() : "MenuFunctionSave".Localized());
		cancelButton.label.text = "Cancel".Localized();
		header.headerText.text = actionButton.label.text;
	}

	public void CreateLayout()
	{
		CreateLayoutForActiveTown();
		unsortedMetadataList.Clear();
		sortedMetadataList.Clear();
		gameDataContainers.Clear();
		switch (Platform.Instance.GetFileSource())
		{
		case FileSource.PlatformStorage:
		{
			List<FileMetadata> collection2 = Platform.Instance.CloudFiles(FileType.SaveFile);
			unsortedMetadataList.AddRange(collection2);
			break;
		}
		case FileSource.ApplicationPersistentData:
		{
			List<FileMetadata> collection = Platform.PersistentLocalFiles(FileType.SaveFile);
			unsortedMetadataList.AddRange(collection);
			break;
		}
		}
		if (currentSortDirection == 1)
		{
			if (currentSortMethod == FileSortType.FileName)
			{
				sortedMetadataList.AddRange(unsortedMetadataList.OrderBy((FileMetadata x) => x.displayName));
			}
			else
			{
				sortedMetadataList.AddRange(unsortedMetadataList.OrderBy((FileMetadata x) => x.dateLastWritten));
			}
		}
		else if (currentSortMethod == FileSortType.FileName)
		{
			sortedMetadataList.AddRange(unsortedMetadataList.OrderByDescending((FileMetadata x) => x.displayName));
		}
		else
		{
			sortedMetadataList.AddRange(unsortedMetadataList.OrderByDescending((FileMetadata x) => x.dateLastWritten));
		}
		foreach (FileMetadata sortedMetadata in sortedMetadataList)
		{
			primaryLayoutManager.AddItemWithHeight(sortedMetadata, 42f);
		}
		UpdateSortDisplay();
		isItemAvailabilityStale = true;
	}

	protected override void UpdateDynamicDisplay()
	{
		base.UpdateDynamicDisplay();
		actionButton.buttonState = (string.IsNullOrEmpty(inputField.text) ? CustomButtonState.Disabled : CustomButtonState.BlueFlashing);
	}

	protected override MonoBehaviour CreateListItemForPool()
	{
		FileListItem component = MenuManager.GetMenuObject(fileListItemPrefab, layoutGroup.transform).GetComponent<FileListItem>();
		component.LoadSelectionManager(selectionManager);
		component.AddPointerClickTrigger(component.OnSelected);
		component.AddRightClickTrigger(component.OnRightClicked);
		component.buttonState = CustomButtonState.Background;
		return component;
	}

	protected override void AssignKeyToItem(object key, MonoBehaviour item)
	{
		if (!(key is FileMetadata fileMetadata) || !(item is FileListItem fileListItem))
		{
			return;
		}
		if (!gameDataContainers.TryGetValue(fileMetadata, out var value))
		{
			string fileContents;
			LoadResultStatus loadResultStatus = Platform.Instance.TryGetFileContents(fileMetadata, out fileContents);
			Debug.Log("Load source " + fileMetadata.fileSource.ToString() + " result " + loadResultStatus);
			if (loadResultStatus == LoadResultStatus.OK)
			{
				value = FileManager.GetGameDataFromContents(fileMetadata, fileContents);
				gameDataContainers[fileMetadata] = value;
			}
		}
		fileListItem.LoadContainer(fileMetadata, value);
		fileListItem.selectionHandle = EntityId.FromGeneric(fileMetadata.platformRootedPath.GetHashCode());
		fileListItem.OnAssignedObjectChanged();
	}

	protected override bool ShouldLayoutItemBeValid(LayoutItem layoutItem)
	{
		return true;
	}

	public void OnLabelSortClicked()
	{
		if (currentSortMethod == FileSortType.FileName)
		{
			currentSortDirection *= -1;
		}
		else
		{
			currentSortMethod = FileSortType.FileName;
			currentSortDirection = 1;
		}
		CreateLayout();
	}

	public void OnDateSortClicked()
	{
		if (currentSortMethod == FileSortType.DateModified)
		{
			currentSortDirection *= -1;
		}
		else
		{
			currentSortMethod = FileSortType.DateModified;
			currentSortDirection = -1;
		}
		CreateLayout();
	}

	public void OnCancelClicked()
	{
		Hide();
		cancelDelegate?.Invoke();
	}

	public void OnActionButtonClicked()
	{
		if (currentPanelMode == FilePanelMode.Load)
		{
			string nameWithExtension = FileManager.AddExtension(inputField.text, FileType.SaveFile);
			FileSource fileSource = Platform.Instance.GetFileSource();
			if (Platform.Instance.FileExists(nameWithExtension, fileSource, FileType.SaveFile, out var resultMetadata))
			{
				MenuManager.Instance.welcomePanel.BeginLoadOfMetadata(resultMetadata);
			}
		}
		else if (currentPanelMode == FilePanelMode.Save)
		{
			string nameWithExtension2 = FileManager.AddExtension(inputField.text, FileType.SaveFile);
			FileSource fileSource2 = Platform.Instance.GetFileSource();
			if (Platform.Instance.FileExists(nameWithExtension2, fileSource2, FileType.SaveFile, out var _))
			{
				MenuPanel.m.playerPromptPanel.ShowConfirmOverwrite(PerformSave, null);
			}
			else
			{
				PerformSave();
			}
		}
	}

	private void PerformSave()
	{
		string text = FileManager.AddExtension(inputField.text, FileType.SaveFile);
		GameManager.Instance.overrideFileName = inputField.text;
		FileManager.Save();
		MenuManager.Instance.ShowMessage("GameSaved".Localized() + " (" + text + ")");
		Hide();
		MenuManager.Instance.gameMenuPanel.Hide();
	}

	public void UpdateSortDisplay()
	{
		fileNameHeaderButton.isSelected = currentSortMethod == FileSortType.FileName;
		dateModifiedHeaderButton.isSelected = currentSortMethod == FileSortType.DateModified;
	}
}
