using Assets.Scripts.Design.Tutorial.Steps;
using ModApi;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorial.Career
{
	public class FirstRaceTutorial : DesignerTutorial
	{
		public FirstRaceTutorial(DesignerScript designer)
			: base(designer, 0.2f, 0.5f)
		{
			base.GridSize = 0.05f;
			LoadSteps();
		}

		private void LoadSteps()
		{
			TutorialScript tutorial = base.Tutorial;
			tutorial.CraftDesignId = "__designerTutorialFirstRace__";
			tutorial.LoadAllParts = true;
			if (Device.IsMobileBuild)
			{
				tutorial.DefaultCameraOffset = new Vector3(0f, -0.5f, 0f);
			}
			int partId = tutorial.GetPartId("Main Frame");
			string stepText = "Great news! We have an airplane for you, all ready to go!";
			tutorial.QueueStep(new InfoStep(tutorial), stepText);
			tutorial.LastStep.CameraZoom = 6f;
			tutorial.LastStep.FocusPartId = partId;
			tutorial.LastStep.CameraRotation = new Vector2(30f, 135f);
			stepText = "These electric motors spin the propellers to generate thrust. The motors are set to spin in opposite directions so the torque cancels out.<br><br>It's very efficient, but it is also a bit slow. Later on, after you unlock jet engines, you will be able to build much faster airplanes.";
			tutorial.QueueStep(new InfoStep(tutorial), stepText);
			tutorial.LastStep.FocusPartId = tutorial.GetPartId("Left Motor");
			tutorial.LastStep.CameraZoom = 3f;
			tutorial.LastStep.CameraRotation = new Vector2(30f, 115f);
			stepText = "Good luck on your first air race!";
			tutorial.QueueStep(new LaunchStep(tutorial), stepText).InstructionText = "Launch from the Juno Village Runway.";
			tutorial.LastStep.CameraZoom = 6f;
			tutorial.LastStep.FocusPartId = partId;
			tutorial.LastStep.CameraRotation = new Vector2(30f, 135f);
		}
	}
}
