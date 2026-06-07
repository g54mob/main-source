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
		internal class xBEEwMAwEXppBpQeDlfzeIoXvSP : VxUwUEwsHpyhUrKaCKjiygOVwov
		{
			private int axtedEoAkHzHHPKjMAlUhOpganvb;

			private int eMUIfimpYMekCJfYwZaTsIbAXxsf;

			public float[] rawValue
			{
				get
				{
					return (xbRrcEKKIAKiQkVzQCekOswVHrJ as UHvFZMekCfSOGNSnqtquqJkGHSX).mgdDrIvxATYlYDqhWbLUTOsrlhk;
				}
			}

			public ExpandableArray_DataContainer<KGLRdXPUfwSsizYSSfUaLfurGQ> events
			{
				get
				{
					return (xbRrcEKKIAKiQkVzQCekOswVHrJ as UHvFZMekCfSOGNSnqtquqJkGHSX).GWfTyFXAiMBoDJEBdCWqJsHJsXZI;
				}
			}

			public xBEEwMAwEXppBpQeDlfzeIoXvSP(UpdateLoopSetting updateLoopSetting, int valueLength, int eventCapacity)
			{
				while (true)
				{
					int num = -1880091992;
					while (true)
					{
						switch (num ^ -1880091990)
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
						axtedEoAkHzHHPKjMAlUhOpganvb = valueLength;
						eMUIfimpYMekCJfYwZaTsIbAXxsf = eventCapacity;
						AhzGMQRtWGSyIzEkOTUIlpjMwgy(updateLoopSetting, nHzkRQoJbhAUbYwgjOSPkUsYGBB);
						num = -1880091989;
					}
				}
			}

			public override void Update(UpdateLoopType P_0)
			{
				base.Update(P_0);
				(xbRrcEKKIAKiQkVzQCekOswVHrJ as UHvFZMekCfSOGNSnqtquqJkGHSX).UZSQFwoMfSAzsmmSKmseCCiJWWD();
			}

			public void UwtFnoJFfhpphgNJcULdzGmVVVd(float[] P_0, float P_1)
			{
				int num = 0;
				while (true)
				{
					int num2;
					int num3;
					if (num >= gRSZlsGnOMePzdfqhIobycvdjXwm.Length)
					{
						num2 = -117213119;
						num3 = num2;
					}
					else
					{
						num2 = -117213117;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -117213119)
						{
						case 3:
							num2 = -117213117;
							continue;
						default:
							return;
						case 2:
							(gRSZlsGnOMePzdfqhIobycvdjXwm[num] as UHvFZMekCfSOGNSnqtquqJkGHSX).HMVGTeKrlsarQgYKYiDrPYtbbSAa(P_0, P_1);
							num++;
							num2 = -117213120;
							continue;
						case 1:
							break;
						case 0:
							return;
						}
						break;
					}
				}
			}

			private rBYVXUVToIgLLonOpRikzkiCPOx nHzkRQoJbhAUbYwgjOSPkUsYGBB(UpdateLoopType P_0)
			{
				return new UHvFZMekCfSOGNSnqtquqJkGHSX(P_0, axtedEoAkHzHHPKjMAlUhOpganvb, eMUIfimpYMekCJfYwZaTsIbAXxsf);
			}
		}

		internal class UHvFZMekCfSOGNSnqtquqJkGHSX : rBYVXUVToIgLLonOpRikzkiCPOx
		{
			private float[] NXFNbbjiyOxgeezDxqRQSZAImSn;

			public float[] mgdDrIvxATYlYDqhWbLUTOsrlhk;

			public ExpandableArray_DataContainer<KGLRdXPUfwSsizYSSfUaLfurGQ> GWfTyFXAiMBoDJEBdCWqJsHJsXZI;

			private ExpandableArray_DataContainer<KGLRdXPUfwSsizYSSfUaLfurGQ> gmnZwcNKKJepixOcbuDfeGLWDZm;

			public UHvFZMekCfSOGNSnqtquqJkGHSX(UpdateLoopType updateLoop, int valueLength, int eventCapacity)
				: base(updateLoop)
			{
				while (true)
				{
					int num = -905418070;
					while (true)
					{
						switch (num ^ -905418072)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							mgdDrIvxATYlYDqhWbLUTOsrlhk = new float[valueLength];
							NXFNbbjiyOxgeezDxqRQSZAImSn = new float[valueLength];
							num = -905418069;
							continue;
						case 3:
							GWfTyFXAiMBoDJEBdCWqJsHJsXZI = new ExpandableArray_DataContainer<KGLRdXPUfwSsizYSSfUaLfurGQ>(eventCapacity, false, 20);
							num = -905418068;
							continue;
						case 4:
							gmnZwcNKKJepixOcbuDfeGLWDZm = new ExpandableArray_DataContainer<KGLRdXPUfwSsizYSSfUaLfurGQ>(eventCapacity, false, 20);
							num = -905418071;
							continue;
						case 1:
							return;
						}
						break;
					}
				}
			}

			public void UZSQFwoMfSAzsmmSKmseCCiJWWD()
			{
				int num = 0;
				int num4 = default(int);
				int count = default(int);
				while (true)
				{
					int num2;
					int num3;
					if (num < NXFNbbjiyOxgeezDxqRQSZAImSn.Length)
					{
						num2 = -974786049;
						num3 = num2;
					}
					else
					{
						num2 = -974786054;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -974786053)
						{
						case 0:
							num2 = -974786049;
							continue;
						case 6:
							GWfTyFXAiMBoDJEBdCWqJsHJsXZI.AddData(gmnZwcNKKJepixOcbuDfeGLWDZm[num4]);
							num4++;
							num2 = -974786050;
							continue;
						case 3:
							NXFNbbjiyOxgeezDxqRQSZAImSn[num] = 0f;
							num++;
							num2 = -974786055;
							continue;
						case 4:
							mgdDrIvxATYlYDqhWbLUTOsrlhk[num] = NXFNbbjiyOxgeezDxqRQSZAImSn[num];
							num2 = -974786056;
							continue;
						case 2:
							break;
						case 1:
							GWfTyFXAiMBoDJEBdCWqJsHJsXZI.Clear();
							count = gmnZwcNKKJepixOcbuDfeGLWDZm.Count;
							num4 = 0;
							num2 = -974786050;
							continue;
						default:
							if (num4 >= count)
							{
								gmnZwcNKKJepixOcbuDfeGLWDZm.Clear();
								return;
							}
							goto case 6;
						}
						break;
					}
				}
			}

			public void HMVGTeKrlsarQgYKYiDrPYtbbSAa(float[] P_0, float P_1)
			{
				int num = 0;
				KGLRdXPUfwSsizYSSfUaLfurGQ injector = default(KGLRdXPUfwSsizYSSfUaLfurGQ);
				while (true)
				{
					int num2;
					int num3;
					if (num >= NXFNbbjiyOxgeezDxqRQSZAImSn.Length)
					{
						num2 = 1870383813;
						num3 = num2;
					}
					else
					{
						num2 = 1870383815;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ 0x6F7BCAC6)
						{
						case 0:
							num2 = 1870383815;
							continue;
						case 3:
							injector = gmnZwcNKKJepixOcbuDfeGLWDZm.injector;
							num2 = 1870383812;
							continue;
						case 4:
							break;
						case 1:
							NXFNbbjiyOxgeezDxqRQSZAImSn[num] += P_0[num];
							num++;
							num2 = 1870383810;
							continue;
						default:
							injector.fuLKaTfKQpOpktgPzRLpUDfEjf(P_0, P_1);
							gmnZwcNKKJepixOcbuDfeGLWDZm.Inject();
							return;
						}
						break;
					}
				}
			}

			public override void Reset()
			{
				Array.Clear(mgdDrIvxATYlYDqhWbLUTOsrlhk, 0, mgdDrIvxATYlYDqhWbLUTOsrlhk.Length);
				gmnZwcNKKJepixOcbuDfeGLWDZm.Clear();
				GWfTyFXAiMBoDJEBdCWqJsHJsXZI.Clear();
			}
		}

		public class KGLRdXPUfwSsizYSSfUaLfurGQ : ExpandableArray_DataContainer<KGLRdXPUfwSsizYSSfUaLfurGQ>.NQrrZCNstUmxUQSuHmBoRPhtvSn, IComparable<KGLRdXPUfwSsizYSSfUaLfurGQ>
		{
			public Vector3 mgdDrIvxATYlYDqhWbLUTOsrlhk;

			public float FeeKHQjHmaGhpevLgnOQQqEXhVFc;

			public KGLRdXPUfwSsizYSSfUaLfurGQ()
			{
			}

			public KGLRdXPUfwSsizYSSfUaLfurGQ(float[] rawValues, float deltaTime)
			{
				fuLKaTfKQpOpktgPzRLpUDfEjf(rawValues, deltaTime);
			}

			public void fuLKaTfKQpOpktgPzRLpUDfEjf(float[] P_0, float P_1)
			{
				int num = MathTools.Min(P_0.Length, 3);
				int num3 = default(int);
				while (true)
				{
					int num2 = 825479243;
					while (true)
					{
						switch (num2 ^ 0x3133D04A)
						{
						case 5:
							break;
						default:
							return;
						case 2:
							mgdDrIvxATYlYDqhWbLUTOsrlhk[num3] = P_0[num3];
							num3++;
							num2 = 825479246;
							continue;
						case 0:
							num2 = 825479246;
							continue;
						case 4:
							if (num3 >= num)
							{
								FeeKHQjHmaGhpevLgnOQQqEXhVFc = P_1;
								num2 = 825479241;
								continue;
							}
							goto case 2;
						case 1:
							num3 = 0;
							num2 = 825479242;
							continue;
						case 3:
							return;
						}
						break;
					}
				}
			}

			public void Set(KGLRdXPUfwSsizYSSfUaLfurGQ P_0)
			{
				mgdDrIvxATYlYDqhWbLUTOsrlhk = P_0.mgdDrIvxATYlYDqhWbLUTOsrlhk;
				FeeKHQjHmaGhpevLgnOQQqEXhVFc = P_0.FeeKHQjHmaGhpevLgnOQQqEXhVFc;
			}

			public bool Equals(KGLRdXPUfwSsizYSSfUaLfurGQ P_0)
			{
				if (FeeKHQjHmaGhpevLgnOQQqEXhVFc == P_0.FeeKHQjHmaGhpevLgnOQQqEXhVFc)
				{
					return mgdDrIvxATYlYDqhWbLUTOsrlhk == P_0.mgdDrIvxATYlYDqhWbLUTOsrlhk;
				}
				return false;
			}

			public void Clear()
			{
				mgdDrIvxATYlYDqhWbLUTOsrlhk.x = 0f;
				mgdDrIvxATYlYDqhWbLUTOsrlhk.y = 0f;
				mgdDrIvxATYlYDqhWbLUTOsrlhk.z = 0f;
				FeeKHQjHmaGhpevLgnOQQqEXhVFc = 0f;
			}

			public int CompareTo(KGLRdXPUfwSsizYSSfUaLfurGQ other)
			{
				return 0;
			}
		}

		public float timestamp;

		public readonly float[] lastRawValue;

		public readonly int valueLength;

		private readonly byte[] gFAMGFphEQAPPIsOqIUOiYImMxyK;

		private readonly float[] IJjPuvOIjgmvDENEKDmDhxVRAcS;

		private readonly int bzosNyaAYkqqmjdsmYcZCYXPqkG;

		private readonly int bKUWnIefrIOAGALIeelSjbpyaaDm;

		private readonly Action<byte[], float[]> LpQqRQdQRXwpWRSAKJEFyQEozHE;

		private readonly Func<float> SOpquRMJTuWZmiTUkbEfgdAUwjh;

		public float[] rawValue
		{
			get
			{
				return (dataSet as xBEEwMAwEXppBpQeDlfzeIoXvSP).rawValue;
			}
		}

		public ExpandableArray_DataContainer<KGLRdXPUfwSsizYSSfUaLfurGQ> events
		{
			get
			{
				return (dataSet as xBEEwMAwEXppBpQeDlfzeIoXvSP).events;
			}
		}

		public HIDGyroscope(UpdateLoopSetting updateLoopSetting, byte reportId, HIDInfo hidInfo, int valueLength, int startingEventCapacity, Action<byte[], float[]> calcValueDelegate, Func<float> getSensorDeltaTimeDelegate)
			: base(new xBEEwMAwEXppBpQeDlfzeIoXvSP(updateLoopSetting, valueLength, startingEventCapacity), reportId, hidInfo)
		{
			while (true)
			{
				int num = 1940973273;
				while (true)
				{
					switch (num ^ 0x73B0E6D8)
					{
					case 5:
						break;
					default:
						return;
					case 2:
						gFAMGFphEQAPPIsOqIUOiYImMxyK = new byte[bzosNyaAYkqqmjdsmYcZCYXPqkG];
						IJjPuvOIjgmvDENEKDmDhxVRAcS = new float[valueLength];
						lastRawValue = new float[valueLength];
						num = 1940973275;
						continue;
					case 0:
						bKUWnIefrIOAGALIeelSjbpyaaDm = hidInfo.dataIndex;
						num = 1940973274;
						continue;
					case 4:
						SOpquRMJTuWZmiTUkbEfgdAUwjh = getSensorDeltaTimeDelegate;
						bzosNyaAYkqqmjdsmYcZCYXPqkG = ((hidInfo.bitSize > 0) ? ((hidInfo.bitSize + 8 - 1) / 8) : 0);
						num = 1940973272;
						continue;
					case 1:
						this.valueLength = valueLength;
						LpQqRQdQRXwpWRSAKJEFyQEozHE = calcValueDelegate;
						num = 1940973276;
						continue;
					case 3:
						return;
					}
					break;
				}
			}
		}

		public override void UpdateValue(NativeBuffer inputReport, float timestamps)
		{
			if (inputReport == null)
			{
				return;
			}
			float num5 = default(float);
			int num3 = default(int);
			while (inputReport[0] == reportId)
			{
				while (true)
				{
					timestamp = timestamp;
					int num = 0;
					int num2 = -1445041913;
					while (true)
					{
						float num4;
						switch (num2 ^ -1445041913)
						{
						case 4:
							num2 = -1445041918;
							continue;
						case 7:
							num2 = -1445041916;
							continue;
						case 10:
							gFAMGFphEQAPPIsOqIUOiYImMxyK[num] = inputReport[bKUWnIefrIOAGALIeelSjbpyaaDm + num];
							num++;
							num2 = -1445041913;
							continue;
						case 6:
							if (SOpquRMJTuWZmiTUkbEfgdAUwjh == null)
							{
								num2 = -1445041914;
								continue;
							}
							num4 = SOpquRMJTuWZmiTUkbEfgdAUwjh();
							goto IL_00b8;
						case 11:
							(dataSet as xBEEwMAwEXppBpQeDlfzeIoXvSP).UwtFnoJFfhpphgNJcULdzGmVVVd(IJjPuvOIjgmvDENEKDmDhxVRAcS, num5);
							num3 = 0;
							num2 = -1445041920;
							continue;
						case 1:
							num4 = 0f;
							goto IL_00b8;
						case 2:
							break;
						case 8:
							lastRawValue[num3] = IJjPuvOIjgmvDENEKDmDhxVRAcS[num3];
							num3++;
							num2 = -1445041916;
							continue;
						case 9:
							if (LpQqRQdQRXwpWRSAKJEFyQEozHE != null)
							{
								LpQqRQdQRXwpWRSAKJEFyQEozHE(gFAMGFphEQAPPIsOqIUOiYImMxyK, IJjPuvOIjgmvDENEKDmDhxVRAcS);
								num2 = -1445041919;
								continue;
							}
							goto case 6;
						case 5:
							goto end_IL_00c3;
						case 0:
							goto IL_013f;
						default:
							{
								if (num3 >= valueLength)
								{
									return;
								}
								goto case 8;
							}
							IL_00b8:
							num5 = num4;
							num2 = -1445041908;
							continue;
						}
						break;
						IL_013f:
						int num6;
						if (num >= bzosNyaAYkqqmjdsmYcZCYXPqkG)
						{
							num2 = -1445041906;
							num6 = num2;
						}
						else
						{
							num2 = -1445041907;
							num6 = num2;
						}
					}
					continue;
					end_IL_00c3:
					break;
				}
			}
		}
	}
}
