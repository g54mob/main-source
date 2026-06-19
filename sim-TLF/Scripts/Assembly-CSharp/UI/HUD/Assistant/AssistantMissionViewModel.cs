using Loxodon.Framework.ViewModels;

namespace UI.HUD.Assistant
{
	public class AssistantMissionViewModel : ViewModelBase
	{
		private string _id;

		private bool _completed;

		private bool _objectiveCountable;

		private int _objectiveCount;

		private int _currentCount;

		private int _missionCount;

		private string _description;

		public string Id => _id;

		public int MissionCount
		{
			get
			{
				return _missionCount;
			}
			set
			{
				Set(ref _missionCount, value, "MissionCount");
			}
		}

		public string DescriptionCount => $"{_currentCount}/{_objectiveCount}";

		public int ObjectiveCount
		{
			get
			{
				return _objectiveCount;
			}
			set
			{
				Set(ref _objectiveCount, value, "ObjectiveCount");
			}
		}

		public bool ObjectiveCountable
		{
			get
			{
				return _objectiveCountable;
			}
			set
			{
				Set(ref _objectiveCountable, value, "ObjectiveCountable");
			}
		}

		public bool Completed
		{
			get
			{
				return _completed;
			}
			set
			{
				Set(ref _completed, value, "Completed");
			}
		}

		public string Description
		{
			get
			{
				return _description;
			}
			set
			{
				Set(ref _description, value, "Description");
			}
		}

		public AssistantMissionViewModel(string id, bool objectiveCountable = false)
		{
			_id = id;
			_objectiveCountable = objectiveCountable;
		}
	}
}
