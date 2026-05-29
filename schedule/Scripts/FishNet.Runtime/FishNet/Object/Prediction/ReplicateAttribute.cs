using System;

namespace FishNet.Object.Prediction
{
	[AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
	public class ReplicateAttribute : Attribute
	{
		[Obsolete("Use PredictionManager.RedundancyCount.")]
		public byte Resends;

		public bool AllowServerControl;
	}
}
