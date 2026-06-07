using Assets.Scripts.Craft.Parts.Modifiers.Car;
using Assets.Scripts.Craft.Parts.Modifiers.Powertrain;
using Assets.Scripts.Design.Tutorials.Steps;

namespace Assets.Scripts.Design.Tutorials.Definitions
{
	public class CarTutorial : Tutorial
	{
		public CarTutorial(TutorialDatabase.TutorialInfo tutorialInfo)
			: base(tutorialInfo)
		{
		}

		protected override void BuildSteps(TutorialStepBuilderContext context)
		{
			context.SetCraftXml("__TutorialCar__");
			string[] excludedParts = new string[13]
			{
				"Transmission 1", "Main Drive Shaft", "Differential 1", "Drive Shaft Left", "Drive Shaft Right", "Suspension Back Left", "Suspension Back Right", "Suspension Front Left", "Suspension Front Right", "Wheel Front Left",
				"Wheel Front Right", "Wheel Back Left", "Wheel Back Right"
			};
			context.LoadAllParts(excludedParts);
			context.AddStep(new InfoStep(context, "We have a beautiful car body, but right now it's just a very expensive sled. We have some work to do.")).SetCameraTarget("Fuselage 2", -30f, 75f, 4f);
			float rotationY = 135f;
			context.AddStep(new AddPartStep(context, "Double Wishbone", "Suspension Front Right", AddPartStep.SymmetrySetting.Enabled, "Slap a wishbone suspension on the front.")).SetCameraTarget("Suspension Front Right", -30f, rotationY, 3f).Configure(delegate(AddPartStep x)
			{
				x.DesignerViewMode = DesignerViewMode.Normal;
			});
			context.AddStep(new AddPartStep(context, "Street Wheel", "Wheel Front Right", AddPartStep.SymmetrySetting.Enabled, "Now add a wheel. Nothing fancy, a Street Wheel will do just fine here."));
			context.AddStep(PartPropertyStep.Create<JWheelData, float>(context, "Wheel Front Right", "_turningAngle", 0f, 20f, "20", "Increase the turning angle. Unless your daily commute is a perfectly straight line, you're going to want to steer."));
			context.AddStep(new AddPartStep(context, "Double Wishbone", "Suspension Back Right", AddPartStep.SymmetrySetting.Enabled, "Typically cars have four wheels, so let's do the same at the back too.")).SetCameraTarget("Suspension Back Right", -30f, rotationY, 3f);
			context.AddStep(new AddPartStep(context, "Street Wheel", "Wheel Back Right", AddPartStep.SymmetrySetting.Enabled, "Another Street Wheel here."));
			context.AddStep(new AddPartStep(context, "Transmission", "Transmission 1", AddPartStep.SymmetrySetting.Disabled, "Add a transmission so the car can shift gears.")).SetCameraTarget("Transmission 1", -30f, rotationY, 2f).Configure(delegate(AddPartStep x)
			{
				x.DesignerViewMode = DesignerViewMode.Powertrain;
			});
			context.AddStep(PartPropertyStep.Create<JTransmissionData, int>(context, "Transmission 1", "_numGears", 5, 3, "3", "Reduce the number of gears on this transmission to make it smaller and lighter."));
			context.AddStep(new AddPartStep(context, "Drive Shaft", "Main Drive Shaft", AddPartStep.SymmetrySetting.Disabled, "Now a drive shaft to carry all that torque from the engine.")).SetCameraTarget("Main Drive Shaft", -30f, rotationY, 2.5f).Configure(delegate(AddPartStep x)
			{
				x.DesignerViewMode = DesignerViewMode.Powertrain;
			});
			context.AddStep(new AddPartStep(context, "Differential", "Differential 1", AddPartStep.SymmetrySetting.Disabled, "Add a differential here. It splits the power coming from the main drive shaft so it can reach multiple wheels at once.")).SetCameraTarget("Differential 1", -30f, rotationY, 2f).Configure(delegate(AddPartStep x)
			{
				x.DesignerViewMode = DesignerViewMode.Powertrain;
			});
			context.AddStep(new AddPartStep(context, "Drive Shaft", "Drive Shaft Right", AddPartStep.SymmetrySetting.Disabled, "Add another drive shaft here to carry the engine power from the differential to the rear wheel.")).SetCameraTarget("Drive Shaft Right", -30f, -145f, 2.25f).Configure(delegate(AddPartStep x)
			{
				x.DesignerViewMode = DesignerViewMode.Powertrain;
			})
				.Configure(delegate(AddPartStep x)
				{
					x.PlacementDistanceThreshold = 1000f;
				});
			context.AddStep(new DriveShaftStep(context, "Drive Shaft Right", "Suspension Back Right", "Now connect the other end of the drive shaft to the wheel."));
			context.LoadedPartIds.Add(context.GetPartIdByName("Drive Shaft Left"));
			context.AddStep(new CompleteTutorialStep(context, "Congrats! You built a functional car. Click the Play button in the bottom right to take it for a spin!")).Configure(delegate(CompleteTutorialStep x)
			{
				x.CustomStart = delegate(TutorialStep step)
				{
					step.Designer.Designer.ViewMode = DesignerViewMode.Normal;
				};
			}).SetCameraTarget("Fuselage 2", -30f, 75f, 4f);
		}
	}
}
