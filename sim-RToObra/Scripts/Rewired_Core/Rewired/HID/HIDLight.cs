using System;
using System.Threading;
using Rewired.Utils;

namespace Rewired.HID
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class HIDLight
	{
		private byte btODrqrTXLIQQrwfSRNgazppDrT;

		private byte ZPBVbmZTCQvkmpKDDwuOinVLlLH;

		private byte igVxxQLKMzPhpMmYVXPiNICtYwv;

		private Action VLIacpadFzqLReAPgFHzRrPMtwzS;

		public float ColorR
		{
			get
			{
				return (float)(int)btODrqrTXLIQQrwfSRNgazppDrT / 255f;
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
				return (float)(int)ZPBVbmZTCQvkmpKDDwuOinVLlLH / 255f;
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
				return (float)(int)igVxxQLKMzPhpMmYVXPiNICtYwv / 255f;
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
				return btODrqrTXLIQQrwfSRNgazppDrT;
			}
			set
			{
				btODrqrTXLIQQrwfSRNgazppDrT = value;
				if (VLIacpadFzqLReAPgFHzRrPMtwzS != null)
				{
					VLIacpadFzqLReAPgFHzRrPMtwzS();
				}
			}
		}

		public byte ColorGRaw
		{
			get
			{
				return ZPBVbmZTCQvkmpKDDwuOinVLlLH;
			}
			set
			{
				ZPBVbmZTCQvkmpKDDwuOinVLlLH = value;
				if (VLIacpadFzqLReAPgFHzRrPMtwzS == null)
				{
					return;
				}
				while (true)
				{
					int num = -353221379;
					while (true)
					{
						switch (num ^ -353221377)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							goto IL_002d;
						case 1:
							return;
						}
						break;
						IL_002d:
						VLIacpadFzqLReAPgFHzRrPMtwzS();
						num = -353221378;
					}
				}
			}
		}

		public byte ColorBRaw
		{
			get
			{
				return igVxxQLKMzPhpMmYVXPiNICtYwv;
			}
			set
			{
				igVxxQLKMzPhpMmYVXPiNICtYwv = value;
				while (true)
				{
					int num = -334274664;
					while (true)
					{
						switch (num ^ -334274663)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							if (VLIacpadFzqLReAPgFHzRrPMtwzS != null)
							{
								goto IL_002d;
							}
							return;
						case 2:
							return;
						}
						break;
						IL_002d:
						VLIacpadFzqLReAPgFHzRrPMtwzS();
						num = -334274661;
					}
				}
			}
		}

		public event Action ValueChangedEvent
		{
			add
			{
				Action action = VLIacpadFzqLReAPgFHzRrPMtwzS;
				Action action2 = default(Action);
				while (true)
				{
					int num = -273025068;
					while (true)
					{
						switch (num ^ -273025066)
						{
						case 0:
							break;
						case 2:
							goto IL_0025;
						default:
						{
							Action value2 = (Action)Delegate.Combine(action2, value);
							action = Interlocked.CompareExchange(ref VLIacpadFzqLReAPgFHzRrPMtwzS, value2, action2);
							if ((object)action != action2)
							{
								goto IL_0025;
							}
							return;
						}
						}
						break;
						IL_0025:
						action2 = action;
						num = -273025065;
					}
				}
			}
			remove
			{
				Action action = VLIacpadFzqLReAPgFHzRrPMtwzS;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value);
					action = Interlocked.CompareExchange(ref VLIacpadFzqLReAPgFHzRrPMtwzS, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		public HIDLight()
		{
		}

		public HIDLight(byte colorRRaw, byte colorGRaw, byte colorBRaw)
		{
			btODrqrTXLIQQrwfSRNgazppDrT = colorRRaw;
			ZPBVbmZTCQvkmpKDDwuOinVLlLH = colorGRaw;
			igVxxQLKMzPhpMmYVXPiNICtYwv = colorBRaw;
		}
	}
}
