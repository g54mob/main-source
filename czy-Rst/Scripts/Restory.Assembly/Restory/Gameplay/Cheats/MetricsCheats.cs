using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Restory.AssetManagement;
using Restory.Data.Base;
using Restory.Data.Metrics;
using Restory.Gameplay.Metrics;
using UnityEngine.Scripting;
using Zenject;

namespace Restory.Gameplay.Cheats
{
	[Preserve]
	public class MetricsCheats : SRDebugCheatBase, INotifyPropertyChanged
	{
		private readonly MetricsService metricsService;

		private readonly List<MetricInfo> metrics = new List<MetricInfo>();

		private const string COMMON_CATEGORY = "Metrics Cheats";

		private MetricInfo selectedMetric;

		private int metricValue;

		[Category("Metrics Cheats")]
		[DisplayName("Selected Metric")]
		[SROptions.Sort(1)]
		public string SelectedMetric
		{
			get
			{
				if (!(selectedMetric == null))
				{
					return selectedMetric.ID;
				}
				return "None";
			}
		}

		[Category("Metrics Cheats")]
		[DisplayName("Metric Value")]
		[SROptions.Sort(3)]
		public int MetricValue
		{
			get
			{
				return metricValue;
			}
			set
			{
				metricValue = value;
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[Category("Metrics Cheats")]
		[DisplayName("<")]
		[SROptions.Sort(0)]
		public void CycleSelectedMetricLeft()
		{
			SwitchSelectedMetric(-1);
		}

		[Category("Metrics Cheats")]
		[DisplayName(">")]
		[SROptions.Sort(2)]
		public void CycleSelectedMetricRight()
		{
			SwitchSelectedMetric(1);
		}

		[Category("Metrics Cheats")]
		[DisplayName("Add Points")]
		[SROptions.Sort(4)]
		public void AddPoints()
		{
			if (selectedMetric != null)
			{
				metricsService.AddPoints(selectedMetric, metricValue);
			}
		}

		[Category("Metrics Cheats")]
		[DisplayName("Set Points")]
		[SROptions.Sort(5)]
		public void SetPoints()
		{
			if (selectedMetric != null)
			{
				metricsService.SetPoints(selectedMetric, metricValue);
			}
		}

		[Category("Metrics Cheats")]
		[DisplayName("Get Points")]
		[SROptions.Sort(6)]
		public void GetPoints()
		{
			if (selectedMetric != null)
			{
				metricValue = metricsService.GetPoints(selectedMetric);
				OnPropertyChanged("MetricValue");
			}
		}

		private void SwitchSelectedMetric(int increment)
		{
			if (metrics != null && metrics.Count != 0)
			{
				int num = metrics.IndexOf(selectedMetric);
				if (num < 0 || num >= metrics.Count)
				{
					num = 0;
				}
				num = (num + increment + metrics.Count) % metrics.Count;
				selectedMetric = metrics[num];
				OnPropertyChanged("SelectedMetric");
			}
		}

		[Inject]
		public MetricsCheats(MetricsService metricsService, GameEntityDataBaseProvider gameEntityDataBaseProvider)
		{
			this.metricsService = metricsService;
			metrics = gameEntityDataBaseProvider.Asset.All.Where((RestoryEntityInfoBase entity) => entity is MetricInfo).Cast<MetricInfo>().ToList();
		}

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
