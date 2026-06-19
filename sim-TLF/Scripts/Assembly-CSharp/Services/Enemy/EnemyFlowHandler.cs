using Player.FSM;
using UnityEngine;

namespace Services.Enemy
{
	public class EnemyFlowHandler
	{
		private readonly float _maxStressValue = 100f;

		private readonly IAirRaidService _airRaidService;

		private readonly ILoyaltyService _loyaltyService;

		private readonly IPlayerStateMachineParametersManipulator _playerFSM;

		public EnemyFlowHandler(IAirRaidService airRaidService, ILoyaltyService loyaltyService, IPlayerStateMachineParametersManipulator playerFSM)
		{
			_airRaidService = airRaidService;
			_loyaltyService = loyaltyService;
			_playerFSM = playerFSM;
			_loyaltyService.StressValueChanged += OnStressValueChanged;
		}

		private void OnStressValueChanged(float stressValue)
		{
			if (stressValue >= _maxStressValue)
			{
				_airRaidService.InvokeAirRaid((_playerFSM as MonoBehaviour).transform.position);
				_loyaltyService.SetStressValue(0f);
			}
		}
	}
}
