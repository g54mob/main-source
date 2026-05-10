using System.Collections.Generic;

namespace GameKit.Utilities.Types
{
	public class TimedOperation
	{
		private readonly float _interval;

		private readonly bool _scaledTime;

		private Dictionary<string, float> _operationTimes;

		private float _lastGlobalTime;

		public TimedOperation(float interval, bool scaledTime = false)
		{
		}

		public bool TryUseOperation()
		{
			return false;
		}

		public bool TryUseOperation(string key)
		{
			return false;
		}
	}
}
