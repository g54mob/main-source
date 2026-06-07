using System.Linq;
using Assets.Scripts.Flight.GameView;
using Assets.Scripts.Flight.GameView.Cameras;
using Assets.Scripts.Levels.Requirements;
using ModApi.Craft.Parts;
using ModApi.Levels.Requirements;
using ModApi.Math;
using UnityEngine;

namespace Assets.Scripts.Levels.LevelScripts
{
	public class DockingPractice : FlightTutorialBase
	{
		private DockingRequirement _dockRequirement;

		private PartData _targetDockingPort;

		public override string GetPersistentMessage()
		{
			if (!Game.InFlightScene || _dockRequirement == null)
			{
				return "Dock with Satellite";
			}
			if (_dockRequirement.Status == LevelRequirementStatus.Pass)
			{
				return "Docked! (" + Units.GetStopwatchTimeString(Score) + ")";
			}
			if (_dockRequirement.DockAmount > 0f)
			{
				return "Docking " + Units.GetPercentageString(_dockRequirement.DockAmount) + " (" + Units.GetStopwatchTimeString(Score) + ")";
			}
			return "Dock with Satellite (" + Units.GetStopwatchTimeString(Score) + ")";
		}

		public override void InitializeRequirements()
		{
			base.InitializeRequirements();
			_dockRequirement = new DockingRequirement(this, "Satellite");
			AddLevelRequirement(_dockRequirement);
			_targetDockingPort = null;
			GameViewScript obj = base.FlightScene.ViewManager.GameView as GameViewScript;
			CameraMode modeOrbitPlanetAligned = obj.CameraControllerManager.DefaultModes.ModeOrbitPlanetAligned;
			OrbitCameraController obj2 = modeOrbitPlanetAligned.CameraController as OrbitCameraController;
			obj2.SetZoom(15f);
			obj2.SetRotation(new Vector3(34f, 21.5f, 0f));
			obj.CameraControllerManager.SelectCameraMode(modeOrbitPlanetAligned);
		}

		protected override void OnFlightLateUpdate()
		{
			base.OnFlightLateUpdate();
			if (!base.IsComplete)
			{
				Score = (float)base.Timer.ElapsedSeconds;
				if (base.AllRequirementsPassed)
				{
					base.TutorialPanel.Visible = false;
					base.Timer.Stop();
					CompleteLevel(success: true, Score);
				}
				else if (base.AnyRequirementFailed)
				{
					base.TutorialPanel.Visible = false;
					base.Timer.Stop();
					CompleteLevel(success: false, 0f);
				}
			}
			if (_targetDockingPort == null)
			{
				_targetDockingPort = _dockRequirement.TargetCraft?.Data.Assembly.Parts.Where((PartData x) => x.Id == 106).FirstOrDefault();
				return;
			}
			base.State.EnsureBegin();
			if (base.State.Step == 0)
			{
				base.State?.EnsureGameView()?.SetStepText("First we need to select the satellite's docking port.")?.EnsurePartIsSelected(_targetDockingPort.PartScript)?.SetStepText("Now we need to set it as our target.")?.EnsurePartIsTargeted(_targetDockingPort.PartScript)?.DeselectPart()?.CompleteStep();
			}
			else if (base.State.Step == 1)
			{
				base.State?.EnsureGameView()?.SetStepText("Now lock your craft's heading on the target.")?.EnsureTargetLock()?.SetStepText("Turn on the analog sticks so you can control your craft.")?.EnsureAnalogSticksVisible()?.SetStepText("Now enable Translation Mode so that you can move your craft in straight lines instead of rotating.")?.EnsureTranslationModeEnabled()?.SetStepText("Now carefully approach the craft until your docking port touches its docking port. ")?.EnsureDocked(_dockRequirement)?.CompleteStep();
			}
			else
			{
				base.TutorialPanel.Visible = false;
			}
		}

		protected override void OnFlightSceneReady()
		{
			base.OnFlightSceneReady();
			base.Timer.Start();
		}
	}
}
