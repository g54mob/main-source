using Events;
using UnityEngine;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/Await Button Hovered", fileName = "AwaitButtonHover", order = 9)]
	public class AwaitButtonHoverSubQuestValidatorSO : AbstractSubQuestValidatorSO
	{
		[SerializeField]
		private BaseEvent _buttonHoveredEvent;

		private bool _isSetup;

		private bool _wasHovered;

		public override bool IsValid()
		{
			if (!_isSetup)
			{
				_buttonHoveredEvent.Register(HandleButtonHovered);
				_isSetup = true;
			}
			return _wasHovered;
		}

		private void HandleButtonHovered()
		{
			_buttonHoveredEvent.UnRegister(HandleButtonHovered);
			_wasHovered = true;
		}

		public override void Reset()
		{
			_isSetup = false;
			_wasHovered = false;
			_buttonHoveredEvent?.UnRegister(HandleButtonHovered);
		}
	}
}
