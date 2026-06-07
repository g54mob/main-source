public abstract class AkCommonPlatformSettings : AkBasePlatformSettings
{
	public override AkInitializationSettings AkInitializationSettings => null;

	public override AkSpatialAudioInitSettings AkSpatialAudioInitSettings => null;

	public override AkCallbackManager.InitializationSettings CallbackManagerInitializationSettings => null;

	public override string InitialLanguage => null;

	public override bool IsDecodedBankEnabled => false;

	public override bool IsAutoBankEnabled
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public override bool LoadBanksAsynchronously => false;

	public override string SoundBankPersistentDataPath => null;

	public override bool SuspendAudioDuringFocusLoss => false;

	public override bool RenderDuringFocusLoss => false;

	public override string SoundbankPath => null;

	public override bool UseSubFoldersForGeneratedFiles => false;

	public override uint MemoryDebugLevel => 0u;

	public override float defaultListenerScalingFactor => 0f;

	public override AkCommunicationSettings AkCommunicationSettings => null;

	protected abstract AkCommonUserSettings GetUserSettings();

	protected abstract AkCommonAdvancedSettings GetAdvancedSettings();

	protected abstract AkCommonCommSettings GetCommsSettings();
}
