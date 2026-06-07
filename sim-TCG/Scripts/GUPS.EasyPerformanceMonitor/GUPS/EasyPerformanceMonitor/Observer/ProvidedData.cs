using GUPS.EasyPerformanceMonitor.Provider;

namespace GUPS.EasyPerformanceMonitor.Observer
{
	public struct ProvidedData<TValue> : IProvidedData<TValue>, IProvidedData
	{
		public IProvider Sender { get; set; }

		public TValue Value { get; set; }

		object IProvidedData.Value => Value;

		public ProvidedData(IProvider _Sender, TValue _Value)
		{
			Sender = _Sender;
			Value = _Value;
		}
	}
}
