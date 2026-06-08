namespace LaundryBear.PlatformServices
{
	public interface IPerformanceService : IService
	{
		void BeginCpuCritical();

		void EndCpuCritical();
	}
}
