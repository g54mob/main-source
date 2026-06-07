using Assets.Scripts.Flight;
using Assets.Scripts.Flight.MapView;
using Assets.Scripts.Flight.UI;
using Assets.Scripts.Menu.Tutorial;
using ModApi.Flight.UI;

namespace Assets.Scripts.Levels.LevelScripts.FlightTutorial
{
	public class FlightTutorialPanelScript : TutorialPanelBaseScript, IFlightTutorialPanel
	{
		private MapViewScript MapView => Game.Instance.FlightScene.ViewManager.MapViewManager.MapView as MapViewScript;

		public override void CloseTutorial()
		{
			base.CloseTutorial();
			(FlightSceneScript.Instance.FlightSceneUI as FlightSceneInterfaceScript).UiController.ScoochAnalogControlsUp = false;
			MapView.PlayerCraft.ManeuverNodeManager.ManeuverNodeCreationEnabled = true;
		}

		protected override void Start()
		{
			base.Start();
			(FlightSceneScript.Instance.FlightSceneUI as FlightSceneInterfaceScript).UiController.ScoochAnalogControlsUp = true;
		}
	}
}
