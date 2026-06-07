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
		private byte iwmjoOZMgPMhvNlPjMSYzeJslQQ;

		private byte kIWFBbliVAfBoiZUKYPcDDudurcqA;

		private byte QPXpYbnMlmqICFKAiDHbzQdEGRNgA;

		[CompilerGenerated]
		private Action zOHeuGaXXFeDybIwUdnHqLbepmOxA;

		public float ColorR
		{
			get
			{
				return (float)(int)iwmjoOZMgPMhvNlPjMSYzeJslQQ / 255f;
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
				return (float)(int)kIWFBbliVAfBoiZUKYPcDDudurcqA / 255f;
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
				return (float)(int)QPXpYbnMlmqICFKAiDHbzQdEGRNgA / 255f;
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
				return iwmjoOZMgPMhvNlPjMSYzeJslQQ;
			}
			set
			{
				iwmjoOZMgPMhvNlPjMSYzeJslQQ = value;
				if (zOHeuGaXXFeDybIwUdnHqLbepmOxA != null)
				{
					zOHeuGaXXFeDybIwUdnHqLbepmOxA();
				}
			}
		}

		public byte ColorGRaw
		{
			get
			{
				return kIWFBbliVAfBoiZUKYPcDDudurcqA;
			}
			set
			{
				kIWFBbliVAfBoiZUKYPcDDudurcqA = value;
				if (zOHeuGaXXFeDybIwUdnHqLbepmOxA != null)
				{
					zOHeuGaXXFeDybIwUdnHqLbepmOxA();
				}
			}
		}

		public byte ColorBRaw
		{
			get
			{
				return QPXpYbnMlmqICFKAiDHbzQdEGRNgA;
			}
			set
			{
				QPXpYbnMlmqICFKAiDHbzQdEGRNgA = value;
				if (zOHeuGaXXFeDybIwUdnHqLbepmOxA != null)
				{
					zOHeuGaXXFeDybIwUdnHqLbepmOxA();
				}
			}
		}

		public event Action ValueChangedEvent
		{
			[CompilerGenerated]
			add
			{
				Action action = zOHeuGaXXFeDybIwUdnHqLbepmOxA;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, value);
					action = Interlocked.CompareExchange(ref zOHeuGaXXFeDybIwUdnHqLbepmOxA, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			remove
			{
				Action action = zOHeuGaXXFeDybIwUdnHqLbepmOxA;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value);
					action = Interlocked.CompareExchange(ref zOHeuGaXXFeDybIwUdnHqLbepmOxA, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		public HIDLight()
		{
		}

		public HIDLight(byte P_0, byte P_1, byte P_2)
		{
			iwmjoOZMgPMhvNlPjMSYzeJslQQ = P_0;
			kIWFBbliVAfBoiZUKYPcDDudurcqA = P_1;
			QPXpYbnMlmqICFKAiDHbzQdEGRNgA = P_2;
		}
	}
}
