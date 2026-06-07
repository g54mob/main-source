public class AkSoundEngineController
{
	private static AkSoundEngineController ms_Instance;

	public static AkSoundEngineController Instance => null;

	private AkSoundEngineController()
	{
	}

	~AkSoundEngineController()
	{
	}

	public void LateUpdate()
	{
	}

	private AkWwiseInitializationSettings GetInitSettingsInstance()
	{
		return null;
	}

	public void Init(AkInitializer akInitializer)
	{
	}

	public void OnDisable()
	{
	}

	public void Terminate()
	{
	}

	public void OnApplicationPause(bool pauseStatus)
	{
	}

	public void OnApplicationFocus(bool focus)
	{
	}

	private void ActivateAudio(bool activate, bool renderAnyway = false)
	{
	}
}
