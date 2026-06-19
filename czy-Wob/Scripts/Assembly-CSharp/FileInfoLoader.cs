using System;
using System.Collections;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FileInfoLoader : MonoBehaviour
{
	public GameObject infoPane;

	public GameObject greyOutObj;

	public GameObject trashPane;

	public GameObject defaultPane;

	public GameObject newGamePane;

	public GameObject baseContent;

	public GameObject corruptedFilePane;

	public TextMeshProUGUI corruptedFileInfoText;

	public CoreButtonUnityGUI restoreFileButton;

	public Image baseContentBone;

	public TextMeshProUGUI fileNameText;

	public CoreButtonUnityGUI playButton;

	public CoreButtonUnityGUI trashButton;

	public CoreButtonUnityGUI standardBackButton;

	public CoreButtonUnityGUI deleteBackButton;

	public CoreButtonUnityGUI deleteCancelButton;

	public CoreButtonUnityGUI deleteConfirmButton;

	public NameInput newGameNameInput;

	public CoreButtonUnityGUI newGameBackButton;

	public CoreButtonUnityGUI newGamePlayButton;

	public TextMeshProUGUI playTimeText;

	public TextMeshProUGUI numberOfDogsText;

	private Segment currentEase;

	private Inchworm.EaseStyle paneInEaseStyle = Inchworm.EaseStyle.OutBack;

	private Inchworm.EaseStyle paneOutEaseStyle = Inchworm.EaseStyle.InBack;

	private Vector3 easeDist = new Vector3(0f, 1500f, 0f);

	private float slideTime = 0.35f;

	private float slideOutTime = 0.2f;

	private string associatedFile;

	private Sprite associatedSprite;

	private bool fileIsCorrupted;

	private string panelInSound = "mainMenu_panelIn";

	private string panelOutSound = "mainMenu_panelOut";

	private string fileDeleteSound = "mainMenu_confirmDeleteFile";

	private Coroutine currentAlphaRoutine;

	private ScalableUIContainer.LoadCallback callback;

	private bool paneLoaded;

	private bool trashPaneLoaded;

	private bool travelInitated;

	private BonesLoader bonesRef;

	private Inchworm inchwormRef;

	private SaveLoadManager saveRef;

	private void Awake()
	{
		paneLoaded = false;
		trashPaneLoaded = false;
		travelInitated = false;
		infoPane.SetActive(value: false);
		greyOutObj.SetActive(value: false);
	}

	private void Update()
	{
		if (GameControls.actions.CloseMenu.WasPressed && paneLoaded && !travelInitated)
		{
			if (trashPaneLoaded)
			{
				UnloadTrashPane();
			}
			else
			{
				HideFileInfo();
			}
		}
	}

	public void SetBonesRef(BonesLoader newRef)
	{
		bonesRef = newRef;
		saveRef = ObjectRegistration.GetRegistrationScript().saveLoadManager;
		inchwormRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
	}

	public void LoadSelectedFile()
	{
		travelInitated = true;
		LockStandardInteractables();
		bonesRef.RemoveAllBonesButtons();
		saveRef.SetActiveFile(associatedFile);
		ObjectRegistration.GetRegistrationScript().GetGlobalComponent<SceneTransition>(GlobalObject.SCENE_TRANSITION).TransitionToScene(SaveLoadManager.homeSceneName);
	}

	public void DeleteSelectedFile()
	{
		LockTrashInteractables();
		saveRef.DeleteSaveFile(associatedFile);
		UnloadTrashAndDefaultPane();
		bonesRef.Refresh();
		AudioController.Play(fileDeleteSound);
	}

	public void LoadTrashPane()
	{
		paneLoaded = false;
		LockStandardInteractables();
		CancelCurrentEases();
		CallCallback();
		infoPane.transform.localPosition = Vector3.zero;
		currentEase = inchwormRef.RequestEase(infoPane, easeDist, slideOutTime, adjustStartingPos: false, paneOutEaseStyle, Inchworm.EaseType.Position, PaneSwitchTrashCallbackMid, Inchworm.EasePriority.Normal, keepSameParent: true);
		AudioController.Play(panelOutSound);
	}

	private void PaneSwitchTrashCallbackMid()
	{
		CancelCurrentEases();
		trashPane.SetActive(value: true);
		defaultPane.SetActive(value: false);
		corruptedFilePane.SetActive(value: false);
		UnlockTrashInteractables();
		infoPane.transform.localPosition = Vector3.zero;
		Vector3 position = infoPane.transform.position;
		infoPane.transform.localPosition = easeDist;
		position -= infoPane.transform.position;
		currentEase = inchwormRef.RequestEase(infoPane, position, slideTime, adjustStartingPos: false, paneInEaseStyle, Inchworm.EaseType.Position, TrashPaneLoaded, Inchworm.EasePriority.Normal, keepSameParent: true);
		AudioController.Play(panelInSound);
	}

	private void TrashPaneLoaded()
	{
		paneLoaded = true;
		trashPaneLoaded = true;
		CancelCurrentEases();
	}

	public void UnloadTrashAndDefaultPane()
	{
		paneLoaded = false;
		trashPaneLoaded = false;
		CancelCurrentEases();
		CallCallback();
		LockTrashInteractables();
		if (currentAlphaRoutine != null)
		{
			StopCoroutine(currentAlphaRoutine);
			currentAlphaRoutine = null;
		}
		currentAlphaRoutine = StartCoroutine(AlphaEaseRoutine(0f));
		infoPane.transform.localPosition = Vector3.zero;
		currentEase = inchwormRef.RequestEase(infoPane, easeDist, slideOutTime, adjustStartingPos: false, paneOutEaseStyle, Inchworm.EaseType.Position, TrashAndDefaultPaneUnloadCallback, Inchworm.EasePriority.Normal, keepSameParent: true);
		AudioController.Play(panelOutSound);
	}

	public void TrashAndDefaultPaneUnloadCallback()
	{
		paneLoaded = false;
		trashPaneLoaded = false;
		CancelCurrentEases();
		trashPane.SetActive(value: false);
		greyOutObj.SetActive(value: false);
		defaultPane.SetActive(value: false);
		corruptedFilePane.SetActive(value: false);
		bonesRef.OnFileInfoHidden();
	}

	public void UnloadTrashPane()
	{
		paneLoaded = false;
		trashPaneLoaded = false;
		CancelCurrentEases();
		CallCallback();
		LockTrashInteractables();
		infoPane.transform.localPosition = Vector3.zero;
		currentEase = inchwormRef.RequestEase(infoPane, easeDist, slideOutTime, adjustStartingPos: false, paneOutEaseStyle, Inchworm.EaseType.Position, TrashPaneUnloadMidCallback, Inchworm.EasePriority.Normal, keepSameParent: true);
		AudioController.Play(panelOutSound);
	}

	private void TrashPaneUnloadMidCallback()
	{
		CancelCurrentEases();
		trashPane.SetActive(value: false);
		if (fileIsCorrupted)
		{
			defaultPane.SetActive(value: false);
			corruptedFilePane.SetActive(value: true);
		}
		else
		{
			defaultPane.SetActive(value: true);
			corruptedFilePane.SetActive(value: false);
		}
		UnlockStandardInteractables();
		infoPane.transform.localPosition = Vector3.zero;
		Vector3 position = infoPane.transform.position;
		infoPane.transform.localPosition = easeDist;
		position -= infoPane.transform.position;
		currentEase = inchwormRef.RequestEase(infoPane, position, slideTime, adjustStartingPos: false, paneInEaseStyle, Inchworm.EaseType.Position, TrashPaneUnloadedCallback, Inchworm.EasePriority.Normal, keepSameParent: true);
		AudioController.Play(panelInSound);
	}

	private void TrashPaneUnloadedCallback()
	{
		paneLoaded = true;
		trashPaneLoaded = false;
		CancelCurrentEases();
	}

	public void Load(ScalableUIContainer.LoadCallback loadCallback)
	{
		if (associatedFile == null)
		{
			LoadNewFilePane(loadCallback);
		}
		else
		{
			LoadFileInfoPane(loadCallback);
		}
	}

	public void SetAssociatedFile(string newFile, Sprite s)
	{
		associatedFile = newFile;
		associatedSprite = s;
		if (associatedFile == null || saveRef.IsNewSave(newFile))
		{
			fileNameText.text = "";
		}
		if (associatedFile == null)
		{
			return;
		}
		string fileName = "";
		string playTime = "";
		string numberOfDogs = "";
		bool fileInfoForSaveFile = saveRef.GetFileInfoForSaveFile(newFile, ref fileName, ref numberOfDogs, ref playTime);
		fileNameText.text = fileName;
		playTimeText.text = playTime;
		numberOfDogsText.text = numberOfDogs;
		if (!fileInfoForSaveFile)
		{
			fileIsCorrupted = true;
			defaultPane.SetActive(value: false);
			corruptedFilePane.SetActive(value: true);
			corruptedFileInfoText.text = ScriptLocalization.GUI.GUI_FILE_CORRUPTEDINFO;
			if (SaveLoadManager.GetAllBackupsForSaveFilePath(newFile).Count == 0)
			{
				restoreFileButton.transform.parent.gameObject.SetActive(value: false);
				TextMeshProUGUI textMeshProUGUI = corruptedFileInfoText;
				textMeshProUGUI.text = textMeshProUGUI.text + " " + ScriptLocalization.GUI.GUI_FILE_CORRUPTED_NOBACKUP;
			}
			else
			{
				restoreFileButton.transform.parent.gameObject.SetActive(value: true);
				TextMeshProUGUI textMeshProUGUI2 = corruptedFileInfoText;
				textMeshProUGUI2.text = textMeshProUGUI2.text + " " + ScriptLocalization.GUI.GUI_FILE_CORRUPTED_BACKUP;
			}
		}
		else
		{
			fileIsCorrupted = false;
		}
	}

	public void RestoreAssociatedFileFromBackup()
	{
		LockStandardInteractables();
		try
		{
			if (!SaveLoadManager.RestoreFileFromMostRecentValidBackup(associatedFile))
			{
				Debug.LogError("Failed to restore file from backup.");
			}
		}
		catch (Exception message)
		{
			Debug.LogError(message);
		}
		UnloadTrashAndDefaultPane();
		bonesRef.Refresh();
	}

	private void UnlockStandardInteractables()
	{
		playButton.interactable = true;
		trashButton.interactable = true;
		restoreFileButton.interactable = true;
		standardBackButton.interactable = true;
	}

	private void LockStandardInteractables()
	{
		playButton.interactable = false;
		trashButton.interactable = false;
		restoreFileButton.interactable = false;
		standardBackButton.interactable = false;
	}

	private void UnlockNewGameInteractables()
	{
		newGameNameInput.Unlock();
		newGameBackButton.interactable = true;
		newGamePlayButton.interactable = true;
		EventSystem.current.SetSelectedGameObject(newGameNameInput.inputRef.gameObject, null);
		newGameNameInput.inputRef.ActivateInputField();
	}

	private void LockNewGameInteractables()
	{
		newGameNameInput.Lock();
		newGameBackButton.interactable = false;
		newGamePlayButton.interactable = false;
	}

	private void UnlockTrashInteractables()
	{
		deleteBackButton.interactable = true;
		deleteCancelButton.interactable = true;
		deleteConfirmButton.interactable = true;
	}

	private void LockTrashInteractables()
	{
		deleteBackButton.interactable = false;
		deleteCancelButton.interactable = false;
		deleteConfirmButton.interactable = false;
	}

	private void LoadNewFilePane(ScalableUIContainer.LoadCallback loadCallback = null)
	{
		trashPane.SetActive(value: false);
		newGamePane.SetActive(value: true);
		defaultPane.SetActive(value: false);
		baseContent.SetActive(value: false);
		corruptedFilePane.SetActive(value: false);
		LoadPaneBase(loadCallback);
		UnlockNewGameInteractables();
	}

	private void LoadFileInfoPane(ScalableUIContainer.LoadCallback loadCallback = null)
	{
		trashPane.SetActive(value: false);
		baseContent.SetActive(value: true);
		newGamePane.SetActive(value: false);
		if (fileIsCorrupted)
		{
			defaultPane.SetActive(value: false);
			corruptedFilePane.SetActive(value: true);
		}
		else
		{
			defaultPane.SetActive(value: true);
			corruptedFilePane.SetActive(value: false);
		}
		baseContentBone.sprite = associatedSprite;
		LoadPaneBase(loadCallback);
		UnlockStandardInteractables();
	}

	private void LoadPaneBase(ScalableUIContainer.LoadCallback loadCallback = null)
	{
		paneLoaded = false;
		CancelCurrentEases();
		CallCallback();
		callback = loadCallback;
		infoPane.SetActive(value: true);
		greyOutObj.SetActive(value: true);
		greyOutObj.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
		if (currentAlphaRoutine != null)
		{
			StopCoroutine(currentAlphaRoutine);
			currentAlphaRoutine = null;
		}
		currentAlphaRoutine = StartCoroutine(AlphaEaseRoutine(1f));
		infoPane.transform.localPosition = Vector3.zero;
		Vector3 position = infoPane.transform.position;
		infoPane.transform.localPosition = easeDist;
		position -= infoPane.transform.position;
		currentEase = inchwormRef.RequestEase(infoPane, position, slideTime, adjustStartingPos: false, paneInEaseStyle, Inchworm.EaseType.Position, OnSelfLoadComplete, Inchworm.EasePriority.Normal, keepSameParent: true);
		AudioController.Play(panelInSound);
	}

	private void OnSelfLoadComplete()
	{
		CancelCurrentEases();
		currentEase = null;
		CallCallback();
		paneLoaded = true;
	}

	private void OnUnloadComplete()
	{
		paneLoaded = false;
		CancelCurrentEases();
		infoPane.SetActive(value: false);
		greyOutObj.SetActive(value: false);
		currentEase = null;
		CallCallback();
		bonesRef.OnFileInfoHidden();
	}

	public void HideFileInfo()
	{
		paneLoaded = false;
		LockNewGameInteractables();
		LockStandardInteractables();
		CancelCurrentEases();
		CallCallback();
		if (currentAlphaRoutine != null)
		{
			StopCoroutine(currentAlphaRoutine);
			currentAlphaRoutine = null;
		}
		currentAlphaRoutine = StartCoroutine(AlphaEaseRoutine(0f));
		currentEase = inchwormRef.RequestEase(infoPane, easeDist, slideOutTime, adjustStartingPos: false, paneOutEaseStyle, Inchworm.EaseType.Position, OnUnloadComplete, Inchworm.EasePriority.Normal, keepSameParent: true);
		AudioController.Play(panelOutSound);
	}

	private IEnumerator AlphaEaseRoutine(float newVal)
	{
		Image r = greyOutObj.GetComponent<Image>();
		float startAlpha = r.color.a;
		float currentTime = 0f;
		for (float neededTime = slideTime; currentTime <= neededTime; currentTime += Time.deltaTime)
		{
			r.color = new Color(1f, 1f, 1f, startAlpha + (newVal - startAlpha) * (currentTime / neededTime));
			yield return new WaitForEndOfFrame();
		}
		r.color = new Color(1f, 1f, 1f, newVal);
		currentAlphaRoutine = null;
	}

	private void CancelCurrentEases()
	{
		if (currentEase != null)
		{
			inchwormRef.CancelAndFinishEase(ref currentEase);
			currentEase = null;
		}
	}

	public void Unload(ScalableUIContainer.LoadCallback unloadCallback)
	{
		CancelCurrentEases();
		callback = unloadCallback;
		OnUnloadComplete();
	}

	private void CallCallback()
	{
		if (callback != null)
		{
			callback();
			callback = null;
		}
	}
}
