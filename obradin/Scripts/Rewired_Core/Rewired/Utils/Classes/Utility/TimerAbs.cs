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
		private float QNkMYqzOmqtoZWNafUcizeGTTCD;

		public float length;

		public TimerAbs()
		{
		}

		public TimerAbs(float inLength)
		{
			length = inLength;
		}

		public void Start()
		{
			running = true;
			QNkMYqzOmqtoZWNafUcizeGTTCD = length + ReInput.unscaledTime;
		}

		public void Start(float inLength)
		{
			running = true;
			length = inLength;
			QNkMYqzOmqtoZWNafUcizeGTTCD = length + ReInput.unscaledTime;
		}

		public bool Update()
		{
			if (!running)
			{
				return false;
			}
			if (ReInput.unscaledTime >= QNkMYqzOmqtoZWNafUcizeGTTCD)
			{
				running = false;
				return true;
			}
			return false;
		}

		public void Clear()
		{
			running = false;
			while (true)
			{
				int num = -1938655941;
				while (true)
				{
					switch (num ^ -1938655942)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						goto IL_0025;
					case 2:
						return;
					}
					break;
					IL_0025:
					QNkMYqzOmqtoZWNafUcizeGTTCD = 0f;
					num = -1938655944;
				}
			}
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
