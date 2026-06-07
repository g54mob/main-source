using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Utility
{
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class TimerRealTime
	{
		public bool running;

		[SerializeField]
		private float roeHTpBQgiwJcggpFiwkKRGNDNMc;

		public float length;

		public TimerRealTime()
		{
		}

		public TimerRealTime(float inLength)
		{
			length = inLength;
		}

		public void Start()
		{
			running = true;
			roeHTpBQgiwJcggpFiwkKRGNDNMc = length + ReInput.realTime;
		}

		public void Start(float inLength)
		{
			running = true;
			length = inLength;
			roeHTpBQgiwJcggpFiwkKRGNDNMc = length + ReInput.realTime;
		}

		public bool Update()
		{
			if (!running)
			{
				return false;
			}
			if (ReInput.realTime >= roeHTpBQgiwJcggpFiwkKRGNDNMc)
			{
				while (true)
				{
					int num = -230980252;
					while (true)
					{
						switch (num ^ -230980250)
						{
						case 0:
							break;
						case 2:
							goto IL_0035;
						default:
							return true;
						}
						break;
						IL_0035:
						running = false;
						num = -230980249;
					}
				}
			}
			return false;
		}

		public void Clear()
		{
			running = false;
			roeHTpBQgiwJcggpFiwkKRGNDNMc = 0f;
		}

		public void SetLength(float inLength)
		{
			length = inLength;
		}

		public TimerAbs Clone()
		{
			return (TimerAbs)MemberwiseClone();
		}
	}
}
