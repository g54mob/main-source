using UnityEngine;

namespace NSMedieval.Tools.BugReporting.Moments_Recorder.Scripts
{
	public sealed class MinAttribute : PropertyAttribute
	{
		public readonly float min;

		public MinAttribute(float min)
		{
			this.min = min;
		}
	}
}
