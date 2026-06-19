using BehaviorDesigner.Runtime.Tasks;
using FullInspector.Generated.SharedInstance;

namespace TH20.BTA.Metagame
{
	[TaskCategory(" TH20/Metagame Script")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/CinematicIcon.png")]
	public class SubmitPostCutsceneEvent : MetagameCutsceneAction
	{
		public SharedInstance_TH20TH20_MetagamePostCutsceneEventDefinition PostCutsceneEvent;

		public override TaskStatus OnUpdate()
		{
			if (!PostCutsceneEvent.IsNull())
			{
				base.Owner.Metagame.CutsceneEvents.SubmitPostCutsceneEvent(PostCutsceneEvent.Instance);
			}
			return TaskStatus.Success;
		}
	}
}
