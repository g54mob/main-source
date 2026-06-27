using System;
using System.Collections.Generic;
using System.Linq;
using Restory.Data.Metrics;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.SaveLoad.Exceptions;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Metrics
{
	public class MetricsService : MonoBehaviour, IInitializable, IDisposable, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter
	{
		private readonly Dictionary<MetricInfo, int> progress = new Dictionary<MetricInfo, int>();

		public IReadOnlyCollection<MetricInfo> Metrics => progress.Keys;

		public event Action<MetricsService, MetricInfo, int> OnMetricPointsChanged;

		public event Action<MetricsService, MetricInfo, int> OnMetricPointsAdded;

		public void Initialize()
		{
		}

		public void Dispose()
		{
			this.OnMetricPointsChanged = null;
			this.OnMetricPointsAdded = null;
			progress.Clear();
		}

		public int GetPoints(MetricInfo rating)
		{
			if (!progress.TryGetValue(rating, out var value))
			{
				return 0;
			}
			return value;
		}

		public void AddPoints(MetricInfo rating, int delta, bool sendCallback = true)
		{
			if (!progress.TryGetValue(rating, out var value))
			{
				value = 0;
			}
			value += delta;
			progress[rating] = value;
			if (sendCallback)
			{
				this.OnMetricPointsAdded?.Invoke(this, rating, delta);
				this.OnMetricPointsChanged?.Invoke(this, rating, value);
			}
		}

		public void SetPoints(MetricInfo rating, int value, bool sendCallback = true)
		{
			progress[rating] = value;
			if (sendCallback)
			{
				this.OnMetricPointsChanged?.Invoke(this, rating, value);
			}
		}

		public void RestoreState(object state)
		{
			try
			{
				MetricsServiceSaveData.MetricProgressSaveData[] array = DataMigrationWizard.Migrate<MetricsServiceSaveData>(state, base.gameObject).Progress;
				for (int i = 0; i < array.Length; i++)
				{
					MetricsServiceSaveData.MetricProgressSaveData metricProgressSaveData = array[i];
					SetPoints(metricProgressSaveData.Metric, metricProgressSaveData.Points, sendCallback: false);
				}
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}

		public object CaptureState()
		{
			try
			{
				return new MetricsServiceSaveData
				{
					Progress = progress.Select((KeyValuePair<MetricInfo, int> kv) => new MetricsServiceSaveData.MetricProgressSaveData
					{
						Metric = kv.Key,
						Points = kv.Value
					}).ToArray()
				};
			}
			catch (Exception innerException)
			{
				Debug.LogException(new CaptureProgressException(base.gameObject, innerException));
				return null;
			}
		}
	}
}
