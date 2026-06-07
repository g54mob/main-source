using System;
using System.Threading;
using Rewired.Utils;

namespace Rewired.HID
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class HIDLight
	{
		private byte EPAdSbHqFRSlfVDksqBiTObjzUM;

		private byte mpZaehhbIUrJLSRUlLsKdRBILCEk;

		private byte BDLhsDDfOnBMEXuXrHDkfqIBnHun;

		private Action ecKvzyNgFvgosguICrPvIgXKmra;

		public float ColorR
		{
			get
			{
				return (float)(int)EPAdSbHqFRSlfVDksqBiTObjzUM / 255f;
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
				return (float)(int)mpZaehhbIUrJLSRUlLsKdRBILCEk / 255f;
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
				return (float)(int)BDLhsDDfOnBMEXuXrHDkfqIBnHun / 255f;
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
				return EPAdSbHqFRSlfVDksqBiTObjzUM;
			}
			set
			{
				EPAdSbHqFRSlfVDksqBiTObjzUM = value;
				while (true)
				{
					int num = -829547981;
					while (true)
					{
						switch (num ^ -829547983)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							if (ecKvzyNgFvgosguICrPvIgXKmra != null)
							{
								goto IL_002d;
							}
							return;
						case 1:
							return;
						}
						break;
						IL_002d:
						ecKvzyNgFvgosguICrPvIgXKmra();
						num = -829547984;
					}
				}
			}
		}

		public byte ColorGRaw
		{
			get
			{
				return mpZaehhbIUrJLSRUlLsKdRBILCEk;
			}
			set
			{
				mpZaehhbIUrJLSRUlLsKdRBILCEk = value;
				while (true)
				{
					int num = -1347743508;
					while (true)
					{
						switch (num ^ -1347743507)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							if (ecKvzyNgFvgosguICrPvIgXKmra != null)
							{
								goto IL_002d;
							}
							return;
						case 0:
							return;
						}
						break;
						IL_002d:
						ecKvzyNgFvgosguICrPvIgXKmra();
						num = -1347743507;
					}
				}
			}
		}

		public byte ColorBRaw
		{
			get
			{
				return BDLhsDDfOnBMEXuXrHDkfqIBnHun;
			}
			set
			{
				BDLhsDDfOnBMEXuXrHDkfqIBnHun = value;
				while (true)
				{
					int num = -769926255;
					while (true)
					{
						switch (num ^ -769926254)
						{
						case 2:
							break;
						default:
							return;
						case 3:
						{
							int num2;
							if (ecKvzyNgFvgosguICrPvIgXKmra != null)
							{
								num = -769926254;
								num2 = num;
							}
							else
							{
								num = -769926253;
								num2 = num;
							}
							continue;
						}
						case 0:
							ecKvzyNgFvgosguICrPvIgXKmra();
							num = -769926253;
							continue;
						case 1:
							return;
						}
						break;
					}
				}
			}
		}

		public event Action ValueChangedEvent
		{
			add
			{
				Action action = ecKvzyNgFvgosguICrPvIgXKmra;
				Action action2 = default(Action);
				Action value2 = default(Action);
				while (true)
				{
					int num = 1517790253;
					while (true)
					{
						switch (num ^ 0x5A77A42F)
						{
						case 3:
							break;
						case 2:
							action2 = action;
							value2 = (Action)Delegate.Combine(action2, value);
							num = 1517790254;
							continue;
						case 1:
							action = Interlocked.CompareExchange(ref ecKvzyNgFvgosguICrPvIgXKmra, value2, action2);
							num = 1517790255;
							continue;
						default:
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
				Action action = ecKvzyNgFvgosguICrPvIgXKmra;
				Action action2 = default(Action);
				Action value2 = default(Action);
				while (true)
				{
					int num = -1321970319;
					while (true)
					{
						switch (num ^ -1321970320)
						{
						case 2:
							break;
						case 1:
							action2 = action;
							num = -1321970317;
							continue;
						case 3:
							value2 = (Action)Delegate.Remove(action2, value);
							num = -1321970320;
							continue;
						default:
							action = Interlocked.CompareExchange(ref ecKvzyNgFvgosguICrPvIgXKmra, value2, action2);
							if ((object)action == action2)
							{
								return;
							}
							goto case 1;
						}
						break;
					}
				}
			}
		}

		public HIDLight()
		{
		}

		public HIDLight(byte colorRRaw, byte colorGRaw, byte colorBRaw)
		{
			EPAdSbHqFRSlfVDksqBiTObjzUM = colorRRaw;
			mpZaehhbIUrJLSRUlLsKdRBILCEk = colorGRaw;
			BDLhsDDfOnBMEXuXrHDkfqIBnHun = colorBRaw;
		}
	}
}
