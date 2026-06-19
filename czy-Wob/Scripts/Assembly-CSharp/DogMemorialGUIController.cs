using I2.Loc;
using TMPro;
using UnityEngine;

public class DogMemorialGUIController : MonoBehaviour
{
	public GameObject loadingDogText;

	public Transform dogRotationTransform;

	public InchwormBounce dogRotationBouncer;

	public TextMeshProUGUI dogNameText;

	public TextScaleInOnLoad dogNameScaleEffect;

	public TMP_InputField epitaphInputField;

	public ObjectRotationArea rotationAreaRef;

	private bool isLoadingDog;

	private string selectDogSound = "storage_selectDog";

	private string windowOpenSound = "incubator_window_open";

	private string windowCloseSound = "incubator_window_close";

	private bool GUIClosed;

	private DogMemorial memorialRef;

	private DogRegistration dogRegRef;

	private GUIManagerPens guiManagerRef;

	private ObjectIndicatorController indicatorRef;

	private void Awake()
	{
		loadingDogText.SetActive(value: false);
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		guiManagerRef = registrationScript.GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI);
		dogRegRef = registrationScript.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		guiManagerRef.DisableBG(LockReason.MEMORIAL_GUI);
		guiManagerRef.RegisterNewPopup(LockReason.MEMORIAL_GUI, stomp: true, CloseGUI);
		epitaphInputField.SetTextWithoutNotify(ScriptLocalization.GUI.GUI_MEMORIAL_DEFAULTEP);
		AudioController.Play(windowOpenSound);
	}

	private void Update()
	{
		if (GameControls.actions.CloseMenu.WasPressed)
		{
			CloseGUI();
		}
	}

	public void SetInfo(DogMemorial newRef, string epitaph, float zoomOrtho, Quaternion rot)
	{
		memorialRef = newRef;
		epitaphInputField.SetTextWithoutNotify(epitaph);
		rotationAreaRef.SetZoom(zoomOrtho);
		dogRotationTransform.rotation = rot;
		UpdateDisplay();
	}

	public void OnEndEditEpitaph()
	{
		memorialRef.epitaph = epitaphInputField.text;
		if (indicatorRef == null)
		{
			indicatorRef = memorialRef.GetComponent<ObjectIndicatorController>();
		}
		if (indicatorRef != null)
		{
			indicatorRef.OnMemorialEpitaphUpdated(memorialRef.epitaph);
		}
	}

	public void CloseGUI()
	{
		if (!GUIClosed)
		{
			memorialRef.SetRotationInfo(rotationAreaRef.GetZoom(), dogRotationTransform.rotation);
			GUIClosed = true;
			guiManagerRef.EnableBG(LockReason.MEMORIAL_GUI);
			guiManagerRef.ClearPopupRegistration(LockReason.MEMORIAL_GUI);
			Object.Destroy(base.gameObject);
			AudioController.Play(windowCloseSound);
		}
	}

	private void UpdateDisplay()
	{
		if (!isLoadingDog && !(memorialRef == null))
		{
			isLoadingDog = true;
			loadingDogText.SetActive(value: true);
			dogNameText.text = memorialRef.dogName;
			dogNameScaleEffect.RequestScaleIn();
			dogRegRef.RequestNewDog(dogRotationTransform.position, dogRotationTransform.rotation, memorialRef.dogGene, null, manualDog: false, dogProfile: memorialRef.dogProfile, customDogAge: memorialRef.dogAge, callback: OnNewDogCreated, playerOwned: false, useBaseGeneWithoutMutation: false, timeslice: true, forceCacheThumbnails: false, dummyDog: false, customDogAgeProgress: 1f);
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
		dogRegRef.MakeDogSuitableForUIDisplay(dog);
		AudioController.Play(selectDogSound);
		dog.transform.SetParent(dogRotationTransform, worldPositionStays: true);
	}
}
