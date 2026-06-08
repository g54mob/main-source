using System.Collections.Generic;

namespace Amazon.Runtime
{
	public class DoubleListParameterValue : ParameterValue
	{
		public List<double> Value { get; set; }

		public DoubleListParameterValue(List<double> values)
		{
			Value = values;
		}

		internal DoubleListParameterValue()
		{
		}
	}
}
