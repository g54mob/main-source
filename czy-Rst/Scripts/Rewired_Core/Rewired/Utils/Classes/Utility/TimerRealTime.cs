using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Utility
{
	[Serializable]
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class TimerRealTime
	{
		public bool running;

		[SerializeField]
		private double LkDdcoepyZZDRLQsQjHmemwMSHggb;

		public double length;

		public TimerRealTime()
		{
		}

		public TimerRealTime(double P_0)
		{
			length = P_0;
		}

		public void Start()
		{
			running = true;
			LkDdcoepyZZDRLQsQjHmemwMSHggb = length + ReInput.realTime;
		}

		public void Start(double inLength)
		{
			running = true;
			length = inLength;
			LkDdcoepyZZDRLQsQjHmemwMSHggb = length + ReInput.realTime;
		}

		public bool Update()
		{
			if (!running)
			{
				return false;
			}
			if (ReInput.realTime >= LkDdcoepyZZDRLQsQjHmemwMSHggb)
			{
				running = false;
				return true;
			}
			return false;
		}

		public void Clear()
		{
			running = false;
			LkDdcoepyZZDRLQsQjHmemwMSHggb = 0.0;
		}

		public void SetLength(double inLength)
		{
			length = inLength;
		}

		public TimerAbs Clone()
		{
			return (TimerAbs)MemberwiseClone();
		}
	}
}
