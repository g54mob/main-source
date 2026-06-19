using System;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ObjectAttributeModifier : AttributeModifier
	{
		[SerializeField]
		[InspectorTooltip("Object attribute to modify")]
		protected readonly ObjectAttributes.Type _type;

		public ObjectAttributes.Type Type => _type;

		public override bool Apply(IAttributesInterface attributesInterface)
		{
			return Apply(attributesInterface, (int)_type);
		}
	}
}
