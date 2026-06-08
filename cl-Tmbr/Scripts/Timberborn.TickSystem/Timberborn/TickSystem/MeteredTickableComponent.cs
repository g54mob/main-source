using Timberborn.Metrics;

namespace Timberborn.TickSystem
{
	public class MeteredTickableComponent
	{
		private readonly TickableComponent _tickableComponent;

		private readonly ITimerMetric _timerMetric;

		private readonly bool _metricsEnabled;

		public bool Enabled => _tickableComponent.Enabled;

		public MeteredTickableComponent(TickableComponent tickableComponent, ITimerMetric timerMetric, bool metricsEnabled)
		{
			_tickableComponent = tickableComponent;
			_timerMetric = timerMetric;
			_metricsEnabled = metricsEnabled;
		}

		public void StartAndTick()
		{
			if (_metricsEnabled)
			{
				_timerMetric.Resume();
			}
			_tickableComponent.StartAndTick();
			if (_metricsEnabled)
			{
				_timerMetric.Pause();
			}
		}
	}
}
