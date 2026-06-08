namespace Kitchen.NetworkSupport
{
	public interface ILiveness
	{
		bool IsLive { get; }

		bool IsGoodQuality { get; }

		void RefreshLiveness();
	}
}
