using System;
using System.Threading;
using Rewired.Utils;

namespace Rewired.HID
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class HIDVibrationMotor
	{
		private int cpuZLeRAUBGhnmovvJZUlTZFgaT;

		private int zSKyqOhQNAJJJCqsIUIyIXfeNYh;

		private int jRNMAByRoYTItOWQUDhZaNkGwtI;

		private Action LnNZXAxFBHDNVeiViTPpokfDGNMJ;

		public float Speed
		{
			get
			{
				return KXTCGfGsJuKIqdInfYYOhOsKfbeK(cpuZLeRAUBGhnmovvJZUlTZFgaT);
			}
			set
			{
				cpuZLeRAUBGhnmovvJZUlTZFgaT = zmqSdocnJveGmGCvVyHrOBcsGy(value);
				if (LnNZXAxFBHDNVeiViTPpokfDGNMJ != null)
				{
					LnNZXAxFBHDNVeiViTPpokfDGNMJ();
				}
			}
		}

		public int SpeedRaw
		{
			get
			{
				return cpuZLeRAUBGhnmovvJZUlTZFgaT;
			}
			set
			{
				cpuZLeRAUBGhnmovvJZUlTZFgaT = value;
				if (LnNZXAxFBHDNVeiViTPpokfDGNMJ != null)
				{
					LnNZXAxFBHDNVeiViTPpokfDGNMJ();
				}
			}
		}

		public event Action ValueChangedEvent
		{
			add
			{
				Action action = LnNZXAxFBHDNVeiViTPpokfDGNMJ;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, value);
					action = Interlocked.CompareExchange(ref LnNZXAxFBHDNVeiViTPpokfDGNMJ, value2, action2);
				}
				while ((object)action != action2);
			}
			remove
			{
				Action action = LnNZXAxFBHDNVeiViTPpokfDGNMJ;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value);
					action = Interlocked.CompareExchange(ref LnNZXAxFBHDNVeiViTPpokfDGNMJ, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		public HIDVibrationMotor(int minSpeedRaw, int maxSpeedRaw)
		{
			zSKyqOhQNAJJJCqsIUIyIXfeNYh = minSpeedRaw;
			jRNMAByRoYTItOWQUDhZaNkGwtI = maxSpeedRaw;
		}

		private float KXTCGfGsJuKIqdInfYYOhOsKfbeK(int P_0)
		{
			return MathTools.Clamp((float)P_0 / (float)jRNMAByRoYTItOWQUDhZaNkGwtI, 0f, 1f);
		}

		private int zmqSdocnJveGmGCvVyHrOBcsGy(float P_0)
		{
			return MathTools.Clamp((int)(P_0 * (float)jRNMAByRoYTItOWQUDhZaNkGwtI), zSKyqOhQNAJJJCqsIUIyIXfeNYh, jRNMAByRoYTItOWQUDhZaNkGwtI);
		}
	}
}
