using GUPS.EasyPerformanceMonitor.Observer;

namespace GUPS.EasyPerformanceMonitor.Provider
{
	public struct PerformanceData : IProvidedData<float>, IProvidedData
	{
		public IProvider Sender { get; private set; }

		public float Value { get; private set; }

		object IProvidedData.Value => Value;

		public float MinValue { get; private set; }

		public float MeanValue { get; private set; }

		public float MaxValue { get; private set; }

		public int ValueCount { get; private set; }

		public PerformanceData(IPerformanceProvider _Sender, float _Value, float _MinValue, float _MeanValue, float _MaxValue, int _ValueCount)
		{
			Sender = _Sender;
			Value = _Value;
			MinValue = _MinValue;
			MeanValue = _MeanValue;
			MaxValue = _MaxValue;
			ValueCount = _ValueCount;
		}
	}
}
