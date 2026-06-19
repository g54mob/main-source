using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Utility
{
	[Serializable]
	[CustomObfuscation(rename = false)]
	internal class Timer
	{
		public bool running;

		[SerializeField]
		private double timer;

		public double length;

		public Timer()
		{
		}

		public Timer(double inLength)
		{
			length = inLength;
		}

		public void PUfBGkQEoKKPRrTrZNGGdNNSToS()
		{
			running = true;
			timer = length;
		}

		public void PUfBGkQEoKKPRrTrZNGGdNNSToS(double P_0)
		{
			running = true;
			length = P_0;
			timer = length;
		}

		public void gLicjynlUvWYLInHpwPHTHUkekNf()
		{
			dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
			PUfBGkQEoKKPRrTrZNGGdNNSToS();
		}

		public bool QTPiZFmnRsxmyQYmMuIoBQkOtfg(double P_0)
		{
			if (!running)
			{
				return false;
			}
			timer -= P_0;
			if (timer <= 0.0)
			{
				running = false;
				return true;
			}
			return false;
		}

		public void dLvQQBBPNcDLyfQfBHFGJrYJbsBD()
		{
			running = false;
			timer = 0.0;
		}

		public void AZLQSxXLYugzhhlVgDTXdQBEiyZF(double P_0)
		{
			length = P_0;
		}

		public Timer AqgeNRkgwzpPIRfsEjgMCeSKqLh()
		{
			return (Timer)MemberwiseClone();
		}
	}
}
