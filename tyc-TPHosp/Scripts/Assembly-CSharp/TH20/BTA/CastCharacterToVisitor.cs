using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Character")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class CastCharacterToVisitor : CharacterAction
	{
		[Tooltip("Character")]
		public SharedCharacterRef _character;

		[Tooltip("Visitor")]
		public SharedVisitorRef _visitor;

		public override TaskStatus OnUpdate()
		{
			if (_character.Get is Visitor visitor)
			{
				_visitor.Value = new VisitorRef(visitor);
				return TaskStatus.Success;
			}
			return TaskStatus.Failure;
		}
	}
}
