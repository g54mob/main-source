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
		private double MtmgCzagbBnJwabuvdqaDVdhnlXN;

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
			MtmgCzagbBnJwabuvdqaDVdhnlXN = length + ReInput.realTime;
		}

		public void Start(double inLength)
		{
			running = true;
			length = inLength;
			MtmgCzagbBnJwabuvdqaDVdhnlXN = length + ReInput.realTime;
		}

		public bool Update()
		{
			if (!running)
			{
				return false;
			}
			if (ReInput.realTime >= MtmgCzagbBnJwabuvdqaDVdhnlXN)
			{
				running = false;
				return true;
			}
			return false;
		}

		public void Clear()
		{
			running = false;
			MtmgCzagbBnJwabuvdqaDVdhnlXN = 0.0;
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
