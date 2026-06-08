using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

internal class fJiCCdOhMgsAbjxKCRBiftpwrmH
{
	private class BPOmSBVIdcdizvDBCxbeRbYZJuu
	{
		private class RoGluaicoeqQKwYyiFrrLXztptI
		{
			private int agVDxkfWemHjQJaQAZaeOwvrWKHc;

			private BvHtBsOdgoVhYrmMurnSlExisOp[] YHGHlHoNtkOhmbsNDxUBNKVvRCH;

			private IIQXQDVgkExzrAzNWkSEVdDkgCa[] VwUbDdEqpqoVsZYgqEgrjcpevFan;

			public RoGluaicoeqQKwYyiFrrLXztptI(int index)
			{
				agVDxkfWemHjQJaQAZaeOwvrWKHc = index;
				YHGHlHoNtkOhmbsNDxUBNKVvRCH = new BvHtBsOdgoVhYrmMurnSlExisOp[20];
				for (int i = 0; i < YHGHlHoNtkOhmbsNDxUBNKVvRCH.Length; i++)
				{
					YHGHlHoNtkOhmbsNDxUBNKVvRCH[i] = new BvHtBsOdgoVhYrmMurnSlExisOp();
				}
				VwUbDdEqpqoVsZYgqEgrjcpevFan = new IIQXQDVgkExzrAzNWkSEVdDkgCa[29];
				for (int j = 0; j < VwUbDdEqpqoVsZYgqEgrjcpevFan.Length; j++)
				{
					VwUbDdEqpqoVsZYgqEgrjcpevFan[j] = new IIQXQDVgkExzrAzNWkSEVdDkgCa(j);
				}
			}

			public void HaBOvKvUIdSMsntTlUhVuRBYdtG()
			{
				int num = 0;
				int num4 = default(int);
				float joystickAxisRawValueByJoystickIndex = default(float);
				while (true)
				{
					int num2;
					int num3;
					if (num < YHGHlHoNtkOhmbsNDxUBNKVvRCH.Length)
					{
						num2 = 999925065;
						num3 = num2;
					}
					else
					{
						num2 = 999925071;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ 0x3B99A54C)
						{
						case 8:
							num2 = 999925065;
							continue;
						default:
							return;
						case 5:
						{
							bool joystickButtonValueByJoystickIndex = UnityInputHelper.GetJoystickButtonValueByJoystickIndex(agVDxkfWemHjQJaQAZaeOwvrWKHc, num);
							YHGHlHoNtkOhmbsNDxUBNKVvRCH[num].HaBOvKvUIdSMsntTlUhVuRBYdtG(joystickButtonValueByJoystickIndex);
							num++;
							num2 = 999925067;
							continue;
						}
						case 7:
							break;
						case 0:
						{
							int num5;
							if (num4 >= VwUbDdEqpqoVsZYgqEgrjcpevFan.Length)
							{
								num2 = 999925066;
								num5 = num2;
							}
							else
							{
								num2 = 999925069;
								num5 = num2;
							}
							continue;
						}
						case 4:
							num2 = 999925068;
							continue;
						case 1:
							joystickAxisRawValueByJoystickIndex = UnityInputHelper.GetJoystickAxisRawValueByJoystickIndex(agVDxkfWemHjQJaQAZaeOwvrWKHc, num4);
							num2 = 999925070;
							continue;
						case 3:
							num4 = 0;
							num2 = 999925064;
							continue;
						case 2:
							VwUbDdEqpqoVsZYgqEgrjcpevFan[num4].HaBOvKvUIdSMsntTlUhVuRBYdtG(joystickAxisRawValueByJoystickIndex);
							num4++;
							num2 = 999925068;
							continue;
						case 6:
							return;
						}
						break;
					}
				}
			}

