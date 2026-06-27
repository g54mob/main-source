using System;
using Restory.Data.Metrics;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Metrics
{
	public abstract class MetricTrigger : MonoBehaviour, IInitializable, IDisposable
	{
		[SerializeField]
		protected MetricInfo metricInfo;

		protected MetricsService metricsService;

		[Inject]
		private void Construct(MetricsService metricsService)
		{
			this.metricsService = metricsService;
		}

		public abstract void Initialize();

		public abstract void Dispose();

		protected void AddPoints(int points)
		{
			metricsService.AddPoints(metricInfo, points);
		}

		protected void SetPoints(int points)
		{
			metricsService.SetPoints(metricInfo, points);
		}
	}
}
