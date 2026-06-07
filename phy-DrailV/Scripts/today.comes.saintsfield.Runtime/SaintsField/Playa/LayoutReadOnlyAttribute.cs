using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SaintsField.Condition;
using SaintsField.Interfaces;

namespace SaintsField.Playa
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
	public class LayoutReadOnlyAttribute : Attribute, IPlayaAttribute, ISaintsLayoutToggle, ISaintsLayoutBase, IConditions
	{
		public IReadOnlyList<ConditionInfo> ConditionInfos { get; }

		public LayoutReadOnlyAttribute(params object[] by)
		{
			ConditionInfos = Parser.Parse(by).ToArray();
		}

		public override string ToString()
		{
			return "<LayoutReadOnlyAttribute conditions=" + string.Join(", ", ConditionInfos) + ">";
		}
	}
}
