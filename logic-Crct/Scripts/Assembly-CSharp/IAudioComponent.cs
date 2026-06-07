internal interface IAudioComponent
{
	void RefreshRead();

	void OnAudioReadSamples(float[] data);
}
