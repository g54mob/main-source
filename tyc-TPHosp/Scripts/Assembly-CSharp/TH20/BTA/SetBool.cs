using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Interaction")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/InteractionIcon.png")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class SetBool : CharacterAction
	{
		[Tooltip("Interaction")]
		public SharedObjectInteractionRef _interaction;

		[Tooltip("Bool")]
		public string _name;

		[Tooltip("Value")]
		public bool _value;

		public override TaskStatus OnUpdate()
		{
			ObjectInteraction objectInteraction = (_interaction.IsValid() ? _interaction.Get : base.Character.Interaction);
			if (objectInteraction == null || objectInteraction.Interactor == null)
			{
				return TaskStatus.Failure;
			}
			objectInteraction.SetBool(_name, _value);
			return TaskStatus.Success;
		}
	}
}
