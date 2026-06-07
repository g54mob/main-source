using System;

namespace Lightbug.CharacterControllerPro.Implementation
{
	[Serializable]
	public struct BoolAction
	{
		public bool value;

		private bool previousValue;

		private bool previousStarted;

		private bool previousCanceled;

		public bool Started { get; private set; }

		public bool Canceled { get; private set; }

		public float StartedElapsedTime { get; private set; }

		public float CanceledElapsedTime { get; private set; }

		public float ActiveTime { get; private set; }

		public float InactiveTime { get; private set; }

		public float LastActiveTime { get; private set; }

		public float LastInactiveTime { get; private set; }

		public void Initialize()
		{
			StartedElapsedTime = float.PositiveInfinity;
			CanceledElapsedTime = float.PositiveInfinity;
			value = false;
			previousValue = false;
			previousStarted = false;
			previousCanceled = false;
		}

		public void Reset()
		{
			Started = false;
			Canceled = false;
		}

		public void Update(float dt)
		{
			Started = !previousValue && value;
			Canceled = previousValue && !value;
			StartedElapsedTime += dt;
			CanceledElapsedTime += dt;
			if (Started)
			{
				StartedElapsedTime = 0f;
				if (!previousStarted)
				{
					LastActiveTime = 0f;
					LastInactiveTime = InactiveTime;
				}
			}
			if (Canceled)
			{
				CanceledElapsedTime = 0f;
				if (!previousCanceled)
				{
					LastActiveTime = ActiveTime;
					LastInactiveTime = 0f;
				}
			}
			if (value)
			{
				ActiveTime += dt;
				InactiveTime = 0f;
			}
			else
			{
				ActiveTime = 0f;
				InactiveTime += dt;
			}
			previousValue = value;
			previousStarted = Started;
			previousCanceled = Canceled;
		}
	}
}
