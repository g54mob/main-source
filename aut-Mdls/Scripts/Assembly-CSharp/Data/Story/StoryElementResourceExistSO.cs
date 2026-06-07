using Data.FactoryFloor.Resources;
using Events.FactoryFloor;
using UnityEngine;

namespace Data.Story
{
	[CreateAssetMenu(fileName = "StoryElementResourceExistSO", menuName = "Story/StoryElementResourceExistSO")]
	public class StoryElementResourceExistSO : StoryElementSO
	{
		[SerializeField]
		private ResourceCreatedEventSO _resourceCreatedEvent;

		[SerializeField]
		private ResourceDataSO _resourceData;

		public override void Initialize()
		{
			_resourceCreatedEvent.RegisterMainThread(OnResourceCreated);
		}

		private void OnResourceCreated(Resource createdResource)
		{
			if (createdResource.Data == _resourceData)
			{
				TryExecute();
			}
		}

		public override void Destroy()
		{
			_resourceCreatedEvent.UnRegisterMainThread(OnResourceCreated);
		}
	}
}
