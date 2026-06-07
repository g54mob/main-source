using System;
using Rewired.Config;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired.HID
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class HIDGyroscope : HIDControllerElementWithDataSet
	{
		internal class SaOpYFunULCXqXjffzBhZRuRVvS : kpSgNRJMRzKQrZwlcddeBBGBDbsc
		{
			private int NLhLeTQcyTvcaxhsaxjEjXrcQgs;

			private int HAQqynUbEYcZzgLDAHwPRnfEwwfo;

			public float[] rawValue
			{
				get
				{
					return (CLjmYleEuCraJMMUJEFwtuAaGlg as dEhPSVIjIdsjzbboWeswANyUKTAX).ZIjTqFZkYVUthlHkiaPIqluvIsp;
				}
			}

			public ExpandableArray_DataContainer<fUKOPkxWszrPBUNUmlhKThawZdL> events
			{
				get
				{
					return (CLjmYleEuCraJMMUJEFwtuAaGlg as dEhPSVIjIdsjzbboWeswANyUKTAX).hkhDdGKzcECVygcMXcYuvVLXdMGW;
				}
			}

			public SaOpYFunULCXqXjffzBhZRuRVvS(UpdateLoopSetting updateLoopSetting, int valueLength, int eventCapacity)
			{
				NLhLeTQcyTvcaxhsaxjEjXrcQgs = valueLength;
				HAQqynUbEYcZzgLDAHwPRnfEwwfo = eventCapacity;
				hvfmLVrxQSWNdDBhcvYEClbOwhb(updateLoopSetting, IvrRSZQlnbvvOkajHWrRPFqUjMQ);
			}

			public override void Update(UpdateLoopType P_0)
			{
				base.Update(P_0);
				(CLjmYleEuCraJMMUJEFwtuAaGlg as dEhPSVIjIdsjzbboWeswANyUKTAX).rdEJYvExbWYUXSDuseVgzyXPBhA();
			}

			public void debMEvthktQBCCbIUOsfUPgDAQe(float[] P_0, float P_1)
			{
				int num = 0;
				while (true)
				{
					int num2;
					int num3;
					if (num >= FRUUibiOIWEsSCBxDuohaLtzlQrt.Length)
					{
						num2 = -1493423502;
						num3 = num2;
					}
					else
					{
						num2 = -1493423501;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -1493423502)
						{
						case 2:
							num2 = -1493423501;
							continue;
						default:
							return;
						case 1:
							(FRUUibiOIWEsSCBxDuohaLtzlQrt[num] as dEhPSVIjIdsjzbboWeswANyUKTAX).crDLQbknxaBSvjgLkmHtNpbfKZFF(P_0, P_1);
							num2 = -1493423498;
							continue;
						case 4:
							num++;
							num2 = -1493423503;
							continue;
						case 3:
							break;
						case 0:
							return;
						}
						break;
					}
				}
			}

			private YEGXFvUHUXCyKCwNcPcYimKmYc IvrRSZQlnbvvOkajHWrRPFqUjMQ(UpdateLoopType P_0)
			{
				return new dEhPSVIjIdsjzbboWeswANyUKTAX(P_0, NLhLeTQcyTvcaxhsaxjEjXrcQgs, HAQqynUbEYcZzgLDAHwPRnfEwwfo);
			}
		}

		internal class dEhPSVIjIdsjzbboWeswANyUKTAX : YEGXFvUHUXCyKCwNcPcYimKmYc
		{
			private float[] wNPECmLesqKnLIDePfuPpkPYtbZ;

			public float[] ZIjTqFZkYVUthlHkiaPIqluvIsp;

			public ExpandableArray_DataContainer<fUKOPkxWszrPBUNUmlhKThawZdL> hkhDdGKzcECVygcMXcYuvVLXdMGW;

			private ExpandableArray_DataContainer<fUKOPkxWszrPBUNUmlhKThawZdL> JodQTbtfCDhLRZEjHHchJDBIDWvO;

			public dEhPSVIjIdsjzbboWeswANyUKTAX(UpdateLoopType updateLoop, int valueLength, int eventCapacity)
				: base(updateLoop)
			{
				while (true)
				{
					int num = 1493768646;
					while (true)
					{
						switch (num ^ 0x590919C4)
						{
						case 0:
							break;
						case 2:
							goto IL_0025;
						default:
							wNPECmLesqKnLIDePfuPpkPYtbZ = new float[valueLength];
							hkhDdGKzcECVygcMXcYuvVLXdMGW = new ExpandableArray_DataContainer<fUKOPkxWszrPBUNUmlhKThawZdL>(eventCapacity, false, 20);
							JodQTbtfCDhLRZEjHHchJDBIDWvO = new ExpandableArray_DataContainer<fUKOPkxWszrPBUNUmlhKThawZdL>(eventCapacity, false, 20);
							return;
						}
						break;
						IL_0025:
						ZIjTqFZkYVUthlHkiaPIqluvIsp = new float[valueLength];
						num = 1493768645;
					}
				}
			}

			public void rdEJYvExbWYUXSDuseVgzyXPBhA()
			{
				int num = 0;
				int count = default(int);
				int num3 = default(int);
				while (true)
				{
					int num2 = -687560855;
					while (true)
					{
						switch (num2 ^ -687560863)
						{
						case 2:
							break;
						default:
							return;
						case 6:
							if (num >= wNPECmLesqKnLIDePfuPpkPYtbZ.Length)
							{
								hkhDdGKzcECVygcMXcYuvVLXdMGW.Clear();
								count = JodQTbtfCDhLRZEjHHchJDBIDWvO.Count;
								num2 = -687560864;
								continue;
							}
							goto case 0;
						case 3:
							num2 = -687560859;
							continue;
						case 8:
							num2 = -687560857;
							continue;
						case 4:
							if (num3 >= count)
							{
								JodQTbtfCDhLRZEjHHchJDBIDWvO.Clear();
								num2 = -687560858;
								continue;
							}
							goto case 5;
						case 5:
							hkhDdGKzcECVygcMXcYuvVLXdMGW.AddData(JodQTbtfCDhLRZEjHHchJDBIDWvO[num3]);
							num3++;
							num2 = -687560859;
							continue;
						case 0:
							ZIjTqFZkYVUthlHkiaPIqluvIsp[num] = wNPECmLesqKnLIDePfuPpkPYtbZ[num];
							wNPECmLesqKnLIDePfuPpkPYtbZ[num] = 0f;
							num++;
							num2 = -687560857;
							continue;
						case 1:
							num3 = 0;
							num2 = -687560862;
							continue;
						case 7:
							return;
						}
						break;
					}
				}
			}

			public void crDLQbknxaBSvjgLkmHtNpbfKZFF(float[] P_0, float P_1)
			{
				int num = 0;
				while (true)
				{
					int num2;
					int num3;
					if (num >= wNPECmLesqKnLIDePfuPpkPYtbZ.Length)
					{
						num2 = 661592241;
						num3 = num2;
					}
					else
					{
						num2 = 661592246;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ 0x276F18B4)
						{
						case 0:
							num2 = 661592246;
							continue;
						case 2:
							wNPECmLesqKnLIDePfuPpkPYtbZ[num] += P_0[num];
							num2 = 661592247;
							continue;
						case 1:
							break;
						case 3:
							num++;
							num2 = 661592245;
							continue;
						case 5:
						{
							fUKOPkxWszrPBUNUmlhKThawZdL injector = JodQTbtfCDhLRZEjHHchJDBIDWvO.injector;
							injector.KZkCmzhSYSECcInSnhPgKBxtRsI(P_0, P_1);
							num2 = 661592240;
							continue;
						}
						default:
							JodQTbtfCDhLRZEjHHchJDBIDWvO.Inject();
							return;
						}
						break;
					}
				}
			}

			public override void Reset()
			{
				Array.Clear(ZIjTqFZkYVUthlHkiaPIqluvIsp, 0, ZIjTqFZkYVUthlHkiaPIqluvIsp.Length);
				JodQTbtfCDhLRZEjHHchJDBIDWvO.Clear();
				hkhDdGKzcECVygcMXcYuvVLXdMGW.Clear();
			}
		}

		public class fUKOPkxWszrPBUNUmlhKThawZdL : ExpandableArray_DataContainer<fUKOPkxWszrPBUNUmlhKThawZdL>.auphSZvmhSLQzyipfcVqbmnlOPkA, IComparable<fUKOPkxWszrPBUNUmlhKThawZdL>
		{
			public Vector3 ZIjTqFZkYVUthlHkiaPIqluvIsp;

			public float obiuMVBNsaFUWKmAOQSExGWXESCf;

			public fUKOPkxWszrPBUNUmlhKThawZdL()
			{
			}

			public fUKOPkxWszrPBUNUmlhKThawZdL(float[] rawValues, float deltaTime)
			{
				while (true)
				{
					int num = 1705413333;
					while (true)
					{
						switch (num ^ 0x65A68AD7)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							goto IL_0024;
						case 1:
							return;
						}
						break;
						IL_0024:
						KZkCmzhSYSECcInSnhPgKBxtRsI(rawValues, deltaTime);
						num = 1705413334;
					}
				}
			}

			public void KZkCmzhSYSECcInSnhPgKBxtRsI(float[] P_0, float P_1)
			{
				int num = MathTools.Min(P_0.Length, 3);
				int num2 = 0;
				while (true)
				{
					int num3;
					int num4;
					if (num2 < num)
					{
						num3 = 2125877324;
						num4 = num3;
					}
					else
					{
						num3 = 2125877326;
						num4 = num3;
					}
					while (true)
					{
						switch (num3 ^ 0x7EB6504F)
						{
						case 4:
							num3 = 2125877324;
							continue;
						default:
							return;
						case 3:
							ZIjTqFZkYVUthlHkiaPIqluvIsp[num2] = P_0[num2];
							num2++;
							num3 = 2125877325;
							continue;
						case 2:
							break;
						case 1:
							obiuMVBNsaFUWKmAOQSExGWXESCf = P_1;
							num3 = 2125877327;
							continue;
						case 0:
							return;
						}
						break;
					}
				}
			}

			public void Set(fUKOPkxWszrPBUNUmlhKThawZdL P_0)
			{
				ZIjTqFZkYVUthlHkiaPIqluvIsp = P_0.ZIjTqFZkYVUthlHkiaPIqluvIsp;
				obiuMVBNsaFUWKmAOQSExGWXESCf = P_0.obiuMVBNsaFUWKmAOQSExGWXESCf;
			}

			public bool Equals(fUKOPkxWszrPBUNUmlhKThawZdL P_0)
			{
				if (obiuMVBNsaFUWKmAOQSExGWXESCf == P_0.obiuMVBNsaFUWKmAOQSExGWXESCf)
				{
					return ZIjTqFZkYVUthlHkiaPIqluvIsp == P_0.ZIjTqFZkYVUthlHkiaPIqluvIsp;
				}
				return false;
			}

			public void Clear()
			{
				ZIjTqFZkYVUthlHkiaPIqluvIsp.x = 0f;
				ZIjTqFZkYVUthlHkiaPIqluvIsp.y = 0f;
				ZIjTqFZkYVUthlHkiaPIqluvIsp.z = 0f;
				obiuMVBNsaFUWKmAOQSExGWXESCf = 0f;
			}

			public int CompareTo(fUKOPkxWszrPBUNUmlhKThawZdL other)
			{
				return 0;
			}
		}

		public float timestamp;

		public readonly float[] lastRawValue;

		public readonly int valueLength;

		private readonly byte[] FFOHNCJKQCbkumTZGCQQgbAkMqhU;

		private readonly float[] vtrQqwwAveFZqkVNoAZJKiPTWHB;

		private readonly int OejdrGdMwQDLTmmGAWRtpIFxxJ;

		private readonly int KYCBqRCUzCxlrIcXIRhSJUdgzrAw;

		private readonly Action<byte[], float[]> mrYChTVqXTCVxhzNiXVDRNAiSmHs;

		private readonly Func<float> xlvjRKsBHcapLImUAgbfLOzSsvw;

		public float[] rawValue
		{
			get
			{
				return (dataSet as SaOpYFunULCXqXjffzBhZRuRVvS).rawValue;
			}
		}

		public ExpandableArray_DataContainer<fUKOPkxWszrPBUNUmlhKThawZdL> events
		{
			get
			{
				return (dataSet as SaOpYFunULCXqXjffzBhZRuRVvS).events;
			}
		}

		public HIDGyroscope(UpdateLoopSetting updateLoopSetting, byte reportId, HIDInfo hidInfo, int valueLength, int startingEventCapacity, Action<byte[], float[]> calcValueDelegate, Func<float> getSensorDeltaTimeDelegate)
			: base(new SaOpYFunULCXqXjffzBhZRuRVvS(updateLoopSetting, valueLength, startingEventCapacity), reportId, hidInfo)
		{
			this.valueLength = valueLength;
			mrYChTVqXTCVxhzNiXVDRNAiSmHs = calcValueDelegate;
			xlvjRKsBHcapLImUAgbfLOzSsvw = getSensorDeltaTimeDelegate;
			OejdrGdMwQDLTmmGAWRtpIFxxJ = ((hidInfo.bitSize > 0) ? ((hidInfo.bitSize + 8 - 1) / 8) : 0);
			KYCBqRCUzCxlrIcXIRhSJUdgzrAw = hidInfo.dataIndex;
			FFOHNCJKQCbkumTZGCQQgbAkMqhU = new byte[OejdrGdMwQDLTmmGAWRtpIFxxJ];
			vtrQqwwAveFZqkVNoAZJKiPTWHB = new float[valueLength];
			lastRawValue = new float[valueLength];
		}

		public override void UpdateValue(NativeBuffer inputReport, float timestamps)
		{
			if (inputReport == null)
			{
				return;
			}
			int num4 = default(int);
			int num3 = default(int);
			while (inputReport[0] == reportId)
			{
				while (true)
				{
					IL_00ca:
					timestamp = timestamp;
					int num = 364713601;
					while (true)
					{
						switch (num ^ 0x15BD168B)
						{
						case 3:
							num = 364713609;
							continue;
						default:
							return;
						case 10:
							num4 = 0;
							num = 364713603;
							continue;
						case 0:
							break;
						case 7:
							FFOHNCJKQCbkumTZGCQQgbAkMqhU[num4] = inputReport[KYCBqRCUzCxlrIcXIRhSJUdgzrAw + num4];
							num4++;
							num = 364713603;
							continue;
						case 2:
							goto end_IL_000c;
						case 8:
							goto IL_00ad;
						case 11:
							goto IL_00ca;
						case 5:
							num = 364713611;
							continue;
						case 6:
							lastRawValue[num3] = vtrQqwwAveFZqkVNoAZJKiPTWHB[num3];
							num3++;
							num = 364713611;
							continue;
						case 1:
						{
							float num2 = ((xlvjRKsBHcapLImUAgbfLOzSsvw != null) ? xlvjRKsBHcapLImUAgbfLOzSsvw() : 0f);
							(dataSet as SaOpYFunULCXqXjffzBhZRuRVvS).debMEvthktQBCCbIUOsfUPgDAQe(vtrQqwwAveFZqkVNoAZJKiPTWHB, num2);
							num3 = 0;
							num = 364713614;
							continue;
						}
						case 4:
							if (mrYChTVqXTCVxhzNiXVDRNAiSmHs != null)
							{
								mrYChTVqXTCVxhzNiXVDRNAiSmHs(FFOHNCJKQCbkumTZGCQQgbAkMqhU, vtrQqwwAveFZqkVNoAZJKiPTWHB);
								num = 364713610;
								continue;
							}
							goto case 1;
						case 9:
							return;
						}
						int num5;
						if (num3 < valueLength)
						{
							num = 364713613;
							num5 = num;
						}
						else
						{
							num = 364713602;
							num5 = num;
						}
						continue;
						IL_00ad:
						int num6;
						if (num4 >= OejdrGdMwQDLTmmGAWRtpIFxxJ)
						{
							num = 364713615;
							num6 = num;
						}
						else
						{
							num = 364713612;
							num6 = num;
						}
						continue;
						end_IL_000c:
						break;
					}
					break;
				}
			}
		}
	}
}
