namespace GAudio
{
	public interface IGATTrackContributor
	{
		bool MixToTrack(GATData trackMonoBuffer, int trackNb);
	}
}