			public void GzCliicOSMFLMvKajLgvnmGSSrh()
			{
				int num = 0;
				int num3 = default(int);
				while (true)
				{
					int num2 = 621782045;
					while (true)
					{
						switch (num2 ^ 0x250FA41B)
						{
						case 7:
							break;
						case 5:
							if (num >= YHGHlHoNtkOhmbsNDxUBNKVvRCH.Length)
							{
								num3 = 0;
								num2 = 621782041;
								continue;
							}
							goto case 0;
						case 3:
							VwUbDdEqpqoVsZYgqEgrjcpevFan[num3].value = UnityInputHelper.GetJoystickAxisRawValueByJoystickIndex(agVDxkfWemHjQJaQAZaeOwvrWKHc, num3);
							num2 = 621782042;
							continue;
						case 4:
							num++;
							num2 = 621782046;
							continue;
						case 6:
							num2 = 621782046;
							continue;
						case 0:
							YHGHlHoNtkOhmbsNDxUBNKVvRCH[num].value = UnityInputHelper.GetJoystickButtonValueByJoystickIndex(agVDxkfWemHjQJaQAZaeOwvrWKHc, num);
							num2 = 621782047;
							continue;
						case 1:
							num3++;
							num2 = 621782041;
							continue;
						default:
							if (num3 >= VwUbDdEqpqoVsZYgqEgrjcpevFan.Length)
							{
								return;
							}
							goto case 3;
						}
						break;
					}
				}
			}

			public bool jFcZHuafkqlzijBvuFElJkopdfY(int P_0)
			{
				if (P_0 < 0 || P_0 >= YHGHlHoNtkOhmbsNDxUBNKVvRCH.Length)
				{
					return false;
				}
				return YHGHlHoNtkOhmbsNDxUBNKVvRCH[P_0].value;
			}

			public bool onTOiISwdiwnVPNqdGBZbNYGehbR(int P_0)
			{
				if (P_0 < 0 || P_0 >= YHGHlHoNtkOhmbsNDxUBNKVvRCH.Length)
				{
					return false;
				}
				return YHGHlHoNtkOhmbsNDxUBNKVvRCH[P_0].justPressed;
			}

			public bool QNRTkSkGFuwIIacWXFtSgclWddbW(int P_0)
			{
				if (P_0 >= 0)
				{
					while (true)
					{
						int num = 1703106802;
						while (true)
						{
							switch (num ^ 0x658358F0)
							{
							case 0:
								break;
							case 2:
								goto IL_0022;
							default:
								goto end_IL_0004;
							}
							break;
							IL_0022:
							if (P_0 >= YHGHlHoNtkOhmbsNDxUBNKVvRCH.Length)
							{
								num = 1703106801;
								continue;
							}
							return YHGHlHoNtkOhmbsNDxUBNKVvRCH[P_0].justReleased;
						}
						continue;
						end_IL_0004:
						break;
					}
				}
				return false;
			}

			public float yVcOttFFFEXExGWTsiXvWxyyabi(int P_0)
			{
				if (P_0 < 0 || P_0 >= VwUbDdEqpqoVsZYgqEgrjcpevFan.Length)
				{
					return 0f;
				}
				return VwUbDdEqpqoVsZYgqEgrjcpevFan[P_0].value;
			}

			public bool PlnHzFXEMqTIBWtGqPRWRHdyRO(int P_0, bool P_1)
			{
				if (P_0 >= 0)
				{
					while (true)
					{
						int num = -712111863;
						while (true)
						{
							switch (num ^ -712111864)
							{
							case 2:
								break;
							case 1:
								goto IL_0022;
							default:
								goto end_IL_0004;
							}
							break;
							IL_0022:
							if (P_0 >= VwUbDdEqpqoVsZYgqEgrjcpevFan.Length)
							{
								num = -712111864;
								continue;
							}
							return VwUbDdEqpqoVsZYgqEgrjcpevFan[P_0].EfomNIIerZfdReJWaymsEQFbGDuv(P_1);
						}
						continue;
						end_IL_0004:
						break;
					}
				}
				return false;
			}

