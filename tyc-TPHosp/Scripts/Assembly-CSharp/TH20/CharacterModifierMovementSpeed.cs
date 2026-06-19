using I2.Loc;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class CharacterModifierMovementSpeed : CharacterModifier
	{
		[SerializeField]
		private int _priority;

		[SerializeField]
		private float _multiplier = 1f;

		[SerializeField]
		private float _walkAnimMultiplier = 1f;

		[SerializeField]
		private float _accelerationMultiplier = 1f;

		public float Multiplier => _multiplier;

		public float WalkAnimMultiplier => _walkAnimMultiplier;

		public float AccelerationMultiplier => _accelerationMultiplier;

		public int Priority => _priority;

		public override void Add(Character character)
		{
			character.SetMovementMultipliers(this);
		}

		public override void Remove(Character character)
		{
			character.RemoveMovementMultiplier();
		}

		public override string Description()
		{
			return LocalisedString.Replace(ScriptLocalization.Character_Modifiers.MovementSpeed_Description_CS, "{[PERCENT]}", StringUtils.FormatPercentageValue(_multiplier - 1f, prefixPlus: true));
		}
	}
}
