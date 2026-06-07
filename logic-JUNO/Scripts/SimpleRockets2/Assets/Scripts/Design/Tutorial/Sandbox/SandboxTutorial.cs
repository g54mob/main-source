using Assets.Scripts.Design.Tutorial.Steps;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorial.Sandbox
{
	public class SandboxTutorial : DesignerTutorial
	{
		public SandboxTutorial(DesignerScript designer)
			: base(designer, 1f, 1f)
		{
			base.Tutorial.CraftDesignId = "__designerTutorial1__";
			base.GridSize = 0.2f;
			LoadSteps();
		}

		protected override void OnTutorialComplete(TutorialScript tutorial)
		{
			base.OnTutorialComplete(tutorial);
			base.Designer.Exit();
		}

		private void LoadSteps()
		{
			TutorialScript tutorial = base.Tutorial;
			tutorial.LoadedPartIds.Add(0);
			AddDesignerIntoSteps(tutorial, 10f);
			string stepText = "Let's start building. The first step is to add a fuel tank below the Command Pod.";
			AddFuselageStep addFuselageStep = tutorial.QueueAddFuselagePartStep(1, "Fuel Tank", updatePosition: true, stepText);
			addFuselageStep.CameraZoom = 15f;
			addFuselageStep.CameraFocusOffset = new Vector3(0f, -4f, 0f);
			addFuselageStep.CameraRotation = Vector2.zero;
			stepText = "Now let's connect a small engine to this fuel tank. Engines draw fuel from the fuel tanks directly above them.";
			tutorial.QueueAddPartStep(2, "Pixie Engine", stepText).CameraFocusOffset = new Vector3(0f, -3f, 0f);
			stepText = "Now let's connect an 'Interstage'. It splits the rocket into multiple 'stages' but more on that later.";
			AddPartStep addPartStep = tutorial.QueueAddPartStep(3, "Interstage", stepText);
			addPartStep.CameraFocusOffset = new Vector3(0f, -3f, 0f);
			addPartStep.PlacementCriteria = AddPartStep.PartPlacementCriteria.AttachPoint;
			stepText = "Let's add another, larger fuel tank below the Interstage.";
			tutorial.QueueAddFuselagePartStep(4, "Fuel Tank", updatePosition: true, stepText).CameraFocusOffset = new Vector3(0f, -1.5f, 0f);
			stepText = "Connect a more powerful engine to this fuel tank.";
			tutorial.QueueAddPartStep(5, "Mage Engine", stepText).CameraFocusOffset = new Vector3(0f, -3f, 0f);
			stepText = "We're going to add side boosters, but first we need to add a 'Side Interstage' that it can connect to.";
			AddPartStep addPartStep2 = tutorial.QueueAddPartStep(6, "Side Interstage", stepText);
			addPartStep2.CameraFocusOffset = new Vector3(0f, -1f, 0f);
			addPartStep2.CameraRotation = new Vector2(30f, 45f);
			addPartStep2.CameraZoom = 6f;
			stepText = "Add another fuel tank here. If you have trouble connecting, try dragging your mouse directly on top of the Side Interstage part we just added.";
			AddFuselageStep addFuselageStep2 = tutorial.QueueAddFuselagePartStep(7, "Fuel Tank", updatePosition: false, stepText);
			addFuselageStep2.CameraZoom = 15f;
			addFuselageStep2.CameraFocusOffset = new Vector3(0f, -1.5f, 0f);
			addFuselageStep2.CameraRotation = new Vector2(0f, 90f);
			addFuselageStep2.MultipleGreenArrows = true;
			stepText = "Add another engine under this side fuel tank.";
			AddPartStep addPartStep3 = tutorial.QueueAddPartStep(8, "Mage Engine", stepText);
			addPartStep3.ClonePartId = 5;
			addPartStep3.CameraRotation = Vector2.zero;
			addPartStep3.CameraFocusOffset = new Vector3(0f, -4f, 0f);
			stepText = "Let's add a nose cone to help reduce drag.";
			tutorial.QueueAddPartStep(12, "Nose Cone", stepText);
			stepText = "Now we can enable Symmetry Mode on this part so we can duplicate our work over to the other side.";
			SymmetryStep symmetryStep = new SymmetryStep(6, "Side Interstage", tutorial);
			symmetryStep.FocusPartId = 6;
			symmetryStep.CameraZoom = 9f;
			symmetryStep.CameraFocusOffset = new Vector3(0f, -1f, 0f);
			symmetryStep.CameraRotation = new Vector2(0f, 0f);
			tutorial.QueueStep(symmetryStep, stepText);
			tutorial.LoadedSymmetricPartIds.Add(6);
			tutorial.LoadedSymmetricPartIds.Add(7);
			tutorial.LoadedSymmetricPartIds.Add(8);
			tutorial.LoadedSymmetricPartIds.Add(12);
			stepText = "Solar panels are fun, let's add some of those.";
			AddPartStep addPartStep4 = tutorial.QueueAddPartStep(14, "Solar Panel Array", stepText);
			addPartStep4.CameraRotation = new Vector2(30f, 45f);
			addPartStep4.CameraZoom = 7f;
			addPartStep4.CameraFocusOffset = new Vector3(0f, -1f, 0f);
			stepText = "Let's enable Symmetry Mode on this Solar Panel Array to duplicate our work to the other side of the rocket.";
			SymmetryStep symmetryStep2 = new SymmetryStep(14, "Solar Panel Array", tutorial);
			symmetryStep2.InitiallySelectedPartId = 14;
			symmetryStep2.CameraFocusOffset = addPartStep4.CameraFocusOffset;
			tutorial.QueueStep(symmetryStep2, stepText);
			tutorial.LoadedSymmetricPartIds.Add(14);
			stepText = "Like many other parts, the Solar Panel Array is highly customizable.\n";
			SolarPanelArrayStep solarPanelArrayStep = new SolarPanelArrayStep(14, "Solar Panel Array", tutorial);
			solarPanelArrayStep.InitiallySelectedPartId = 14;
			solarPanelArrayStep.CameraFocusOffset = addPartStep4.CameraFocusOffset;
			tutorial.QueueStep(solarPanelArrayStep, stepText);
			stepText = string.Empty;
			StagingStep stagingStep = tutorial.QueueStep(new StagingStep(2, tutorial), stepText);
			stagingStep.InitialStageIndex = 0;
			stagingStep.TargetStageIndex = 4;
			stagingStep.MainText = "Normally staging is calculated automatically, but sometimes you need to re-arrange things. I purposely messed up the staging for this rocket, so we'll need to fix it.\n\nThe Pixie Engine should not turn on until after the large boosters have jettisoned. To do this, we need to move it to the last stage.";
			stepText = "Excellent! You have built a multi-stage rocket! You should check out the Flight Tutorial next to learn how to fly this masterpiece!";
			tutorial.QueueStep(new InfoStep(tutorial), stepText);
			tutorial.LastStep.CameraZoom = 19f;
			tutorial.LastStep.FocusPartId = 4;
			tutorial.LastStep.CameraRotation = new Vector2(0f, 0f);
			tutorial.QueueStep(new EndStep(tutorial), stepText);
		}
	}
}
