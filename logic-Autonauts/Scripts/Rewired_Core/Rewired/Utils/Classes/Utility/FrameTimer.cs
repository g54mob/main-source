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
		private float timeRemaining;

		public float length;

		public float overrunBuffer;

		public FrameTimer()
		{
		}

		public FrameTimer(float inLength)
		{
			length = inLength;
		}

		public void gvigjQaykylkiDxmhkUQKBzXkGmr()
		{
			running = true;
			timeRemaining = length;
		}

		public void gvigjQaykylkiDxmhkUQKBzXkGmr(float P_0)
		{
			running = true;
			while (true)
			{
				int num = -1932000766;
				while (true)
				{
					switch (num ^ -1932000765)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						goto IL_0025;
					case 0:
						return;
					}
					break;
					IL_0025:
					length = P_0;
					timeRemaining = length;
					num = -1932000765;
				}
			}
		}

		public bool rdEJYvExbWYUXSDuseVgzyXPBhA(float P_0, float P_1)
		{
			if (!running)
			{
				return false;
			}
			float num = ((P_1 > 0f) ? (timeRemaining / P_1) : timeRemaining);
			num -= P_0;
			if (overrunBuffer > 0f)
			{
				goto IL_0037;
			}
			goto IL_00c2;
			IL_0037:
			int num2 = -477421118;
			goto IL_003c;
			IL_00c2:
			if (!(num <= 0f))
			{
				timeRemaining = num * P_1;
				overrunBuffer = 0f;
				num2 = -477421115;
			}
			else
			{
				num2 = -477421117;
			}
			goto IL_003c;
			IL_003c:
			while (true)
			{
				switch (num2 ^ -477421120)
				{
				case 0:
					break;
				case 2:
					num -= overrunBuffer;
					num2 = -477421114;
					continue;
				case 1:
					overrunBuffer = num * -1f;
					num2 = -477421112;
					continue;
				case 3:
					running = false;
					num2 = -477421116;
					continue;
				case 8:
					return true;
				case 6:
					goto IL_00c2;
				case 7:
					overrunBuffer = 0f;
					num2 = -477421112;
					continue;
				case 4:
					goto IL_00e9;
				default:
					return false;
				}
				break;
				IL_00e9:
				int num3;
				if (num >= 0f)
				{
					num2 = -477421113;
					num3 = num2;
				}
				else
				{
					num2 = -477421119;
					num3 = num2;
				}
			}
			goto IL_0037;
		}

		public void QYwkAfdRMMgAPnyPzHFUdcsKUPp()
		{
			running = false;
			timeRemaining = 0f;
			overrunBuffer = 0f;
		}

		public void znWkNgvMxWQGjdGxYBNxchHTOpT(float P_0)
		{
			length = P_0;
		}

		public FrameTimer zGjqClOCiLpYyXYoyjxggUSDIMx()
		{
			return (FrameTimer)MemberwiseClone();
		}
	}
}
