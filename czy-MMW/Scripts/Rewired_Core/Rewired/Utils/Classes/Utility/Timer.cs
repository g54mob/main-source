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

		public void zkbVJWHrYSmptyHJvyduUMEVZGdB()
		{
			running = true;
			timer = length;
		}

		public void PgXgtCJWuRDOIDhOPtpLgeLHXFTFB(double P_0)
		{
			running = true;
			length = P_0;
			timer = length;
		}

		public void IfcSwUFGjpFQYIlAipSqOtEbldAr()
		{
			jeEgJZyXgOTmaCHFUcuixaoNVdwX();
			zkbVJWHrYSmptyHJvyduUMEVZGdB();
		}

		public bool DbKFRZZvoaUGlcwmTRzCSeEFddDHA(double P_0)
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

		public void jeEgJZyXgOTmaCHFUcuixaoNVdwX()
		{
			running = false;
			timer = 0.0;
		}

		public void MqfAESawMCuWKJMmwtRPKjBoncofA(double P_0)
		{
			length = P_0;
		}

		public Timer XJVerIwCsPhPAxZDMqJZBDsFCIGeA()
		{
			return (Timer)MemberwiseClone();
		}
	}
}
