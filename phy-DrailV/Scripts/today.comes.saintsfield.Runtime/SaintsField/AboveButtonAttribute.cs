using System;
using System.Diagnostics;

namespace SaintsField
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
	[Conditional("UNITY_EDITOR")]
	public class AboveButtonAttribute : DecButtonAttribute
	{
		public AboveButtonAttribute(string funcName, string buttonLabel = null, bool isCallback = false, string groupBy = "")
			: base(funcName, buttonLabel, isCallback, groupBy)
		{
		}
	}
}
