using TMPro;
using UnityEngine;

public class DogNameInput : MonoBehaviour
{
	public TMP_InputField inputRef;

	public TextMeshProUGUI doneText;

	public CoreButtonUnityGUI doneButton;

	public GameObject loadingDogText;

	public Transform dogRotationTransform;

	public InchwormBounce dogRotationBouncer;

	public Camera dogRotationCamera;

	public GameObject stamp;

	private float adultDogCamOrtho = 2.5f;

	private bool isLoadingDog;

	private float doneTextInactiveAlpha = 0.75f;

	private string openSound = "naming_popup";

	private string stampSound = "naming_stamp";

	private string closeSound = "naming_confirm";

	private string selectDogSound = "storage_selectDog";

	private string textInSound = "mainMenu_characterIn";

	private string textOutSound = "mainMenu_characterErased";

	private ulong associatedDog;

	private string previousString = "";

	private bool GUIClosed;

	private GUIManagerPens guiRef;

	private DogRegistration dogRegRef;

	private void Awake()
	{
		LockDoneButton();
		loadingDogText.SetActive(value: false);
		inputRef.characterLimit = GlobalProperties.dogNameCharLimit;
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		guiRef = registrationScript.GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI);
		dogRegRef = registrationScript.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		RandomizeName();
		guiRef.DisableBG(LockReason.DOG_NAME_GUI);
		guiRef.RegisterNewPopup(LockReason.DOG_NAME_GUI);
		AudioController.Play(openSound);
		stamp.SetActive(value: false);
	}

	private void Update()
	{
		CheckUnlock();
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

	private void OnDestroy()
	{
		GUIClosed = true;
		guiRef.EnableBG(LockReason.DOG_NAME_GUI);
		guiRef.ClearPopupRegistration(LockReason.DOG_NAME_GUI);
		if (TutorialController.IsTutorialActive())
		{
			TutorialController.OnDogNamed();
		}
		AudioController.Play(closeSound);
	}

	public void SetDogRef(ulong dogID)
	{
		associatedDog = dogID;
		SaveableDog saveableDogFromID = dogRegRef.GetSaveableDogFromID(dogID);
		inputRef.text = saveableDogFromID.dogName;
		UpdateDisplay(saveableDogFromID);
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
		GameObject dogFromID = dogRegRef.GetDogFromID(associatedDog);
		if (dogFromID != null)
		{
			dogFromID.GetComponent<DogIndicatorController>().EnableEntireIndicator();
		}
		Object.Destroy(base.gameObject);
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

	private void UpdateDisplay(SaveableDog sd)
	{
		if (!isLoadingDog)
		{
			isLoadingDog = true;
			loadingDogText.SetActive(value: true);
			dogRegRef.RequestNewDog(dogRotationTransform.position, dogRotationTransform.rotation, sd.dogGene, null, manualDog: false, dogProfile: sd.dogProfile, customDogAge: sd.brain.dogAge, customDogAgeProgress: sd.brain.dogAgeProgress, callback: OnNewDogCreated, playerOwned: false);
		}
	}

	private void OnNewDogCreated(GameObject dog)
	{
		if (GUIClosed)
		{
			Object.Destroy(dog);
			return;
		}
		isLoadingDog = false;
		loadingDogText.SetActive(value: false);
		dogRotationBouncer.RequestBounce();
		AudioController.Play(selectDogSound);
		dogRegRef.MakeDogSuitableForUIDisplay(dog);
		dog.transform.SetParent(dogRotationTransform, worldPositionStays: true);
		if (dog.GetComponent<DoggyBrain>().GetCurrentDogAge() != DogAge.PUPPY)
		{
			dogRotationCamera.orthographicSize = adultDogCamOrtho;
		}
		Inchworm globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
		float num = 0.25f;
		float num2 = 0.25f;
		stamp.SetActive(value: true);
		stamp.transform.localScale = new Vector3(3f, 3f, 3f);
		globalComponent.RequestEaseToScale(stamp, Vector3.one, 0.25f, Inchworm.EaseStyle.QuadraticIn, null, Inchworm.EasePriority.Normal, num, invisibleBeforeStart: true);
		AudioController.Play(stampSound, 1f, num + num2);
	}
}
