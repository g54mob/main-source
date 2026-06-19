using System;
using System.Threading;
using Rewired.Utils;

namespace Rewired.HID
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class HIDLight
	{
		private byte raFbyBdnTlmCSfVvGfDcujRmPqk;

		private byte DkSIuZVYGaqiqHAHZsqWtwpCeMa;

		private byte cMAWXzLOGPlPnanARVqoEbigbCC;

		private Action LnNZXAxFBHDNVeiViTPpokfDGNMJ;

		public float ColorR
		{
			get
			{
				return (float)(int)raFbyBdnTlmCSfVvGfDcujRmPqk / 255f;
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
				return (float)(int)DkSIuZVYGaqiqHAHZsqWtwpCeMa / 255f;
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
				return (float)(int)cMAWXzLOGPlPnanARVqoEbigbCC / 255f;
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
				return raFbyBdnTlmCSfVvGfDcujRmPqk;
			}
			set
			{
				raFbyBdnTlmCSfVvGfDcujRmPqk = value;
				if (LnNZXAxFBHDNVeiViTPpokfDGNMJ != null)
				{
					LnNZXAxFBHDNVeiViTPpokfDGNMJ();
				}
			}
		}

		public byte ColorGRaw
		{
			get
			{
				return DkSIuZVYGaqiqHAHZsqWtwpCeMa;
			}
			set
			{
				DkSIuZVYGaqiqHAHZsqWtwpCeMa = value;
				if (LnNZXAxFBHDNVeiViTPpokfDGNMJ != null)
				{
					LnNZXAxFBHDNVeiViTPpokfDGNMJ();
				}
			}
		}

		public byte ColorBRaw
		{
			get
			{
				return cMAWXzLOGPlPnanARVqoEbigbCC;
			}
			set
			{
				cMAWXzLOGPlPnanARVqoEbigbCC = value;
				if (LnNZXAxFBHDNVeiViTPpokfDGNMJ != null)
				{
					LnNZXAxFBHDNVeiViTPpokfDGNMJ();
				}
			}
		}

		public event Action ValueChangedEvent
		{
			add
			{
				Action action = LnNZXAxFBHDNVeiViTPpokfDGNMJ;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, value);
					action = Interlocked.CompareExchange(ref LnNZXAxFBHDNVeiViTPpokfDGNMJ, value2, action2);
				}
				while ((object)action != action2);
			}
			remove
			{
				Action action = LnNZXAxFBHDNVeiViTPpokfDGNMJ;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value);
					action = Interlocked.CompareExchange(ref LnNZXAxFBHDNVeiViTPpokfDGNMJ, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		public HIDLight()
		{
		}

		public HIDLight(byte colorRRaw, byte colorGRaw, byte colorBRaw)
		{
			raFbyBdnTlmCSfVvGfDcujRmPqk = colorRRaw;
			DkSIuZVYGaqiqHAHZsqWtwpCeMa = colorGRaw;
			cMAWXzLOGPlPnanARVqoEbigbCC = colorBRaw;
		}
	}
}
