using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20.BTC
{
	[TaskCategory(" TH20/Character")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class CompareAttribute : CharacterConditional
	{
		private enum Operator
		{
			Equals = 0,
			LessThan = 1,
			GreaterThan = 2
		}

		[SerializeField]
		[BehaviorDesigner.Runtime.Tasks.Tooltip("Character attrribute")]
		private CharacterAttributes.Type _type;

		[SerializeField]
		[BehaviorDesigner.Runtime.Tasks.Tooltip("Comparison operator")]
		private Operator _operator;

		[SerializeField]
		[BehaviorDesigner.Runtime.Tasks.Tooltip("Comparison value")]
		private float _value;

		public override TaskStatus OnUpdate()
		{
			AttributeFloat attribute = base.Character.GetCharacterAttributes().GetAttribute(_type);
			if (attribute != null && CompareValues(attribute.Value(), _value) == _operator)
			{
				return TaskStatus.Success;
			}
			return TaskStatus.Failure;
		}

		private Operator CompareValues(float lhs, float rhs)
		{
			if (lhs < rhs)
			{
				return Operator.LessThan;
			}
			if (lhs > rhs)
			{
				return Operator.GreaterThan;
			}
			return Operator.Equals;
		}
	}
}
