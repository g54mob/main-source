using System;

[Serializable]
public class NetworkSoundData
{
	public GameAudios audioName;

	public float delay;

	public NetworkSoundData(GameAudios audioName, float delay = 0f)
	{
		this.audioName = audioName;
		this.delay = delay;
	}
}
