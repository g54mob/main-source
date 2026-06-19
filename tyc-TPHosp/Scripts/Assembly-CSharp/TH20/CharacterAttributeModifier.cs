using System;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class CharacterAttributeModifier : AttributeModifier
	{
		[SerializeField]
		[InspectorTooltip("Character attribute to modify")]
		protected readonly CharacterAttributes.Type _type;

		public CharacterAttributes.Type Type => _type;

		public override bool Apply(IAttributesInterface attributesInterface)
		{
			return Apply(attributesInterface, (int)_type);
		}

		public bool IsNeedModifer()
		{
			if (_type != CharacterAttributes.Type.Hunger && _type != CharacterAttributes.Type.Thirst && _type != CharacterAttributes.Type.Toilet && _type != CharacterAttributes.Type.Boredom && _type != CharacterAttributes.Type.Litter)
			{
				return _type == CharacterAttributes.Type.Nausea;
			}
			return true;
		}
	}
}
