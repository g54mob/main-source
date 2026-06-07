namespace Utility
{
	public class NodeInformation
	{
		public int index;

		public string name;

		public string desc;

		public bool isLinear = true;

		public float minOutput = float.NegativeInfinity;

		public float maxOutput = float.PositiveInfinity;

		public string tooltipText => string.Format("{0}{1}\n\nOutput range: {2} to {3}", (!isLinear) ? "!NONLINEAR! the same input won't always result in the same output\n\n" : "", desc, (minOutput > -10000000f) ? ((object)(int)minOutput) : "-Inf", (maxOutput < 1000000f) ? ((object)(int)maxOutput) : "Inf");

		public string rangeText => string.Format("Output range: {0} to {1}", (minOutput > -10000000f) ? ((object)(int)minOutput) : "-Inf", (maxOutput < 1000000f) ? ((object)(int)maxOutput) : "Inf");
	}
}
