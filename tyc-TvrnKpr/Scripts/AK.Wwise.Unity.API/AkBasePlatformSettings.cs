using UnityEngine;

public class AkBasePlatformSettings : ScriptableObject
{
	public virtual AkInitializationSettings AkInitializationSettings => null;

	public virtual AkSpatialAudioInitSettings AkSpatialAudioInitSettings => null;

	public virtual AkCallbackManager.InitializationSettings CallbackManagerInitializationSettings => null;

	public virtual string SoundBankPersistentDataPath => null;

	public virtual string InitialLanguage => null;

	public virtual bool LoadBanksAsynchronously => false;

	public virtual bool SuspendAudioDuringFocusLoss => false;

	public virtual bool RenderDuringFocusLoss => false;

	public virtual string SoundbankPath => null;

	public virtual AkCommunicationSettings AkCommunicationSettings => null;

	public virtual bool UseSubFoldersForGeneratedFiles => false;

	public virtual uint MemoryDebugLevel => 0u;

	public virtual bool IsDecodedBankEnabled => false;

	public virtual bool IsAutoBankEnabled
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public virtual float defaultListenerScalingFactor => 0f;
}
