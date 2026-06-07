using Assets.Scripts.Craft.Parts.Modifiers.Fuselage;
using Assets.Scripts.Design.Tutorial.Steps;
using ModApi;
using ModApi.Craft;
using ModApi.Design;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorial.Career
{
	public class FirstPayloadTutorial : DesignerTutorial
	{
		public FirstPayloadTutorial(DesignerScript designer)
			: base(designer, 0.1f, 0.5f)
		{
			base.Tutorial.CraftDesignId = "__designerTutorialFirstPayload__";
			base.GridSize = 0.05f;
			LoadSteps();
		}

		private void LoadSteps()
		{
			TutorialScript tutorial = base.Tutorial;
			tutorial.LoadedPartIds.AddRange(new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 });
			if (Device.IsMobileBuild)
			{
				tutorial.DefaultCameraOffset = new Vector3(0f, -0.5f, 0f);
			}
			string stepText = "Let's start with the same rocket we built for the Vertical Shot contract, minus the nose cone.";
			tutorial.QueueStep(new InfoStep(tutorial), stepText);
			tutorial.LastStep.FocusPartId = tutorial.GetPartId("Fuel Tank Top");
			tutorial.LastStep.CameraZoom = 5f;
			tutorial.LastStep.CameraRotation = new Vector2(30f, 30f);
			stepText = "First let's attach the payload. This is what the customer wants us to bring to space, so be careful with it and try not to damage it.";
			int partId = tutorial.GetPartId("Payload Fairing Base");
			tutorial.QueueAddPartStep(partId, "Sounding Rocket Payload", stepText);
			int[] collection = new int[4]
			{
				partId,
				tutorial.GetPartId("Payload Attachment"),
				tutorial.GetPartId("Payload Fairing Nose Cone"),
				tutorial.GetPartId("Payload")
			};
			tutorial.LastStep.HighlightPartIds.AddRange(collection);
			tutorial.LoadedPartIds.AddRange(collection);
			tutorial.LastStep.CameraZoom = 2.5f;
			tutorial.LastStep.CameraRotation = new Vector2(30f, 30f);
			tutorial.LastStep.CameraFocusOffset += Vector3.zero;
			stepText = "Now, let's add an 'Interstage'. It splits the rocket into multiple 'stages' but more on that later.";
			int interstageId = tutorial.GetPartId("Interstage");
			AddFuselageStep interstageStep = tutorial.QueueAddFuselagePartStep(interstageId, "Interstage", updatePosition: true, stepText);
			interstageStep.CameraRotation = new Vector2(0f, 0f);
			interstageStep.PlacementCriteria = AddPartStep.PartPlacementCriteria.AttachPoint;
			stepText = "Now let's add another fuel tank below this, but we will make it a bit fatter so it can hold more fuel.";
			tutorial.QueueAddFuselagePartStep(tutorial.GetPartId("Fuel Tank Bottom"), "Fuel Tank", updatePosition: true, stepText).RequireRadius = true;
			tutorial.LastStep.CraftDataLoaded = delegate(CraftData craft)
			{
				FuselageData modifier = craft.Assembly.GetPartById(interstageId).GetModifier<FuselageData>();
				modifier.BottomScale = interstageStep.DesignerFuselage.BottomScale;
				modifier.Script?.UpdateMeshes(updateNormalSmoothing: true);
			};
			tutorial.LastStep.CameraZoom = 6.5f;
			tutorial.LastStep.CameraRotation = new Vector2(0f, 0f);
			stepText = "Now let's connect an engine to this fuel tank.";
			tutorial.QueueAddPartStep(tutorial.GetPartId("Engine-Bottom-1"), "Goblin Solid Motor", stepText);
			tutorial.LastStep.CameraZoom = 1.5f;
			tutorial.LastStep.CameraRotation = new Vector2(-30f, 0f);
			tutorial.LastStep.CameraFocusOffset += Vector3.zero;
			stepText = "Now let's duplicate this engine because we need more thrust.";
			int partId2 = tutorial.GetPartId("Engine-Bottom-1");
			tutorial.QueueStep(new SymmetryStep(partId2, "Goblin Solid Motor", tutorial, SymmetryMode.Radial3), stepText);
			tutorial.LastStep.InitiallySelectedPartId = partId2;
			tutorial.LastStep.FocusPartId = partId2;
			tutorial.LastStep.CameraZoom = 2.5f;
			tutorial.LastStep.CameraRotation = new Vector2(-30f, 0f);
			tutorial.LastStep.CameraFocusOffset += Vector3.zero;
			tutorial.LoadedSymmetricPartIds.Add(partId2);
			tutorial.LoadedSymmetricPartIds.Add(tutorial.GetPartId("Engine-Bottom-2"));
			tutorial.LoadedSymmetricPartIds.Add(tutorial.GetPartId("Engine-Bottom-3"));
			stepText = "Now let's add some fins to the bottom stage for more stabilization. We can clone the fins from the upper stage to save us some work.";
			int partId3 = tutorial.GetPartId("Fin-Bottom-1");
			AddPartStep addPartStep = tutorial.QueueAddPartStep(partId3, "Fin", stepText);
			addPartStep.ClonePartId = tutorial.GetPartId("Fin-Top-1");
			addPartStep.RecenterAfterClone = true;
			tutorial.LastStep.ReselectPart = false;
			tutorial.LastStep.CenterOnTarget = false;
			tutorial.LastStep.FocusPartId = tutorial.GetPartId("Fin-Top-1");
			tutorial.LastStep.CameraZoom = 3f;
			tutorial.LastStep.CameraAnimationDuration = 2.5f;
			tutorial.LastStep.CameraRotation = new Vector2(0f, 45f);
			tutorial.LastStep.CameraFocusOffset += new Vector3(0f, -0.5f, 0f);
			stepText = "Enable symmetry for this fin.";
			tutorial.QueueStep(new SymmetryStep(partId3, "Fin", tutorial, SymmetryMode.Radial3), stepText);
			tutorial.LastStep.InitiallySelectedPartId = partId3;
			tutorial.LastStep.FocusPartId = partId3;
			tutorial.LastStep.CameraZoom = 2f;
			tutorial.LastStep.CameraRotation = new Vector2(30f, 45f);
			tutorial.LoadedSymmetricPartIds.Add(tutorial.GetPartId("Fin-Bottom-1"));
			tutorial.LoadedSymmetricPartIds.Add(tutorial.GetPartId("Fin-Bottom-2"));
			tutorial.LoadedSymmetricPartIds.Add(tutorial.GetPartId("Fin-Bottom-3"));
			stepText = string.Empty;
			StagingStep stagingStep = tutorial.QueueStep(new StagingStep(tutorial.GetPartId("Second Stage Engine"), tutorial), stepText);
			stagingStep.ReselectPart = false;
			stagingStep.FocusPartId = interstageId;
			stagingStep.CameraZoom = 8f;
			stagingStep.CameraRotation = new Vector2(30f, 45f);
			stagingStep.InitialStageIndex = 2;
			stagingStep.TargetStageIndex = 1;
			stagingStep.MainText = "Normally staging is calculated automatically, but it's a good idea to check it before launching.\n\nThe Second Stage Engine should actually be in Stage 2 so it can activate and do its thing before the payload is deployed.";
			stepText = "Excellent! You have built a multi-stage rocket!";
			tutorial.QueueStep(new LaunchStep(tutorial), stepText).InstructionText = "Now click the Launch button and see how it flies.";
			tutorial.LastStep.CameraZoom = 10.5f;
			tutorial.LastStep.FocusPartId = interstageId;
			tutorial.LastStep.CameraRotation = new Vector2(30f, 45f);
		}
	}
}
