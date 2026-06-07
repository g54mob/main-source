using SettingScripts;

namespace OneUseScripts
{
	public class SceneScreenShotHandler : ScreenShotHandler
	{
		public static SceneScreenShotHandler instance;

		protected override void Awake()
		{
			base.Awake();
			instance = this;
			ScenarioIndependentSettings.Instance.SimulationSize.Subscribe(OnSimulationSizeChange, call: true);
		}

		private void OnSimulationSizeChange(float val)
		{
			cam.orthographicSize = val;
		}

		private void OnDestroy()
		{
			instance = null;
			ScenarioIndependentSettings.Instance.SimulationSize.UnSubscribe(OnSimulationSizeChange);
		}
	}
}
