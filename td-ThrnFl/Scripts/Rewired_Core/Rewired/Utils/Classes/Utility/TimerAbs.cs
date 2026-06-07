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
		private double WUTaUXoBKOjIDaPDVLwEoVPJGDvw;

		public double length;

		public TimerAbs()
		{
		}

		public TimerAbs(double P_0)
		{
			length = P_0;
		}

		public void Start()
		{
			running = true;
			WUTaUXoBKOjIDaPDVLwEoVPJGDvw = length + ReInput.unscaledTime;
		}

		public void Start(double inLength)
		{
			running = true;
			length = inLength;
			WUTaUXoBKOjIDaPDVLwEoVPJGDvw = length + ReInput.unscaledTime;
		}

		public bool Update()
		{
			if (!running)
			{
				return false;
			}
			if (ReInput.unscaledTime >= WUTaUXoBKOjIDaPDVLwEoVPJGDvw)
			{
				running = false;
				return true;
			}
			return false;
		}

		public void Clear()
		{
			running = false;
			WUTaUXoBKOjIDaPDVLwEoVPJGDvw = 0.0;
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
