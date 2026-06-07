namespace VoxelBusters.EssentialKit
{
	public class NetworkServicesHostReachabilityStatusChangeResult
	{
		public bool IsReachable { get; private set; }

		internal NetworkServicesHostReachabilityStatusChangeResult(bool isReachable)
		{
		}
	}
}
