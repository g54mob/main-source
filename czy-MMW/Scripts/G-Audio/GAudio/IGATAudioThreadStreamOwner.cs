namespace GAudio
{
	public interface IGATAudioThreadStreamOwner
	{
		int NbOfStreams { get; }

		IGATAudioThreadStream GetAudioThreadStream(int streamIndex);
	}
}
