namespace SettingsScripts
{
	public static class SimMetricExtend
	{
		public static bool MetricHasArgument(this SimMetric metric)
		{
			if (metric == SimMetric.Time)
			{
				return false;
			}
			return true;
		}

		public static bool MetricHasArgumentList(this SimMetric metric)
		{
			return metric switch
			{
				SimMetric.Constant => false, 
				SimMetric.Time => false, 
				_ => true, 
			};
		}

		public static SimMetricTargetType TargetOfMetric(this SimMetric metric)
		{
			return metric switch
			{
				SimMetric.SpeciesCount => SimMetricTargetType.Species, 
				SimMetric.SpeciesBiomass => SimMetricTargetType.Species, 
				SimMetric.TagCount => SimMetricTargetType.Tag, 
				SimMetric.TagBiomass => SimMetricTargetType.Tag, 
				SimMetric.MaterialCount => SimMetricTargetType.Pellets, 
				SimMetric.MaterialBiomass => SimMetricTargetType.Pellets, 
				_ => SimMetricTargetType.None, 
			};
		}
	}
}
