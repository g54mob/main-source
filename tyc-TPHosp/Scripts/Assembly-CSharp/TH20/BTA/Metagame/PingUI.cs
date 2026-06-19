using BehaviorDesigner.Runtime.Tasks;

namespace TH20.BTA.Metagame
{
	[TaskCategory(" TH20/Metagame Script")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/PingIcon.png")]
	public class PingUI : MetagameAction
	{
		public override void OnStart()
		{
			base.OnStart();
		}

		public override TaskStatus OnUpdate()
		{
			return TaskStatus.Success;
		}

		public override void OnEnd()
		{
			base.OnEnd();
		}
	}
}
