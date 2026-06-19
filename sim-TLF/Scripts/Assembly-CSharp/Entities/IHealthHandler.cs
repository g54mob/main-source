using Services.Health;

namespace Entities
{
	public interface IHealthHandler
	{
		IHealthService HealthService { get; }
	}
}
