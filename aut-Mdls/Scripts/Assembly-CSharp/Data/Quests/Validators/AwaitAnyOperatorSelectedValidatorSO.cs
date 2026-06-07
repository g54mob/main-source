using Events.FactoryFloor;
using UnityEngine;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/Await Any Operator Selected", fileName = "AwaitAnyOperatorSelected", order = 8)]
	public class AwaitAnyOperatorSelectedValidatorSO : AbstractSubQuestValidatorSO
	{
		[SerializeField]
		private BluePrintEvent _startPreviewEvent;

		private bool _isSetup;

		private bool _eventWasCalled;

		public override bool IsValid()
		{
			if (!_isSetup)
			{
				_startPreviewEvent.Register(OnPreviewStarted);
				_isSetup = true;
			}
			return _eventWasCalled;
		}

		private void OnPreviewStarted(BlueprintViewEventDto obj)
		{
			_eventWasCalled = true;
		}

		public override void Reset()
		{
			_isSetup = false;
			_eventWasCalled = false;
			_startPreviewEvent?.UnRegister(OnPreviewStarted);
		}
	}
}