			public void tAgADqjTsMUxSqYXeDyJIdETYRAp()
			{
				int num = 0;
				int num2 = default(int);
				while (true)
				{
					int num3;
					if (num >= YHGHlHoNtkOhmbsNDxUBNKVvRCH.Length)
					{
						num2 = 0;
						num3 = -693139566;
						goto IL_0009;
					}
					goto IL_004d;
					IL_0009:
					while (true)
					{
						switch (num3 ^ -693139568)
						{
						case 5:
							num3 = -693139567;
							continue;
						case 3:
							break;
						case 0:
							num++;
							num3 = -693139565;
							continue;
						case 1:
							goto IL_004d;
						case 4:
							VwUbDdEqpqoVsZYgqEgrjcpevFan[num2].tAgADqjTsMUxSqYXeDyJIdETYRAp();
							num2++;
							num3 = -693139566;
							continue;
						default:
							if (num2 >= VwUbDdEqpqoVsZYgqEgrjcpevFan.Length)
							{
								return;
							}
							goto case 4;
						}
						break;
					}
					continue;
					IL_004d:
					YHGHlHoNtkOhmbsNDxUBNKVvRCH[num].tAgADqjTsMUxSqYXeDyJIdETYRAp();
					num3 = -693139568;
					goto IL_0009;
				}
			}
		}

		private class OymAjsquUjsTHNRaeArumaLrLCf
		{
			private BvHtBsOdgoVhYrmMurnSlExisOp[] YHGHlHoNtkOhmbsNDxUBNKVvRCH;

			public OymAjsquUjsTHNRaeArumaLrLCf()
			{
				YHGHlHoNtkOhmbsNDxUBNKVvRCH = new BvHtBsOdgoVhYrmMurnSlExisOp[7];
				for (int i = 0; i < YHGHlHoNtkOhmbsNDxUBNKVvRCH.Length; i++)
				{
					YHGHlHoNtkOhmbsNDxUBNKVvRCH[i] = new BvHtBsOdgoVhYrmMurnSlExisOp();
				}
			}

			public void GzCliicOSMFLMvKajLgvnmGSSrh()
			{
				int num = 0;
				while (num < YHGHlHoNtkOhmbsNDxUBNKVvRCH.Length)
				{
					while (true)
					{
						YHGHlHoNtkOhmbsNDxUBNKVvRCH[num].value = Input.GetButton("MouseButton" + num);
						num++;
						int num2 = -677250496;
						while (true)
						{
							switch (num2 ^ -677250495)
							{
							case 0:
								num2 = -677250493;
								continue;
							case 2:
								break;
							default:
								goto end_IL_0022;
							}
							break;
						}
						continue;
						end_IL_0022:
						break;
					}
				}
			}

			public bool jFcZHuafkqlzijBvuFElJkopdfY(int P_0)
			{
				if (P_0 < 0 || P_0 >= YHGHlHoNtkOhmbsNDxUBNKVvRCH.Length)
				{
					return false;
				}
				return YHGHlHoNtkOhmbsNDxUBNKVvRCH[P_0].value;
			}

			public bool onTOiISwdiwnVPNqdGBZbNYGehbR(int P_0)
			{
				if (P_0 >= 0)
				{
					while (true)
					{
						int num = -207138208;
						while (true)
						{
							switch (num ^ -207138207)
							{
							case 0:
								break;
							case 1:
								goto IL_0022;
							default:
								goto end_IL_0004;
							}
							break;
							IL_0022:
							if (P_0 >= YHGHlHoNtkOhmbsNDxUBNKVvRCH.Length)
							{
								num = -207138205;
								continue;
							}
							return YHGHlHoNtkOhmbsNDxUBNKVvRCH[P_0].justPressed;
						}
						continue;
						end_IL_0004:
						break;
					}
				}
				return false;
			}

			public bool QNRTkSkGFuwIIacWXFtSgclWddbW(int P_0)
			{
				if (P_0 < 0 || P_0 >= YHGHlHoNtkOhmbsNDxUBNKVvRCH.Length)
				{
					return false;
				}
				return YHGHlHoNtkOhmbsNDxUBNKVvRCH[P_0].justReleased;
			}

