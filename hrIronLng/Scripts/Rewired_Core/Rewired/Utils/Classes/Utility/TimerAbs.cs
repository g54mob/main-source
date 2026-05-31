using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Utility
{
	[Serializable]
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class TimerAbs
	{
		public bool running;

		[SerializeField]
		private double qLDaWbOLBPFsHzYEiejfiEVidbI;

		public double length;

		public TimerAbs()
		{
		}

		public TimerAbs(double inLength)
		{
			length = inLength;
		}

		public void Start()
		{
			running = true;
			qLDaWbOLBPFsHzYEiejfiEVidbI = length + ReInput.unscaledTime;
		}

		public void Start(double inLength)
		{
			running = true;
			length = inLength;
			qLDaWbOLBPFsHzYEiejfiEVidbI = length + ReInput.unscaledTime;
		}

		public bool Update()
		{
			if (!running)
			{
				return false;
			}
			if (ReInput.unscaledTime >= qLDaWbOLBPFsHzYEiejfiEVidbI)
			{
				running = false;
				return true;
			}
			return false;
		}

		public void Clear()
		{
			running = false;
			qLDaWbOLBPFsHzYEiejfiEVidbI = 0.0;
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
