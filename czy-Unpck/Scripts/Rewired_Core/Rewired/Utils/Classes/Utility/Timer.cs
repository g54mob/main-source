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

		public void NoiITHOkBgdirKSZopWLLfLYZOJ()
		{
			running = true;
			timer = length;
		}

		public void NoiITHOkBgdirKSZopWLLfLYZOJ(double P_0)
		{
			running = true;
			length = P_0;
			timer = length;
		}

		public void exhqDHttYNsutpxCQesQfKUkREI()
		{
			tAgADqjTsMUxSqYXeDyJIdETYRAp();
			NoiITHOkBgdirKSZopWLLfLYZOJ();
		}

		public bool GzCliicOSMFLMvKajLgvnmGSSrh(double P_0)
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

		public void tAgADqjTsMUxSqYXeDyJIdETYRAp()
		{
			running = false;
			timer = 0.0;
		}

		public void SuCyZSTDfKaLRCBbLTgUcQBAnFM(double P_0)
		{
			length = P_0;
		}

		public Timer EilcbgeeBHODbenDzVGhaquGLZK()
		{
			return (Timer)MemberwiseClone();
		}
	}
}
