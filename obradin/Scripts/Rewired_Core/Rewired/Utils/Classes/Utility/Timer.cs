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

		public void HTeWiJSswgFIFVAtPBCSclhPFDl()
		{
			running = true;
			timer = length;
		}

		public void HTeWiJSswgFIFVAtPBCSclhPFDl(float P_0)
		{
			running = true;
			length = P_0;
			timer = length;
		}

		public void qehfGXrwIHhWHFuXfeFHDCmIzPio()
		{
			nympziBLtYDUiPlWNRoEGqbSPfa();
			HTeWiJSswgFIFVAtPBCSclhPFDl();
		}

		public bool UZSQFwoMfSAzsmmSKmseCCiJWWD(float P_0)
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

		public void nympziBLtYDUiPlWNRoEGqbSPfa()
		{
			running = false;
			timer = 0f;
		}

		public void SsGrxMJOZQxnrTHIkHITHpZPVik(float P_0)
		{
			length = P_0;
		}

		public Timer IxdjXayueLebPlujYihyBmYReRo()
		{
			return (Timer)MemberwiseClone();
		}
	}
}
