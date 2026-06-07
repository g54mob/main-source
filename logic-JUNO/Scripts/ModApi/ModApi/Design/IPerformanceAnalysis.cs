using System;
using ModApi.Craft;
using ModApi.Planet;

namespace ModApi.Design
{
	public interface IPerformanceAnalysis
	{
		AtmosphereSample AtmosphereSample { get; set; }

		float MachNumber { get; }

		StageAnalysis StageAnalysis { get; }

		IPlanetData Star { get; }

		double StarDistance { get; }

		bool Visible { get; set; }

		event EventHandler<EventArgs> EnvironmentChanged;

		event EventHandler<EventArgs> StageAnalysisChanged;

		event EventHandler<EventArgs> StagingChanged;

		void ClosePanel();

		void ConfigureForVacuum();

		void ToggleInspectorPanel();
	}
}
