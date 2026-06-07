using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Utils;

namespace Rewired.HID
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class HIDLight
	{
		private byte eepuaiDWNAzeebumdhpJeAKWTpqI;

		private byte aFXsOnyWAuVatJTLyFczboGkwZGn;

		private byte CMYcPlIkaUBlPsLDCQkmNvFDbvxBA;

		[CompilerGenerated]
		private Action riWNrEnWExhehMObgzCSbNZnlOuR;

		public float ColorR
		{
			get
			{
				return (float)(int)eepuaiDWNAzeebumdhpJeAKWTpqI / 255f;
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
				return (float)(int)aFXsOnyWAuVatJTLyFczboGkwZGn / 255f;
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
				return (float)(int)CMYcPlIkaUBlPsLDCQkmNvFDbvxBA / 255f;
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
				return eepuaiDWNAzeebumdhpJeAKWTpqI;
			}
			set
			{
				eepuaiDWNAzeebumdhpJeAKWTpqI = value;
				if (riWNrEnWExhehMObgzCSbNZnlOuR != null)
				{
					riWNrEnWExhehMObgzCSbNZnlOuR();
				}
			}
		}

		public byte ColorGRaw
		{
			get
			{
				return aFXsOnyWAuVatJTLyFczboGkwZGn;
			}
			set
			{
				aFXsOnyWAuVatJTLyFczboGkwZGn = value;
				if (riWNrEnWExhehMObgzCSbNZnlOuR != null)
				{
					riWNrEnWExhehMObgzCSbNZnlOuR();
				}
			}
		}

		public byte ColorBRaw
		{
			get
			{
				return CMYcPlIkaUBlPsLDCQkmNvFDbvxBA;
			}
			set
			{
				CMYcPlIkaUBlPsLDCQkmNvFDbvxBA = value;
				if (riWNrEnWExhehMObgzCSbNZnlOuR != null)
				{
					riWNrEnWExhehMObgzCSbNZnlOuR();
				}
			}
		}

		public event Action ValueChangedEvent
		{
			[CompilerGenerated]
			add
			{
				Action action = riWNrEnWExhehMObgzCSbNZnlOuR;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, value);
					action = Interlocked.CompareExchange(ref riWNrEnWExhehMObgzCSbNZnlOuR, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = riWNrEnWExhehMObgzCSbNZnlOuR;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value);
					action = Interlocked.CompareExchange(ref riWNrEnWExhehMObgzCSbNZnlOuR, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		public HIDLight()
		{
		}

		public HIDLight(byte P_0, byte P_1, byte P_2)
		{
			eepuaiDWNAzeebumdhpJeAKWTpqI = P_0;
			aFXsOnyWAuVatJTLyFczboGkwZGn = P_1;
			CMYcPlIkaUBlPsLDCQkmNvFDbvxBA = P_2;
		}
	}
}
