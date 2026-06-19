using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Interaction")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/InteractionIcon.png")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class SetTrigger : CharacterAction
	{
		[Tooltip("Interaction")]
		public SharedObjectInteractionRef _interaction;

		[Tooltip("Trigger")]
		public string _trigger;

		public override TaskStatus OnUpdate()
		{
			ObjectInteraction objectInteraction = (_interaction.IsValid() ? _interaction.Get : base.Character.Interaction);
			if (objectInteraction == null)
			{
				return TaskStatus.Success;
			}
			objectInteraction.SetTrigger(_trigger);
			return TaskStatus.Success;
		}
	}
}
