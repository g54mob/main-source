using System.Linq;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Design.Tutorial.Steps;
using ModApi.Craft;
using ModApi.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorial.Career
{
	public class TheJumpTutorial : DesignerTutorial
	{
		public TheJumpTutorial(DesignerScript designer)
			: base(designer, 0.2f, 0.5f)
		{
			base.GridSize = 0.05f;
			LoadSteps();
		}

		private void LoadSteps()
		{
			TutorialScript tutorial = base.Tutorial;
			tutorial.LoadedPartIds.Add(0);
			base.Tutorial.CraftDesignId = "__new_career__";
			AddDesignerIntoSteps(tutorial, 2.5f, invokeDesignerPullout: true);
			Vector3 vector = new Vector3(0f, -0.375f, 0f);
			int commandDiscId = tutorial.GetPartId("Command Disc");
			CommandPodConfigurationStep commandPodConfigurationStep = tutorial.QueueStep(new CommandPodConfigurationStep(commandDiscId, "Command Disc", tutorial), "Since we are building a craft that mostly moves horizontally, we'll need to change the Command Disc from Rocket to Plane configuration.");
			commandPodConfigurationStep.BatteryStepText = "Let's also increase the battery capacity, which will increase the driving range of this car.";
			commandPodConfigurationStep.TargetBattery = 0.25f;
			tutorial.LastStep.InitiallySelectedPartId = 0;
			tutorial.LastStep.CameraZoom = 2.5f;
			tutorial.LastStep.CameraRotation = new Vector2(30f, 30f);
			tutorial.LastStep.CameraFocusOffset = vector;
			tutorial.LastStep.InvokeDesignerPullout = true;
			tutorial.LastStep.CraftDataLoaded = delegate(CraftData craftData)
			{
				craftData.Assembly.Parts.Where((PartData x) => x.Id == commandDiscId).First().GetModifier<CommandPodData>()
					.Battery = 0f;
			};
			base.Tutorial.CraftDesignId = "__designerTutorialTheJump__";
			string stepText = "Let's start building a car. The first step is to add an empty fuel tank behind the Command Disc. This will serve as the body of the car.";
			tutorial.QueueAddFuselagePartStep(tutorial.GetPartId("Fuel Tank"), "Fuel Tank", updatePosition: true, stepText);
			tutorial.LastStep.CameraZoom = 3f;
			tutorial.LastStep.CameraRotation = new Vector2(30f, 30f);
			tutorial.LastStep.CameraFocusOffset = vector;
			stepText = "Now let's add a nose cone to help reduce drag and make it look cooler too.";
			AddFuselageStep addFuselageStep = tutorial.QueueAddFuselagePartStep(tutorial.GetPartId("Nose Cone"), "Nose Cone", updatePosition: true, stepText);
			tutorial.LastStep.CameraRotation = new Vector2(30f, 120f);
			addFuselageStep.FlipDeltaPosition = true;
			addFuselageStep.CameraZoom = 2.5f;
			stepText = "Now let's add a front wheel.";
			int partId = tutorial.GetPartId("Front Wheel Left");
			tutorial.QueueAddPartStep(partId, "Car Wheel", stepText);
			tutorial.LastStep.CameraZoom = 2.5f;
			tutorial.LastStep.CameraRotation = new Vector2(30f, 120f);
			tutorial.LastStep.CameraFocusOffset = vector;
			stepText = "Now let's add a rear wheel";
			int partId2 = tutorial.GetPartId("Rear Wheel Left");
			tutorial.QueueAddPartStep(partId2, "Car Wheel", stepText).ClonePartId = partId;
			tutorial.LastStep.CameraRotation = new Vector2(30f, 120f);
			tutorial.LastStep.CameraFocusOffset = vector + new Vector3(0f, 0f, 0.25f);
			stepText = "I think cars usually have wheels on both sides, so let's use the Symmetry Tool and duplicate our work to the other side.";
			tutorial.QueueStep(new SymmetryStep(partId2, "Car Wheel", tutorial), stepText).ClosePanelRequired = false;
			tutorial.LastStep.InitiallySelectedPartId = partId2;
			tutorial.LastStep.FocusPartId = partId2;
			tutorial.LoadedSymmetricPartIds.Add(partId2);
			tutorial.LoadedSymmetricPartIds.Add(tutorial.GetPartId("Rear Wheel Right"));
			stepText = "Now do the same thing for the other wheel.";
			tutorial.QueueStep(new SymmetryStep(partId, "Car Wheel", tutorial), stepText).ClosePanelRequired = false;
			tutorial.LastStep.InitiallySelectedPartId = partId;
			tutorial.LastStep.FocusPartId = partId;
			tutorial.LoadedSymmetricPartIds.Add(partId);
			tutorial.LoadedSymmetricPartIds.Add(tutorial.GetPartId("Front Wheel Left"));
			stepText = "Make the front wheels turnable and reduce the engine torque to save money.\n\nSince Symmetry Mode is enabled on this wheel, the other side will automatically receive any changes we make.";
			tutorial.QueueStep(new ConfigureWheelStep(partId, "Car Wheel", tutorial), stepText);
			tutorial.LastStep.InitiallySelectedPartId = partId;
			tutorial.LastStep.FocusPartId = partId;
			stepText = "Crank up the torque on those rear wheels and adjust their gear ratio. Lower gear ratios are better for top speed and higher gear ratios are better for acceleration.";
			tutorial.QueueStep(new ConfigureWheelStep(partId2, "Car Wheel", tutorial), stepText);
			tutorial.LastStep.InitiallySelectedPartId = partId2;
			tutorial.LastStep.FocusPartId = partId2;
			stepText = "Change the motor input to use Pitch instead of Throttle. This will allow you to go in reverse in case you get stuck.";
			ConfigureMotorInputStep configureMotorInputStep = tutorial.QueueStep(new ConfigureMotorInputStep(partId2, "Car Wheel", tutorial), stepText);
			configureMotorInputStep.InputControllerId = "RPM";
			configureMotorInputStep.TargetInput = "Pitch";
			configureMotorInputStep.StartingInput = "Throttle";
			tutorial.LastStep.InitiallySelectedPartId = partId2;
			tutorial.LastStep.FocusPartId = partId2;
			stepText = "Excellent! I've never seen a better car! I'm really proud of us!";
			tutorial.QueueStep(new LaunchStep(tutorial), stepText).InstructionText = "Now click the launch button at the top right and launch this magnificent creation from the Juno Village Runway.";
			tutorial.LastStep.CameraZoom = 5f;
			tutorial.LastStep.FocusPartId = tutorial.GetPartId("Fuel Tank");
			tutorial.LastStep.CameraRotation = new Vector2(30f, 135f);
		}
	}
}
