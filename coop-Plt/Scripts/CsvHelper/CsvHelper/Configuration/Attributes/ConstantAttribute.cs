using System;

namespace CsvHelper.Configuration.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
	public class ConstantAttribute : Attribute, IMemberMapper, IParameterMapper
	{
		public object Constant { get; private set; }

		public ConstantAttribute(object constant)
		{
			Constant = constant;
		}

		public void ApplyTo(MemberMap memberMap)
		{
			memberMap.Data.Constant = Constant;
			memberMap.Data.IsConstantSet = true;
		}

		public void ApplyTo(ParameterMap parameterMap)
		{
			parameterMap.Data.Constant = Constant;
			parameterMap.Data.IsConstantSet = true;
		}
	}
}
