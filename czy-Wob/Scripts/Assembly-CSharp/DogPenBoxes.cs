using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DogPenBoxes : BoxList
{
	public DogPenPane dogPenPaneRef;

	public GameObject dogPreviewHolder;

	public GameObject storeButton;

	public GameObject bringOutButton;

	public GameObject copyWindow;

	public GameObject importWindow;

	public GameObject importFailureWindow;

	public GameObject importButton;

	public GameObject exportButton;

	public GameObject exportDogGUI;

	public GameObject importDogGUI;

	public TextMeshPro exportDogGeneText;

	public TextMeshPro importDogGeneText;

	public CoreButton importConfirmButton;

	public InventoryItem cocoonItem;

	public List<CoreButton> standardButtons = new List<CoreButton>();

	private DogHome dogHomeRef;

	private DogRegistration dogRegRef;

	public override void Preload()
	{
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		dogHomeRef = registrationScript.GetGlobalComponent<DogHome>(GlobalObject.DOG_HOME);
		dogRegRef = registrationScript.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		boxesPerRow = 7;
		rowsPerScreen = 2;
		boxOffsetY = 2.6f;
		boxOffsetX = 2.6f;
		scaleInTime = 0.5f;
		scaleOutTime = 0.5f;
		scaleInOffset = 0.025f;
		scaleOutOffset = 0.01f;
		objectThumbnailRot = Vector3.zero;
		objectThumbnailPos = new Vector3(0f, 0.15f, -5f);
		objectThumbnailScale = new Vector3(0.5f, 0.5f, 0.5f);
		ToggleBubs = dogPenPaneRef.ToggleBubs;
		ToggleScrollUp = dogPenPaneRef.ToggleScrollUp;
		ToggleScrollDown = dogPenPaneRef.ToggleScrollDown;
		copyWindow.SetActive(value: false);
		importWindow.SetActive(value: false);
		exportDogGUI.SetActive(value: false);
		importDogGUI.SetActive(value: false);
		importFailureWindow.SetActive(value: false);
		base.Preload();
	}

	public void ExportSelectedDog()
	{
		SetStandardButtonStatus(status: false);
		SaveableDog selectedSaveableDog = GetSelectedSaveableDog();
		if (selectedSaveableDog != null)
		{
			string text = dogRegRef.ExportDog(selectedSaveableDog);
			exportDogGUI.SetActive(value: true);
			exportDogGeneText.text = text;
			exportDogGeneText.enableWordWrapping = true;
		}
	}

	public void CloseExportDogGUI()
	{
		exportDogGUI.SetActive(value: false);
		SetStandardButtonStatus(status: true);
	}

	public void ImportDogButtonClicked()
	{
		importDogGUI.SetActive(value: true);
		SetStandardButtonStatus(status: false);
	}

	public void CloseImportDogGUI()
	{
		importDogGUI.SetActive(value: false);
		SetStandardButtonStatus(status: true);
	}

	public void CopyDogCode()
	{
		UniClipboard.SetText(exportDogGeneText.text);
		DisplayCopyPopup();
	}

	public void PasteDogCode()
	{
		importDogGeneText.text = UniClipboard.GetText();
	}

	public void ImportPastedDogCode()
	{
		if (dogRegRef.TryImportDog(importDogGeneText.text, OnDogImportComplete))
		{
			DisplayImportPopup();
		}
		else
		{
			DisplayImportFailurePopup();
		}
		importDogGeneText.text = "";
	}

	private void DisplayCopyPopup()
	{
		CloseExportDogGUI();
		copyWindow.SetActive(value: true);
		SetStandardButtonStatus(status: false);
	}

	public void CloseCopyPopup()
	{
		copyWindow.SetActive(value: false);
		SetStandardButtonStatus(status: true);
	}

	private void DisplayImportPopup()
	{
		CloseImportDogGUI();
		importWindow.SetActive(value: true);
		SetStandardButtonStatus(status: false);
	}

	private void DisplayImportFailurePopup()
	{
		CloseImportDogGUI();
		importFailureWindow.SetActive(value: true);
		SetStandardButtonStatus(status: false);
	}

	private void OnDogImportComplete()
	{
		UpdateHeldObjectsOfType();
		previewCache.Clear();
		PreloadPreviews();
		ClearBoxes();
		FillBoxes();
		RefreshUI();
		SetActiveBox(0);
	}

	public void CloseImportPopup()
	{
		importWindow.SetActive(value: false);
		SetStandardButtonStatus(status: true);
	}

	public void CloseImportFailurePopup()
	{
		importFailureWindow.SetActive(value: false);
		SetStandardButtonStatus(status: true);
	}

	private void SetStandardButtonStatus(bool status)
	{
		for (int i = 0; i < standardButtons.Count; i++)
		{
			if (!status)
			{
				standardButtons[i].HardDisable();
			}
			else
			{
				standardButtons[i].ClearHardDisable();
			}
		}
		for (int j = 0; j < boxes.Count; j++)
		{
			GetBackingObject(boxes[j]).GetComponent<Clickable>().enabled = status;
		}
		dogPenPaneRef.SetScrollInteractability(status);
	}

	public void StoreSelectedDog()
	{
		SaveableDog selectedSaveableDog = GetSelectedSaveableDog();
		if (!selectedSaveableDog.inWorld)
		{
			return;
		}
		if (selectedSaveableDog.inCocoon)
		{
			List<GameObject> allObjectsForTag = ObjectRegistration.GetRegistrationScript().GetAllObjectsForTag(TagsEnum.COCOON);
			for (int i = 0; i < allObjectsForTag.Count; i++)
			{
				if (allObjectsForTag[i].GetComponent<Cocoon>().GetAssociatedDogID() == selectedSaveableDog.dogID)
				{
					Object.Destroy(allObjectsForTag[i]);
					break;
				}
			}
			selectedSaveableDog.inWorld = false;
			dogRegRef.UpdateSaveableDog(selectedSaveableDog);
		}
		else
		{
			GameObject dogFromID = dogRegRef.GetDogFromID(selectedSaveableDog.dogID);
			dogRegRef.SaveDog(dogFromID, inWorld: false);
			Object.Destroy(dogFromID);
		}
		RefreshButtons();
		dogRegRef.RefreshSelectedDog();
		UpdateBoxIcon(boxes[GetWorkingIndex(activeBoxIndex)], activeBoxIndex);
	}

	public void BringOutSelectedDog()
	{
		SaveableDog selectedSaveableDog = GetSelectedSaveableDog();
		if (selectedSaveableDog.inWorld)
		{
			return;
		}
		if (selectedSaveableDog.inCocoon)
		{
			GameObject gameObject = dogHomeRef.TrySpawnItem(cocoonItem, dogHomeRef.GetPosForRoom(selectedSaveableDog.roomUID), selectedSaveableDog.roomUID);
			if (gameObject == null)
			{
				Debug.LogError("Something went wrong while attempting to bring out a cocoon dog.");
				return;
			}
			selectedSaveableDog.inWorld = true;
			dogRegRef.UpdateSaveableDog(selectedSaveableDog);
			dogRegRef.CacheThumbnailForDogID(selectedSaveableDog.dogID);
			gameObject.GetComponent<Cocoon>().SetAssociatedDogID(selectedSaveableDog.dogID);
			RefreshUI();
		}
		else
		{
			dogRegRef.RequestNewDog(dogHomeRef.GetPosForRoom(selectedSaveableDog.roomUID), Quaternion.identity, null, selectedSaveableDog, manualDog: false, DogCreationCallback);
		}
	}

	private void DogCreationCallback(GameObject dog)
	{
		dogRegRef.SaveDog(dog, inWorld: true);
		dogRegRef.CacheThumbnailForDogID(dogRegRef.GetIDFromDog(dog));
		RefreshUI();
	}

	private void RefreshUI()
	{
		RefreshButtons();
		dogRegRef.RefreshSelectedDog();
		UpdateBoxIcon(boxes[GetWorkingIndex(activeBoxIndex)], activeBoxIndex);
	}

	private SaveableDog GetSelectedSaveableDog()
	{
		return dogRegRef.GetSaveableDogFromID((ulong)heldObjectsOfType[GetWorkingIndex(activeBoxIndex)]);
	}

	public override object GetSelectedObject()
	{
		return dogRegRef.GetDogFromID((ulong)heldObjectsOfType[GetWorkingIndex(activeBoxIndex)]);
	}

	protected override GameObject GetPreviewObjectForObject(object obj)
	{
		GameObject obj2 = Object.Instantiate(dogPreviewHolder);
		obj2.GetComponent<SpriteRenderer>().sprite = dogRegRef.GetDefaultThumbnailForDogID((ulong)obj);
		return obj2;
	}

	protected override void SetActiveBox(int index)
	{
		base.SetActiveBox(index);
		RefreshButtons();
	}

	private void RefreshButtons()
	{
		if (heldObjectsOfType.Count == 0)
		{
			storeButton.SetActive(value: false);
			bringOutButton.SetActive(value: false);
		}
		else if (dogRegRef.GetSaveableDogFromID((ulong)GetObjectForIndex(activeBoxIndex)).inWorld)
		{
			storeButton.SetActive(value: true);
			bringOutButton.SetActive(value: false);
		}
		else
		{
			storeButton.SetActive(value: false);
			bringOutButton.SetActive(value: true);
		}
	}

	protected override void FillBox(GameObject box, int index, bool updateRotation = true)
	{
		base.FillBox(box, index, updateRotation);
		UpdateBoxIcon(box, index);
	}

	private void UpdateBoxIcon(GameObject box, int index)
	{
		if (GetWorkingIndex(index) >= heldObjectsOfType.Count)
		{
			box.GetComponent<DogPenBox>().inPenIcon.SetActive(value: false);
			box.GetComponent<DogPenBox>().inCocoonIcon.SetActive(value: false);
			return;
		}
		SaveableDog saveableDogFromID = dogRegRef.GetSaveableDogFromID((ulong)GetObjectForIndex(index));
		if (saveableDogFromID.inWorld)
		{
			box.GetComponent<DogPenBox>().inPenIcon.SetActive(value: true);
		}
		else
		{
			box.GetComponent<DogPenBox>().inPenIcon.SetActive(value: false);
		}
		if (saveableDogFromID.inCocoon)
		{
			box.GetComponent<DogPenBox>().inCocoonIcon.SetActive(value: true);
		}
		else
		{
			box.GetComponent<DogPenBox>().inCocoonIcon.SetActive(value: false);
		}
	}

	protected override string GetObjectNameForIndex(int index)
	{
		return dogRegRef.GetSaveableDogFromID((ulong)heldObjectsOfType[index]).dogName;
	}

	protected override string GetObjectDescriptionForIndex(int index)
	{
		return dogRegRef.GetSaveableDogFromID((ulong)heldObjectsOfType[index]).brain.dogAge.ToString();
	}

	protected override void UpdateHeldObjectsOfType()
	{
		List<SaveableDog> allOwnedDogs = dogRegRef.GetAllOwnedDogs();
		heldObjectsOfType.Clear();
		for (int i = 0; i < allOwnedDogs.Count; i++)
		{
			if (allOwnedDogs[i].inWorld)
			{
				heldObjectsOfType.Add(allOwnedDogs[i].dogID);
			}
		}
		for (int j = 0; j < allOwnedDogs.Count; j++)
		{
			if (!allOwnedDogs[j].inWorld)
			{
				heldObjectsOfType.Add(allOwnedDogs[j].dogID);
			}
		}
	}

	protected override List<object> GetAllObjects()
	{
		List<SaveableDog> allOwnedDogs = dogRegRef.GetAllOwnedDogs();
		List<object> list = new List<object>();
		for (int i = 0; i < allOwnedDogs.Count; i++)
		{
			if (allOwnedDogs[i].inWorld)
			{
				list.Add(allOwnedDogs[i].dogID);
			}
		}
		for (int j = 0; j < allOwnedDogs.Count; j++)
		{
			if (!allOwnedDogs[j].inWorld)
			{
				list.Add(allOwnedDogs[j].dogID);
			}
		}
		return list;
	}
}
