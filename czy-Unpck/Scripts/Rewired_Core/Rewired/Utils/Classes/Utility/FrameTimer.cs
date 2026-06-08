using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Utility
{
	[Serializable]
	[CustomObfuscation(rename = false)]
	internal class FrameTimer
	{
		public bool running;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private double timeRemaining;

		public double length;

		public double overrunBuffer;

		public FrameTimer()
		{
		}

		public FrameTimer(double inLength)
		{
			length = inLength;
		}

		public void NoiITHOkBgdirKSZopWLLfLYZOJ()
		{
			running = true;
			timeRemaining = length;
		}

		public void NoiITHOkBgdirKSZopWLLfLYZOJ(double P_0)
		{
			running = true;
			length = P_0;
			timeRemaining = length;
		}

		public bool GzCliicOSMFLMvKajLgvnmGSSrh(double P_0, double P_1)
		{
			if (!running)
			{
				goto IL_000b;
			}
			double num = ((P_1 > 0.0) ? (timeRemaining / P_1) : timeRemaining);
			num -= P_0;
			int num2 = -1583450892;
			goto IL_0010;
			IL_000b:
			num2 = -1583450891;
			goto IL_0010;
			IL_0010:
			while (true)
			{
				switch (num2 ^ -1583450896)
				{
				case 2:
					break;
				case 0:
					if (num <= 0.0)
					{
						running = false;
						int num3;
						if (num < 0.0)
						{
							num2 = -1583450893;
							num3 = num2;
						}
						else
						{
							num2 = -1583450890;
							num3 = num2;
						}
						continue;
					}
					timeRemaining = num * P_1;
					overrunBuffer = 0.0;
					return false;
				case 4:
					if (overrunBuffer > 0.0)
					{
						num -= overrunBuffer;
						num2 = -1583450896;
						continue;
					}
					goto case 0;
				case 6:
					overrunBuffer = 0.0;
					num2 = -1583450895;
					continue;
				case 3:
					overrunBuffer = num * -1.0;
					num2 = -1583450895;
					continue;
				case 5:
					return false;
				default:
					return true;
				}
				break;
			}
			goto IL_000b;
		}

		public void tAgADqjTsMUxSqYXeDyJIdETYRAp()
		{
			running = false;
			timeRemaining = 0.0;
			overrunBuffer = 0.0;
		}

		public void SuCyZSTDfKaLRCBbLTgUcQBAnFM(double P_0)
		{
			length = P_0;
		}

		public FrameTimer EilcbgeeBHODbenDzVGhaquGLZK()
		{
			return (FrameTimer)MemberwiseClone();
		}
	}
}
