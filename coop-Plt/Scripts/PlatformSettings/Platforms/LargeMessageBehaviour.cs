namespace Platforms
{
	public enum LargeMessageBehaviour
	{
		SendAsOne = 0,
		SplitIntoFewPackets = 1,
		SplitIntoManyPackets = 2,
		SplitOverFrames = 3
	}
}
