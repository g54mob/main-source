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
		private float timer;

		public float length;

		public Timer()
		{
		}

		public Timer(float inLength)
		{
			length = inLength;
		}

		public void gvigjQaykylkiDxmhkUQKBzXkGmr()
		{
			running = true;
			timer = length;
		}

		public void gvigjQaykylkiDxmhkUQKBzXkGmr(float P_0)
		{
			running = true;
			length = P_0;
			while (true)
			{
				int num = -1767326342;
				while (true)
				{
					switch (num ^ -1767326341)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						goto IL_002c;
					case 2:
						return;
					}
					break;
					IL_002c:
					timer = length;
					num = -1767326343;
				}
			}
		}

		public void XefaJAbPMFQxgDSWaBDVNrslxAvL()
		{
			QYwkAfdRMMgAPnyPzHFUdcsKUPp();
			gvigjQaykylkiDxmhkUQKBzXkGmr();
		}

		public bool rdEJYvExbWYUXSDuseVgzyXPBhA(float P_0)
		{
			if (!running)
			{
				return false;
			}
			timer -= P_0;
			if (timer <= 0f)
			{
				running = false;
				return true;
			}
			return false;
		}

		public void QYwkAfdRMMgAPnyPzHFUdcsKUPp()
		{
			running = false;
			timer = 0f;
		}

		public void znWkNgvMxWQGjdGxYBNxchHTOpT(float P_0)
		{
			length = P_0;
		}

		public Timer zGjqClOCiLpYyXYoyjxggUSDIMx()
		{
			return (Timer)MemberwiseClone();
		}
	}
}
