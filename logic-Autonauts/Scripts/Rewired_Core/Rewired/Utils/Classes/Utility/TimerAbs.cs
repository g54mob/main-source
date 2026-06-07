using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Utility
{
	[Serializable]
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class TimerAbs
	{
		public bool running;

		[SerializeField]
		private float roeHTpBQgiwJcggpFiwkKRGNDNMc;

		public float length;

		public TimerAbs()
		{
		}

		public TimerAbs(float inLength)
		{
			length = inLength;
		}

		public void Start()
		{
			running = true;
			roeHTpBQgiwJcggpFiwkKRGNDNMc = length + ReInput.unscaledTime;
		}

		public void Start(float inLength)
		{
			running = true;
			length = inLength;
			while (true)
			{
				int num = 435215902;
				while (true)
				{
					switch (num ^ 0x19F0DE1C)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						goto IL_002c;
					case 1:
						return;
					}
					break;
					IL_002c:
					roeHTpBQgiwJcggpFiwkKRGNDNMc = length + ReInput.unscaledTime;
					num = 435215901;
				}
			}
		}

		public bool Update()
		{
			if (!running)
			{
				goto IL_0008;
			}
			int num;
			if (ReInput.unscaledTime >= roeHTpBQgiwJcggpFiwkKRGNDNMc)
			{
				num = -1724181219;
				goto IL_000d;
			}
			return false;
			IL_0008:
			num = -1724181218;
			goto IL_000d;
			IL_000d:
			switch (num ^ -1724181220)
			{
			case 0:
				break;
			case 2:
				return false;
			default:
				running = false;
				return true;
			}
			goto IL_0008;
		}

		public void Clear()
		{
			running = false;
			roeHTpBQgiwJcggpFiwkKRGNDNMc = 0f;
		}

		public void SetLength(float inLength)
		{
			length = inLength;
		}

		public TimerAbs Clone()
		{
			return (TimerAbs)MemberwiseClone();
		}
	}
}
