using System;
using Restory.Data.Metrics;
using Restory.Data.WorkshopStatus;
using Restory.Gameplay.Metrics;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.WorkshopStatus
{
	public sealed class PointsBasedWorkshopStatusEvaluator : WorkshopStatusEvaluatorBase
	{
		[Serializable]
		private struct StatusThreshold
		{
			[SerializeField]
			private StatusInfo status;

			[SerializeField]
			[Min(0f)]
			private int requiredPoints;

			public readonly StatusInfo Status => status;

			public readonly int RequiredPoints => requiredPoints;
		}

		[SerializeField]
		private MetricInfo sourceMetricInfo;

		[SerializeField]
		private StatusThreshold[] thresholds = Array.Empty<StatusThreshold>();

		private WorkshopStatusService statusService;

		private MetricsService metricsService;

		[Inject]
		private void Construct(WorkshopStatusService statusService, MetricsService metricsService)
		{
			this.statusService = statusService;
			this.metricsService = metricsService;
		}

		public override void Initialize()
		{
			metricsService.OnMetricPointsChanged += ResolveOnMetricPointsChanged;
			Recalculate();
		}

		public override void Dispose()
		{
			metricsService.OnMetricPointsChanged -= ResolveOnMetricPointsChanged;
			for (int i = 0; i < thresholds.Length; i++)
			{
				statusService.RemoveStatus(thresholds[i].Status);
			}
		}

		private void ResolveOnMetricPointsChanged(MetricsService service, MetricInfo metric, int points)
		{
			Recalculate();
		}

		private void Recalculate()
		{
			if (sourceMetricInfo == null || thresholds.Length == 0)
			{
				return;
			}
			int points = metricsService.GetPoints(sourceMetricInfo);
			int num = -1;
			int num2 = int.MinValue;
			for (int i = 0; i < thresholds.Length; i++)
			{
				StatusThreshold statusThreshold = thresholds[i];
				if (statusThreshold.RequiredPoints <= points && statusThreshold.RequiredPoints >= num2)
				{
					num = i;
					num2 = statusThreshold.RequiredPoints;
				}
			}
			for (int j = 0; j < thresholds.Length; j++)
			{
				StatusInfo status = thresholds[j].Status;
				if (j == num)
				{
					statusService.AddStatus(status);
				}
				else
				{
					statusService.RemoveStatus(status);
				}
			}
		}
	}
}
