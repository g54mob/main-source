using System;
using System.Reflection;

namespace NUnit.Framework.Constraints
{
	public class PropertyConstraint : PrefixConstraint
	{
		private readonly string name;

		private object propValue;

		public PropertyConstraint(string name, IConstraint baseConstraint)
			: base(baseConstraint)
		{
			this.name = name;
			base.DescriptionPrefix = "property " + name;
		}

		public override ConstraintResult ApplyTo(object actual)
		{
			Guard.ArgumentNotNull(actual, "actual");
			Type type = actual as Type;
			if ((object)type == null)
			{
				type = actual.GetType();
			}
			PropertyInfo property = type.GetProperty(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if ((object)property == null)
			{
				throw new ArgumentException($"Property {name} was not found", "name");
			}
			propValue = property.GetValue(actual, null);
			return new ConstraintResult(this, propValue, base.BaseConstraint.ApplyTo(propValue).IsSuccess);
		}

		protected override string GetStringRepresentation()
		{
			return $"<property {name} {base.BaseConstraint}>";
		}
	}
}
