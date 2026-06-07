namespace Gilzoide.UpdateManager.Jobs
{
	public interface IJobDataSynchronizer<T>
	{
		void SyncJobData(ref T jobData);
	}
}
