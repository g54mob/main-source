using Assets.Scripts.Design.Tutorial.Steps;
using ModApi;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorial.Career
{
	public class FirstFlightTutorial : DesignerTutorial
	{
		public FirstFlightTutorial(DesignerScript designer)
			: base(designer, 0.2f, 0.5f)
		{
			base.GridSize = 0.05f;
			LoadSteps();
		}

		private void AddWings(int wingId, int symmetricId, int clonePartId, string initialInput, Vector2? resizeCameraRotation, string stepAdd, string stepControlSurface, string stepSymmetry)
		{
			TutorialScript tutorial = base.Tutorial;
			string stepText = stepAdd;
			tutorial.LoadedPartIds.Add(wingId);
			AddWingPartStep addWingPartStep = tutorial.QueueStep(new AddWingPartStep(wingId, tutorial, "Wing", clonePartId), stepText);
			addWingPartStep.CameraZoom = 4f;
			addWingPartStep.CameraRotation = new Vector2(30f, 315f);
			addWingPartStep.ResizeCameraZoom = 5f;
			addWingPartStep.ResizeCameraRotation = resizeCameraRotation ?? new Vector2(90f, 0f);
			addWingPartStep.CameraFocusOffset += new Vector3(0f, 0f, -1f);
			stepText = stepControlSurface;
			tutorial.QueueStep(new ConfigureControlSurfaceStep(wingId, "Wing", tutorial, initialInput), stepText);
			tutorial.LastStep.InitiallySelectedPartId = wingId;
			if (symmetricId > 0)
			{
				stepText = stepSymmetry;
				tutorial.QueueStep(new SymmetryStep(wingId, "Wing", tutorial), stepText).ClosePanelRequired = false;
				tutorial.LastStep.InitiallySelectedPartId = wingId;
				tutorial.LastStep.FocusPartId = wingId;
				tutorial.LoadedSymmetricPartIds.Add(wingId);
				tutorial.LoadedSymmetricPartIds.Add(symmetricId);
			}
		}

		private void LoadSteps()
		{
			TutorialScript tutorial = base.Tutorial;
			tutorial.CraftDesignId = "__designerTutorialFirstFlight__";
			tutorial.LoadedPartIds.Add(tutorial.GetPartId("Command Disc"));
			tutorial.LoadedPartIds.Add(tutorial.GetPartId("Nose Cone"));
			tutorial.LoadedPartIds.Add(tutorial.GetPartId("Fuel Tank"));
			tutorial.LoadedPartIds.Add(tutorial.GetPartId("Front Left Panel"));
			tutorial.LoadedPartIds.Add(tutorial.GetPartId("Front Right Panel"));
			tutorial.LoadedPartIds.Add(tutorial.GetPartId("Rear Right Panel"));
			tutorial.LoadedPartIds.Add(tutorial.GetPartId("Rear Left Panel"));
			tutorial.LoadedPartIds.Add(tutorial.GetPartId("Front Wheel Right"));
			tutorial.LoadedPartIds.Add(tutorial.GetPartId("Front Wheel Left"));
			tutorial.LoadedPartIds.Add(tutorial.GetPartId("Rear Wheel Right"));
			tutorial.LoadedPartIds.Add(tutorial.GetPartId("Rear Wheel Left"));
			AddDesignerIntoSteps(tutorial, 2.5f, invokeDesignerPullout: true);
			if (Device.IsMobileBuild)
			{
				tutorial.DefaultCameraOffset = new Vector3(0f, -0.5f, 0f);
			}
			string stepText = "I've started with the car from The Jump tutorial but I've made some tweaks to make room for some wings.";
			tutorial.QueueStep(new InfoStep(tutorial), stepText);
			tutorial.LastStep.CameraZoom = 3f;
			tutorial.LastStep.CameraRotation = new Vector2(30f, 30f);
			tutorial.LastStep.CameraFocusOffset += new Vector3(0f, 0.25f, 0f);
			int partId = tutorial.GetPartId("Wing Right");
			AddWings(partId, tutorial.GetPartId("Wing Left"), 0, null, null, "First, we'll need to add the main wings that will provide the lift to get this beauty off the ground.", "Now, add a control surface to this wing so the craft will be able to roll and turn while flying through the air.", "Use the Symmetry Tool and duplicate our work to the other side.");
			int partId2 = tutorial.GetPartId("Elevator Right");
			AddWings(partId2, tutorial.GetPartId("Elevator Left"), partId, "Roll", null, "Now add the elevator, which will allow the craft to pitch upwards and downwards to change its altitude. It's quite important for airplanes.", "The elevator's control surface should respond to Pitch input. Note to self: the wheels are also set to use Pitch, so we'll need to change those later.", "Use the Symmetry Tool and duplicate our work to the other side.");
			AddWings(tutorial.GetPartId("Rudder"), 0, partId2, "Pitch", new Vector3(0f, 270f), "Now add the rudder, which provides stability on the yaw axis. It's a common misconception that the rudder is used for turning, but that's actually the job of the main wings by rolling into the turn. The rudder is used for making minor corrections.", "The rudder's control surface should respond to Yaw input.", null);
			stepText = "Since the elevators are using the Pitch input, we'll need to change the motor input for the wheels to use Throttle. Otherwise when you pull back on the stick to pitch upwards, you will also decrease the motor input.";
			int partId3 = tutorial.GetPartId("Rear Wheel Right");
			ConfigureMotorInputStep configureMotorInputStep = tutorial.QueueStep(new ConfigureMotorInputStep(partId3, "Car Wheel", tutorial), stepText);
			configureMotorInputStep.InputControllerId = "RPM";
			configureMotorInputStep.TargetInput = "Throttle";
			configureMotorInputStep.StartingInput = "Pitch";
			tutorial.LastStep.InitiallySelectedPartId = partId3;
			tutorial.LastStep.FocusPartId = partId3;
			tutorial.LastStep.CameraZoom = 3.25f;
			tutorial.LastStep.CameraRotation = new Vector2(7.5f, 300f);
			stepText = "When designing an airplane, it's very important to consider the relationship between the Center of Mass (CoM) and the Center of Lift (CoL). We can visualize their positions using the View Panel.";
			tutorial.QueueStep(new CenterIndicatorsStep(tutorial), stepText);
			tutorial.LastStep.FocusPartId = tutorial.GetPartId("Fuel Tank");
			tutorial.LastStep.CameraZoom = 6f;
			tutorial.LastStep.CameraRotation = new Vector2(0f, 270f);
			tutorial.LastStep.CameraFocusOffset += new Vector3(0f, -0.5f, 0f);
			stepText = "As you can see, the red Center of Mass is slightly in front of the blue Center of Lift, so this craft should be aerodynamically stable. The further the CoM is in front of the CoL, the more stable it becomes, but it loses some maneuverability and is less responsive to pitch.\n\nThe closer they are, the more aerobatic it becomes but if they are too close then it can become unstable. If the CoM is behind the CoL then it would be like trying to shoot an arrow backwards, feathers first.\n\nTo simplify: the red ball is in front of the blue ball, so this craft is good to go.";
			tutorial.QueueStep(new InfoStep(tutorial), stepText);
			stepText = "Great job! Even the Wright Brothers would be proud!";
			tutorial.QueueStep(new LaunchStep(tutorial), stepText).InstructionText = "Now launch this magnificent creation from the Juno Village Runway. Let's see if this thing can fly!";
			tutorial.LastStep.InitiallySelectedPartId = -1;
			tutorial.LastStep.ReselectPart = false;
			tutorial.LastStep.CameraZoom = 5f;
			tutorial.LastStep.FocusPartId = tutorial.GetPartId("Fuel Tank");
			tutorial.LastStep.CameraRotation = new Vector2(30f, 135f);
		}
	}
}
