using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Tannoy")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/TannoyIcon.png")]
	public class QueueAnnouncement : ExpiringLevelAction
	{
		[UsedImplicitly]
		public string TannoyAudioEventName = "";

		public override TaskStatus OnUpdate()
		{
			if (HasTaskExpired())
			{
				return TaskStatus.Success;
			}
			TannoyManager.OnAnnouncementQueueRequest.InvokeSafe(TannoyAudioEventName);
			return TaskStatus.Success;
		}
	}
}
