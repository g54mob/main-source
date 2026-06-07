using System;
using System.Threading;
using Rewired.Utils;

namespace Rewired.HID
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class HIDLight
	{
		private byte ZttKXzKNkqCxECzDBhHtfMmKkgE;

		private byte dwMdtagdvhNaeSvJSgRanCswyEw;

		private byte SZafBRchvASPxdufQTylGPkOhWy;

		private Action twjymmIokCwhTlnPjZXgsCWpVVs;

		public float ColorR
		{
			get
			{
				return (float)(int)ZttKXzKNkqCxECzDBhHtfMmKkgE / 255f;
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
				return (float)(int)dwMdtagdvhNaeSvJSgRanCswyEw / 255f;
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
				return (float)(int)SZafBRchvASPxdufQTylGPkOhWy / 255f;
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
				return ZttKXzKNkqCxECzDBhHtfMmKkgE;
			}
			set
			{
				ZttKXzKNkqCxECzDBhHtfMmKkgE = value;
				if (twjymmIokCwhTlnPjZXgsCWpVVs != null)
				{
					twjymmIokCwhTlnPjZXgsCWpVVs();
				}
			}
		}

		public byte ColorGRaw
		{
			get
			{
				return dwMdtagdvhNaeSvJSgRanCswyEw;
			}
			set
			{
				dwMdtagdvhNaeSvJSgRanCswyEw = value;
				if (twjymmIokCwhTlnPjZXgsCWpVVs != null)
				{
					twjymmIokCwhTlnPjZXgsCWpVVs();
				}
			}
		}

		public byte ColorBRaw
		{
			get
			{
				return SZafBRchvASPxdufQTylGPkOhWy;
			}
			set
			{
				SZafBRchvASPxdufQTylGPkOhWy = value;
				if (twjymmIokCwhTlnPjZXgsCWpVVs != null)
				{
					twjymmIokCwhTlnPjZXgsCWpVVs();
				}
			}
		}

		public event Action ValueChangedEvent
		{
			add
			{
				Action action = twjymmIokCwhTlnPjZXgsCWpVVs;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, value);
					action = Interlocked.CompareExchange(ref twjymmIokCwhTlnPjZXgsCWpVVs, value2, action2);
				}
				while ((object)action != action2);
			}
			remove
			{
				Action action = twjymmIokCwhTlnPjZXgsCWpVVs;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value);
					action = Interlocked.CompareExchange(ref twjymmIokCwhTlnPjZXgsCWpVVs, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		public HIDLight()
		{
		}

		public HIDLight(byte colorRRaw, byte colorGRaw, byte colorBRaw)
		{
			ZttKXzKNkqCxECzDBhHtfMmKkgE = colorRRaw;
			dwMdtagdvhNaeSvJSgRanCswyEw = colorGRaw;
			SZafBRchvASPxdufQTylGPkOhWy = colorBRaw;
		}
	}
}
