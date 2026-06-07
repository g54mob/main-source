namespace GAudio
{
	public interface IGATAudioThreadStreamClient
	{
		void HandleAudioThreadStream(float[] data, int offset, bool emptyData, IGATAudioThreadStream stream);
	}
}
