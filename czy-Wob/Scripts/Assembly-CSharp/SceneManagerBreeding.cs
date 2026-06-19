public class SceneManagerBreeding : SceneManagerBase
{
	protected GUIManagerPens guiRef;

	private BreedingGUI breedingRef;

	public override void PreloadScene(PreloadCallback newCallback)
	{
		guiRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI);
		guiRef.SetGUIInteractiveStatus(status: false, LockReason.SCENE_PRELOAD);
		guiRef.LockPlayModeGUI();
		base.PreloadScene(newCallback);
		breedingRef = guiRef.ShowBreedingGUI();
	}

	public override bool IsBreedingScene()
	{
		return true;
	}

	public override void StartScene()
	{
		base.StartScene();
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		breedingRef.Initialize();
		breedingRef.InitializeBreeding(registrationScript.saveLoadManager.GetDogA(), registrationScript.saveLoadManager.GetDogB());
		guiRef.SetGUIInteractiveStatus(status: true, LockReason.SCENE_PRELOAD);
	}

	public void ShowPeekCutscene()
	{
		breedingRef.SetupPeekRoom();
	}

	public BreedingGUI GetBreedingGUIRef()
	{
		return breedingRef;
	}
}
