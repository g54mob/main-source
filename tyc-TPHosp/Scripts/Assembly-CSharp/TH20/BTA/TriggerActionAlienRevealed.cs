using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Character")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/InteractionStartIcon.png")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class TriggerActionAlienRevealed : TriggerAction
	{
		public override void OnEnd()
		{
			base.OnEnd();
			if (base.Character != null)
			{
				base.Character.GetComponent<AlienComponent>()?.OnRevealedActionFinished();
			}
		}

		public override TaskStatus OnUpdate()
		{
			TaskStatus taskStatus = base.OnUpdate();
			if (taskStatus == TaskStatus.Running && base.Character != null)
			{
				AlienComponent component = base.Character.GetComponent<AlienComponent>();
				if (component != null && !component.Discovered)
				{
					taskStatus = TaskStatus.Success;
				}
			}
			return taskStatus;
		}
	}
}
