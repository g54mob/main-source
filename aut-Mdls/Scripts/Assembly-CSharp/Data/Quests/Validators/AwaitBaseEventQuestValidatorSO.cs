using Events;
using UnityEngine;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/Await Base Event", fileName = "AwaitBaseEvent", order = 8)]
	public class AwaitBaseEventQuestValidatorSO : AbstractSubQuestValidatorSO
	{
		[SerializeField]
		private BaseEvent _event;

		[SerializeField]
		private int _callAmount = 1;

		private bool _isSetup;

		private bool _eventWasCalled;

		private int _calledAmount;

		public override bool IsValid()
		{
			if (!_isSetup)
			{
				_calledAmount = 0;
				_event.Register(HandleButtonClicked);
				_isSetup = true;
			}
			return _eventWasCalled;
		}

		private void HandleButtonClicked()
		{
			_calledAmount++;
			if (_calledAmount >= _callAmount)
			{
				_eventWasCalled = true;
			}
		}

		public override void Reset()
		{
			_isSetup = false;
			_eventWasCalled = false;
			_calledAmount = 0;
			_event?.UnRegister(HandleButtonClicked);
		}
	}
}