			public void tAgADqjTsMUxSqYXeDyJIdETYRAp()
			{
				int num = 0;
				while (num < YHGHlHoNtkOhmbsNDxUBNKVvRCH.Length)
				{
					while (true)
					{
						YHGHlHoNtkOhmbsNDxUBNKVvRCH[num].tAgADqjTsMUxSqYXeDyJIdETYRAp();
						int num2 = 1055193580;
						while (true)
						{
							switch (num2 ^ 0x3EE4F9ED)
							{
							case 0:
								num2 = 1055193583;
								continue;
							case 2:
								break;
							case 1:
								num++;
								num2 = 1055193582;
								continue;
							default:
								goto end_IL_0026;
							}
							break;
						}
						continue;
						end_IL_0026:
						break;
					}
				}
			}
		}

		private class BvHtBsOdgoVhYrmMurnSlExisOp
		{
			private bool HewmgBxnlqheeaCyBbxCmITSoEAX;

			private bool gFdeFoVLZpCBOkFYPVOzQudxsNiX;

			public bool value
			{
				get
				{
					return HewmgBxnlqheeaCyBbxCmITSoEAX;
				}
				set
				{
					gFdeFoVLZpCBOkFYPVOzQudxsNiX = HewmgBxnlqheeaCyBbxCmITSoEAX;
					HewmgBxnlqheeaCyBbxCmITSoEAX = value;
				}
			}

			public bool justPressed
			{
				get
				{
					if (HewmgBxnlqheeaCyBbxCmITSoEAX)
					{
						return !gFdeFoVLZpCBOkFYPVOzQudxsNiX;
					}
					return false;
				}
			}

			public bool justReleased
			{
				get
				{
					if (gFdeFoVLZpCBOkFYPVOzQudxsNiX)
					{
						return !HewmgBxnlqheeaCyBbxCmITSoEAX;
					}
					return false;
				}
			}

			public void HaBOvKvUIdSMsntTlUhVuRBYdtG(bool P_0)
			{
				HewmgBxnlqheeaCyBbxCmITSoEAX = P_0;
				while (true)
				{
					int num = 1178888212;
					while (true)
					{
						switch (num ^ 0x46446815)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							goto IL_0025;
						case 0:
							return;
						}
						break;
						IL_0025:
						gFdeFoVLZpCBOkFYPVOzQudxsNiX = P_0;
						num = 1178888213;
					}
				}
			}

