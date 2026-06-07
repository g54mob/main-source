using System.Diagnostics;
using SaintsField.Interfaces;
using SaintsField.Utils;
using UnityEngine;

namespace SaintsField
{
	[Conditional("UNITY_EDITOR")]
	public abstract class DecButtonAttribute : PropertyAttribute, ISaintsAttribute
	{
		public readonly string FuncName;

		public readonly string ButtonLabel;

		public readonly bool IsCallback;

		public SaintsAttributeType AttributeType => SaintsAttributeType.Other;

		public string GroupBy { get; }

		protected DecButtonAttribute(string funcName, string buttonLabel = null, bool isCallback = false, string groupBy = "")
		{
			FuncName = RuntimeUtil.ParseCallback(funcName).content;
			(string, bool) tuple = RuntimeUtil.ParseCallback(buttonLabel, isCallback);
			ButtonLabel = tuple.Item1;
			IsCallback = tuple.Item2;
			GroupBy = groupBy;
		}
	}
}
