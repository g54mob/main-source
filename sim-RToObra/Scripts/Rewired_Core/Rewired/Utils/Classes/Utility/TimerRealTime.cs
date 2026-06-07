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
		private float QNkMYqzOmqtoZWNafUcizeGTTCD;

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
			QNkMYqzOmqtoZWNafUcizeGTTCD = length + ReInput.realTime;
		}

		public void Start(float inLength)
		{
			running = true;
			while (true)
			{
				int num = -933091914;
				while (true)
				{
					switch (num ^ -933091916)
					{
					case 0:
						break;
					case 2:
						goto IL_0025;
					default:
						QNkMYqzOmqtoZWNafUcizeGTTCD = length + ReInput.realTime;
						return;
					}
					break;
					IL_0025:
					length = inLength;
					num = -933091915;
				}
			}
		}

		public bool Update()
		{
			if (!running)
			{
				return false;
			}
			if (ReInput.realTime >= QNkMYqzOmqtoZWNafUcizeGTTCD)
			{
				running = false;
				return true;
			}
			return false;
		}

		public void Clear()
		{
			running = false;
			QNkMYqzOmqtoZWNafUcizeGTTCD = 0f;
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
