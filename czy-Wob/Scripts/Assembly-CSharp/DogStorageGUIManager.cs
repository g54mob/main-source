using System.Collections.Generic;
using ClockStone;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DogStorageGUIManager : MonoBehaviour
{
	public GameObject mainStorageUIHolder;

	public GeneticInspectionGUIManager geneticInspectionUIHolder;

	public Transform dogStorageBoxesHolder;

	public CursorUpdateArea dogStorageUpdateArea;

	public CursorUpdateArea inWorldCoresUpdateArea;

	public Color dogHeaderColor;

	public Color coreHeaderColor;

	public Image bgImageRef;

	public List<DogStorageTab> allStorageTabs = new List<DogStorageTab>();

	public List<Image> allTraitIcons = new List<Image>();

	public Tooltip traitTooltip;

	public InventoryItem dogCoreItem;

	public Transform dogsTab;

	public Image dogsTabImage;

	public CoreButtonUnityGUI dogsTabButton;

	public Transform coresTab;

	public Image coresTabImage;

	public CoreButtonUnityGUI coresTabButton;

	public DogStorageTab coresStorageTab;

	public DogStorageTab memorialsStorageTab;

	public GameObject cocoonFilterTab;

	public GameObject penBoxesHolder;

	public GameObject coreBoxesHolder;

	public Transform coreBoxesPlacementTransform;

	public TMP_InputField searchFilter;

	public GameObject applySearchFilterButton;

	public GameObject clearSearchFilterButton;

	private string currentSearchString = "";

	private string currentSearchStringInvariant = "";

	public Color activeTabColor;

	public Color inactiveTabColor;

	public GameObject releaseButtonHolder;

	public GameObject destroyCoreButtonHolder;

	public GameObject releaseDogPopupHolder;

	public GameObject destroyCorePopupHolder;

	public GameObject renameButtonHolder;

	public GameObject renamePopupHolder;

	public Color storeBackingColor;

	public Color bringOutBackingColor;

	public Image rotationCircleBacking;

	public GameObject activeDogCoreIcon;

	public GameObject activeDogCocoonIcon;

	public GameObject activeDogMemorialIcon;

	public Color enabledButtonTextColor;

	public Color disabledButtonTextColor;

	public Color enabledButtonBackingColor;

	public Color disabledButtonBackingColor;

	public Image storeButtonBacking;

	public Image bringOutButtonBacking;

	public TextMeshProUGUI storeButtonText;

	public TextMeshProUGUI bringOutButtonText;

	public GameObject banishButtonHolder;

	public GameObject removeCoreButtonHolder;

	public CoreButtonUnityGUI geneticInspectionButton;

	public Image exportButtonBacking;

	public TextMeshProUGUI exportButtonText;

	public CoreButtonUnityGUI exportButtonRef;

	public GameObject storeDogHighlightHolder;

	public GameObject bringOutDogHighlightHolder;

	public TextMeshProUGUI activeDogAge;

	public TextMeshProUGUI activeDogAgeNumber;

	public TextMeshProUGUI activeDogName;

	public TextScaleInOnLoad dogAgeScaleEffect;

	public TextScaleInOnLoad dogNameScaleEffect;

	public TextScaleInOnLoad dogAgeNumberScaleEffect;

	public Image activeLabelSymbol;

	public GameObject dogLabelHolder;

	public GameObject dogLabelChooser;

	public GameObject loadingDogText;

	public Transform dogRotationTransform;

	public InchwormBounce dogRotationBouncer;

	public CoreButtonUnityGUI storeButton;

	public CoreButtonUnityGUI bringOutButton;

	public InventoryItem cocoonItemRef;

	public GameObject importExportPopupHolder;

	public GameObject pasteButtonHolder;

	public GameObject copyButtonHolder;

	public GameObject confirmImportButtonHolder;

	public GameObject confirmExportButtonHolder;

	public TextMeshProUGUI importExportCodeHolder;

	public TextMeshProUGUI importExportMessageHolder;

	public GameObject closeImportExportWindowButtonHolder;

	public GameObject penLoadingBlocker;

	public GameObject importButtonHolder;

	public GameObject exportButtonHolder;

	public GameObject tutorialArrowExit;

	private float headerActiveYPos = 25f;

	private float headerInactiveYPos;

	private ColorBlock activeTabColorBlock;

	private ColorBlock inactiveTabColorBlock;

	private HeaderType currentHeaderType;

	private float traitScaleTimeOffset = 0.1f;

	private string openSound = "storage_open";

	private string closeSound = "storage_close";

	private string favSound = "storage_favorite";

	private string unfavSound = "storage_unfavorite";

	private string storageFilterOnSound = "storage_filter_on";

	private string storageFilterOffSound = "storage_filter_off";

	private string storageSelectDogSound = "storage_selectDog";

	private string storageStoreDogSound = "storage_storeDog";

	private string storageBringOutDogSound = "storage_bringOutDog";

	private bool isLoadingDog;

	private bool needsDogRefresh;

	private GameObject currentlyRotatedDog;

	public List<DogStorageBox> penBoxes = new List<DogStorageBox>();

	private List<DogStorageBox> instantiatedStorageBoxes = new List<DogStorageBox>();

	private List<DogStorageBox> instantiatedInWorldCoreBoxes = new List<DogStorageBox>();

	private DogStorageBox currentlySelectedBox;

	private SelectionType lastSelectionType;

	private List<DogLabelType> activeTabTypes = new List<DogLabelType>();

	private List<DogLabelType> activeCoreTabTypes = new List<DogLabelType>();

	private float colorEaseTime = 1f;

	private Color startingColor;

	private Color endingColor;

	private float currentEaseTime;

	private bool GUIClosed;

	private bool loadingDogs;

	private int delayedUIRefresh;

	private bool geneticInspectionGUIOpen;

	private DogStorageBox selectedBoxBeforeGeneticInspection;

	private DogHome dogHomeRef;

	private PenFocus penFocusRef;

	private DogRegistration dogRegRef;

	private GhostManager ghostManagerRef;

	private InventoryManager inventoryRef;

	private MusicPlaylistController musicRef;

	private DogThumbnailController thumbnailRef;

	private void Update()
	{
		if (geneticInspectionGUIOpen)
		{
			return;
		}
		if (GameControls.actions.CloseMenu.WasPressed && !TutorialController.IsTutorialActive())
		{
			if (releaseDogPopupHolder.activeSelf)
			{
				OnCancelReleaseButtonPressed();
			}
			else if (destroyCorePopupHolder.activeSelf)
			{
				OnCancelDestroyCoreButtonPressed();
			}
			else if (renamePopupHolder.activeSelf)
			{
				renamePopupHolder.GetComponent<DogNameInputStorage>().OnCancelButtonPressed();
			}
			else
			{
				if (!importExportPopupHolder.activeSelf)
				{
					CloseGUI();
					return;
				}
				CloseImportExportWindow();
			}
		}
		if (delayedUIRefresh > 0)
		{
			delayedUIRefresh--;
			if (delayedUIRefresh <= 0)
			{
				if (currentlySelectedBox != null)
				{
					RefreshUI(currentlySelectedBox.boxIndex);
				}
				else
				{
					RefreshUI(0);
				}
			}
		}
		EaseColors();
		if (loadingDogs && !dogRegRef.IsLoadingOwnedDogs())
		{
			loadingDogs = false;
			if (currentlySelectedBox != null)
			{
				RefreshUI(currentlySelectedBox.boxIndex, checkBothSelectionTypes: false, leaveSelectedStorageDog: true);
			}
			else
			{
				RefreshUI(0, checkBothSelectionTypes: false, leaveSelectedStorageDog: true);
			}
		}
	}

	public void CloseGeneticInspectionGUIManager()
	{
		geneticInspectionGUIOpen = false;
		geneticInspectionButton.gameObject.SetActive(value: true);
		geneticInspectionUIHolder.gameObject.SetActive(value: false);
		SelectBox(selectedBoxBeforeGeneticInspection);
	}

	public void OpenGeneticInspectionGUIManager()
	{
		if (currentlySelectedBox == null)
		{
			Debug.LogError("Attempting to open genetic inspection UI without any selected dog.");
			return;
		}
		geneticInspectionGUIOpen = true;
		geneticInspectionButton.gameObject.SetActive(value: false);
		geneticInspectionUIHolder.gameObject.SetActive(value: true);
		if (currentHeaderType == HeaderType.DOGS)
		{
			SaveableDog saveableDogFromID = dogRegRef.GetSaveableDogFromID(currentlySelectedBox.associatedDogID);
			if (saveableDogFromID == null)
			{
				selectedBoxBeforeGeneticInspection = currentlySelectedBox;
				DeselectActiveBox();
				Debug.LogError("No SaveableDog found for ID: " + currentlySelectedBox.associatedDogID);
				return;
			}
			geneticInspectionUIHolder.SetSaveableDog(saveableDogFromID);
		}
		else
		{
			DogCore associatedCoreObject = currentlySelectedBox.associatedCoreObject;
			SaveableDogCore associatedCore = currentlySelectedBox.associatedCore;
			DogMemorial associatedMemorial = currentlySelectedBox.associatedMemorial;
			if (associatedCore != null)
			{
				geneticInspectionUIHolder.SetSaveableDogCore(associatedCore);
			}
			else if (associatedCoreObject != null)
			{
				geneticInspectionUIHolder.SetDogCore(associatedCoreObject);
			}
			else if (associatedMemorial != null)
			{
				geneticInspectionUIHolder.SetDogMemorial(associatedMemorial);
			}
		}
		selectedBoxBeforeGeneticInspection = currentlySelectedBox;
		DeselectActiveBox();
	}

	public void OnGUIOpened()
	{
		SFXOverlord.LockInWorldSFX(LockReason.DOG_STORAGE_GUI);
		geneticInspectionGUIOpen = false;
		mainStorageUIHolder.SetActive(value: true);
		geneticInspectionUIHolder.gameObject.SetActive(value: false);
		geneticInspectionButton.interactable = false;
		Initialize();
		if (TutorialController.IsTutorialActive())
		{
			TutorialController.OnDogStorageScreenOpened();
		}
		musicRef.OnEnterDogStorage();
		AudioController.Play(openSound);
	}

	private void OnDestroy()
	{
		RecycleBoxes();
		GUIClosed = true;
		SFXOverlord.UnlockInWorldSFX(LockReason.DOG_STORAGE_GUI);
		if (TutorialController.IsTutorialActive())
		{
			TutorialController.OnDogStorageScreenClosed();
		}
		musicRef.OnExitDogStorage();
		AudioController.Play(closeSound);
	}

	public void CloseGUI()
	{
		GUIClosed = true;
		ObjectRegistration.GetRegistrationScript().GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI).OnDogStorageGUIClosed();
	}

	public void OnImportButtonPressed()
	{
		importExportPopupHolder.SetActive(value: true);
		copyButtonHolder.SetActive(value: false);
		pasteButtonHolder.SetActive(value: true);
		confirmImportButtonHolder.SetActive(value: true);
		confirmExportButtonHolder.SetActive(value: false);
		importExportCodeHolder.text = "";
		importExportMessageHolder.text = "";
	}

	public void OnExportButtonPressed()
	{
		SaveableDog saveableDogFromID = dogRegRef.GetSaveableDogFromID(currentlySelectedBox.associatedDogID);
		importExportPopupHolder.SetActive(value: true);
		copyButtonHolder.SetActive(value: true);
		pasteButtonHolder.SetActive(value: false);
		confirmExportButtonHolder.SetActive(value: false);
		confirmImportButtonHolder.SetActive(value: false);
		importExportMessageHolder.text = "";
		importExportCodeHolder.text = dogRegRef.ExportDog(saveableDogFromID);
	}

	public void OnCopyExportCodeButtonPressed()
	{
		UniClipboard.SetText(importExportCodeHolder.text);
		copyButtonHolder.SetActive(value: false);
		confirmExportButtonHolder.SetActive(value: true);
		importExportCodeHolder.text = "";
		importExportMessageHolder.text = ScriptLocalization.GUI.GUI_STRG_CODECOPIED;
	}

	public void OnPasteImportCodeButtonPressed()
	{
		importExportMessageHolder.text = "";
		importExportCodeHolder.text = UniClipboard.GetText();
	}

	public void OnConfirmImportButtonPressed()
	{
		copyButtonHolder.SetActive(value: false);
		pasteButtonHolder.SetActive(value: false);
		confirmImportButtonHolder.SetActive(value: false);
		closeImportExportWindowButtonHolder.SetActive(value: false);
		if (dogRegRef.TryImportDog(importExportCodeHolder.text, OnDogImportComplete))
		{
			importExportCodeHolder.text = "";
			importExportMessageHolder.text = ScriptLocalization.GUI.GUI_STRG_IMPORTING;
			return;
		}
		confirmExportButtonHolder.SetActive(value: true);
		closeImportExportWindowButtonHolder.SetActive(value: true);
		importExportCodeHolder.text = "";
		importExportMessageHolder.text = ScriptLocalization.GUI.GUI_STRG_INVALIDCODE;
	}

	private void OnDogImportComplete()
	{
		confirmExportButtonHolder.SetActive(value: true);
		closeImportExportWindowButtonHolder.SetActive(value: true);
		importExportCodeHolder.text = "";
		importExportMessageHolder.text = ScriptLocalization.GUI.GUI_STRG_IMPORTSUCCESS;
		if (currentlySelectedBox != null)
		{
			RefreshUI(currentlySelectedBox.boxIndex);
		}
		else
		{
			RefreshUI(0);
		}
		if (GoalsController.GetCounterForCondition(GoalCondition.IMPORT_DOG) == 0)
		{
			GoalsController.SetGoalEvent(GoalCondition.IMPORT_DOG, 1);
		}
	}

	public void CloseImportExportWindow()
	{
		importExportPopupHolder.SetActive(value: false);
	}

	public void OnBanishButtonPressed()
	{
		ulong associatedDogID = currentlySelectedBox.associatedDogID;
		GameObject dogFromID = dogRegRef.GetDogFromID(associatedDogID);
		if (dogFromID == null)
		{
			RefreshUI(currentlySelectedBox.boxIndex);
			Debug.LogError("No active dog found for banishment request.");
		}
		else
		{
			ghostManagerRef.BanishGhost(dogFromID);
			RefreshUI(currentlySelectedBox.boxIndex);
		}
	}

	public void OnRemoveCoreButtonPressed()
	{
		delayedUIRefresh = 2;
		currentlySelectedBox.associatedMemorial.RemoveCore();
	}

	public void OnStoreButtonPressed()
	{
		if (currentlySelectedBox.associatedCoreObject != null)
		{
			StoreDogCore(currentlySelectedBox.associatedCoreObject.gameObject);
			return;
		}
		if (currentlySelectedBox.associatedMemorial != null)
		{
			StoreDogMemorial(currentlySelectedBox.associatedMemorial);
			return;
		}
		ulong associatedDogID = currentlySelectedBox.associatedDogID;
		if (!dogRegRef.IsGivenDogBeingLoaded(associatedDogID))
		{
			AudioController.Play(storageStoreDogSound);
			GameObject gameObject = ((!dogRegRef.GetSaveableDogFromID(associatedDogID).inCocoon) ? dogRegRef.GetDogFromID(associatedDogID) : dogRegRef.GetCocoonFromID(associatedDogID));
			if (gameObject != null)
			{
				gameObject.GetComponent<RegisterTaggedObject>().ManualUnregister();
				Object.Destroy(gameObject);
			}
			RefreshUI(currentlySelectedBox.boxIndex);
		}
	}

	private void StoreDogCore(GameObject coreObject)
	{
		AudioController.Play(storageStoreDogSound);
		ObjectRegistration.GetRegistrationScript().UnregisterTaggedObject(coreObject, TagsEnum.DOG_CORE);
		Object.Destroy(coreObject);
		RefreshUI(currentlySelectedBox.boxIndex);
		delayedUIRefresh = 2;
	}

	private void StoreDogMemorial(DogMemorial memorialObject)
	{
		AudioController.Play(storageStoreDogSound);
		memorialObject.OnRemovedFromRoom();
		memorialObject.RemoveCore(destroyCore: true);
		delayedUIRefresh = 2;
	}

	public void OnBringOutButtonPressed()
	{
		if (dogRegRef.IsGivenDogBeingLoaded(currentlySelectedBox.associatedDogID))
		{
			return;
		}
		SaveableDog saveableDog = null;
		if (currentHeaderType == HeaderType.DOGS)
		{
			saveableDog = dogRegRef.GetSaveableDogFromID(currentlySelectedBox.associatedDogID);
			if (saveableDog.inWorld)
			{
				return;
			}
		}
		AudioController.Play(storageBringOutDogSound);
		ulong value = 0uL;
		GameObject gameObject = penFocusRef.GetFocusedRoom();
		if (penFocusRef.FollowCamActive())
		{
			Transform followTarget = penFocusRef.GetFollowTarget();
			if (followTarget != null)
			{
				BoundingBoxComponent component = followTarget.root.GetComponent<BoundingBoxComponent>();
				if (component != null)
				{
					RoomBase currentRoom = component.GetCurrentRoom(requireInRoom: true);
					if (currentRoom != null)
					{
						gameObject = currentRoom.gameObject;
					}
				}
			}
		}
		if (gameObject == null)
		{
			gameObject = penFocusRef.GetLastFocusedRoom();
		}
		if (gameObject != null)
		{
			DogDenInterior component2 = gameObject.GetComponent<DogDenInterior>();
			if (component2 != null)
			{
				ulong? roomUID = component2.associatedDenRef.GetComponent<BoundingBoxComponent>().GetRoomUID();
				if (!roomUID.HasValue)
				{
					return;
				}
				value = roomUID.Value;
			}
			else
			{
				value = gameObject.GetComponent<BuildObjectInfo>().GetUID();
			}
		}
		if (saveableDog != null && saveableDog.inCocoon)
		{
			Vector3 value2 = cocoonItemRef.itemPrefab.transform.localScale * saveableDog.cocoonScale;
			if (value2.x <= 0.01f)
			{
				value2 = cocoonItemRef.itemPrefab.transform.localScale;
			}
			GameObject gameObject2 = dogHomeRef.TrySpawnItem(cocoonItemRef, dogHomeRef.GetPosForRoom(value), customScale: value2, expectedRoom: value);
			if (gameObject2 == null)
			{
				Debug.LogError("Something went wrong while attempting to bring out a cocoon dog.");
				return;
			}
			saveableDog.inWorld = true;
			dogRegRef.UpdateSaveableDog(saveableDog);
			dogRegRef.CacheThumbnailForDogID(saveableDog.dogID);
			gameObject2.GetComponent<Cocoon>().SetAssociatedDogID(saveableDog.dogID);
			RefreshUI(currentlySelectedBox.boxIndex);
			return;
		}
		if (saveableDog != null)
		{
			dogRegRef.RequestNewDog(dogHomeRef.GetPosForRoom(value), Quaternion.identity, null, saveableDog, manualDog: false, DogCreationCallback);
		}
		else if (currentHeaderType == HeaderType.CORES)
		{
			Vector3 placementPos = Vector3.zero;
			if (gameObject != null)
			{
				placementPos = gameObject.GetComponent<RoomBase>().GetRoomCenter();
			}
			GameObject gameObject3 = dogHomeRef.TrySpawnItem(dogCoreItem, placementPos);
			if (gameObject3 != null)
			{
				gameObject3.GetComponent<DogCore>().LoadSaveableDogCore(currentlySelectedBox.associatedCore);
				inventoryRef.playerInventory.RemoveDogCoreFromInventory(currentlySelectedBox.associatedCore);
			}
			else
			{
				Debug.LogError("Something went wrong while trying to remove a dog core from our inventory through the storage screen.");
			}
			delayedUIRefresh = 2;
			return;
		}
		RefreshUI(currentlySelectedBox.boxIndex);
	}

	public void OnRenameButtonPressed()
	{
		if (!(currentlySelectedBox == null))
		{
			renamePopupHolder.SetActive(value: true);
			renamePopupHolder.GetComponent<DogNameInputStorage>().SetDogRef(currentlySelectedBox.associatedDogID);
		}
	}

	public void OnRenameComplete()
	{
		RefreshUI(currentlySelectedBox.boxIndex);
	}

	public void OnReleaseButtonPressed()
	{
		releaseDogPopupHolder.SetActive(value: true);
	}

	public void OnDestroyCoreButtonPressed()
	{
		destroyCorePopupHolder.SetActive(value: true);
	}

	public void OnConfirmReleaseButtonPressed()
	{
		SaveableDog saveableDogFromID = dogRegRef.GetSaveableDogFromID(currentlySelectedBox.associatedDogID);
		if (saveableDogFromID == null)
		{
			releaseDogPopupHolder.SetActive(value: false);
			return;
		}
		dogRegRef.ReleaseAndRemoveDog(saveableDogFromID);
		RefreshUI(currentlySelectedBox.boxIndex);
		releaseDogPopupHolder.SetActive(value: false);
	}

	public void OnCancelReleaseButtonPressed()
	{
		releaseDogPopupHolder.SetActive(value: false);
	}

	public void OnConfirmDestroyCoreButtonPressed()
	{
		SaveableDogCore associatedCore = currentlySelectedBox.associatedCore;
		if (associatedCore != null)
		{
			inventoryRef.playerInventory.RemoveDogCoreFromInventory(associatedCore);
			RefreshUI(currentlySelectedBox.boxIndex);
		}
		else if (currentlySelectedBox.associatedCoreObject != null)
		{
			currentlySelectedBox.associatedCoreObject.GetComponent<RegisterTaggedObject>().SetSafeDestroy();
			Object.Destroy(currentlySelectedBox.associatedCoreObject.gameObject);
			delayedUIRefresh = 2;
		}
		else if (currentlySelectedBox.associatedMemorial != null)
		{
			currentlySelectedBox.associatedMemorial.SetMoveCoreToInventory(val: false);
			currentlySelectedBox.associatedMemorial.RemoveCore(destroyCore: true);
			delayedUIRefresh = 2;
		}
		destroyCorePopupHolder.SetActive(value: false);
	}

	public void OnCancelDestroyCoreButtonPressed()
	{
		destroyCorePopupHolder.SetActive(value: false);
	}

	public void OnSelectLabelButtonPressed()
	{
		if (currentHeaderType == HeaderType.DOGS)
		{
			if (dogRegRef.GetSaveableDogFromID(currentlySelectedBox.associatedDogID) == null)
			{
				return;
			}
		}
		else if (currentlySelectedBox.associatedCore == null && currentlySelectedBox.associatedCoreObject == null && currentlySelectedBox.associatedMemorial == null)
		{
			return;
		}
		dogLabelChooser.SetActive(value: true);
	}

	public void OnCloseLabelChooserPressed()
	{
		dogLabelChooser.SetActive(value: false);
	}

	public void OnLabelSelected(DogLabelType newlabel)
	{
		dogLabelChooser.SetActive(value: false);
		if (currentHeaderType == HeaderType.DOGS)
		{
			if (dogRegRef.GetSaveableDogFromID(currentlySelectedBox.associatedDogID) == null)
			{
				return;
			}
			dogRegRef.SetDogLabel(currentlySelectedBox.associatedDogID, newlabel);
		}
		else if (currentlySelectedBox.associatedCoreObject != null)
		{
			currentlySelectedBox.associatedCoreObject.labelType = newlabel;
		}
		else if (currentlySelectedBox.associatedMemorial != null)
		{
			currentlySelectedBox.associatedMemorial.labelType = newlabel;
		}
		else if (currentlySelectedBox.associatedCore != null)
		{
			currentlySelectedBox.associatedCore.labelType = newlabel;
		}
		if (newlabel == DogLabelType.NONE)
		{
			AudioController.Play(unfavSound);
		}
		else
		{
			AudioController.Play(favSound);
		}
		RefreshUI(currentlySelectedBox.boxIndex);
	}

	public void OnStorageTabSelected(DogLabelType selectedType)
	{
		if (!activeTabTypes.Contains(selectedType))
		{
			AudioController.Play(storageFilterOnSound);
			activeTabTypes.Add(selectedType);
			if (currentlySelectedBox != null)
			{
				RefreshUI(currentlySelectedBox.boxIndex);
			}
			else
			{
				RefreshUI(0);
			}
		}
	}

	public void OnStorageTabDeselected(DogLabelType deselctedType)
	{
		if (activeTabTypes.Contains(deselctedType))
		{
			AudioController.Play(storageFilterOffSound);
			activeTabTypes.Remove(deselctedType);
			if (currentlySelectedBox != null)
			{
				RefreshUI(currentlySelectedBox.boxIndex);
			}
			else
			{
				RefreshUI(0);
			}
		}
	}

	public void OnCoreStorageTabSelected(DogLabelType selectedType)
	{
		if (!activeCoreTabTypes.Contains(selectedType))
		{
			AudioController.Play(storageFilterOnSound);
			activeCoreTabTypes.Add(selectedType);
			if (currentlySelectedBox != null)
			{
				RefreshUI(currentlySelectedBox.boxIndex);
			}
			else
			{
				RefreshUI(0);
			}
		}
	}

	public void OnCoreStorageTabDeselected(DogLabelType deselctedType)
	{
		if (activeCoreTabTypes.Contains(deselctedType))
		{
			AudioController.Play(storageFilterOffSound);
			activeCoreTabTypes.Remove(deselctedType);
			if (currentlySelectedBox != null)
			{
				RefreshUI(currentlySelectedBox.boxIndex);
			}
			else
			{
				RefreshUI(0);
			}
		}
	}

	private void Initialize()
	{
		loadingDogText.SetActive(value: false);
		tutorialArrowExit.SetActive(value: false);
		penLoadingBlocker.SetActive(value: false);
		renamePopupHolder.SetActive(value: false);
		activeDogCoreIcon.SetActive(value: false);
		activeDogCocoonIcon.SetActive(value: false);
		activeDogMemorialIcon.SetActive(value: false);
		releaseDogPopupHolder.SetActive(value: false);
		destroyCorePopupHolder.SetActive(value: false);
		importExportPopupHolder.SetActive(value: false);
		storeDogHighlightHolder.SetActive(value: false);
		bringOutDogHighlightHolder.SetActive(value: false);
		applySearchFilterButton.SetActive(value: true);
		clearSearchFilterButton.SetActive(value: false);
		DisableBanishButton();
		removeCoreButtonHolder.SetActive(value: false);
		renamePopupHolder.GetComponent<DogNameInputStorage>().SetStorageRef(this);
		penFocusRef = Camera.main.GetComponent<PenFocus>();
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		dogHomeRef = registrationScript.GetGlobalComponent<DogHome>(GlobalObject.DOG_HOME);
		musicRef = SingletonMonoBehaviour<AudioController>.Instance.GetComponent<MusicPlaylistController>();
		ghostManagerRef = registrationScript.GetGlobalComponent<GhostManager>(GlobalObject.GHOST_MANAGER);
		dogRegRef = registrationScript.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		inventoryRef = registrationScript.GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER);
		thumbnailRef = dogRegRef.GetThumbnailRef();
		for (int i = 0; i < allStorageTabs.Count; i++)
		{
			allStorageTabs[i].SetStorageRef(this);
		}
		coresStorageTab.SetStorageRef(this);
		memorialsStorageTab.SetStorageRef(this);
		CoreButtonUnityGUI coreButtonUnityGUI = dogsTabButton;
		activeTabColorBlock = default(ColorBlock);
		inactiveTabColorBlock = default(ColorBlock);
		activeTabColorBlock.colorMultiplier = 1f;
		activeTabColorBlock.normalColor = activeTabColor;
		activeTabColorBlock.selectedColor = activeTabColor;
		activeTabColorBlock.disabledColor = activeTabColor;
		activeTabColorBlock.pressedColor = activeTabColor;
		activeTabColorBlock.highlightedColor = activeTabColor;
		inactiveTabColorBlock.colorMultiplier = 1f;
		inactiveTabColorBlock.normalColor = inactiveTabColor;
		inactiveTabColorBlock.selectedColor = coreButtonUnityGUI.colors.selectedColor;
		inactiveTabColorBlock.disabledColor = coreButtonUnityGUI.colors.disabledColor;
		inactiveTabColorBlock.pressedColor = coreButtonUnityGUI.colors.pressedColor;
		inactiveTabColorBlock.highlightedColor = coreButtonUnityGUI.colors.highlightedColor;
		SetHeaderType(HeaderType.DOGS, fromLoad: true);
		RefreshUI(0, checkBothSelectionTypes: true);
	}

	public void OnDogsTabClicked()
	{
		if (currentHeaderType != HeaderType.DOGS)
		{
			SetHeaderType(HeaderType.DOGS);
			AudioController.Play(storageFilterOnSound);
		}
	}

	public void OnCoresTabClicked()
	{
		if (currentHeaderType != HeaderType.CORES)
		{
			SetHeaderType(HeaderType.CORES);
			AudioController.Play(storageFilterOnSound);
		}
	}

	public void SetHeaderType(HeaderType newType, bool fromLoad = false)
	{
		currentHeaderType = newType;
		RefreshUI(0, checkBothSelectionTypes: true);
		if (currentHeaderType == HeaderType.DOGS)
		{
			SetTargetBGColor(dogHeaderColor, fromLoad);
			cocoonFilterTab.SetActive(value: true);
			penBoxesHolder.SetActive(value: true);
			coreBoxesHolder.SetActive(value: false);
			dogsTabButton.colors = activeTabColorBlock;
			coresTabButton.colors = inactiveTabColorBlock;
			dogsTab.transform.localPosition = new Vector3(dogsTab.localPosition.x, headerActiveYPos, dogsTab.localPosition.z);
			coresTab.transform.localPosition = new Vector3(coresTab.localPosition.x, headerInactiveYPos, coresTab.localPosition.z);
		}
		else
		{
			SetTargetBGColor(coreHeaderColor, fromLoad);
			cocoonFilterTab.SetActive(value: false);
			penBoxesHolder.SetActive(value: false);
			coreBoxesHolder.SetActive(value: true);
			dogsTabImage.GetComponent<CoreButtonUnityGUI>().colors = inactiveTabColorBlock;
			coresTabImage.GetComponent<CoreButtonUnityGUI>().colors = activeTabColorBlock;
			dogsTab.transform.localPosition = new Vector3(dogsTab.localPosition.x, headerInactiveYPos, dogsTab.localPosition.z);
			coresTab.transform.localPosition = new Vector3(coresTab.localPosition.x, headerActiveYPos, coresTab.localPosition.z);
		}
		if (currentlySelectedBox != null)
		{
			RefreshUI(currentlySelectedBox.boxIndex);
		}
		else
		{
			RefreshUI(0);
		}
	}

	private void SetTargetBGColor(Color c, bool fromLoad)
	{
		if (fromLoad)
		{
			endingColor = c;
			startingColor = c;
			currentEaseTime = 0f;
			bgImageRef.material.SetColor("_Color", c);
		}
		else
		{
			endingColor = c;
			startingColor = bgImageRef.material.GetColor("_Color");
			currentEaseTime = colorEaseTime;
		}
	}

	private void EaseColors()
	{
		if (!(currentEaseTime <= 0f))
		{
			currentEaseTime -= Time.deltaTime;
			if (currentEaseTime < 0f)
			{
				currentEaseTime = 0f;
			}
			bgImageRef.material.SetColor("_Color", Color.Lerp(startingColor, endingColor, 1f - currentEaseTime / colorEaseTime));
		}
	}

	public void SetExitArrowStatus(bool val)
	{
		tutorialArrowExit.SetActive(val);
	}

	private void DogCreationCallback(GameObject dog)
	{
		dogRegRef.SaveDog(dog, inWorld: true);
		dogRegRef.CacheThumbnailForDogID(dogRegRef.GetIDFromDog(dog));
	}

	private void RefreshUI(int lastActiveIndex, bool checkBothSelectionTypes = false, bool leaveSelectedStorageDog = false)
	{
		if (!leaveSelectedStorageDog || (currentlySelectedBox != null && currentlySelectedBox.boxType == BoxType.PENS))
		{
			DeselectActiveBox();
		}
		PopulatePenBoxes();
		if (!leaveSelectedStorageDog)
		{
			if (currentHeaderType == HeaderType.DOGS)
			{
				PopulateStorageBoxes();
			}
			else if (currentHeaderType == HeaderType.CORES)
			{
				PopulateCoreStorageBoxes();
			}
		}
		if (dogRegRef.IsLoadingOwnedDogs())
		{
			loadingDogs = true;
			penLoadingBlocker.SetActive(value: true);
		}
		else
		{
			penLoadingBlocker.SetActive(value: false);
		}
		if (lastSelectionType == SelectionType.PENS)
		{
			if (!TrySelectPensDog(ref lastActiveIndex) && checkBothSelectionTypes)
			{
				TrySelectStorageDog(ref lastActiveIndex);
			}
		}
		else if ((!leaveSelectedStorageDog || currentlySelectedBox == null || currentlySelectedBox.boxType == BoxType.PENS) && !TrySelectStorageDog(ref lastActiveIndex) && checkBothSelectionTypes)
		{
			TrySelectPensDog(ref lastActiveIndex);
		}
	}

	private bool TrySelectPensDog(ref int lastActiveIndex)
	{
		if (currentHeaderType == HeaderType.CORES)
		{
			if (instantiatedInWorldCoreBoxes.Count == 0)
			{
				return false;
			}
			if (lastActiveIndex >= instantiatedInWorldCoreBoxes.Count)
			{
				lastActiveIndex = instantiatedInWorldCoreBoxes.Count - 1;
			}
			SelectBox(instantiatedInWorldCoreBoxes[lastActiveIndex].GetComponent<DogStorageBox>());
			return true;
		}
		if (dogRegRef.IsLoadingOwnedDogs())
		{
			return false;
		}
		while (lastActiveIndex >= 0)
		{
			if (penBoxes.Count > lastActiveIndex && penBoxes[lastActiveIndex].IsButtonEnabled())
			{
				SelectBox(penBoxes[lastActiveIndex]);
				return true;
			}
			if (lastActiveIndex == 0)
			{
				break;
			}
			lastActiveIndex--;
		}
		return false;
	}

	private bool TrySelectStorageDog(ref int lastActiveIndex)
	{
		if (instantiatedStorageBoxes.Count == 0)
		{
			return false;
		}
		if (lastActiveIndex >= instantiatedStorageBoxes.Count)
		{
			lastActiveIndex = instantiatedStorageBoxes.Count - 1;
		}
		SelectBox(instantiatedStorageBoxes[lastActiveIndex].GetComponent<DogStorageBox>());
		return true;
	}

	private void PopulatePenBoxes()
	{
		if (currentHeaderType == HeaderType.CORES)
		{
			for (int i = 0; i < penBoxes.Count; i++)
			{
				penBoxes[i].SetEnabled(val: false);
			}
			PopulateInWorldCoreBoxes();
			return;
		}
		int num = 0;
		List<ulong> orderedDogUIDs = dogRegRef.GetOrderedDogUIDs();
		List<ulong> listOfOwnedDogsBeingLoaded = dogRegRef.GetListOfOwnedDogsBeingLoaded();
		for (int j = 0; j < listOfOwnedDogsBeingLoaded.Count; j++)
		{
			if (!orderedDogUIDs.Contains(listOfOwnedDogsBeingLoaded[j]))
			{
				orderedDogUIDs.Add(listOfOwnedDogsBeingLoaded[j]);
			}
		}
		for (int k = 0; k < orderedDogUIDs.Count && k < penBoxes.Count; k++)
		{
			penBoxes[k].SetDog(orderedDogUIDs[k], dogRegRef, this, null, k);
			num++;
		}
		for (int l = orderedDogUIDs.Count; l < penBoxes.Count; l++)
		{
			penBoxes[l].SetEnabled(val: false);
		}
	}

	private void PopulateInWorldCoreBoxes()
	{
		RecycleInWorldCoreBoxes();
		int num = 0;
		if (activeCoreTabTypes.Count == 0 || activeCoreTabTypes.Contains(DogLabelType.MEMORIAL))
		{
			List<ulong> allMemorialIDs = ghostManagerRef.GetAllMemorialIDs();
			for (int i = 0; i < allMemorialIDs.Count; i++)
			{
				GameObject placeableObjectForUID = ObjectRegistration.GetRegistrationScript().GetPlaceableObjectForUID(allMemorialIDs[i]);
				if (!(placeableObjectForUID == null))
				{
					DogMemorial component = placeableObjectForUID.GetComponent<DogMemorial>();
					DogStorageBox usableDogStorageBox = thumbnailRef.GetUsableDogStorageBox();
					usableDogStorageBox.boxType = BoxType.PENS;
					instantiatedInWorldCoreBoxes.Add(usableDogStorageBox);
					usableDogStorageBox.transform.SetParent(coreBoxesPlacementTransform);
					usableDogStorageBox.transform.localScale = Vector3.one;
					usableDogStorageBox.SetMemorialObject(component, dogRegRef, this, inWorldCoresUpdateArea, num);
					num++;
				}
			}
		}
		if (activeCoreTabTypes.Count == 0 || activeCoreTabTypes.Contains(DogLabelType.CORE))
		{
			List<GameObject> allObjectsForTag = ObjectRegistration.GetRegistrationScript().GetAllObjectsForTag(TagsEnum.DOG_CORE);
			for (int j = 0; j < allObjectsForTag.Count; j++)
			{
				DogCore component2 = allObjectsForTag[j].GetComponent<DogCore>();
				DogStorageBox usableDogStorageBox2 = thumbnailRef.GetUsableDogStorageBox();
				usableDogStorageBox2.boxType = BoxType.PENS;
				instantiatedInWorldCoreBoxes.Add(usableDogStorageBox2);
				usableDogStorageBox2.transform.SetParent(coreBoxesPlacementTransform);
				usableDogStorageBox2.transform.localScale = Vector3.one;
				usableDogStorageBox2.SetDogCoreObject(component2, dogRegRef, this, inWorldCoresUpdateArea, num);
				num++;
			}
		}
	}

	private void PopulateCoreStorageBoxes()
	{
		RecycleStorageBoxes();
		int num = activeTabTypes.Count;
		if (activeTabTypes.Contains(DogLabelType.COCOON))
		{
			num--;
		}
		int num2 = 0;
		List<SaveableDogCore> heldDogCores = inventoryRef.GetHeldDogCores();
		for (int i = 0; i < heldDogCores.Count; i++)
		{
			DogLabelType labelType = heldDogCores[i].labelType;
			bool flag = false;
			if (num == 0)
			{
				flag = true;
			}
			if (num > 0 && activeTabTypes.Contains(labelType))
			{
				flag = true;
			}
			if (!flag)
			{
				continue;
			}
			if (currentSearchString.Length > 0)
			{
				string text = heldDogCores[i].dogName.ToLower();
				string text2 = heldDogCores[i].dogName.ToLowerInvariant();
				if (!text.Contains(currentSearchString) && !text2.Contains(currentSearchString) && !text.Contains(currentSearchStringInvariant) && !text2.Contains(currentSearchStringInvariant))
				{
					continue;
				}
			}
			DogStorageBox usableDogStorageBox = thumbnailRef.GetUsableDogStorageBox();
			usableDogStorageBox.boxType = BoxType.STORAGE;
			instantiatedStorageBoxes.Add(usableDogStorageBox);
			usableDogStorageBox.transform.SetParent(dogStorageBoxesHolder);
			usableDogStorageBox.transform.localScale = Vector3.one;
			usableDogStorageBox.SetDogCore(heldDogCores[i], dogRegRef, this, dogStorageUpdateArea, num2);
			num2++;
		}
	}

	private void PopulateStorageBoxes()
	{
		RecycleStorageBoxes();
		int num = 0;
		List<SaveableDog> allOwnedDogs = dogRegRef.GetAllOwnedDogs();
		List<ulong> listOfOwnedDogsBeingLoaded = dogRegRef.GetListOfOwnedDogsBeingLoaded();
		for (int i = 0; i < allOwnedDogs.Count; i++)
		{
			if (allOwnedDogs[i].inWorld || listOfOwnedDogsBeingLoaded.Contains(allOwnedDogs[i].dogID))
			{
				continue;
			}
			DogLabelType dogLabelType = allOwnedDogs[i].labelType;
			if (dogLabelType == DogLabelType.NONE && allOwnedDogs[i].favorite)
			{
				dogLabelType = DogLabelType.STAR;
			}
			bool flag = false;
			bool flag2 = activeTabTypes.Contains(DogLabelType.COCOON);
			if (activeTabTypes.Count == 0)
			{
				flag = true;
			}
			if (flag2)
			{
				if (activeTabTypes.Count > 1 && activeTabTypes.Contains(dogLabelType))
				{
					flag = true;
				}
			}
			else if (activeTabTypes.Count > 0 && activeTabTypes.Contains(dogLabelType))
			{
				flag = true;
			}
			if (!flag && (!flag2 || !allOwnedDogs[i].inCocoon))
			{
				continue;
			}
			if (currentSearchString.Length > 0)
			{
				string text = allOwnedDogs[i].dogName.ToLower();
				string text2 = allOwnedDogs[i].dogName.ToLowerInvariant();
				if (!text.Contains(currentSearchString) && !text2.Contains(currentSearchString) && !text.Contains(currentSearchStringInvariant) && !text2.Contains(currentSearchStringInvariant))
				{
					continue;
				}
			}
			DogStorageBox usableDogStorageBox = thumbnailRef.GetUsableDogStorageBox();
			usableDogStorageBox.boxType = BoxType.STORAGE;
			instantiatedStorageBoxes.Add(usableDogStorageBox);
			usableDogStorageBox.transform.SetParent(dogStorageBoxesHolder);
			usableDogStorageBox.transform.localScale = Vector3.one;
			usableDogStorageBox.SetDog(allOwnedDogs[i].dogID, dogRegRef, this, dogStorageUpdateArea, num);
			num++;
		}
	}

	public void OnSearchFilterApplied()
	{
		if (searchFilter.text.Length != 0)
		{
			currentSearchString = searchFilter.text.ToLower();
			currentSearchStringInvariant = searchFilter.text.ToLowerInvariant();
			clearSearchFilterButton.SetActive(value: true);
			if (currentlySelectedBox != null)
			{
				RefreshUI(currentlySelectedBox.boxIndex);
			}
			else
			{
				RefreshUI(0);
			}
		}
	}

	public void OnSearchFilterCleared()
	{
		currentSearchString = "";
		currentSearchStringInvariant = "";
		searchFilter.SetTextWithoutNotify("");
		clearSearchFilterButton.SetActive(value: false);
		if (currentlySelectedBox != null)
		{
			RefreshUI(currentlySelectedBox.boxIndex);
		}
		else
		{
			RefreshUI(0);
		}
	}

	private void RecycleBoxes()
	{
		RecycleStorageBoxes();
		RecycleInWorldCoreBoxes();
	}

	private void RecycleStorageBoxes()
	{
		for (int num = instantiatedStorageBoxes.Count - 1; num >= 0; num--)
		{
			thumbnailRef.RecycleDogStorageBox(instantiatedStorageBoxes[num]);
		}
		instantiatedStorageBoxes.Clear();
	}

	private void RecycleInWorldCoreBoxes()
	{
		for (int num = instantiatedInWorldCoreBoxes.Count - 1; num >= 0; num--)
		{
			thumbnailRef.RecycleDogStorageBox(instantiatedInWorldCoreBoxes[num]);
		}
		instantiatedInWorldCoreBoxes.Clear();
	}

	public void OnTraitHoverStart(int index)
	{
		traitTooltip.SetItem(GetTraitInfoForIndex(index));
		traitTooltip.gameObject.SetActive(value: true);
	}

	public void OnTraitHover()
	{
		traitTooltip.HoverBehavior();
	}

	public void OnTraitHoverStop()
	{
		traitTooltip.gameObject.SetActive(value: false);
	}

	public void SelectBox(DogStorageBox boxRef)
	{
		if (currentlySelectedBox != null && boxRef.boxIndex == currentlySelectedBox.boxIndex && boxRef.selectionType == currentlySelectedBox.selectionType && boxRef.boxType == currentlySelectedBox.boxType)
		{
			return;
		}
		if (currentlySelectedBox != null)
		{
			DeselectActiveBox();
		}
		currentlySelectedBox = boxRef;
		currentlySelectedBox.SetBoxSelected();
		EnableExportButton();
		DogCore associatedCoreObject = boxRef.associatedCoreObject;
		SaveableDogCore associatedCore = boxRef.associatedCore;
		DogMemorial associatedMemorial = boxRef.associatedMemorial;
		SaveableDog saveableDogFromID = dogRegRef.GetSaveableDogFromID(boxRef.associatedDogID);
		if (currentHeaderType == HeaderType.DOGS)
		{
			UpdateTraits(saveableDogFromID.brain.personality);
			CreateRotationDog(saveableDogFromID);
			activeDogName.text = saveableDogFromID.dogName;
			activeDogAge.text = DoggyBrain.GetReadableNameForDogAge(saveableDogFromID.brain.dogAge);
			if (saveableDogFromID.inWorld && !saveableDogFromID.inCocoon)
			{
				DoggyBrain component = dogRegRef.GetDogFromID(saveableDogFromID.dogID).GetComponent<DoggyBrain>();
				activeDogAgeNumber.text = DoggyBrain.GetReadableMinutesAlive(component.GetCurrentDogAge(), component.GetCurrentDogAgeProgress());
			}
			else
			{
				activeDogAgeNumber.text = DoggyBrain.GetReadableMinutesAlive(saveableDogFromID.brain.dogAge, saveableDogFromID.brain.dogAgeProgress);
			}
			if (saveableDogFromID.isGhost)
			{
				string gUI_AGE_MOD_GHOST = ScriptLocalization.GUI.GUI_AGE_MOD_GHOST;
				int length = gUI_AGE_MOD_GHOST.IndexOf("[");
				int num = gUI_AGE_MOD_GHOST.IndexOf("]");
				activeDogAge.text = gUI_AGE_MOD_GHOST.Substring(0, length) + activeDogAge.text + gUI_AGE_MOD_GHOST.Substring(num + 1);
				activeDogAgeNumber.text = "";
				activeDogAgeNumber.gameObject.SetActive(value: false);
			}
			else
			{
				activeDogAgeNumber.gameObject.SetActive(value: true);
			}
			renameButtonHolder.SetActive(value: true);
			releaseButtonHolder.SetActive(value: true);
			destroyCoreButtonHolder.SetActive(value: false);
			EnableReleaseButton();
		}
		else
		{
			if (associatedCore != null)
			{
				UpdateTraits(associatedCore.dogPersonality);
				CreateRotationDog(associatedCore);
				activeDogName.text = associatedCore.dogName;
				activeDogAge.text = DoggyBrain.GetReadableNameForDogAge(associatedCore.dogAge);
			}
			else if (associatedCoreObject != null)
			{
				UpdateTraits(associatedCoreObject.dogPersonality);
				CreateRotationDog(associatedCoreObject);
				activeDogName.text = associatedCoreObject.dogName;
				activeDogAge.text = DoggyBrain.GetReadableNameForDogAge(associatedCoreObject.dogAge);
			}
			else if (associatedMemorial != null)
			{
				UpdateTraits(associatedMemorial.dogPersonality);
				CreateRotationDog(associatedMemorial);
				activeDogName.text = associatedMemorial.dogName;
				activeDogAge.text = DoggyBrain.GetReadableNameForDogAge(associatedMemorial.dogAge);
			}
			renameButtonHolder.SetActive(value: false);
			releaseButtonHolder.SetActive(value: false);
			destroyCoreButtonHolder.SetActive(value: true);
			activeDogAgeNumber.gameObject.SetActive(value: false);
		}
		if (TutorialController.IsTutorialActive() || currentHeaderType == HeaderType.CORES)
		{
			importButtonHolder.SetActive(value: false);
			exportButtonHolder.SetActive(value: false);
		}
		else
		{
			importButtonHolder.SetActive(value: true);
			exportButtonHolder.SetActive(value: true);
		}
		if (!TutorialController.IsTutorialActive())
		{
			geneticInspectionButton.interactable = true;
		}
		dogAgeScaleEffect.RequestScaleIn();
		dogNameScaleEffect.RequestScaleIn();
		dogAgeNumberScaleEffect.RequestScaleIn();
		dogLabelHolder.SetActive(value: true);
		dogLabelChooser.SetActive(value: false);
		DogLabelType dogLabelType = DogLabelType.NONE;
		if (saveableDogFromID != null)
		{
			dogLabelType = saveableDogFromID.labelType;
			if (saveableDogFromID.favorite && dogLabelType == DogLabelType.NONE)
			{
				dogLabelType = DogLabelType.STAR;
			}
		}
		if (currentHeaderType == HeaderType.CORES)
		{
			if (associatedCore != null)
			{
				dogLabelType = associatedCore.labelType;
			}
			else if (associatedCoreObject != null)
			{
				dogLabelType = associatedCoreObject.labelType;
			}
			else if (associatedMemorial != null)
			{
				dogLabelType = associatedMemorial.labelType;
			}
		}
		if (dogLabelType == DogLabelType.NONE)
		{
			activeLabelSymbol.sprite = null;
			activeLabelSymbol.gameObject.SetActive(value: false);
		}
		else
		{
			activeLabelSymbol.gameObject.SetActive(value: true);
			activeLabelSymbol.sprite = dogRegRef.GetSpriteForLabel(dogLabelType);
		}
		if (boxRef.boxType == BoxType.PENS)
		{
			UpdateUIForInWorldDog();
			lastSelectionType = SelectionType.PENS;
		}
		else
		{
			UpdateUIForInStorageDog();
			lastSelectionType = SelectionType.STORAGE;
		}
		if (currentHeaderType == HeaderType.DOGS && dogRegRef.GetNumberOfOwnedAndLoadingDogsMinusGhosts() >= dogRegRef.GetMaxDogs())
		{
			DisableBringOutButton();
		}
		if (currentHeaderType == HeaderType.CORES)
		{
			if (associatedCoreObject != null || associatedCore != null)
			{
				activeDogCoreIcon.SetActive(value: true);
				activeDogCocoonIcon.SetActive(value: false);
				activeDogMemorialIcon.SetActive(value: false);
			}
			else if (associatedMemorial != null)
			{
				activeDogCoreIcon.SetActive(value: false);
				activeDogCocoonIcon.SetActive(value: false);
				activeDogMemorialIcon.SetActive(value: true);
			}
		}
		else if (saveableDogFromID != null)
		{
			activeDogCoreIcon.SetActive(value: false);
			activeDogMemorialIcon.SetActive(value: false);
			activeDogCocoonIcon.SetActive(saveableDogFromID.inCocoon);
		}
	}

	public void DeselectActiveBox()
	{
		dogRotationBouncer.StopBounce();
		dogAgeScaleEffect.EndCurrentScale();
		dogNameScaleEffect.EndCurrentScale();
		dogAgeNumberScaleEffect.EndCurrentScale();
		activeDogAge.text = "";
		activeDogName.text = "";
		activeDogAgeNumber.text = "";
		dogLabelHolder.SetActive(value: false);
		activeDogCoreIcon.SetActive(value: false);
		renameButtonHolder.SetActive(value: false);
		releaseButtonHolder.SetActive(value: false);
		activeDogCocoonIcon.SetActive(value: false);
		destroyCoreButtonHolder.SetActive(value: false);
		UpdateTraits(null);
		UpdateUIForNoDog();
		DisableExportButton();
		if (currentHeaderType == HeaderType.CORES)
		{
			importButtonHolder.SetActive(value: false);
			exportButtonHolder.SetActive(value: false);
		}
		else
		{
			importButtonHolder.SetActive(value: true);
			exportButtonHolder.SetActive(value: true);
		}
		geneticInspectionButton.interactable = false;
		if (currentlyRotatedDog != null)
		{
			Object.Destroy(currentlyRotatedDog);
			currentlyRotatedDog = null;
		}
		if (currentlySelectedBox != null)
		{
			currentlySelectedBox.SetBoxDeselected();
			currentlySelectedBox = null;
		}
	}

	private void UpdateTraits(SaveableDogPersonality personalityRef)
	{
		for (int i = 0; i < allTraitIcons.Count; i++)
		{
			allTraitIcons[i].transform.parent.GetComponent<InchwormBounce>().StopBounce();
		}
		OnTraitHoverStop();
		SetTraitForIndex(0, activeValue: false);
		SetTraitForIndex(1, activeValue: false);
		SetTraitForIndex(2, activeValue: false);
		SetTraitForIndex(3, activeValue: false);
		SetTraitForIndex(4, activeValue: false);
		SetTraitForIndex(5, activeValue: false);
		if (personalityRef != null)
		{
			int num = 0;
			if (personalityRef.foodPersonality != FoodPersonalityType.STANDARD)
			{
				SetFoodPersonalityTraitForIndex(num, personalityRef.foodPersonality);
				num++;
			}
			if (personalityRef.socialPersonality != SocialPersonalityType.STANDARD)
			{
				SetSocialPersonalityTraitForIndex(num, personalityRef.socialPersonality);
				num++;
			}
			if (personalityRef.energyPersonality != EnergyPersonalityType.STANDARD)
			{
				SetEnergyPersonalityTraitForIndex(num, personalityRef.energyPersonality);
				num++;
			}
			if (personalityRef.mischiefPersonality != MischiefPersonalityType.STANDARD)
			{
				SetMischiefPersonalityTraitForIndex(num, personalityRef.mischiefPersonality);
				num++;
			}
			if (personalityRef.nicenessPersonality != NicenessPersonalityType.STANDARD)
			{
				SetNicenessPersonalityTraitForIndex(num, personalityRef.nicenessPersonality);
				num++;
			}
			if (personalityRef.pettablePersonality != PettablePersonalityType.LIKES_PETTING)
			{
				SetPettablePersonalityTraitForIndex(num, personalityRef.pettablePersonality);
				num++;
			}
			if (personalityRef.loudnessPersonality != LoudnessPersonalityType.STANDARD)
			{
				SetLoudnessPersonalityTraitForIndex(num, personalityRef.loudnessPersonality);
				num++;
			}
			for (int j = 0; j < num; j++)
			{
				InchwormBounce component = allTraitIcons[j].transform.parent.GetComponent<InchwormBounce>();
				component.bounceStartDelay = (float)j * traitScaleTimeOffset;
				component.RequestBounce();
			}
		}
	}

	private DogPersonalityTrait GetTraitInfoForIndex(int index)
	{
		if (index >= allTraitIcons.Count)
		{
			Debug.LogError("No trait for index: " + index);
			return null;
		}
		return allTraitIcons[index].transform.parent.gameObject.GetComponent<DogPersonalityTrait>();
	}

	private void SetTraitForIndex(int index, bool activeValue, string traitName = "", string traitDescription = "", Sprite icon = null)
	{
		Image image2 = allTraitIcons[index];
		if (image2 == null)
		{
			Debug.LogError("Attempting to access a trait for index " + index + " but no UI exists that maps to that index.");
			return;
		}
		GameObject gameObject = image2.transform.parent.gameObject;
		gameObject.SetActive(activeValue);
		image2.sprite = icon;
		image2.enabled = icon != null;
		gameObject.GetComponent<DogPersonalityTrait>().SetTrait(traitName, traitDescription);
	}

	private void UpdateUIForInWorldDog()
	{
		EnableStoreButton();
		DisableBringOutButton();
		if (currentHeaderType == HeaderType.DOGS && dogRegRef.GetSaveableDogFromID(currentlySelectedBox.associatedDogID).isGhost)
		{
			DisableStoreButton();
			EnableBanishButton();
		}
		else
		{
			DisableBanishButton();
		}
		if (currentHeaderType == HeaderType.CORES && currentlySelectedBox.associatedMemorial != null)
		{
			removeCoreButtonHolder.SetActive(value: true);
		}
		else
		{
			removeCoreButtonHolder.SetActive(value: false);
		}
	}

	private void UpdateUIForInStorageDog()
	{
		DisableStoreButton();
		DisableBanishButton();
		EnableBringOutButton();
		removeCoreButtonHolder.SetActive(value: false);
	}

	private void UpdateUIForNoDog()
	{
		DisableStoreButton();
		DisableBanishButton();
		DisableBringOutButton();
		removeCoreButtonHolder.SetActive(value: false);
		rotationCircleBacking.color = Color.white;
	}

	private void EnableExportButton()
	{
		exportButtonRef.interactable = true;
		exportButtonText.color = enabledButtonTextColor;
		exportButtonBacking.color = enabledButtonBackingColor;
	}

	private void DisableExportButton()
	{
		exportButtonRef.interactable = false;
		exportButtonText.color = disabledButtonTextColor;
		exportButtonBacking.color = disabledButtonBackingColor;
	}

	private void EnableStoreButton()
	{
		storeButton.interactable = true;
		storeDogHighlightHolder.SetActive(value: true);
		storeButtonText.color = enabledButtonTextColor;
		storeButtonBacking.color = enabledButtonBackingColor;
		rotationCircleBacking.color = storeBackingColor;
	}

	private void DisableStoreButton()
	{
		storeButton.interactable = false;
		storeDogHighlightHolder.SetActive(value: false);
		storeButtonText.color = disabledButtonTextColor;
		storeButtonBacking.color = disabledButtonBackingColor;
	}

	private void EnableBringOutButton()
	{
		bringOutButton.interactable = true;
		bringOutDogHighlightHolder.SetActive(value: true);
		rotationCircleBacking.color = bringOutBackingColor;
		bringOutButtonText.color = enabledButtonTextColor;
		bringOutButtonBacking.color = enabledButtonBackingColor;
	}

	private void DisableBringOutButton()
	{
		bringOutButton.interactable = false;
		bringOutDogHighlightHolder.SetActive(value: false);
		bringOutButtonText.color = disabledButtonTextColor;
		bringOutButtonBacking.color = disabledButtonBackingColor;
	}

	private void EnableReleaseButton()
	{
		if (!TutorialController.IsTutorialActive())
		{
			releaseButtonHolder.SetActive(value: true);
		}
		else
		{
			releaseButtonHolder.SetActive(value: false);
		}
	}

	private void DisableReleaseButton()
	{
		releaseButtonHolder.SetActive(value: false);
	}

	private void EnableBanishButton()
	{
		DisableReleaseButton();
		banishButtonHolder.SetActive(value: true);
	}

	private void DisableBanishButton()
	{
		banishButtonHolder.SetActive(value: false);
	}

	private void CreateRotationDog(DogMemorial am)
	{
		if (isLoadingDog)
		{
			needsDogRefresh = true;
			return;
		}
		isLoadingDog = true;
		loadingDogText.SetActive(value: true);
		dogRegRef.RequestNewDog(dogRotationTransform.position, dogRotationTransform.rotation, am.dogGene, null, manualDog: false, dogProfile: am.dogProfile, callback: OnNewDogCreated, playerOwned: false, useBaseGeneWithoutMutation: false, timeslice: true, forceCacheThumbnails: false, dummyDog: false, customDogAge: am.dogAge, customDogAgeProgress: 0f);
	}

	private void CreateRotationDog(SaveableDog sd)
	{
		if (isLoadingDog)
		{
			needsDogRefresh = true;
			return;
		}
		isLoadingDog = true;
		loadingDogText.SetActive(value: true);
		dogRegRef.RequestNewDog(dogRotationTransform.position, dogRotationTransform.rotation, sd.dogGene, null, manualDog: false, dogProfile: sd.dogProfile, callback: OnNewDogCreated, playerOwned: false, useBaseGeneWithoutMutation: false, timeslice: true, forceCacheThumbnails: false, dummyDog: false, customDogAge: sd.brain.dogAge, customDogAgeProgress: sd.brain.dogAgeProgress, traitsAllowed: true, useTemporaryID: false, customDogPersonality: null, customFloraPool: null, respectMaxDogs: true, isGhost: sd.isGhost);
	}

	private void CreateRotationDog(SaveableDogCore sc)
	{
		if (isLoadingDog)
		{
			needsDogRefresh = true;
			return;
		}
		isLoadingDog = true;
		loadingDogText.SetActive(value: true);
		dogRegRef.RequestNewDog(dogRotationTransform.position, dogRotationTransform.rotation, sc.dogGene, null, manualDog: false, dogProfile: sc.dogProfile, callback: OnNewDogCreated, playerOwned: false, useBaseGeneWithoutMutation: false, timeslice: true, forceCacheThumbnails: false, dummyDog: false, customDogAge: sc.dogAge, customDogAgeProgress: 0f);
	}

	private void CreateRotationDog(DogCore ac)
	{
		if (isLoadingDog)
		{
			needsDogRefresh = true;
			return;
		}
		isLoadingDog = true;
		loadingDogText.SetActive(value: true);
		dogRegRef.RequestNewDog(dogRotationTransform.position, dogRotationTransform.rotation, ac.dogGene, null, manualDog: false, dogProfile: ac.dogProfile, callback: OnNewDogCreated, playerOwned: false, useBaseGeneWithoutMutation: false, timeslice: true, forceCacheThumbnails: false, dummyDog: false, customDogAge: ac.dogAge, customDogAgeProgress: 0f);
	}

	private void OnNewDogCreated(GameObject dog)
	{
		if (GUIClosed)
		{
			Object.Destroy(dog);
			return;
		}
		isLoadingDog = false;
		if (needsDogRefresh || currentlySelectedBox == null)
		{
			Object.Destroy(dog);
			needsDogRefresh = false;
			if (currentlySelectedBox != null)
			{
				if (currentHeaderType == HeaderType.DOGS)
				{
					CreateRotationDog(dogRegRef.GetSaveableDogFromID(currentlySelectedBox.associatedDogID));
				}
				else if (currentlySelectedBox.associatedCore != null)
				{
					CreateRotationDog(currentlySelectedBox.associatedCore);
				}
				else if (currentlySelectedBox.associatedCoreObject != null)
				{
					CreateRotationDog(currentlySelectedBox.associatedCoreObject);
				}
				else if (currentlySelectedBox.associatedMemorial != null)
				{
					CreateRotationDog(currentlySelectedBox.associatedMemorial);
				}
			}
			else
			{
				loadingDogText.SetActive(value: false);
			}
		}
		else
		{
			currentlyRotatedDog = dog;
			loadingDogText.SetActive(value: false);
			dogRotationBouncer.RequestBounce();
			dogRegRef.MakeDogSuitableForUIDisplay(dog);
			AudioController.Play(storageSelectDogSound);
			dog.transform.SetParent(dogRotationTransform, worldPositionStays: true);
		}
	}

	private void SetFoodPersonalityTraitForIndex(int index, FoodPersonalityType trait)
	{
		switch (trait)
		{
		case FoodPersonalityType.FOOD_OBSESSED:
			SetTraitForIndex(index, activeValue: true, ScriptLocalization.GUI.GUI_TRAIT_LIKESFOOD_NAME, ScriptLocalization.GUI.GUI_TRAIT_LIKESFOOD_DESC, thumbnailRef.gluttonTraitIcon);
			break;
		case FoodPersonalityType.FOOD_AVERSE:
			SetTraitForIndex(index, activeValue: true, ScriptLocalization.GUI.GUI_TRAIT_DISLIKESFOOD_NAME, ScriptLocalization.GUI.GUI_TRAIT_DISLIKESFOOD_DESC, thumbnailRef.foodAverseTraitIcon);
			break;
		}
	}

	private void SetSocialPersonalityTraitForIndex(int index, SocialPersonalityType trait)
	{
		switch (trait)
		{
		case SocialPersonalityType.SOCIAL:
			SetTraitForIndex(index, activeValue: true, ScriptLocalization.GUI.GUI_TRAIT_LIKESSOCIAL_NAME, ScriptLocalization.GUI.GUI_TRAIT_LIKESSOCIAL_DESC, thumbnailRef.socialTraitIcon);
			break;
		case SocialPersonalityType.ALOOF:
			SetTraitForIndex(index, activeValue: true, ScriptLocalization.GUI.GUI_TRAIT_DISLIKESSOCIAL_NAME, ScriptLocalization.GUI.GUI_TRAIT_DISLIKESSOCIAL_DESC, thumbnailRef.aloofTraitIcon);
			break;
		}
	}

	private void SetEnergyPersonalityTraitForIndex(int index, EnergyPersonalityType trait)
	{
		switch (trait)
		{
		case EnergyPersonalityType.LAYABOUT:
			SetTraitForIndex(index, activeValue: true, ScriptLocalization.GUI.GUI_TRAIT_LIKESSLEEP_NAME, ScriptLocalization.GUI.GUI_TRAIT_LIKESSLEEP_DESC, thumbnailRef.layaboutTraitIcon);
			break;
		case EnergyPersonalityType.GOOF:
			SetTraitForIndex(index, activeValue: true, ScriptLocalization.GUI.GUI_TRAIT_DISLIKESSLEEP_NAME, ScriptLocalization.GUI.GUI_TRAIT_DISLIKESSLEEP_DESC, thumbnailRef.highEnergyTraitIcon);
			break;
		}
	}

	private void SetMischiefPersonalityTraitForIndex(int index, MischiefPersonalityType trait)
	{
		switch (trait)
		{
		case MischiefPersonalityType.POLITE:
			SetTraitForIndex(index, activeValue: true, ScriptLocalization.GUI.GUI_TRAIT_DISLIKESMISCHIEF_NAME, ScriptLocalization.GUI.GUI_TRAIT_DISLIKESMISCHIEF_DESC, thumbnailRef.politeTraitIcon);
			break;
		case MischiefPersonalityType.MISCHEVIOUS:
			SetTraitForIndex(index, activeValue: true, ScriptLocalization.GUI.GUI_TRAIT_LIKESMISCHIEF_NAME, ScriptLocalization.GUI.GUI_TRAIT_LIKESMISCHIEF_DESC, thumbnailRef.rudeTraitIcon);
			break;
		}
	}

	private void SetNicenessPersonalityTraitForIndex(int index, NicenessPersonalityType trait)
	{
		switch (trait)
		{
		case NicenessPersonalityType.NICE:
			SetTraitForIndex(index, activeValue: true, ScriptLocalization.GUI.GUI_TRAIT_NICE_NAME, ScriptLocalization.GUI.GUI_TRAIT_NICE_DESC, thumbnailRef.peacefulTraitIcon);
			break;
		case NicenessPersonalityType.MEAN:
			SetTraitForIndex(index, activeValue: true, ScriptLocalization.GUI.GUI_TRAIT_MEAN_NAME, ScriptLocalization.GUI.GUI_TRAIT_MEAN_DESC, thumbnailRef.antagonisticTraitIcon);
			break;
		}
	}

	private void SetPettablePersonalityTraitForIndex(int index, PettablePersonalityType trait)
	{
		if (trait == PettablePersonalityType.DISLIKES_PETTING)
		{
			SetTraitForIndex(index, activeValue: true, ScriptLocalization.GUI.GUI_TRAIT_UNPETTABLE_NAME, ScriptLocalization.GUI.GUI_TRAIT_UNPETTABLE_DESC, thumbnailRef.unpettableTraitIcon);
		}
	}

	private void SetLoudnessPersonalityTraitForIndex(int index, LoudnessPersonalityType trait)
	{
		switch (trait)
		{
		case LoudnessPersonalityType.LOUD:
			SetTraitForIndex(index, activeValue: true, ScriptLocalization.GUI.GUI_TRAIT_LOUD_NAME, ScriptLocalization.GUI.GUI_TRAIT_LOUD_DESC, thumbnailRef.loudTraitIcon);
			break;
		case LoudnessPersonalityType.QUIET:
			SetTraitForIndex(index, activeValue: true, ScriptLocalization.GUI.GUI_TRAIT_QUIET_NAME, ScriptLocalization.GUI.GUI_TRAIT_QUIET_DESC, thumbnailRef.quietTraitIcon);
			break;
		}
	}
}
