using System;
using System.Threading;
using Rewired.Utils;

namespace Rewired.HID
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class HIDLight
	{
		private byte pTSrvanTwXPcwiAXpuknLAFiGRh;

		private byte TnXFkoBzvSUkMqbjmBJLJhUUNWr;

		private byte ubHLZMVblhLCBRHccayxyVsqrGV;

		private Action HCAUfwpghrvdiBrRQgkVOjJniFj;

		public float ColorR
		{
			get
			{
				return (float)(int)pTSrvanTwXPcwiAXpuknLAFiGRh / 255f;
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
				return (float)(int)TnXFkoBzvSUkMqbjmBJLJhUUNWr / 255f;
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
				return (float)(int)ubHLZMVblhLCBRHccayxyVsqrGV / 255f;
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
				return pTSrvanTwXPcwiAXpuknLAFiGRh;
			}
			set
			{
				pTSrvanTwXPcwiAXpuknLAFiGRh = value;
				while (true)
				{
					int num = -1541404710;
					while (true)
					{
						switch (num ^ -1541404709)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							if (HCAUfwpghrvdiBrRQgkVOjJniFj != null)
							{
								goto IL_002d;
							}
							return;
						case 0:
							return;
						}
						break;
						IL_002d:
						HCAUfwpghrvdiBrRQgkVOjJniFj();
						num = -1541404709;
					}
				}
			}
		}

		public byte ColorGRaw
		{
			get
			{
				return TnXFkoBzvSUkMqbjmBJLJhUUNWr;
			}
			set
			{
				TnXFkoBzvSUkMqbjmBJLJhUUNWr = value;
				if (HCAUfwpghrvdiBrRQgkVOjJniFj == null)
				{
					return;
				}
				while (true)
				{
					int num = -1807755255;
					while (true)
					{
						switch (num ^ -1807755256)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							goto IL_002d;
						case 0:
							return;
						}
						break;
						IL_002d:
						HCAUfwpghrvdiBrRQgkVOjJniFj();
						num = -1807755256;
					}
				}
			}
		}

		public byte ColorBRaw
		{
			get
			{
				return ubHLZMVblhLCBRHccayxyVsqrGV;
			}
			set
			{
				ubHLZMVblhLCBRHccayxyVsqrGV = value;
				if (HCAUfwpghrvdiBrRQgkVOjJniFj != null)
				{
					HCAUfwpghrvdiBrRQgkVOjJniFj();
				}
			}
		}

		public event Action ValueChangedEvent
		{
			add
			{
				Action action = HCAUfwpghrvdiBrRQgkVOjJniFj;
				Action action2 = default(Action);
				Action value2 = default(Action);
				while (true)
				{
					int num = -1008921801;
					while (true)
					{
						switch (num ^ -1008921803)
						{
						case 0:
							break;
						case 2:
							action2 = action;
							num = -1008921804;
							continue;
						case 1:
							value2 = (Action)Delegate.Combine(action2, value);
							num = -1008921802;
							continue;
						default:
							action = Interlocked.CompareExchange(ref HCAUfwpghrvdiBrRQgkVOjJniFj, value2, action2);
							if ((object)action == action2)
							{
								return;
							}
							goto case 2;
						}
						break;
					}
				}
			}
			remove
			{
				Action action = HCAUfwpghrvdiBrRQgkVOjJniFj;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value);
					action = Interlocked.CompareExchange(ref HCAUfwpghrvdiBrRQgkVOjJniFj, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		public HIDLight()
		{
		}

		public HIDLight(byte colorRRaw, byte colorGRaw, byte colorBRaw)
		{
			pTSrvanTwXPcwiAXpuknLAFiGRh = colorRRaw;
			TnXFkoBzvSUkMqbjmBJLJhUUNWr = colorGRaw;
			ubHLZMVblhLCBRHccayxyVsqrGV = colorBRaw;
		}
	}
}
