using UnityEngine;

public class AudioChipModule : Module
{
	public enum Commands
	{
		UpdateVolume = 1
	}

	public class Channel_EventData : EventData
	{
		public int Channel;

		public Channel_EventData()
		{
		}

		public Channel_EventData(int channel)
		{
		}
	}

	public int channelsCount;

	private AudioSource[] channels;

	private bool[] channelsPlaying;

	private bool[] channelsPaused;

	private float[] channelsVolume;

	private ModuleProperty channelsCountProperty;

	private ModuleProperty volumeProperty;

	private const int spectrumDataCount = 64;

	public override void AllocResources()
	{
	}

	public override void DeallocResources()
	{
	}

	protected override void OnSetupFinished()
	{
	}

	public override void ApplyPermanentStorage(Storage storage, Storage permanentOnlyStorage = null)
	{
	}

	private void SetupChannels()
	{
	}

	public override void OnTurnOff()
	{
	}

	public override void OnPreTickUpdate(TickLoop tickLoop)
	{
	}

	public override void RunCommand(int commandId)
	{
	}

	private bool IsPowerOfTwo(int x)
	{
		return false;
	}

	public float[] Script_GetSpectrumData(int channel, int samplesCount)
	{
		return null;
	}

	public double Script_GetDspTime()
	{
		return 0.0;
	}

	public void Script_Play(AudioSampleAsset audioSample, int channel)
	{
	}

	public void Script_PlayScheduled(AudioSampleAsset audioSample, int channel, double dspTime)
	{
	}

	public void Script_PlayLoop(AudioSampleAsset audioSample, int channel)
	{
	}

	public void Script_PlayLoopScheduled(AudioSampleAsset audioSample, int channel, double dspTime)
	{
	}

	public void Script_Stop(int channel)
	{
	}

	public void Script_Pause(int channel)
	{
	}

	public void Script_UnPause(int channel)
	{
	}

	public bool Script_IsPlaying(int channel)
	{
		return false;
	}

	public bool Script_IsPaused(int channel)
	{
		return false;
	}

	public float Script_GetPlayTime(int channel)
	{
		return 0f;
	}

	public void Script_SeekPlayTime(float time, int channel)
	{
	}

	public void Script_SetChannelVolume(float volume, int channel)
	{
	}

	public float Script_GetChannelVolume(int channel)
	{
		return 0f;
	}

	public void Script_SetChannelPitch(float pitch, int channel)
	{
	}

	public float Script_GetChannelPitch(int channel)
	{
		return 0f;
	}
}
