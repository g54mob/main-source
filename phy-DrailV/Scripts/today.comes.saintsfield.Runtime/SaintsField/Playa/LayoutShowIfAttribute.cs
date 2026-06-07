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
	public class LayoutShowIfAttribute : Attribute, IPlayaAttribute, ISaintsLayoutToggle, ISaintsLayoutBase, IConditions
	{
		public IReadOnlyList<ConditionInfo> ConditionInfos { get; }

		public EMode EditorMode { get; }

		public LayoutShowIfAttribute(EMode editorMode, params object[] by)
		{
			EditorMode = editorMode;
			ConditionInfos = Parser.Parse(by).ToArray();
		}

		public LayoutShowIfAttribute(params object[] by)
			: this(EMode.Edit | EMode.Play, by)
		{
		}

		public override string ToString()
		{
			return string.Format("<LayoutShowIfAttribute eMode={0} conditions={1}>", EditorMode, string.Join(", ", ConditionInfos));
		}
	}
}
