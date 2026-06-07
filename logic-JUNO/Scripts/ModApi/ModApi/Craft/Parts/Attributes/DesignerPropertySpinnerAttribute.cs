using System;
using System.Collections.Generic;
using System.Linq;

namespace ModApi.Craft.Parts.Attributes
{
	[AttributeUsage(AttributeTargets.Field)]
	public class DesignerPropertySpinnerAttribute : DesignerPropertyAttribute
	{
		public bool AllowManualInput { get; set; }

		public bool IsTextSpinner { get; private set; }

		public decimal MaxValue { get; set; }

		public decimal MinValue { get; set; }

		public decimal StepSize { get; set; }

		public DesignerPropertySpinnerTextFormat TextFormat { get; set; }

		public bool ValidateManualInput { get; set; }

		public List<string> Values { get; set; }

		public DesignerPropertySpinnerAttribute(int min, int max, int stepSize = 1)
			: this((decimal)min, (decimal)max, (decimal)stepSize)
		{
		}

		public DesignerPropertySpinnerAttribute(double min, double max, double stepSize)
			: this((decimal)min, (decimal)max, (decimal)stepSize)
		{
		}

		public DesignerPropertySpinnerAttribute(float min, float max, float stepSize)
			: this((decimal)min, (decimal)max, (decimal)stepSize)
		{
		}

		public DesignerPropertySpinnerAttribute()
		{
			Values = new List<string>(0);
			IsTextSpinner = true;
			AllowManualInput = false;
			ValidateManualInput = true;
		}

		public DesignerPropertySpinnerAttribute(params string[] values)
		{
			Values = ((values == null) ? new List<string>(0) : new List<string>(values));
			IsTextSpinner = true;
			AllowManualInput = false;
			ValidateManualInput = true;
		}

		public DesignerPropertySpinnerAttribute(params object[] values)
		{
			Values = ((values == null) ? new List<string>(0) : values.Select((object x) => x.ToString()).ToList());
			IsTextSpinner = true;
			AllowManualInput = false;
			ValidateManualInput = true;
		}

		protected DesignerPropertySpinnerAttribute(decimal min, decimal max, decimal stepSize)
		{
			MinValue = min;
			MaxValue = max;
			StepSize = stepSize;
			IsTextSpinner = false;
			AllowManualInput = true;
			ValidateManualInput = true;
		}
	}
}
