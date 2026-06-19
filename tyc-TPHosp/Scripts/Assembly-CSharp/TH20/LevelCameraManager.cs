namespace TH20
{
	public class LevelCameraManager : MustCallDestroy
	{
		private TopDownCameraLogic _currentLevelCamera;

		public TopDownCameraLogic CurrentLevelCamera => _currentLevelCamera;

		public void RegisterCamera(TopDownCameraLogic camera)
		{
			_currentLevelCamera = camera;
		}

		public void UnregisterCamera(TopDownCameraLogic camera)
		{
			if (_currentLevelCamera == camera)
			{
				_currentLevelCamera = null;
			}
		}

		public override void Destroy()
		{
			_currentLevelCamera = null;
			base.Destroy();
		}
	}
}
