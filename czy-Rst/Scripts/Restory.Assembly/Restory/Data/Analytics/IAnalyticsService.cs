namespace Restory.Data.Analytics
{
	public interface IAnalyticsService
	{
		bool IsActive { get; set; }

		void RequestDataDeletion();
	}
}
