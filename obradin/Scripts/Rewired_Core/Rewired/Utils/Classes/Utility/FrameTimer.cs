using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Utility
{
	[Serializable]
	[CustomObfuscation(rename = false)]
	internal class FrameTimer
	{
		public bool running;

		[SerializeField]
		[CustomObfuscation(rename = false)]
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

		public void HTeWiJSswgFIFVAtPBCSclhPFDl()
		{
			running = true;
			timeRemaining = length;
		}

		public void HTeWiJSswgFIFVAtPBCSclhPFDl(float P_0)
		{
			running = true;
			length = P_0;
			timeRemaining = length;
		}

		public bool UZSQFwoMfSAzsmmSKmseCCiJWWD(float P_0, float P_1)
		{
			if (!running)
			{
				return false;
			}
			float num = ((P_1 > 0f) ? (timeRemaining / P_1) : timeRemaining);
			num -= P_0;
			while (true)
			{
				int num2 = -1329244686;
				while (true)
				{
					switch (num2 ^ -1329244687)
					{
					case 0:
						break;
					case 4:
						running = false;
						if (num < 0f)
						{
							overrunBuffer = num * -1f;
							num2 = -1329244684;
							continue;
						}
						goto case 2;
					case 1:
						if (num <= 0f)
						{
							num2 = -1329244683;
							continue;
						}
						timeRemaining = num * P_1;
						overrunBuffer = 0f;
						return false;
					case 5:
						num2 = -1329244681;
						continue;
					case 2:
						overrunBuffer = 0f;
						num2 = -1329244681;
						continue;
					case 3:
						if (overrunBuffer > 0f)
						{
							num -= overrunBuffer;
							num2 = -1329244688;
							continue;
						}
						goto case 1;
					default:
						return true;
					}
					break;
				}
			}
		}

		public void nympziBLtYDUiPlWNRoEGqbSPfa()
		{
			running = false;
			timeRemaining = 0f;
			overrunBuffer = 0f;
		}

		public void SsGrxMJOZQxnrTHIkHITHpZPVik(float P_0)
		{
			length = P_0;
		}

		public FrameTimer IxdjXayueLebPlujYihyBmYReRo()
		{
			return (FrameTimer)MemberwiseClone();
		}
	}
}
