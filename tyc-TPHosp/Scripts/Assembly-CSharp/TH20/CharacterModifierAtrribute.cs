using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class CharacterModifierAtrribute : CharacterModifier
	{
		[SerializeField]
		private CharacterAttributes.Type _type;

		[SerializeField]
		private float _amount;

		public override void Add(Character character)
		{
			character.GetCharacterAttributes().GetAttribute(_type)?.Modify(_amount, 1f);
		}
	}
}
