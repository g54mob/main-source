using TMPro;
using UnityEngine;

public class DogNameInputStorage : MonoBehaviour
{
	public TMP_InputField inputRef;

	public TextMeshProUGUI doneText;

	public CoreButtonUnityGUI doneButton;

	private float doneTextInactiveAlpha = 0.75f;

	private string openSound = "naming_popup";

	private string closeSound = "naming_confirm";

	private string textInSound = "mainMenu_characterIn";

	private string textOutSound = "mainMenu_characterErased";

	private ulong associatedDog;

	private string previousString = "";

	private DogRegistration dogRegRef;

	private DogStorageGUIManager storageRef;

	private void Awake()
	{
		LockDoneButton();
		inputRef.characterLimit = GlobalProperties.dogNameCharLimit;
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		dogRegRef = registrationScript.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		AudioController.Play(openSound);
	}

	public void SetStorageRef(DogStorageGUIManager newRef)
	{
		storageRef = newRef;
	}

	private void Update()
	{
		CheckUnlock();
	}

	public void OnCancelButtonPressed()
	{
		base.gameObject.SetActive(value: false);
	}

	public void OnValueChanged()
	{
		if (inputRef.text.Length > previousString.Length)
		{
			AudioController.Play(textInSound);
		}
		else if (inputRef.text.Length < previousString.Length)
		{
			AudioController.Play(textOutSound);
		}
		previousString = inputRef.text;
	}

	private void CheckUnlock()
	{
		if (inputRef.text.Length < 1)
		{
			LockDoneButton();
		}
		else
		{
			UnlockDoneButton();
		}
	}

	public void SetDogRef(ulong dogID)
	{
		associatedDog = dogID;
		SaveableDog saveableDogFromID = dogRegRef.GetSaveableDogFromID(dogID);
		inputRef.text = saveableDogFromID.dogName;
		CheckUnlock();
	}

	public void RandomizeName()
	{
		inputRef.text = dogRegRef.ChooseRandomDogNameNonDestructive(inputRef.text);
		CheckUnlock();
	}

	public void OnOkayButtonPressed()
	{
		SaveableDog saveableDogFromID = dogRegRef.GetSaveableDogFromID(associatedDog);
		saveableDogFromID.dogName = inputRef.text;
		dogRegRef.UpdateSaveableDog(saveableDogFromID);
		dogRegRef.RefreshNameForDogID(associatedDog);
		dogRegRef.RefreshThumbnailForDogID(associatedDog);
		storageRef.OnRenameComplete();
		base.gameObject.SetActive(value: false);
		AudioController.Play(closeSound);
	}

	private void LockDoneButton()
	{
		doneButton.interactable = false;
		doneText.alpha = doneTextInactiveAlpha;
	}

	private void UnlockDoneButton()
	{
		doneText.alpha = 1f;
		doneButton.interactable = true;
	}
}
