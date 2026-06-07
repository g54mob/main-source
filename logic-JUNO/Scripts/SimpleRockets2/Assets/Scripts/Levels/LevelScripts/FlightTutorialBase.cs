using Assets.Scripts.Levels.LevelScripts.FlightTutorial;
using Assets.Scripts.Ui;
using ModApi.Levels;
using ModApi.Ui;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Levels.LevelScripts
{
	public class FlightTutorialBase : Level
	{
		public FlightTutorialPanelScript TutorialPanel { get; private set; }

		protected FlightTutorialState State { get; private set; }

		public override void InitializeRequirements()
		{
			State = new FlightTutorialState(base.PlayerCraft, delegate(string s)
			{
				OnPlayerLose(s);
			});
		}

		public void OnPlayerLose(string message)
		{
			TutorialPanel.StepText = string.Empty;
			TutorialPanel.InstructionText = message;
			CompleteLevel(success: false, 0f);
		}

		protected override void OnFlightSceneReady()
		{
			base.OnFlightSceneReady();
			base.Timer.Start();
			GameObject gameObject = UiUtilities.CreateUiGameObject("TutorialPanel", base.FlightScene.FlightSceneUI.Transform);
			TutorialPanel = gameObject.AddComponent<FlightTutorialPanelScript>();
			Game.Instance.UserInterface.BuildUserInterfaceFromResource("Ui/Xml/Flight/FlightTutorialPanel", TutorialPanel, delegate(IXmlLayoutController x)
			{
				TutorialPanel.OnLayoutRebuilt((XmlLayout)x.XmlLayout);
			});
			State.TutorialPanel = TutorialPanel;
		}

		protected override void OnFlightSceneUnloading()
		{
			base.OnFlightSceneUnloading();
			TutorialPanel = null;
		}
	}
}
