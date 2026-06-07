using System;
using ModApi;
using ModApi.Planet;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorial.Steps
{
	public class PerformanceStep : TutorialStep
	{
		public enum PerformanceMetricType
		{
			DeltaV = 0,
			StartingTWR = 1,
			EndingTWR = 2,
			Isp = 3,
			ExitPressure = 4
		}

		public string MetricText { get; set; }

		public PerformanceMetricType PerformanceMetric { get; set; }

		public double RequiredAltitude { get; set; }

		public string StageName { get; set; }

		public PerformanceStep(TutorialScript tutorialScript)
			: base(-1, tutorialScript)
		{
			base.CanSkip = false;
		}

		public override void Start()
		{
			base.Start();
		}

		public override void Update()
		{
			base.TutorialScript.ShowPanelType(TutorialPanelScript.TutorialPanelType.Instruction);
			CraftPerformanceAnalysis craftPerformanceAnalysis = base.TutorialScript.DesignerScript.PerformanceAnalysis as CraftPerformanceAnalysis;
			if (craftPerformanceAnalysis.Visible)
			{
				craftPerformanceAnalysis.SetGroupCollapsed("Staging Analysis", collapsed: false);
				craftPerformanceAnalysis.SetGroupCollapsed("Environment", collapsed: false);
				craftPerformanceAnalysis.SetGroupCollapsed("Craft Details", collapsed: true);
				base.TutorialScript.DisableUiHighlight();
				if (craftPerformanceAnalysis.SelectedEnvironment.Name != "Droo")
				{
					base.TutorialScript.HighlightUiElement("Performance.Environment", new Vector2(8f, 8f));
					DisplayInstruction("Select Droo in the Design Info panel");
				}
				else if (!Utilities.CompareDoubles(craftPerformanceAnalysis.AtmosphereSampleAltitudePercentage, RequiredAltitude, 0.009999999776482582))
				{
					base.TutorialScript.HighlightUiElement("Performance.Altitude", new Vector2(8f, 8f));
					AtmosphereSample sample = craftPerformanceAnalysis.SelectedEnvironment.Sample(RequiredAltitude);
					DisplayInstruction("Change the altitude to " + craftPerformanceAnalysis.GetAltitudeDisplayValue(sample) + " in the Design Info panel");
				}
				else if (craftPerformanceAnalysis.SelectedStageName != StageName)
				{
					base.TutorialScript.HighlightUiElement("Performance.Stage.StageNumber", new Vector2(8f, 8f));
					DisplayInstruction("Select " + StageName + " in the Design Info panel");
				}
				else
				{
					Tuple<string, Vector2> metricInfo = GetMetricInfo();
					base.TutorialScript.HighlightUiElement(metricInfo.Item1, metricInfo.Item2);
					DisplayStep(MetricText);
					base.TutorialScript.ShowPanelType(TutorialPanelScript.TutorialPanelType.Okay);
				}
			}
			else
			{
				base.TutorialScript.HighlightUiElement("Menu.Performance", new Vector2(8f, 8f));
				DisplayInstruction("Click the button on the right to open the Design Info panel.");
			}
		}

		private Tuple<string, Vector2> GetMetricInfo()
		{
			Vector2 item = new Vector2(8f, 8f);
			string text = null;
			return new Tuple<string, Vector2>(PerformanceMetric switch
			{
				PerformanceMetricType.DeltaV => "Performance.Stage.DeltaV", 
				PerformanceMetricType.StartingTWR => "Performance.Stage.StartingTWR", 
				PerformanceMetricType.EndingTWR => "Performance.Stage.EndingTWR", 
				PerformanceMetricType.Isp => "Performance.Stage.Isp", 
				PerformanceMetricType.ExitPressure => "Performance.Engine.ExitPressure", 
				_ => throw new Exception($"Unsupported metric type: {PerformanceMetric}"), 
			}, item);
		}
	}
}
