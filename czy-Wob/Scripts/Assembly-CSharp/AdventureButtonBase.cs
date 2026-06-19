using UnityEngine;

public class AdventureButtonBase : MonoBehaviour
{
	public delegate void TutorialCallback();

	public GameObject adventureGUIRef;

	public GameObject adventureIndicatorRef;

	private TutorialCallback currentGUIOpenCallback;

	private GameObject instantiatedGUIRef;

	private PenFocus focusRef;

	private GUIManagerPens guiRef;

	private AdventureManager adventureRef;

	private void Awake()
	{
		adventureIndicatorRef.SetActive(value: false);
		adventureRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<AdventureManager>(GlobalObject.ADVENTURE_MANAGER);
	}

	private void Update()
	{
		SyncResearchReadyIndicator();
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
			Debug.LogError("Attempting to open the research GUI when it's already open.");
			return;
		}
		focusRef.DisableModularZoom();
		guiRef.DisableBG(LockReason.RESEARCH_GUI);
		instantiatedGUIRef = Object.Instantiate(adventureGUIRef, Vector3.zero, Quaternion.identity);
		instantiatedGUIRef.GetComponent<AdventureGUI>().SetAdventureRef(this);
	}

	public void UnloadGUI()
	{
		Object.Destroy(instantiatedGUIRef);
		OnGUIUnloaded();
	}

	private void OnGUIUnloaded()
	{
		focusRef.EnableModularZoom(focusRef.GetFocusedRoom());
		guiRef.EnableBG(LockReason.RESEARCH_GUI);
		instantiatedGUIRef = null;
		if (currentGUIOpenCallback != null)
		{
			currentGUIOpenCallback();
			currentGUIOpenCallback = null;
		}
	}

	private void SyncResearchReadyIndicator()
	{
		if (adventureRef.CanAdventure())
		{
			adventureIndicatorRef.SetActive(value: true);
		}
		else
		{
			adventureIndicatorRef.SetActive(value: false);
		}
	}
}
