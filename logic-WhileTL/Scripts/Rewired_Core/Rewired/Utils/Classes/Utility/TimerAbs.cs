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
		private double kDjssXLhyxEIsaMKZTfnsSVqOrOBb;

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
			kDjssXLhyxEIsaMKZTfnsSVqOrOBb = length + ReInput.unscaledTime;
		}

		public void Start(double inLength)
		{
			running = true;
			length = inLength;
			kDjssXLhyxEIsaMKZTfnsSVqOrOBb = length + ReInput.unscaledTime;
		}

		public bool Update()
		{
			if (!running)
			{
				return false;
			}
			if (ReInput.unscaledTime >= kDjssXLhyxEIsaMKZTfnsSVqOrOBb)
			{
				running = false;
				return true;
			}
			return false;
		}

		public void Clear()
		{
			running = false;
			kDjssXLhyxEIsaMKZTfnsSVqOrOBb = 0.0;
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
