using Loxodon.Framework.ViewModels;
using Services;
using Services.Missions;
using UI.HUD;

namespace Mail
{
	public class MailMissionContentViewModel : ViewModelBase
	{
		private bool _isMissionAccepted;

		private bool _isMissionCompleted;

		private bool _isRewardCollected;

		private string _missionDescription;

		private string _missionReward;

		private string _buttonText;

		private readonly MissionDefinition _missionDefinition;

		private readonly IMissionService _missionService;

		private readonly IMoneyService _moneyService;

		private readonly PlayerHUDView _playerHUD;

		public bool IsMissionAccepted
		{
			get
			{
				return _isMissionAccepted;
			}
			set
			{
				Set(ref _isMissionAccepted, value, "IsMissionAccepted");
			}
		}

		public bool IsMissionCompleted
		{
			get
			{
				return _isMissionCompleted;
			}
			set
			{
				Set(ref _isMissionCompleted, value, "IsMissionCompleted");
			}
		}

		public bool IsRewardCollected
		{
			get
			{
				return _isRewardCollected;
			}
			set
			{
				Set(ref _isRewardCollected, value, "IsRewardCollected");
			}
		}

		public string MissionDescription
		{
			get
			{
				return _missionDescription;
			}
			set
			{
				Set(ref _missionDescription, value, "MissionDescription");
			}
		}

		public string MissionReward
		{
			get
			{
				return _missionReward;
			}
			set
			{
				Set(ref _missionReward, value, "MissionReward");
			}
		}

		public string ButtonText
		{
			get
			{
				return _buttonText;
			}
			set
			{
				Set(ref _buttonText, value, "ButtonText");
			}
		}

		public bool AcceptButtonEnabled => !IsMissionAccepted;

		public bool CollectButtonEnabled
		{
			get
			{
				if (IsMissionCompleted)
				{
					return !IsRewardCollected;
				}
				return false;
			}
		}

		public MailMissionContentViewModel(IMissionService missionService, IMoneyService moneyService, PlayerHUDView playerHUDView, MissionDefinition def)
		{
			_missionService = missionService;
			_moneyService = moneyService;
			_playerHUD = playerHUDView;
			_missionDefinition = def;
			MissionDescription = def.Description;
			MissionReward = $"Expected Reward For Completion: {def.Reward.FlyCoins}";
			if (_missionService.GetCompleted(def.MissionId) != null)
			{
				_isMissionAccepted = true;
				_isMissionCompleted = true;
				_buttonText = "Mission Completed";
				_isRewardCollected = _missionService.IsRewardCollected(def.MissionId);
			}
			else if (_missionService.GetActive(def.MissionId) != null)
			{
				_isMissionAccepted = true;
				_buttonText = "Mission Accepted";
			}
			else
			{
				_buttonText = "Accept Mission";
			}
			_missionService.OnMissionCompleted += OnMissionCompleted;
		}

		private void OnMissionCompleted(MissionInstance instance)
		{
			if (!(_missionDefinition.MissionId != instance.MissionId))
			{
				IsMissionCompleted = true;
				IsMissionAccepted = true;
				ButtonText = "Mission Completed";
			}
		}

		public void AcceptMissionCommand()
		{
			if (!IsMissionAccepted)
			{
				IsMissionAccepted = true;
				ButtonText = "Mission Accepted";
				_missionService.StartMission(_missionDefinition);
			}
		}

		public void CollectRewardCommand()
		{
			if (CollectButtonEnabled)
			{
				_moneyService.AddCurrency(_missionDefinition.Reward.FlyCoins);
				_playerHUD.InfoMessageSender.SendMoneyMessage(_missionDefinition.Reward.FlyCoins);
				_missionService.MarkRewardCollected(_missionDefinition.MissionId);
				IsRewardCollected = true;
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_missionService.OnMissionCompleted -= OnMissionCompleted;
			}
			base.Dispose(disposing);
		}
	}
}
