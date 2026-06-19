using System;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public abstract class AttributeModifier
	{
		[SerializeField]
		[InspectorTooltip("Amount to modify the attribute by")]
		protected readonly float _amount;

		[SerializeField]
		[InspectorTooltip("Time to modify the attribute over")]
		protected readonly float _time;

		public abstract bool Apply(IAttributesInterface attributesInterface);

		protected bool Apply(IAttributesInterface attributesInterface, int enumValue)
		{
			if (attributesInterface != null)
			{
				Attributes attributes = attributesInterface.GetAttributes();
				if (attributes != null)
				{
					AttributeFloat attribute = attributes.GetAttribute(enumValue);
					if (attribute != null)
					{
						if (_time > 0f)
						{
							attribute.AddModifier(this);
						}
						else
						{
							attribute.Modify(_amount, attributesInterface.GetAttributeMultiplier(enumValue));
						}
						return true;
					}
				}
			}
			return false;
		}

		public float TimeToModify()
		{
			return _time;
		}

		public float Amount()
		{
			return _amount;
		}

		public float AmountToModify(float deltaTime)
		{
			if (!(_time > 0f))
			{
				return _amount;
			}
			return _amount / _time * deltaTime;
		}
	}
}
