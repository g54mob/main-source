using System;
using NUnit.Compatibility;

namespace NUnit.Framework.Constraints
{
	public class AttributeConstraint : PrefixConstraint
	{
		private readonly Type expectedType;

		private Attribute attrFound;

		public AttributeConstraint(Type type, IConstraint baseConstraint)
			: base(baseConstraint)
		{
			expectedType = type;
			base.DescriptionPrefix = "attribute " + expectedType.FullName;
			if (!typeof(Attribute).GetTypeInfo().IsAssignableFrom(expectedType.GetTypeInfo()))
			{
				throw new ArgumentException($"Type {expectedType} is not an attribute", "type");
			}
		}

		public override ConstraintResult ApplyTo(object actual)
		{
			Guard.ArgumentNotNull(actual, "actual");
			Attribute[] customAttributes = AttributeHelper.GetCustomAttributes(actual, expectedType, inherit: true);
			if (customAttributes.Length == 0)
			{
				throw new ArgumentException($"Attribute {expectedType} was not found", "actual");
			}
			attrFound = customAttributes[0];
			return base.BaseConstraint.ApplyTo(attrFound);
		}

		protected override string GetStringRepresentation()
		{
			return $"<attribute {expectedType} {base.BaseConstraint}>";
		}
	}
}
