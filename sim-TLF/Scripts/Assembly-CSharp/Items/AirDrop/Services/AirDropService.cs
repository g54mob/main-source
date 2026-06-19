using System.Linq;
using Items.Box;
using Loxodon.Framework.Contexts;
using Services.Missions;
using Services.Save;
using Services.Save.Missions;
using Services.Save.Player;
using UI.HUD;
using UI.HUD.Assistant;
using UnityEngine;
using Zenject;

namespace Items.AirDrop.Services
{
	public class AirDropService : IAirDropService, IInitializable
	{
		[Inject]
		private DiContainer _container;

		[Inject]
		private PlayerSaveService _playerSaveService;

		[Inject]
		private IMissionService _missionService;

		[Inject]
		private MissionSaveService _missionSaveService;

		[Inject]
		private ISaveService _saveService;

		[Inject]
		private PlayerHUDView _hudView;

		private AssistantPopupViewModel _assistantPopupVM;

		void IInitializable.Initialize()
		{
		}

		ParachuteHolder IAirDropService.SpawnAirDrop(ItemBoxView box, Vector3 worldPos)
		{
			if (!_playerSaveService.PlayerData.GameData.TutorialDone)
			{
				_assistantPopupVM = Loxodon.Framework.Contexts.Context.GetApplicationContext().GetService<AssistantPopupViewModel>();
				_playerSaveService.PlayerData.GameData.TutorialDone = true;
				foreach (MissionInstance item in _missionService.GetAllActive().ToList())
				{
					_missionService.FailMission(item.MissionId);
				}
				_playerSaveService.OnSave();
				_saveService.Save(_missionSaveService.SaveKey);
				_assistantPopupVM.Missions.Clear();
			}
			ParachuteHolder parachuteHolder = _container.InstantiatePrefabResourceForComponent<ParachuteHolder>("Items/AirDrop");
			parachuteHolder.transform.position = worldPos;
			parachuteHolder.ConnectBox(box);
			return parachuteHolder;
		}
	}
}
