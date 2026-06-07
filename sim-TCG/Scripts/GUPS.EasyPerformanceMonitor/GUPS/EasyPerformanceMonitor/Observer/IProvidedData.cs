using GUPS.EasyPerformanceMonitor.Provider;

namespace GUPS.EasyPerformanceMonitor.Observer
{
	public interface IProvidedData
	{
		IProvider Sender { get; }

		object Value { get; }
	}
	public interface IProvidedData<out TValue> : IProvidedData
	{
		new TValue Value { get; }
	}
}
