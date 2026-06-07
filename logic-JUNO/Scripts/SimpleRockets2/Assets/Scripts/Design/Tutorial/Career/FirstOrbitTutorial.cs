using System.Linq;
using Assets.Scripts.Craft.Parts.Modifiers.Propulsion;
using Assets.Scripts.Design.Tutorial.Steps;
using ModApi;
using ModApi.Craft;
using ModApi.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorial.Career
{
	public class FirstOrbitTutorial : DesignerTutorial
	{
		private bool _configurationEngine2Done;

		private bool _configurationEngine3Done;

		private int _engineId2;

		private int _engineId3;

		public FirstOrbitTutorial(DesignerScript designer)
			: base(designer, 0.1f, 0.5f)
		{
			base.Tutorial.CraftDesignId = "__designerTutorialFirstOrbit__";
			base.GridSize = 0.05f;
			_engineId2 = base.Tutorial.GetPartId("Second Stage Engine");
			_engineId3 = base.Tutorial.GetPartId("Third Stage Engine");
			LoadSteps();
		}

		private void CraftLoaded(CraftData craftData)
		{
			if (!_configurationEngine2Done)
			{
				RocketEngineData modifier = craftData.Assembly.Parts.Where((PartData x) => x.Id == _engineId2).First().GetModifier<RocketEngineData>();
				modifier.UserNozzleThroatRadius = 0.75f;
				modifier.ExtensionSize = 1f;
				modifier.Scale = 0.65f;
				modifier.UpdateEngineType(updateFuelType: false);
			}
			if (!_configurationEngine3Done)
			{
				RocketEngineData modifier2 = craftData.Assembly.Parts.Where((PartData x) => x.Id == _engineId3).First().GetModifier<RocketEngineData>();
				modifier2.ExtensionSize = 1f;
				modifier2.Scale = 0.5f;
				modifier2.UpdateEngineType(updateFuelType: false);
			}
		}

		private void LoadSteps()
		{
			TutorialScript tutorial = base.Tutorial;
			CraftPerformanceAnalysis craftPerformanceAnalysis = base.Tutorial.DesignerScript.PerformanceAnalysis as CraftPerformanceAnalysis;
			craftPerformanceAnalysis.SelectEnvironment("Droo");
			if (Device.IsMobileBuild)
			{
				tutorial.DefaultCameraOffset = new Vector3(0f, -0.5f, 0f);
			}
			tutorial.LoadAllParts = true;
			string stepText = "We have a craft ready for you to use but it needs a few tweaks to its engines to improve its performance so that it can achieve orbit.";
			QueueStep(new InfoStep(tutorial), stepText);
			tutorial.LastStep.LoadCraft = true;
			tutorial.LastStep.CameraZoom = 12f;
			tutorial.LastStep.FocusPartId = tutorial.GetPartId("Second Stage Engine");
			tutorial.LastStep.CameraRotation = new Vector2(30f, 30f);
			stepText = "Open the Design Info panel.";
			PerformanceStep performanceStep = QueuePerfStep(stepText, PerformanceStep.PerformanceMetricType.DeltaV, "All Stages", 1.0, "This is the craft's total Delta V, which means change in velocity. Theoretically, this is how fast the craft could go in a perfect environment without gravity and without drag.");
			stepText = "Realistically, we need at least 4,500m/s to get into low orbit around Droo. It appears that we have more than enough, but we also need to consider that engine performance is affected by atmospheric pressure which changes with altitude.";
			performanceStep = QueuePerfStep(stepText, PerformanceStep.PerformanceMetricType.DeltaV, "All Stages", 0.0, "We have some work to do. We will need to look at each stage and see what we can do to improve performance. Don't worry, it's just rocket science.");
			stepText = "Let's look at the first stage, which consists of five solid rocket motors.";
			performanceStep = QueuePerfStep(stepText, PerformanceStep.PerformanceMetricType.DeltaV, "Stage 1", 0.0, "The Delta V looks okay for this stage, since we just want to use it to gain some altitude before starting the more efficient engines, that require a thinner atmosphere to work.");
			performanceStep.FocusPartId = tutorial.GetPartId("Goblin Solid Motor Center");
			performanceStep.CameraZoom = 2.5f;
			performanceStep.CameraRotation = new Vector2(-30f, 30f);
			performanceStep = QueuePerfStep(stepText, PerformanceStep.PerformanceMetricType.StartingTWR, "Stage 1", 0.0, "Another important metric to consider is TWR, which stands for Thrust to Weight Ratio. If this is less than 1, then the craft will not be able to overcome gravity during liftoff. This stage has plenty of TWR for launch.");
			performanceStep = QueuePerfStep(stepText, PerformanceStep.PerformanceMetricType.EndingTWR, "Stage 1", 0.0, "Notice the Ending TWR is higher than the Starting TWR. This is because the engines are burning fuel mass throughout the stage so the craft is losing mass. This means the rocket's acceleration actually increases throughout the stage.");
			performanceStep = QueuePerfStep(stepText, PerformanceStep.PerformanceMetricType.Isp, "Stage 1", 0.0, "One last thing to mention is the Isp, which stands for Specific Impulse. It's kinda like gas mileage for rocket engines. Higher is better. These solid rocket motors are not very efficient, but they're cheap and they get the job done.");
			double altitude = 8000.0 / craftPerformanceAnalysis.SelectedEnvironment.AtmosphereHeight;
			stepText = "Let's look at the second stage. From our previous launches we have found that this stage will ignite around 8km altitude.";
			performanceStep = QueuePerfStep(stepText, PerformanceStep.PerformanceMetricType.DeltaV, "Stage 2", altitude, "The Delta V and Starting TWR is terrible for this stage. This is because the Gnome Engine is optimized to work in a vacuum, but don't worry! We can do some rocket surgery here and improve its performance inside an atmosphere.");
			tutorial.LastStep.InitiallySelectedPartId = tutorial.GetPartId("Second Stage Engine");
			tutorial.LastStep.FocusPartId = performanceStep.InitiallySelectedPartId;
			tutorial.LastStep.CameraRotation = new Vector2(0f, 30f);
			tutorial.LastStep.CameraFocusOffset += new Vector3(0f, -0.5f, 0f);
			tutorial.LastStep.CameraZoom = 2.5f;
			tutorial.LastStep.HidePartIds.Add(tutorial.GetPartId("Interstage-1"));
			tutorial.LastStep.LoadCraft = true;
			performanceStep = QueuePerfStep(stepText, PerformanceStep.PerformanceMetricType.ExitPressure, "Stage 2", altitude, "This engine is suffering from severe over-expansion, which happens when the engine's exhaust Exit Pressure is less than Air Pressure. Over-expansion is what causes shock diamonds to show up in the exhaust. The closer Exit Pressure is to Air Pressure, the more efficient the engine becomes.");
			tutorial.LastStep.HidePartIds.Add(tutorial.GetPartId("Interstage-1"));
			stepText = "We can shorten the nozzle and crank up the power to increase this engine's Exit Pressure so that it's closer to the Air Pressure at this altitude.";
			ConfigureRocketEngineStep configureRocketEngineStep = QueueStep(new ConfigureRocketEngineStep(_engineId2, "Gnome Engine", tutorial), stepText);
			RocketEngineData modifier = tutorial.CurrentStepCraftData.Assembly.GetPartById(_engineId2).GetModifier<RocketEngineData>();
			configureRocketEngineStep.TargetSize = modifier.Scale;
			configureRocketEngineStep.TargetThroatRadius = modifier.UserNozzleThroatRadius;
			configureRocketEngineStep.TargetExtensionSize = modifier.ExtensionSize;
			tutorial.LastStep.HidePartIds.Add(tutorial.GetPartId("Interstage-1"));
			tutorial.LastStep.InitiallySelectedPartId = _engineId2;
			tutorial.LastStep.CameraFocusOffset += new Vector3(0f, -0.5f, 0f);
			tutorial.LastStep.FocusPartId = _engineId2;
			tutorial.LastStep.Complete = delegate
			{
				_configurationEngine2Done = true;
			};
			tutorial.LastStep.LoadCraft = true;
			stepText = "Let's take a look and see how things have changed.";
			performanceStep = QueuePerfStep(stepText, PerformanceStep.PerformanceMetricType.DeltaV, "Stage 2", altitude, "That's a huge improvement in Delta V and TWR! Now let's take a look at the third stage.");
			tutorial.LastStep.HidePartIds.Add(tutorial.GetPartId("Interstage-1"));
			tutorial.LastStep.LoadCraft = true;
			double altitude2 = 1.0;
			stepText = "The third stage engine will mostly be working in the upper atmosphere and in space.";
			performanceStep = QueuePerfStep(stepText, PerformanceStep.PerformanceMetricType.DeltaV, "Stage 3", altitude2, "The Delta V is pretty good for this stage, but we can improve it by lengthening the nozzle.");
			tutorial.LastStep.InitiallySelectedPartId = tutorial.GetPartId("Third Stage Engine");
			tutorial.LastStep.FocusPartId = performanceStep.InitiallySelectedPartId;
			tutorial.LastStep.CameraRotation = new Vector2(0f, 30f);
			tutorial.LastStep.CameraFocusOffset += new Vector3(0f, -0.5f, 0f);
			tutorial.LastStep.CameraZoom = 2.5f;
			tutorial.LastStep.HidePartIds.Add(tutorial.GetPartId("Interstage-2"));
			tutorial.LastStep.LoadCraft = true;
			stepText = "Ideally, Exit Pressure would be 0 for a rocket engine designed to work in space, but that would require an infinitely large nozzle. We'll have to settle for something a little shorter than that.";
			ConfigureRocketEngineStep configureRocketEngineStep2 = QueueStep(new ConfigureRocketEngineStep(_engineId3, "Gnome Engine", tutorial), stepText);
			RocketEngineData modifier2 = tutorial.CurrentStepCraftData.Assembly.GetPartById(_engineId3).GetModifier<RocketEngineData>();
			configureRocketEngineStep2.TargetSize = modifier2.Scale;
			configureRocketEngineStep2.TargetThroatRadius = modifier2.UserNozzleThroatRadius;
			configureRocketEngineStep2.TargetExtensionSize = modifier2.ExtensionSize;
			tutorial.LastStep.HidePartIds.Add(tutorial.GetPartId("Interstage-2"));
			tutorial.LastStep.InitiallySelectedPartId = _engineId3;
			tutorial.LastStep.CameraRotation = new Vector2(0f, 30f);
			tutorial.LastStep.CameraFocusOffset += new Vector3(0f, -0.25f, 0f);
			tutorial.LastStep.FocusPartId = _engineId3;
			tutorial.LastStep.Complete = delegate
			{
				_configurationEngine3Done = true;
			};
			tutorial.LastStep.LoadCraft = true;
			stepText = "Great work! Now this rocket is ready for launch!";
			QueueStep(new LaunchStep(tutorial), stepText).InstructionText = "Click the launch button at the top right and launch from the Juno Village Pad.";
			tutorial.LastStep.ReselectPart = false;
			tutorial.LastStep.LoadCraft = true;
			tutorial.LastStep.CameraZoom = 12f;
			tutorial.LastStep.FocusPartId = tutorial.GetPartId("Second Stage Engine");
			tutorial.LastStep.CameraRotation = new Vector2(30f, 30f);
		}

		private PerformanceStep QueuePerfStep(string stepText, PerformanceStep.PerformanceMetricType metric, string stage, double altitude, string metricText = null)
		{
			PerformanceStep performanceStep = QueueStep(new PerformanceStep(base.Tutorial), stepText);
			performanceStep.StageName = stage;
			performanceStep.RequiredAltitude = altitude;
			performanceStep.MetricText = metricText ?? string.Empty;
			performanceStep.PerformanceMetric = metric;
			return performanceStep;
		}

		private T QueueStep<T>(T step, string stepText) where T : TutorialStep
		{
			base.Tutorial.QueueStep(step, stepText);
			step.CraftDataLoaded = CraftLoaded;
			step.LoadCraft = false;
			return step;
		}
	}
}
