using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Utils;

namespace Rewired.HID
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class HIDLight
	{
		private byte PdPjdZDmNAoprvvFgEOlPMiGgkAj;

		private byte xAMZTBjEOJiEHtXdpbzBHDManoUmA;

		private byte EQItVxvlMqCJAESqhNMdjyPGWracB;

		[CompilerGenerated]
		private Action xBPFWWBHHindayCrQlKoGKQGxZcTb;

		public float ColorR
		{
			get
			{
				return (float)(int)PdPjdZDmNAoprvvFgEOlPMiGgkAj / 255f;
			}
			set
			{
				ColorRRaw = (byte)MathTools.Clamp((int)(value * 255f), 0, 255);
			}
		}

		public float ColorG
		{
			get
			{
				return (float)(int)xAMZTBjEOJiEHtXdpbzBHDManoUmA / 255f;
			}
			set
			{
				ColorGRaw = (byte)MathTools.Clamp((int)(value * 255f), 0, 255);
			}
		}

		public float ColorB
		{
			get
			{
				return (float)(int)EQItVxvlMqCJAESqhNMdjyPGWracB / 255f;
			}
			set
			{
				ColorBRaw = (byte)MathTools.Clamp((int)(value * 255f), 0, 255);
			}
		}

		public byte ColorRRaw
		{
			get
			{
				return PdPjdZDmNAoprvvFgEOlPMiGgkAj;
			}
			set
			{
				PdPjdZDmNAoprvvFgEOlPMiGgkAj = value;
				if (xBPFWWBHHindayCrQlKoGKQGxZcTb != null)
				{
					xBPFWWBHHindayCrQlKoGKQGxZcTb();
				}
			}
		}

		public byte ColorGRaw
		{
			get
			{
				return xAMZTBjEOJiEHtXdpbzBHDManoUmA;
			}
			set
			{
				xAMZTBjEOJiEHtXdpbzBHDManoUmA = value;
				if (xBPFWWBHHindayCrQlKoGKQGxZcTb != null)
				{
					xBPFWWBHHindayCrQlKoGKQGxZcTb();
				}
			}
		}

		public byte ColorBRaw
		{
			get
			{
				return EQItVxvlMqCJAESqhNMdjyPGWracB;
			}
			set
			{
				EQItVxvlMqCJAESqhNMdjyPGWracB = value;
				if (xBPFWWBHHindayCrQlKoGKQGxZcTb != null)
				{
					xBPFWWBHHindayCrQlKoGKQGxZcTb();
				}
			}
		}

		public event Action ValueChangedEvent
		{
			[CompilerGenerated]
			add
			{
				Action action = xBPFWWBHHindayCrQlKoGKQGxZcTb;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, value);
					action = Interlocked.CompareExchange(ref xBPFWWBHHindayCrQlKoGKQGxZcTb, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = xBPFWWBHHindayCrQlKoGKQGxZcTb;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value);
					action = Interlocked.CompareExchange(ref xBPFWWBHHindayCrQlKoGKQGxZcTb, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		public HIDLight()
		{
		}

		public HIDLight(byte P_0, byte P_1, byte P_2)
		{
			PdPjdZDmNAoprvvFgEOlPMiGgkAj = P_0;
			xAMZTBjEOJiEHtXdpbzBHDManoUmA = P_1;
			EQItVxvlMqCJAESqhNMdjyPGWracB = P_2;
		}
	}
}
