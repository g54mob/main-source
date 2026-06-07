using System;
using NUnit.Compatibility;

namespace NUnit.Framework.Constraints
{
	public class AttributeExistsConstraint : Constraint
	{
		private Type expectedType;

		public override string Description => "type with attribute " + MsgUtils.FormatValue(expectedType);

		public AttributeExistsConstraint(Type type)
			: base(type)
		{
			expectedType = type;
			if (!typeof(Attribute).GetTypeInfo().IsAssignableFrom(expectedType.GetTypeInfo()))
			{
				throw new ArgumentException($"Type {expectedType} is not an attribute", "type");
			}
		}

		public override ConstraintResult ApplyTo(object actual)
		{
			Guard.ArgumentNotNull(actual, "actual");
			Attribute[] customAttributes = AttributeHelper.GetCustomAttributes(actual, expectedType, inherit: true);
			ConstraintResult constraintResult = new ConstraintResult(this, actual);
			constraintResult.Status = ((customAttributes.Length != 0) ? ConstraintStatus.Success : ConstraintStatus.Failure);
			return constraintResult;
		}
	}
}
