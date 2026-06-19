using System;
using I2.Loc;

namespace TH20.UI
{
	public class EmergencyStatsMenu : AnimatedMenuBase
	{
		private AmbulanceLeagueMenu[] _ambulanceLeagueMenus;

		private Level _level;

		private TopDownCameraLogic _cameraLogic;

		private TimelineManager _timelineManager;

		public void Setup(Level level)
		{
			_level = level;
			_cameraLogic = _level.CameraLogic;
			_ambulanceLeagueMenus = GetComponentsInChildren<AmbulanceLeagueMenu>();
			_timelineManager = _level.TimelineManager;
			LocalizationManager.OnLocalizeEvent += OnLocalize;
			TimelineManager timelineManager = _timelineManager;
			timelineManager.OnTimelineUpdated = (Action<int, int, int>)Delegate.Combine(timelineManager.OnTimelineUpdated, new Action<int, int, int>(OnTimelineUpdated));
			Initialise();
		}

		public override void CloseMenu()
		{
			if (_cameraLogic != null)
			{
				_cameraLogic.SetFixedTransform(null);
			}
			LocalizationManager.OnLocalizeEvent -= OnLocalize;
			TimelineManager timelineManager = _timelineManager;
			timelineManager.OnTimelineUpdated = (Action<int, int, int>)Delegate.Remove(timelineManager.OnTimelineUpdated, new Action<int, int, int>(OnTimelineUpdated));
			base.CloseMenu();
		}

		private void Initialise()
		{
			if (_cameraLogic != null)
			{
				_cameraLogic.SetFixedTransform(_cameraLogic.CameraComponent.transform);
			}
			AmbulanceLeagueMenu[] ambulanceLeagueMenus = _ambulanceLeagueMenus;
			for (int i = 0; i < ambulanceLeagueMenus.Length; i++)
			{
				ambulanceLeagueMenus[i].Setup(_level);
			}
		}

		private void OnLocalize()
		{
		}

		private void OnTimelineUpdated(int day, int month, int year)
		{
			if (day == 1)
			{
				Initialise();
			}
		}
	}
}
