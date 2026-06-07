using System.Linq;
using Assets.Scripts.Design.Tutorial.Steps;
using Assets.Scripts.State.Validation;
using Assets.Scripts.Ui;
using ModApi;
using ModApi.Common.Events;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorial
{
	public class DesignerTutorial
	{
		private float _originalGridSize;

		public DesignerScript Designer { get; }

		public float? GridSize { get; set; }

		public TutorialScript Tutorial { get; private set; }

		public string TutorialId { get; private set; }

		public event SimpleNotificationDelegate TutorialComplete;

		public DesignerTutorial(DesignerScript designer, float? startFuselageScale, float? startWingScale)
		{
			Designer = designer;
			GameObject gameObject = UiUtilities.CreateUiGameObject("Tutorial", Designer.DesignerUi.Transform);
			Tutorial = gameObject.AddComponent<TutorialScript>();
			Tutorial.DesignerScript = Designer;
			Tutorial.Tutorial = this;
			Tutorial.Complete += OnTutorialComplete;
			Designer.DesignerPlatform.AutoResize = true;
			Designer.OnTutorialStarted();
			if (Game.Instance.GameState.Validator is CareerValidator careerValidator)
			{
				careerValidator.StartScaleFuselageOverride = startFuselageScale;
				careerValidator.StartScaleWingOverride = startWingScale;
			}
		}

		public void StartTutorial(string tutorialId)
		{
			TutorialId = tutorialId;
			_originalGridSize = Game.Instance.Settings.Game.Designer.GridSize.Value;
			if (GridSize.HasValue)
			{
				Game.Instance.Settings.Game.Designer.GridSize.Value = GridSize.Value;
			}
			Tutorial.StartTutorial();
		}

		protected void AddDesignerIntoSteps(TutorialScript tut, float zoom, bool invokeDesignerPullout = false)
		{
			string empty = string.Empty;
			if (tut.DesignerScript.CraftScript.Data.Assembly.Parts.Count > 1)
			{
				InfoStep infoStep = new InfoStep(tut, TutorialPanelScript.TutorialPanelType.BackupCraft);
				infoStep.LoadCraft = false;
				empty = "Would you like to back up your current craft before starting the tutorial?";
				tut.QueueStep(infoStep, empty);
			}
			if (!Game.Instance.Settings.SeenNotifications.Contains("Designer-CompletedIntro"))
			{
				empty = "Welcome to the Designer! First, let me show you how to move the view around.";
				CameraStep cameraStep = tut.QueueStep(new CameraStep(tut, CameraStep.CameraStepType.Rotate), empty);
				cameraStep.CameraRotation = new Vector2(30f, 150f);
				cameraStep.InvokeDesignerPullout = invokeDesignerPullout;
				cameraStep.CameraZoom = zoom;
				cameraStep.FocusPartId = 0;
				tut.QueueStep(new CameraStep(tut, CameraStep.CameraStepType.Pan), empty);
				tut.LastStep.InvokeDesignerPullout = invokeDesignerPullout;
				empty = "This is the Command Pod and it's the brain of your rocket. Try to keep it safe. You can't control your rocket without it.";
				InfoStep infoStep2 = tut.QueueStep(new InfoStep(tut), empty);
				infoStep2.CameraRotation = new Vector2(30f, 150f);
				infoStep2.FocusPartId = 0;
				infoStep2.InvokeDesignerPullout = invokeDesignerPullout;
				infoStep2.Complete = delegate
				{
					Game.Instance.Settings.AddNotification("Designer-CompletedIntro");
				};
				if (Device.IsMobileBuild)
				{
					empty = "Before we add a part, let's turn on the Finger Tool. It makes it much easier to place parts with precision. It can also help you to clone parts, but we'll cover that later.";
					tut.QueueStep(new FingerToolStep(tut), empty);
				}
			}
		}

		protected virtual void OnTutorialComplete(TutorialScript tutorial)
		{
			if (Game.Instance.GameState.Validator is CareerValidator careerValidator)
			{
				careerValidator.StartScaleFuselageOverride = null;
				careerValidator.StartScaleWingOverride = null;
			}
			Game.Instance.Settings.Game.Designer.GridSize.Value = _originalGridSize;
			(Game.Instance.Designer as DesignerScript).OnTutorialComplete(Tutorial);
			this.TutorialComplete?.Invoke();
			Game.Instance.Settings.AddNotification(TutorialId);
		}
	}
}
