using NSEipix.Model;
using NSMedieval.Enums;
using NSMedieval.StatsSystem;

namespace NSMedieval.UI
{
	public class InfoPanelStat
	{
		private string title;

		private string statFormat;

		private IntRange statValues;

		private string tooltipKey;

		private StatTrend trend;

		private StatType statType;

		public string Title => title;

		public string StatFormat => statFormat;

		public IntRange StatValues => statValues;

		public string TooltipKey => tooltipKey;

		public StatTrend Trend => trend;

		public StatType StatType => statType;

		public InfoPanelStat(string title, string statFormat, IntRange statValues, StatType statType = StatType.None)
		{
			this.title = title;
			this.statFormat = statFormat;
			this.statValues = statValues;
			this.statType = statType;
		}

		public InfoPanelStat(string title, string statFormat, IntRange statValues, string tooltipKey, StatType statType = StatType.None)
		{
			this.title = title;
			this.statFormat = statFormat;
			this.statValues = statValues;
			this.tooltipKey = tooltipKey;
			this.statType = statType;
		}

		public InfoPanelStat(string title, string statFormat, IntRange statValues, string tooltipKey, StatTrend trend, StatType statType = StatType.None)
		{
			this.title = title;
			this.statFormat = statFormat;
			this.statValues = statValues;
			this.tooltipKey = tooltipKey;
			this.trend = trend;
			this.statType = statType;
		}
	}
}
