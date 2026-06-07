using System;
using System.Collections.Generic;

namespace Assets.Scripts.Design.PartProperties.Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class DesignerPropertyToggleButtonAttribute : DesignerPropertyAttribute
	{
		public bool AllowFunkyInput { get; set; }

		public bool SilenceEnumCountMismatch { get; set; }

		public List<string> Values { get; set; }

		public DesignerPropertyToggleButtonAttribute(params string[] values)
		{
			Values = ((values == null) ? new List<string>() : new List<string>(values));
		}
	}
}
