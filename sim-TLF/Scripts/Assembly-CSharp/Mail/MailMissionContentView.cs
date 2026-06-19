using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Views;
using Services;
using Services.Missions;
using TMPro;
using UI.HUD;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Mail
{
	public class MailMissionContentView : UIView
	{
		[SerializeField]
		private TextMeshProUGUI _missionDescriptionText;

		[SerializeField]
		private TextMeshProUGUI _missionRewardText;

		[SerializeField]
		private Button _acceptMissionButton;

		[SerializeField]
		private Button _collectRewardButton;

		[SerializeField]
		private TextMeshProUGUI _buttonText;

		[SerializeField]
		private Image _tickImage;

		public string MissionId;

		[Inject]
		private IMissionService _missionService;

		[Inject]
		private IMoneyService _moneyService;

		[Inject]
		private PlayerHUDView _playerHUD;

		[Inject]
		private DiContainer _diContainer;

		[Inject]
		public void Initialize()
		{
			if (!string.IsNullOrEmpty(MissionId))
			{
				MissionDefinition missionDefinition = _missionService.GetActive(MissionId)?.Definition ?? _missionService.GetCompleted(MissionId)?.Definition;
				if (missionDefinition != null)
				{
					MailMissionContentViewModel dataContext = _diContainer.Instantiate<MailMissionContentViewModel>(new object[1] { missionDefinition });
					this.SetDataContext(dataContext);
					CreateBinding();
				}
			}
		}

		public void CreateBinding()
		{
			BindingSet<MailMissionContentView, MailMissionContentViewModel> bindingSet = this.CreateBindingSet<MailMissionContentView, MailMissionContentViewModel>();
			bindingSet.Bind(_missionDescriptionText).For((TextMeshProUGUI v) => v.text).To((MailMissionContentViewModel vm) => vm.MissionDescription)
				.OneWay();
			bindingSet.Bind(_missionRewardText).For((TextMeshProUGUI v) => v.text).To((MailMissionContentViewModel vm) => vm.MissionReward)
				.OneWay();
			bindingSet.Bind(_buttonText).For((TextMeshProUGUI v) => v.text).To((MailMissionContentViewModel vm) => vm.ButtonText)
				.OneWay();
			bindingSet.Bind(_acceptMissionButton).For((Button v) => v.onClick).To((MailMissionContentViewModel vm) => vm.AcceptMissionCommand)
				.OneWay();
			bindingSet.Bind(_acceptMissionButton).For((Button v) => v.interactable).To((MailMissionContentViewModel vm) => vm.AcceptButtonEnabled)
				.OneWay();
			bindingSet.Bind(_collectRewardButton.gameObject).For((GameObject v) => v.activeSelf).To((MailMissionContentViewModel vm) => vm.IsMissionCompleted)
				.OneWay();
			bindingSet.Bind(_collectRewardButton).For((Button v) => v.onClick).To((MailMissionContentViewModel vm) => vm.CollectRewardCommand)
				.OneWay();
			bindingSet.Bind(_collectRewardButton).For((Button v) => v.interactable).To((MailMissionContentViewModel vm) => vm.CollectButtonEnabled)
				.OneWay();
			bindingSet.Bind(_tickImage.gameObject).For((GameObject v) => v.activeSelf).To((MailMissionContentViewModel vm) => vm.IsMissionAccepted)
				.OneWay();
			bindingSet.Build();
		}
	}
}
