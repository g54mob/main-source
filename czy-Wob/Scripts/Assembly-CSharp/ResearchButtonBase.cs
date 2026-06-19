using UnityEngine;

public class ResearchButtonBase : MonoBehaviour
{
	public delegate void TutorialCallback();

	public GameObject researchGUIRef;

	public GameObject researchDoneIndicatorRef;

	public GameObject tutorialArrow;

	private TutorialCallback currentGUIOpenCallback;

	private GameObject instantiatedGUIRef;

	private PenFocus focusRef;

	private GUIManagerPens guiRef;

	private void Awake()
	{
		tutorialArrow.SetActive(value: false);
		researchDoneIndicatorRef.SetActive(value: false);
	}

	public void OnButtonClicked()
	{
		if (guiRef == null)
		{
			focusRef = Camera.main.GetComponent<PenFocus>();
			guiRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI);
		}
		LoadGUI();
		tutorialArrow.SetActive(value: false);
	}

	public void ActivateTutorialArrow(TutorialCallback callback)
	{
		tutorialArrow.SetActive(value: true);
		currentGUIOpenCallback = callback;
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
		Object.Instantiate(researchGUIRef, Vector3.zero, Quaternion.identity);
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
}
