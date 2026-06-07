namespace VoxelBusters.EssentialKit
{
	public class CloudServicesSavedDataChangeResult
	{
		public CloudSavedDataChangeReasonCode ChangeReason { get; private set; }

		public string[] ChangedKeys { get; private set; }

		internal CloudServicesSavedDataChangeResult(CloudSavedDataChangeReasonCode changeReason, string[] changedKeys)
		{
		}
	}
}
