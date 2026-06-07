using System;
using UnityEngine;

namespace Lightbug.Utilities
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class BooleanButtonAttribute : PropertyAttribute
	{
		public string Label;

		public string FalseLabel;

		public string TrueLabel;

		public bool FalseLabelFirst;

		public BooleanButtonAttribute(string label, string falseLabel, string trueLabel, bool falseLabelFirst)
		{
			Label = label;
			FalseLabelFirst = falseLabelFirst;
			FalseLabel = falseLabel;
			TrueLabel = trueLabel;
		}
	}
}
