using Events;
using UnityEngine;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/Await Button Clicked", fileName = "AwaitButtonClicked", order = 8)]
	public class AwaitButtonClickedSubQuestValidatorSO : AbstractSubQuestValidatorSO
	{
		[SerializeField]
		private BaseEvent _buttonClickedEvent;

		private bool _isSetup;

		private bool _wasClicked;

		public override bool IsValid()
		{
			if (!_isSetup)
			{
				_buttonClickedEvent.Register(HandleButtonClicked);
				_isSetup = true;
			}
			return _wasClicked;
		}

		private void HandleButtonClicked()
		{
			_wasClicked = true;
		}

		public override void Reset()
		{
			_isSetup = false;
			_wasClicked = false;
			_buttonClickedEvent?.UnRegister(HandleButtonClicked);
		}
	}
}
