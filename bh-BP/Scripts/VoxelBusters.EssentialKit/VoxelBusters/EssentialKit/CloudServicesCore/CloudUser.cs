namespace VoxelBusters.EssentialKit.CloudServicesCore
{
	public class CloudUser : ICloudUser
	{
		public string UserId { get; private set; }

		public CloudUserAccountStatus AccountStatus { get; private set; }

		public CloudUser(string userId, CloudUserAccountStatus accountStatus)
		{
		}
	}
}
