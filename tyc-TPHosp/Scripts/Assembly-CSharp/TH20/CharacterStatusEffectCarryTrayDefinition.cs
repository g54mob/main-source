using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class CharacterStatusEffectCarryTrayDefinition : CharacterStatusEffectDefinition
	{
		public override bool HasFinished(float startTime, float timeNow, Character character)
		{
			if (character.RoomUsing != null && character.RoomUsing.Definition._type != RoomDefinition.Type.Cafe)
			{
				return true;
			}
			if (character is Staff staff && staff.CurrentJob != null)
			{
				return true;
			}
			return base.HasFinished(startTime, timeNow, character);
		}
	}
}