			public void tAgADqjTsMUxSqYXeDyJIdETYRAp()
			{
				HewmgBxnlqheeaCyBbxCmITSoEAX = false;
				gFdeFoVLZpCBOkFYPVOzQudxsNiX = false;
			}
		}

		private class IIQXQDVgkExzrAzNWkSEVdDkgCa
		{
			private int PMseDxjZDtRvamemDItHYfHDQxf;

			private float HewmgBxnlqheeaCyBbxCmITSoEAX;

			private float icowlEukVowztxbwFVESUIUdEzHe;

			public float value
			{
				get
				{
					return HewmgBxnlqheeaCyBbxCmITSoEAX;
				}
				set
				{
					HewmgBxnlqheeaCyBbxCmITSoEAX = value;
				}
			}

			public IIQXQDVgkExzrAzNWkSEVdDkgCa(int axisIndex)
			{
				PMseDxjZDtRvamemDItHYfHDQxf = axisIndex;
			}

			public void HaBOvKvUIdSMsntTlUhVuRBYdtG(float P_0)
			{
				icowlEukVowztxbwFVESUIUdEzHe = P_0;
				HewmgBxnlqheeaCyBbxCmITSoEAX = P_0;
			}

			public bool EfomNIIerZfdReJWaymsEQFbGDuv(bool P_0)
			{
				float num = HewmgBxnlqheeaCyBbxCmITSoEAX - icowlEukVowztxbwFVESUIUdEzHe;
				if (P_0 && num < 0f)
				{
					return false;
				}
				if (MathTools.Abs(num) > 0.7f)
				{
					return true;
				}
				return false;
			}

			public void tAgADqjTsMUxSqYXeDyJIdETYRAp()
			{
				HewmgBxnlqheeaCyBbxCmITSoEAX = 0f;
				while (true)
				{
					int num = 1989453909;
					while (true)
					{
						switch (num ^ 0x7694A854)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							goto IL_0029;
						case 2:
							return;
						}
						break;
						IL_0029:
						icowlEukVowztxbwFVESUIUdEzHe = 0f;
						num = 1989453910;
					}
				}
			}
		}

		private RoGluaicoeqQKwYyiFrrLXztptI[] KjXmBSVldpfwjiNaozEQFsyjEtD;

		private OymAjsquUjsTHNRaeArumaLrLCf QsKjzCdyrVeEepaejRwEtsXGCvQ;

		public BPOmSBVIdcdizvDBCxbeRbYZJuu()
		{
			KjXmBSVldpfwjiNaozEQFsyjEtD = new RoGluaicoeqQKwYyiFrrLXztptI[16];
			for (int i = 0; i < KjXmBSVldpfwjiNaozEQFsyjEtD.Length; i++)
			{
				KjXmBSVldpfwjiNaozEQFsyjEtD[i] = new RoGluaicoeqQKwYyiFrrLXztptI(i);
			}
			QsKjzCdyrVeEepaejRwEtsXGCvQ = new OymAjsquUjsTHNRaeArumaLrLCf();
		}

		public void HaBOvKvUIdSMsntTlUhVuRBYdtG()
		{
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num >= KjXmBSVldpfwjiNaozEQFsyjEtD.Length)
				{
					num2 = -1152495274;
					num3 = num2;
				}
				else
				{
					num2 = -1152495276;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -1152495275)
					{
					case 2:
						num2 = -1152495276;
						continue;
					default:
						return;
					case 1:
						KjXmBSVldpfwjiNaozEQFsyjEtD[num].HaBOvKvUIdSMsntTlUhVuRBYdtG();
						num++;
						num2 = -1152495275;
						continue;
					case 0:
						break;
					case 3:
						return;
					}
					break;
				}
			}
		}

		public void GzCliicOSMFLMvKajLgvnmGSSrh()
		{
			int num = 0;
			while (num < KjXmBSVldpfwjiNaozEQFsyjEtD.Length)
			{
				while (true)
				{
					KjXmBSVldpfwjiNaozEQFsyjEtD[num].GzCliicOSMFLMvKajLgvnmGSSrh();
					num++;
					int num2 = -1934704747;
					while (true)
					{
						switch (num2 ^ -1934704745)
						{
						case 0:
							num2 = -1934704746;
							continue;
						case 1:
							break;
						default:
							goto end_IL_0022;
						}
						break;
					}
					continue;
					end_IL_0022:
					break;
				}
			}
			QsKjzCdyrVeEepaejRwEtsXGCvQ.GzCliicOSMFLMvKajLgvnmGSSrh();
		}

		public bool hGXrqMljwgAFREWrIxfbYBQVHqn(int P_0, int P_1)
		{
			if (P_0 >= 0)
			{
				while (true)
				{
					int num = -621340382;
					while (true)
					{
						switch (num ^ -621340381)
						{
						case 0:
							break;
						case 1:
							goto IL_0022;
						default:
							goto end_IL_0004;
						}
						break;
						IL_0022:
						if (P_0 >= KjXmBSVldpfwjiNaozEQFsyjEtD.Length)
						{
							num = -621340383;
							continue;
						}
						return KjXmBSVldpfwjiNaozEQFsyjEtD[P_0].jFcZHuafkqlzijBvuFElJkopdfY(P_1);
					}
					continue;
					end_IL_0004:
					break;
				}
			}
			return false;
		}

		public bool IWIFIRpTzKautLzErLHXSoulUx(int P_0, int P_1)
		{
			if (P_0 < 0 || P_0 >= KjXmBSVldpfwjiNaozEQFsyjEtD.Length)
			{
				return false;
			}
			return KjXmBSVldpfwjiNaozEQFsyjEtD[P_0].onTOiISwdiwnVPNqdGBZbNYGehbR(P_1);
		}

		public bool lVMqnFoiGYFLvOEqYEANFPpWlfng(int P_0, int P_1)
		{
			if (P_0 >= 0)
			{
				while (true)
				{
					int num = -568366590;
					while (true)
					{
						switch (num ^ -568366589)
						{
						case 0:
							break;
						case 1:
							goto IL_0022;
						default:
							goto end_IL_0004;
						}
						break;
						IL_0022:
						if (P_0 >= KjXmBSVldpfwjiNaozEQFsyjEtD.Length)
						{
							num = -568366591;
							continue;
						}
						return KjXmBSVldpfwjiNaozEQFsyjEtD[P_0].QNRTkSkGFuwIIacWXFtSgclWddbW(P_1);
					}
					continue;
					end_IL_0004:
					break;
				}
			}
			return false;
		}

		public bool ejsfksCaqpcjIpvPgTqFmRGgrYAQ(int P_0, int P_1, bool P_2)
		{
			if (P_0 >= 0)
			{
				while (true)
				{
					int num = 1043116484;
					while (true)
					{
						switch (num ^ 0x3E2CB1C5)
						{
						case 0:
							break;
						case 1:
							goto IL_0022;
						default:
							goto end_IL_0004;
						}
						break;
						IL_0022:
						if (P_0 >= KjXmBSVldpfwjiNaozEQFsyjEtD.Length)
						{
							num = 1043116487;
							continue;
						}
						return KjXmBSVldpfwjiNaozEQFsyjEtD[P_0].PlnHzFXEMqTIBWtGqPRWRHdyRO(P_1, P_2);
					}
					continue;
					end_IL_0004:
					break;
				}
			}
			return false;
		}

		public bool evjDkIjMSZfTJWeeTRQPPLdYDopO(int P_0)
		{
			return QsKjzCdyrVeEepaejRwEtsXGCvQ.jFcZHuafkqlzijBvuFElJkopdfY(P_0);
		}

		public bool xJfATUfnIAysYdyMKrAHrtWZILgF(int P_0)
		{
			return QsKjzCdyrVeEepaejRwEtsXGCvQ.onTOiISwdiwnVPNqdGBZbNYGehbR(P_0);
		}

		public bool saaTMAsusuqwGDWhNHxeAvDXFsj(int P_0)
		{
			return QsKjzCdyrVeEepaejRwEtsXGCvQ.QNRTkSkGFuwIIacWXFtSgclWddbW(P_0);
		}

		public void tAgADqjTsMUxSqYXeDyJIdETYRAp()
		{
			int num = 0;
			while (true)
			{
				int num2;
				if (num >= KjXmBSVldpfwjiNaozEQFsyjEtD.Length)
				{
					QsKjzCdyrVeEepaejRwEtsXGCvQ.tAgADqjTsMUxSqYXeDyJIdETYRAp();
					num2 = 1270678176;
					goto IL_0009;
				}
				goto IL_0052;
				IL_0009:
				while (true)
				{
					switch (num2 ^ 0x4BBD02A2)
					{
					case 3:
						num2 = 1270678179;
						continue;
					default:
						return;
					case 0:
						break;
					case 4:
						num++;
						num2 = 1270678178;
						continue;
					case 1:
						goto IL_0052;
					case 2:
						return;
					}
					break;
				}
				continue;
				IL_0052:
				KjXmBSVldpfwjiNaozEQFsyjEtD[num].tAgADqjTsMUxSqYXeDyJIdETYRAp();
				num2 = 1270678182;
				goto IL_0009;
			}
		}
	}

	private UpdateLoopType vuGbLgVYuadXzhzNZHvlhRNLlqP;

	private BPOmSBVIdcdizvDBCxbeRbYZJuu acnpoBoAxDpgNQhwTcuYGkYkHPu;

	private IndexedDictionary<int, BPOmSBVIdcdizvDBCxbeRbYZJuu> cnMdijtHVvTgZNQjViuuBmexAFT;

	public fJiCCdOhMgsAbjxKCRBiftpwrmH(UpdateLoopSetting updateLoopSetting)
	{
		cnMdijtHVvTgZNQjViuuBmexAFT = new IndexedDictionary<int, BPOmSBVIdcdizvDBCxbeRbYZJuu>();
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(updateLoopSetting, list);
			for (int i = 0; i < list.Count; i++)
			{
				cnMdijtHVvTgZNQjViuuBmexAFT.Add((int)list[i], new BPOmSBVIdcdizvDBCxbeRbYZJuu());
			}
		}
		vuGbLgVYuadXzhzNZHvlhRNLlqP = UpdateLoopType.Update;
		acnpoBoAxDpgNQhwTcuYGkYkHPu = cnMdijtHVvTgZNQjViuuBmexAFT.GetValue(0);
	}

	public void HaBOvKvUIdSMsntTlUhVuRBYdtG()
	{
		rPKlBVlHhYwVOZgWoldpGGuNJFl(ReInput.currentUpdateLoop);
		acnpoBoAxDpgNQhwTcuYGkYkHPu.HaBOvKvUIdSMsntTlUhVuRBYdtG();
	}

	public void GzCliicOSMFLMvKajLgvnmGSSrh(UpdateLoopType P_0)
	{
		rPKlBVlHhYwVOZgWoldpGGuNJFl(P_0);
		acnpoBoAxDpgNQhwTcuYGkYkHPu.GzCliicOSMFLMvKajLgvnmGSSrh();
	}

	public bool hGXrqMljwgAFREWrIxfbYBQVHqn(int P_0, int P_1)
	{
		return acnpoBoAxDpgNQhwTcuYGkYkHPu.hGXrqMljwgAFREWrIxfbYBQVHqn(P_0, P_1);
	}

	public bool IWIFIRpTzKautLzErLHXSoulUx(int P_0, int P_1)
	{
		return acnpoBoAxDpgNQhwTcuYGkYkHPu.IWIFIRpTzKautLzErLHXSoulUx(P_0, P_1);
	}

	public bool lVMqnFoiGYFLvOEqYEANFPpWlfng(int P_0, int P_1)
	{
		return acnpoBoAxDpgNQhwTcuYGkYkHPu.lVMqnFoiGYFLvOEqYEANFPpWlfng(P_0, P_1);
	}

	public bool ejsfksCaqpcjIpvPgTqFmRGgrYAQ(int P_0, int P_1, bool P_2)
	{
		return acnpoBoAxDpgNQhwTcuYGkYkHPu.ejsfksCaqpcjIpvPgTqFmRGgrYAQ(P_0, P_1, P_2);
	}

	public bool evjDkIjMSZfTJWeeTRQPPLdYDopO(int P_0)
	{
		return acnpoBoAxDpgNQhwTcuYGkYkHPu.evjDkIjMSZfTJWeeTRQPPLdYDopO(P_0);
	}

	public bool xJfATUfnIAysYdyMKrAHrtWZILgF(int P_0)
	{
		return acnpoBoAxDpgNQhwTcuYGkYkHPu.xJfATUfnIAysYdyMKrAHrtWZILgF(P_0);
	}

	public bool saaTMAsusuqwGDWhNHxeAvDXFsj(int P_0)
	{
		return acnpoBoAxDpgNQhwTcuYGkYkHPu.saaTMAsusuqwGDWhNHxeAvDXFsj(P_0);
	}

	public void tAgADqjTsMUxSqYXeDyJIdETYRAp()
	{
		int num = 0;
		while (num < cnMdijtHVvTgZNQjViuuBmexAFT.Count)
		{
			while (true)
			{
				cnMdijtHVvTgZNQjViuuBmexAFT[num].tAgADqjTsMUxSqYXeDyJIdETYRAp();
				int num2 = 452133272;
				while (true)
				{
					switch (num2 ^ 0x1AF30198)
					{
					case 2:
						num2 = 452133275;
						continue;
					case 3:
						break;
					case 0:
						num++;
						num2 = 452133273;
						continue;
					default:
						goto end_IL_0026;
					}
					break;
				}
				continue;
				end_IL_0026:
				break;
			}
		}
	}

	private void rPKlBVlHhYwVOZgWoldpGGuNJFl(UpdateLoopType P_0)
	{
		if (vuGbLgVYuadXzhzNZHvlhRNLlqP != P_0)
		{
			vuGbLgVYuadXzhzNZHvlhRNLlqP = P_0;
			acnpoBoAxDpgNQhwTcuYGkYkHPu = cnMdijtHVvTgZNQjViuuBmexAFT.GetValue((int)P_0);
		}
	}
}
