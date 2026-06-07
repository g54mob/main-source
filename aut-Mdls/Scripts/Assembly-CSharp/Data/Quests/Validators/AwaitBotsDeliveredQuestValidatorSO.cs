using Data.FactoryFloor.Resources;
using Events.FactoryFloor;
using UnityEngine;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/Await Bots Delivered", fileName = "AwaitBotsDelivered", order = 8)]
	public class AwaitBotsDeliveredQuestValidatorSO : AbstractSubQuestValidatorSO
	{
		[SerializeField]
		private BotDeliveredEventSO _botDeliveredEvent;

		[SerializeField]
		private BotResourceDataSO _botDataToCheckFor;

		[SerializeField]
		private int _botsNeeded;

		private bool _isSetup;

		private bool _allBotsDelivered;

		private int _botsDelivered;

		public override bool IsValid()
		{
			if (!_isSetup)
			{
				_botDeliveredEvent.Register(HandleBotDeliveredEvent);
				_isSetup = true;
			}
			return _allBotsDelivered;
		}

		private void HandleBotDeliveredEvent(Resource botResource)
		{
			if (botResource.Data == _botDataToCheckFor)
			{
				_botsDelivered++;
			}
			if (_botsDelivered >= _botsNeeded)
			{
				_allBotsDelivered = true;
			}
		}

		public override void Reset()
		{
			_isSetup = false;
			_allBotsDelivered = false;
			_botsDelivered = 0;
			_botDeliveredEvent?.UnRegister(HandleBotDeliveredEvent);
		}
	}
}
