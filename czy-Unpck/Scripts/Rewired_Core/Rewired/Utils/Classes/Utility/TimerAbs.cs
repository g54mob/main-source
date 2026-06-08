using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Utility
{
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class TimerAbs
	{
		public bool running;

		[SerializeField]
		private double EKcwtghsTqCNrTxAELabSDmUaKz;

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
			EKcwtghsTqCNrTxAELabSDmUaKz = length + ReInput.unscaledTime;
		}

		public void Start(double inLength)
		{
			running = true;
			length = inLength;
			while (true)
			{
				int num = -159455239;
				while (true)
				{
					switch (num ^ -159455240)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						goto IL_002c;
					case 0:
						return;
					}
					break;
					IL_002c:
					EKcwtghsTqCNrTxAELabSDmUaKz = length + ReInput.unscaledTime;
					num = -159455240;
				}
			}
		}

		public bool Update()
		{
			if (!running)
			{
				return false;
			}
			if (ReInput.unscaledTime >= EKcwtghsTqCNrTxAELabSDmUaKz)
			{
				running = false;
				return true;
			}
			return false;
		}

		public void Clear()
		{
			running = false;
			EKcwtghsTqCNrTxAELabSDmUaKz = 0.0;
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
