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

		public Timer(double P_0)
		{
			length = P_0;
		}

		public void YzxJYzIGUbUuQcUjIpyhOcHzsJaf()
		{
			running = true;
			timer = length;
		}

		public void YzxJYzIGUbUuQcUjIpyhOcHzsJaf(double P_0)
		{
			running = true;
			length = P_0;
			timer = length;
		}

		public void tJwArrlPuIdDCHkLwFcoFcSPYmnIA()
		{
			wJjPIIRJfHhEbGedUconecGfiwzgB();
			YzxJYzIGUbUuQcUjIpyhOcHzsJaf();
		}

		public bool DsDuSUaDcVanpNAhDLIRqjKndMGi(double P_0)
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

		public void wJjPIIRJfHhEbGedUconecGfiwzgB()
		{
			running = false;
			timer = 0.0;
		}

		public void HzBnAwZbkHueqicLlriedILhicrgA(double P_0)
		{
			length = P_0;
		}

		public Timer LecwYkPGCIgQEQdPCCJhfwkvopKc()
		{
			return (Timer)MemberwiseClone();
		}
	}
}
