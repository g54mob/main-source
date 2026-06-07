using System.Linq;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Design.Tutorial.Steps;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Design;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorial.Career
{
	public class VerticalShotTutorial : DesignerTutorial
	{
		public VerticalShotTutorial(DesignerScript designer)
			: base(designer, 0.1f, 0.5f)
		{
			base.Tutorial.CraftDesignId = "__designerTutorialVerticalShot__";
			base.GridSize = 0.05f;
			LoadSteps();
		}

		private void LoadSteps()
		{
			TutorialScript tutorial = base.Tutorial;
			tutorial.LoadedPartIds.Add(0);
			AddDesignerIntoSteps(tutorial, 2.5f);
			string stepText = "Let's build a rocket! The first step is to add a fuel tank below the Command Disc.";
			tutorial.QueueAddFuselagePartStep(tutorial.GetPartId("Fuel Tank"), "Fuel Tank", updatePosition: true, stepText);
			tutorial.LastStep.CameraZoom = 5f;
			tutorial.LastStep.CameraRotation = new Vector2(0f, 0f);
			tutorial.LastStep.CameraFocusOffset = new Vector3(0f, -0.75f, 0f);
			stepText = "Now let's add a nose cone to help reduce drag.";
			AddFuselageStep addFuselageStep = tutorial.QueueAddFuselagePartStep(tutorial.GetPartId("Nose Cone"), "Nose Cone", updatePosition: true, stepText);
			addFuselageStep.FlipDeltaPosition = true;
			addFuselageStep.CameraZoom = 2.5f;
			stepText = "Now connect an engine to this fuel tank. Engines draw fuel from the fuel tanks directly above them.";
			tutorial.QueueAddPartStep(tutorial.GetPartId("Goblin Solid Motor"), "Goblin Solid Motor", stepText);
			tutorial.LastStep.CameraZoom = 1.25f;
			tutorial.LastStep.CameraRotation = new Vector2(-30f, 0f);
			tutorial.LastStep.CameraFocusOffset = new Vector3(0f, 0f, 0f);
			stepText = "Now let's add some fins to help stabilize this beautiful creation.";
			int partId = tutorial.GetPartId("Fin 1");
			tutorial.LoadedPartIds.Add(partId);
			AddWingPartStep addWingPartStep = tutorial.QueueStep(new AddWingPartStep(partId, tutorial, "Fin"), stepText);
			addWingPartStep.CameraZoom = 2.5f;
			addWingPartStep.CameraRotation = new Vector2(30f, -60f);
			addWingPartStep.ResizeCameraZoom = 2.5f;
			addWingPartStep.ResizeCameraRotation = new Vector2(0f, 270f);
			addWingPartStep.CameraFocusOffset = new Vector3(0f, -0.25f, 0f);
			stepText = "Now we can enable Symmetry Mode on this fin so we can duplicate our work instead of having to add each fin individually.";
			tutorial.QueueStep(new SymmetryStep(partId, "Fin", tutorial, SymmetryMode.Radial4), stepText);
			tutorial.LastStep.InitiallySelectedPartId = partId;
			tutorial.LastStep.FocusPartId = partId;
			tutorial.LastStep.CameraZoom = 2.5f;
			tutorial.LastStep.CameraRotation = new Vector2(30f, -60f);
			tutorial.LastStep.CameraFocusOffset = new Vector3(0f, 0f, 0f);
			tutorial.LoadedSymmetricPartIds.Add(tutorial.GetPartId("Fin 1"));
			tutorial.LoadedSymmetricPartIds.Add(tutorial.GetPartId("Fin 2"));
			tutorial.LoadedSymmetricPartIds.Add(tutorial.GetPartId("Fin 3"));
			tutorial.LoadedSymmetricPartIds.Add(tutorial.GetPartId("Fin 4"));
			stepText = "Now let's enable the gyro on the Command Disc. The gyro can help to stabilize the rocket when it's in flight.";
			int commandDiscId = tutorial.GetPartId("Command Disc");
			CommandPodConfigurationStep commandPodConfigurationStep = tutorial.QueueStep(new CommandPodConfigurationStep(commandDiscId, "Command Disc", tutorial), stepText);
			commandPodConfigurationStep.TargetType = CrafConfigurationType.Rocket;
			commandPodConfigurationStep.TargetGyro = 0.25f;
			tutorial.LastStep.InitiallySelectedPartId = commandDiscId;
			tutorial.LastStep.FocusPartId = commandDiscId;
			tutorial.LastStep.CameraZoom = 1.5f;
			tutorial.LastStep.CameraRotation = new Vector2(0f, 0f);
			tutorial.LastStep.CameraFocusOffset = new Vector3(0f, 0f, 0f);
			tutorial.LastStep.CraftDataLoaded = delegate(CraftData craftData)
			{
				craftData.Assembly.Parts.Where((PartData x) => x.Id == commandDiscId).First().GetModifier<CommandPodData>()
					.Gyros = 0f;
			};
			stepText = "Excellent! You have built your first rocket!";
			tutorial.QueueStep(new LaunchStep(tutorial), stepText).InstructionText = "Click the launch button at the top right and launch from the Juno Village Pad.";
			tutorial.LastStep.ReselectPart = false;
			tutorial.LastStep.CameraZoom = 5f;
			tutorial.LastStep.FocusPartId = tutorial.GetPartId("Fuel Tank");
			tutorial.LastStep.CameraRotation = new Vector2(30f, 30f);
		}
	}
}
