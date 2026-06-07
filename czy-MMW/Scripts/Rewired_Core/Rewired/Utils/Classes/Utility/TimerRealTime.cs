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
		private double MKrJnRhMmOOPLCJlIBJYyNKtFzoR;

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
			MKrJnRhMmOOPLCJlIBJYyNKtFzoR = length + ReInput.realTime;
		}

		public void Start(double inLength)
		{
			running = true;
			length = inLength;
			MKrJnRhMmOOPLCJlIBJYyNKtFzoR = length + ReInput.realTime;
		}

		public bool Update()
		{
			if (!running)
			{
				return false;
			}
			if (ReInput.realTime >= MKrJnRhMmOOPLCJlIBJYyNKtFzoR)
			{
				running = false;
				return true;
			}
			return false;
		}

		public void Clear()
		{
			running = false;
			MKrJnRhMmOOPLCJlIBJYyNKtFzoR = 0.0;
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
