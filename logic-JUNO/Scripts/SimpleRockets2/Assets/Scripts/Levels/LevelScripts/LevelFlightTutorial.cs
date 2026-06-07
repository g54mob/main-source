using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Flight.GameView;
using Assets.Scripts.Flight.GameView.Cameras;
using Assets.Scripts.Input;
using UnityEngine;

namespace Assets.Scripts.Levels.LevelScripts
{
	public class LevelFlightTutorial : FlightTutorialBase
	{
		private bool _debugSkip;

		public override string GetPersistentMessage()
		{
			return "Flight Tutorial";
		}

		public override void InitializeRequirements()
		{
			base.InitializeRequirements();
			base.FlightScene.FlightSceneUI.SetNavSphereVisibility(visible: false, updateSettings: false);
			GameViewScript obj = base.FlightScene.ViewManager.GameView as GameViewScript;
			CameraMode modeOrbitPlanetAligned = obj.CameraControllerManager.DefaultModes.ModeOrbitPlanetAligned;
			(modeOrbitPlanetAligned.CameraController as OrbitCameraController).SetZoom(30f);
			obj.CameraControllerManager.SelectCameraMode(modeOrbitPlanetAligned);
		}

		protected override void OnFlightLateUpdate()
		{
			base.OnFlightLateUpdate();
			Score = 0f;
			if (DebugInput.GetKeyDown(KeyCode.K))
			{
				_debugSkip = !_debugSkip;
				Debug.Log("Debug Skip: " + _debugSkip);
			}
			else if (_debugSkip)
			{
				return;
			}
			base.State.EnsureBegin();
			if (base.State.Step == 0)
			{
				base.State?.SetStepLimits(0, 500)?.SetStepText("Let me show you how to get this craft into orbit. I may pause the game periodically so you'll have time to adjust the controls.")?.SetPauseIfFailed(value: true)?.EnsureGameView()?.EnsureNavSphereVisible(visible: true)?.EnsureHeadingLock()?.SetStepText("The Nav Sphere controls your craft's heading. When Heading Lock is enabled, your craft will always try to point towards the blue triangle. The white cone is the direction your craft is currently pointing.")?.EnsureButtonClicked("NavSphereIntro")?.EnsureNavSpherePitch(90)?.EnsureNavSphereHeadingEast()?.SetStepText("Prepare for blast off.")?.EnsureThrottle(1f)?.EnsureNotPaused()?.SetStepText("Time to blast off!")?.EnsureStage(1, "%ActivateInstruction% to activate your first stage. This will activate your engines.")?.CompleteStep();
				return;
			}
			if (base.State.Step == 1)
			{
				base.State?.SetStepLimits(0, 1250)?.SetPauseIfFailed(value: true)?.SetStepText("Keep going until your altitude is about 1,000m.")?.EnsureGameView()?.EnsureNavSphereSettings(90, 90)?.EnsureThrottle(1f)?.EnsureNotPaused()?.EnsureMinimumAltitude(1000f)?.CompleteStep();
				return;
			}
			if (base.State.Step == 2)
			{
				base.State?.SetStepLimits(750, 6000)?.SetPauseIfFailed(value: true)?.EnsureGravityTurn(75, reduceThrottle: true, "Time to start a 'Gravity Turn' so we can start building up lateral speed while we climb.")?.SetStepText("Continue like this until your altitude is about 5,000m")?.EnsureNotPaused()?.EnsureMinimumAltitude(5000f)?.CompleteStep();
				return;
			}
			if (base.State.Step == 3)
			{
				base.State?.SetStepLimits(4000, 16000)?.SetPauseIfFailed(value: true)?.EnsureGravityTurn(45, reduceThrottle: true, "Adjust your Gravity Turn to help increase our lateral speed.")?.SetStepText("Continue like this until your altitude is about 15,000m. We need a lot of lateral speed to get into orbit.")?.EnsureNotPaused()?.EnsureMinimumAltitude(15000f)?.CompleteStep();
				return;
			}
			if (base.State.Step == 4)
			{
				base.State?.SetStepLimits(14000, 0)?.SetPauseIfFailed(value: true)?.EnsureGravityTurn(30, reduceThrottle: false, "Adjust your Gravity Turn for even more lateral speed.")?.SetStepText("Continue like this until your active engines run out of fuel")?.EnsureNotPaused()?.EnsureNoFuel()?.WaitForTimer("NoFuel", 2f)?.CompleteStep();
				return;
			}
			if (base.State.Step == 5)
			{
				base.State?.SetStepLimits(14000, 0)?.SetPauseIfFailed(value: true)?.EnsureGravityTurn(30, reduceThrottle: false, "Adjust your Gravity Turn for even more lateral speed.")?.SetStepText("Great! Now it's time to activate the next two stages, which will jettison those empty fuel tanks and then start your next engine.")?.EnsureButtonClicked("DropTanks")?.EnsureNotPaused()?.SetStepText(string.Empty)?.EnsureStage(2, "%ActivateInstruction% to jettison your empty fuel tanks and engines.")?.EnsureStage(3, "%ActivateInstruction% again to start your next engine.")?.SetStepText("Perfect!")?.WaitForTimer("Post-Stage-3", 2f)?.CompleteStep();
				return;
			}
			if (base.State.Step == 6)
			{
				base.State?.SetStepLimits(16500, 75000)?.SetStepText("You're doing great!")?.SetPauseIfFailed(value: true)?.EnsureHeadingLock()?.EnsureNavSpherePitch(30)?.EnsureNavSphereHeadingEast()?.EnsureThrottle(1f)?.SetStepText("Now, let's take a look at Map View.")?.EnsureMapView()?.EnsureNavSphereVisible(visible: false)?.SetStepText("This is the Map View. First, let's zoom in on your craft.")?.EnsureMapViewZoom(12f, 8f)?.SetStepText("The blue cone is your craft and the blue line is your predicted trajectory/orbit. The green arrow is your 'apoapsis,' which is the highest point along your orbit.")?.EnsureNotTimeWarp()?.EnsureFastForward()?.SetPauseIfFailed(value: false)?.EnsureApoapsisAltitude(125000.0)?.CompleteStep();
				return;
			}
			if (base.State.Step == 7)
			{
				base.State?.SetStepLimits(55000, 0)?.SetPauseIfFailed(value: true)?.SetStepText("Awesome! Now we need to kill the engines and wait.")?.EnsureThrottle(0f, 0f)?.EnsureMapView()?.EnsureMapViewZoom(15f, 8f)?.EnsureNavSphereVisible(visible: false)?.SetStepText("Wait until we are 30 seconds from the apoapsis to do our next burn")?.EnsureNotPaused()?.EnsureMinimumAltitude(80000f)?.EnsureLowTimeWarp(45.0)?.EnsureTimeToApoapsis(140.0, string.Empty)?.EnsureTimeToApoapsis(80.0, "While we're waiting, I just wanted to say thanks for playing our game.")?.EnsureTimeToApoapsis(60.0, string.Empty)?.EnsureTimeToApoapsis(30.0, string.Empty)?.CompleteStep();
				return;
			}
			if (base.State.Step == 8)
			{
				base.State?.SetStepLimits(110000, 0)?.SetPauseIfFailed(value: true)?.EnsureNotTimeWarp()?.EnsureGameView()?.SetStepText("Now we need to Heading Lock our 'prograde.' Prograde just means the direction the craft is moving. This will ensure that we burn efficiently as we reach the peak of our orbit.")?.EnsureNavSphereVisible(visible: true)?.EnsureLockedOnPrograde()?.EnsureThrottle(1f)?.SetStepText("Continue like this until your engine runs out of fuel.")?.EnsureNotPaused()?.EnsureNoFuel()?.CompleteStep();
				return;
			}
			if (base.State.Step == 9)
			{
				base.State?.SetStepLimits(110000, 0)?.SetStepText(string.Empty)?.EnsureStage(4, "%ActivateInstruction% to jettison your empty fuel tank and engine.")?.EnsureStage(5, "%ActivateInstruction% again to start your last engine.")?.SetStepText("Excellent!")?.WaitForTimer("Post-Stage-5", 2f)?.CompleteStep();
				return;
			}
			if (base.State.Step == 10)
			{
				base.State?.SetPauseIfFailed(value: true)?.EnsureNotTimeWarp()?.SetStepText("We're almost there. Now we need to burn until the orange 'periapsis' arrow shows up. The periapsis is the lowest point in our orbit and we want it to be well above the atmosphere.")?.EnsureLockedOnPrograde()?.EnsureThrottle(1f)?.EnsureMapView()?.EnsureMapViewZoom(125f, 50f)?.EnsureNotPaused()?.SetStepText("Continue burning until the orange 'periapsis' arrow appears and is well above the atmosphere.")?.EnsurePeriapsisAltitude(100000.0)?.CompleteStep();
				return;
			}
			if (base.State.Step == 11)
			{
				base.State?.SetPauseIfFailed(value: true)?.SetStepText("You did it! Now kill your engines.")?.EnsureThrottle(0f, 0f)?.SetStepText("Now let's activate those fancy solar panels")?.EnsureGameView()?.EnsureNotPaused()?.EnsureActivationPanelOpen()?.EnsureActivationGroupActive(9)?.SetStepText(string.Empty)?.CompleteStep();
				return;
			}
			base.State?.SetStepText(string.Empty)?.ShowMessage("Congratulations! You have achieved orbit!");
			base.TutorialPanel.StepText = string.Empty;
			CompleteLevel(success: true, 0f);
		}

		protected override void OnFlightSceneReady()
		{
			base.OnFlightSceneReady();
			(base.PlayerCraft.PrimaryCommandPod as CommandPodScript).GetStageActivationPermission = delegate(int stage)
			{
				bool num = stage < base.State.MaxAllowableStage;
				if (!num)
				{
					Debug.Log("Prevented stage activation");
				}
				return num;
			};
			base.State.MapView.MapCameraScript.SetRotationAndZoom(new Vector2(-82f, -75.6f), 8f);
			BodyScript.EnableDragLift = true;
		}
	}
}
