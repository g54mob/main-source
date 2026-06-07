namespace VoxelBusters.EssentialKit
{
	public interface ICloudUser
	{
		string UserId { get; }

		CloudUserAccountStatus AccountStatus { get; }
	}
}
