using FullInspector;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class CharacterModifierAttachActor : CharacterModifier
	{
		public SharedInstance<AdditionalActorDefinition> Actor;

		public override void Add(Character character)
		{
			character.GetOrAddComponent<AttachActorToCharacterComponent>().Attach(Actor.Instance);
		}

		public override void Remove(Character character)
		{
			character.RemoveComponents<AttachActorToCharacterComponent>();
		}
	}
}
