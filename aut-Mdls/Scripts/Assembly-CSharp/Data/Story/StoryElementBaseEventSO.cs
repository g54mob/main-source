using Events;
using UnityEngine;

namespace Data.Story
{
	[CreateAssetMenu(fileName = "StoryElementBaseEventSO", menuName = "Story/StoryElementBaseEventSO")]
	public class StoryElementBaseEventSO : StoryElementSO
	{
		[SerializeField]
		private BaseEvent _baseEvent;

		public override void Initialize()
		{
			_baseEvent.Register(OnBaseEventTriggered);
		}

		public override void Destroy()
		{
			_baseEvent.UnRegister(OnBaseEventTriggered);
		}

		private void OnBaseEventTriggered()
		{
			_baseEvent.UnRegister(OnBaseEventTriggered);
			TryExecute();
		}
	}
}
