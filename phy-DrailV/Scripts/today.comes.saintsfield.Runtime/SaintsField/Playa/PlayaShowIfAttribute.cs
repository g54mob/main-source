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
	public class PlayaShowIfAttribute : Attribute, IPlayaAttribute, IVisibilityAttribute, IConditions
	{
		public IReadOnlyList<ConditionInfo> ConditionInfos { get; }

		public virtual bool IsShow => true;

		public PlayaShowIfAttribute(params object[] andCallbacks)
		{
			ConditionInfos = ((andCallbacks.Length == 0) ? Parser.Parse(new object[1] { true }).ToArray() : Parser.Parse(andCallbacks).ToArray());
		}
	}
}
