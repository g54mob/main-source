using Player.FSM;
using Player.Stats;
using UnityEngine;
using Zenject;

namespace Items
{
	[CreateAssetMenu(menuName = "Player Usable Object/Consumable/Item", fileName = "New Consumable Object")]
	public class PlayerConsumableObject : ConsumableObject
	{
		public float NicotineStatChanger;

		public float AlcoholStatChanger;

		private UsableConsumableItem _consumableItem;

		[Inject]
		protected IPlayerStatsService _playerStatsService;

		[Inject]
		protected IPlayerStateMachineParametersManipulator _playerFSM;

		public override void Consume(UsableConsumableItem consumableItem)
		{
			_playerStatsService.AddModToAlcohol(AlcoholStatChanger);
			_playerStatsService.AddModToNicotine(NicotineStatChanger);
		}

		public override void TryUnuse()
		{
			Debug.Log("Can't Unuse...");
		}
	}
}
