using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Craft.Parts.Modifiers.CarverParts;
using Assets.Scripts.Craft.Parts.Modifiers.Powertrain;
using Assets.Scripts.Design.Tutorials.Steps;
using Assets.Scripts.Design.Tutorials.Steps.FuselageSteps;
using Assets.Scripts.Design.Tutorials.Steps.WingSteps;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorials.Definitions
{
	public class PropPlaneTutorial : Tutorial
	{
		public PropPlaneTutorial(TutorialDatabase.TutorialInfo tutorialInfo)
			: base(tutorialInfo)
		{
		}

		protected override void BuildSteps(TutorialStepBuilderContext context)
		{
			context.SetCraftXml("__TutorialProp__");
			context.LoadedPartIds.Add(context.GetPartIdByName("Flight Computer 1"));
			context.LoadedPartIds.Add(context.GetPartIdByName("Fuselage 1"));
			context.AddStep(new AddPartStep(context, "Fuselage", "Fuselage 2", AddPartStep.SymmetrySetting.Any, "Let's start with the body of the aircraft, also known as its fuselage.")).SetCameraTarget("Fuselage 2", -30f, 150f, 4.5f);
			context.AddStep(new FuselageLengthStep(context, "Fuselage 2", FuselageEndType.Back, 1f, 1.75f, "Stretch out the length."));
			context.AddStep(new FuselageHeightStep(context, "Fuselage 2", FuselageEndType.Back, 0.75f, 0.5f, "Squish the height down on the back face."));
			context.AddStep(new FuselageWidthStep(context, "Fuselage 2", FuselageEndType.Back, 0.75f, 0.5f, "Taper the width down. We want it sleek, not chunky."));
			context.AddStep(new FuselageAddSectionStep(context, "Fuselage 2", "Fuselage 3", FuselageEndType.Back, "Add another fuselage using the 'Add Section' button."));
			context.AddStep(new FuselageLengthStep(context, "Fuselage 3", FuselageEndType.Back, 1.75f, 1f, "Shorten up this new tail section.")).SetCameraTarget("Fuselage 3", -30f, 150f, 4.5f);
			context.AddStep(new FuselageAddSectionStep(context, "Fuselage 1", "Fuselage 4", FuselageEndType.Front, "Now for the nose. Add a section up front.")).SetCameraTarget("Fuselage 1", -30f, 30f, 6f);
			context.AddStep(new FuselageLengthStep(context, "Fuselage 4", FuselageEndType.Front, 1.5f, 0.25f, "Stubby noses are in this season. Shorten it up."));
			context.AddStep(new FuselageAddSectionStep(context, "Fuselage 4", "Fuselage 5", FuselageEndType.Front, "Add one last section for the tip of the nose."));
			context.AddStep(new FuselageLengthStep(context, "Fuselage 5", FuselageEndType.Front, 0.25f, 0.75f, "Pull it out just a tad."));
			context.AddStep(new FuselageHeightStep(context, "Fuselage 5", FuselageEndType.Front, 0.75f, 0.4f, "Slope the top down."));
			context.AddStep(new FuselageWidthStep(context, "Fuselage 5", FuselageEndType.Front, 1f, 0.75f, "Squeeze the sides in just slightly."));
			context.AddStep(new FuselageCuttingStep(context, "Fuselage 5", FuselageEndType.Front, null, new JFuselageData.CuttingParams(null, null, 0.5m, null), "Cutting is another way to modify fuselage parts, allowing for unique shapes."));
			context.AddStep(new AddPartStep(context, "Primary Wing", "Primary Wing Right", AddPartStep.SymmetrySetting.Enabled, "Slap some wings on this tube so it can actually fly.")).SetCameraTarget("Primary Wing Right", -45f, 45f, 5f);
			context.AddStep(new WingShapeStep(context, "Primary Wing Right", 0f, 1.45f, 0.225f, 3f, 0.4f, -0.3f, 0f, 1.45f, 0.225f, 4.2f, 0.4f, 0.7f, "Make the wings huge so it has plenty of lift.")).SetCameraTarget("Primary Wing Right", new Vector3(2.5f, 0f, 0.5f), -60f, 45f, 6.5f);
			context.LoadedPartIds.Add(context.GetPartIdByName("Primary Wing Aileron Right"));
			context.LoadedPartIds.Add(context.GetPartIdByName("Primary Wing Aileron Left"));
			context.AddStep(PartPropertyStep.Create<JWingData, float>(context, "Primary Wing Right", "_fuelFraction", 0f, 0.15f, "15%", "Fuel typically goes in the wings. Let's add some now so we don't forget. But not too much, fuel is heavy!"));
			context.AddStep(new AddPartStep(context, "Horizontal Stabilizer", "Horizontal Stabilizer Right", AddPartStep.SymmetrySetting.Enabled, "Add the horizontal stabilizer. These allow the aircraft to pitch up and down.")).SetCameraTarget("Horizontal Stabilizer Right", -45f, 45f, 5f);
			context.LoadedPartIds.Add(context.GetPartIdByName("Horizontal Stabilizer Flap Right"));
			context.LoadedPartIds.Add(context.GetPartIdByName("Horizontal Stabilizer Flap Left"));
			context.AddStep(new AddPartStep(context, "Vertical Stabilizer", "Vertical Stabilizer", AddPartStep.SymmetrySetting.Disabled, "Add a vertical stabilizer so we don't spin out like a frisbee."));
			context.LoadedPartIds.Add(context.GetPartIdByName("Vertical Stabilizer Flap"));
			TutorialStepBuilderContext.StepBuilder<AddPartStep> stepBuilder = context.AddStep(new AddPartStep(context, "Small Prop", new string[3] { "Prop Engine", "Gearbox 1", "Prop Assembly" }, AddPartStep.SymmetrySetting.Disabled, "Now let's bolt on a propeller engine."));
			bool? useZTest = false;
			stepBuilder.SetDefaultHighlightConfiguration(null, null, useZTest).SetCameraTarget("Prop Engine", -30f, 45f, 4f);
			context.AddStep(PartPropertyStep.Create<JEngineData, int>(context, "Prop Engine", "_cylinderRows", 2, 3, "6", "Let's make this engine a little more powerful."));
			context.AddStep(PartPropertyStep.Create<JFuselageData, bool>(context, "Fuselage 5", "_isHollow", previousValue: false, newValue: true, "Yes", "Hollow out the nose section so we can show off our engine to the world."));
			context.AddStep(new AddPartStep(context, "Wing Gear", "Landing Gear Right", AddPartStep.SymmetrySetting.Enabled, "Add the landing gear here.")).SetCameraTarget("Landing Gear Right", new Vector3(0f, -0.5f, 0f), 15f, 50f, 3f);
			context.AddStep(new AddPartStep(context, "Fixed Gear", "Tail Landing Gear", AddPartStep.SymmetrySetting.Disabled, "Add a tiny wheel in the back to keep the tail out of the dirt.")).SetCameraTarget("Tail Landing Gear", 15f, 50f, 3f);
			context.AddStep(PartPropertyStep.Create<WheelData, bool>(context, "Tail Landing Gear", "_turningEnabled", previousValue: false, newValue: true, "Yes", "Enable turning on the rear wheel to make it a little easier to get around on the runway."));
			context.AddStep(new AddPartStep(context, "Bay", "Cockpit Hole", AddPartStep.SymmetrySetting.Disabled, "We need somewhere to stash the pilot. Carve out a hole for the cockpit.")).SetCameraTarget("Cockpit Hole", -30f, 45f, 3f);
			context.AddStep(PartPropertyStep.Create<ProceduralBayData, float>(context, "Cockpit Hole", "_width", 0.3f, 0.7f, "0.7", "Widen the gap. Major Chad has broad shoulders.")).Configure(delegate(PartPropertyStep x)
			{
				x.CuttingOutlinesState = true;
			});
			context.AddStep(PartPropertyStep.Create<ProceduralBayData, float>(context, "Cockpit Hole", "_height", 0.6f, 1.1f, "1.1", "Stretch it out. Even virtual pilots appreciate decent legroom.")).Configure(delegate(PartPropertyStep x)
			{
				x.CuttingOutlinesState = true;
			});
			context.AddStep(new AddPartStep(context, "Basic Seat", "Pilot Seat", AddPartStep.SymmetrySetting.Any, "Add a seat for our pilot, Major Chad.")).Configure(delegate(AddPartStep x)
			{
				x.CuttingOutlinesState = false;
			}).SetCameraTarget("Cockpit Hole", -75f, 45f, 3f);
			context.AddStep(new CompleteTutorialStep(context, "Congrats! You built an airplane! You can take it for a test flight by clicking the Play button in the bottom right.")).SetCameraTarget("Fuselage 2", -30f, 45f, 9f);
		}
	}
}
