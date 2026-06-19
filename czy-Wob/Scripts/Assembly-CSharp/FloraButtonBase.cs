using UnityEngine;

public class FloraButtonBase : MonoBehaviour
{
	public delegate void TutorialCallback();

	public GameObject floraGUIRef;

	public GameObject unrecognizedFloraIndicator;

	private TutorialCallback currentGUIOpenCallback;

	private GameObject instantiatedGUIRef;

	private PenFocus focusRef;

	private GUIManagerPens guiRef;

	private FloraManager floraManagerRef;

	private void Awake()
	{
		unrecognizedFloraIndicator.SetActive(value: false);
		floraManagerRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<FloraManager>(GlobalObject.FLORA_MANAGER);
	}

	private void Update()
	{
		CheckFloraButton();
	}

	public void OnButtonClicked()
	{
		if (guiRef == null)
		{
			focusRef = Camera.main.GetComponent<PenFocus>();
			guiRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI);
		}
		LoadGUI();
	}

	private void LoadGUI()
	{
		if (instantiatedGUIRef != null)
		{
			Debug.LogError("Attempting to open the flora GUI when it's already open.");
			return;
		}
		focusRef.DisableModularZoom();
		guiRef.DisableBG(LockReason.FLORA_GUI);
		instantiatedGUIRef = Object.Instantiate(floraGUIRef, Vector3.zero, Quaternion.identity);
		instantiatedGUIRef.GetComponent<FloraGUI>().SetFloraRef(this);
	}

	public void CloseFloraGUIIfOpen()
	{
		if (instantiatedGUIRef != null)
		{
			instantiatedGUIRef.GetComponent<FloraGUI>().CloseGUI();
		}
	}

	public void UnloadGUI()
	{
		Object.Destroy(instantiatedGUIRef);
		OnGUIUnloaded();
	}

	private void OnGUIUnloaded()
	{
		focusRef.EnableModularZoom(focusRef.GetFocusedRoom());
		guiRef.EnableBG(LockReason.FLORA_GUI);
		instantiatedGUIRef = null;
		if (currentGUIOpenCallback != null)
		{
			currentGUIOpenCallback();
			currentGUIOpenCallback = null;
		}
	}

	private void CheckFloraButton()
	{
		unrecognizedFloraIndicator.SetActive(floraManagerRef.DoesAnyFloraHaveUnrecognizedInfo());
	}
}
