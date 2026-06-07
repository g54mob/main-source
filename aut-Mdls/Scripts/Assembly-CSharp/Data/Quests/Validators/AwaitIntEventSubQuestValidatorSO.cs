using Events;
using UnityEngine;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/Await IntEvent", fileName = "AwaitIntEvent", order = 9)]
	public class AwaitIntEventSubQuestValidatorSO : AbstractSubQuestValidatorSO
	{
		[SerializeField]
		private BaseEvent<int> _intEvent;

		[SerializeField]
		private int _requiredIntValue;

		private bool _isSetup;

		private bool _wasClicked;

		public override bool IsValid()
		{
			if (!_isSetup)
			{
				_intEvent.Register(HandleButtonClicked);
				_isSetup = true;
			}
			return _wasClicked;
		}

		private void HandleButtonClicked(int value)
		{
			_wasClicked = value == _requiredIntValue;
		}

		public override void Reset()
		{
			_isSetup = false;
			_wasClicked = false;
			_intEvent?.UnRegister(HandleButtonClicked);
		}
	}
}
