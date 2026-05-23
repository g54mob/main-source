using Data.FactoryFloor.Resources;
using Events.FactoryFloor;
using UnityEngine;

namespace Data.Quests.Validators
{
	[CreateAssetMenu(menuName = "Quests/Validators/Detect Resource Exists", fileName = "DetectResourceExists", order = 6)]
	public class DetectResourceExistsSubQuestValidatorSO : AbstractSubQuestValidatorSO
	{
		[SerializeField]
		private ResourceCreatedEventSO _resourceCreatedEvent;

		[SerializeField]
		private ResourceDataSO _resourceData;

		private bool _init;

		private bool _resourceGotCreated;

		public override bool IsValid()
		{
			if (!_init)
			{
				_init = true;
				_resourceGotCreated = false;
				_resourceCreatedEvent.RegisterMainThread(OnResourceCreated);
			}
			return _resourceGotCreated;
		}

		private void OnResourceCreated(Resource createdResource)
		{
			_resourceGotCreated = createdResource.Data == _resourceData;
		}

		public override void Reset()
		{
			_init = false;
			_resourceGotCreated = false;
			_resourceCreatedEvent.UnRegisterMainThread(OnResourceCreated);
		}
	}
}
