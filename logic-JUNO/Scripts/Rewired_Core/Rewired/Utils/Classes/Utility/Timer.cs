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

		public void hrgEGXEYgiTAouAMPfLycpeYcfsaA()
		{
			running = true;
			timer = length;
		}

		public void ZjCQuODjjjwdZxMJtHYYEijWbndP(double P_0)
		{
			running = true;
			length = P_0;
			timer = length;
		}

		public void EYrXqYGwLHzsXABaWxNnqkWeVOee()
		{
			nHRzqDxjtocKbYOlqFClVSeKVySE();
			hrgEGXEYgiTAouAMPfLycpeYcfsaA();
		}

		public bool LUBIlJAbxYtZuqujpGgBmpiCNidJ(double P_0)
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

		public void nHRzqDxjtocKbYOlqFClVSeKVySE()
		{
			running = false;
			timer = 0.0;
		}

		public void QTcMHIvSBmmxLGLbWMaYDLjvHAAY(double P_0)
		{
			length = P_0;
		}

		public Timer BNExHOtHrpicVxaMyFkGrzSGcoaN()
		{
			return (Timer)MemberwiseClone();
		}
	}
}
