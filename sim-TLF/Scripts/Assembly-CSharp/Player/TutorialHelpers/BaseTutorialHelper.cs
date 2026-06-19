using Services.Missions;
using Services.Save.Player;
using UnityEngine;
using Zenject;

namespace Player.TutorialHelpers
{
	public class BaseTutorialHelper : MonoBehaviour
	{
		[Inject]
		private PlayerSaveService _playerSaveService;

		[Inject]
		private MissionEventBus _missionEventBus;

		private void OnEnable()
		{
			if (_playerSaveService.PlayerData.GameData.TutorialDone)
			{
				base.gameObject.SetActive(value: false);
			}
		}

		public virtual void EmitStep(string stepID)
		{
			_missionEventBus.Emit("interact", stepID);
		}
	}
}
