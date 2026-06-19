using UnityEngine;

public class PlayModeController : MonoBehaviour
{
	public GameObject itemButton;

	public CoreButtonUnityGUI floraButtonRef;

	public CommandChooserGUI commandChooserGUI;

	private SceneManagerBase sceneRef;

	private DogPettingController pettingRef;

	private void Awake()
	{
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		sceneRef = registrationScript.GetGlobalComponent<SceneManagerBase>(GlobalObject.SCENE_MANAGER);
		pettingRef = registrationScript.GetGlobalComponent<DogPettingController>(GlobalObject.DOG_PETTING_CONTROLLER);
		ExitPettingMode();
		commandChooserGUI.gameObject.SetActive(value: true);
	}

	private void Start()
	{
		if (sceneRef.GetGameMode() == GameMode.HOME)
		{
			ShowFloraButton();
		}
		else
		{
			HideFloraButton();
		}
	}

	public void EnterPettingMode()
	{
		pettingRef.SetPettingMode(val: true);
		OnCommandSwitched();
		commandChooserGUI.SetPetActive();
	}

	public void ExitPettingMode()
	{
		pettingRef.SetPettingMode(val: false);
		OnCommandSwitched();
		commandChooserGUI.SetGrabActive();
	}

	public void SwapCommands()
	{
		if (pettingRef.InPettingMode())
		{
			ExitPettingMode();
		}
		else
		{
			EnterPettingMode();
		}
	}

	public void OnCommandSwitched()
	{
	}

	private void ShowFloraButton()
	{
		floraButtonRef.gameObject.SetActive(value: true);
	}

	private void HideFloraButton()
	{
		floraButtonRef.gameObject.SetActive(value: false);
	}
}
