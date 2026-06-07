public class AkUnitySoundEngineInitialization
{
	public delegate void InitializationDelegate();

	public delegate void ReInitializationDelegate();

	public delegate void TerminationDelegate();

	protected static AkUnitySoundEngineInitialization m_Instance;

	public InitializationDelegate initializationDelegate;

	public ReInitializationDelegate reInitializationDelegate;

	public TerminationDelegate terminationDelegate;

	public static AkUnitySoundEngineInitialization Instance => null;

	public bool InitializeSoundEngine()
	{
		return false;
	}

	protected virtual void LoadInitBank()
	{
	}

	protected virtual void ClearBanks()
	{
	}

	protected virtual void ResetBanks()
	{
	}

	public bool ResetSoundEngine(bool isInPlayMode)
	{
		return false;
	}

	public bool ShouldKeepSoundEngineEnabled()
	{
		return false;
	}

	public void ResetSoundEngine()
	{
	}

	public void TerminateSoundEngine()
	{
	}

	private void TerminateSoundEngine(bool forceReset)
	{
	}
}
