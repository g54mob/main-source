using Events;
using UnityEngine;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/Await Closing ModalDialog", fileName = "AwaitClosingModalDialogue", order = 6)]
	public class AwaitClosingModalDialogueValidatorSO : AbstractSubQuestValidatorSO
	{
		[SerializeField]
		private BaseEvent _closedModalDialogEvent;

		private bool _isSetup;

		private bool _modalDialogueClosed;

		public override bool IsValid()
		{
			if (!_isSetup)
			{
				_closedModalDialogEvent.Register(HandleModalDialogueClosed);
				_isSetup = true;
			}
			if (_modalDialogueClosed)
			{
				return true;
			}
			return false;
		}

		private void HandleModalDialogueClosed()
		{
			_closedModalDialogEvent.UnRegister(HandleModalDialogueClosed);
			_modalDialogueClosed = true;
		}

		public override void Reset()
		{
			_modalDialogueClosed = false;
			_isSetup = false;
			if (_closedModalDialogEvent != null)
			{
				_closedModalDialogEvent.UnRegister(HandleModalDialogueClosed);
			}
		}
	}
}
