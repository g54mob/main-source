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

		public void fwiTIsmfGNlAknieVpYkmQbeVWjo()
		{
			running = true;
			timer = length;
		}

		public void VBUkXfjJfMiZTajKbHGUAimkIcqC(double P_0)
		{
			running = true;
			length = P_0;
			timer = length;
		}

		public void UfdsXvgKYcliJRhxOZkdkBhUSorV()
		{
			zbBUjwVpNXatxDTymaIbKBHezoXcA();
			fwiTIsmfGNlAknieVpYkmQbeVWjo();
		}

		public bool HhVLEmyUFdDswbYLntRZyalmLsmN(double P_0)
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

		public void zbBUjwVpNXatxDTymaIbKBHezoXcA()
		{
			running = false;
			timer = 0.0;
		}

		public void WMuDtjHvsRoyZFBLIfhGDmuFjULD(double P_0)
		{
			length = P_0;
		}

		public Timer HAQrvbPiZGAzFGayqxzEnwXyxZxJ()
		{
			return (Timer)MemberwiseClone();
		}
	}
}
