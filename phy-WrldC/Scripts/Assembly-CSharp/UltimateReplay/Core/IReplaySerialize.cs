namespace UltimateReplay.Core
{
	public interface IReplaySerialize
	{
		void OnReplaySerialize(ReplayState state);

		void OnReplayDeserialize(ReplayState state);
	}
}
