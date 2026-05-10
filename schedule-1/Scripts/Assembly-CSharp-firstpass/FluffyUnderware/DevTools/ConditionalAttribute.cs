using System.Reflection;

namespace FluffyUnderware.DevTools
{
	public class ConditionalAttribute : ActionAttribute
	{
		public enum OperatorEnum
		{
			AND = 0,
			OR = 1
		}

		public class Condition
		{
			public string FieldName;

			public FieldInfo FieldInfo;

			public PropertyInfo PropertyInfo;

			public object CompareTo;

			public bool CompareFalse;

			public OperatorEnum Operator;

			public MethodInfo MethodInfo;

			public string MethodName;
		}

		public Condition[] Conditions;

		protected ConditionalAttribute(string fieldOrProperty, object compareTo, bool compareFalse = false)
			: base(null, default(ActionEnum))
		{
		}

		protected ConditionalAttribute(string fieldOrProperty, object compareTo, bool compareFalse, OperatorEnum op, string fieldOrProperty2, object compareTo2, bool compareFalse2)
			: base(null, default(ActionEnum))
		{
		}

		protected ConditionalAttribute(string fieldOrProperty, object compareTo, bool compareFalse, OperatorEnum op, string fieldOrProperty2, object compareTo2, bool compareFalse2, string fieldOrProperty3, object compareTo3, bool compareFalse3)
			: base(null, default(ActionEnum))
		{
		}

		protected ConditionalAttribute(string methodToQuery)
			: base(null, default(ActionEnum))
		{
		}

		public virtual bool ConditionMet(object classInstance)
		{
			return false;
		}

		private bool evaluate(Condition cond, object classInstance)
		{
			return false;
		}
	}
}
