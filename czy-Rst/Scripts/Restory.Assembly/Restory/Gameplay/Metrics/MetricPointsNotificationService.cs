using System;
using Restory.Data.Metrics;
using Restory.UI.Presenters.Metrics;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Metrics
{
	public class MetricPointsNotificationService : MonoBehaviour, IInitializable, IDisposable
	{
		private MetricsService metricsService;

		private GUI_MetricScoreNotificationCanvas guiPointsNotificationCanvas;

		[Inject]
		private void Construct(MetricsService metricsService, GUI_MetricScoreNotificationCanvas guiPointsNotificationCanvas)
		{
			this.metricsService = metricsService;
			this.guiPointsNotificationCanvas = guiPointsNotificationCanvas;
		}

		public void Initialize()
		{
			metricsService.OnMetricPointsAdded += ResolveOnMetricPointsAdded;
		}

		public void Dispose()
		{
			metricsService.OnMetricPointsAdded -= ResolveOnMetricPointsAdded;
			metricsService = null;
		}

		private void ResolveOnMetricPointsAdded(MetricsService service, MetricInfo info, int addedPoints)
		{
			guiPointsNotificationCanvas.Show(info, addedPoints);
		}
	}
}
