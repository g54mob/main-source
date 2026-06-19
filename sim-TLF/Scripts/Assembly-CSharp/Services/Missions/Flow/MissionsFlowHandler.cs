using System;
using System.Linq;
using Computer.Services;
using Cysharp.Threading.Tasks;
using Data;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Contexts;
using Mail;
using MyBox;
using Services.Markers;
using Services.Save.Missions;
using Services.Save.Player;
using UI.HUD.Assistant;
using UnityEngine;
using UnityEngine.AddressableAssets;
using WorldEnvironment.Islands;
using Zenject;

namespace Services.Missions.Flow
{
	public class MissionsFlowHandler : IInitializable, ITickable
	{
		private const string CUSTOM_CONTENT_ID = "MailMissionContent";

		private float _reachMissionCooldown = 240f;

		private float _deliveryMissionCooldown = 1800f;

		private float _reachTimer;

		private float _deliveryTimer;

		private MailMissionContentView _customContentPrefab;

		private readonly MissionsPresetsService _missionsPresets;

		private readonly IMissionService _missionService;

		private readonly MissionEventBus _missionEventBus;

		private readonly IslandWorldSpawner _islandSpawner;

		private readonly MissionsRewardHandler _rewardHandler;

		private readonly IWorldReachMarkerService _reachMarkerService;

		private readonly IMailService _mailService;

		private readonly AssistantPopupViewModel _assistantPopupViewModel;

		private readonly DiContainer _diContainer;

		private readonly PlayerSaveService _playerSaveService;

		private readonly MissionSaveService _missionSaveService;

		public MissionsFlowHandler(MissionsPresetsService missionsPresets, IMissionService missionService, IslandWorldSpawner islandWorldSpawner, IWorldReachMarkerService worldReachMarkerService, IMailService mailService, DiContainer diContainer, MissionEventBus eventBus, PlayerSaveService playerSaveService, MissionSaveService missionSaveService)
		{
			_missionsPresets = missionsPresets;
			_missionService = missionService;
			_islandSpawner = islandWorldSpawner;
			_reachMarkerService = worldReachMarkerService;
			_mailService = mailService;
			_diContainer = diContainer;
			_missionEventBus = eventBus;
			_playerSaveService = playerSaveService;
			_missionSaveService = missionSaveService;
			_rewardHandler = new MissionsRewardHandler();
			_assistantPopupViewModel = Loxodon.Framework.Contexts.Context.GetApplicationContext().GetService<AssistantPopupViewModel>();
			_missionService.OnMissionStarted += OnMissionStarted;
		}

		private void OnMissionStarted(MissionInstance instance)
		{
			if (_playerSaveService.PlayerData.GameData.TutorialDone)
			{
				_assistantPopupViewModel.Appear();
			}
		}

		async void IInitializable.Initialize()
		{
			_customContentPrefab = await LoadCustomContent();
		}

		void ITickable.Tick()
		{
			if (_playerSaveService.PlayerData.GameData.TutorialDone && _missionSaveService.IsLoaded && _missionService.GetAllActive().Count() <= 0)
			{
				_reachTimer += UnityEngine.Time.deltaTime;
				if (!_missionService.GetAllCompleted().Any((MissionInstance x) => !x.RewardCollected) && _reachTimer >= _reachMissionCooldown)
				{
					StartReachMission();
				}
			}
		}

		private async void StartReachMission()
		{
			_customContentPrefab = await LoadCustomContent();
			IslandObjectView random = _islandSpawner.SpawnedIslands.GetRandom();
			string islandId = random.CoordinatesString;
			float reward = UnityEngine.Random.Range(_rewardHandler.ReachReward.MinReward, _rewardHandler.ReachReward.MaxReward);
			_missionsPresets.StartReachMission(islandId, reward);
			(await _reachMarkerService.CreateMarker(random.TerrainCenter)).Init(delegate
			{
				_missionEventBus.Emit("reach", islandId);
				_reachTimer = 0f - _reachMissionCooldown;
			});
			_assistantPopupViewModel.SetSpeechBubbleVisible(value: true);
			_assistantPopupViewModel.SetSpeechBubbleText("You've just recieved new email. Go chek it until it's too late...");
			MissionInstance active = _missionService.GetActive(islandId);
			MailMissionContentViewModel dataContext = _diContainer.Instantiate<MailMissionContentViewModel>(new object[1] { active.Definition });
			_customContentPrefab.SetDataContext(dataContext);
			_customContentPrefab.CreateBinding();
			_customContentPrefab.MissionId = active.MissionId;
			MailObject mailObject = new MailObject
			{
				Subject = "New Islands Ahead",
				From = "Anon",
				Date = DateTime.Now.AddYears(100).ToString(),
				UseCustomContent = true,
				FromName = "Anonymous_1337",
				CustomContentPrefab = _customContentPrefab.gameObject,
				CustomContentAddressableKey = "MailMissionContent",
				MissionId = active.MissionId
			};
			_mailService.SendMail(mailObject);
		}

		private async UniTask<MailMissionContentView> LoadCustomContent()
		{
			return (await Addressables.LoadAssetAsync<GameObject>("MailMissionContent")).GetComponent<MailMissionContentView>();
		}
	}
}
